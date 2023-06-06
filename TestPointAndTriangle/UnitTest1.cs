using Home_Work_10_1;
using System.Drawing;
using Point = Home_Work_10_1.Point;

namespace TestPointAndTriangle
{
    [TestClass]
    public class TestPoint
    {
        Point vertex1 = new Point(0, 0);
        Point vertex2 = new Point(0, 3);
        Point vertex3 = new Point(4, 0);
        [TestMethod]
        public void PerimeterTest()
        {
            Triangle triangle = new(vertex1, vertex2, vertex3);

            // Arrange
            double expectedPerimeter = 12;

            // Act
            double actual = triangle.Perimeter();

            //Assert
            Assert.AreEqual(expectedPerimeter, actual);

        }
        [TestMethod]
        public void SquareTest()
        {
            Triangle triangle = new(vertex1, vertex2, vertex3);

            // Arrange
            double expectedSquare = 6;

            // Act
            double actual = triangle.Square();

            //Assert
            Assert.AreEqual(expectedSquare, actual);


        }
        [TestMethod]
        public  void PrintText()
        {
            Triangle triangle = new(vertex1, vertex2, vertex3);
            string expectedOutput = " Triangle with vertices:\n Vertex 1: (0,0) \n Vertex 2: (0,3) \n Vertex 3: (4,0) \n" +
                                    " Perimeter: 12 \n Square: 6 \n";
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw); //перенаправляємо вивід консолі на об'єкт StringWriter
                triangle.Print();
                string actualPrint = sw.ToString();

                Assert.AreEqual(expectedOutput, actualPrint);

            }


        }
      
    }
}