using Bored.Application.Registration.AppServices.Contracts.Users.Handlers;

namespace Bored.Application.Registration.Host.Kafka.Handlers;

public class AcceptIdeaEventHandler
{
    private readonly IAddUserHandler _addUserHandler;

    public AcceptIdeaEventHandler(IAddUserHandler addUserHandler)
    {
        _addUserHandler = addUserHandler;
    }
}