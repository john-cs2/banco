using BancoConsola.Entidades;

namespace BancoConsola.Estructuras
{
    public class ColaAtencion
    {
        private NodoCola frente;
        private NodoCola fin;

        public void Encolar(Cliente cliente)
        {
            NodoCola nuevo = new NodoCola(cliente);

            if (fin == null)
            {
                frente = fin = nuevo;
                return;
            }

            fin.Siguiente = nuevo;
            fin = nuevo;
        }

        public Cliente Desencolar()
        {
            if (frente == null)
                return null;

            Cliente cliente = frente.Cliente;
            frente = frente.Siguiente;

            if (frente == null)
                fin = null;

            return cliente;
        }

        public void MostrarCola()
        {
            NodoCola actual = frente;

            if (actual == null)
            {
                Console.WriteLine("No hay clientes en espera.");
                return;
            }

            while (actual != null)
            {
                Console.WriteLine(actual.Cliente.Nombre);
                actual = actual.Siguiente;
            }
        }
    }
}