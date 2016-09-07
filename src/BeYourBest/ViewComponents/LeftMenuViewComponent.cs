using System.Collections.Generic;
using BeYourBest.Models.MainViewModels;
using DAL.Data;
using DAL.Enums;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeYourBest.ViewComponents
{
    public class LeftMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public LeftMenuViewComponent(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke(LeftMenuElementsType elementsType)
        {
            var items = GetItemsAsync(elementsType);
            return View(items);
        }
        private List<LeftMenuItemViewModel> GetItemsAsync(LeftMenuElementsType elementsType)
        {
            var result = new List<LeftMenuItemViewModel>();
            switch (elementsType)
            {
                case LeftMenuElementsType.Goal:
                    foreach (var goal in _dbContext.Goals)
                    {
                        result.Add(new LeftMenuItemViewModel()
                        {
                            Id = goal.Id,
                            DisplayName = goal.Title,
                            Type = LeftMenuElementsType.Category
                        });
                    };
                    break;
                case LeftMenuElementsType.Category:
                    foreach (var category in _dbContext.Categories)
                    {
                        result.Add(new LeftMenuItemViewModel()
                        {
                            Id = category.Id,
                            DisplayName = category.Name,
                            Type = LeftMenuElementsType.Category
                        });
                    }
                    break;
            }

            return result;
        }
    }
}
