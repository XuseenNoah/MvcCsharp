using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcCsharp.ViewModels;
using System.Data.SqlClient;

namespace MvcCsharp.Models
{
    public class Repository
    {
        public string dbconn = System.Configuration.ConfigurationManager.ConnectionStrings["Db"].ConnectionString;

        public void CreateCustomer(Customers customer)
        {
            using (var conn = new SqlConnection(dbconn))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO Customers VALUES (@CustomerName,@CustomerAddres,@CustomerPhone,@CusomterEmail,getdate())";
                cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerAddres", customer.CustomerAddres);
                cmd.Parameters.AddWithValue("@CustomerPhone", customer.CustomerPhone);
                cmd.Parameters.AddWithValue("@CusomterEmail", customer.Email);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}