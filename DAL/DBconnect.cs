using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
namespace DAL
{
    public class DBconnect
    {
        protected SqlConnection _conn = new SqlConnection(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=ql_nhahangWF;Integrated Security=True");


      
    }
}
