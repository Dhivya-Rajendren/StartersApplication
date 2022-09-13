using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessClubApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FitnessClubApp.Pages
{
    public class CoachesModel : PageModel
    {
        private readonly ICoachRepository repo;

        public CoachesModel(ICoachRepository repository)
        {
            this.repo = repository;
        }
        public List<Coach> Coaches { get; set; }
        public void OnGet()// Http get method 
        {
   Coaches=   repo.GetCoaches();
        }
    }
}
