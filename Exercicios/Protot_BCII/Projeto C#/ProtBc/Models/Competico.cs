using System;
using System.Collections.Generic;

namespace ProtBc.Models;

public partial class Competico
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public int ModalidadeId { get; set; }

    public virtual ICollection<Equipe> Equipes { get; set; } = new List<Equipe>();

    public virtual Modalidade Modalidade { get; set; } = null!;

    public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();
}
