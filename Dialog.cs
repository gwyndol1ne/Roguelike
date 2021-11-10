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
        private List<string> reactionmsg;
        public Dialog(List<string> Message,List<string> Otwet, List<string> Reactionmsg) 
        {
            message = Message;
            otwet = Otwet;
            reactionmsg = Reactionmsg;
        }
        public int GetDialog(NPC nPC)
        {
            Console.Write(nPC.Name + ":");
            Menu DialogOtwet = new Menu(otwet);
            reaction = DialogOtwet.GetChoice(true, message[0]);
            Console.Clear();
            Console.WriteLine(nPC.Name + ":" + message[0]);
            Console.WriteLine("Вы:" + otwet[reaction]);
            Console.WriteLine(nPC.Name + ":" + reactionmsg[reaction]);
            Console.WriteLine("Для выхода из диалога нажмите ENTER");
            string[] leaVe = new string[1];
            leaVe[0] = "Я пожалуй пойду ";
            Menu LeaveMenu = new Menu(leaVe);            
            return reaction = LeaveMenu.GetChoice(reaction);
           
            
        }
    }
    
}
