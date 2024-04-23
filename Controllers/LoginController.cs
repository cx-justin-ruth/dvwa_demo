using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using dvcsharp_core_api.Models;
using dvcsharp_core_api.Data;

namespace purchasepal_core
{
    class PurchaseController
    {
        static void Main(string[] args)
        {
            try
            {
                var user = args[0];
                var pwd = Encrypt(args[1]);
                Login(user, pwd);
            }
            catch  
            {

                Console.WriteLine("An error has occurred!!");
            }
            
        }

        private static  string Encrypt(string plain)
        {
            return plain;
        }
//added in AI Remediation Fix 
private int GetUserId_Safe(HttpRequest request)
{
    int userId = 0;
    
    string userName = request.Form["UserName"];
    string sql = "SELECT [UserID] FROM [AppUsers] WHERE [UserName] = @UserName";
    
    using (SqlConnection conn = GetConnection())
    {
        using (SqlCommand command = new SqlCommand(sql, conn))
        {
            command.Parameters.AddWithValue("@UserName", userName);
            
            conn.Open();
            userId = (int)command.ExecuteScalar();
        }
    }
    
    return userId;
}

      /*  private static void Login(string username,string password)
        {
            try
            {
                using (var conn = new SqlConnection("conn..."))
                {
                    var sql = "SELECT * FROM Users WHERE username = '" + username + "' AND pwd = '" + password + "'";
                    using (var cmd = new SqlCommand(sql))
                    {
                        cmd.Connection = conn;
                        cmd.ExecuteScalar();
                    }

                }
            }
            catch  
            {

                Console.WriteLine("An error has occurred !!");
            }
           
        } */
    }
}
