using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyNotepad.DataLayer
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<string> GetFileNamesList();
        T GetFileByName(string name);
        Task<T> GetFileByNameAsync(string name);
        T GetFileById(int id);
        void Create(T item);
        Task CreateAsync(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}