using Microsoft.EntityFrameworkCore;

namespace LoanApplicationPortal.LoanContext
{
    public class LoanDbContext : DbContext
    {
     
        public LoanDbContext(DbContextOptions<LoanDbContext> options) : base(options)
        {

        }

        public DbSet<LoanDbContext> LoanApplications { get; set; }

    }
}
