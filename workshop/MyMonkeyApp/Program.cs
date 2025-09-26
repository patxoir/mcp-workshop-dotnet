using MyMonkeyApp;

Console.Clear();
DisplayWelcomeBanner();

while (true)
{
    DisplayMenu();
    
    var choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            ListAllMonkeys();
            break;
        case "2":
            GetMonkeyByName();
            break;
        case "3":
            GetRandomMonkey();
            break;
        case "4":
            Console.WriteLine("🐒 Thanks for visiting the Monkey App! Goodbye! 🐒");
            return;
        default:
            Console.WriteLine("❌ Invalid choice. Please select 1-4.");
            break;
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}

static void DisplayWelcomeBanner()
{
    var asciiArt = GetRandomAsciiArt();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(asciiArt);
    Console.ResetColor();
    
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("🐒 Welcome to the Monkey Console Application! 🐒");
    Console.ResetColor();
    Console.WriteLine();
}

static void DisplayMenu()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Please select an option:");
    Console.WriteLine("1. List all monkeys");
    Console.WriteLine("2. Get details for a specific monkey by name");
    Console.WriteLine("3. Get a random monkey");
    Console.WriteLine("4. Exit app");
    Console.ResetColor();
    Console.Write("\nYour choice: ");
}

static void ListAllMonkeys()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("🐒 All Available Monkeys 🐒");
    Console.ResetColor();
    Console.WriteLine(new string('=', 50));
    
    var monkeys = MonkeyHelper.GetMonkeys();
    
    foreach (var monkey in monkeys)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"• {monkey.Name}");
        Console.ResetColor();
        Console.WriteLine($"  Location: {monkey.Location}");
        Console.WriteLine($"  Population: {monkey.Population:N0}");
        Console.WriteLine();
    }
    
    Console.WriteLine($"Total monkeys: {monkeys.Count}");
}

static void GetMonkeyByName()
{
    Console.Write("Enter monkey name: ");
    var name = Console.ReadLine();
    
    var monkey = MonkeyHelper.GetMonkeyByName(name ?? "");
    
    if (monkey != null)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"🐒 {monkey.Name} Details 🐒");
        Console.ResetColor();
        Console.WriteLine(new string('=', 30));
        Console.WriteLine($"Name: {monkey.Name}");
        Console.WriteLine($"Location: {monkey.Location}");
        Console.WriteLine($"Population: {monkey.Population:N0}");
        Console.WriteLine($"Coordinates: ({monkey.Latitude:F2}, {monkey.Longitude:F2})");
        Console.WriteLine($"Details: {monkey.Details}");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"❌ No monkey found with name: {name}");
        Console.ResetColor();
    }
}

static void GetRandomMonkey()
{
    var monkey = MonkeyHelper.GetRandomMonkey();
    var accessCount = MonkeyHelper.GetRandomMonkeyAccessCount();
    
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("🎲 Random Monkey Selection 🎲");
    Console.ResetColor();
    Console.WriteLine(new string('=', 35));
    
    // Display random ASCII art
    var randomArt = GetRandomAsciiArt();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(randomArt);
    Console.ResetColor();
    
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Selected: {monkey.Name}");
    Console.ResetColor();
    Console.WriteLine($"Location: {monkey.Location}");
    Console.WriteLine($"Population: {monkey.Population:N0}");
    Console.WriteLine($"Details: {monkey.Details}");
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"🔢 Random selections made: {accessCount}");
    Console.ResetColor();
}

static string GetRandomAsciiArt()
{
    var asciiArts = new[]
    {
        @"
           __
        .-'  |
       /     |
       |  -  |    🐵
       |     |
        \___/
        ",
        
        @"
           .-""-.
          /      \
         |  o   o  |   🐒
         |    ^    |
          \  ___  /
           '-----'
        ",
        
        @"
            ___
           (o o)     🙈
          (  V  )
         --m-m--
        ",
        
        @"
          ___
         ( . .)     🙉
        o_)   )
         (___/
        ",
        
        @"
           .--.
          (    )    🙊
           '--'
          /    \
         /      \
        ",
        
        @"
           (\   /)
          ( ._. )   🐵
         o_)   (_o
        "
    };

    var random = new Random();
    return asciiArts[random.Next(asciiArts.Length)];
}
