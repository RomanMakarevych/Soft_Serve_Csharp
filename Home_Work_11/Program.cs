using System.ComponentModel.Design.Serialization;

namespace Home_Work_11
{
    public delegate void MyDel(int m);

    class Student
    {
        private string? name;
        private List<int> marks;
        public event MyDel MarkChange;

      
        public Student(string name, List<int> marks)
        {
            this.name = name;
            this.marks = marks;
            
        }
        public void AddMark(int mark)
        {
            if(mark < 0 || mark > 12)
                throw new ArgumentOutOfRangeException( "mark","The mark must be between 0 and 12.");
            marks.Add(mark);
            MarkChange?.Invoke(mark);
        }

        public void Print()
        {
            Console.Write($"{name}: ");
            foreach (var item in marks)
            {
                Console.Write(item + " ") ;
            }
        }

    }

    class Parent
    {
        public void OnMarkChange(int mark)
        {
            Console.WriteLine($"New mark: {mark}");
        }
    }

    class Accountancy
    {
        public void PayingFellowship(int mark)
        {
            if (mark >= 10)
            {
                Console.WriteLine("The student is eligible for a scholarship.");
            }
            else
            {
                Console.WriteLine("The student is not eligible for a scholarship.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new("Roman", new List<int> { });
            Parent parent = new();
            Accountancy accountancy = new();
            student.MarkChange += parent.OnMarkChange;
            student.MarkChange += accountancy.PayingFellowship;

           

            try
            {
                student.AddMark(10);
                student.AddMark(9);
                student.AddMark(12);
                student.Print();
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error:" + ex.Message);
            }


        }
    }
}