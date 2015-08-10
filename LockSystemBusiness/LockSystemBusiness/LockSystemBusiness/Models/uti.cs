using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Collections;

namespace LockSystemBusiness.Models
{
    public static class uti
    {
        public static DataTable GetImagesInfo(string folder, bool hidden)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cnn = new MySqlConnection(ConnectionStrings.MySqlConnectionString()))
            {
                cnn.Open();
                using (var cmd = cnn.CreateCommand())
                {
                    if (hidden == true)
                    {
                        cmd.CommandText = "SELECT * FROM lockbusiness_images WHERE folder=@folder AND hidden=0";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM lockbusiness_images WHERE folder=@folder";
                    }
                    cmd.Parameters.AddWithValue("folder", folder);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable GetRandomImagesInfo(string folder, bool hidden)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cnn = new MySqlConnection(ConnectionStrings.MySqlConnectionString()))
            {
                cnn.Open();
                using (var cmd = cnn.CreateCommand())
                {
                    if (hidden == true)
                    {
                        cmd.CommandText = "SELECT * FROM lockbusiness_images WHERE folder=@folder AND hidden=0 ORDER BY RAND()";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM lockbusiness_images WHERE folder=@folder ORDER BY RAND()";
                    }
                    cmd.Parameters.AddWithValue("folder", folder);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable GetPageData(string pagename)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cnn = new MySqlConnection(ConnectionStrings.MySqlConnectionString()))
            {
                cnn.Open();
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = "SELECT pagedata FROM lockbusiness_page WHERE pagename=@pagename";
                    cmd.Parameters.AddWithValue("pagename", pagename);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public static bool GetPageActive(string tabname)
        {
            bool toReturn = false;
            using (MySqlConnection cnn = new MySqlConnection(ConnectionStrings.MySqlConnectionString()))
            {
                cnn.Open();
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = "SELECT active FROM lockbusiness_tabs WHERE id=@id";
                    cmd.Parameters.AddWithValue("id", tabname);
                    int num = Convert.ToInt32(cmd.ExecuteScalar());
                    switch (num) { case 1: toReturn = true; break; }
                }
            }
            return toReturn;
        }
    }
}