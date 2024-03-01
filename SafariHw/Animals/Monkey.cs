using SafariHw.LivingHabitats;

namespace SafariHw.Animals;

internal class Monkey(string name, LivingHabitat livingHabitat, int age) : Mammal(name, livingHabitat, age)
{
	public void ClimbTree()
	{
		Console.WriteLine($"Monkey {name} is climbing tree.");
	}
}