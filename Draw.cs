using System;
using System.Collections.Generic;
using System.Text;

namespace Screen
{
    class Draw
    {
        public void draw(string[] screen)
        {
            for(int i = 0; i < screen.Length; i++)
            {
                Console.WriteLine(screen[i]);
            }
        }
    }
}
