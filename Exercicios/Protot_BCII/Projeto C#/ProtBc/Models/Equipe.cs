using System;
using System.Collections.Generic;

namespace ProtBc.Models;

public partial class Equipe
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int? CompeticaoId { get; set; }

    public virtual Competico? Competicao { get; set; }

    public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();
}
