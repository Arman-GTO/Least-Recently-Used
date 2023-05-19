using Least_Recently_Used;

#region variables
string? inp;
LRUCache? LRU;
#endregion

while (true)
{
    LRU = null;
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("  P{lease enter instructions: (init, get, put)\n       (enter nothing to exit)\n\n");
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("  ");
        inp = Console.ReadLine() + "";
        if (inp == "") break;
        try
        {
            var arr = inp.Split(' ');
            switch (arr[0])
            {
                case "init":
                    if (LRU != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("  LRU already initiated!\n");
                        break;
                    }
                    LRU = new(Convert.ToInt32(arr[1]));
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("  OK\n");
                    Console.Write("  {");
                    foreach (var item in LRU.WriteAll()) Console.Write($"({item.Key},{item.Value.value}),");
                    if (LRU.WriteAll().Count != 0)
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write("}\n");
                    break;
                case "put":
                    if (LRU == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("  LRU is not initiated!\n");
                        break;
                    }
                    LRU.Put(Convert.ToInt32(arr[1]), Convert.ToInt32(arr[2]));
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("  null\n");
                    Console.Write("  {");
                    foreach (var item in LRU.WriteAll()) Console.Write($"({item.Key},{item.Value.value}),");
                    if (LRU.WriteAll().Count != 0)
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write("}\n");
                    break;
                case "get":
                    if (LRU == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("  LRU is not initiated!\n");
                        break;
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("  " + LRU.Get(Convert.ToInt32(arr[1])) + "\n");
                    Console.Write("  {");
                    foreach (var item in LRU.WriteAll()) Console.Write($"({item.Key},{item.Value.value}),");
                    if (LRU.WriteAll().Count != 0)
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write("}\n");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("  Invalid instruction!\n");
                    break;
            } // Check which function to call
        }
        catch { } // Check for any possible error
    } // Take inputs until exited by user
    Console.CursorVisible = false;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("\n  R: restart   |   ESC: exit\n\n");
What_To_Do:
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.R:
            break;
        case ConsoleKey.Escape:
            Console.ResetColor();
            return;
        default:
            goto What_To_Do;
    } // Check if restart or exit the app
}