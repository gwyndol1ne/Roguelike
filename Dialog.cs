using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Dialog
    {
        int reaction;
        private List<string> message;
        private List<string> otwet;
        public Dialog(List<string> Message,List<string> Otwet) 
        {
            message = Message;
            otwet = Otwet;
        }
       public void GetDialog(NPC nPC)
        {
            Console.WriteLine("Привет меня зовут{0}, a тебя ?",nPC.Name);
            Menu DialogOtwet = new Menu(otwet);
            reaction= DialogOtwet.GetChoice(true,message[0]);
            Console.Clear();
            Console.WriteLine("Привет меня зовут{0}", nPC.Name);
            Console.WriteLine(otwet[reaction]);
          
        }
    }
    
}
