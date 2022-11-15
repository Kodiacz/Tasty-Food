using TastyFood.Core.Models.NutritionFactModels.CreateModels;

namespace TastyFood.Core.Models.IngredientModels.CreateModels
{
    public class CreateProductViewModel
    {
        public CreateCategoryViewModel Category { get; set; }

        public string Quantity { get; set; }

        public IEnumerable<CreateNutritionFactViewModel> NutritionFacts { get; set; }
    }
}