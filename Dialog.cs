using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Dialog
    {
        int reaction;
        private readonly List<string> message;
        private readonly List<string> otwet;
        private readonly List<string> reactionmsg;
        public Dialog(List<string> Message,List<string> Otwet, List<string> Reactionmsg) 
        {
            message = Message;
            otwet = Otwet;
            reactionmsg = Reactionmsg;
        }
        public int GetDialog(NPC nPC,Player player,NPC nPC1)
        {

            Console.Write(nPC.Name + ":");
            Menu DialogOtwet = new Menu(otwet);           
            reaction = DialogOtwet.GetChoice(true, message[0],1);
            Console.Clear();
            string dialogVAlue = nPC.Name + ":"+message[0]+'\n' +"Вы:" + otwet[reaction]+ '\n' + nPC.Name + ":" + reactionmsg[reaction]+'\n';
            if (reaction==nPC.TrigerNummber&player.QuestNumber==0&nPC==nPC1)
            {
                player.Quests[player.QuestNumber].trigger = true;
            }
            string[] leaVe = new string[1];
            leaVe[0] = "Я пожалуй пойду ";
         
            Menu LeaveMenu = new Menu(leaVe);
            reaction = LeaveMenu.GetChoice(true,dialogVAlue,3);
            return reaction;
           
            
        }
    }
    
}
