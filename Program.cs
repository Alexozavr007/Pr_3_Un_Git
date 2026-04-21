Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;
bool e = true;
Console.WriteLine("Введіть масив для обробки");
var arr = ReadJaggedRandom();
while (e)
{
    Console.WriteLine("Введіть блок для виконання завдання ( 1, 2, 3 або 4 )");
    var num = Console.ReadLine();
    switch (num)
    {
        case "1":
            Block_2_Max(ref arr);
            break;
        case "2":
            Block_2_Alex(ref arr);
            break;
        case "3":
            Block_2_Illia(ref arr);
            break;
        default:
            Console.WriteLine("Ви ввели щось не зрозуміле (((");
            break;
    }
    Console.WriteLine("Чи продовжувати далі змінювати масив? (true or false)");
    e = bool.Parse(Console.ReadLine());
}
//common mathods
static int[][] ReadJaggedRandom()
{
    Random rnd = new Random();
    Console.Write("Введіть кількість рядків: ");
    int rows = int.Parse(Console.ReadLine());
    int[][] jagged = new int[rows][];

    for (int i = 0; i < rows; i++)
    {
        int cols = rnd.Next(1, 11);
        jagged[i] = new int[cols];

        for (int j = 0; j < cols; j++)
        {
            jagged[i][j] = rnd.Next(0, 51);
        }
    }
    return jagged;
}
static void PrintJaggedArray(int[][] arr) {
    for (int i = 0; i < arr.Length; i++) {
        Console.Write($"Рядок {i + 1}: ");
        Console.WriteLine(string.Join(", ", arr[i]));
    }
}

static void Block_2_Alex(ref int[][] arr) {
    if (arr == null || arr.Length == 0) {
        Console.WriteLine("Масив порожній.");
        return;
    }

    Console.WriteLine("Початковий зубчастий масив:");
    PrintJaggedArray(arr);

    RemoveEvenRows(ref arr);

    Console.WriteLine("Масив після видалення парних рядків (0, 2, 4...):");
    PrintJaggedArray(arr);
}
static void Block_2_Max(ref int[][] arr)
{
    PrintJaggedArray(arr);
    z8(ref arr);
    PrintJaggedArray(arr);
}
static void Block_2_Illia(ref int[][] arr)
{
    if (newArr == null || newArr.Length == 0)
    {
        Console.WriteLine("Масив порожній.");
        return;
    }
    Console.WriteLine("Початковий масив:");
    PrintJaggedArray(arr);

    DeleteEvenRows(ref arr);

    Console.WriteLine("Змінений масив(знищено парні рядки):");
    PrintJaggedArray(arr);
}

//Alex methods
static void RemoveEvenRows(ref int[][] arr) {
    int n = arr.Length;

    int newCount = n / 2;

    if (newCount == 0) {
        Console.WriteLine("[Результат]: Усі рядки видалено.");
        return;
    }

    for (int i = 0; i < newCount; i++) {
        arr[i] = arr[i * 2 + 1];
    }

    Array.Resize(ref arr, newCount);
    var a = arr.Length;
    Console.WriteLine($"[Успіх]: Видалено парні рядки. Нова кількість рядків: {newCount}");
}

//Max methods
static void z8(ref int[][] arr)
{
    int maxcol = 0;
    int maxrow = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = 0; j < arr[i].Length; j++)
        {
            if (arr[i][j] > arr[maxrow][maxcol])
            {
                maxrow = i;
                maxcol = j;
            }
        }
    }
    DeleteRow(ref arr, maxrow);
}
static void DeleteRow(ref int[][] jagged, int k)
{
    if (jagged == null || k < 0 || k >= jagged.Length)
    {
        Console.WriteLine("Помилка: такого рядка не існує. Масив не змінено.");
        return;
    }

    int[][] newJagged = new int[jagged.Length - 1][];

    for (int i = 0; i < k; i++)
    {
        newJagged[i] = jagged[i];
    }

    for (int i = k + 1; i < jagged.Length; i++)
    {
        newJagged[i - 1] = jagged[i];
    }

    jagged = newJagged;
}
//Illia methods
static int[][] DeleteEvenRows(ref int[][] initialData)
{
    int index = 0;
    int[][] newArr = new int[initialData.Length / 2][];
    for (int i = 0; i < initialData.Length; i++)
    {
        if (i % 2 == 0)
        {
            newArr[index] = new int[initialData[i].Length];
        }
        for (int j = 0; j < initialData[i].Length; j++)
        {
            if (i % 2 == 0)
            {
                newArr[index][j] = initialData[i][j];
            }
        }
        if (i % 2 == 0) index++;
    }
    return newArr;
}

