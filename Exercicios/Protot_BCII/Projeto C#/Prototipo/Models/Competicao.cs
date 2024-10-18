namespace Competicao.Models
{
    public class Competicao
    {
        public int CompeticaoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public int ModalidadeId { get; set; }
        public string TipoTorneio { get; set; }

        public virtual Modalidade Modalidade { get; set; }
    }
}
