﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TastyFood.Infrastructure.Data.Entities
{
    public class ApplicationUserFavoriteRecipe
    {
        [ForeignKey(nameof(User))]
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey(nameof(FavoriteRecipe))]
        public int RecipeId { get; set; }
        public Recipe FavoriteRecipe { get; set; }
    }
}