using AsyncLogger;

const string logFilePath = "log.txt";
var logger = new Logger(logFilePath);
// pass the logger into the StartMonitoringAsync so that it can update the BackupThreshold property
// when the configuration changes in the appsettings.json file
// the check interval is set to 1 second, but can be configured as needed
var configManager = new ConfigurationManager(TimeSpan.FromSeconds(1)).StartMonitoringAsync(logger);

logger.BackupRequired += (sender, e) => MakeBackup(logFilePath);

var userInputTask = ReadUserInputAsync(logger);
var periodicLoggingTask = LogPeriodicallyAsync(logger);

await Task.WhenAll(userInputTask, periodicLoggingTask);

static async Task ReadUserInputAsync(Logger logger)
{
	while (true)
	{
		Console.WriteLine("Enter 'i' for info, 'w' for warning, 'e' for error, 'q' to exit:");
		var message = Console.ReadLine();
		var input = message![0];
		Console.WriteLine();

		switch (input)
		{
			case 'i':
				await logger.LogAsync(LogLevel.Information, string.Concat(message.Skip(1)));
				break;
			case 'w':
				await logger.LogAsync(LogLevel.Warning, string.Concat(message.Skip(1)));
				break;
			case 'e':
				await logger.LogAsync(LogLevel.Error, string.Concat(message.Skip(1)));
				break;
			case 'q':
				Environment.Exit(0);
				break;
			default:
				Console.WriteLine("Invalid input.");
				break;
		}
	}
}

static async Task LogPeriodicallyAsync(Logger logger)
{
	while (true)
	{
		Task.Delay(1000).Wait();
		await logger.LogAsync(LogLevel.Information, "Periodic log message.");
	}
}

static void MakeBackup(string logFilePath)
{
	var backupFileName = $"{DateTime.Now:yyyyMMddHHmmss}_backup.txt";
	File.Copy(logFilePath, backupFileName);
	Console.WriteLine($"Backup created: {backupFileName}");
}