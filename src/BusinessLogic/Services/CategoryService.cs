using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Interfaces;
using DAL.Data;
using DAL.Models;

namespace BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
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
            using (ApplicationDbContext dbContext = new ApplicationDbContext(null))
            {
                return dbContext.Categories.Where(c => c.Owner.Id == userId);
            }
        }

        public void UpdateCategory(Category category)
        {
            InsertOrUpdateCategory(category);
        }

        public void DeleteCategory(Category category)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext(null))
            {
                dbContext.Categories.Remove(category);
                dbContext.SaveChanges();
            }
        }

        private void InsertOrUpdateCategory(Category category)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext(null))
            {
                dbContext.Categories.Add(category);
                dbContext.SaveChanges();
            }
        }
    }
}
