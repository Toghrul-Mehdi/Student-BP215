using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentDB
{
    class Program
    {
        static void Main()
        {
            string connectionString = "Server=localhost;Database=BP215;Trusted_Connection=True;";

            string[] StudentName = { "Togrul", "Kenan", "Turan", "Samir", "Emin", "Bextiyar" };
            string[] StudentSurname = { "Mehdiyev", "Qurbanli", "Mirzeyev", "Hebibov", "Eminov", "Bextiyarov" };
            int[] StudentAge = { 19, 18, 18, 17, 16, 20 };
            double[] AvgPoint = { 80.3, 51.4, 48.5, 60.5, 72, 50 };

            string query = "INSERT INTO Student(StudentName,StudentSurname,StudentAge,AvgPoint) VALUES (@StudentName,@StudentSurname,@StudentAge,@AvgPoint)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        for (int i = 0; i < StudentName.Length; i++)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@StudentName", StudentName[i]);
                            cmd.Parameters.AddWithValue("@StudentSurname", StudentSurname[i]);
                            cmd.Parameters.AddWithValue("@StudentAge", StudentAge[i]);
                            cmd.Parameters.AddWithValue("@AvgPoint", AvgPoint[i]);
                            Console.WriteLine(StudentName[i]+" elave olundu!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}