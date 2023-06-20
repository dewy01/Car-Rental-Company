using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalCompany.Data;
using CarRentalCompany.Repositories.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace CarRentalCompany.Pages.Colours
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IGenericRepository<Colour> _repository;

        public CreateModel(IGenericRepository<Colour> repository)
        {
            this._repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Colour Colour { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //await _repository.Insert(Colour);

            using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarRentalCompany_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    @$"INSERT INTO Colours(Name,DateCreated)
                    VALUES(
                         @Colour,
                         @Date)";

                tableCmd.Parameters.Add("@Colour", System.Data.SqlDbType.VarChar, 50).Value=Colour.Name;
                tableCmd.Parameters.Add("@Date", System.Data.SqlDbType.DateTime).Value = DateTime.Now;

                tableCmd.ExecuteNonQuery();

            }


            return RedirectToPage("./Index");
        }
    }
}
