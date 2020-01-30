using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3
{
    public static class DBLayer
    {
        //public static string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public static string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString.Replace("##", HttpContext.Current.Server.MapPath("CMS_DB.mdf")); //HttpContext.Current.Server.MapPath("CMS_DB.mdf")
        public static DataTable SelectRecords()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("UpsertRecord"))
                    {
                        cmd.Parameters.AddWithValue("@Action", "SELECT");
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dt);

                        }
                    }
                    con.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void Insert(ContactModel oContactModel)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UpsertRecord"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "INSERT");
                    cmd.Parameters.AddWithValue("@FirstName", oContactModel.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", oContactModel.LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", oContactModel.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Status", oContactModel.Status);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public static void Update(ContactModel oContactModel, int id)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UpsertRecord"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "UPDATE");
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@FirstName", oContactModel.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", oContactModel.LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", oContactModel.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Status", oContactModel.Status);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public static void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UpsertRecord"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "DELETE");
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }


    }
}