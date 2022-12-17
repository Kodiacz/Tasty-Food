using TastyFood.Exceptions;

namespace TastyFood.Test
{
    public class Tests
    {
        private TastyFoodDbContext inMemmoryContext;
        private RecipeService recipeService;
        private IRepository repo;
        private Guard guard = new Guard();

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<TastyFoodDbContext>()
                .UseInMemoryDatabase("TastyFoodInMemmoryDB")
                .Options;

            inMemmoryContext = new TastyFoodDbContext(contextOptions);

            inMemmoryContext.Database.EnsureDeleted();
            inMemmoryContext.Database.EnsureCreated();

            repo = new Repository(inMemmoryContext);
            recipeService = new RecipeService(repo, guard);
        }

        [Test]
        public async Task TestIfRecipeIsCreated()
        {
            await repo.AddAsync(new Recipe()
            {
                Id = 255,
                Title = "Title",
                Description = "Description",
                ImageUrl = "test",
                PreparationTime = 1,
                CookTime = 1,
                AdditionalTime = 1,
                ServingsQuantity = 1,
                UserOwnerId = "spoawdpoakwdsuperkeyoapwodkaw",
            });

            await repo.SaveChangesAsync();

            var entity = await repo.AllReadonly<Recipe>().Where(r => r.Id == 255).FirstOrDefaultAsync();

            Assert.That(entity, Is.Not.Null);
        }

        [Test]
        public async Task TestIfRecipeIsEdited()
        {
            await repo.AddAsync(new Recipe()
            {
                Id = 255,
                Title = "Title",
                Description = "Description",
                ImageUrl = "test",
                PreparationTime = 1,
                CookTime = 1,
                AdditionalTime = 1,
                ServingsQuantity = 1,
                UserOwnerId = "spoawdpoakwdsuperkeyoapwodkaw",
            });

            await repo.SaveChangesAsync();

            await recipeService.UpdateRecipeAsync(new EditRecipeViewModel()
            {
                Title = "Edited Title",
                Description = "Description",
                ImageUrl = "test",
                PreparationTime = 1,
                CookTime = 1,
                AdditionalTime = 1,
                ServingsQuantity = 1,
            }, 255);

            Recipe editedEntity = await repo.GetByIdAsync<Recipe>(255);

            Assert.That(editedEntity.Title, Is.EqualTo("Edited Title"));
        }

        [Test]
        public async Task TestIfRecipeIsDeleted()
        {
            await repo.AddAsync(new Recipe()
            {
                Id = 255,
                Title = "Title",
                Description = "Description",
                ImageUrl = "test",
                PreparationTime = 1,
                CookTime = 1,
                AdditionalTime = 1,
                ServingsQuantity = 1,
                UserOwnerId = "spoawdpoakwdsuperkeyoapwodkaw",
            });

            await repo.SaveChangesAsync();

            await recipeService.DeleteSoftAsync(255);

            Recipe deletedEntity = await repo.GetByIdAsync<Recipe>(255);
            Assert.That(deletedEntity.IsActive, Is.EqualTo(false));
        }

        [Test]
        public async Task TestIfGetAllUserOwnRecipesAsyncDoesNotIncludeOtherUsers()
        {
            List<Recipe> recipes = new List<Recipe>()
            {
                new Recipe()
                {
                    Id = 1,
                    Title = "Title1",
                    Description = "Description1",
                    ImageUrl = "test1",
                    PreparationTime = 1,
                    CookTime = 1,
                    AdditionalTime = 1,
                    ServingsQuantity = 1,
                    UserOwnerId = "first",
                },
                new Recipe()
                {
                    Id = 2,
                    Title = "Title2",
                    Description = "Description2",
                    ImageUrl = "test2",
                    PreparationTime = 2,
                    CookTime = 2,
                    AdditionalTime = 2,
                    ServingsQuantity = 2,
                    UserOwnerId = "first",
                },
                new Recipe()
                {
                    Id = 3,
                    Title = "Title3",
                    Description = "Description3",
                    ImageUrl = "test3",
                    PreparationTime = 13,
                    CookTime = 13,
                    AdditionalTime = 13,
                    ServingsQuantity = 13,
                    UserOwnerId = "second",
                },
            };

            await repo.AddRangeAsync(recipes);
            await repo.SaveChangesAsync();

            IEnumerable<AllRecipeViewModel> ownerRecipes = await recipeService.GetAllUserOwnRecipesAsync("first");

            Assert.That(ownerRecipes.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task TestIfGetAllUserOwnRecipesAsyncDoesNotIncludeOtherUsersAndDeletedRecipes()
        {
            List<Recipe> recipes = new List<Recipe>()
            {
                new Recipe()
                {
                    Id = 1,
                    Title = "Title1",
                    Description = "Description1",
                    ImageUrl = "test1",
                    PreparationTime = 1,
                    CookTime = 1,
                    AdditionalTime = 1,
                    ServingsQuantity = 1,
                    UserOwnerId = "first",
                },
                new Recipe()
                {
                    Id = 2,
                    Title = "Title2",
                    Description = "Description2",
                    ImageUrl = "test2",
                    PreparationTime = 2,
                    CookTime = 2,
                    AdditionalTime = 2,
                    ServingsQuantity = 2,
                    UserOwnerId = "first",
                    IsActive = false,
                },
                new Recipe()
                {
                    Id = 3,
                    Title = "Title3",
                    Description = "Description3",
                    ImageUrl = "test3",
                    PreparationTime = 13,
                    CookTime = 13,
                    AdditionalTime = 13,
                    ServingsQuantity = 13,
                    UserOwnerId = "second",
                },
            };

            await repo.AddRangeAsync(recipes);
            await repo.SaveChangesAsync();

            IEnumerable<AllRecipeViewModel> ownerRecipes = await recipeService.GetAllUserOwnRecipesAsync("first");

            Assert.That(ownerRecipes.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task TestGetAllRecipesAsync()
        {
            List<Recipe> recipes = new List<Recipe>()
            {
                new Recipe()
                {
                    Id = 1,
                    Title = "Title1",
                    Description = "Description1",
                    ImageUrl = "test1",
                    PreparationTime = 1,
                    CookTime = 1,
                    AdditionalTime = 1,
                    ServingsQuantity = 1,
                    UserOwnerId = "first",
                },
                new Recipe()
                {
                    Id = 2,
                    Title = "Title2",
                    Description = "Description2",
                    ImageUrl = "test2",
                    PreparationTime = 2,
                    CookTime = 2,
                    AdditionalTime = 2,
                    ServingsQuantity = 2,
                    UserOwnerId = "first",
                    IsActive = false,
                },
                new Recipe()
                {
                    Id = 3,
                    Title = "Title3",
                    Description = "Description3",
                    ImageUrl = "test3",
                    PreparationTime = 13,
                    CookTime = 13,
                    AdditionalTime = 13,
                    ServingsQuantity = 13,
                    UserOwnerId = "second",
                },
            };

            await repo.AddRangeAsync(recipes);
            await repo.SaveChangesAsync();

            IEnumerable<AllRecipeViewModel> entityRecipes = await recipeService.GetAllRecipesAsync();

            Assert.That(entityRecipes.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task TestAddRecipeToUserFavoritesList()
        {
            ApplicationUser user = new ApplicationUser()
            {
                Id = "ID",
                FirstName = "FirstName",
                LastName = "LastName",
            };

            List<Recipe> recipes = new List<Recipe>()
            {
                new Recipe()
                {
                    Id = 1,
                    Title = "Title1",
                    Description = "Description1",
                    ImageUrl = "test1",
                    PreparationTime = 1,
                    CookTime = 1,
                    AdditionalTime = 1,
                    ServingsQuantity = 1,
                    UserOwnerId = "first",
                },
                new Recipe()
                {
                    Id = 2,
                    Title = "Title2",
                    Description = "Description2",
                    ImageUrl = "test2",
                    PreparationTime = 2,
                    CookTime = 2,
                    AdditionalTime = 2,
                    ServingsQuantity = 2,
                    UserOwnerId = "first",
                    IsActive = false,
                },
                new Recipe()
                {
                    Id = 3,
                    Title = "Title3",
                    Description = "Description3",
                    ImageUrl = "test3",
                    PreparationTime = 13,
                    CookTime = 13,
                    AdditionalTime = 13,
                    ServingsQuantity = 13,
                    UserOwnerId = "second",
                },
            };
            
            await repo.AddAsync(user);
            await repo.AddRangeAsync(recipes);
            await repo.SaveChangesAsync();

            ApplicationUser userEntity = await repo.GetByIdAsync<ApplicationUser>("ID");
            await recipeService.AddRecipeToUserFavoritesListAsync(1, "ID");

            Assert.That(userEntity.FavoriteRecipes.Count(), Is.EqualTo(1));

            Assert.ThrowsAsync<ArgumentNullException>(() => recipeService.AddRecipeToUserFavoritesListAsync(255, "ID"));
            Assert.ThrowsAsync<ArgumentNullException>(() => recipeService.AddRecipeToUserFavoritesListAsync(255, null));
        }

        [TearDown]
        public void TearDown()
        {
            inMemmoryContext.Dispose();
        }
    }
}