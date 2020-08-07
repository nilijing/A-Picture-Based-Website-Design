using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class DBHelper
    {
        private string _ConnectionString;
        public string ConnectionString
        {
            get { return this._ConnectionString;  }
            set { this._ConnectionString = value; }
        }

        public DBHelper()
        {
        
            ConnectionString = ConfigurationManager.ConnectionStrings["FoodStory"].ConnectionString;
        }


        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
   return connection;
        }
        
        public int ExecuteScalarToInt(string safeSql)
        {
            int result = -1;
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(safeSql, connection);
                result = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return result;
        }

        public int ExecuteScalarToInt(string sql, params SqlParameter[] values)
        {
            int result = -1;
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                string resultStr = cmd.ExecuteScalar().ToString();
                if (resultStr != "")
                    result = Convert.ToInt32(resultStr);
                else
                    result = 0;
                connection.Close();
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return result;
        }

        public string ExecuteScalarToStr(string safeSql)
        {
            string result = "";
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(safeSql, connection);
                result = cmd.ExecuteScalar().ToString();
                connection.Close();
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return result;
        }

        public string ExecuteScalarToStr(string sql, params SqlParameter[] values)
        {
            string result = "";
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                result = cmd.ExecuteScalar().ToString();
                connection.Close();
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return result;
        }

        public int ExecuteNonQuery(string safeSql)
        {
            int result = -1;
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(safeSql, connection);
                result = cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return result;
        }

        public int ExecuteNonQuery(string sql, params SqlParameter[] values)
        {
            int result = -1;
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                result = cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return result;
        }

        public SqlDataReader GetDataReader(string safeSql)
        {
            SqlDataReader reader;
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(safeSql, connection);
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //connection.Close();   //此处不能关闭connection，会导致后面SqlDataReader读取数据失败
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return reader;
        }

        public SqlDataReader GetDataReader(string sql, params SqlParameter[] values)
        {
            SqlDataReader reader;
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //connection.Close();  //此处不能关闭connection，会导致后面SqlDataReader读取数据失败
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }
            return reader;
        }

        public DataTable GetDataTable(string safeSql)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(safeSql, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                connection.Close();  
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return ds.Tables[0];
        }

        public DataTable GetDataTable(string sql, params SqlParameter[] values)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection connection = OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                connection.Close();
            }
            catch (SqlException excep)
            {
                throw new Exception(excep.Message);
            }

            return ds.Tables[0];
        }
    }
}

