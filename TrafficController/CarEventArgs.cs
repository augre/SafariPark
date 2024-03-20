namespace TrafficController;

public class CarEventArgs(Car car) : EventArgs
{
	public Car Car { get; } = car;
}