using System.ComponentModel.DataAnnotations;

namespace ControleEpi.Model
{
    public class Colaborador
    {
        public int ColaboradorId { get; set; }

      
        public string? ColaboradorNome { get; set; }
        public DateOnly DataAdmissao { get; set; }
        public DateOnly DataDemissao { get; set; }
        public ICollection<ListaEpi> listaEpis { get; set; }

    }
}
