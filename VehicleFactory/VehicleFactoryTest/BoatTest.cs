using VehicleFactory;

namespace VehicleFactoryTest
{
    [TestClass]
    public class BoatTest
    {
        [TestMethod]
        public void SwimMaxCountNegativeTest()
        {
            var boat = new Boat();
            var result = boat.Swim(-2);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        [DataRow(123)]
        [DataRow(-3)]
        [DataTestMethod]
        public void SwimSuccessTest(int maxCount)
        {
            var boat = new Boat();
            var result = boat.Swim(maxCount);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void SwimMoreThanMaxTest()
        {
            int max = 5; 
            var boat = new Boat();
            var expectedResult = false;
            for(int i = 0; i < 10; i++)
            {
                var result = boat.Swim(max);
                expectedResult = result;
            }

            Assert.AreEqual(false, expectedResult);
        }

        [TestMethod]
        public void SwimFiveTimesTest()
        {
            int max = 5;
            var boat = new Boat();
            var expectedResult = false;
            for (int i = 0; i < 6; i++)
            {
                var result = boat.Swim(max);
                expectedResult = result;
            }

            Assert.AreEqual(true, expectedResult);
        }
    }
}