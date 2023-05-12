namespace _14_exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // code wit exception 

            //    string str = null;
            //    str.Replace('@', '-');// NullReferenceexception




            FinallysExample();



            Console.WriteLine("Continue ...");
        
        }

        private static void ExceptionsExample()
        {
            try
            {


                Console.WriteLine("Enter current year ");
                int year = int.Parse(Console.ReadLine());

                Console.WriteLine($"Next year {year + 1} ");

            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Overflow : {ex.Message}");

            }

            catch (ArgumentException ex)
            {
                Console.WriteLine($"(Argument null:  {ex.Message}");

            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalide Form : {ex.Message}");

            }

        }

        private static void FinallysExample()
        {


            var writer = File.AppendText("text.txt");
            //stream.Write();
            //stream.Read();


            try
            {
                Console.WriteLine("Enter current year ");
                int year = int.Parse(Console.ReadLine());

                writer.WriteLine($"Current year {year}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            finally
            {

                Console.WriteLine( "cLEAR RESOURCES");
                // clear resources
                writer.Close();
                
            }
        }
           

    }

  
}