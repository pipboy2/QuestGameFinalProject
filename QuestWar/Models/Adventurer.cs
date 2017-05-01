using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestWar
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Adventurer : Character
    {
        #region ENUMERABLES


        #endregion

        #region FIELDS

        private int _experiencePoints;
        private int _lives;
        private List<int> _worldAreaLocationsVisited;
        private List<AdventurerObject> _inventory;


        #endregion


        #region PROPERTIES

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        public int Health
        {
            get { return HP; }
            set { HP = value; }
        }

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }
        
        public List<int> WorldAreaLocationsVisited
        {
            get { return _worldAreaLocationsVisited; }
            set { _worldAreaLocationsVisited = value; }
        }
        
        public List<AdventurerObject> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public int TotalMoney { get; set; } = 0;

        public int OneHandedWeaponDamage { get; set; } = 10;
        public int TwoHandedWeaponDamage { get; set; } = 10;
        public int RangedWeaponDamage { get; set; } = 10;
        public int MagicDamage { get; set; } = 10;

        public int OneHandedWeaponSkill { get; set; } = 10;
        public int TwoHandedWeaponSkill { get; set; } = 10;
        public int RangedWeaponSkill { get; set; } = 10;
        public int MagicSkill { get; set; } = 10;
        #endregion


        #region CONSTRUCTORS

        public Adventurer()
        {
            _worldAreaLocationsVisited = new List<int>();
            _inventory = new List<AdventurerObject>();
        }

        public Adventurer(string name, RaceType race, int worldAreaLocationID) : base(name, race, worldAreaLocationID)
        {
            _worldAreaLocationsVisited = new List<int>();
            _inventory = new List<AdventurerObject>();
        }

        #endregion


        #region METHODS

        public bool HasVisited(int _worldAreaLocationID)
        {
            if (WorldAreaLocationsVisited.Contains(_worldAreaLocationID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
