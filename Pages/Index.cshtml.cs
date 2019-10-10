using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Issue863.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(ILogger<IndexModel> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async void OnGet()
        {
            await TestIssue863();
        }

        private async Task TestIssue863()
        {
            var users = _userManager.Users.ToArray();
            var roles = await _userManager.GetRolesAsync(users.First());

            foreach (var role in roles)
            {
                Debug.WriteLine(role);
            }
        }
    }
}
