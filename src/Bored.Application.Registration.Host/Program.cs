using Bored.Application.Registration.AppServices.Contracts.Activities.Kafka.Handlers;
using Bored.Application.Registration.AppServices.Contracts.Users.Kafka.Handlers;
using Bored.Application.Registration.AppServices.Contracts.Users.Kafka.Producers;
using Bored.Application.Registration.AppServices.Extensions;
using Bored.Application.Registration.Client.Kafka;
using Bored.Application.Registration.Client.Kafka.Events.Incoming;
using Bored.Application.Registration.Client.Kafka.Events.Outgoing;
using Bored.Application.Registration.DataAccess.Extensions;
using Bored.Application.Registration.Host;
using Bored.Application.Registration.Host.Kafka.Handlers;
using Bored.Application.Registration.Host.Users.Kafka.Handlers;
using Bored.Application.Registration.Host.Users.Kafka.Producers;
using DCS.Platform.Kafka.Abstractions.Helpers;
using KafkaFlow;
using KafkaFlow.Serializer;
using KafkaFlow.TypedHandler;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddHandlers();
builder.Services.AddValidators();

builder.Services.Configure<KafkaOptions>(builder.Configuration.GetSection("Kafka"));
var kafkaOptions = builder.Configuration.GetSection("Kafka").Get<KafkaOptions>();
builder.Services.AddKafka(kafka => kafka
    .UseMicrosoftLog()
    .AddCluster(cluster => cluster
        .WithBrokers(kafkaOptions.Servers)
        .AddProducer<RegisterUserEventResultProducer>(builder => builder
            .AddMiddlewares(middlewares => middlewares.AddSerializer<JsonCoreSerializer>())
            .DefaultTopic(KafkaHelpers.GetTopic(typeof(RegisterUserEventResult)))
        )
        .AddProducer<AddPartnerEventProducer>(builder => builder
            .AddMiddlewares(middlewares => middlewares.AddSerializer<JsonCoreSerializer>())
            .DefaultTopic(KafkaHelpers.GetTopic(typeof(AddPartnerEvent)))
        )
        .AddProducer<RequestPartnerEventResultProducer>(builder => builder
            .AddMiddlewares(middlewares => middlewares.AddSerializer<JsonCoreSerializer>())
            .DefaultTopic(KafkaHelpers.GetTopic(typeof(RequestPartnerEventResult)))
        )
        .AddConsumer(consumer => consumer
            .Topic(KafkaHelpers.GetTopic(typeof(RegisterUserEvent)))
            .WithGroupId(kafkaOptions.ConsumerGroup)
            .WithBufferSize(100)
            .WithWorkersCount(10)
            .AddMiddlewares(middlewares => middlewares
                .AddSerializer<JsonCoreSerializer>()
                .AddTypedHandlers(handlers => handlers
                    .WithHandlerLifetime(InstanceLifetime.Scoped)
                    .AddHandler<RegisterUserEventHandler>()
                    .WhenNoHandlerFound(context =>
                        Console.WriteLine("Message not handled > Partition: {0} | Offset: {1}",
                            context.ConsumerContext.Partition,
                            context.ConsumerContext.Offset)
                    )
                )
            )
        )
        .AddConsumer(consumer => consumer
            .Topic(KafkaHelpers.GetTopic(typeof(AcceptActivityEvent)))
            .WithGroupId(kafkaOptions.ConsumerGroup)
            .WithBufferSize(100)
            .WithWorkersCount(10)
            .AddMiddlewares(middlewares => middlewares
                .AddSerializer<JsonCoreSerializer>()
                .AddTypedHandlers(handlers => handlers
                    .WithHandlerLifetime(InstanceLifetime.Scoped)
                    .AddHandler<AcceptActivityEventHandler>()
                    .WhenNoHandlerFound(context =>
                        Console.WriteLine("Message not handled > Partition: {0} | Offset: {1}",
                            context.ConsumerContext.Partition,
                            context.ConsumerContext.Offset)
                    )
                )
            )
        )
        .AddConsumer(consumer => consumer
            .Topic(KafkaHelpers.GetTopic(typeof(AddPartnerEventResult)))
            .WithGroupId(kafkaOptions.ConsumerGroup)
            .WithBufferSize(100)
            .WithWorkersCount(10)
            .AddMiddlewares(middlewares => middlewares
                .AddSerializer<JsonCoreSerializer>()
                .AddTypedHandlers(handlers => handlers
                    .WithHandlerLifetime(InstanceLifetime.Scoped)
                    .AddHandler<AddPartnerEventResultHandler>()
                    .WhenNoHandlerFound(context =>
                        Console.WriteLine("Message not handled > Partition: {0} | Offset: {1}",
                            context.ConsumerContext.Partition,
                            context.ConsumerContext.Offset)
                    )
                )
            )
        )
        .AddConsumer(consumer => consumer
            .Topic(KafkaHelpers.GetTopic(typeof(RequestPartnerEvent)))
            .WithGroupId(kafkaOptions.ConsumerGroup)
            .WithBufferSize(100)
            .WithWorkersCount(10)
            .AddMiddlewares(middlewares => middlewares
                .AddSerializer<JsonCoreSerializer>()
                .AddTypedHandlers(handlers => handlers
                    .WithHandlerLifetime(InstanceLifetime.Scoped)
                    .AddHandler<RequestPartnerEventHandler>()
                    .WhenNoHandlerFound(context =>
                        Console.WriteLine("Message not handled > Partition: {0} | Offset: {1}",
                            context.ConsumerContext.Partition,
                            context.ConsumerContext.Offset)
                    )
                )
            )
        )
    )
);
builder.Services.AddHealthChecks();
builder.Services.AddScoped<IRegisterUserEventHandler, RegisterUserEventHandler>();
builder.Services.AddScoped<IRegisterUserEventResultProducer, RegisterUserEventResultProducer>();
builder.Services.AddScoped<IRequestPartnerEventResultProducer, RequestPartnerEventResultProducer>();
builder.Services.AddScoped<IAddPartnerEventProducer, AddPartnerEventProducer>();

builder.Services.AddScoped<IAcceptActivityEventHandler, AcceptActivityEventHandler>();
builder.Services.AddScoped<IAddPartnerEventResultHandler, AddPartnerEventResultHandler>();
builder.Services.AddScoped<IRequestPartnerEventHandler, RequestPartnerEventHandler>();


var app = builder.Build();
var lifetime = app.Services.CreateKafkaBus();
await lifetime.StartAsync();

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health");
    app.MapGet("/", async context => { await context.Response.WriteAsync("hi"); });
});



app.Run();
