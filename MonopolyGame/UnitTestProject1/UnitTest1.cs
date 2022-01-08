using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace MonopolyGame
{
    [TestClass]
    public class UnitTest1
    {
        //Test on Chance class
        [TestMethod]
        public void ChanceMessage()
        {
            Chance chance = new Chance();
            chance.Number = 7;
            string result = chance.Chance_message();
            Assert.AreEqual<string>(result, "It's your lucky day. When you walk around here, you find some money on the ground. Get $118.");
        }

        //Test on CommunityChest class
        [TestMethod]
        public void CommunityChestMessage()
        {
            CommunityChest community = new CommunityChest();
            community.Number = 7;
            string result = community.Community_Chest_message();
            Assert.AreEqual<string>(result, "Holiday fund matures. Receive $100");
        }

        //Tests on Player class
        [TestMethod]
        public void EnoughMoneyPlayer()
        {
            Player player = new Player();
            player.Money = 140;
            bool result = player.EnoughMoneyToBuy(100);
            Assert.AreEqual<bool>(result, true);    
        }

        [TestMethod]
        public void NotEnoughMoneyPlayer()
        {
            Player player = new Player();
            player.Money = 140;
            bool result = player.EnoughMoneyToBuy(200);
            Assert.AreEqual<bool>(result, false);
        }
        [TestMethod]
        public void FamilyCompletePlayer()
        {
            Property property = new Property("Tuilerie Garden", 120, 118, "Garden", 2, 18);
            Property property2 = new Property("Plants Garden", 180, 176, "Garden", 2, 12);
            Player player = new Player();
            player.Own_properties = new List<Property>();
            player.Own_properties.Add(property);
            player.Own_properties.Add(property2);

            bool result = player.FamilyComplete(property);
            Assert.AreEqual<bool>(result, true);   
        }
        [TestMethod]
        public void FamilyNotCompletePlayer()
        {
            Property property = new Property("Tuilerie Garden", 120, 118, "Garden", 3, 18);
            Property property2 = new Property("Plants Garden", 180, 176, "Garden", 3, 12);
            Player player = new Player();
            player.Own_properties = new List<Property>();
            player.Own_properties.Add(property);
            player.Own_properties.Add(property2);
            bool result = player.FamilyComplete(property);
            Assert.AreEqual<bool>(result, false);
        }
        [TestMethod]
        public void NumberOfRailroad()
        {
            Property property = new Property("Saint-Lazare RailRoad", 120, 118, "Railroad", 2, 18);
            Property property2 = new Property("Montparnasse Railroad", 180, 176, "Railroad", 2, 12);
            Player player = new Player();
            player.Own_properties = new List<Property>();
            player.Own_properties.Add(property);
            player.Own_properties.Add(property2);
            int result = player.NumberOfRailroads();
            Assert.AreEqual(result, 2);
        }
    }
}
