using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Competicao.Models
{

    public class Equipe
    {
        [Key]
        public int EquipeId { get; set; }  // ID único da equipe

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }  // Nome da equipe

        public int CompeticaoId { get; set; }  // Referência à competição

        // Propriedade de navegação para Competicao
        public virtual Competicao Competicao { get; set; }  

        // Propriedade de navegação para jogadores, se houver
        public virtual ICollection<Atleta> Atletas { get; set; }  
    }
}
