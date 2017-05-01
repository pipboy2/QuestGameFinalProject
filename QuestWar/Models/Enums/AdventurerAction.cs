using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestWar
{
    /// <summary>
    /// enum of all possible player actions
    /// </summary>
    public enum AdventurerAction
    {
        None,
        MissionSetup,
        LookAround,
        LookAt,
        PickUp,
        PutDown,
        Inventory,
        Travel,
        TravelMenu,
        AdventurerInfo,
        AdventurerLocationsVisited,
        ObjectMenu,
        NonplayerCharacterMenu,
        TalkTo,
        ListWorldAreaLocations,
        ListGameObjects,
        ListNonplayerCharacters,
        AdminMenu,
        ReturnToMainMenu,
        Battle,
        Exit
    }
}
