using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestWar
{
    /// <summary>
    /// class of the game map
    /// </summary>
    public class World
    {
        #region ***** define all lists to be maintained by the World object *****

        //
        // list of all worldArea locations and game objects
        //
        private List<WorldAreaLocation> _worldAreaLocations;
        private List<GameObject> _gameObjects;
        private List<Npc> _npcs;

        public List<Npc> Npcs
        {
            get { return _npcs; }
            set { _npcs = value; }
        }


        public List<WorldAreaLocation> WorldAreaLocations
        {
            get { return _worldAreaLocations; }
            set { _worldAreaLocations = value; }
        }

        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
            set { _gameObjects = value; }
        }

        #endregion

        #region ***** constructor *****

        //
        // default World constructor
        //
        public World()
        {
            //
            // add all of the World objects to the game
            // 
            IntializeWorld();
        }

        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the World with all of the worldArea locations and game objects
        /// </summary>
        private void IntializeWorld()
        {
            _worldAreaLocations = WorldObjects.WorldAreaLocations;
            _gameObjects = WorldObjects.GameObjects;
            _npcs = WorldObjects.Npcs;
        }

        #endregion

        #region ***** define methods to return game element objects and information *****

        /// <summary>
        /// validate worldArea location id number
        /// </summary>
        /// <param name="worldAreaLocationId"></param>
        /// <returns>is Id valid</returns>
        public bool IsValidWorldAreaLocationId(int worldAreaLocationId)
        {
            List<int> worldAreaLocationIds = new List<int>();

            //
            // create a list of worldArea location ids
            //
            foreach (WorldAreaLocation stl in _worldAreaLocations)
            {
                worldAreaLocationIds.Add(stl.WorldAreaLocationID);
            }

            //
            // determine if the worldArea location id is a valid id and return the result
            //
            if (worldAreaLocationIds.Contains(worldAreaLocationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// validate game object id number in current location
        /// </summary>
        /// <param name="gameObjectId"></param>
        /// <returns>is Id valid</returns>
        public bool IsValidGameObjectByLocationId(int gameObjectId, int currentWorldAreaLocation)
        {
            List<int> gameObjectIds = new List<int>();

            //
            // create a list of game object ids in current worldArea location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.WorldAreaLocationId == currentWorldAreaLocation)
                {
                    gameObjectIds.Add(gameObject.Id);
                }

            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (gameObjectIds.Contains(gameObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// validate adventurer object id number in current location
        /// </summary>
        /// <param name="adventurerObjectId"></param>
        /// <returns>is Id valid</returns>
        public bool IsValidAdventurerObjectByLocationId(int adventurerObjectId, int currentWorldAreaLocation)
        {
            List<int> adventurerObjectIds = new List<int>();

            //
            // create a list of adventurer object ids in current worldArea location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.WorldAreaLocationId == currentWorldAreaLocation && gameObject is AdventurerObject)
                {
                    adventurerObjectIds.Add(gameObject.Id);
                }

            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (adventurerObjectIds.Contains(adventurerObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// determine if a location is accessible to the player
        /// </summary>
        /// <param name="WorldAreaeLocationId"></param>
        /// <returns>accessible</returns>
        public bool IsAccessibleLocation(int worldAreaLocationId, Adventurer adventurer)
        {
            WorldAreaLocation worldAreaLocation = GetWorldAreaLocationById(worldAreaLocationId);
            if (worldAreaLocation.PlayerCanAccess(adventurer) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// return the current maximum ID for a worldAreaLocation object
        /// </summary>
        /// <returns>max worldAreaLocationObjectID </returns>
        public int GetMaxWorldAreaLocationId()
        {
            int MaxId = 0;

            foreach (WorldAreaLocation worldAreaLocation in _worldAreaLocations)
            {
                if (worldAreaLocation.WorldAreaLocationID > MaxId)
                {
                    MaxId = worldAreaLocation.WorldAreaLocationID;
                }
            }

            return MaxId;
        }

        /// <summary>
        /// get a worldAreaLocation object using an Id
        /// </summary>
        /// <param name="Id">worldArea location Id</param>
        /// <returns>requested worldArea location</returns>
        public WorldAreaLocation GetWorldAreaLocationById(int Id)
        {
            WorldAreaLocation worldAreaLocation = null;

            //
            // run through the worldArea location list and grab the correct one
            //
            foreach (WorldAreaLocation location in _worldAreaLocations)
            {
                if (location.WorldAreaLocationID == Id)
                {
                    worldAreaLocation = location;
                }
            }

            //
            // the specified ID was not found in the World
            // throw and exception
            //
            if (worldAreaLocation == null)
            {
                string feedbackMessage = $"The World Area Location ID {Id} does not exist in the current World.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return worldAreaLocation;
        }

        /// <summary>
        /// return the maximum ID for a GameObject object
        /// </summary>
        /// <returns>max GameObjectID </returns>
        public int GetMaxGameObjectId()
        {
            int MaxId = 0;

            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.Id > MaxId)
                {
                    MaxId = gameObject.Id;
                }
            }

            return MaxId;
        }

        /// <summary>
        /// get a game object using an Id
        /// </summary>
        /// <param name="Id">game object Id</param>
        /// <returns>requested game object</returns>
        public GameObject GetGameObjectById(int Id)
        {
            GameObject gameObjectToReturn = null;

            //
            // run through the game object list and grab the correct one
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.Id == Id)
                {
                    gameObjectToReturn = gameObject;
                }
            }

            //
            // the specified ID was not found in the World
            // throw and exception
            //
            if (gameObjectToReturn == null)
            {
                string feedbackMessage = $"The Game Object ID {Id} does not exist in the current World.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return gameObjectToReturn;
        }

        public List<GameObject> GetGameObjectsByWorldAreaLocationId(int worldAreaLocationId)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            //
            // run through the game object list and grab all that are in the current worldArea location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.WorldAreaLocationId == worldAreaLocationId)
                {
                    gameObjects.Add(gameObject);
                }
            }

            return gameObjects;
        }

        public List<AdventurerObject> GetAdventurerObjectsByWorldAreaLocationId(int worldAreaLocationId)
        {
            List<AdventurerObject> adventurerObjects = new List<AdventurerObject>();

            //
            // run through the game object list and grab all that are in the current worldArea location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.WorldAreaLocationId == worldAreaLocationId && gameObject is AdventurerObject)
                {
                    adventurerObjects.Add(gameObject as AdventurerObject);
                }
            }

            return adventurerObjects;
        }

        public bool IsValidNpcByLocationId(int npcId, int currentWorldAreaLocation)
        {
            List<int> npcIds = new List<int>();

            //
            // create a list of NPC ids in current worldArea location
            //

            foreach (Npc npc in _npcs)
            {
                if (npc.WorldAreaLocationID == currentWorldAreaLocation)
                {
                    npcIds.Add(npc.Id);
                }

            }

            //
            // determine if the game object id is a valid id and return the result
            //

            if (npcIds.Contains(npcId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Npc GetNpcById(int Id)
        {
            Npc npcToReturn = null;

            //
            // run through the NPC object list and grab the correct one
            //

            foreach (Npc npc in _npcs)
            {
                if (npc.Id == Id)
                {
                    npcToReturn = npc;
                }
            }

            //
            // the specified ID was not found in the World
            // throw and exception
            //

            if (npcToReturn == null)
            {
                string feedbackMessage = $"The NPC ID {Id} does not exist in the current World.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return npcToReturn;
        }

        public List<Npc> GetNpcsByWorldAreaLocationId(int worldAreaLocationID)
        {
            List<Npc> npcs = new List<Npc>();

            //
            // run through the NPC object list and grab all that are in the current worldArea location
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.WorldAreaLocationID == worldAreaLocationID)
                {
                    npcs.Add(npc);
                }
            }

            return npcs;
        }

        #endregion
    }
}
