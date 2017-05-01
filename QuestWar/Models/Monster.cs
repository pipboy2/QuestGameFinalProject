using QuestWar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestWar
{
    public class Monster : Character
    {
        public int ExpGained { get; set; }
        public int MaxAttack { get; set; }
        public int Gold { get; set; }
    }
}
