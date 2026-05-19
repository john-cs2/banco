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
                Console.WriteLine("---------Registro Fallido----------");
                return false;
                
            }

            Clientes.Agregar(new Cliente(cedula, nombre, cuenta));
            Console.WriteLine("---------Registro Exitoso----------");
            return true;
        }

        public bool Depositar(string cuenta, double monto)
        {
            Cliente cliente = Clientes.BuscarPorCuenta(cuenta);

            if (cliente == null)
            {
                Console.WriteLine("---------Deposito Fallido----------");
                return false;   
            }

            cliente.Saldo += monto;

            Historial.Apilar(new Transaccion(cuenta, "Deposito", monto));
            
            Console.WriteLine($"---------Has depositado {monto} con exito----------");
            return true;
        }

        public bool Retirar(string cuenta, double monto)
        {
            Cliente cliente = Clientes.BuscarPorCuenta(cuenta);

            if (cliente == null || cliente.Saldo < monto)
            {
                Console.WriteLine("--------- Saldo insuficiente----------");
                return false;
            } 

            cliente.Saldo -= monto;

            Historial.Apilar(new Transaccion(cuenta, "Retiro", monto));
            Console.WriteLine($"---------Has retirado {monto} con exito----------");

            return true;
        }

        public bool DeshacerUltimaTransaccion()
        {
            if (Historial.EstaVacia())
               {
                Console.WriteLine("No hay transacciones recientes");
                 return false;
               }

            Transaccion t = Historial.Desapilar();

            Cliente cliente = Clientes.BuscarPorCuenta(t.NumeroCuenta);

            if (t.Tipo == "Deposito")
                {cliente.Saldo -= t.Monto;
                Console.WriteLine("deposito deshecho con exito");}
            else
               { cliente.Saldo += t.Monto;
                Console.WriteLine("retiro deshecho con exito");
               }

            return true;
        }
    }
}