using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAionProject.Models;

namespace QuestWar
{
    /// <summary>
    /// view class
    /// </summary>
    public class ConsoleView
    {
        #region ENUMS

        private enum ViewStatus
        {
            AdventurerInitialization,
            PlayingGame
        }

        #endregion

        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Adventurer _gameAdventurer;
        World _gameWorld;

        ViewStatus _viewStatus;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Adventurer gameAdventurer, World gameWorld)
        {
            _gameAdventurer = gameAdventurer;
            _gameWorld = gameWorld;

            _viewStatus = ViewStatus.AdventurerInitialization;

            InitializeDisplay();
        }

        #endregion

        #region METHODS
        /// <summary>
        /// display all of the elements on the game play screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText">message box header title</param>
        /// <param name="messageBoxText">message box text</param>
        /// <param name="menu">menu to use</param>
        /// <param name="inputBoxPrompt">input box text</param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
            DisplayStatusBox();
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public AdventurerAction GetActionMenuChoice(Menu menu)
        {
            AdventurerAction choosenAction = AdventurerAction.None;
            Console.CursorVisible = false;

            //
            // create an array of valid keys from menu dictionary
            //
            char[] validKeys = menu.MenuChoices.Keys.ToArray();

            //
            // validate key pressed as in MenuChoices dictionary
            //
            char keyPressed;
            do
            {
                ConsoleKeyInfo keyPressedInfo = Console.ReadKey(true);
                keyPressed = keyPressedInfo.KeyChar;
            } while (!validKeys.Contains(keyPressed));

            choosenAction = menu.MenuChoices[keyPressed];
            Console.CursorVisible = true;

            return choosenAction;
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get a valid integer from the player - note: if max and min values are both 0, range validation is disabled
        /// </summary>
        /// <param name="prompt">prompt message in console</param>
        /// <param name="minimumValue">min. value</param>
        /// <param name="maximumValue">max. value</param>
        /// <param name="integerChoice">out value</param>
        /// <returns></returns>
        private bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            //
            // validate on range if either minimumValue and maximumValue are not 0
            //
            bool validateRange = (minimumValue != 0 || maximumValue != 0);

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (validateRange)
                    {
                        if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                        {
                            validResponse = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                            DisplayInputBoxPrompt(prompt);
                        }
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            Console.CursorVisible = false;

            return true;
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetDouble(string prompt, double minimumValue, double maximumValue, out double doubleChoice)
        {
            bool validResponse = false;
            doubleChoice = 0;

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (double.TryParse(Console.ReadLine(), out doubleChoice))
                {
                    if (doubleChoice >= minimumValue && doubleChoice <= maximumValue)
                    {
                        validResponse = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage($"You must enter an number value between {minimumValue} and {maximumValue}. Please try again.");
                        DisplayInputBoxPrompt(prompt);
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an number value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            return true;
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public Character.RaceType GetRace()
        {
            Character.RaceType raceType;
            Enum.TryParse<Character.RaceType>(Console.ReadLine(), out raceType);

            return raceType;
        }

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySpashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 35);
            Console.WriteLine(tabSpace + @" _____                 _     _    _  ");
            Console.WriteLine(tabSpace + @"|  _  |               | |   | |  | |");
            Console.WriteLine(tabSpace + @"| | | |_   _  ___  ___| |_  | |  | | __ _ _ __ ");
            Console.WriteLine(tabSpace + @"| | | | | | |/ _ \/ __| __| | |/\| |/ _` | '__|");
            Console.WriteLine(tabSpace + @"\ \/' / |_| |  __/\__ \ |_  \  /\  / (_| | |   ");
            Console.WriteLine(tabSpace + @" \_/\_\\__,_|\___||___/\__|  \/  \/ \__,_|_| ");
            Console.WriteLine(tabSpace + @""); 

            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        /// <summary>
        /// initialize the console window settings
        /// </summary>
        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "Quest War";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, AdventurerAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != AdventurerAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        /// <summary>
        /// display the text in the message box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        /// <summary>
        /// draw the status box on the game screen
        /// </summary>
        public void DisplayStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            //
            // display the text for the status box if playing game
            //
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // display stats
                //
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gameAdventurer, _gameWorld))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            }
            else
            {
                //
                // display status box header without header
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
        }

        /// <summary>
        /// draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        /// <summary>
        /// display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        /// <summary>
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>adventure object with all properties updated</returns>
        public Adventurer GetInitialAdventurerInfo()
        {
            Adventurer adventurer = new Adventurer();

            //
            // intro
            //
            DisplayGamePlayScreen("Mission Initialization", Text.InitializeAdventureIntro(), ActionMenu.AdventureIntro, "");
            GetContinueKey();

            //
            // get adventurer's name
            //
            DisplayGamePlayScreen("Mission Initialization - Name", Text.InitializeAdventureGetAdventurerName(), ActionMenu.AdventureIntro, "");
            DisplayInputBoxPrompt("Enter your name: ");
            adventurer.Name = GetString();

            //
            // get adventurer's age
            //
            DisplayGamePlayScreen("Mission Initialization - Age", Text.InitializeAdventureGetAdventurerAge(adventurer.Name), ActionMenu.AdventureIntro, "");
            int gameAdventurerAge;

            GetInteger($"Enter your age {adventurer.Name}: ", 0, 1000000, out gameAdventurerAge);
            adventurer.Age = gameAdventurerAge;

            //
            // get adventurer's race
            //
            DisplayGamePlayScreen("Mission Initialization - Race", Text.InitializeAdventureGetAdventurerRace(adventurer), ActionMenu.AdventureIntro, "");
            DisplayInputBoxPrompt($"Enter your race {adventurer.Name}: ");
            adventurer.Race = GetRace();

            //
            // echo the adventurer's info
            //
            DisplayGamePlayScreen("Mission Initialization - Complete", Text.InitializeAdventureEchoAdventurerInfo(adventurer), ActionMenu.AdventureIntro, "");
            GetContinueKey();

            // 
            // change view status to playing game
            //
            _viewStatus = ViewStatus.PlayingGame;

            return adventurer;
        }

        public void DisplayListOfAllNpcObjects()
        {
            DisplayGamePlayScreen("List: Npc Objects", Text.ListAllNpcObjects(_gameWorld.Npcs), ActionMenu.AdminMenu, "");
        }
        #region ----- display responses to menu action choices -----
        /// <summary>
        /// display all relevant information about the adventuere
        /// </summary>
        public void DisplayAdventurerInfo()
        {
            WorldAreaLocation currentWorldAreaLocation = _gameWorld.GetWorldAreaLocationById(_gameAdventurer.WorldAreaLocationID);
            DisplayGamePlayScreen("Adventurer Information", Text.AdventurerInfo(_gameAdventurer, currentWorldAreaLocation), ActionMenu.AdventurerMenu, "");
        }

        /// <summary>
        /// display all relevant information about the current location
        /// </summary>
        public void DisplayCurrentLocationInfo()
        {
            WorldAreaLocation currentWorldAreaLocation = _gameWorld.GetWorldAreaLocationById(_gameAdventurer.WorldAreaLocationID);
            DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(currentWorldAreaLocation), ActionMenu.MainMenu, "");
        }

        /// <summary>
        /// display select information about the current location
        /// </summary>
        public void DisplayLookAround()
        {
            //
            // get current world area location
            //
            WorldAreaLocation currentWorldAreaLocation = _gameWorld.GetWorldAreaLocationById(_gameAdventurer.WorldAreaLocationID);

            //
            // get list of game objects in current world-area location
            //
            List<GameObject> gameObjectsInCurrentWorldAreaLocation = _gameWorld.GetGameObjectsByWorldAreaLocationId(_gameAdventurer.WorldAreaLocationID);

            //
            // get list of NPCs in current world area location
            //

            List<Npc> npcsInCurrentWorldAreaLocation = _gameWorld.GetNpcsByWorldAreaLocationId(_gameAdventurer.WorldAreaLocationID);

            string messageBoxText = Text.LookAround(currentWorldAreaLocation) + Environment.NewLine + Environment.NewLine;
            messageBoxText += Text.GameObjectsChooseList(gameObjectsInCurrentWorldAreaLocation) + Environment.NewLine;
            messageBoxText += Text.NpcsChooseList(npcsInCurrentWorldAreaLocation);

            DisplayGamePlayScreen("Current Location", messageBoxText, ActionMenu.MainMenu, "");
        }

        /// <summary>
        /// display all relevant information about a game object
        /// </summary>
        /// <param name="gameObject"></param>
        public void DisplayGameObjectInfo(GameObject gameObject)
        {
            DisplayGamePlayScreen("Current Location", Text.LookAt(gameObject), ActionMenu.ObjectMenu, "");
        }

        /// <summary>
        /// display the information required for the player to choose the next location
        /// </summary>
        /// <returns></returns>
        public int DisplayGetNextWorldAreaLocation()
        {
            int worldAreaLocationId = 0;
            bool validWorldAreaLocationId = false;

            DisplayGamePlayScreen("Travel to a New world area Location", Text.Travel(_gameAdventurer, _gameWorld.WorldAreaLocations), ActionMenu.MainMenu, "");

            while (!validWorldAreaLocationId)
            {
                //
                // get an integer from the player
                //
                GetInteger($"Enter your new location {_gameAdventurer.Name}: ", 1, _gameWorld.GetMaxWorldAreaLocationId(), out worldAreaLocationId);

                //
                // validate integer as a valid world area location id and determine accessibility
                //
                if (_gameWorld.IsValidWorldAreaLocationId(worldAreaLocationId))
                {
                    if (_gameWorld.IsAccessibleLocation(worldAreaLocationId, _gameAdventurer))
                    {
                        validWorldAreaLocationId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you attempting to travel to an inaccessible location. Please try again.");
                    }
                }
                else
                {
                    DisplayInputErrorMessage("It appears you entered an invalid World Area Location id. Please try again.");
                }
            }

            return worldAreaLocationId;
        }

        /// <summary>
        /// display the information required for the player to choose an object to look at
        /// </summary>
        /// <returns></returns>
        public int DisplayGetGameObjectToLookAt()
        {
            int gameObjectId = 0;
            bool validGamerObjectId = false;

            //
            // get a list of game objects in the current world area location
            //
            List<GameObject> gameObjectsInWorldAreaLocation = _gameWorld.GetGameObjectsByWorldAreaLocationId(_gameAdventurer.WorldAreaLocationID);

            if (gameObjectsInWorldAreaLocation.Count > 0)
            {
                DisplayGamePlayScreen("Look at a Object", Text.GameObjectsChooseList(gameObjectsInWorldAreaLocation), ActionMenu.ObjectMenu, "");

                while (!validGamerObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to look at: ", 0, 0, out gameObjectId);

                    //
                    // validate integer as a valid game object id and in current location
                    //
                    if (_gameWorld.IsValidGameObjectByLocationId(gameObjectId, _gameAdventurer.WorldAreaLocationID))
                    {
                        validGamerObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid game object id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Look at a Object", "It appears there are no game objects here.", ActionMenu.ObjectMenu, "");
            }

            return gameObjectId;
        }

        /// <summary>
        /// display the information required for the player to choose an object to pick up
        /// </summary>
        /// <returns>game object Id</returns>
        public int DisplayGetAdventuereObjectToPickUp()
        {
            int gameObjectId = 0;
            bool validGameObjectId = false;

            //
            // get a list of adventuere objects in the current world area location
            //
            List<AdventurerObject> adventurerObjectsInWorldAreaLocation = _gameWorld.GetAdventurerObjectsByWorldAreaLocationId(_gameAdventurer.WorldAreaLocationID);

            if (adventurerObjectsInWorldAreaLocation.Count > 0)
            {
                DisplayGamePlayScreen("Pick Up Game Object", Text.GameObjectsChooseList(adventurerObjectsInWorldAreaLocation), ActionMenu.ObjectMenu, "");

                while (!validGameObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to add to your inventory: ", 0, 0, out gameObjectId);

                    //
                    // validate integer as a valid game object id and in current location
                    //
                    if (_gameWorld.IsValidAdventurerObjectByLocationId(gameObjectId, _gameAdventurer.WorldAreaLocationID))
                    {
                        AdventurerObject adventurerObject = _gameWorld.GetGameObjectById(gameObjectId) as AdventurerObject;
                        if (adventurerObject.CanInventory)
                        {
                            validGameObjectId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears you may not inventory that object. Please try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid game object id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no game objects here.", ActionMenu.ObjectMenu, "");
            }

            return gameObjectId;
        }

        /// <summary>
        /// display the information required for the player to choose an object to pick up
        /// </summary>
        /// <returns>game object Id</returns>
        public int DisplayGetInventoryObjectToPutDown()
        {
            int adventurerObjectId = 0;
            bool validInventoryObjectId = false;

            if (_gameAdventurer.Inventory.Count > 0)
            {
                DisplayGamePlayScreen("Put Down Game Object", Text.GameObjectsChooseList(_gameAdventurer.Inventory), ActionMenu.ObjectMenu, "");

                while (!validInventoryObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to remove from your inventory: ", 0, 0, out adventurerObjectId);

                    //
                    // find object in inventory
                    // note: LINQ used, but a foreach loop may also be used 
                    //
                    AdventurerObject objectToPutDown = _gameAdventurer.Inventory.FirstOrDefault(o => o.Id == adventurerObjectId);

                    //
                    // validate object in inventory
                    //
                    if (objectToPutDown != null)
                    {
                        validInventoryObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered the Id of an object not in the inventory. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no objects currently in inventory.", ActionMenu.ObjectMenu, "");
            }

            return adventurerObjectId;
        }

        /// <summary>
        /// confirm object added to inventory
        /// </summary>
        /// <param name="objectAddedToInventory">game object</param>
        public void DisplayConfirmAdventurerObjectAddedToInventory(AdventurerObject objectAddedToInventory)
        {
            DisplayGamePlayScreen("Pick Up Game Object", $"The {objectAddedToInventory.Name} has been added to your inventory.", ActionMenu.ObjectMenu, "");
        }

        /// <summary>
        /// confirm object removed from inventory
        /// </summary>
        /// <param name="objectRemovedFromInventory">game object</param>
        public void DisplayConfirmAdventurerObjectRemovedFromInventory(AdventurerObject objectRemovedFromInventory)
        {
            DisplayGamePlayScreen("Put Down Game Object", $"The {objectRemovedFromInventory.Name} has been removed from your inventory.", ActionMenu.ObjectMenu, "");
        }

        /// <summary>
        /// display all locations visited
        /// </summary>
        public void DisplayLocationsVisited()
        {
            //
            // generate a list of world area locations that have been visited
            //
            List<WorldAreaLocation> visitedWorldAreaLocations = new List<WorldAreaLocation>();
            foreach (int worldAreaLocationId in _gameAdventurer.WorldAreaLocationsVisited)
            {
                visitedWorldAreaLocations.Add(_gameWorld.GetWorldAreaLocationById(worldAreaLocationId));
            }

            DisplayGamePlayScreen("World area Locations Visited", Text.VisitedLocations(visitedWorldAreaLocations), ActionMenu.AdventurerMenu, "");
        }

        /// <summary>
        /// display current inventory
        /// </summary>
        public void DisplayInventory()
        {
            DisplayGamePlayScreen("Current Inventory", Text.CurrentInventory(_gameAdventurer.Inventory), ActionMenu.AdventurerMenu, "");
        }

        /// <summary>
        /// display a list all locations in the world
        /// </summary>
        public void DisplayListOfWorldAreaLocations()
        {
            DisplayGamePlayScreen("List: World Area Locations", Text.ListAllWorldAreaLocations(_gameWorld.WorldAreaLocations), ActionMenu.AdminMenu, "");
        }

        /// <summary>
        /// display a list of all game objects
        /// </summary>
        public void DisplayListOfAllGameObjects()
        {
            DisplayGamePlayScreen("List: Game Objects", Text.ListAllGameObjects(_gameWorld.GameObjects), ActionMenu.AdminMenu, "");
        }

        public int DisplayGetNpcToBattle()
        {
            int npcId = 0;
            bool validNpcId = false;

            List<Npc> npcsInWorldAreaLocation = _gameWorld.GetNpcsByWorldAreaLocationId(_gameAdventurer.WorldAreaLocationID).Where(npc => npc.CanBattle).ToList();
            if (npcsInWorldAreaLocation.Count > 0)
            {
                DisplayGamePlayScreen("Choose Character to Battle With", Text.NpcsChooseList(npcsInWorldAreaLocation), ActionMenu.NpcMenu, "");

                while (!validNpcId)
                {
                    GetInteger($"Enter the Id number of the character you wish to battle with: ", 0, 0, out npcId);
                    if (_gameWorld.IsValidNpcByLocationId(npcId, _gameAdventurer.WorldAreaLocationID))
                    {
                        Npc npc = _gameWorld.GetNpcById(npcId);
                        if (npc is MonsterNpc)
                        {
                            validNpcId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("This character has no interest in fighting you.");
                        }
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Choose Character to Battle With", "It appears there are no NPCs here.", ActionMenu.NpcMenu, "");
            }
            return npcId;
        }

        public int DisplayGetNpcToTalkTo()
        {
            int npcId = 0;
            bool validNpcId = false;

            //
            // get a list of NPCs in the current world area location
            //

            List<Npc> npcsInWorldAreaLocation = _gameWorld.GetNpcsByWorldAreaLocationId(_gameAdventurer.WorldAreaLocationID);

            if (npcsInWorldAreaLocation.Count > 0)
            {
                DisplayGamePlayScreen("Choose Character to Speak With", Text.NpcsChooseList(npcsInWorldAreaLocation), ActionMenu.NpcMenu, "");

                while (!validNpcId)
                {
                    //
                    // get an integer from the player
                    //

                    GetInteger($"Enter the Id number of the character you wish to speak with: ", 0, 0, out npcId);

                    //
                    // validate integer as a valid NPC id and in current location
                    //

                    if (_gameWorld.IsValidNpcByLocationId(npcId, _gameAdventurer.WorldAreaLocationID))
                    {
                        Npc npc = _gameWorld.GetNpcById(npcId);
                        if (npc is ISpeak)
                        {
                            validNpcId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears this character has nothing to say. Please try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid NPC id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Choose Character to Speak With", "It appears there are no NPCs here.", ActionMenu.NpcMenu, "");
            }

            return npcId;
        }

        public void DisplayTalkTo(Npc npc)
        {
            ISpeak speakingNpc = npc as ISpeak;

            string message = speakingNpc.Speak();

            if (message == "")
            {
                message = "It appears this character has nothing to say. Please try again.";
            }

            DisplayGamePlayScreen("Speak to Character", message, ActionMenu.NpcMenu, "");
        }

        #endregion

        #endregion
    }
}
