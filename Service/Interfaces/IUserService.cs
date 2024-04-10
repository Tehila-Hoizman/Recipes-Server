using Common.Entity;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService :IService<UserDto>
    {
        public Task<UserDto> GetUserByEmailAndPassword(string email,string password);
        //public Task RemoveFavorite(int recipeId, int userId);
        //public Task AddFavorite(int recipeId, int userId);
        public Task<bool> IsEmailExist(string email);


    }
}
