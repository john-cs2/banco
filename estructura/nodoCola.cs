using BancoConsola.Entidades;

namespace BancoConsola.Estructuras
{
    public class NodoCola
    {
        public Cliente Cliente;
        public NodoCola Siguiente;

        public NodoCola(Cliente cliente)
        {
            Cliente = cliente;
        }
    }
}