namespace TastyFood.Core.Models.RecipeModels
{
    using TastyFood.Core.Models.IngredientModels;

    public class CheckBoxOptionViewModel
    {
        public bool IsChecked { get; set; } = false;

        public string Description { get; set; }

        public string Value { get; set; }
    }
}
