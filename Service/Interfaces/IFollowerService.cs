using Common.Entity;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IFollowerService:IService<FollowerDto>
    {
        public Task DeleteByRecipeUser(int userId,int recipeId);


    }
}
