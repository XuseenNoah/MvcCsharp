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
                cmd.CommandText = @"INSERT INTO Customers (CustomerName,CustomerAddres,CustomerPhone,Date)  VALUES (@CustomerName,@CustomerAddres,@CustomerPhone,getdate())";
                cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerAddres", customer.CustomerAddres);
                cmd.Parameters.AddWithValue("@CustomerPhone", customer.CustomerPhone);
        
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Customers GetCustomerPhone(string customerPhone)
        {
            using (var conn = new SqlConnection(dbconn))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT *FROM Customers WHERE CustomerPhone=@CustomerPhone";
                cmd.Parameters.AddWithValue("@CustomerPhone", customerPhone);
                conn.Open();
                var reader = cmd.ExecuteReader();
                Customers customer = null;
                if (reader.Read())
                {
                    customer = new Customers();
                    customer.CustomerPhone = reader["CustomerPHone"] as string;

                }
                return customer;
            }
        }

        public List<Customers> ListPersons(string customerName)
        {
            using (var conn = new SqlConnection(dbconn))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT *FROM Customers  WHERE CustomerName LIKE @CustomerName";
                cmd.Parameters.AddWithValue("@CustomerName", customerName+"%%");
                conn.Open();
                var reader = cmd.ExecuteReader();
                var listPersons = new List<Customers>();
                while (reader.Read())
                {
                    var customer = new Customers();
                    customer.Id = (int)reader["Id"];
                    customer.CustomerName = reader["CustomerName"]as string ;
                    customer.CustomerAddres = reader["CustomerAddres"] as string;
                    customer.CustomerPhone = reader["CustomerPhone"] as string;
                    customer.Email = reader["Email"] as string;
                    customer.Date = (DateTime)reader["Date"];
                    listPersons.Add(customer);
                    
                }
                return listPersons;

            }
        }
    }
}