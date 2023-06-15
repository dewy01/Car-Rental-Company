using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalCompany.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
        private IHttpContextAccessor Accessor;

        public IndexModel(ILogger<IndexModel> logger, IHttpContextAccessor _accessor)
		{
			_logger = logger;
            this.Accessor = _accessor;
        }

		public void OnGet()
		{

		}

        public void OnPostWriteCookie(string name)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Append("Name", name, option);
            RedirectToPage("/Index");
        }

        public void OnPostReadCookie()
        {
            string name = this.Accessor.HttpContext.Request.Cookies["Name"];
            ViewData["Message"] = name;
            RedirectToPage("/Index");
        }

        public void OnPostDeleteCookie()
        {
            Response.Cookies.Delete("Name");
            RedirectToPage("/Index");
        }
    }
}