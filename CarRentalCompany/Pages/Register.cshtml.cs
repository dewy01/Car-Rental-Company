
using CarRentalCompany.Repositories.Interfaces;
using CarRentalCompany.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace CarRentalCompany.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Register Model { get; set; }
        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var user = new IdentityUser()
            {
                UserName = Model.Email,
                Email = Model.Email
            };

            var result = await userManager.CreateAsync(user, Model.Password);
            if(result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return RedirectToPage("Index");
            }

            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return Page();
        }
    }
}
