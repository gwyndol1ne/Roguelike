using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    [Serializable]
    public class Item
    {
        /*public enum Slot
        {
            None = 0,
            LeftHand = 1,
            RightHand = 2,
            Head = 3,
            Body = 4,
            Legs = 5,
            Foot = 6,
            Ring = 7,
            Amulet = 8,
        }*/

        public int Id { get; }
        public string Name { get; }
        public Item(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
