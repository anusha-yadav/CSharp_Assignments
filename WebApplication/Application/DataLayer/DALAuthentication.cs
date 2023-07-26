using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using BusinessModels;

namespace DataLayer
{
    public class DALAuthentication : IDALAuthentication
    {
        public string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception(Literals.encodeMsg + ex.Message);
            }
        }

        public bool IsUserExists(string username)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Literals.userExistsQuery, con);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader sqlda = cmd.ExecuteReader();
                    if (sqlda.Read())
                    {
                        sqlda.Close();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public int ForgotPassword(User user)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                int flag = 0;
                try
                {
                    conn.Open();
                    if (IsUserExists(user.username))
                    {
                        SqlCommand command = new SqlCommand(Literals.updatePasswdQuery, conn);
                        command.Parameters.AddWithValue("@newpasswd", EncodePasswordToBase64(user.new_passwd));
                        command.Parameters.AddWithValue("@username", user.username);
                        flag = command.ExecuteNonQuery();
                    }
                    return flag;
                }
                catch (SqlException ex)
                {
                    throw new Exception(Literals.databaseError + ex.Message);
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
                try
                {
                    using (SqlCommand cmd = new SqlCommand("Insert_User"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Username", user.username);
                            cmd.Parameters.AddWithValue("@Password", EncodePasswordToBase64(user.password));
                            cmd.Parameters.AddWithValue("@Email", user.email);
                            cmd.Parameters.AddWithValue("@Mobile", user.mobile);
                            cmd.Connection = con;
                            con.Open();
                            flag = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                    return flag;
                }
                catch (SqlException ex)
                {
                    throw new Exception(Literals.databaseError + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public bool LoginUser(User user)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection sqlcon = new SqlConnection(strcon))
            {
                try
                {
                    string query = Literals.loginUserQuery;
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    cmd.Parameters.AddWithValue("username", user.username);
                    cmd.Parameters.AddWithValue("password", EncodePasswordToBase64(user.password));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int flag = cmd.ExecuteNonQuery();
                    if (dt.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                    throw new Exception(Literals.databaseError + ex.Message);
                }
                finally
                {
                    sqlcon.Close();
                }
            }
        }
    }
}
