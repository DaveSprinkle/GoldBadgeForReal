using System;
using System.Collections.Generic;
using _02_Komodo_Email_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Komodo_Email_Testing
{
    [TestClass]
    public class EmailUnitTests
    {
        [TestMethod]
        public void AddRecipientToList_ShouldGetCorrectBoolean()
        {
            //Arrange
            Recipient recipient = new Recipient();
            Email_Repo repo = new Email_Repo();

            //Act
            bool addResult = repo.AddRecipientToList(recipient);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            //Arrange
            Recipient newRecipient = new Recipient();
            Email_Repo repo = new Email_Repo();

            repo.AddRecipientToList(newRecipient);

            //Act
            List<Recipient> listRecipients = repo.GetRecipients();

            bool directoryHasContent = listRecipients.Contains(newRecipient);

            //Assert
            Assert.IsTrue(directoryHasContent);
        }

        [TestMethod]
        public void GetByModel_ShouldReturnCorrectContent()
        {
            //Arrange
            Email_Repo repo = new Email_Repo();
            Recipient newRecipient = new Recipient("David","Sprinkle",1,"dave@mail.com","Howdy.");
            repo.AddRecipientToList(newRecipient);
            string last = "Sprinkle";

            //Act
            Recipient searchResult = repo.GetRecipientByLastName(last);
            //Assert
            Assert.AreEqual(searchResult.LastName, last);
        }

        [TestMethod]
        public void UpdateExistingRecipient_ShouldReturnTrue()
        {
            //Arrange
            Email_Repo repo = new Email_Repo();
            Recipient oldRecipient = new Recipient("David", "Sprinkle", 1, "dave@mail.com", "Howdy.");
            repo.AddRecipientToList(oldRecipient);

            Recipient newRecipient = new Recipient("Cecil", "Sprinkle", 1, "cecil@mail.com", "Howdy.");

            //Act
            bool updateResult = repo.UpdateExistingRecipient(oldRecipient.LastName, newRecipient);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteExistingRecipient_ShouldReturnTrue()
        {
            //Arrange
            Email_Repo repo = new Email_Repo();
            Recipient newRecipient = new Recipient("David", "Sprinkle", 1, "dave@mail.com", "Howdy.");
            repo.AddRecipientToList(newRecipient);
            string lastname = "Sprinkle";

            //Act
            Recipient oldRecipient = repo.GetRecipientByLastName(lastname);

            bool removeResult = repo.DeleteRecipient(oldRecipient);

            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}
