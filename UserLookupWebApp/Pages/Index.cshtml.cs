using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserLookupWebApp.Models;

namespace UserLookupWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<UserModel> Users { get; set; }

        [BindProperty(SupportsGet = true)]
        public string UserName { get; set; }
        public void OnGet()
        {
            //GetUserName();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            else
            {
                Users = UserData.GetUsers();

                foreach (var user in Users)
                {
                    if (user.FullName.Contains(UserName))
                    {
                        return RedirectToPage("Forms/UserDisplayPage", new { SearchedName = UserName });
                    }
                }

                return RedirectToPage("Forms/ErrorPage", new {SearchedName = UserName});
            }            
        }

        public string GetUserName()
        {
            return UserName;
        }
    }
}