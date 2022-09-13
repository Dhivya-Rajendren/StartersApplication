using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessClubApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FitnessClubApp.Pages
{
    public class CoachStoryModel : PageModel
    {
        private readonly ICoachRepository repo;

        public CoachStoryModel(ICoachRepository coachRepository)
        {
            this.repo = coachRepository;
        }
        public Coach Coach { get; set; }
        public void OnGet(int id)
        {
         Coach=   repo.GetCoachById(id);

        }
    }
}
