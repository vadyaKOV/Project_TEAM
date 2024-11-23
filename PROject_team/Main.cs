using Person;
using A=Article;
using Magazine;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

Console.WriteLine("Введите количество строк и столбцов через пробел, запятую или точку с запятой:");
string input = Console.ReadLine();
string[] dimensions = input.Split(new char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

int nrow = int.Parse(dimensions[0]);
int ncolumn = int.Parse(dimensions[1]);
int totalElements = nrow * ncolumn;

A.Article[] oneDimensionalArray = new A.Article[totalElements];
InitializeOneDimensionalArray(oneDimensionalArray);
long startTime = Environment.TickCount;
PerformOperationOnOneDimensionalArray(oneDimensionalArray);
long endTime = Environment.TickCount;
long oneDimensionalTime = endTime - startTime;

// Двумерный прямоугольный массив
A.Article[,] rectangularArray = new A.Article[nrow, ncolumn];
InitializeRectangularArray(rectangularArray);
startTime = Environment.TickCount;
PerformOperationOnRectangularArray(rectangularArray);
endTime = Environment.TickCount;
long rectangularTime = endTime - startTime;

// Двумерный ступенчатый массив
A.Article[][] jaggedArray = new A.Article[nrow][];
for (int i = 0; i < nrow; i++)
{
    jaggedArray[i] = new A.Article[ncolumn];
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
magazine.AddArticles();
magazine.AddArticles(articlemass[0],new Article.Article());
Console.WriteLine("Вывод информации журнала: ");
Console.WriteLine(magazine.ToString());

// Инициализация массива (исправленная инициализация для ступенчатого массива)
static void InitializeOneDimensionalArray(A.Article[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = new A.Article();
    }
}

// Инициализация двумерного прямоугольного массива
static void InitializeRectangularArray(A.Article[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = new A.Article();
        }
    }
}

// Инициализация двумерного ступенчатого массива
static void InitializeJaggedArray(A.Article[][] arr)
{
    int k = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = 0; j < arr[i].Length; j++)
        {
            arr[i][j] = new A.Article();
        }
    }
}

// Инициализация двумерного ступенчатого массива
//static void InitializeJaggedArray(Article.Article[][] arr)
//{
//    int k = 0;
//    for (int i = 0; i < arr.Length; i++)
//    {
//        for (int j = 0; j < arr[i].Length; j++)
//        {
//            arr[i][j].Mark = 6;
//        }
//    }
//}

// Выполнение операции с элементами массива
static void PerformOperationOnOneDimensionalArray(A.Article[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i].Mark = 6;
    }
}


// Выполнение операции с двумерным прямоугольным массивом
static void PerformOperationOnRectangularArray(A.Article[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j].Mark = 6;
        }
    }
}

// Выполнение операции с двумерным ступенчатым массивом
static void PerformOperationOnJaggedArray(A.Article[][] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = 0; j < arr[i].Length; j++)
        {
            arr[i][j].Mark = 6;
        }
    }
}

public enum Frequency
{
    Weekly,
    Monthly,
    Yearly
};