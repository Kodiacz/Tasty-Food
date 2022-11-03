using System.ComponentModel.DataAnnotations;
using TastyFood.Infrastructure.Data.Entities;

namespace TastyFood.Infrastructure.Data.Entities
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength()]
        public string Title { get; set; }
    }
}

//  -Title : (required maxlength 60, minimum 5)
//	-Creator(user id)(required)
//	- Description(required string)
//	- ImageUrl(required string)
//	- Ingredients(collection)(required)
//	- Directions ? (collection)
//	- Nutrtion Facts ? (collection)
//	- Details ?
