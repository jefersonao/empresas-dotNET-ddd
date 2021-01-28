using Domain.Entities;
using IMDb.Domain.Interfaces.Repositories;
using IMDb.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDb.Domain.Services
{
    public class ServiceUser : ServiceBase<User>, IServiceUser
    {
        private readonly IRepositoryUser repositoryUser;
        public ServiceUser(IRepositoryUser userRepository)
            : base(userRepository)
        {
            this.repositoryUser = userRepository;
        }
    }
}
