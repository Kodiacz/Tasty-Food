namespace TastyFood.Core.Models.RecipeModels
{
    using System.ComponentModel.DataAnnotations;

    using TastyFood.Core.Models.DirectionModels;
    using TastyFood.Infrastructure.Data.Entities;

    public class DetailRecipeViewModel
    {
        public DetailRecipeViewModel()
        {
            Ingredients = new List<CheckBoxOptionViewModel>();
            Directions = new List<DirectionViewModel>();
            IngredientsOutput = new List<string>();
        }

        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public ApplicationUser Creator { get; set; }

        public int PreparationTime { get; set; }

        public int CookTime { get; set; }

        public int AdditionalTime { get; set; }

        public int ServingsQuantity { get; set; }

        public List<CheckBoxOptionViewModel> Ingredients { get; set; }

        public List<string> IngredientsOutput { get; set; }

        public List<DirectionViewModel> Directions { get; set; }
    }
}
