﻿namespace TastyFood.Core.Models.RecipeModels
{
    using System.ComponentModel.DataAnnotations;
    using TastyFood.Core.Models.DirectionModels;
    using TastyFood.Core.Models.IngredientModels;
    using static TastyFood.Infrastructure.Data.DataConstants.RecipeConstants;

    public class CreateRecipeViewModel
    {
        public CreateRecipeViewModel()
        {
            Ingredients = new List<IngredientViewModel>();
            Directions = new List<DirectionViewModel>();
        }

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(PreparationTimeMinLength, PreparationTimeMaxLength)]
        public int PreparationTime { get; set; }

        [Required]
        [Range(CookTimeMinLength, CookTimeMaxLength)]
        public int CookTime { get; set; }

        [Required]
        [Range(AdditionalTimeMinLength, AdditionalTimeMaxLength)]
        public int AdditionalTime { get; set; }

        [Required]
        [Range(ServingsQuantityMinLength, ServingsQuantityMaxLength)]
        public int ServingsQuantity { get; set; }

        public IEnumerable<IngredientViewModel> Ingredients { get; set; }

        public IEnumerable<DirectionViewModel> Directions { get; set; }
    }
}