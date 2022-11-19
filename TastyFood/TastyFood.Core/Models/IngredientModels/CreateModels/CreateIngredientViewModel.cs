namespace TastyFood.Core.Models.IngredientModels.CreateModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateIngredientViewModel
    {
        public CreateProductViewModel Product { get; set; }


        [Range(typeof(double), "0.000", "10.000")]
        public double Quantity { get; set; }
    }
}