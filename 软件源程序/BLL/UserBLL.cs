using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Web.Security;
using System.Data;

namespace BLL
{
    public class UserBLL
    {
        private UserDAL userDAL = new UserDAL();
        private FarvoriteDAL farvoriteDAL = new FarvoriteDAL();

        public User QueryInfo(string username)
        {
            return userDAL.QueryOneRecord(username);
        }

        public User QueryInfoByID(string id)
        {
            return userDAL.QueryOneRecordByID(id);
        }


        public bool VerifyPwd(string username, string pwd)
        {
      
            User user = QueryInfo(username);

            if (user == null)
            {
                return false;
            }
            else
            {
              
                if (user.Pwd == FormsAuthentication
                    .HashPasswordForStoringInConfigFile(pwd, "MD5"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

   
        public bool IsExist(string username)
        {
            return userDAL.IsExist(username);
        }

        public bool Register(User user)
        {
            return userDAL.InsertOneRecord(user);
        }

        public bool ModifyInfo(User user)
        {
            return userDAL.UpdateOneRecord(user);
        }

        public bool ModifyPwd(string email, string oldPwd, string newPwd)
        {
          
            if (VerifyPwd(email, oldPwd) == true)
            {
                return userDAL.UpdateOneRecordPwd(email, newPwd);
            }
            else
            {
                return false;
            }
        }

        public bool ModifyFace(string email, string path)
        {
            return userDAL.UpdateOneRecordAny(email, "FacePath", path);
        }

        public DataTable FarvoriteTable(string id)
        {
            return farvoriteDAL.QueryAllRecord(id);
        }
    }
}
