using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessClubApp.Models
{
    public class DbHelper:ICoachRepository
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader reader;
        public DbHelper(IConfiguration configuration)
        {
            con = new SqlConnection(configuration.GetConnectionString("FitnessDB"));
            con.Open();

        }

        public void AddNewCoach(Coach coach)
        {
            com = new SqlCommand("insert into coaches(CoachName,CoachTYpe,Email,Contact,CoachImage) values('" + coach.CoachName + "','" + coach.CoachType + "','" + coach.Email + "'," + coach.Contact + ",'"+coach.CoachImgURL+"')", con);
            com.ExecuteNonQuery();
        }

        public Coach GetCoachById(int id)
        {

            return GetCoaches().Find(t => t.CoachId == id);
        }

        public List<Coach> GetCoaches()
        {
            List<Coach> coaches = new List<Coach>();
            com = new SqlCommand("Select * from coaches", con);
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                Coach coach = new Coach();
                coach.CoachId = reader.GetInt32(0);
                coach.CoachName = reader.GetString(1);
                coach.CoachType = reader.GetString(2);
                coach.Email = reader.GetString(3);
                coach.Contact = reader.GetInt32(4);
                coach.CoachImgURL = reader.GetString(5);
                coaches.Add(coach);
            }
            reader.Close();
            return coaches;

        }
    }
}
