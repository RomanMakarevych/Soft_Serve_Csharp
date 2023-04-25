struct User
{
    public int ID { get; set; }
    public string Email { get; set; }
    public string? Adress { get; set; }
    public double Bonus { get; set; }

}

internal class Program
{

    private static void Main(string[] args)
    {
        int id = 10002;
        string name = "Roman";
        string adress = "Lviv";

        User me = new User()
        {
            ID= 1004,
            Email="lviv",
            Adress= "SChevchenka",
            Bonus= 1200
        };
        me.ID = 1004;

    }

}
