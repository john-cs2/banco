using BancoConsola.Entidades;

namespace BancoConsola.Estructuras
{
    public class NodoPila
    {
        public Transaccion Transaccion;
        public NodoPila Siguiente;

        public NodoPila(Transaccion transaccion)
        {
            Transaccion = transaccion;
        }
    }
}