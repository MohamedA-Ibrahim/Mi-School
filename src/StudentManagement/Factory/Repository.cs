using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace MiSchool.Factory
{
    public class Repository<T> : Database, IRepository<T> where T : class
    {
        private IDbConnection con = new SqlConnection(conVal("School1"));

        public void Execute(string sqlstr)
        {
            con.Execute(sqlstr);
        }

        public void ExecuteParam(string sqlstr, object Param)
        {
            con.Execute(sqlstr, Param);
        }

        public IEnumerable<T> GetAll(string sqlstr)
        {
            return con.Query<T>(sqlstr);
        }

        public IEnumerable<T> GetById(string sqlstr, object Param)
        {
            return con.Query<T>(sqlstr, Param);
        }
    }
}
