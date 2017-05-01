using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAionProject.Models;

namespace QuestWar

{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Adventurer _gameAdventurer;
        private World _gameWorld;
        private WorldAreaLocation _currentLocation;
        private bool _playingGame;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gameAdventurer = new Adventurer();
            _gameWorld = new World();
            _gameConsoleView = new ConsoleView(_gameAdventurer, _gameWorld);
            _playingGame = true;

            //
            // add initial items to the Adventurer's inventory
            //
            _gameAdventurer.Inventory.Add(_gameWorld.GetGameObjectById(8) as AdventurerObject);
            _gameAdventurer.Inventory.Add(_gameWorld.GetGameObjectById(9) as AdventurerObject);

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            AdventurerAction adventurerActionChoice = AdventurerAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Mission Intro", Text.AdventureIntro(), ActionMenu.AdventureIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission adventurer
            // 
            InitializeMission();

            //
            // prepare game play screen
            //
            _currentLocation = _gameWorld.GetWorldAreaLocationById(_gameAdventurer.WorldAreaLocationID);
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");

            //
            // game loop
            //
            while (_playingGame)
            {
                //
                // process all flags, events, and stats
                //
                UpdateGameStatus();

                //
                // get next game action from player
                //
                adventurerActionChoice = GetNextAdventurerAction();

                //
                // choose an action based on the player's menu choice
                //
                switch (adventurerActionChoice)
                {
                    case AdventurerAction.None:
                        break;

                    case AdventurerAction.AdventurerInfo:
                        _gameConsoleView.DisplayAdventurerInfo();
                        break;

                    case AdventurerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;

                    case AdventurerAction.Travel:
                        TravelAction();
                        break;

                    case AdventurerAction.AdventurerLocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                        break;

                    case AdventurerAction.LookAt:
                        LookAtAction();
                        break;

                    case AdventurerAction.PickUp:
                        PickUpAction();
                        break;

                    case AdventurerAction.PutDown:
                        PutDownAction();
                        break;

                    case AdventurerAction.Inventory:
                        _gameConsoleView.DisplayInventory();
                        break;

                    case AdventurerAction.ListWorldAreaLocations:
                        _gameConsoleView.DisplayListOfWorldAreaLocations();
                        break;

                    case AdventurerAction.ListGameObjects:
                        _gameConsoleView.DisplayListOfAllGameObjects();
                        break;

                    case AdventurerAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        break;

                    case AdventurerAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;

                    case AdventurerAction.ListNonplayerCharacters:
                        _gameConsoleView.DisplayListOfAllNpcObjects();
                        break;

                    case AdventurerAction.TravelMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdventurerMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Adventurer Menu", "Select an operation from the menu.", ActionMenu.AdventurerMenu, "");
                        break;

                    case AdventurerAction.ObjectMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.ObjectMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Object Menu", "Select an operation from the menu.", ActionMenu.ObjectMenu, "");
                        break;

                    case AdventurerAction.NonplayerCharacterMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                        _gameConsoleView.DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu.", ActionMenu.NpcMenu, "");
                        break;

                    case AdventurerAction.TalkTo:
                        TalkToAction();
                        break;

                    case AdventurerAction.Battle:
                        bool survived = BattleAction();
                        if (!survived)
                        {
                            _playingGame = false;
                        }
                        else
                        {
                            ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        }
                        break;

                    case AdventurerAction.Exit:
                        _playingGame = false;
                        break;

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        private AdventurerAction GetNextAdventurerAction()
        {
            AdventurerAction adventurerrActionChoice = AdventurerAction.None;

            switch (ActionMenu.currentMenu)
            {
                case ActionMenu.CurrentMenu.MainMenu:
                    adventurerrActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                    break;

                case ActionMenu.CurrentMenu.ObjectMenu:
                    adventurerrActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ObjectMenu);
                    break;

                case ActionMenu.CurrentMenu.NpcMenu:
                    adventurerrActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.NpcMenu);
                    break;

                case ActionMenu.CurrentMenu.AdventurerMenu:
                    adventurerrActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdventurerMenu);
                    break;

                case ActionMenu.CurrentMenu.AdminMenu:
                    adventurerrActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                    break;

                default:
                    break;
            }

            return adventurerrActionChoice;
        }

        /// <summary>
        /// process the Adventurer action
        /// </summary>
        private void TravelAction()
        {
            //
            // get new location choice and update the current location property
            //                        
            _gameAdventurer.WorldAreaLocationID = _gameConsoleView.DisplayGetNextWorldAreaLocation();
            _currentLocation = _gameWorld.GetWorldAreaLocationById(_gameAdventurer.WorldAreaLocationID);

            //
            // display the new world area location info
            //
            _gameConsoleView.DisplayCurrentLocationInfo();
        }

        /// <summary>
        /// process the Look At action
        /// </summary>
        private void LookAtAction()
        {
            //
            // display a list of game objects in world area location and get a player choice
            //
            int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectToLookAt();

            //
            // display game object info
            //
            if (gameObjectToLookAtId != 0)
            {
                //
                // get the game object from the World
                //
                GameObject gameObject = _gameWorld.GetGameObjectById(gameObjectToLookAtId);

                //
                // display information for the object chosen
                //
                _gameConsoleView.DisplayGameObjectInfo(gameObject);
            }
        }


        /// <summary>
        /// process the Pick Up action
        /// </summary>
        private void PickUpAction()
        {
            //
            // display a list of Adventurer objects in world area location and get a player choice
            //
            int adventurerObjectToPickUpId = _gameConsoleView.DisplayGetAdventuereObjectToPickUp();

            //
            // add the Adventurer object to Adventurer's inventory
            //
            if (adventurerObjectToPickUpId != 0)
            {
                //
                // get the game object from the World
                //
                AdventurerObject AdventurerObject = _gameWorld.GetGameObjectById(adventurerObjectToPickUpId) as AdventurerObject;

                //
                // note: Adventurer object is added to list and the world area location is set to 0
                //
                _gameAdventurer.Inventory.Add(AdventurerObject);
                AdventurerObject.WorldAreaLocationId = 0;

                //
                // display confirmation message
                //
                _gameConsoleView.DisplayConfirmAdventurerObjectAddedToInventory(AdventurerObject);
            }
        }

        /// <summary>
        /// process the Put Down action
        /// </summary>
        private void PutDownAction()
        {
            //
            // display a list of Adventurer objects in inventory and get a player choice
            //
            int inventoryObjectToPutDownId = _gameConsoleView.DisplayGetInventoryObjectToPutDown();

            //
            // get the game object from the World
            //
            AdventurerObject adventurerObject = _gameWorld.GetGameObjectById(inventoryObjectToPutDownId) as AdventurerObject;

            //
            // remove the object from inventory and set the world area location to the current value
            //
            _gameAdventurer.Inventory.Remove(adventurerObject);
            adventurerObject.WorldAreaLocationId = _gameAdventurer.WorldAreaLocationID;

            //
            // display confirmation message
            //
            _gameConsoleView.DisplayConfirmAdventurerObjectRemovedFromInventory(adventurerObject);

        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializeMission()
        {
            Adventurer adventurer = _gameConsoleView.GetInitialAdventurerInfo();

            _gameAdventurer.Name = adventurer.Name;
            _gameAdventurer.Age = adventurer.Age;
            _gameAdventurer.Race = adventurer.Race;
            _gameAdventurer.WorldAreaLocationID = 1;

            _gameAdventurer.ExperiencePoints = 0;
            _gameAdventurer.Health = 100;
            _gameAdventurer.Lives = 3;
        }

        /// <summary>
        /// part of the game loop and used to update many elements of the game and game play
        /// </summary>
        private void UpdateGameStatus()
        {
            if (!_gameAdventurer.HasVisited(_currentLocation.WorldAreaLocationID))
            {
                //
                // add new location to the list of visited locations if this is a first visit
                //
                _gameAdventurer.WorldAreaLocationsVisited.Add(_currentLocation.WorldAreaLocationID);

                //
                // update experience points for visiting locations
                //
                _gameAdventurer.ExperiencePoints += _currentLocation.ExperiencePoints;
            }
        }

        private bool BattleAction()
        {
            //
            // display a list of NPCs in world area location and get a player choice
            //

            int npcToBattleId = _gameConsoleView.DisplayGetNpcToBattle();

            //
            // display NPC's message
            //

            if (npcToBattleId != 0)
            {
                //
                // get the NPC from the World
                //

                MonsterNpc npc = _gameWorld.GetNpcById(npcToBattleId) as MonsterNpc;

                var battle = new Battle(_gameAdventurer, npc.SpawnMonstersForBattle());
                var battleResult = battle.Start();
                if (battleResult == BattleResult.Win && npc.RemoveWhenDefeated)
                {
                    WorldObjects.Npcs.Remove(npc);
                }
                return battleResult != BattleResult.Lose; //Return false if the player loses, so we know to exit the game.
            }
            return true;
        }

        private void TalkToAction()
        {
            //
            // display a list of NPCs in world area location and get a player choice
            //

            int npcToTalkToId = _gameConsoleView.DisplayGetNpcToTalkTo();

            //
            // display NPC's message
            //

            if (npcToTalkToId != 0)
            {
                //
                // get the NPC from the World
                //

                Npc npc = _gameWorld.GetNpcById(npcToTalkToId);

                //
                // display information for the object chosen
                //

                _gameConsoleView.DisplayTalkTo(npc);
            }
        }
        #endregion
    }
}
