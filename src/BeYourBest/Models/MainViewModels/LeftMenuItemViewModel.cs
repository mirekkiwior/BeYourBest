using DAL.Enums;

namespace BeYourBest.Models.MainViewModels
{
    public class LeftMenuItemViewModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public LeftMenuElementsType Type { get; set; }
    }
}
