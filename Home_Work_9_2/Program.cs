using System.Text.RegularExpressions;

namespace Home_Work_9_2
{
    internal class Program
    {
        static void Main(string[] args)
        {  
            //Task B

            string fileName = "file.txt";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            File.WriteAllText(filePath, txt);
            string[] alllines = File.ReadAllLines(filePath);
            

            // Task B_1: Count and write the number of symbols in every line
            CountofLineSymbol(alllines);

            // Task B_2: Find the longest and the shortest line
            var shortestLine = alllines.OrderBy(line => line.Length).First();
            ShowLineLength(shortestLine);

            var longestLine = alllines.OrderByDescending(line => line.Length).First();
            ShowLineLength(longestLine);

            // Task B_3:  Find and write only lines that consist of the word "var"
            string searchText = "var";

            // A:
            FindAndWriteSearchLine(alllines, searchText);
            // B:
            Regex reg = new Regex(@"\b" + searchText + @"\b");
            FindWithRegex(alllines, searchText, reg);
        }

        
        static void FindWithRegex(string[]lines, string searchText,Regex reg)
        {
            foreach (string line in lines)
            {
                if (reg.IsMatch(line))
                {
                    Console.WriteLine(line);
                }
            }
        }

        static void FindAndWriteSearchLine(string[]lines,string textLine)
        {
            foreach (string  line in lines)
            {
                if (line.Contains(textLine))
                {
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine("\n" + new string('-', 110) + "\n");
        }

        static void ShowLineLength<T>(IEnumerable<T> lines)
        {
            foreach (var item in lines)
            {
                Console.Write(item);
            }
            Console.WriteLine("\n"+new string('-',110)+"\n");
        }
        static void CountofLineSymbol(string[] lines)
        {
            Console.WriteLine("\n\t\t Number of symbols in each line:\n");

            foreach (string line in lines)
            { 
                int symbolCount=line.Length;
                Console.WriteLine($"Line {number}: Symbol Count: {symbolCount}");
                ++number;
            }
            Console.WriteLine("\n");
        }

        static int number = 1; 

        static string txt =
                            " What is Lorem Ipsum? var\r\n" +
                            " Hello\n" +
                            " var\n"+
                            " Lorem Ipsum is simply dummy text of the printing and typesetting industry.\n" +
                            " Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,\n" +
                            " when an unknown printer took a galley of type var and scrambled it to make a type specimen book.\n" +
                            " It has survived not only five centuries, but also the leap into electronic typesetting,\n" +
                            " remaining essentially unchanged.\n" +
                            " It was popularised in the 1960s with the release var of Letraset sheets containing Lorem Ipsum passages,\n" +
                            " and more recently with desktop publishing software like Aldus PageMak.\n";
    }
}