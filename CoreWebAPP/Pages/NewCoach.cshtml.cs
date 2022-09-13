using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FitnessClubApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FitnessClubApp.Pages
{
    public class NewCoachModel : PageModel
    {
        [BindProperty]
        public Coach Coach { get; set; }
        public ICoachRepository repo { get; }

        private readonly IHostingEnvironment environment;

        public NewCoachModel(ICoachRepository coachRepository,IHostingEnvironment environment)
        {
            repo = coachRepository;
            this.environment = environment;
        }
        public void OnGet()
        {
        }

   
        public void OnPost(IFormFile postedFiles)
        {
            string wwwPath = this.environment.WebRootPath;
            string contentPath = this.environment.ContentRootPath;
            string path = Path.Combine(this.environment.WebRootPath, "images");
            List<string> uploadedFiles = new List<string>();
           
                string fileName = Path.GetFileName(postedFiles.FileName);
                using (FileStream str = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFiles.CopyTo(str);
                    uploadedFiles.Add(fileName);

                }
                Coach.CoachImgURL =  "/images/" + fileName;
            
            
            Coach.CoachId = repo.GetCoaches().Count + 1;
            repo.AddNewCoach(Coach);
        }
    }
}
