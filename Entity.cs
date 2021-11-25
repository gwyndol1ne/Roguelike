﻿using System;
using System.Collections.Generic;

namespace Roguelike
{
    [Serializable]
    public class Entity
    {
        public Entity(string name, int hp, int damage, int strength, int agility, int intelligence, int defense, int mapId, int x, int y, char symb)
        {
            Name = name;
            MapId = mapId;
            X = x;
            Y = y;
            Symbol = symb;
            Alive = true;
            Stats = new Dictionary<string, int[]>();
            EffectBuffs = new Dictionary<string, List<EffectBuff>>();
            EffectActions = new List<EffectAction>();
            SetupEffects(new int[] { hp, damage, strength, agility, intelligence, defense });
            UpdateEffects();
            Stats["hp"][1] = Stats["hp"][0];
            Maps.SetEntity(mapId, x, y, this);
        }
        public bool Stunned { get; set; }
        public bool Alive { get; set; }
        public char Symbol { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int MapId { get; set; }
        public Dictionary<string, int[]> Stats { get; } //иди нахуй (с)программа
        public Dictionary<string, List<EffectBuff>> EffectBuffs { get; }
        public List<EffectAction> EffectActions { get; set; }
        public string[] StatNames = { "hp", "damage", "strength", "agility", "intelligence", "defense" };
        private string[] buffNames = { "hp", "damage", "strength", "agility", "intelligence", "defense", "stun" };
        public void ChangeStatsByTarot(int tarotNumber)
        {
            Stats["hp"][0] += Tarot.Tarots[tarotNumber].HP;
            Stats["hp"][1] += Tarot.Tarots[tarotNumber].HP;
            Stats["damage"][0] += Tarot.Tarots[tarotNumber].Damage;
            Stats["strength"][0] += Tarot.Tarots[tarotNumber].Strength;
            Stats["agility"][0] += Tarot.Tarots[tarotNumber].Agility;
            Stats["intelligence"][0] += Tarot.Tarots[tarotNumber].Intelligence;
            Stats["defense"][0] += Tarot.Tarots[tarotNumber].Defense;
        }
        public bool ChangeStat(int statNumber, int value)
        {
            if (statNumber == 0 && value <= 0) return false;
            if (statNumber == 0)
            {
                Stats["hp"][0] = value;
                Stats["hp"][1] = value;
                return true;
            }
            Stats[StatNames[statNumber]][0] = value;
            return true;
        }
        private void SetupEffects(int[] stats)
        {
            for (int i = 0; i < StatNames.Length; i++) AddFieldToStats(StatNames[i], stats[i]);
            for (int i = 0; i < buffNames.Length; i++) AddEffectField(buffNames[i]);
        }
        private void AddFieldToStats(string name, int value)
        {
            Stats.Add(name, new int[2]);
            Stats[name][0] = value;
        }
        private void AddEffectField(string name)
        {
            EffectBuffs.Add(name, new List<EffectBuff>());
        }
        public bool Move(int dirX, int dirY)
        {
            int startingMapId = MapId;
            if (!MovementManager.TryMove(this, dirX, dirY))
            {
                int gameStatus = MovementManager.CantMoveDecider(MapId, X + dirX, Y + dirY);
                if (this is Player)
                {
                    Program.currentGame.GameStatus = (Game.Status)gameStatus;
                }
                else if (this is Enemy)
                {
                    if (gameStatus == (int)Game.Status.InBattleForEntity) Program.currentGame.GameStatus = Game.Status.InBattle;
                }
                return false;
            }
            if (startingMapId != MapId) return false;
            return true;
        }
        public void MoveTowards(int x, int y)
        {
            point direction = Pathfinder.GetPath(Y, (X + 1) / 2, y, (x + 1) / 2, Maps.GetPassable(MapId))[0];
            direction.y *= 2;
            Move(direction.y, direction.x);
        }
        public int GetDamaged(int damage, bool ignoreArmor = false, Entity[] enemies = null)
        {
            int damageRecieved;
            if (!ignoreArmor) {
                double percentBlocked = (Stats["defense"][1] * 0.01) / (1 + Stats["defense"][1] * 0.01);
                damageRecieved = (int)Math.Round(Convert.ToDouble(damage) * (1 - percentBlocked));
            }
            else damageRecieved = damage;
            //да да давай говори я же понимаю все
            if (damageRecieved >= Stats["hp"][1])
            {
                Stats["hp"][1] = 0;
                Alive = false;
            }
            else Stats["hp"][1] -= damageRecieved;
            if (EffectActions != null)
            {
                for (int i = 0; i < EffectActions.Count; i++)
                {
                    if (EffectActions[i].action == EffectAction.LoversEffect) EffectActions[i].action(enemies, damage);
                }
            }
            return damageRecieved;
        }
        public void UpdateEffects()
        {
            foreach (string key in StatNames)
            {
                if (key != "hp") Stats[key][1] = Stats[key][0];
                foreach (EffectBuff buff in EffectBuffs[key])
                {
                    Stats[key][1] += buff.value;
                }
            }
            if (EffectBuffs["stun"].Count != 0) Stunned = true;
            else Stunned = false;
            List<int> toDelete = new List<int>();
            foreach (string key in EffectBuffs.Keys)
            {
                for (int i = 0; i < EffectBuffs[key].Count; i++)
                {
                    EffectBuffs[key][i].duration--;
                    if (EffectBuffs[key][i].duration == 0) toDelete.Add(i);
                }
                for (int i = toDelete.Count - 1; i > -1; i--) EffectBuffs[key].RemoveAt(toDelete[i]);
                toDelete.Clear();
            }
            for(int i = 0; i < EffectActions.Count; i++)
            {
                EffectActions[i].duration--;
                if (EffectActions[i].duration == 0) toDelete.Add(i);
            }
            for (int i = toDelete.Count - 1; i > -1; i--) EffectActions.RemoveAt(toDelete[i]);
            toDelete.Clear();
            if(this is Player) ((Player)this).CountStatsByItems();
        }
    }
}