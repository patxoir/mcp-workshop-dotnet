
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

class Program
{
	private static readonly List<string> asciiArts = new()
	{
		"  (o o)\n (  .  )\n  (   )\n   \"\"\"",
		"   w  c( .. )o   (\n    \\__(- )    ,)\n        /    _/ \n       (   (",
		"   (o o)\n  (  .  )\n   (   )\n    \"\"\"",
		"   (o o)\n  (  .  )\n   (   )\n    \"\"\""
	};

	static async Task Main(string[] args)
	{
		// MCP 서버에서 데이터 로드 예시 (여기서는 더미 데이터)
		await MonkeyHelper.LoadMonkeysAsync(async () =>
		{
			// 실제 MCP 연동 시, API 호출로 대체
			await Task.Delay(100); // 시뮬레이션
			return new List<Monkey>
			{
				new Monkey { Name = "Baboon", Location = "Africa & Asia", Population = 10000, Details = "Baboons are African and Arabian Old World monkeys.", Image = "", Latitude = -8.78, Longitude = 34.50 },
				new Monkey { Name = "Capuchin Monkey", Location = "Central & South America", Population = 23000, Details = "The capuchin monkeys are New World monkeys.", Image = "", Latitude = 12.76, Longitude = -85.60 },
				new Monkey { Name = "Blue Monkey", Location = "Central and East Africa", Population = 12000, Details = "The blue monkey is a species of Old World monkey.", Image = "", Latitude = 1.95, Longitude = 37.29 }
			};
		});

		var random = new Random();
		while (true)
		{
			Console.Clear();
			// 랜덤 ASCII 아트 출력
			Console.WriteLine(asciiArts[random.Next(asciiArts.Count)]);
			Console.WriteLine("==== Monkey App ====");
			Console.WriteLine("1. List all monkeys");
			Console.WriteLine("2. Get details for a specific monkey by name");
			Console.WriteLine("3. Get a random monkey");
			Console.WriteLine("4. Exit app");
			Console.Write("Select an option: ");
			var input = Console.ReadLine();
			Console.WriteLine();

			switch (input)
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
					Console.WriteLine("Bye!");
					return;
				default:
					Console.WriteLine("Invalid option.");
					break;
			}
			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey();
		}
	}

	static void ListAllMonkeys()
	{
		var monkeys = MonkeyHelper.GetMonkeys();
		Console.WriteLine("Name                Location                Population");
		Console.WriteLine("------------------------------------------------------");
		foreach (var m in monkeys)
		{
			Console.WriteLine($"{m.Name,-20} {m.Location,-22} {m.Population,10}");
		}
	}

	static void GetMonkeyByName()
	{
		Console.Write("Enter monkey name: ");
		var name = Console.ReadLine();
		var monkey = MonkeyHelper.GetMonkeyByName(name ?? "");
		if (monkey == null)
		{
			Console.WriteLine("Monkey not found.");
			return;
		}
		Console.WriteLine($"Name: {monkey.Name}");
		Console.WriteLine($"Location: {monkey.Location}");
		Console.WriteLine($"Population: {monkey.Population}");
		Console.WriteLine($"Details: {monkey.Details}");
	}

	static void GetRandomMonkey()
	{
		var monkey = MonkeyHelper.GetRandomMonkey();
		if (monkey == null)
		{
			Console.WriteLine("No monkeys available.");
			return;
		}
		Console.WriteLine($"Random Monkey: {monkey.Name}");
		Console.WriteLine($"Location: {monkey.Location}");
		Console.WriteLine($"Population: {monkey.Population}");
		Console.WriteLine($"Details: {monkey.Details}");
		Console.WriteLine($"Random pick count: {MonkeyHelper.GetRandomPickCount()}");
	}
}
