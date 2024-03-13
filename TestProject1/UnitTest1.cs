using Models;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            Massage massage = new Massage();
            Assert.Pass();
        }
    }
}