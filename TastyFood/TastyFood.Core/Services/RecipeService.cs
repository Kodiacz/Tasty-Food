namespace TastyFood.Core
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using TastyFood.Exceptions;
    using TastyFood.Core.Contracts;
    using TastyFood.Core.Models.RecipeModels;
    using TastyFood.Infrastructure.Data.Common;
    using TastyFood.Core.Models.DirectionModels;
    using TastyFood.Core.Models.IngredientModels;
    using TastyFood.Infrastructure.Data.Entities;

#pragma warning disable IDE0003
    public class RecipeService : IRecipeService
    {
        private readonly IRepository repo;
        private readonly IGuard guard;

        public RecipeService(IRepository repo, IGuard guard)
        {
            this.repo = repo;
            this.guard = guard;
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

                await repo.AddAsync(direction);

                recipe.Directions.Add(direction);
            }

            await repo.AddAsync(recipe);
            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a collection of AllRecipeViewModel which is filtered 
        /// by the User ID
        /// </summary>
        /// <param name="currentUserId">The id of the current User</param>
        /// <returns>returns an IEnumerable collection of type AllRecipeViewModel</returns>
        public async Task<IEnumerable<AllRecipeViewModel>> GetAllUserOwnRecipesAsync(string currentUserId)
        {
            var model = await repo.All<Recipe>()
                .Include(r => r.Ingredients)
                .Include(r => r.Directions)
                .Where(r => r.IsActive && r.UserOwnerId == currentUserId)
                .Select(r => new AllRecipeViewModel
                {
                    Id = r.Id,
                    OwnerId = r.UserOwnerId,
                    Title = r.Title,
                    Description = r.Description,
                    ImageUrl = r.ImageUrl,
                    UserFavoritesId = r.UsersFavoriteRecipes.Select(uf => uf!.Id).ToList()
                })
                .ToListAsync();

            return model;
        }

        /// <summary>
        /// Gets the Recipe entity from the database and maps it to the view model
        /// </summary>
        /// <param name="recipeId">the id of the Recipe entity in the database</param>
        /// <returns>returns object of type DetailRecipeViewModel</returns>
        public async Task<DetailRecipeViewModel> GetRecipeWithIdAsync(int recipeId, string currentUserName)
        {
            Recipe recipeEntity = await repo.GetByIdAsync<Recipe>(recipeId);

            guard.GuardAgainstNull(recipeEntity, $"The Recipe entity with ID {recipeId} is null");

            ApplicationUser recipeOwner = this.repo.AllReadonly<ApplicationUser>()
                .Where(au => au.Id == recipeEntity.UserOwnerId)
                .FirstOrDefault()!;

            guard.GuardAgainstNull(recipeOwner, $"The {nameof(ApplicationUser)} with ID {recipeEntity.UserOwnerId} does not exist");

            ICollection<Ingredient> ingredientsEntities = repo.All<Ingredient>().Where(i => i.RecipeId == recipeId).ToHashSet();
            ICollection<Direction> directionsEntities = repo.All<Direction>().Where(d => d.RecipeId == recipeId).ToHashSet();

            return new DetailRecipeViewModel
            {
                Id = recipeId,
                Title = recipeEntity.Title,
                Creator = recipeOwner,
                Description = recipeEntity.Description,
                ImageUrl = recipeEntity.ImageUrl,
                PreparationTime = recipeEntity.PreparationTime,
                CookTime = recipeEntity.CookTime,
                AdditionalTime = recipeEntity.AdditionalTime,
                ServingsQuantity = recipeEntity.ServingsQuantity,
                Ingredients = ingredientsEntities.Select(i => new CheckBoxOptionViewModel
                {
                    Description = $"{i.Product} - {i.Quantity}",
                    Value = $"{i.Product} - {i.Quantity}",
                }).ToList(),
                Directions = directionsEntities.Select(d => new DirectionViewModel
                {
                    Step = d.Step,
                }).ToList(),
            };
        }

        /// <summary>
        /// Creating an EditRecipeViewModel and assigning the proper values to it
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns>Returning EditRecipeViewModel</returns>
        public async Task<EditRecipeViewModel> CreateEditRecipeViewModelAsync(int recipeId)
        {
            var entity = await this.repo.AllReadonly<Recipe>()
                .Include(r => r.Ingredients)
                .Include(r => r.Directions)
                .Where(r => r.IsActive && r.Id == recipeId)
                .FirstOrDefaultAsync();

            var model = new EditRecipeViewModel
            {
                Title = entity!.Title,
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

            return model;
        }

        /// <summary>
        /// Updating the Recipe entity in the database with the EditRecipeViewModel
        /// </summary>
        /// <param name="model">EditRecipeViewModel type that contains the new data for the updated Recipe entity</param>
        /// <param name="recipeId">integer that cointains the Recipe id in the database</param>
        /// <returns></returns>
        public async Task UpdateRecipeAsync(EditRecipeViewModel model, int recipeId)
        {
            var entity = await this.repo.All<Recipe>()
                .Include(r => r.Ingredients)
                .Include(r => r.Directions)
                .Where(r => r.IsActive && r.Id == recipeId)
                .FirstOrDefaultAsync();

            entity!.Title = model.Title;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;
            entity.PreparationTime = model.PreparationTime;
            entity.CookTime = model.CookTime;
            entity.AdditionalTime = model.AdditionalTime;
            entity.ServingsQuantity = model.ServingsQuantity;

            for (int i = 0; i < model.Ingredients.Count; i++)
            {
                if (i >= entity.Ingredients.Count)
                {
                    entity.Ingredients.Add(new Ingredient
                    {
                        Product = model.Ingredients[i].Product.ToLower(),
                        Quantity = model.Ingredients[i].Quantity.ToLower(),
                    });
                }
                else
                {
                    if (model.DeletedIngredients.Count > i && entity.Ingredients.Any(ing => ing.Product == model.DeletedIngredients[i].Product))
                    {
                        Ingredient ingredientToDelete = entity.Ingredients.Where(ing => ing.Product == model.DeletedIngredients[i].Product).First();
                        model.Ingredients.Remove(model.DeletedIngredients[i]);
                        entity.Ingredients.Remove(ingredientToDelete);
                    }

                    entity.Ingredients[i].Product = model.Ingredients[i].Product;
                    entity.Ingredients[i].Quantity = model.Ingredients[i].Quantity;
                }
            }

            for (int i = 0; i < model.Directions.Count; i++)
            {
                if (i >= entity.Directions.Count)
                {
                    entity.Directions.Add(new Direction
                    {
                        Step = model.Directions[i].Step.ToLower(),
                    });
                }
                else
                {
                    if (model.DeletedDirections.Count > i && entity.Directions.Any(ing => ing.Step == model.DeletedDirections[i].Step))
                    {
                        Direction ingredientToDelete = entity.Directions.Where(ing => ing.Step == model.DeletedDirections[i].Step).First();
                        model.Directions.Remove(model.DeletedDirections[i]);
                        entity.Directions.Remove(ingredientToDelete);
                    }

                    entity.Directions[i].Step = model.Directions[i].Step;
                }
            }

            await this.repo.SaveChangesAsync();
        }

        /// <summary>
        /// Marks the entity as deleted but it doesn't really deletes the entity from the database
        /// </summary>
        /// <param name="recipeId">integer type that represents the id of the Recipe entity</param>
        /// <returns></returns>
        public async Task DeleteSoftAsync(int recipeId)
        {
            var entity = await this.repo.All<Recipe>()
                .Where(r => r.IsActive && r.Id == recipeId)
                .FirstOrDefaultAsync();

            guard.GuardAgainstNull(entity, $"The {nameof(Recipe)} with ID {recipeId} does not exist");
            guard.GuardAgainstDeletedEntity(entity!.IsActive, $"The {nameof(Recipe)} with ID {recipeId} is already deleted");

            entity!.IsActive = false;

            await this.repo.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a collection of AllRecipeViewModel with no filter
        /// </summary>
        /// <returns>returns an IEnumerable collection of type AllRecipeViewModel</returns>
        public async Task<IEnumerable<AllRecipeViewModel>> GetAllRecipesAsync()
        {
            var model = await repo.AllReadonly<Recipe>()
                .Include(r => r.Ingredients)
                .Include(r => r.Directions)
                .Where(r => r.IsActive)
                .Select(r => new AllRecipeViewModel
                {
                    Id = r.Id,
                    OwnerId = r.UserOwnerId,
                    Title = r.Title,
                    Description = r.Description,
                    ImageUrl = r.ImageUrl,
                    UserFavoritesId = r.UsersFavoriteRecipes.Select(uf => uf!.Id).ToList()
                })
                .ToListAsync();

            return model;
        }

        /// <summary>
        /// Adding the recipe into the user's favorite list
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public async Task AddRecipeToUserFavoritesListAsync(int recipeId, string currentUserId)
        {
            Recipe entity = this.repo.All<Recipe>()
                .Where(r => r.IsActive && r.Id == recipeId)
                .FirstOrDefault()!;

            guard.GuardAgainstNull(entity, $"The {nameof(Recipe)} with ID {recipeId} does not exist");

            ApplicationUser user = this.repo.All<ApplicationUser>()
                .Where(au => au.Id == currentUserId)
                .Include(au => au.FavoriteRecipes)
                .FirstOrDefault()!;

            guard.GuardAgainstNull(user, $"The {nameof(ApplicationUser)} with ID {currentUserId} does not exist");

            user.FavoriteRecipes.Add(entity);

            await this.repo.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all the recipe that contains the content of the parameter input
        /// </summary>
        /// <param name="searchBy">parameter of type string that contains the type that the recipe is going to be searched by</param>
        /// <param name="input">parameter of type string that contains the content that the recipe is going to be searched by</param>
        /// <returns>returns an IEnumerable collection of type AllRecipeViewModel</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<AllRecipeViewModel>> GetSearchedRecipesAsync(string? searchBy, string? input)
        {
            if (searchBy == "Title" && input != null)
            {
                return await this.repo.AllReadonly<Recipe>()
                        .Include(r => r.Ingredients)
                        .Include(r => r.Directions)
                        .Where(r => r.Title.ToLower().Contains(input.ToLower()))
                        .Select(r => new AllRecipeViewModel
                        {
                            Id = r.Id,
                            OwnerId = r.UserOwnerId,
                            Title = r.Title,
                            Description = r.Description,
                            ImageUrl = r.ImageUrl,
                            UserFavoritesId = r.UsersFavoriteRecipes.Select(uf => uf!.Id).ToList()
                        })
                        .ToListAsync();
            }
            else if (searchBy == "Ingredient" && input != null)
            {
                return await this.repo.AllReadonly<Recipe>()
                       .Include(r => r.Ingredients)
                       .Include(r => r.Directions)
                       .Where(r => r.Ingredients.Any(i => i.Product.ToLower().Contains(input.ToLower())))
                       .Select(r => new AllRecipeViewModel
                       {
                           Id = r.Id,
                           OwnerId = r.UserOwnerId,
                           Title = r.Title,
                           Description = r.Description,
                           ImageUrl = r.ImageUrl,
                           UserFavoritesId = r.UsersFavoriteRecipes.Select(uf => uf!.Id).ToList()
                       })
                       .ToListAsync();
            }
            else
            {
                return await this.repo.AllReadonly<Recipe>()
                        .Include(r => r.Ingredients)
                        .Include(r => r.Directions)
                        .Where(r => r.IsActive)
                        .Select(r => new AllRecipeViewModel
                        {
                            Id = r.Id,
                            OwnerId = r.UserOwnerId,
                            Title = r.Title,
                            Description = r.Description,
                            ImageUrl = r.ImageUrl,
                            UserFavoritesId = r.UsersFavoriteRecipes.Select(uf => uf!.Id).ToList()
                        })
                        .ToListAsync();
            }
        }

        /// <summary>
        /// Gets a recipes collection that is favorites recipes of the user
        /// </summary>
        /// <param name="currentUserId">parameter of type string that contains the curren user id</param>
        /// <returns>IEnumerable collection of type Recipe</returns>
        public async Task<IEnumerable<AllRecipeViewModel>> GetUserFavoriteRecipes(string currentUserId)
        {
            var user = await this.repo.AllReadonly<ApplicationUser>()
                .Include(au => au.FavoriteRecipes)
                .Where(au => au.Id == currentUserId)
                .FirstAsync();

            return user.FavoriteRecipes.Select(fr => new AllRecipeViewModel
            {
                Id = fr!.Id,
                Title = fr.Title,
                Description = fr.Description,
                ImageUrl = fr.ImageUrl,
                OwnerId = fr.UserOwnerId,
                UserFavoritesId = fr.UsersFavoriteRecipes.Select(uf => uf!.Id).ToList()
            }).ToList();
        }

        public async Task RemoveFromFavorites(int recipeId, string currentUserId)
        {
            var recipe = await this.repo.All<Recipe>()
                .Where(r => r.Id == recipeId)
                .FirstOrDefaultAsync()!;

            var user = await this.repo.All<ApplicationUser>()
                .Include(au => au.FavoriteRecipes)
                .Where(au => au.Id == currentUserId)
                .FirstOrDefaultAsync()!;

            user!.FavoriteRecipes.Remove(recipe);
            await this.repo.SaveChangesAsync();
        }
    }
}
