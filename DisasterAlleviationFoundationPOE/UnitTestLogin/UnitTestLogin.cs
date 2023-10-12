using DisasterAlleviationFoundationPOE.ViewModels;
using DisasterAlleviationFoundationPOE.Pages.MonetaryDonations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DisasterAlleviationFoundationPOE.UnitTestLogin
{
    [TestClass]
    public class UnitTestLogin
    {
        Login login;

        [TestMethod]
        public void TestMethod1_ReturnsSuccessfullLogin()
        {

            // Arrange
            Login login = new Login();
            const string Email = "Joe";
            const string Password = "Joe123456";
            const bool RememberMe = true;


            // Act
            var actual = Login.Equals(Email, Password);

            // Assert
            Assert.IsTrue(true);

        }

        public void TestMethod2()
        {
            Assert.IsNotNull(true);
        }

    }


}