using TrafficController;

public class Lane
{
	private List<Car> _cars = new();
	public Direction Direction { get; set; }

	public List<Car> Cars
	{
		get => _cars;
		set => _cars = value;
	}

	public void AddCar(Car car)
	{
		_cars.Add(car);
	}

}