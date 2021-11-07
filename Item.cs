using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Item
    {
        private int id;
        private string name;

        public string Name { get { return name; } } 
        public Item(int Id, string Name)
        {
            id = Id;
            name = Name;
        }
    }
}
