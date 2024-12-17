using BoatClubLibrary.BoatData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoatClubWebsite1.Pages.Boat
{
    public class CreateBoatModel : PageModel
    {
        [BindProperty]
        public BoatClubLibrary.BoatData.Boat Boat { get; set; }

        public CreateBoatModel() { }
        
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            BoatRepo.CreateBoat(Boat);
            return RedirectToPage("GetAllBoats");
        }
    }
}
