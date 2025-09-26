namespace MyMonkeyApp;

public static class MonkeyHelper
{
    private static readonly List<Monkey> _monkeys = new()
    {
        new Monkey
        {
            Name = "Baboon",
            Location = "Africa & Asia",
            Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
            Population = 10000,
            Latitude = -8.783195,
            Longitude = 34.508523,
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg"
        },
        new Monkey
        {
            Name = "Capuchin Monkey",
            Location = "Central & South America",
            Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.",
            Population = 23000,
            Latitude = 10.895887,
            Longitude = -63.154220,
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg"
        },
        new Monkey
        {
            Name = "Blue Monkey",
            Location = "Central and East Africa",
            Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia",
            Population = 200000,
            Latitude = -7.264089,
            Longitude = 17.921143,
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/bluemonkey.jpg"
        },
        new Monkey
        {
            Name = "Squirrel Monkey",
            Location = "Central & South America",
            Details = "The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae.",
            Population = 500000,
            Latitude = -2.0581,
            Longitude = -59.6289,
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/squirrelmonkey.jpg"
        },
        new Monkey
        {
            Name = "Golden Lion Tamarin",
            Location = "Brazil",
            Details = "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.",
            Population = 3000,
            Latitude = -22.9068,
            Longitude = -43.1729,
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/goldenlion.jpg"
        },
        new Monkey
        {
            Name = "Howler Monkey",
            Location = "South America",
            Details = "Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae.",
            Population = 15000,
            Latitude = -9.6497,
            Longitude = -63.5806,
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/howler.jpg"
        },
        new Monkey
        {
            Name = "Japanese Macaque",
            Location = "Japan",
            Details = "The Japanese macaque, is a terrestrial Old World monkey species native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each year",
            Population = 25000,
            Latitude = 38.5816,
            Longitude = 138.3416,
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/japanesemacaque.jpg"
        },
        new Monkey
        {
            Name = "Mandrill",
            Location = "Southern Cameroon, Equatorial Guinea, Gabon, Republic of the Congo",
            Details = "The mandrill is a primate of the Old World monkey family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Equatorial Guinea, Gabon, and the Republic of the Congo.",
            Population = 7000,
            Latitude = -0.7893,
            Longitude = 11.6346,
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/mandrill.jpg"
        },
        new Monkey
        {
            Name = "Proboscis Monkey",
            Location = "Borneo",
            Details = "The proboscis monkey or long-nosed monkey, known as the bekantan in Malay, is a reddish-brown arboreal Old World monkey that is endemic to the southeast Asian island of Borneo.",
            Population = 1000,
            Latitude = 1.88,
            Longitude = 114.5,
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/proboscismonkey.jpg"
        }
    };

    private static int _randomMonkeyAccessCount = 0;

    public static List<Monkey> GetMonkeys()
    {
        return _monkeys.ToList(); // Return a copy to prevent external modification
    }

    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return _monkeys.FirstOrDefault(m => 
            string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    public static Monkey GetRandomMonkey()
    {
        var random = new Random();
        _randomMonkeyAccessCount++;
        return _monkeys[random.Next(_monkeys.Count)];
    }

    public static int GetRandomMonkeyAccessCount()
    {
        return _randomMonkeyAccessCount;
    }
}