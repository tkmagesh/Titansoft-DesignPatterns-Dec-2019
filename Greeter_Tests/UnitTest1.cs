using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreeterApp;

namespace Greeter_Tests
{
    [TestClass]
    public class GreeterTests
    {
        [TestMethod]
        public void Greets_Good_Morning_When_Hour_Before_12()
        {
            //Arrange
            var userName = "Magesh";
            var sut = new Greeter();
            var expectedResult = "Hi Magesh, Good Morning!";

            //Act
            var actualResult = sut.Greet(userName);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        

        [TestMethod]
        public void Greets_Good_Day_When_Hour_After_12()
        {
            //Arrange
            var userName = "Magesh";
            var sut = new Greeter();
            var expectedResult = "Hi Magesh, Have a Good Day!";

            //Act
            var actualResult = sut.Greet(userName);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
