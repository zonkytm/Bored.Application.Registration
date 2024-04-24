using Bored.Application.Registration.Api.Contracts;
using Bored.Application.Registration.AppServices.Contracts.Ideas.Infos;

namespace Bored.Application.Registration.AppServices.Contracts.Ideas.Repositories;

public interface IIdeaRepository
{
    public Task<Idea[]> GetUserIdeasListAsync(long telegramId);

    public Task AddIdea(AddIdeaInfo ideaInfo);

    public Task<bool> DeleteUserIdea(DeleteIdeaInfo deleteIdeaInfo);
}