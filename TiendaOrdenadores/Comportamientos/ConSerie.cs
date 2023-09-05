namespace TiendaOrdenadoresA.Comportamientos
{
    public class ConSerie : ISerie
    {
        public ConSerie(string _serie)
        {
            NumeroDeSerie = _serie;
        }

        public string NumeroDeSerie { get; set; }
    }
}