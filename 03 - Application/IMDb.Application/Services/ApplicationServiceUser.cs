using Domain.Entities;
using IMDb.Application.Interfaces;
using IMDb.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDb.Application.Services
{
    public class ApplicationServiceUser : IApplicationServiceUser
    {
        private readonly IServiceUser serviceUser;

        public ApplicationServiceUser(IServiceUser serviceuser)
        {
            this.serviceUser = serviceuser;
        }

        public void Add(User user)
        {
            serviceUser.Add(user);
        }

        public void Update(User user)
        {
            serviceUser.Update(user);
        }

        public void Remove(User user)
        {
            serviceUser.Delete(user.Id);
        }

        public IEnumerable<User> GetAll()
        {
            return serviceUser.GetAll();
        }

        public User GetById(int id)
        {
            return serviceUser.GetById(id);
        }
    }
}

