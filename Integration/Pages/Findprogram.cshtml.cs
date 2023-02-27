
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Integration.Pages
{
    public class FindprogramModel : PageModel
    {
        public bool conf = false;
        public ProgramF find;
        [BindProperty]
        public string programcode { get; set; }
        [BindProperty]
        
        public string Message { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            find = BCS.FindProgram(programcode);

            if (find != null)
            {
                conf = true;
                Message = "Succeed";
            }
            else
            {
                Message = "Error";
            }
        }
    }
}
