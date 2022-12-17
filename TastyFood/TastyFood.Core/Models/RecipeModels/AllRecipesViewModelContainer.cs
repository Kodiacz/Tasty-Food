namespace TastyFood.Core.Models.RecipeModels
{
    public class AllRecipesViewModelContainer
    {
        public AllRecipesViewModelContainer()
        {
            this.RecipeModels = new List<AllRecipeViewModel>();
        }

        public IEnumerable<AllRecipeViewModel> RecipeModels { get; set; }

        public FilterForAllRecipes FilterForRecipes { get; set; }
    }
}
