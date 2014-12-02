using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BusinessLogic
{
    public interface ILogic<T> : Logic where T : IModel
    {
        int create(T obj);
        int update(T obj);
        int delete(int id);
        T selectById(int id);
        DataTable selectAll();
    }
}
