Console.WriteLine("Введіть блок для виконання завдання ( 1 або 2 )");
var num = Console.ReadLine();
switch (num) {
    case "1":
        //Block_1();
        break;
    case "2":
        Block_2();
        break;
    default:
        Console.WriteLine("Ви ввели щось не зрозуміле (((");
        break;
}

static void Block_2() {
    int[][] jaggedArray = InputJaggedArray();

    if (jaggedArray == null || jaggedArray.Length == 0) {
        Console.WriteLine("Масив порожній.");
        return;
    }

    Console.WriteLine("Початковий зубчастий масив:");
    PrintJaggedArray(jaggedArray);

    RemoveEvenRows(ref jaggedArray);

    Console.WriteLine("Масив після видалення парних рядків (0, 2, 4...):");
    PrintJaggedArray(jaggedArray);
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