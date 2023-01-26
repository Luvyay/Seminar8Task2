/*
Задача 2
Из двумерного массива целых чисел удалить строку и столбец, на пересечении которых расположен наименьший элемент.
*/

int[,] CreateRandom2dArray()
{
    Console.Write("Input a number of rows: ");
    int rows = Convert.ToInt32(Console.ReadLine());

    Console.Write("Input a number of columns: ");
    int columns = Convert.ToInt32(Console.ReadLine());

    Console.Write("Input a min possible value: ");
    int minValue = Convert.ToInt32(Console.ReadLine());

    Console.Write("Input a max possible value: ");
    int maxValue = Convert.ToInt32(Console.ReadLine());

    int[,] array = new int[rows, columns];

    for(int i = 0; i < rows; i++)
    {
        for(int j = 0; j < columns; j++)
        {
            array[i,j] = new Random().Next(minValue, maxValue + 1);
        }
    }

    return array;
}

void Show2dArray(int[,] array)
{
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i,j] + "\t");
        }

        Console.WriteLine();
    }
    Console.WriteLine();
}

int[] FindMin(int[,] array)
{
    int[] minPosition = new int[2];
    int minValue = array[0,0];

    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            if(array[i,j] < minValue)
            {
                minValue = array[i,j];
                minPosition[0] = i;
                minPosition[1] = j;
            }
        }
    }

    return minPosition;
}

int[,] RemoveArray(int[,] array, int[] Position)
{
    int[,] newArray = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];

    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            newArray[i-Convert.ToInt32((i>=Position[0] + 1)),j-Convert.ToInt32((j>=Position[1] + 1))] = array[i,j];
        }
    }

    return newArray;
}

int[,] newArray = CreateRandom2dArray();
Show2dArray(newArray);

int[] minValue = FindMin(newArray);
Console.WriteLine($"{minValue[0]} {minValue[1]}");
int[,] newArray2 = RemoveArray(newArray, FindMin(newArray));
Show2dArray(newArray2);