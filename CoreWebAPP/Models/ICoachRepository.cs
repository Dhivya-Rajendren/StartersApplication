using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessClubApp.Models
{
public    interface ICoachRepository
    {
        List<Coach> GetCoaches();
        Coach GetCoachById(int id);
        void AddNewCoach(Coach coach);
    }
}
