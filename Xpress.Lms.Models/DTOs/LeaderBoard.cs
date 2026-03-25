namespace Xpress.Lms.Models.DTOs
{
    public class LeaderBoard
    {
        public string Category { get; set; } = default!;
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public decimal TopScore { get; set; }
    }
}
