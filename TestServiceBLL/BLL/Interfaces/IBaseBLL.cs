using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServiceBLL.BLL.Interfaces
{
    public interface IBaseBLL<T>
    {

        T Get(Guid id);
        List<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        T Delete(Guid id);
    }
}
