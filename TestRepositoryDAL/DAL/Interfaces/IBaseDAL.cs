using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepositoryDAL.DAL.Interfaces
{
    public interface IBaseDAL<T>
    {
        T Get(Guid id);
        List<T> GetAll();
        int Create(T entity);
        int Update(T entity);
        int Delete(Guid id);
    }
}
