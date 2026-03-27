namespace Xpress.Lms.Models.Entities
{
    public class Attempts: BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public decimal Score { get; set; }
        public int Progress { get; set; }
    }
}
