using System.Collections.Generic;
using System.Threading.Tasks;
using BeYourBest.Models.MainViewModels;
using BusinessLogic.Interfaces;
using DAL.Enums;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeYourBest.ViewComponents
{
    public class LeftMenuViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly IGoalService _goalService;
        private readonly ICategoryService _categoryService;

        public LeftMenuViewComponent(UserManager<User> userManager,
            IGoalService goalService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _goalService = goalService;
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke(LeftMenuElementsType elementsType)
        {
            var items = GetItems(elementsType);
            return View(items);
        }

        private List<LeftMenuItemViewModel> GetItems(LeftMenuElementsType elementsType)
        {
            var result = new List<LeftMenuItemViewModel>();
            var user = GetCurrentUserAsync().Result;
            switch (elementsType)
            {
                case LeftMenuElementsType.Goal:
                    foreach (var goal in _goalService.GetGoalsByUser(user.Id))
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
                    foreach (var category in _categoryService.GetCategoriesByUser(user.Id))
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

        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
