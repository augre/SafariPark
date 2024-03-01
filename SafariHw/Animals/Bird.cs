using SafariHw.LivingHabitats;

namespace SafariHw.Animals;

internal class Bird(string name, LivingHabitat livingHabitat, int age) : Animal(name, livingHabitat, age)
{
	public virtual void Chirp()
	{
		Console.WriteLine($"Bird {name} is chirping");
	}

	public virtual void Fly()
	{
		Console.WriteLine($"Bird {name} is flying.");
	}
}