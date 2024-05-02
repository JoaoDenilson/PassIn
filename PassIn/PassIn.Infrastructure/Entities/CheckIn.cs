using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassIn.Infrastructure.Entities
{
    public class CheckIn
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Created_at { get; set; }
        public Guid Attendee_Id { get; set; }
        public Attendee Attendee { get; set; } = default!;
    }
}
