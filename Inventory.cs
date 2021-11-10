using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Inventory
    {
        private List<Item> items = new List<Item>();

        public void AddItem (Item item)
        {
            items.Add(item);
        }
    }
}
