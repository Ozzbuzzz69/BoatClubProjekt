using BoatClubLibrary.BoatData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoatClubWebsite1.Pages.Boat
{
    public class GetAllBoatsModel : PageModel
    {
        public List<BoatClubLibrary.BoatData.Boat> Boats { get; set; } = new List<BoatClubLibrary.BoatData.Boat>();
        
        public GetAllBoatsModel() { }
        
        public void OnGet()
        {
            Boats = BoatRepo.ReadAllBoats();
        }
    }
}
