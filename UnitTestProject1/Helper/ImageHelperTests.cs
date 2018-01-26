using AHWForm.ExtMethods;
using NUnit.Framework;

namespace UnitTestProject1.Helper
{
    [TestFixture]
    public class ImageHelperTests
    {


        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void TestMethod1()
        {
            // Arrange


            // Act
            ImageHelper imageHelper = this.CreateImageHelper();


            // Assert

        }

        private ImageHelper CreateImageHelper()
        {
            return new ImageHelper();
        }
    }
}
