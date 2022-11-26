﻿namespace TastyFood.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using TastyFood.Core.Contracts;
    using TastyFood.Core.Models.DirectionModels;
    using TastyFood.Core.Models.IngredientModels;
    using TastyFood.Core.Models.RecipeModels;
    using TastyFood.Infrastructure.Data.Common;
    using TastyFood.Infrastructure.Data.Entities;

    public class RecipeService : IRecipeService
    {
        private readonly IRepository repo;

        public RecipeService(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Creating a CreateRecipeViewModel
        /// </summary>
        /// <returns>Returns instance of CreateRecipeViewModel</returns>
        public CreateRecipeViewModel CreateRecipeViewModel()
        {
            return new CreateRecipeViewModel();
        }

        /// <summary>
        /// Creates a recipe and adds it to the database
        /// </summary>
        /// <returns></returns>
        public async Task CreateRecipeAsync(CreateRecipeViewModel model, string currentUserId)
        {
            var recipe = new Recipe()
            {
                Title = model.Title,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PreparationTime = model.PreparationTime,
                CookTime = model.CookTime,
                AdditionalTime = model.AdditionalTime,
                ServingsQuantity = model.ServingsQuantity,
                UserOwnerId = currentUserId,
            };

            foreach (var ingredient in model.Ingredients)
            {
                string modelProduct = ingredient.Product.ToLower();
                string modelQuantity = ingredient.Quantity.ToLower();

                recipe.Ingredients.Add(new Ingredient
                {
                    Product = modelProduct,
                    Quantity = modelQuantity,
                });
            }

            foreach (var modelDirection in model.Directions)
            {
                var direction = new Direction()
                {
                    Step = modelDirection.Step,
                };

                await this.repo.AddAsync(direction);

                recipe.Directions.Add(direction);
            }


            await this.repo.AddAsync(recipe);
            await this.repo.SaveChangesAsync();
        }

        /// <summary>
        /// Creates a collection of AllOwnRecipeViewModel
        /// </summary>
        /// <param name="currentUserId">The id of the current User</param>
        /// <returns>returns IEnumerable<OwnRecipesViewModel></returns>
        public async Task<IEnumerable<AllOwnRecipeViewModel>> GetAllUserOwnRecipesAsync(string currentUserId)
        {
            var model = await this.repo.All<Recipe>()
                .Include(r => r.Ingredients)
                .Include(r => r.Directions)
                .Where(r => r.IsActive && r.UserOwnerId == currentUserId)
                .Select(r => new AllOwnRecipeViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    ImageUrl = r.ImageUrl,
                })
                .ToListAsync();

            return model;
        }

        /// <summary>
        /// Gets the Recipe entity from the database and maps it to the view model
        /// </summary>
        /// <param name="recipeId">the id of the Recipe entity in the database</param>
        /// <returns>DetailRecipeViewModel with all the needed data</returns>
        public async Task<DetailRecipeViewModel> GetRecipeWithIdAsync(int recipeId, string currentUserName)
        {
            Recipe entity = await this.repo.GetByIdAsync<Recipe>(recipeId);

            return new DetailRecipeViewModel
            {
                Title = entity.Title,
                Creator = currentUserName,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                PreparationTime = entity.PreparationTime,
                CookTime = entity.CookTime,
                AdditionalTime = entity.AdditionalTime,
                ServingsQuantity = entity.ServingsQuantity,
                Ingredients = entity.Ingredients.Select(i => new IngredientViewModel
                {
                    Product = i.Product,
                    Quantity = i.Quantity,
                }).ToList(),
                Directions = entity.Directions.Select(d => new DirectionViewModel
                {
                    Step = d.Step,
                }).ToList(),
            };
        }
    }
}
