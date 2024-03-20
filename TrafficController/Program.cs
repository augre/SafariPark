using TrafficController;

var leftLane = new Lane { Direction = Direction.Left };
var rightLane = new Lane { Direction = Direction.Right };
var lanes = new List<Lane?> { leftLane, rightLane };

var random = new Random();
var positions = (ControllerPosition[]) Enum.GetValues(typeof(ControllerPosition));
var controller = new TrafficController.TrafficController { Position = positions[random.Next(positions.Length)] };


var intersection = new Intersection(controller, random);
foreach (var lane in lanes)
{
	intersection.AddLane(lane);
}

for (var i = 0; i < 20; i++)
{
	Direction[] directions = [Direction.Straight, Direction.Right, Direction.Left];

	var lane = lanes[random.Next(lanes.Count)];
	var direction = directions[random.Next(directions.Length)];
	controller.Position = positions[random.Next(positions.Length)];
	if (lane != null)
	{
		var car = new Car {WhichLane = lane.Direction, Direction = direction};
		controller.OnCarArrived(car);
	}
}


