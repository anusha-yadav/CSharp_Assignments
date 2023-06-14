using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace BuisnessLogic
{
    public class UserBL
    {
        SqlConnection conn = new SqlConnection(@"Data Source=ANUSHA\SQLEXPRESS;Initial Catalog=Anusha;Integrated Security=True");
        public DataTable loginuser(UserDA userDA)
        {
            DataTable dt = new DataTable();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tb1 where UserName = '" + userDA.username + "' and password='" + userDA.password + "'", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }
    }
}
