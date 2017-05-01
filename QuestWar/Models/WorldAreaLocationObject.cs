using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestWar
{
    public class WorldAreaLocationObject : GameObject
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int WorldAreaLocationId { get; set; }
        public bool IsDeadly { get; set; }
    }
}
