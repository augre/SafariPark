namespace TrafficController;

public class Intersection
{
	private readonly List<Lane?> _lanes = new();
	private readonly TrafficController _controller;
	private readonly Random _random;

	public Intersection(TrafficController controller, Random random)
	{
		_controller = controller;
		_random = random;
		_controller.CarArrived += HandleCarArrived;
	}

	public void AddLane(Lane? lane)
	{
		_lanes.Add(lane);
	}

	private void HandleCarArrived(object sender, CarEventArgs e)
	{
		var positions = (ControllerPosition[])Enum.GetValues(typeof(ControllerPosition));
		var lane = _lanes.Find(l => l != null && l.Direction == e.Car.WhichLane);
		if (lane != null)
		{
			lane.Cars.Add(e.Car);
			Console.WriteLine($"Car arrived in lane {lane.Direction}");
			//wait until the car gets a go from the controller
			while (true)
			{
				_controller.Position = positions[_random.Next(positions.Length)];
				if (_controller.IsMovementAllowed(e.Car.Direction))
				{
					Console.WriteLine($"Car is moving in {e.Car.Direction}");
					break;
				}
				Console.WriteLine("Car is waiting");
			}
		}
		else
		{
			Console.WriteLine("No lane found for car direction");
		}
	}

}