using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestWar
{
    /// <summary>
    /// class for the game map locations
    /// </summary>
    public class WorldAreaLocation
    {
        #region FIELDS

        private string _commonName;
        private int _worldAreaLocationID; // must be a unique value for each object
        private int _universalDate;
        private string _universalLocation;
        private string _description;
        private string _generalContents;
        private int _experiencePoints;

        #endregion


        #region PROPERTIES

        public string CommonName
        {
            get { return _commonName; }
            set { _commonName = value; }
        }

        public int WorldAreaLocationID
        {
            get { return _worldAreaLocationID; }
            set { _worldAreaLocationID = value; }
        }

        public int UniversalDate
        {
            get { return _universalDate; }
            set { _universalDate = value; }
        }

        public string UniversalLocation
        {
            get { return _universalLocation; }
            set { _universalLocation = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string GeneralContents
        {
            get { return _generalContents; }
            set { _generalContents = value; }
        }

        public Func<Adventurer, bool> PlayerCanAccess { get; set; } = p => true;

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        #endregion


        #region CONSTRUCTORS



        #endregion


        #region METHODS



        #endregion


    }
}
