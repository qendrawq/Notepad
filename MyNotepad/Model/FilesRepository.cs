using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MyNotepad.DataLayer
{
    public class FileRepository : IRepository<File>
    {
        private ApplicationDBContext db;

        public FileRepository()
        {
            this.db = new ApplicationDBContext();
        }

        private bool disposed = false;

        public IEnumerable<string> GetFileNamesList()
        {
            return (from f in db.Files
                select f.Name)
                .ToList();
        }

        public File GetFileByName(string name)
        {
            return db.Files.Where(t => t.Name.Equals(name)).FirstOrDefault();
        }

        public Task<File> GetFileByNameAsync(string name)
        {
            return db.Files.Where(t => t.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public File GetFileById(int id)
        {
            return db.Files.Find(id);
        }

        public void Create(File item)
        {
            db.Files.Add(item);
        }

        public async Task CreateAsync(File item)
        {
             await Task.Run(() => Create(item));
        }

        public void Update(File item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            File file = db.Files.Find(id);
            if (file != null)
                db.Files.Remove(file);
        }

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