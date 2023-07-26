using System;
using System.Data;
using System.Data.SqlClient;
using BusinessModels;
using System.Configuration;

namespace DataLayer
{
    public class DALAuthentication
    {
        public int ForgotPassword(User user)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                int flag = 0;
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select username from Info_DB where Username= @username", conn);
                    cmd.Parameters.AddWithValue("@username", user.username);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();
                        SqlCommand command = new SqlCommand("UPDATE Info_DB SET Password = @newpasswd WHERE Username = @username", conn);
                        command.Parameters.AddWithValue("@newpasswd", user.new_passwd);
                        command.Parameters.AddWithValue("@username", user.username);
                        flag = command.ExecuteNonQuery();
                    }
                    reader.Close();
                    return flag;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Database disconnected "+ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public int RegisterUser(User user)
        {
            int flag = 0;
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand("Insert_User"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", user.username);
                        cmd.Parameters.AddWithValue("@Password", user.password);
                        cmd.Parameters.AddWithValue("@Email", user.email);
                        cmd.Parameters.AddWithValue("@Mobile", user.mobile);
                        cmd.Connection = con;
                        con.Open();
                        flag = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
            }
            return flag;
        }

        public bool LoginUser(User user)
        {
            string strcon = "Data Source=COGNINE-L13;Initial Catalog=Anusha;Integrated Security=True";
            using (SqlConnection sqlcon = new SqlConnection(strcon))
            {
                sqlcon.Open();
                string query = "select * from Info_DB where Username = @username and Password = @password";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                cmd.Parameters.AddWithValue("username", user.username);
                cmd.Parameters.AddWithValue("password", user.password);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
