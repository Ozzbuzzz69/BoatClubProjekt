using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BoatClubLibrary.MemberData;

namespace BoatClubWebsite.Pages.Member
{
    public class CreateMemberModel : PageModel
    {
        
        [BindProperty]
        public BoatClubLibrary.MemberData.Member Member { get; set; }
        
    }
}
