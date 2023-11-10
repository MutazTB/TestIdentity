using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDomainENT.Entities;
using TestRepositoryDAL.DAL.Interfaces;

namespace TestRepositoryDAL.DAL.Implementation
{
    public class ToDoListDAL : IToDoListDAL
    {
        public int Create(ToDoList entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ToDoList Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ToDoList> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Update(ToDoList entity)
        {
            throw new NotImplementedException();
        }
    }
}
