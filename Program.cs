Console.WriteLine("Введіть блок для виконання завдання ( 1 або 2 )");
var num = Console.ReadLine();
bool e = true;
var arr = InputJaggedArray();
while (e)
{
    switch (num)
    {
        case "1":
            Block2();
            break;
        case "2":
            Block_2(arr);
            break;
        default:
            Console.WriteLine("Ви ввели щось не зрозуміле (((");
            break;
    }
    Console.WriteLine("чи продовжувати далі змінювати масив? (true or false)");
    e = bool.Parse(Console.ReadLine());
}

static void Block_2(int[][] arr) {
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

static int[][] InputJaggedArray() {
    Console.Write("Введіть кількість рядків: ");
    var n = int.Parse(Console.ReadLine());

    int[][] arr = new int[n][];
    for (int i = 0; i < n; i++) {
        Console.Write($"Введіть кількість елементів у рядку {i}: ");
        int m = int.Parse(Console.ReadLine());
        arr[i] = new int[m];
        for (int j = 0; j < m; j++) {
            arr[i][j] = (i + 1) * (j + 1);
        }
    }
    return arr;
}

static void PrintJaggedArray(int[][] arr) {
    if (arr.Length == 0) { Console.WriteLine("Масив порожній."); return; }
    for (int i = 0; i < arr.Length; i++) {
        Console.Write($"Рядок {i}: ");
        Console.WriteLine(string.Join(", ", arr[i]));
    }
}
static int[][] ReadJaggedManual()
{
    Console.Write("Введіть кількість рядків: ");
    int rows = int.Parse(Console.ReadLine());
    int[][] jagged = new int[rows][];

    for (int i = 0; i < rows; i++)
    {
        Console.Write($"Введіть кількість елементів у рядку {i}: ");
        int cols = int.Parse(Console.ReadLine());
        jagged[i] = new int[cols];

        for (int j = 0; j < cols; j++)
        {
            Console.Write($"jagged[{i}][{j}] = ");
            jagged[i][j] = int.Parse(Console.ReadLine());
        }
    }
    return jagged;
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
static void PrintJagged(int[][] jagged)
{
    for (int i = 0; i < jagged.Length; i++)
    {
        Console.WriteLine($"Рядок {i + 1}: " + string.Join(" ", jagged[i]));
    }
}
static void Block2()
{
    int[][] arr;
    Console.WriteLine("Виберыть спосіб заповнення 1 - рандом, 2 - в ручну:");
    int a = int.Parse(Console.ReadLine());
    if (a == 1)
        arr = ReadJaggedRandom();
    else
        arr = ReadJaggedManual();
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