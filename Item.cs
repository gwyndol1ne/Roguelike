using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    public class Item
    {
        private int id;
        private string name;

        public Item(int Id, string Name)
        {
            id = Id;
            name = Name;
        }
        public string Name
        {
            get { return name; }
        }
        public int Id
        {
            get { return id; }
        }
    }
}
