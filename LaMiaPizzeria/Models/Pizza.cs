using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LaMiaPizzeria.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        [MaxLength(20)]

        [Column(TypeName = "text")]
        public string Description { get; set; }
        public float Price { get; set; }

        public Pizza(int id, string image, string name, string description, float price)
        {
            Id = id;
            Image = image;
            Name = name;
            Description = description;
            Price = price;
        }

        public Pizza()
        {

        }
    }
}
