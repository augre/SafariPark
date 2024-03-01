using SafariHw.LivingHabitats;

namespace SafariHw.Animals;

internal class Owl(string name, LivingHabitat livingHabitat, int age) : Bird(name, livingHabitat, age)
{
	public override void Chirp()
	{
		Console.WriteLine("Hoot");
	}
}