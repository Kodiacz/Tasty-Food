namespace TastyFood.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Direction
    {
        public Direction()
        {
            this.Steps = new List<Step>();
        }

        public int Id { get; set; }

        [Required]
        public IEnumerable<Step> Steps { get; set; }
    }
}
