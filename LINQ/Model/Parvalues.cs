using System.ComponentModel.DataAnnotations;

namespace LINQ.Model
{
    public class Parvalues
    {
        [Key]
        public int Id { get; set; }
        public decimal? Amount { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? VersionNumber { get; set; }
    }
}
