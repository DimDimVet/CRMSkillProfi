using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICRMSkillProfi.Interface;
using WebAPICRMSkillProfi.Models;

namespace WebAPICRMSkillProfi.Data
{
    public class ValuesBlogRepozitory : IValuesModelRepozitory<BlogItem>
    {
        private DbSqlContext _dbContext;
        public ValuesBlogRepozitory(DbSqlContext context)
        {
            this._dbContext = context;
        }

        #region Blog
        public async Task<IEnumerable<BlogItem>> GetListAsync()
        {
            await _dbContext.SaveChangesAsync();
            return _dbContext.Blogs;
        }
        public async Task AddAsync(BlogItem _blog)
        {
            using (_dbContext = new DbSqlContext())
            {
                await _dbContext.Blogs.AddAsync(_blog);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task EditAsync(string _idOldBlog, BlogItem _blogEdit)
        {
            using (_dbContext = new DbSqlContext())
            {
                IQueryable<BlogItem> _temp = _dbContext.Blogs.Where(m => m.Id == $"{_idOldBlog}");
                foreach (BlogItem item in _temp)
                {
                    item.Id = _blogEdit.Id;
                    item.DateBlog = _blogEdit.DateBlog;
                    item.TitleBlog = _blogEdit.TitleBlog;
                    item.DesriptionBlog = _blogEdit.DesriptionBlog;
                    item.Data = _blogEdit.Data;
                }
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(string _id)
        {
            using (_dbContext = new DbSqlContext())
            {
                IQueryable<BlogItem> _temp = _dbContext.Blogs.Where(p => p.Id == $"{_id}");
                foreach (BlogItem item in _temp)
                {
                    _dbContext.Blogs.Remove(item);
                }
                await _dbContext.SaveChangesAsync();
            }
        }
        #endregion
    }
}
