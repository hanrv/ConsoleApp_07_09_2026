using ConsoleApp_07_09_2026.Interfaces;

namespace ConsoleApp_07_09_2026.Clases
{
    /// <summary>
    /// Procesa pagos con tarjeta de crédito.
    /// PRINCIPIO DIP (Dependency Inversion Principle): Depende de ILectorConsola, no de Console directamente.
    /// Esto permite cambiar la fuente de entrada sin modificar esta clase.
    /// </summary>
    public class PagoTarjeta : IPago
    {
        private readonly IEntradaConsola _entradaConsola;
        private readonly ISalidaConsola _salidaConsola;

        public PagoTarjeta(IEntradaConsola entradaConsola, ISalidaConsola salidaConsola)
        {
            _entradaConsola = entradaConsola;
            _salidaConsola = salidaConsola;
        }

        public bool ProcesarPago(decimal monto)
        {
            _salidaConsola.EscribirLinea("\n  ─────────────── PAGO CON TARJETA ───────────────");
            _salidaConsola.EscribirLinea($"  Total del pedido: S/{monto:F2}");
            _salidaConsola.Escribir("  Número de tarjeta (16 dígitos): ");
            string tarjeta = _entradaConsola.LeerLinea();

            if (tarjeta.Length == 16)
            {
                _salidaConsola.EscribirLinea("  Procesando pago seguro...");
                _salidaConsola.EscribirLinea("  ✓ Transacción autorizada.");
                return true;
            }

            _salidaConsola.EscribirLinea("  ⚠ El número de tarjeta debe contener 16 dígitos.");
            return false;
        }
    }
}