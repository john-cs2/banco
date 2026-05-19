namespace BancoConsola.Entidades
{
    public class Transaccion
    {
        public string NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public double Monto { get; set; }

        public Transaccion(string numeroCuenta, string tipo, double monto)
        {
            NumeroCuenta = numeroCuenta;
            Tipo = tipo;
            Monto = monto;
        }
    }
}