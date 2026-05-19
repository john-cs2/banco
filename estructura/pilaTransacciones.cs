using BancoConsola.Entidades;

namespace BancoConsola.Estructuras
{
    public class PilaTransacciones
    {
        private NodoPila cima;

        public void Apilar(Transaccion transaccion)
        {
            NodoPila nuevo = new NodoPila(transaccion);
            nuevo.Siguiente = cima;
            cima = nuevo;
        }

        public Transaccion Desapilar()
        {
            if (cima == null)
                return null;

            Transaccion t = cima.Transaccion;
            cima = cima.Siguiente;

            return t;
        }

        public bool EstaVacia()
        {
            return cima == null;
        }
    }
}