using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    [Serializable]
    public class NPC : Entity
    {
        public NPC(string Name, int Hp, int Damage, int Strength, int Agility, int Intelligence, int Defense, int MapId, int X, int Y, char Symbol,int trigerNummber) : base(Name, Hp, Damage, Strength,  Agility, Intelligence, Defense, MapId, X, Y, Symbol)
        {
            TrigerNummber = trigerNummber;
        }
        public int TrigerNummber { get; set; }
        public List<Item> NPCInventory = ItemCollector.GetAllItems();
        public List<string> GetTiefsItemNames()
        {
            List<string> TiefsItemsName = new List<string>(); 
            for (int i = 0; i < NPCInventory.Count; i++)
            {
                TiefsItemsName.Add(NPCInventory[i].Name);
            }
            if (NPCInventory.Count>0)
            {
                TiefsItemsName.Add("Забрать все");
            }
           
            TiefsItemsName.Add("Выйти");
            return TiefsItemsName;
        }
        
        
    }
}
