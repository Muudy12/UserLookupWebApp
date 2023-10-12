using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserLookupWebApp.Models;

namespace UserLookupWebApp.Pages.Forms
{
    public class UserDisplayPageModel : PageModel
    {
        public List<UserModel> ExistingUsers = UserData.GetUsers();

        [BindProperty]
        public List<UserModel> DisplayUsers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchedName { get; set; }
        public void OnGet()
        {
            DisplayUsers = ExistingUsers.Where(x => x.FullName.Contains(SearchedName)).ToList();
        }
    }
}
