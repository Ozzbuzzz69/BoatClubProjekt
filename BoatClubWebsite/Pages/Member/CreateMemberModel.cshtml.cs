using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoatClubWebsite.Pages.Member
{
    public class CreateMemberModelModel : PageModel
    {
        [BindProperty]
        public BoatClubLibrary.MemberData.Member Member { get; set; }
        public void OnGet()
        {
        }
    }
}
