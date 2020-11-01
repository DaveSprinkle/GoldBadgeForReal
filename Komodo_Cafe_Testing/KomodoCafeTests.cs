using System;
using System.Collections.Generic;
using _03_Komodo_Cafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Komodo_Cafe_Testing
{
    [TestClass]
    public class KomodoCafeTests
    {
        [TestMethod]
        public void AddRecipientToList_ShouldGetCorrectBoolean()
        {
            //Arrange
            KMenuItem item = new KMenuItem();
            Komodo_Cafe_Repo repo = new Komodo_Cafe_Repo();

            //Act
            bool addResult = repo.AddMenuItemToList(item);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetMenu_ShouldReturnCorrectCollection()
        {
            //Arrange
            KMenuItem newItem = new KMenuItem();
            Komodo_Cafe_Repo repo = new Komodo_Cafe_Repo();

            repo.AddMenuItemToList(newItem);

            //Act
            List<KMenuItem> listItems = repo.GetItems();

            bool menuHasContent = listItems.Contains(newItem);

            //Assert
            Assert.IsTrue(menuHasContent);
        }

        [TestMethod]
        public void GetByModel_ShouldReturnCorrectContent()
        {
            //Arrange
            Komodo_Cafe_Repo repo = new Komodo_Cafe_Repo();            
            KMenuItem newItem = new KMenuItem(1, "Test Meal", "Delicious", "Some ingredients", 10.95m);
            repo.AddMenuItemToList(newItem);
            string mealname = "Test Meal";

            //Act
            KMenuItem searchResult = repo.GetItemByName(mealname);
            //Assert
            Assert.AreEqual(searchResult.MealName, mealname);
        }

        [TestMethod]
        public void UpdateExistingItem_ShouldReturnTrue()
        {
            //Arrange
            Komodo_Cafe_Repo repo = new Komodo_Cafe_Repo();
            KMenuItem oldItem = new KMenuItem(1, "Test Meal", "Delicious", "Some ingredients", 10.95m);
            repo.AddMenuItemToList(oldItem);

            KMenuItem newMeal = new KMenuItem(1, "Test Meal 2", "Delicious", "Some ingredients", 10.95m);

            //Act
            bool updateResult = repo.UpdateExistingItem(oldItem.MealName, newMeal);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteExistingItem_ShouldReturnTrue()
        {
            //Arrange
            Komodo_Cafe_Repo repo = new Komodo_Cafe_Repo();
            KMenuItem newItem = new KMenuItem(1, "Test Meal", "Delicious", "Some ingredients", 10.95m);
            repo.AddMenuItemToList(newItem);
            string mealname = "Test Meal";

            //Act
            KMenuItem oldItem = repo.GetItemByName(mealname);

            bool removeResult = repo.DeleteItem(newItem);

            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}
