using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class LikeDAL : DBHelper
    {
        public bool IsLikeToday(string liker, string foodID)
        {
            string sqlStr = "SELECT COUNT(*) FROM [Like] where DATEDIFF(day,[Date],GETDATE())=0" + " AND [Liker] = @Liker AND [FoodID] = @FoodID";
            SqlParameter[] SqlParam = new SqlParameter[2];
            SqlParam[0] = new SqlParameter("@Liker", liker);
            SqlParam[1] = new SqlParameter("@FoodID", foodID);
            string result = ExecuteScalarToStr(sqlStr, SqlParam);
            if (Convert.ToInt32(result) >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool InsertOneRecord(string liker, string foodID)
        {
            string sqlStr = "INSERT INTO [Like]([Liker],[FoodID])"  + " VALUES(@Liker,@FoodID)";
            SqlParameter[] SqlParam = new SqlParameter[2];
            SqlParam[0] = new SqlParameter("@Liker", liker);
            SqlParam[1] = new SqlParameter("@FoodID", foodID);
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
    }
}
