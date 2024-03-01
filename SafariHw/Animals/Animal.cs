using SafariHw.LivingHabitats;

namespace SafariHw.Animals;

internal class Animal(string name, LivingHabitat livingHabitat, int age)
{
	public string Name { get; set; } = name ?? throw new ArgumentNullException(nameof(name));
	public LivingHabitat LivingHabitat { get; set; } = livingHabitat;
	public int Age { get; set; } = age;

	public virtual void Eat()
	{
		Console.WriteLine("The animal is eating");
	}

	public virtual void Sleep()
	{
		Console.WriteLine("The animal is sleeping");
	}
}