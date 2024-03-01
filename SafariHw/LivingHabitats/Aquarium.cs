using SafariHw.SafariPark;

namespace SafariHw.LivingHabitats;

internal class Aquarium(LivingHabitat[] livingHabitats) : SafariParkSection(livingHabitats)
{
	public override void CleanSection()
	{
		Console.WriteLine("Cleaning the aquarium");
	}

	public override void FeedAnimals()
	{
		Console.WriteLine("Feeding the fish");
	}

	public override void GetMaintenance()
	{
		Console.WriteLine("Getting the aquarium maintenance");
	}
}