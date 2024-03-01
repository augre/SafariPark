using SafariHw.SafariPark;

namespace SafariHw.LivingHabitats;

internal class TropicalJungle(LivingHabitat[] livingHabitats) : SafariParkSection(livingHabitats)
{
	public override void CleanSection()
	{
		Console.WriteLine("Cleaning the tropical jungle");
	}

	public override void FeedAnimals()
	{
		Console.WriteLine("Feeding the monkeys");
	}

	public override void GetMaintenance()
	{
		Console.WriteLine("Getting the tropical jungle maintenance");
	}
}