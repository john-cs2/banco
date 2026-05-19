using BancoConsola.Entidades;

namespace BancoConsola.Estructuras
{
    public class ListaEnlazadaClientes
    {
        private NodoCliente cabeza;

        public void Agregar(Cliente cliente)
        {
            NodoCliente nuevo = new NodoCliente(cliente);

            if (cabeza == null)
            {
                cabeza = nuevo;
                return;
            }

            NodoCliente actual = cabeza;

            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            actual.Siguiente = nuevo;
        }

        public Cliente BuscarPorCedula(string cedula)
        {
            NodoCliente actual = cabeza;

            while (actual != null)
            {
                if (actual.Cliente.Cedula == cedula)
                    return actual.Cliente;

                actual = actual.Siguiente;
            }

            return null;
        }

        public Cliente BuscarPorCuenta(string cuenta)
        {
            NodoCliente actual = cabeza;

            while (actual != null)
            {
                if (actual.Cliente.NumeroCuenta == cuenta)
                    return actual.Cliente;

                actual = actual.Siguiente;
            }

            return null;
        }

        public void MostrarTodos()
        {
            NodoCliente actual = cabeza;

            while (actual != null)
            {
                Console.WriteLine(actual.Cliente);
                actual = actual.Siguiente;
            }
        }

        public int Contar()
        {
            int contador = 0;
            NodoCliente actual = cabeza;

            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }

            return contador;
        }

        public double TotalDinero()
        {
            double total = 0;
            NodoCliente actual = cabeza;

            while (actual != null)
            {
                total += actual.Cliente.Saldo;
                actual = actual.Siguiente;
            }

            return total;
        }
    }
}