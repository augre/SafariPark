using SafariHw.LivingHabitats;

namespace SafariHw.Animals;

internal class Fish(string name, LivingHabitat livingHabitat, int age) : Animal(name, livingHabitat, age)
{
	public override void Eat()
	{
		Console.WriteLine("The fish is eating");
	}

	public override void Sleep()
	{
		Console.WriteLine("The fish is sleeping");
	}

	public virtual void Swim()
	{
		Console.WriteLine("The fish is swimming");
	}
}