using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestWar
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum RaceType
        {
            None,
            Human,
            Elf,
            Dwarf
        }

        #endregion

        #region FIELDS

        protected string _name;
        protected int _worldAreaLocationID;
        protected int _age;
        protected RaceType _race;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int WorldAreaLocationID
        {
            get { return _worldAreaLocationID; }
            set { _worldAreaLocationID = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }

        public int HP { get; set; } = 10;
        public int MP { get; set; } = 5;

        


        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, RaceType race, int worldAreaLocationID)
        {
            _name = name;
            _race = race;
            _worldAreaLocationID = worldAreaLocationID;
        }

        #endregion

        #region METHODS



        #endregion
    }
}
