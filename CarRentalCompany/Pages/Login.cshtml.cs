using CarRentalCompany.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CarRentalCompany.Pages
{
    public class LoginModel : PageModel
    {

        private readonly SignInManager<IdentityUser> signInManager;
        [BindProperty]
        public Login Model { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager= signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string returnUrl = null;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var identityResult = await signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);
            


            if (identityResult.Succeeded)
            {
                if (returnUrl == null || returnUrl == "/")
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    return RedirectToPage(returnUrl);
                }
            }

            ModelState.AddModelError("","Username or Password Incorrect");

            return Page();
        }

    }
}
