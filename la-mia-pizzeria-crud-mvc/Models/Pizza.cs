using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_crud_mvc.Models
{
    public class Pizza
    {
        [Key] public int Id { get; set; }

        [MaxLength(100)]  // AGGIUNTA se si vogliono specificare ancora di più le colonne
        public string Name { get; set; }

        [Column(TypeName = "text")]  // AGGIUNTA se si vogliono specificare ancora di più le colonne
        public string Description { get; set; }
        public int Price { get; set; }
        public string Image {  get; set; }


        public Pizza(string name, string description, int price, string image)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Image = image;
        }

        public Pizza()
        {

        }
    }
}
