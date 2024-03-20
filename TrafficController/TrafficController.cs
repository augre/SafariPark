namespace TrafficController;

public class TrafficController
{
	public event EventHandler<CarEventArgs> CarArrived;

	public void OnCarArrived(Car car)
	{
		CarArrived?.Invoke(this, new CarEventArgs(car));
	}
	public ControllerPosition Position { get; set; }

	public bool IsMovementAllowed(Direction direction)
	{
		return Position switch
		{
			ControllerPosition.SidewaysFacingLeft => direction is Direction.Straight or Direction.Right,
			ControllerPosition.FacingRightHandHorizontal => direction == Direction.Right,
			ControllerPosition.Facing or ControllerPosition.FacingLeftHandUp or ControllerPosition.FacingRightHandUp
				or ControllerPosition.SidewaysFacingRightRightHandHorizontal => direction == Direction.Stop,
			ControllerPosition.SidewaysFacingLeftRightHandHorizontal => true,
			_ => false
		};
	}
}