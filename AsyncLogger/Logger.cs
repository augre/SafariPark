namespace AsyncLogger;

public class Logger(string logFilePath)
{
	public event EventHandler? BackupRequired;

	public int BackupThreshold { get; set; }
	private int _writeCount = 0;

	public async Task LogAsync(LogLevel level, string message)
	{
		var logMessage = $"{DateTime.Now}: [{level}] - {message}{Environment.NewLine}";

		await WriteLogAsync(logMessage);

		Interlocked.Increment(ref _writeCount);

		if (_writeCount >= BackupThreshold)
		{
			OnBackupRequired();
			_writeCount = 0;
		}
	}

	private async Task WriteLogAsync(string logMessage)
	{
		await using var writer = File.AppendText(logFilePath);
		await writer.WriteAsync(logMessage);
	}

	protected virtual void OnBackupRequired()
	{
		BackupRequired?.Invoke(this, EventArgs.Empty);
	}
}