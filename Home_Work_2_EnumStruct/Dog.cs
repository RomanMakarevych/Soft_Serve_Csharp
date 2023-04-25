
   struct Dog
    {
    
    public string name;
    public string mark;
    public int age;

    public override string ToString()
        {
            return $"Name: {name}, Mark: {mark}, Age: {age}";
        }

    public void Info()
    {
        Console.WriteLine($"Name: {name}, Mark: {mark}, Age: {age}");
    }

}

