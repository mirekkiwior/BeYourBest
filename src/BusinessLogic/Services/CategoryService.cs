using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using DAL.Data;
using DAL.Models;

namespace BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddNewCategory(string name, User owner)
        {
            Category category = new Category()
            {
                Name = name,
                Owner = owner
            };

            InsertOrUpdateCategory(category);
        }

        public IEnumerable<Category> GetCategoriesByUser(string userId)
        {
            return _dbContext.Categories.Where(c => c.Owner.Id == userId);

        }

        public void UpdateCategory(Category category)
        {
            InsertOrUpdateCategory(category);
        }

        public void DeleteCategory(Category category)
        {
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }

        private void InsertOrUpdateCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }
    }
}
