using SafariHw.LivingHabitats;

namespace SafariHw.Animals;

internal class Mammal(string name, LivingHabitat livingHabitat, int age) : Animal(name, livingHabitat, age)
{
	public virtual void BreastFeed()
	{
		Console.WriteLine("Breastfeeding");
	}

	public virtual void GiveBirth()
	{
		Console.WriteLine("Giving birth");
	}
}