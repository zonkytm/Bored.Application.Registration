﻿using Bored.Application.Registration.AppServices.Contracts.Users.Infos;

namespace Bored.Application.Registration.AppServices.Contracts.Users.Handlers;

public interface IAddUserHandler
{
    public Task<long> Handle(AddUserInfo addUserInfo, CancellationToken cancellationToken);
}