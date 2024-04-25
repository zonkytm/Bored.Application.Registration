namespace Bored.Application.Registration.Client.Kafka;

public class KafkaOptions
{
    public string[] Servers { get; init; } = Array.Empty<string>();
    public string? ConsumerGroup { get; init; }
}