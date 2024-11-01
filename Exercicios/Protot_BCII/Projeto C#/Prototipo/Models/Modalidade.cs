using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Competicao.Models
{
    public class Modalidade
    {
        [Key]
        public int ModalidadeId { get; set; }  // ID �nico da modalidade

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }// Nome da modalidade

        // Propriedade de navega��o para competi��es
        public virtual ICollection<Competicao> Competicoes { get; set; } = new List<Competicao>();
    }
}
