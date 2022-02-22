using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Assignment3.Models;

namespace Assignment3.Services.Part2DAO
{
    public class SlideshowDAO
    {
        internal List<Image_Class> GetImages()
        {
            List<Image_Class> pictures = new List<Image_Class>();

            string connectionString = "Data Source = comp466a3.database.windows.net; Initial Catalog = comp466a3; User ID = Jenya; Password = Albinasuckscock123; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            string queryString = "SELECT * FROM [dbo].[p2_images]";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(queryString, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Image_Class picture = new Image_Class(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));

                    pictures.Add(picture);
                }             
            }
            return pictures;
        }
    }
}