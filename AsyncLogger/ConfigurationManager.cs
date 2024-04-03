using Microsoft.Extensions.Configuration;

namespace AsyncLogger;

public class ConfigurationManager(
	TimeSpan checkInterval
	)
{
	private int _backupThreshold;
	private readonly CancellationTokenSource _cancellationTokenSource = new();

	public async Task StartMonitoringAsync(Logger logger)
	{

		while (!_cancellationTokenSource.Token.IsCancellationRequested)
		{
			var currentThreshold = await GetBackupThresholdAsync();
			if (currentThreshold != _backupThreshold)
			{
				_backupThreshold = currentThreshold;
				logger.BackupThreshold = _backupThreshold;
			}

			await Task.Delay(checkInterval);
		}
	}

	public void StopMonitoring()
	{
		_cancellationTokenSource?.Cancel();
	}

	private async Task<int> GetBackupThresholdAsync()
	{
		var config = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json")
			.AddEnvironmentVariables()
			.Build();
		var settings = config.GetRequiredSection("Settings").Get<Settings>();
		var n = settings?.N ?? 5;
		return n;
	}

	public sealed class Settings
	{
		public required int N { get; set; }
	}
}