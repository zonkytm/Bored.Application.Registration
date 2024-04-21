﻿namespace Bored.Application.Registration.Host.Kafka;

public class KafkaOptions
{
    public string[] Servers { get; init; } = Array.Empty<string>();
    public string? ConsumerGroup { get; init; }
}