using System.Data.Entity;

namespace MyNotepad.DataLayer
{
    /// <summary>
    /// Database context
    /// </summary>
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("DefaultConnection")
        {
        }

        /// <summary>
        /// Set of files from database
        /// </summary>
        public DbSet<File> Files { get; set; }
    }
}