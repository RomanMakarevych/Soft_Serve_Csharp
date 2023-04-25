class Cat
{
    public int FullnessLevel { get;  set; }


    public void EatSomething(FoodEnum food)
    {
            switch (food)
            {
                case FoodEnum.fisch:
                    FullnessLevel += 10;
                    break;
                case FoodEnum.mouse:
                    FullnessLevel += 20;
                    break;
                case FoodEnum.meat:
                    FullnessLevel += 30;
                    break;
                default:
                    Console.WriteLine("I don't want to eat that!");
                    break;

            }
       
    }

}

