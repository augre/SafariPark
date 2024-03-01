using SafariHw.Animals;
using SafariHw.LivingHabitats;

namespace SafariHw.SafariPark;

internal class SafariParkSection(LivingHabitat[] livingHabitats)
{
	private Animal[] animals = Array.Empty<Animal>();
	public int Count { get; private set; }

	public LivingHabitat[] LivingHabitats { get; } =
		livingHabitats ?? throw new ArgumentNullException(nameof(livingHabitats));

	public virtual void CleanSection()
	{
		Console.WriteLine("Cleaning");
	}

	public virtual void FeedAnimals()
	{
		Console.WriteLine("Eating");
	}

	public virtual void GetMaintenance()
	{
	}

	public void AddAnimal(Animal animal)
	{
		Array.Resize(ref animals, animals.Length + 1);
		if (animals.Length >= 1) animals[^1] = animal;
		Count = animals.Length;
	}
}