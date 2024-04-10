using Microsoft.EntityFrameworkCore;
using Repository.Entity;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly IContext _context;
        public CommentRepository(IContext context)
        {
            _context = context;
        }
        //public async Task AddItemAsync(Comment item)
        //{
        //    await _context.Comments.AddAsync(item);
        //    await _context.save();
        //}
        public async Task<Comment> AddItemAsync(Comment item)
        {
            Comment c = item;
            await _context.Comments.AddAsync(c);
            await this._context.save();
            return c;
        }
        public async Task DeleteAsync(int id)
        {
            _context.Comments.Remove(await GetAsyncById(id));
            await _context.save();
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetAsyncById(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Comment> UpdateAsync(int id, Comment item)
        {
            var comment = await GetAsyncById(id);
            if (comment.content != null) comment.content = item.content;
            if (comment.UserId != null) comment.UserId = item.UserId;
            if (comment.commentDate != DateTime.MinValue) comment.commentDate = item.commentDate;
            if (comment.replyToId != 0) comment.replyToId = item.replyToId;
            if (comment.replyToRecipe != null) comment.replyToRecipe = item.replyToRecipe;

            await _context.save();
            return comment;
        }


    }
}
