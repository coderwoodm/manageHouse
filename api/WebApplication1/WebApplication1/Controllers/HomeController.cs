using Demo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //public string Options()

        //{
        //    return null; // HTTP 200 response with empty body
        //}
        // GET: Home

        public ActionResult getRentMes()
        {
            List<House> houses = new List<House>();
            string sql = string.Format("select * from rentHouseMes");
            SqlDataReader reader = DBHelper.GetDataReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    House h = new House();
                    h.id = reader["id"].ToString();
                    h.name = reader["name"].ToString();
                    h.phone = reader["phone"].ToString();
                    h.address = reader["address"].ToString();
                    h.finishCase = reader["finishCase"].ToString();
                    h.houseArea = reader["houseArea"].ToString();
                    h.houseType = reader["houseType"].ToString();
                    h.houseStyle = reader["houseStyle"].ToString();
                    h.monthMoney = reader["monthMoney"].ToString();
                    h.rentOut = reader["rentOut"].ToString();
                    houses.Add(h);
                }
            }
            return Json(houses, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserLogin()
        {
            List<Login> users = new List<Login>();
            string sql = string.Format("select * from Users");
            SqlDataReader reader = DBHelper.GetDataReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Login u = new Login();
                    u.userName = reader["userName"].ToString();
                    u.userPwd = reader["userPwd"].ToString();
                    u.Name = reader["Name"].ToString();
                    u.iphone = reader["iphone"].ToString();
                    users.Add(u);
                }
            }
            return Json(users,JsonRequestBehavior.AllowGet);
        }

        public ActionResult getBegSellMes()
        {
            List<begSellHouse> houses = new List<begSellHouse>();
            string sql = string.Format("select * from begSellHouse");
            SqlDataReader reader = DBHelper.GetDataReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    begSellHouse h = new begSellHouse();
                    h.id = reader["id"].ToString();
                    h.name = reader["name"].ToString();
                    h.phone = reader["phone"].ToString();
                    h.finishCase = reader["finishCase"].ToString();
                    h.houseArea = reader["houseArea"].ToString();
                    h.houseType = reader["houseType"].ToString();
                    h.houseStyle = reader["houseStyle"].ToString();
                    houses.Add(h);
                }
            }
            return Json(houses, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getBegRentMes()
        {
            List<begRentHouse> houses = new List<begRentHouse>();
            string sql = string.Format("select * from begRentHouse");
            SqlDataReader reader = DBHelper.GetDataReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    begRentHouse h = new begRentHouse();
                    h.id = reader["id"].ToString();
                    h.name = reader["name"].ToString();
                    h.phone = reader["phone"].ToString();
                    h.finishCase = reader["finishCase"].ToString();
                    h.houseArea = reader["houseArea"].ToString();
                    h.houseType = reader["houseType"].ToString();
                    h.houseStyle = reader["houseStyle"].ToString();
                    houses.Add(h);
                }
            }
            return Json(houses, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getSellMes()
        {

            List<sellHouse> houses = new List<sellHouse>();
            string sql = string.Format("select * from sellHouseMes");
            SqlDataReader reader = DBHelper.GetDataReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    sellHouse h = new sellHouse();
                    h.id = reader["id"].ToString();
                    h.name = reader["name"].ToString();
                    h.phone = reader["phone"].ToString();
                    h.address = reader["address"].ToString();
                    h.finishCase = reader["finishCase"].ToString();
                    h.houseArea = reader["houseArea"].ToString();
                    h.houseType = reader["houseType"].ToString();
                    h.houseStyle = reader["houseStyle"].ToString();
                    h.pric = reader["pric"].ToString();
                    h.sale = reader["sale"].ToString();
                    houses.Add(h);
                }
            }
            return Json(houses, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getRentMesTwo()
        {

            List<rentHouse> houses = new List<rentHouse>();
            string sql = string.Format("select * from rentTwoHouseM");
            SqlDataReader reader = DBHelper.GetDataReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    rentHouse h = new rentHouse();
                    h.id = reader["id"].ToString();
                    h.name = reader["name"].ToString();
                    h.phone = reader["phone"].ToString();
                    h.address = reader["address"].ToString();
                    h.finishCase = reader["finishCase"].ToString();
                    h.houseArea = reader["houseArea"].ToString();
                    h.houseType = reader["houseType"].ToString();
                    h.houseStyle = reader["houseStyle"].ToString();
                    h.monthMoney = reader["monthMoney"].ToString();
                    h.rentOut = reader["rentOut"].ToString();
                    h.sex = reader["sex"].ToString();
                    houses.Add(h);
                }
            }
            return Json(houses, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getScreenMes(SreenMes o)
        {
            string sqlSon = "";
            if (o.houseArea != null)
            {
                sqlSon += "and houseArea = '" + o.houseArea + "'";
            }
            if (o.monthMoney != null)
            {
                sqlSon += "and monthMoney = '" + o.monthMoney + "'";
            }
            if (o.houseType != null)
            {
                sqlSon += "and houseType = '" + o.houseType + "'";
            }
            if (o.houseStyle != null)
            {
                sqlSon += "and houseStyle = '" +o.houseStyle+"'";
            }
            if (o.finishCase != null)
            {
                sqlSon += "and finishCase = '" + o.finishCase + "'";
            }
            sqlSon = sqlSon.Remove(0, 3);
            List<House> data = new List<House>();
            string sql = string.Format("select * from rentHouseMes where " + sqlSon);
            SqlDataReader reader = DBHelper.GetDataReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    House h = new House();
                    h.id = reader["id"].ToString();
                    h.name = reader["name"].ToString();
                    h.phone = reader["phone"].ToString();
                    h.address = reader["address"].ToString();
                    h.finishCase = reader["finishCase"].ToString();
                    h.houseArea = reader["houseArea"].ToString();
                    h.houseType = reader["houseType"].ToString();
                    h.houseStyle = reader["houseStyle"].ToString();
                    h.monthMoney = reader["monthMoney"].ToString();
                    h.rentOut = reader["rentOut"].ToString();
                    data.Add(h);
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getSellScreenMes(sellSreenMes o)
        {
            string sqlSon = "";
            if (o.houseArea != null)
            {
                sqlSon += "and houseArea = '" + o.houseArea + "'";
            }
            if (o.pric != null)
            {
                sqlSon += "and pric = '" + o.pric + "'";
            }
            if (o.houseType != null)
            {
                sqlSon += "and houseType = '" + o.houseType + "'";
            }
            if (o.houseStyle != null)
            {
                sqlSon += "and houseStyle = '" + o.houseStyle + "'";
            }
            if (o.finishCase != null)
            {
                sqlSon += "and finishCase = '" + o.finishCase + "'";
            }
            sqlSon = sqlSon.Remove(0, 3);
            List<sellHouse> data = new List<sellHouse>();
            string sql = string.Format("select * from sellHouseMes where " + sqlSon);
            SqlDataReader reader = DBHelper.GetDataReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    sellHouse h = new sellHouse();
                    h.id = reader["id"].ToString();
                    h.name = reader["name"].ToString();
                    h.phone = reader["phone"].ToString();
                    h.address = reader["address"].ToString();
                    h.finishCase = reader["finishCase"].ToString();
                    h.houseArea = reader["houseArea"].ToString();
                    h.houseType = reader["houseType"].ToString();
                    h.houseStyle = reader["houseStyle"].ToString();
                    h.pric = reader["pric"].ToString();
                    h.sale = reader["sale"].ToString();
                    data.Add(h);
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getScreenMesTwo(SreenMesJr o)
        {
            string sqlSon = "";
            if (o.houseArea != null)
            {
                sqlSon += "and houseArea = '" + o.houseArea + "'";
            }
            if (o.monthMoney != null)
            {
                sqlSon += "and monthMoney = '" + o.monthMoney + "'";
            }
            if (o.houseType != null)
            {
                sqlSon += "and houseType = '" + o.houseType + "'";
            }
            if (o.houseStyle != null)
            {
                sqlSon += "and houseStyle = '" + o.houseStyle + "'";
            }
            if (o.finishCase != null)
            {
                sqlSon += "and finishCase = '" + o.finishCase + "'";
            }
            if (o.sex != null)
            {
                sqlSon += "and sex = '" + o.sex + "'";
            }
            sqlSon = sqlSon.Remove(0, 3);
            List<rentHouse> data = new List<rentHouse>();
            string sql = string.Format("select * from rentTwoHouseM where " + sqlSon);
            SqlDataReader reader = DBHelper.GetDataReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    rentHouse h = new rentHouse();
                    h.id = reader["id"].ToString();
                    h.name = reader["name"].ToString();
                    h.phone = reader["phone"].ToString();
                    h.address = reader["address"].ToString();
                    h.finishCase = reader["finishCase"].ToString();
                    h.houseArea = reader["houseArea"].ToString();
                    h.houseType = reader["houseType"].ToString();
                    h.houseStyle = reader["houseStyle"].ToString();
                    h.monthMoney = reader["monthMoney"].ToString();
                    h.rentOut = reader["rentOut"].ToString();
                    h.sex = reader["sex"].ToString();
                    data.Add(h);
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public void AddItemMes(House o)
        {
            string sql = string.Format("insert into rentHouseMes values('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",o.name,o.phone,o.houseType,o.monthMoney,o.houseStyle,o.houseArea,o.finishCase,o.address,o.rentOut);
            DBHelper.ExecuteNonQuery(sql);
        }

        public void AddUser(Login o)
        {
            string sql = string.Format("insert into Users values('{0}', '{1}','{2}','{3}')", o.userName, o.userPwd, o.Name, o.iphone);
            DBHelper.ExecuteNonQuery(sql);
        }

        public void AddItemMesTwo(rentHouse o)
        {
            string sql = string.Format("insert into rentTwoHouseM values('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", o.name, o.phone, o.houseType, o.monthMoney, o.houseStyle, o.houseArea, o.finishCase, o.address, o.rentOut,o.sex);
            DBHelper.ExecuteNonQuery(sql);
        }
        public void AddSellItemMes(sellHouse o)
        {
            string sql = string.Format("insert into sellHouseMes values('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", o.name, o.phone, o.houseType, o.pric, o.houseStyle, o.houseArea, o.finishCase, o.address, o.sale);
            DBHelper.ExecuteNonQuery(sql);
        }

        public void AddBegItemMes(begRentHouse o)
        {
            string sql = string.Format("insert into begRentHouse values('{0}', '{1}','{2}','{3}','{4}','{5}')", o.name, o.phone, o.houseType, o.houseStyle, o.houseArea, o.finishCase);
            DBHelper.ExecuteNonQuery(sql);
        }
        public void AddBegSellItemMes(begSellHouse o)
        {
            string sql = string.Format("insert into begSellHouse values('{0}', '{1}','{2}','{3}','{4}','{5}')", o.name, o.phone, o.houseType, o.houseStyle, o.houseArea, o.finishCase);
            DBHelper.ExecuteNonQuery(sql);
        }

        public void DeleteItemMes(int[] id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                string sql = string.Format("delete from rentHouseMes where id={0}", id[i]);
                DBHelper.ExecuteNonQuery(sql);
            }
        }
        public void DeleteItemMesTwo(int[] id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                string sql = string.Format("delete from rentTwoHouseM where id={0}", id[i]);
                DBHelper.ExecuteNonQuery(sql);
            }
        }
        public void DeleteSellItemMes(int[] id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                string sql = string.Format("delete from sellHouseMes where id={0}", id[i]);
                DBHelper.ExecuteNonQuery(sql);
            }
        }

        public void DeleteBegItemMes(int[] id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                string sql = string.Format("delete from begRentHouse where id={0}", id[i]);
                DBHelper.ExecuteNonQuery(sql);
            }
        }
        public void DeleteBegSellItemMes(int[] id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                string sql = string.Format("delete from begSellHouse where id={0}", id[i]);
                DBHelper.ExecuteNonQuery(sql);
            }
        }
        public void upDataMes(House h)
        {
            string sql = string.Format("update rentHouseMes set name = '{1}',phone = '{2}' , houseType = '{3}' , houseArea = '{4}' , monthMoney = '{5}' , houseStyle = '{6}' , rentOut = '{7}' , finishCase = '{8}' , address = '{9}' where id = {0}  ", h.id,h.name,h.phone,h.houseType,h.houseArea,h.monthMoney,h.houseStyle,h.rentOut,h.finishCase,h.address);
            DBHelper.ExecuteNonQuery(sql);
        }
        public void upDataPwd(Login user)
        {
            string sql = string.Format("update Users set userPwd = '{0}' where userName = '{1}'",user.userPwd,user.userName );
            DBHelper.ExecuteNonQuery(sql);
        }
    }
}