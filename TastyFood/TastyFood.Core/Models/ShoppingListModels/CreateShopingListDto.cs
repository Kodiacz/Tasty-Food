namespace TastyFood.Core.Models.ShoppingListModels
{
    using static TastyFood.Infrastructure.Data.DataConstants.ShoppingListConstants;

    public class CreateShopingListDto
    {
        public string UserId { get; set; }

        public string Name { get; set; }
    }
}
