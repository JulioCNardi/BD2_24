namespace Competicao.Models
{
    public class Modalidade
    {
        public int ModalidadeId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Competicao> Competicoes { get; set; }
    }
}
