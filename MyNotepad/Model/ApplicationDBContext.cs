using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

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