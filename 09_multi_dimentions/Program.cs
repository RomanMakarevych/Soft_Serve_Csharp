//--------------------- Multi-Dimentions arrays -----------
int[,] matrix = new int[3, 4]
{
    { 1,2,3,4 },
    { 2,5,6,4 },
    { 55,66,77,44 }
};

Console.WriteLine($"Lenght: {matrix.Length}");
Console.WriteLine($"Lenght: {matrix.GetLength(1)}");

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 4; j++)
    {
        Console.Write(matrix[i,j] + " ");
    }
    Console.WriteLine();
}