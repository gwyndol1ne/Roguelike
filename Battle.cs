using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Battle
    {
        private Entity[] friend;
        private Entity[] enemy;
        public Battle(Entity f, Entity[] e)
        {
            friend = new Entity[1];
            friend[0] = f;
            enemy = e;
            Begin();
        }
        private void Begin()
        {
            GameInterface.DrawBattleInterface(enemy, friend[0]);

        }


    }
}
