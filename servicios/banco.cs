using BancoConsola.Entidades;
using BancoConsola.Estructuras;

namespace BancoConsola.Servicios
{
    public class Banco
    {
        public ListaEnlazadaClientes Clientes = new ListaEnlazadaClientes();
        public ColaAtencion Cola = new ColaAtencion();
        public PilaTransacciones Historial = new PilaTransacciones();

        public bool RegistrarCliente(string cedula, string nombre, string cuenta)
        {
            if (Clientes.BuscarPorCedula(cedula) != null ||
                Clientes.BuscarPorCuenta(cuenta) != null)
            {
                return false;
            }

            Clientes.Agregar(new Cliente(cedula, nombre, cuenta));
            return true;
        }

        public bool Depositar(string cuenta, double monto)
        {
            Cliente cliente = Clientes.BuscarPorCuenta(cuenta);

            if (cliente == null)
                return false;

            cliente.Saldo += monto;

            Historial.Apilar(new Transaccion(cuenta, "Deposito", monto));

            return true;
        }

        public bool Retirar(string cuenta, double monto)
        {
            Cliente cliente = Clientes.BuscarPorCuenta(cuenta);

            if (cliente == null || cliente.Saldo < monto)
                return false;

            cliente.Saldo -= monto;

            Historial.Apilar(new Transaccion(cuenta, "Retiro", monto));

            return true;
        }

        public bool DeshacerUltimaTransaccion()
        {
            if (Historial.EstaVacia())
                return false;

            Transaccion t = Historial.Desapilar();

            Cliente cliente = Clientes.BuscarPorCuenta(t.NumeroCuenta);

            if (t.Tipo == "Deposito")
                cliente.Saldo -= t.Monto;
            else
                cliente.Saldo += t.Monto;

            return true;
        }
    }
}