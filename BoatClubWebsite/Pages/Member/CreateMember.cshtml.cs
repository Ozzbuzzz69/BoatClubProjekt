using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BoatClubLibrary.MemberData;
using BoatClubLibrary.MemberData.MemberService;

namespace BoatClubWebsite.Pages.Member
{
    public class CreateMemberModel : PageModel
    {
        private MemberService _memberService;
        [BindProperty]
        public BoatClubLibrary.MemberData.Member Member { get; set; }
        public CreateMemberModel(MemberService memberService)
        {
            _memberService = memberService;
        }
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
            _memberService.AddMember(Member);
            return RedirectToPage("GetAllMembers");
        }
    }
}
