using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginMVC.Models;
using System.Data.SqlClient;

namespace LoginMVC.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-7JKTAF5\\MSSQLSERVER01; database=AIRA; integrated security=SSPI;";
        }
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select* from dbo.login where username='"+acc.Name+"' and password='"+acc.Password+"'"; 
            dr=cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View();

            }
            else
            {
                con.Close();
                return View();
            }
           
            
         }
    }
}