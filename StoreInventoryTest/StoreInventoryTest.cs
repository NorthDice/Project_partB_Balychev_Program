namespace StoreInventoryTest
{
    [TestClass]
    public class StoreInventoryTest
    {
        [TestMethod]
        public void Count_ValidCount()
        {
            // Arrange 
            StoreInventory inventory = new StoreInventory()
            {
                new StoreItem(1000, 10, PeripheriItems.None),
                new StoreItem(500, 3, PeripheriItems.None),
                new StoreItem(3000, 5, PeripheriItems.None),
                new StoreItem(1400, 20, PeripheriItems.None)
            };

            // Act
            int result = inventory.Count;

            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Count_InvalidCount()
        {
            // Arrange 
            StoreInventory inventory = new StoreInventory();

            // Act
            int result = inventory.Count;

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Clear_Clear()
        {
            // Arrange 
            StoreInventory inventory = new StoreInventory()
            {
                new StoreItem(1000, 10, PeripheriItems.None),
                new StoreItem(500, 3, PeripheriItems.None),
                new StoreItem(3000, 5, PeripheriItems.None),
                new StoreItem(1400, 20, PeripheriItems.None)
            };

            // Act
            inventory.Clear();

            // Assert
            Assert.AreEqual(0, inventory.Count);
        }

        [TestMethod]
        public void Add_Valid()
        {
            // Arrange
            StoreInventory inventory = new StoreInventory();
            StoreItem newItem = new StoreItem(200, 2, PeripheriItems.Mouse);

            // Act
            inventory.Add(newItem);

            // Assert
            Assert.IsTrue(inventory.Contains(newItem));
        }

        [TestMethod]
        public void Add_Invalid()
        {
            // Arrange
            StoreInventory inventory = new StoreInventory();
            StoreItem newItem = new StoreItem(-200, 2, PeripheriItems.Mouse);

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => inventory.Add(newItem));
        }

        [TestMethod]
        public void Add_NullInput()
        {
            // Arrange
            StoreInventory inventory = new StoreInventory();

            // Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => inventory.Add(null));
        }

        [TestMethod]
        public void Remove_Valid()
        {
            // Arrange
            StoreItem itemToRemove = new StoreItem(500, 3, PeripheriItems.None);
            StoreInventory inventory = new StoreInventory()
            {
                new StoreItem(1000, 10, PeripheriItems.None),
                new StoreItem(3000, 5, PeripheriItems.None),
                new StoreItem(1400, 20, PeripheriItems.None)
            };

            // Act
            bool result = inventory.Remove(itemToRemove);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(inventory.Contains(itemToRemove));
        }

        [TestMethod]
        public void Remove_Invalid()
        {
            // Arrange
            StoreInventory inventory = new StoreInventory();
            StoreItem itemToRemove = new StoreItem(500, 3, PeripheriItems.None);

            // Act
            bool result = inventory.Remove(itemToRemove);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Remove_NullInput()
        {
            // Arrange
            StoreInventory inventory = new StoreInventory();

            // Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => inventory.Remove(null));
        }

        [TestMethod]
        public void Contains_Valid()
        {
            // Arrange
            StoreItem itemToCheck = new StoreItem(500, 3, PeripheriItems.None);
            StoreInventory inventory = new StoreInventory()
            {
                new StoreItem(1000, 10, PeripheriItems.None),
                new StoreItem(3000, 5, PeripheriItems.None),
                new StoreItem(1400, 20, PeripheriItems.None)
            };

            // Act
            bool result = inventory.Contains(itemToCheck);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Contains_Invalid()
        {
            // Arrange
            StoreInventory inventory = new StoreInventory();
            StoreItem itemToCheck = new StoreItem(500, 3, PeripheriItems.None);

            // Act
            bool result = inventory.Contains(itemToCheck);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SortByPrice_SortsItemsByPrice()
        {
            // Arrange
            StoreInventory inventory = new StoreInventory()
            {
                new StoreItem(1000, 10, PeripheriItems.None),
                new StoreItem(500, 3, PeripheriItems.None),
                new StoreItem(3000, 5, PeripheriItems.None),
                new StoreItem(1400, 20, PeripheriItems.None)
            };

            // Act
            inventory.SortByPrice();

            var sortedItems = inventory.ToList();
            Assert.AreEqual(500, sortedItems[0].Price);
            Assert.AreEqual(1000, sortedItems[1].Price);
            Assert.AreEqual(1400, sortedItems[2].Price);
            Assert.AreEqual(3000, sortedItems[3].Price);
        }

    }
}
