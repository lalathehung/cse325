// See https://aka.ms/new-console-template for more information
string name = "Arthur";

Console.WriteLine($"Hello, {name}!");

DateTime today = DateTime.Today;
DateTime nextChristmas = new DateTime(today.Year, 12, 25);

if (today > nextChristmas)
{
    nextChristmas = new DateTime(today.Year + 1, 12, 25);
}

int daysUntilChristmas = (nextChristmas - today).Days;

Console.WriteLine($"There are {daysUntilChristmas} days until Christmas.");
