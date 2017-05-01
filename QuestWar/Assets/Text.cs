using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestWar
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "Quest War" };
        public static List<string> FooterText = new List<string>() { "UltraPip Studios, 2017" };

        #region INTITIAL GAME SETUP

        public static string AdventureIntro()
        {
            string messageBoxText =
            "You have been tasked to go to the Kings Castle to get the key " +
            "to help you defeat the scurge of the land. " +
            "With your courage and power you should have no issue to find your way to " +
            "the caslte.\n" +
            " \n" +
            "Press the Esc key to exit the game at any point.\n" +
            " \n" +
            "Your adventure begins now.\n" +
            " \n" +
            "\tYour first task will be to set up the initial parameters of your adventurer.\n" +
            " \n" +
            "\tPress any key to begin the adventure Initialization Process.\n";

            return messageBoxText;
        }

        public static string InitialLocationInfo()
        {
            string messageBoxText =
            "You open the door from your house armed with your weapons and armor. " +
            "the city shines in your eyes as you begin your adventure. " +
            "You seem many people comming and going on their daily lives, not knowing " +
            "what fate lies for them all.\n" +
            " \n" +
            "\tChoose from the menu options to proceed.\n";

            return messageBoxText;
        }

        #region Initialize Adventure Text

        public static string InitializeAdventureIntro()
        {
            string messageBoxText =
                "Before you begin your adventure we much gather your base data.\n" +
                " \n" +
                "You will be prompted for the required information. Please enter the information below.\n" +
                " \n" +
                "\tPress any key to begin.";

            return messageBoxText;
        }

        public static string InitializeAdventureGetAdventurerName()
        {
            string messageBoxText =
                "Enter your name Adventurer.\n" +
                " \n" +
                "Please use the name you wish to be referred during your adventure.";

            return messageBoxText;
        }

        public static string InitializeAdventureGetAdventurerAge(string name)
        {
            string messageBoxText =
                $"Very good then, we will call you {name} on this adventure.\n" +
                " \n" +
                "Enter your age below.\n";

            return messageBoxText;
        }

        public static string InitializeAdventureGetAdventurerRace(Adventurer gameAdventurer)
        {
            string messageBoxText =
                $"{gameAdventurer.Name}, it will be important for us to know your race on this adventure.\n" +
                " \n" +
                "Enter your race below.\n" +
                " \n" +
                "Please use the universal race classifications below." +
                " \n";

            string raceList = null;

            foreach (Character.RaceType race in Enum.GetValues(typeof(Character.RaceType)))
            {
                if (race != Character.RaceType.None)
                {
                    raceList += $"\t{race}\n";
                }
            }

            messageBoxText += raceList;

            return messageBoxText;
        }

        public static string InitializeAdventureEchoAdventurerInfo(Adventurer gameAdventurer)
        {
            string messageBoxText =
                $"Very good then {gameAdventurer.Name}.\n" +
                " \n" +
                "It appears we have all the necessary data to begin your adventure. You will find it" +
                " listed below.\n" +
                " \n" +
                $"\tAdventurer Name: {gameAdventurer.Name}\n" +
                $"\tAdventurer Age: {gameAdventurer.Age}\n" +
                $"\tAdventurer Race: {gameAdventurer.Race}\n" +
                " \n" +
                "Press any key to begin your adventure.";

            return messageBoxText;
        }

        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        public static string AdventurerInfo(Adventurer gameAdventurer, WorldAreaLocation currentLocation)
        {
            string messageBoxText =
                $"\tAdventurer Name: {gameAdventurer.Name}\n" +
                $"\tAdventurer Age: {gameAdventurer.Age}\n" +
                $"\tAdventurer Race: {gameAdventurer.Race}\n" +
                " \n" +
                $"\tCurrent Location: {currentLocation.CommonName}\n" +
                " \n";

            return messageBoxText;
        }

        public static string CurrentLocationInfo(WorldAreaLocation wolrdAreaLocation)
        {
            string messageBoxText =
                $"Current Location: {wolrdAreaLocation.CommonName}\n" +
                " \n" +
                wolrdAreaLocation.Description;

            return messageBoxText;
        }

        public static string LookAround(WorldAreaLocation worldAreaLocation)
        {
            string messageBoxText =
                $"Current Location: {worldAreaLocation.CommonName}\n" +
                " \n" +
                worldAreaLocation.Description;

            return messageBoxText;
        }

        /// <summary>
        /// list all locations other than the current location
        /// </summary>
        /// <param name="gameadventurer">game Adventurer object</param>
        /// <param name="worldAreaLocations">list of all World area locations</param>
        /// <returns></returns>
        public static string Travel(Adventurer gameadventurer, List<WorldAreaLocation> worldAreaLocations)
        {
            string messageBoxText =
                $"{gameadventurer.Name}, Where would you like to travel adventurer?\n" +
                " \n" +
                "Enter the ID number of your desired location from the table below.\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "Accessible".PadRight(10) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "-------".PadRight(10) + "\n";

            //
            // display all locations except the current location
            //
            string worldAreaLocationList = null;
            foreach (WorldAreaLocation worldAreaLocation in worldAreaLocations)
            {
                if (worldAreaLocation.WorldAreaLocationID != gameadventurer.WorldAreaLocationID)
                {
                    worldAreaLocationList +=
                        $"{worldAreaLocation.WorldAreaLocationID}".PadRight(10) +
                        $"{worldAreaLocation.CommonName}".PadRight(30) +
                        $"{worldAreaLocation.PlayerCanAccess(gameadventurer)}".PadRight(10) +
                        Environment.NewLine;
                }
            }

            messageBoxText += worldAreaLocationList;

            return messageBoxText;
        }

        public static string VisitedLocations(IEnumerable<WorldAreaLocation> worldAreaLocations)
        {
            string messageBoxText =
                "World-Area Locations Visited\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //
            // display all locations
            //
            string worldAreaLocationList = null;
            foreach (WorldAreaLocation worldAreaLocation in worldAreaLocations)
            {
                worldAreaLocationList +=
                    $"{worldAreaLocation.WorldAreaLocationID}".PadRight(10) +
                    $"{worldAreaLocation.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += worldAreaLocationList;

            return messageBoxText;
        }

        public static string ListAllWorldAreaLocations(IEnumerable<WorldAreaLocation> worldAreaLocations)
        {
            string messageBoxText =
                "World-Area Locations\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //
            // display all locations
            //
            string worldAreaLocationList = null;
            foreach (WorldAreaLocation worldAreaLocation in worldAreaLocations)
            {
                worldAreaLocationList +=
                    $"{worldAreaLocation.WorldAreaLocationID}".PadRight(10) +
                    $"{worldAreaLocation.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += worldAreaLocationList;

            return messageBoxText;
        }

        public static string ListAllGameObjects(IEnumerable<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Game Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "World-Area Location Id".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) +
                "----------------------".PadRight(10) + "\n";

            //
            // display all Adventurer objects in rows
            //
            string gameObjectRows = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRows +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    $"{gameObject.WorldAreaLocationId}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }

        public static string GameObjectsChooseList(IEnumerable<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Game Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + 
                "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + 
                "----------------------".PadRight(30) + "\n";

            //
            // display all Adventurer objects in rows
            //
            string gameObjectRows = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRows +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
        }


        public static string ListWorldAreaLocationObjectsByWorldAreaLocation(int worldAreaLocationId, IEnumerable<GameObject> gameObjects)
        {
            //
            // generate a list of Adventurer objects from the game object list with the current world-area location id
            //
            List<WorldAreaLocationObject> worldAreaLocationObjects = new List<WorldAreaLocationObject>();
            foreach (var gameObject in gameObjects)
            {
                if (gameObject is AdventurerObject &&
                    gameObject.WorldAreaLocationId == worldAreaLocationId)
                {
                    worldAreaLocationObjects.Add(gameObject as WorldAreaLocationObject);
                }
            }

            //
            // display table name and column headers
            //
            string messageBoxText =
                "World-Area Location Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "Type".PadRight(20) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) +
                "----------------------".PadRight(20) + "\n";

            //
            // display all Adventurer objects in rows
            //
            string worldAreaLocationObjectRows = null;
            foreach (WorldAreaLocationObject worldAreaLocationObject in worldAreaLocationObjects)
            {
                worldAreaLocationObjectRows +=
                    $"{worldAreaLocationObject.Id}".PadRight(10) +
                    $"{worldAreaLocationObject.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += worldAreaLocationObjectRows;

            return messageBoxText;
        }

        public static string LookAt(GameObject gameObject)
        {
            string messageBoxText = "";

            messageBoxText =
                $"{gameObject.Name}\n" +
                " \n" +
                gameObject.Description + " \n" +
                " \n";
                
            if (gameObject is AdventurerObject)
            {
                AdventurerObject adventurerObject = gameObject as AdventurerObject;

                messageBoxText += $"The {adventurerObject.Name} has a value of {adventurerObject.Value} and ";

                if (adventurerObject.CanInventory)
                {
                    messageBoxText += "may be added to your inventory.";
                }
                else
                {
                    messageBoxText += "may not be added to your inventory.";
                }
            }
            else
            {
                messageBoxText += $"The {gameObject.Name} may not be added to your inventory.";
            }

            return messageBoxText;
        }

        public static string CurrentInventory(IEnumerable<AdventurerObject> inventory)
        {
            string messageBoxText = "";

            //
            // display table header
            //
            messageBoxText =
            "ID".PadRight(10) +
            "Name".PadRight(30) +
            "Type".PadRight(10) +
            "\n" +
            "---".PadRight(10) +
            "----------------------------".PadRight(30) +
            "----------------------".PadRight(10) +
            "\n";

            //
            // display all Adventurer objects in rows
            //
            string inventoryObjectRows = null;
            foreach (AdventurerObject inventoryObject in inventory)
            {
                inventoryObjectRows +=
                    $"{inventoryObject.Id}".PadRight(10) +
                    $"{inventoryObject.Name}".PadRight(30) +
                    $"{inventoryObject.Type}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += inventoryObjectRows;

            return messageBoxText;
        }

        #endregion

        public static List<string> StatusBox(Adventurer adventurer, World world)
        {
            List<string> statusBoxText = new List<string>();

            statusBoxText.Add($"Experience Points: {adventurer.ExperiencePoints}\n");
            statusBoxText.Add($"Health: {adventurer.Health}\n");
            statusBoxText.Add($"Lives: {adventurer.Lives}\n");

            return statusBoxText;
        }

        public static string ListAllNpcObjects(IEnumerable<Npc> npcObjects)
        {
            //
            // display table name and column headers
            //

            string messageBoxText =
                "NPC Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "World-Area Location Id".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) +
                "----------------------".PadRight(10) + "\n";

            //
            // display all npc objects in rows
            //

            string npcObjectRows = null;
            foreach (Npc npcObject in npcObjects)
            {
                npcObjectRows +=
                    $"{npcObject.Id}".PadRight(10) +
                    $"{npcObject.Name}".PadRight(30) +
                    $"{npcObject.WorldAreaLocationID}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += npcObjectRows;

            return messageBoxText;
        }

        public static string NpcsChooseList(IEnumerable<Npc> npcs)
        {
            //
            // display table name and column headers
            //

            string messageBoxText =
                "NPCs\n" +
                " \n" +

                //
                // display table header
                //

                "ID".PadRight(10) +
                "Name".PadRight(30) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) + "\n";

            //
            // display all NPCs in rows
            //

            string npcRows = null;
            foreach (Npc npc in npcs)
            {
                npcRows +=
                    $"{npc.Id}".PadRight(10) +
                    $"{npc.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += npcRows;

            return messageBoxText;
        }
    }
}
