using SafariHw.Animals;
using SafariHw.LivingHabitats;
using SafariHw.SafariPark;

var safariPark = new SafariPark();

safariPark.AddSafariParkSection(new Aquarium([LivingHabitat.Water]));
safariPark.AddSafariParkSection(new TropicalJungle([
	LivingHabitat.Garden, LivingHabitat.Terrarium, LivingHabitat.Tree
]));
safariPark.AddAnimal(new Owl("Tobi", LivingHabitat.Tree, 3));
safariPark.AddAnimal(new Owl("Al", LivingHabitat.Tree, 3));
safariPark.AddAnimal(new Monkey("Charlie", LivingHabitat.Garden, 5));
safariPark.AddAnimal(new Monkey("Churchill", LivingHabitat.Tree, 7));
safariPark.AddAnimal(new Monkey("Terra", LivingHabitat.Terrarium, 1));

safariPark.AddAnimal(new CatFish("Lajos", LivingHabitat.Water, 20));
safariPark.AddAnimal(new CatFish("Cat", LivingHabitat.Water, 3));
safariPark.AddAnimal(new LionFish("Lion", LivingHabitat.Water, 13));

safariPark.MoveAnimalsToSections();

var animalCountPerSection = safariPark.CountAnimalsInSections();
foreach (var (section, count) in animalCountPerSection) Console.WriteLine($"{section} Count: {count}");