using System.ComponentModel.DataAnnotations;

namespace Competicao.Models
{
    public class Atleta
    {
        [Key]
        public int AtletaId { get; set; }  // ID único do atleta

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }  // Nome do atleta

        public int EquipeId { get; set; }  // Referência à equipe

        // Propriedade de navegação para Equipe
        public virtual Equipe Equipe { get; set; }  
    }
}
