using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestWar
{
    public class Civillian : Npc, ISpeak
    {
        public override int Id { get; set; }
        public override string Description { get; set; }
        public override bool CanBattle { get; set; } = false;
        public List<string> Messages { get; set; }

        //
        // generate a message or use default
        //
        
        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return "";
            }
        }

        //
        // randomly select a message from the list of messages
        // 
        
        private string GetMessage()
        {
            Random r = new Random();
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }
    }
}
