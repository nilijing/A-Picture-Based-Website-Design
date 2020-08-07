using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Web.Security;

namespace DAL
{
    public class UserDAL : DBHelper
    {
        public User QueryOneRecord(string username)
        {
            User user;
            string sqlStr = "SELECT * FROM [User] WHERE Email=@Username";
            SqlParameter[] SqlParam = new SqlParameter[1];
            SqlParam[0] = new SqlParameter("@Username", username);
            SqlDataReader dataReader = GetDataReader(sqlStr, SqlParam);
            if (dataReader.Read())
            {
                user = new User();
                user.ID = dataReader["ID"].ToString();
                user.Email = dataReader["Email"].ToString();
                user.Pwd = dataReader["Pwd"].ToString();
                user.NickName = dataReader["NickName"].ToString();
                user.Sex = dataReader["Sex"].ToString();
                user.FacePath = dataReader["FacePath"].ToString();
                user.Phone = dataReader["Phone"].ToString();
                user.QQ = dataReader["QQ"].ToString();
                user.RegTime = dataReader["RegTime"].ToString();
                if (dataReader.Read())
                {
                    throw new Exception("User表有重复，请检查。");
                }

            }
            else
            {
                user = null;
            }
            dataReader.Close();
            return user;
        }
        public User QueryOneRecordByID(string id)
        {
            User user;
            string sqlStr = "SELECT * FROM [User] WHERE ID=@ID";
            SqlParameter[] SqlParam = new SqlParameter[1];
            SqlParam[0] = new SqlParameter("@ID", id);
            SqlDataReader dataReader = GetDataReader(sqlStr, SqlParam);
            if (dataReader.Read())
            {
                user = new User();
                user.ID = dataReader["ID"].ToString();
                user.Email = dataReader["Email"].ToString();
                user.Pwd = dataReader["Pwd"].ToString();
                user.NickName = dataReader["NickName"].ToString();
                user.Sex = dataReader["Sex"].ToString();
                user.FacePath = dataReader["FacePath"].ToString();
                user.Phone = dataReader["Phone"].ToString();
                user.QQ = dataReader["QQ"].ToString();
                user.RegTime = dataReader["RegTime"].ToString();
                if (dataReader.Read())
                {
                    throw new Exception("User表有重复，请检查。");
                }

            }
            else
            {
                user = null;
            }
            dataReader.Close();
            return user;
        }
        public bool IsExist(string username)
        {
            string sqlStr = "SELECT COUNT(*) FROM [User] WHERE Email=@Username";
            SqlParameter[] SqlParam = new SqlParameter[1];
            SqlParam[0] = new SqlParameter("@Username", username);
            int result = ExecuteScalarToInt(sqlStr, SqlParam);
            if (result == 1)
            {
                return true;
            }
            else if (result == 0)
            {
                return false;
            }
            else
            {
                throw new Exception("User表的学生学号有重复，请检查。");
            }
        }
        public bool InsertOneRecord(User user)
        {
            if (IsExist(user.Email) == false)
            {
                string sqlStr = "INSERT INTO [User]([Email],[Pwd],[NickName],[Sex],[FacePath],[Phone],[QQ],[EmailVerification])"
                    + " VALUES(@Email,@Pwd,@NickName,@Sex,@FacePath,@Phone,@QQ,@EmailVerification)";
                SqlParameter[] SqlParam = new SqlParameter[8];
                SqlParam[0] = new SqlParameter("@Email", user.Email);
                SqlParam[1] = new SqlParameter("@Pwd", user.Pwd);
                SqlParam[2] = new SqlParameter("@NickName", user.NickName);
                SqlParam[3] = new SqlParameter("@Sex", user.Sex);
                SqlParam[4] = new SqlParameter("@FacePath", user.FacePath);
                SqlParam[5] = new SqlParameter("@Phone", user.Phone);
                SqlParam[6] = new SqlParameter("@QQ", user.QQ);
                SqlParam[7] = new SqlParameter("@EmailVerification", user.EmailVerification);
                int result = ExecuteNonQuery(sqlStr, SqlParam);
                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool UpdateOneRecord(User user)
        {
            string sqlStr = "UPDATE [User] SET [NickName] = @NickName,[Sex] = @Sex,[FacePath] = @FacePath,[Phone] = @Phone,[QQ] = @QQ,[EmailVerification] = @EmailVerification WHERE [Email] = @Email";
            SqlParameter[] SqlParam = new SqlParameter[7];
            SqlParam[0] = new SqlParameter("@NickName", user.NickName);
            SqlParam[1] = new SqlParameter("@Sex", user.Sex);
            SqlParam[2] = new SqlParameter("@FacePath", user.FacePath);
            SqlParam[3] = new SqlParameter("@Phone", user.Phone);
            SqlParam[4] = new SqlParameter("@QQ", user.QQ);
            SqlParam[5] = new SqlParameter("@EmailVerification", user.EmailVerification);
            SqlParam[6] = new SqlParameter("@Email", user.Email);
            int result = ExecuteNonQuery(sqlStr, SqlParam);
            if (result == 1)
            {
                return true;
            }
            else if (result == 0)
            {
                return false;
            }
            else
            {
                throw new Exception("User表的用户名有重复，请检查。");
            }
        }
        public bool UpdateOneRecordPwd(string email, string newPwd)
        {
            string sqlStr = "UPDATE [User] SET Pwd=@Pwd WHERE [Email] = @Email";
            SqlParameter[] SqlParam = new SqlParameter[2];
            SqlParam[0] = new SqlParameter("@Pwd", FormsAuthentication.HashPasswordForStoringInConfigFile(newPwd, "MD5"));
            SqlParam[1] = new SqlParameter("@Email", email);
            int result = ExecuteNonQuery(sqlStr, SqlParam);
            if (result == 1)
            {
                return true;
            }
            else if (result == 0)
            {
                return false;
            }
            else
            {
                throw new Exception("User表的用户名有重复，请检查。");
            }
        }
        public bool UpdateOneRecordAny(string email, string field, string value)
        {
            string sqlStr = "UPDATE [User] SET " + field + "=@Value WHERE [Email] = @Email";
            SqlParameter[] SqlParam = new SqlParameter[2];
            SqlParam[0] = new SqlParameter("@Value", value);
            SqlParam[1] = new SqlParameter("@Email", email);
            int result = ExecuteNonQuery(sqlStr, SqlParam);
            if (result == 1)
            {
                return true;
            }
            else if (result == 0)
            {
                return false;
            }
            else
            {
                throw new Exception("User表的用户名有重复，请检查。");
            }
        }
    }
}
