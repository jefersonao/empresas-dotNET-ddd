using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDb.Application.Interfaces
{
    public interface IApplicationServiceUser
    {
        void Add(User user);

        void Update(User user);

        void Remove(User user);

        IEnumerable<User> GetAll();

        User GetById(int id);


    }
}
