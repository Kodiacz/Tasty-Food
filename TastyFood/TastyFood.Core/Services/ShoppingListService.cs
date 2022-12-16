namespace TastyFood.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using TastyFood.Core.Contracts;
    using TastyFood.Core.Models.IngredientModels;
    using TastyFood.Core.Models.RecipeModels;
    using TastyFood.Core.Models.ShoppingListModels;
    using TastyFood.Exceptions;
    using TastyFood.Infrastructure.Data.Common;
    using TastyFood.Infrastructure.Data.Entities;

    public class ShoppingListService : IShoppingListService
    {
        private readonly IRepository repo;

        private readonly IGuard guard;

        public ShoppingListService(IRepository repo,
                                   IGuard guard)
        {
            this.repo = repo;
            this.guard = guard;
        }

        /// <summary>
        /// Creates a ShoppingListViewModel and asigns its properties with the DetailRecipeViewModel 
        /// that is passed as a parametar
        /// </summary>
        /// <param name="model">parameter object of type DetailRecipeViewModel</param>
        /// <param name="currentUserId">parameter of type string which contains the current user id</param>
        /// <param name="currentUserName">parameter of type string which contains the current user username</param>
        /// <returns>returns object of type CreateShoppingListViewModel</returns>
        public CreateShoppingListViewModel BindShoppingListViewModel(DetailRecipeViewModel model, string currentUserId, string currentUserName)
        {
            return new CreateShoppingListViewModel
            {
                Name = model.Title,
                Ingredients = model.IngredientsOutput.Select(i => new IngredientViewModel
                {
                    Product = i.Split(" - ")[0],
                    Quantity = i.Split(" - ")[1],
                }).ToList(),
                OwnerUserId = currentUserId
            };
        }

        /// <summary>
        /// Creates a ShoppingList entity and assigns its properties from the 
        /// model of type CreateShoppingListViewModel that is passed as a parameter
        /// </summary>
        /// <param name="model">parameter object of type CreateShoppingListViewModel</param>
        /// <param name="recipeId">parameter of type int that contains the id of a Recipe entity</param>
        /// <returns></returns>
        public async Task CreateShoppintListAsync(CreateShoppingListViewModel model, int recipeId)
        {
            var ingredientsEntities = this.repo.All<Ingredient>()
                .Where(i => i.RecipeId == recipeId).ToHashSet();

            ShoppingList shoppingEntity;

            if (ingredientsEntities.All(i => i.ShoppingListId != null))
            {
                shoppingEntity = this.repo.All<ShoppingList>()
                    .Where(sl => sl.Ingredients.All(i => i.ShoppingListId == sl.Id))
                    .First();

                shoppingEntity.IsActive = true;
            }
            else
            {
                shoppingEntity = new ShoppingList()
                {
                    Name = model.Name,
                    UserId = model.OwnerUserId,
                };

                foreach (var recipe in ingredientsEntities)
                {
                    shoppingEntity.Ingredients.Add(recipe);
                }

                await this.repo.AddAsync(shoppingEntity);
            }

            await this.repo.SaveChangesAsync();
        }

        /// <summary>
        /// Gets the owner of the recipe 
        /// </summary>
        /// <param name="recipeId">parameter of type int that contains the id of the Recipe entity</param>
        /// <returns>returns an object of type ApplicationUser</returns>
        public ApplicationUser GetOwnerOfRecipe(int recipeId)
        {
            ApplicationUser recipeOwner = this.repo.AllReadonly<ApplicationUser>()
                .Where(au => au.OwnRecipes.Any(or => or.Id == recipeId))
                .FirstOrDefault()!;

            return recipeOwner;
        }

        /// <summary>
        /// Gets the id of the current user ShoppingList
        /// </summary>
        /// <param name="currentUser">parameter of type string that contains the id of the current user</param>
        /// <returns>returns a</returns>
        public int? GetCurrentUserShoppingListId(string currentUser, int currentRecipeId)
        {
            return this.repo
                .AllReadonly<ShoppingList>()
                .Where(sl => sl.UserId == currentUser && sl.Ingredients.All(i => i.RecipeId == currentRecipeId))
                .FirstOrDefault()
                ?.Id ?? null;
        }

        /// <summary>
        /// Deleting by marking the entity as deleted, which means that the property 
        /// IsActive equals false
        /// </summary>
        /// <param name="shoppingListId">parameter of type in which contains the ID of the current recipe</param>
        public void DeleteSoftShoppingList(int? shoppingListId)
        {
            ShoppingList? shoppingListEntity = this.repo.All<ShoppingList>()
                .Where(sl => sl.Id == shoppingListId)
                ?.FirstOrDefault() ?? null;

            guard.GuardAgainstNull(shoppingListEntity, $"The {nameof(ShoppingList)} with ID {shoppingListId} does not exist");
            guard.GuardAgainstDeletedEntity(shoppingListEntity!.IsActive, $"The {nameof(ShoppingList)} with ID {shoppingListId} is already deleted");

            shoppingListEntity.IsActive = false;
        }
    }
}
