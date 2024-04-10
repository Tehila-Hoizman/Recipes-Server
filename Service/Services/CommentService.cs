using AutoMapper;
using Common.Entity;
using Repository.Entity;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CommentService :ICommentService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Comment> repository;
        private readonly IRepository<User> repositoryU;

        public CommentService(IRepository<Comment> repository, IMapper mapper, IRepository<User> repositoryU)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.repositoryU = repositoryU;
        }
        public async Task<CommentDto> AddItemAsync(CommentDto item)
        {
            return mapper.Map<CommentDto>(await repository.AddItemAsync(mapper.Map<Comment>(item)));

            //await repository.AddItemAsync(mapper.Map<Comment>(item));
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<CommentDto> GetAsyncById(int id)
        {
            return mapper.Map<CommentDto>(await repository.GetAsyncById(id));
        }

        //public async Task<List<CommentDto>> GetAllAsync()
        //{
        //    return mapper.Map<List<CommentDto>>(await repository.GetAllAsync());
        //}
        public async Task<List<CommentDto>> GetAllAsync()
        {
            List<CommentDto> r = mapper.Map<List<CommentDto>>(await repository.GetAllAsync());
            foreach (var item in r)
            {
                UserDto user = mapper.Map<UserDto>(await repositoryU.GetAsyncById(item.UserId));
                item.UserName = user.FirstName+ " "+user.LastName;
                item.UrlImageUser = user.UrlImage;
            }
            return r;
        }
        public async Task<CommentDto> UpdateAsync(int id, CommentDto item)
        {
            return mapper.Map<CommentDto>(await repository.UpdateAsync(id, mapper.Map<Comment>(item)));

        }
        public async Task<String> GetUserName(int id)
        {
            UserDto user = mapper.Map<UserDto>(await repositoryU.GetAsyncById(id));
            return user.FirstName + " " + user.LastName;
        }

    }
}
