using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MyNotepad.DataLayer
{
    /// <summary>
    /// Repository for SQLite database
    /// </summary>
    public class FileRepository : IRepository<File>
    {
        private ApplicationDBContext db;

        public FileRepository()
        {
            this.db = new ApplicationDBContext();
        }

        private bool disposed = false;

        /// <summary>
        /// Return collection of file names from database
        /// </summary>
        /// <returns>Collection of file names from database</returns>
        public IEnumerable<string> GetFileNamesList()
        {
            return (from f in db.Files
                select f.Name)
                .ToList();
        }

        /// <summary>
        /// Return file from database by name
        /// </summary>
        /// <param name="name">File`s name</param>
        /// <returns>File from database</returns>
        public File GetFileByName(string name)
        {
            return db.Files.Where(t => t.Name.Equals(name)).FirstOrDefault();
        }

        /// <summary>
        /// Return file from database by name asynchronously  
        /// </summary>
        /// <param name="name">File`s name</param>
        /// <returns>File from database</returns>
        public Task<File> GetFileByNameAsync(string name)
        {
            return db.Files.Where(t => t.Name.Equals(name)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Return file from database by Id
        /// </summary>
        /// <param name="name">File`s Id</param>
        /// <returns>File from database</returns>
        public File GetFileById(int id)
        {
            return db.Files.Find(id);
        }

        /// <summary>
        /// Insert new file to database
        /// </summary>
        /// <param name="item">New file</param>
        public void Create(File item)
        {
            db.Files.Add(item);
        }

        /// <summary>
        /// Insert new file to database asynchronously
        /// </summary>
        /// <param name="item">New file</param>
        public async Task CreateAsync(File item)
        {
             await Task.Run(() => Create(item));
        }

        /// <summary>
        /// Alter file in database
        /// </summary>
        /// <param name="item">Altered file</param>
        public void Update(File item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Delete file from database
        /// </summary>
        /// <param name="id">File`s id</param>
        public void Delete(int id)
        {
            File file = db.Files.Find(id);
            if (file != null)
                db.Files.Remove(file);
        }

        /// <summary>
        /// Save changes in database
        /// </summary>
        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}