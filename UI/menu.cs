using BancoConsola.Servicios;
using BancoConsola.Entidades;

namespace BancoConsola.UI
{
    public class Menu
    {
        private Banco banco = new Banco();

        public void Mostrar()
        {
            int opcion;

            do
            {
                Console.WriteLine("\n=== BANCO ===");
                Console.WriteLine("1. Registrar cliente");
                Console.WriteLine("2. Listar clientes");
                Console.WriteLine("3. Buscar cliente");
                Console.WriteLine("4. Agregar cliente a cola");
                Console.WriteLine("5. Atender siguiente cliente");
                Console.WriteLine("6. Depositar");
                Console.WriteLine("7. Retirar");
                Console.WriteLine("8. Consultar saldo");
                Console.WriteLine("9. Deshacer transaccion");
                Console.WriteLine("10. Mostrar cola");
                Console.WriteLine("11. Total clientes");
                Console.WriteLine("12. Total dinero banco");
                Console.WriteLine("13. Salir");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarCliente();
                        break;

                    case 2:
                        banco.Clientes.MostrarTodos();
                        break;

                    case 3:
                        BuscarCliente();
                        break;

                    case 4:
                        AgregarACola();
                        break;

                    case 5:
                        AtenderCliente();
                        break;

                    case 6:
                        Depositar();
                        break;

                    case 7:
                        Retirar();
                        break;

                    case 8:
                        ConsultarSaldo();
                        break;

                    case 9:
                        Console.WriteLine(
                            banco.DeshacerUltimaTransaccion()
                            ? "Transaccion revertida"
                            : "No hay transacciones"
                        );
                        break;

                    case 10:
                        banco.Cola.MostrarCola();
                        break;

                    case 11:
                        Console.WriteLine(
                            $"Clientes: {banco.Clientes.Contar()}"
                        );
                        break;

                    case 12:
                        Console.WriteLine(
                            $"Dinero total: ${banco.Clientes.TotalDinero()}"
                        );
                        break;
                    
                        case 13:
                        Console.WriteLine("---------------Saliendo......---------------"          );
                        break;

                    default:
                        Console.WriteLine("---------------opcion invalida---------------");
                        break;
                }

            } while (opcion != 13);
        }

        private void RegistrarCliente()
        {
            Console.Write("Cedula: ");
            string cedula = Console.ReadLine();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Cuenta: ");
            string cuenta = Console.ReadLine();

            bool registrado = banco.RegistrarCliente(
                cedula,
                nombre,
                cuenta
            );

            Console.WriteLine(
                registrado
                ? "Cliente registrado"
                : "Cliente duplicado"
            );
        }

        private void BuscarCliente()
        {
            Console.Write("Cuenta: ");
            string cuenta = Console.ReadLine();

            Cliente cliente = banco.Clientes.BuscarPorCuenta(cuenta);

            Console.WriteLine(
                cliente != null
                ? cliente.ToString()
                : "No encontrado"
            );
        }

        private void AgregarACola()
        {
            Console.Write("Cuenta: ");
            string cuenta = Console.ReadLine();

            Cliente cliente = banco.Clientes.BuscarPorCuenta(cuenta);

            if (cliente == null)
            {
                Console.WriteLine("Cliente no existe");
                return;
            }

            banco.Cola.Encolar(cliente);

            Console.WriteLine("Cliente agregado a cola");
        }

        private void AtenderCliente()
        {
            Cliente cliente = banco.Cola.Desencolar();

            Console.WriteLine(
                cliente != null
                ? $"Atendiendo a {cliente.Nombre}"
                : "No hay clientes"
            );
        }

        private void Depositar()
        {
            Console.Write("Cuenta: ");
            string cuenta = Console.ReadLine();

            Console.Write("Monto: ");
            double monto = double.Parse(Console.ReadLine());

            Console.WriteLine(
                banco.Depositar(cuenta, monto)
                ? "Deposito exitoso"
                : "Error"
            );
        }

        private void Retirar()
        {
            Console.Write("Cuenta: ");
            string cuenta = Console.ReadLine();

            Console.Write("Monto: ");
            double monto = double.Parse(Console.ReadLine());

            Console.WriteLine(
                banco.Retirar(cuenta, monto)
                ? "Retiro exitoso"
                : "Fondos insuficientes"
            );
        }

        private void ConsultarSaldo()
        {
            Console.Write("Cuenta: ");
            string cuenta = Console.ReadLine();

            Cliente cliente = banco.Clientes.BuscarPorCuenta(cuenta);

            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado");
                return;
            }

            Console.WriteLine($"Saldo: ${cliente.Saldo}");
        }
    }
}