using QuestWar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestWar
{
    public class MonsterNpc : Npc
    {
        public override int Id { get; set; }
        public override string Description { get; set; }
        public override bool CanBattle { get; set; } = true;
        public bool RemoveWhenDefeated { get; set; }

        public Func<List<Monster>> SpawnMonstersForBattle { get; set; }
        public List<string> Messages { get; internal set; }
    }
}
