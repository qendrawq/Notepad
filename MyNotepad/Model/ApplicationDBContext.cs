using System.Data.Entity;

namespace MyNotepad.DataLayer
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("DefaultConnection")
        {
        }
        public DbSet<File> Files { get; set; }
    }
}