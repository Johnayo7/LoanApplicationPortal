namespace LoanApplicationPortal.Models.Domain
{
    public class BaseEntity
    {

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
