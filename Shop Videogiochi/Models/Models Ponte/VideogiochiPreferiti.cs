namespace Shop_Videogiochi.Models.Models_Ponte
{
    public class VideogiochiPreferiti
    {
        private static List<dataInputId> listaVideogiochi = new List<dataInputId>();

        public VideogiochiPreferiti() { }

        public static List<dataInputId> listaVideogiochiPreferiti => listaVideogiochi;

    }
}
