using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IService <T>
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetAsyncById(int id);
        public Task<T> UpdateAsync(int id, T item);
        public Task DeleteAsync(int id);
        public Task<T> AddItemAsync(T item);
    }
}
