using System;
using System.Collections.Generic;

namespace ProtBc.Models;

public partial class Modalidade
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public virtual ICollection<Competico> Competicos { get; set; } = new List<Competico>();
}
