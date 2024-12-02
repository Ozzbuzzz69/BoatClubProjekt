using BoatClubLibrary.MemberData.MemberService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BoatClubLibrary.MemberData;

namespace BoatClubWebsite.Pages.Member
{
    public class GetAllMembersModel : PageModel
    {
        private MemberService _memberService;
        public List<BoatClubLibrary.MemberData.Member> Members { get; set; } = new List<BoatClubLibrary.MemberData.Member>();
        public GetAllMembersModel(MemberService memberService)
        {
            _memberService = memberService;
        }
        public void OnGet()
        {
            Members = _memberService.GetMembers();
        }

        
    }
}
