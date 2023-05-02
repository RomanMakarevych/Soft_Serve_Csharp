//------------- Array ---------
// array can stora multile values of the same type
// array[] name = new type[size]{initial values};

//int[] marks = new int[10]; // 0 by default
int[] marks = {4,5,6,5,1,7,8}; // simplyfy
//access array item:  array[index]
marks[0] += 2;
Console.WriteLine($"First marks {0}");
Console.WriteLine($"Last marks {9}");
Console.WriteLine($"Marks count: {marks.Length}");

// show all marks 
for (int i = 0; i < marks.Length; i++)
{
    Console.WriteLine($"Studen {i+1} mark = {marks[i]}");

}
// show student's average mark

int sum = 0;
//for (int i = 0; i < marks.Length; i++)
//{
//    sum += marks[i];
//}

foreach(int m in marks)
{
    sum += m;
}
Console.WriteLine($"Average mark: {(float)sum/marks.Length}");

//----------------- foreach(type name in collection){..code..};

foreach (int m in marks)
{    
    // m +=2 // cannot change the value
    Console.WriteLine($"Mark: {m}");
}