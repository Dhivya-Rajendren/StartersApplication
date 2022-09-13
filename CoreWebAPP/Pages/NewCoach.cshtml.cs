using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessClubApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FitnessClubApp.Pages
{
    public class NewCoachModel : PageModel
    {
        [BindProperty]
        public Coach Coach { get; set; }
        public ICoachRepository repo { get; }

        public NewCoachModel(ICoachRepository coachRepository)
        {
            repo = coachRepository;
        }
        public void OnGet()
        {
        }

   
        public void OnPost()
        {
            Coach.CoachId = repo.GetCoaches().Count + 1;
            repo.AddNewCoach(Coach);
        }
    }
}
