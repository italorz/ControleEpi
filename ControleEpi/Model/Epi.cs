namespace ControleEpi.Model
{
    public class Epi
    {
        public int EpiId { get; set; }
        public string? EpiName { get; set; }
        public string? EpiDescricao { get; set; }
        public int EpiValidade { get; set; }

        public ICollection<ListaEpi>? listaEpis {  get; set; } = new List<ListaEpi>();


    }
}
