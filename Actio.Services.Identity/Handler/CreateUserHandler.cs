﻿using Actio.Common.Commands;
using Actio.Common.Events;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Identity.Handler
{
    public class CreateUserHandler : ICommandHandler<CreateActivity>
    {
        private readonly IBusClient _busClient;

        public CreateUserHandler(IBusClient busClient) {
            _busClient = busClient;
        }

        public async Task HandleAsync(CreateActivity command)
        {
            Console.WriteLine($"Creating activity:{command.Name}");

            await _busClient.PublishAsync(
                new ActivityCreated(
                    command.Id, 
                    command.UserId, 
                    command.Category, 
                    command.Name, 
                    command.Description, 
                    command.CreatedAt));
        }
    }
}
