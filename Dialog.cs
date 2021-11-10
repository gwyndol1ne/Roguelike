using System;
using System.Collections.Generic;
using System.Text;

namespace Roguelike
{
    class Dialog
    {
        private List<string> message;
        private List<string> otwet;
        public Dialog(List<string> Message,List<string> Otwet) 
        {
            message = Message;
            otwet = Otwet;
        }
       
    }
    
}
