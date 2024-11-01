using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Competicao.Models
{
    public class Competicao
    {
        public int CompeticaoId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public int ModalidadeId { get; set; }
        public Modalidade Modalidade { get; set; }

        // Relacionamento com as equipes
        public ICollection<Equipe> Equipes { get; set; } = new List<Equipe>();

        // Outros campos e propriedades, se necessário
        public string TipoTorneio { get; set; }
    }
}
