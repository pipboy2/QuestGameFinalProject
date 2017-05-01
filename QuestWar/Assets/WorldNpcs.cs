using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAionProject.Models;

namespace QuestWar
{
    public static partial class WorldObjects
    {
        public static List<Npc> Npcs = new List<Npc>()
        {
            new Civillian
            {
                Id = 1,
                Name = "The town drunk",
                WorldAreaLocationID = 2,
                Description = "This is a man that has been down on his luck and smells like something the cat would throw away",
                Messages = new List<string>
                {
                    "Will work for ale. 'hic' ",
                    "I was married once, until i took an arrow to the knee.",
                    "*BURP*"
                }
            },

            new Civillian
            {
                Id = 2,
                Name = "Sir Lockhart",
                WorldAreaLocationID = 1,
                Description = "Captain of the gull",
                Messages = new List<string>
                {
                    "Go to Kings Castle",
                    "You must help us!",
                    "Save these lands"
                }
            },

            new Civillian
            {
                Id = 4,
                Name = "Guard",
                WorldAreaLocationID = 4,
                Description = "A Guard for the King."
            },

            new Civillian
            {
                Id = 5,
                Name = "The King",
                WorldAreaLocationID = 4,
                Description = "King of Bree",
                Messages = new List<string>
                {
                    "Take this key to open the Dark Dungeon!",
                    "You must help us!",
                    "Save these lands"
                }
            },

            new Civillian
            {
                Id = 3,
                Name = "Prisoner",
                WorldAreaLocationID = 3,
                Description = "This man is cuffed to the very stones of the wall, looks like he is barely alive.",
                Messages = new List<string>
                {
                    "uhhhhhhhhh........",
                    "help me....",
                    "..."
                }
            },

            new Civillian
            {
                Id = 6,
                Name = "White Wizzard",
                WorldAreaLocationID = 6,
                Description = "A man that is entirely covered in white and silver robes.",
                Messages = new List<string>
                {
                    "Its dangerous to go alone. Take this!",
                    "All your base are belong to us.",
                    "Have you seen a gold ring around here?"
                }
            },

            new MonsterNpc
            {
                Id = 8,
                Name = "Zombie",
                WorldAreaLocationID = 3,
                Description = "A figure of a Zombie with flesh ripped from its body. The only thing you notice is one eye left in its socket.",
                Messages = new List<string>
                {
                    "Take this key to open the Dark Dungeon!",
                    "You must help us!",
                    "Save these lands"
                },
                RemoveWhenDefeated = true,
                SpawnMonstersForBattle = () => new List<Monster>()
                {
                    new Monster
                    {
                        Name = "Zombie",
                        HP = 3,
                        MaxAttack = 1,
                        ExpGained = 2,
                        Gold = 5
                    }
                }
            },

            new MonsterNpc
            {
                Id = 9,
                Name = "The Dark Horde",
                WorldAreaLocationID = 6,
                Description = "The unbeatle master of the castle. Keeps spawning its dark brood.",
                RemoveWhenDefeated = false,
                SpawnMonstersForBattle = () => new List<Monster>()
                {
                    new Monster
                    {
                        Name = "Dark Brood",
                        HP = 3,
                        MaxAttack = 1,
                        ExpGained = 2,
                        Gold = 5
                    },
                    new Monster
                    {
                        Name = "Dark Brood",
                        HP = 3,
                        MaxAttack = 1,
                        ExpGained = 2,
                        Gold = 5
                    },
                    new Monster
                    {
                        Name = "Dark Brood",
                        HP = 3,
                        MaxAttack = 1,
                        ExpGained = 2,
                        Gold = 5
                    },
                    new Monster
                    {
                        Name = "Dark Brood",
                        HP = 3,
                        MaxAttack = 1,
                        ExpGained = 2,
                        Gold = 5
                    }
                }
            }
        };
    }
}
