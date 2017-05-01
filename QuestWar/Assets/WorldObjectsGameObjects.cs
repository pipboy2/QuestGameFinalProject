using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestWar
{
    /// <summary>
    /// static class to hold all objects in the game world; locations, game objects, npc's
    /// </summary>aa
    public static partial class WorldObjects
    {
        public static List<GameObject> GameObjects = new List<GameObject>()
        {
            new AdventurerObject
            {
                Id = 1,
                Name = "Bag of Gold",
                WorldAreaLocationId = 2,
                Description = "A small leather pouch filled with 9 gold coins.",
                Type = AdventurerObjectType.Treasure,
                Value = 45,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new AdventurerObject
            {
                Id = 2,
                Name = "Dimond",
                WorldAreaLocationId = 3,
                Description = "A large dimond the size of your fist",
                Type = AdventurerObjectType.Treasure,
                Value = 45,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new AdventurerObject
            {
                Id = 3,
                Name = "Red Potion",
                WorldAreaLocationId = 3,
                Description = "A small vial that holds a mysterious red liquide.",
                Type = AdventurerObjectType.Medicine,
                Value = 45,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new AdventurerObject
            {
                Id = 4,
                Name = "A blank piece of paper",
                WorldAreaLocationId = 4,
                Description =
                    "A blank piece of paper..." + "/n" +
                    "at closer inspection you notice a small line of text" + "/n" +
                    "/n" +
                    "It says that the key to the dark castle is in the dungeon. Take this key!",
                Type = AdventurerObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new AdventurerObject
            {
                Id = 8,
                Name = "Bastard Sword",
                WorldAreaLocationId = 0,
                Description =
                    "A sword given to you from you fater. It can be used one handed or two handed.",
                Type = AdventurerObjectType.Weapon,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new AdventurerObject
            {
                Id = 9,
                Name = "Staff",
                WorldAreaLocationId = 0,
                Description =
                    "A Magical Staff that you aquired from your adventures.",
                Type = AdventurerObjectType.Weapon,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new AdventurerObject
            {
                Id = 11,
                Name = "Bow and arrows",
                WorldAreaLocationId = 0,
                Description =
                    "A wooden bow that you made yourself in your youth.",
                Type = AdventurerObjectType.Weapon,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new AdventurerObject
            {
                Id = 7,
                Name = "Dark Dungeon Key",
                WorldAreaLocationId = 4,
                Description =
                    "The Key to open the door to the Dark Dungeon.",
                Type = AdventurerObjectType.Treasure,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },
            new WorldAreaLocationObject
            {
                Id = 5,
                Name = "Golden Chest",
                WorldAreaLocationId = 2,
                Description = "A large wooden chest adorned with jewels.",
                IsDeadly = true
            },

            new WorldAreaLocationObject
            {
                Id = 6,
                Name = "Silver Mirror",
                WorldAreaLocationId = 2,
                Description = "A small silver mirror hanging on the wall next to a small window.",
                IsDeadly = true
            },

            new AdventurerObject
            {
                Id = 10,
                Name = "Dark Castle Key",
                WorldAreaLocationId = 3,
                Description =
                    "The key to get into the Dark Castle",
                Type = AdventurerObjectType.Treasure,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            }
        };
    }
}
