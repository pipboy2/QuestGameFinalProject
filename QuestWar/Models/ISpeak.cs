using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestWar
{
    interface ISpeak
    {
        List<string> Messages { get; set; }

        string Speak();
    }
}
