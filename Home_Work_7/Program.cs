using System.Reflection.PortableExecutable;

namespace Home_Work_7
{

    internal class Program
    {


        static void Main(string[] args)
        {

            Dictionary<string, string> phoneBook = new();

            //створюемо папку PhoneBook на робочому столi

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string dirName = "PhoneBook";

            if (!Directory.Exists($@"{desktopPath}/{dirName}"))
            {
                Directory.CreateDirectory(Path.Combine(desktopPath, dirName));
            }

            //створюемо текстовий файл "phones.txt" у папцi PhoneBook 

            string fileName = "phones.txt";
            string filePath = Path.Combine(desktopPath, dirName, fileName);

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            // записуемо номера телефону i iмена у файл "phones.txt"

            using (StreamWriter writer = File.CreateText(filePath))
            {
                writer.WriteLine("Roman: 80997483549 \n" +
                                 "Anton: 80967444548 \n" +
                                 "Oleg: 80997435541 \n" +
                                 "Maria: 80675483540 \n" +
                                 "Daria: 80954333491 \n" +
                                 "Igor: 80997563740 \n" +
                                 "Petro: 80997783541 \n" +
                                 "Oksana: 80937783542 \n" +
                                 "Petro9: 80937783541 \n" +
                                 "Anton: 80997999945 \n" +
                                 "Igor: 80977811146 \n" +
                                 "Bohdan: 80632223849");
            }

            // зчитуемо весь текст з фалу "phones.txt"

            Console.WriteLine("\n------------------ Text from file: <phones.txt> ------------------\n");
            using (StreamReader reader = File.OpenText(filePath))
            {
                string all = reader.ReadToEnd();
                Console.WriteLine($"{all}");
            }

            // Читання даних з файлу та запис у словник

            Console.WriteLine("------------------ Read and write from file:<phones.txt> to Dictionary <phoneBook> ------------------\n");


            using (StreamReader reader1 = File.OpenText(filePath))
            {
                int count = 1;//створюемо змiнну,щоб лише 9 пар записати
                string line;
                while ((line = reader1.ReadLine()) != null && count <= 9)
                {
                    string[] parts = line.Split(':');
                    string key = parts[0];
                    string value = parts[1];
                    phoneBook[key] = value;
                    ++count;
                }
            }

            foreach (var dic in phoneBook)
            {
                Console.WriteLine("Name: " + dic.Key + ", Phone number: " + dic.Value);
            }

            // Створюемо новий текстовий файл "Phones.txt" у папцi PhoneBook  i  зааписуемо лише PhoneNumbers 

            string filePhoneNumber = "PhonesNumbers.txt";
            string filePathPhoneNumber = Path.Combine(desktopPath, dirName, filePhoneNumber);

            if (!File.Exists(filePathPhoneNumber))
            {
                File.Create(filePathPhoneNumber).Close();
            }

            using (StreamWriter writer1 = File.CreateText(filePathPhoneNumber))
            {
                foreach (var number in phoneBook)
                {
                    writer1.WriteLine(number.Value);
                }
            }

            Console.WriteLine("\n");

            //пошук номера телефону за iменем

            Console.WriteLine("------------------ Search Phone number with Name from Dictionary <phoneBook> ------------------\n");

            Console.WriteLine("Введiть iм'я для пошуку номера телефону:");
            
            string searchName = Console.ReadLine();

            if (phoneBook.TryGetValue(searchName, out string searchNumber))
            {
                Console.WriteLine("Знайдено номер телефону: " + searchNumber+"\n");
            }
            else
            {
                Console.WriteLine("Номер телефону для вказаного iменi не знайдено.\n");
            }

            //Змінити всі номери телефонів у форматі 80########## на новий формат +380######## 

            Console.WriteLine("------------------ Replace all Phonenumbers 80######### to +380######## ------------------\n");

            Dictionary<string, string> updatedPhoneBook = new Dictionary<string, string>();
            foreach (var dic in phoneBook)
            {
                string updatedNumber = dic.Value.Replace("80", "+380");
                updatedPhoneBook[dic.Key] = updatedNumber;
            }

            foreach (var item in updatedPhoneBook)
            {
                Console.WriteLine(item.Key + " "+ item.Value);
            }

            //  Результат записати у файл «New.txt»

            string fileNew = "New.txt";
            string fileNewPath = Path.Combine(desktopPath, dirName, fileNew);
            if (!File.Exists(fileNewPath))
            {
                File.Create(fileNewPath).Close();
            }

            using(StreamWriter writer2 = File.CreateText(fileNewPath))
            {
                foreach (var dic in updatedPhoneBook)
                {
                    writer2.WriteLine(dic);
                }
            }  

        }
    }
}