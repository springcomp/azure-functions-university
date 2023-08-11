using Microsoft.Extensions.Logging;

internal static class AppEvents
{
	private static readonly EventId _httpTriggerProcessed
		= new EventId(1001, "http-trigger-processed");

	public static EventId HttpTriggerProcessed
		=> _httpTriggerProcessed;
}