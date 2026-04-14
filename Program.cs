
bool e = true;
Console.WriteLine("Введыть масив для обробки");
var arr = ReadJaggedRandom();
while (e)
{
    Console.WriteLine("Введіть блок для виконання завдання ( 1 або 2 )");
    var num = Console.ReadLine();
    switch (num)
    {
        case "1":
            Block2(ref arr);
            break;
        case "2":
            Block_2(ref arr);
            break;
        default:
            Console.WriteLine("Ви ввели щось не зрозуміле (((");
            break;
    }
    Console.WriteLine("чи продовжувати далі змінювати масив? (true or false)");
    e = bool.Parse(Console.ReadLine());
}

static void Block_2(ref int[][] arr) {
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
    if (arr.Length == 0) { Console.WriteLine("Масив порожній."); return; }
    for (int i = 0; i < arr.Length; i++) {
        Console.Write($"Рядок {i}: ");
        Console.WriteLine(string.Join(", ", arr[i]));
    }
}
static void PrintJagged(int[][] jagged)
{
    for (int i = 0; i < jagged.Length; i++)
    {
        Console.WriteLine($"Рядок {i + 1}: " + string.Join(" ", jagged[i]));
    }
}
static void Block2(ref int[][] arr)
{
    PrintJagged(arr);
    z8(ref arr);
    PrintJagged(arr);
}
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