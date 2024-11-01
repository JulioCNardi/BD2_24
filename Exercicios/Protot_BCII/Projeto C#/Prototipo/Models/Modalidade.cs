using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Competicao.Models
{
    public class Modalidade
    {
        [Key]
        public int ModalidadeId { get; set; }  // ID único da modalidade

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }// Nome da modalidade

        // Propriedade de navegação para competições
        public virtual ICollection<Competicao> Competicoes { get; set; } = new List<Competicao>();
    }
}
