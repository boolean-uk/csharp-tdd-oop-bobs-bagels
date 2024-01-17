using exercise.main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.tests
{
    [TestFixture]
    public class InventoryTests
    {
        [Test]
        public void AddItem_ItemAddedToInventory()
        {
            // Arrange
            Inventory inventory = new Inventory();
            Bagel bagel = new Bagel("BGLO", 0.49m, "Bagel", "Onion");

            // Act
            inventory.AddItem(bagel);

            // Assert
            Assert.IsTrue(inventory.GetItemDetails("BGLO") != null, "Item should be added to the inventory");
        }
        
        [Test]
        public void RemoveItem_ItemRemovedFromInventory()
        {
            // Arrange
            Inventory inventory = new Inventory();
            Bagel bagel = new Bagel("BGLO", 0.49m, "Bagel", "Onion");
            inventory.AddItem(bagel);

            // Act
            inventory.RemoveItem("BGLO");

            // Assert
            Assert.Throws<ArgumentException>(() => inventory.GetItemDetails("BGLO"), "Item should be removed from the inventory");
        }
    }
}
