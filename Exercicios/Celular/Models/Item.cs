using System.ComponentModel.DataAnnotations.Schema;

namespace Celular.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        [ForeignKey("CategoriaID")]

        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }
    }
}
