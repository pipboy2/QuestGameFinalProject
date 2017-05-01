using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestWar
{
    /// <summary>
    /// static class to hold key/value pairs for menu options
    /// </summary>
    public static class ActionMenu
    {
        public enum CurrentMenu
        {
            AdventureIntro,
            InitializeAdventure,
            MainMenu,
            ObjectMenu,
            NpcMenu,
            AdventurerMenu,
            AdminMenu
        }

        //
        // flag current operating menu
        //

        public static CurrentMenu currentMenu = CurrentMenu.MainMenu;

        private static Menu adventureIntro = new Menu()
        {
            MenuName = "AdventureIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, AdventurerAction>()
                    {
                        { ' ', AdventurerAction.None }
                    }
        };

        public static Menu InitializeAdventure = new Menu()
        {
            MenuName = "InitializeAdventure",
            MenuTitle = "Initialize Adventure",
            MenuChoices = new Dictionary<char, AdventurerAction>()
                {
                    { '1', AdventurerAction.Exit }
                }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, AdventurerAction>()
                {
                    { '1', AdventurerAction.LookAround },
                    { '2', AdventurerAction.Travel },
                    { '3', AdventurerAction.ObjectMenu },
                    { '4', AdventurerAction.NonplayerCharacterMenu },
                    { '5', AdventurerAction.TravelMenu },
                    { '6', AdventurerAction.AdminMenu },
                    { '7', AdventurerAction.Exit },
                }
        };

        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, AdventurerAction>()
                {
                    { '1', AdventurerAction.ListWorldAreaLocations },
                    { '2', AdventurerAction.ListGameObjects},
                    { '3', AdventurerAction.ListNonplayerCharacters },
                    { '0', AdventurerAction.ReturnToMainMenu }
                }
        };
        public static Menu AdventurerMenu = new Menu()
        {
            MenuName = "AdventurerMenu",
            MenuTitle = "Adventurer Menu",
            MenuChoices = new Dictionary<char, AdventurerAction>()
                {
                    { '1', AdventurerAction.AdventurerInfo },
                    { '2', AdventurerAction.Inventory},
                    { '3', AdventurerAction.AdventurerLocationsVisited},
                    { '0', AdventurerAction.ReturnToMainMenu }
                }
        };

        public static Menu ObjectMenu = new Menu()
        {
            MenuName = "ObjectMenu",
            MenuTitle = "Object Menu",
            MenuChoices = new Dictionary<char, AdventurerAction>()
                {
                    { '1', AdventurerAction.LookAt },
                    { '2', AdventurerAction.PickUp},
                    { '3', AdventurerAction.PutDown},
                    { '0', AdventurerAction.ReturnToMainMenu }
                }
        };

        public static Menu NpcMenu = new Menu()
        {
            MenuName = "NpcMenu",
            MenuTitle = "NPC Menu",
            MenuChoices = new Dictionary<char, AdventurerAction>()
                {
                    { '1', AdventurerAction.TalkTo},
                    { '2', AdventurerAction.Battle },
                    { '0', AdventurerAction.ReturnToMainMenu }
                }
        };

        public static Menu AdventureIntro { get => adventureIntro; set => adventureIntro = value; }
    }
}
