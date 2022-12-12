using TastyFood.Core;
using TastyFood.Core.Models.RecipeModels;

namespace TastyFood.Test
{
    public class Tests
    {
        private TastyFoodDbContext inMemmoryContext;
        private Mock<IRepository> repoMock = new Mock<IRepository>();

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<TastyFoodDbContext>()
                .UseInMemoryDatabase("TastyFoodInMemmoryDB")
                .Options;

            inMemmoryContext = new TastyFoodDbContext(contextOptions);

            inMemmoryContext.Database.EnsureDeleted();
            inMemmoryContext.Database.EnsureCreated();
        }

        [Test]
        public async Task TestIfRecipeIsCreated()
        {
            var repo = new Repository(inMemmoryContext);

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
            var repo = new Repository(inMemmoryContext);
            var recipeService = new RecipeService(repo);


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
            var repo = new Repository(inMemmoryContext);
            var recipeService = new RecipeService(repo);

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

            await recipeService.DeleteSoft(255);

            Recipe deletedEntity = await repo.GetByIdAsync<Recipe>(255);
            Assert.That(deletedEntity.IsActive, Is.EqualTo(false));
        }

        [TearDown]
        public void TearDown()
        {
            inMemmoryContext.Dispose();
        }
    }
}