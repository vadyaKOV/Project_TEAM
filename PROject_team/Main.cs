using Person;
using Article;
using Magazine;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

Console.WriteLine("Введите количество строк и столбцов через пробел, запятую или точку с запятой:");
string input = Console.ReadLine();
string[] dimensions = input.Split(new char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

int nrow = int.Parse(dimensions[0]);
int ncolumn = int.Parse(dimensions[1]);
int totalElements = nrow * ncolumn;

int[] oneDimensionalArray = new int[totalElements];
InitializeOneDimensionalArray(oneDimensionalArray);
long startTime = Environment.TickCount;
PerformOperationOnOneDimensionalArray(oneDimensionalArray);
long endTime = Environment.TickCount;
long oneDimensionalTime = endTime - startTime;

// Двумерный прямоугольный массив
int[,] rectangularArray = new int[nrow, ncolumn];
InitializeRectangularArray(rectangularArray);
startTime = Environment.TickCount;
PerformOperationOnRectangularArray(rectangularArray);
endTime = Environment.TickCount;
long rectangularTime = endTime - startTime;

// Двумерный ступенчатый массив
int[][] jaggedArray = new int[nrow][];
for (int i = 0; i < nrow; i++)
{
    jaggedArray[i] = new int[ncolumn];
}
InitializeJaggedArray(jaggedArray);
startTime = Environment.TickCount;
PerformOperationOnJaggedArray(jaggedArray);
endTime = Environment.TickCount;
long jaggedTime = endTime - startTime;

Console.WriteLine($"\nВремя выполнения операций:");
Console.WriteLine($"Одномерный массив: {oneDimensionalTime} мс");
Console.WriteLine($"Прямоугольный массив: {rectangularTime} мс");
Console.WriteLine($"Ступенчатый массив: {jaggedTime} мс");
Console.WriteLine($"Количество строк: {nrow}, Количество столбцов: {ncolumn}");


Magazine.Magazine magazine = new Magazine.Magazine("DanikNEWS", Frequency.Weekly, DateTime.Now, 1000);
Console.Write("\nВывод данных журнала: ");
Console.WriteLine(magazine.ToShortString());
Console.WriteLine("\nВывод данных со статьями:");
Console.WriteLine(magazine.ToString());
Console.WriteLine("Проверка частоты выходов: ");
Console.WriteLine("Еженедельно: " + magazine[Frequency.Weekly]);
Console.WriteLine("Ежемесячно: " + magazine[Frequency.Monthly]);
Console.WriteLine("Ежегодно: " + magazine[Frequency.Yearly]);
Console.WriteLine("\nДобавление статей: ");
Console.Write("Введите количество статей: ");
int x = Convert.ToInt32(Console.ReadLine());
Article.Article[] articlemass = new Article.Article[x];
for (int i = 0; i < articlemass.Length; i++)
{
    Console.WriteLine("Статья " + (i + 1));
    articlemass[i] = new Article.Article();
    Console.Write("Введите название: ");
    articlemass[i].NameTitle = Console.ReadLine();
    Console.Write("Введите оценку: ");
    articlemass[i].Mark = Convert.ToDouble(Console.ReadLine());

}
magazine.AddArticles(articlemass);
Console.WriteLine("Вывод информации журнала: ");
Console.WriteLine(magazine.ToString());

// Инициализация массива (исправленная инициализация для ступенчатого массива)
static void InitializeOneDimensionalArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = i;
    }
}

// Инициализация двумерного прямоугольного массива
static void InitializeRectangularArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = i * arr.GetLength(1) + j;
        }
    }
}

// Инициализация двумерного ступенчатого массива
static void InitializeJaggedArray(int[][] arr)
{
    int k = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = 0; j < arr[i].Length; j++)
        {
            arr[i][j] = k++;
        }
    }
}

// Выполнение операции с элементами массива
static void PerformOperationOnOneDimensionalArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] += 1;
    }
}


// Выполнение операции с двумерным прямоугольным массивом
static void PerformOperationOnRectangularArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] += 1;
        }
    }
}

// Выполнение операции с двумерным ступенчатым массивом
static void PerformOperationOnJaggedArray(int[][] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = 0; j < arr[i].Length; j++)
        {
            arr[i][j] += 1;
        }
    }
}

public enum Frequency
{
    Weekly,
    Monthly,
    Yearly
};