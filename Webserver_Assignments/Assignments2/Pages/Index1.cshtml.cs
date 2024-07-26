using Assignments2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignments2.Pages
{
    public class Index1Model : PageModel
    {
        static List<Book> books = new List<Book>()
        {
            new Book(){Id=1,Name="physics",price=200,language="telugu",Author="kaboor"},
            new Book(){Id=2,Name="chemistry",price=300,language="english",Author="kali"},
            new Book(){Id=3,Name="maths",price=200,language="telugu",Author="joe"},

        };
        [BindProperty]
        public Book Book { get; set; }
        public List<Book> List
        {
            get { return books; }
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            books.Add(Book);
            return RedirectToPage("Index1");
        }
    }

}