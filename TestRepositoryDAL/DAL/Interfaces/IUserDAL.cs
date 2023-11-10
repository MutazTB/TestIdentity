using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDomainENT.Entities;

namespace TestRepositoryDAL.DAL.Interfaces
{
    public interface IUserDAL
    {
        Task Register(UserRegister viewModel);

        Task Login(UserLogin viewModel);

        Task Logout();
    }
}
