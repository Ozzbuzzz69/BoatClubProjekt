using BoatClubLibrary.BoatData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoatClubWebsite1.Pages.Boat
{
    public class DeleteBoatModel : PageModel
    {
        public BoatClubLibrary.BoatData.Boat Boat { get; set; }

        public DeleteBoatModel() { }

        public IActionResult OnGet(int id)
        {
            Boat = BoatRepo.ReadBoat(id);
            if (Boat == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            BoatClubLibrary.BoatData.Boat deleteBoat = BoatRepo.DeleteBoatRazor(Boat.Id);
            if (deleteBoat == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("GetAllBoats");
        }
    }
}
