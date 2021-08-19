using AddressBookADO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressTest
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookRepo addressBook = new AddressBookRepo();
        AddressBookModel model = new AddressBookModel();

        [TestMethod]
        public void AddingContactShouldReturnTrue()
        {
            model.FirstName = "sam";
            model.LastName = "bat";
            model.Address = "lank";
            model.City = "Vegas";
            model.State = "Texas";
            model.ZipCode = "733301";
            model.PhoneNumber = "1156534455";
            model.EmailId = "sam7@xyz.com";

            var result = addressBook.AddContacts(model);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdatingContactShouldReturnTrue()
        {
            model.FirstName = "sam";
            model.LastName = "den";
            model.Address = "Cental park";
            model.City = "paris";
            model.State = "france";
            model.ZipCode = "668899";
            model.PhoneNumber = "88677889088";
            model.EmailId = "sammm7@xyz.com";

            var result = addressBook.EditContact(model);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DelectingContactShouldReturnTrue()
        {
            model.FirstName = "Pra";
            

            var result = addressBook.DeleteContact(model);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenCityOrStateShouldReturnDataIfFound()
        {
            var result = addressBook.DisplayByCityOrState(model);
            Assert.IsNotNull(result);
        }
    }
}
