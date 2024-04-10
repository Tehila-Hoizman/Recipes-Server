using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetAsyncById(int id);
        public Task DeleteAsync(int id);
        public Task<T> UpdateAsync(int id, T item);
        //public Task AddItemAsync(T item);
        public Task<T> AddItemAsync(T item);

        //Task<object> GetUserByEmailAndPassword(string email, string password);
    }
}
