using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDomainENT.Entities;
using TestRepositoryDAL.DAL.Interfaces;
using TestServiceBLL.BLL.Interfaces;

namespace TestServiceBLL.BLL.Implementation
{
    public class UserBLL : IUserBLL
    {
        private IUserDAL _userDAL;
        public UserBLL(IUserDAL userDAL) 
        {
            _userDAL = userDAL;            
        }
        public async Task Login(UserLogin viewModel)
        {
            await _userDAL.Login(viewModel);
        }

        public async Task Logout()
        {
            await _userDAL.Logout();
        }

        public async Task Register(UserRegister viewModel)
        {
            await _userDAL.Register(viewModel);
        }
    }
}
