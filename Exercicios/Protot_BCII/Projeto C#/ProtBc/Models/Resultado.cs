using System;
using System.Collections.Generic;

namespace ProtBc.Models;

public partial class Resultado
{
    public int Id { get; set; }

    public int? CompeticaoId { get; set; }

    public int? EquipeId { get; set; }

    public int Pontos { get; set; }

    public virtual Competico? Competicao { get; set; }

    public virtual Equipe? Equipe { get; set; }
}
