using MyCalccLib;

namespace MyCalcTest
{
    [TestClass]
    public class MyCalc_test
    {
        int x = 10;
        int y = 20;
        [TestMethod]
        public void TestMethod1()
        {
            //налаштування для перевiрки
          
            int expected = 30;

            // актуальний проект

            MyCalc calc = new();
            int actual = calc.Sum(x, y);
            // assert
            Assert.AreEqual(expected, actual);


        }
        [TestMethod]
        public void TestSub()
        {
            int expected = -10;
            MyCalc sub = new();
            int actual = sub.Sub(x, y);

            Assert.AreEqual(expected, actual);

        }

    }
}