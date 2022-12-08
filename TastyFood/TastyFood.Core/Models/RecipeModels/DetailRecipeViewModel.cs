namespace TastyFood.Core.Models.RecipeModels
{
    using System.ComponentModel.DataAnnotations;

    using TastyFood.Core.Models.DirectionModels;

    public class DetailRecipeViewModel
    {
        public DetailRecipeViewModel()
        {
            Ingredients = new List<CheckBoxOptionViewModel>();
            Directions = new List<DirectionViewModel>();
        }

        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Creator { get; set; }

        public int PreparationTime { get; set; }

        public int CookTime { get; set; }

        public int AdditionalTime { get; set; }

        public int ServingsQuantity { get; set; }

        public ICollection<CheckBoxOptionViewModel> Ingredients { get; set; }

        public ICollection<string> IngredientsOutput { get; set; }

        public ICollection<DirectionViewModel> Directions { get; set; }
    }
}
