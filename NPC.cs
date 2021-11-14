using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class NPC : Entity
    {
        public NPC(string Name, int Hp, int Damage, int Strength, int Agility, int Intelligence, int Defense, int MapId, int X, int Y) : 
              base(Name, Hp, Damage, Strength,  Agility, Intelligence, Defense, MapId, X, Y)
        {
            Maps.SetNpc(MapId, this, X, Y);
        }
        public List<Item> TiefsBag = ItemCollector.GetAllItems();
        public List<string> GetTiefsItemNames()
        {
            List<string> TiefsItemsName = new List<string>(); 
            for (int i = 0; i < TiefsBag.Count; i++)
            {
                TiefsItemsName.Add(TiefsBag[i].Name);
            }
            TiefsItemsName.Add("Забрать все");
            TiefsItemsName.Add("Выйти");
            return TiefsItemsName;
        }
        
    }
}
