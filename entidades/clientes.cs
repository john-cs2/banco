namespace BancoConsola.Entidades
{
    public class Cliente
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string NumeroCuenta { get; set; }
        public double Saldo { get; set; }

        public Cliente(string cedula, string nombre, string numeroCuenta)
        {
            Cedula = cedula;
            Nombre = nombre;
            NumeroCuenta = numeroCuenta;
            Saldo = 0;
        }

        public override string ToString()
        {
            return $"[{NumeroCuenta}] {Nombre} - CC: {Cedula} - Saldo: ${Saldo}";
        }
    }
}