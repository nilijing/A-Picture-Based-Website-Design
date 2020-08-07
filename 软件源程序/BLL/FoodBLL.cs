using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class FoodBLL
    {
        private FoodDAL foodDAL = new FoodDAL();
        private FarvoriteDAL farvoriteDAL = new FarvoriteDAL();
        private LikeDAL likeDAL = new LikeDAL();

        public Food Query(string id)
        {
            return foodDAL.QueryOneRecord(id);
        }

        public DataTable QueryAllByUID(string uid)
        {
            return foodDAL.QueryAllRecordByUID(uid);
        }

  
        public DataTable Search(String[] keywords)
        {
            return foodDAL.Search(keywords);
        }

        public bool Insert(Food food)
        {
            return foodDAL.InsertOneRecord(food);
        }

        public DataTable QueryN(int num)
        {
            return foodDAL.QueryMultRecord(num);
        }


        public bool FarvoriteFromUser(string userID, string foodID)
        {
            Farvorite farvorite = farvoriteDAL.QueryOneRecord(userID, foodID);
            if (farvorite == null)
            {
                return farvoriteDAL.InsertOneRecord(userID, foodID);
            }
            else
            {
                return false;
            }
        }

        public bool RemoveFarvorite(string userID, string foodID)
        {
            return farvoriteDAL.DeleteOneRecord(userID, foodID);
        }

  
        public bool LikeFromAny(string liker, string foodID)
        {
            if (!likeDAL.IsLikeToday(liker, foodID))
            {
                return likeDAL.InsertOneRecord(liker, foodID);
            }
            else
            {
                return false;
            }
        }

    }
}
