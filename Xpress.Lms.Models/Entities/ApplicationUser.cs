using Xpress.Lms.Models.Enums;

namespace Xpress.Lms.Models.Entities
{
    public class ApplicationUser : BaseEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public Roles Role { get; set; }
    }
}
