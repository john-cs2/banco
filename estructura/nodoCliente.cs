using BancoConsola.Entidades;

namespace BancoConsola.Estructuras
{
    public class NodoCliente
    {
        public Cliente Cliente;
        public NodoCliente Siguiente;

        public NodoCliente(Cliente cliente)
        {
            Cliente = cliente;
            Siguiente = null;
        }
    }
}