namespace Xpress.Lms.Models.Entities
{
    public class Courses : BaseEntity
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public Guid CategoryId { get; set; } 
        public Guid InstructorId { get; set; } 
        public string ThumbnailUrl { get; set; } = default!;
    }
}
