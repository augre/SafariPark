using SafariHw.Animals;
using SafariHw.LivingHabitats;

namespace SafariHw.SafariPark;

internal class SafariPark
{
	private Animal[] animals = Array.Empty<Animal>();
	private SafariParkSection[] safariParkSections = Array.Empty<SafariParkSection>();

	public void AddAnimal(Animal animal)
	{
		Array.Resize(ref animals, animals.Length + 1);
		if (animals.Length >= 1) animals[^1] = animal;
	}

	public void AddSafariParkSection(SafariParkSection section)
	{
		Array.Resize(ref safariParkSections, safariParkSections.Length + 1);
		safariParkSections[^1] = section;
	}

	public void MoveAnimalsToSections()
	{
		foreach (var animal in animals)
			switch (animal.LivingHabitat)
			{
				case LivingHabitat.Tree:
					safariParkSections.First(x => x.LivingHabitats.Contains(LivingHabitat.Tree)).AddAnimal(animal);
					break;
				case LivingHabitat.Water:
					safariParkSections.First(x => x.LivingHabitats.Contains(LivingHabitat.Water))
						.AddAnimal(animal);
					break;
				case LivingHabitat.Garden:
					safariParkSections.First(x => x.LivingHabitats.Contains(LivingHabitat.Garden))
						.AddAnimal(animal);
					break;
				case LivingHabitat.Terrarium:
					safariParkSections.First(x => x.LivingHabitats.Contains(LivingHabitat.Terrarium))
						.AddAnimal(animal);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
	}

	public List<(SafariParkSection section, int count)> CountAnimalsInSections()
	{
		return safariParkSections.Select(safariParkSection => (safariParkSection, safariParkSection.Count))
			.ToList();
	}
}