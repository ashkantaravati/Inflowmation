using System.ComponentModel.DataAnnotations;

namespace Inflowmation.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        [MaxLength(400)]
        public string? Descriptions { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Employee? CreatedBy { get; set; }

        public Department? IssuedFrom { get; set; }
        public Department? IssuedFor { get; set; }



    }
}
