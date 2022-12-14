namespace TastyFood.Core.Models.RecipeModels
{
    public class AllRecipeViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string OwnerId { get; set; }

        public List<string> UserFavoritesId { get; set; }
    }
}
