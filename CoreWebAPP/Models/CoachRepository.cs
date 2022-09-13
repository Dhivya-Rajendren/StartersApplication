using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessClubApp.Models
{
    public class CoachRepository:ICoachRepository
    {
        private static List<Coach> _coaches = new List<Coach>()
        {
            new Coach(){CoachId=1,CoachName="Sasvanth",CoachType="Workout",Email="Savanth@cloudkamps.com",Contact=789545},
            new Coach(){CoachId=2,CoachName="Priya",CoachType="Diet",Email="Priya_Diet@cloudkamps.com",Contact=78989545},
            new Coach(){CoachId=3,CoachName="Suresh",CoachType="Diet",Email="Suresh@cloudkamps.com",Contact=89789545},
            new Coach(){CoachId=4,CoachName="Amitha",CoachType="Workout",Email="Amitha@cloudkamps.com",Contact=789789545},
            new Coach(){CoachId=5,CoachName="Sam",CoachType="Workout",Email="Sam@cloudkamps.com",Contact=789545}
        };

        public List<Coach> GetCoaches()
        {
            return _coaches;
        }

        public Coach GetCoachById(int id)
        {
            return _coaches.FirstOrDefault(c => c.CoachId == id);
        }

        public void AddNewCoach(Coach coach)
        {
            _coaches.Add(coach);
        }
    }
}
