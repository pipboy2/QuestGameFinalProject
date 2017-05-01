using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestWar
{
    /// <summary>
    /// static class to hold all objects in the game world; locations, game objects, npc's
    /// </summary>
    public static partial class WorldObjects
    {
        public static List<WorldAreaLocation> WorldAreaLocations = new List<WorldAreaLocation>()
        {
            new WorldAreaLocation
            {
                CommonName = "Eldershire",
                WorldAreaLocationID = 1,
                UniversalLocation = "In the land of Bree",
                Description = "It is the town you have been born and raised in." +
                    "The town has a small castle in the middle but is surrounded by  " +
                    "lusch green planes. \n",
                GeneralContents = "The town is small but it has a level of elegence to it. " +
                    "There have been many people that have come and gone but it always feels like home. " +
                    "The entire city is surrounded by farm lands. \n",
                ExperiencePoints = 10
            },

            new WorldAreaLocation
            {
                CommonName = "Castle Eos",
                WorldAreaLocationID = 2,
                UniversalLocation = "In the land of the north",
                Description = "Castle Eos is the town that the king lives. " +
                    "Dont be fooled by its large size and busy streats. Many things carry " +
                    "underfoot. Keep on your guard",
                GeneralContents = "There are many people that are running to and from places.",
                ExperiencePoints = 10
            },

            new WorldAreaLocation
            {
                CommonName = "Dark Dungeon",
                WorldAreaLocationID = 3,
                UniversalLocation = "An area far to the south surrounded by dark swamps near the Lost Woods",
                Description = "No one who has come near this place and returned to tell the tale. " +
                              "It is said that a great skeleton guards this gate.",
                GeneralContents = "A large locked gate bars your way to this area.",
                PlayerCanAccess = p => p.Inventory.Any(obj => obj.Id == 7),
                ExperiencePoints = 20
            },

            new WorldAreaLocation
            {
                CommonName = "Kings Castle",
                WorldAreaLocationID = 4,
                UniversalLocation = "To the northeast of the land of Bree",
                Description = "This is where the king of light lives. Many years has he guarded and ruled the land." +
                              "It is said that the king needs to speak to you urgently about a dark shadow the the south east",
                GeneralContents = "The King sits on his thrown. There are is a key on the table.",
                ExperiencePoints = 10
            },

            new WorldAreaLocation
            {
                CommonName = "Lost Woods",
                WorldAreaLocationID = 5,
                UniversalLocation = "East of the land of Bree",
                Description = "The Lost Woods gets its name by the amount of people that seem to get lost " +
                    "in its depths. ",
                GeneralContents = "There is nothing of importance here. You should leave quickly. You feel like their are eyes apon you.",
                ExperiencePoints = 10
            },

            new WorldAreaLocation
            {
                CommonName = "Dark Castle",
                WorldAreaLocationID = 6,
                UniversalLocation = "South East of Bree",
                Description = "This is the Dark Castle where there is said to be a dark lord " +
                    "that uses his power to creat a never ending army at his footsteps. " +
                    "It is said that he is undefeatble.",
                GeneralContents = "A locked door to the castle stops you from entering. Where is that key?",
                PlayerCanAccess = p => p.Inventory.Any(obj => obj.Id == 10),
                ExperiencePoints = 10
            },
        };
    }
}
