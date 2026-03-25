using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;
using System.Security.Principal;
using static System.Formats.Asn1.AsnWriter;

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
