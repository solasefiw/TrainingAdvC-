using System.ComponentModel.DataAnnotations;

namespace LINQ.Model
{
    public class Shareholders
    {
        [Key]
        public int Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Gender { get; set; }
        public string? ShareholderType { get; set; }
        public string? AccountNumber { get; set; }
    }
}
