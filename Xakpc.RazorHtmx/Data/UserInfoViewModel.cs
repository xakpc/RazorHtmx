using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Xakpc.RazorHtmx.Data
{
    public class UserInfoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Status")]
        public string? Status { get; set; }

        public Guid RowId { get; set; } = Guid.Empty;
    }
}
