using System.Collections.Generic;
using DAL.Models;

namespace BusinessLogic.Interfaces
{
    public interface ICategoryService
    {
        void AddNewCategory(string name, User owner);
        IEnumerable<Category> GetCategoriesByUser(string userId);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
