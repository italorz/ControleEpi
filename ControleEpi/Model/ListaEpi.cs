namespace ControleEpi.Model
{
    public class ListaEpi
    {
        public int ListaEpiId { get; set; }
        public int EpiId { get; set; }
        public int ColaboradorId { get; set; }
        public Epi? Epi { get; set; }
        public Colaborador? colaborador { get; set; }
    }
}
