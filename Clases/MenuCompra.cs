using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp_07_09_2026.Interfaces;

namespace ConsoleApp_07_09_2026.Clases
{
    /// <summary>
    /// Gestiona el menú de compra, el carrito y la selección del método de pago.
    /// </summary>
    public class MenuCompra
    {
        private const string OpcionSalir = "0";
        private static readonly (string Nombre, string Categoria, decimal Precio)[] Catalogo =
        {
            ("Hamburguesa", "Comidas", 8.50m),
            ("Empanada", "Comidas", 5.50m),
            ("Fanta", "Bebidas", 2.50m),
            ("Frugos", "Bebidas", 3.00m),
            ("Cuates", "Snacks", 1.00m),
            ("Chetos", "Snacks", 1.20m)
        };

        private readonly IEntradaConsola _entrada;
        private readonly ISalidaConsola _salida;
        private readonly IProductoFactory _productoFactory;
        private readonly IProductoRepository _productoRepository;

        public MenuCompra(
            IEntradaConsola entrada,
            ISalidaConsola salida,
            IProductoFactory productoFactory,
            IProductoRepository productoRepository)
        {
            _entrada = entrada;
            _salida = salida;
            _productoFactory = productoFactory;
            _productoRepository = productoRepository;
        }

        public void Ejecutar()
        {
            try
            {
                EjecutarMenu();
            }
            catch (Exception ex)
            {
                _salida.EscribirLinea($"Error inesperado: {ex.Message}");
                throw;
            }
        }

        private void EjecutarMenu()
        {
            while (true)
            {
                MostrarEncabezado();
                MostrarMenuPrincipal();

                try
                {
                    _salida.Escribir("Selecciona una opción: ");
                    string opcion = _entrada.LeerLinea().Trim();

                    switch (opcion)
                    {
                        case "1":
                            AgregarProductoManual();
                            break;
                        case "2":
                            AgregarProductosAleatorios();
                            break;
                        case "3":
                            MostrarCarrito();
                            break;
                        case OpcionSalir:
                            if (FinalizarCompra())
                            {
                                return;
                            }
                            break;
                        default:
                            throw new ArgumentException("Elige una opción disponible del menú.");
                    }
                }
                catch (ArgumentException ex)
                {
                    MostrarAviso(ex.Message);
                }
            }
        }

        private void MostrarEncabezado()
        {
            _salida.EscribirLinea("\n╔══════════════════════════════════════════════╗");
            _salida.EscribirLinea("║              GO MARKET ONLINE               ║");
            _salida.EscribirLinea("║       Calidad y ofertas para tu día          ║");
            _salida.EscribirLinea("╚══════════════════════════════════════════════╝");

            List<Producto> carrito = _productoRepository.ObtenerTodos();
            _salida.EscribirLinea($"  Carrito: {carrito.Sum(producto => producto.Cantidad)} artículo(s)  |  Total: S/{_productoRepository.CalcularTotal():F2}");
        }

        private void MostrarMenuPrincipal()
        {
            _salida.EscribirLinea("\n  ┌────────────────── TIENDA ──────────────────┐");
            _salida.EscribirLinea("  │  1. Explorar catálogo y añadir productos   │");
            _salida.EscribirLinea("  │  2. Añadir selección aleatoria (LINQ)       │");
            _salida.EscribirLinea("  │  3. Ver carrito                            │");
            _salida.EscribirLinea("  │  0. Pagar y salir                          │");
            _salida.EscribirLinea("  └───────────────────────────────────────────┘");
        }

        private void AgregarProductoManual()
        {
            MostrarCatalogo();
            int seleccion = LeerEntero("Número de producto: ", 1, Catalogo.Length);
            var productoSeleccionado = Catalogo[seleccion - 1];
            int cantidad = LeerEntero("Cantidad: ", 1, 99);
            AgregarProductoAlCarrito(productoSeleccionado.Nombre, cantidad);

            _salida.EscribirLinea($"✓ {productoSeleccionado.Nombre} × {cantidad} añadido(s) al carrito.");
        }

        private void AgregarProductosAleatorios()
        {
            _salida.EscribirLinea("\n  Carga inteligente: agrega productos y cantidades al azar.");
            int cantidadTipos = LeerEntero($"  ¿Cuántos productos distintos? (1-{Catalogo.Length}): ", 1, Catalogo.Length);

            var productosGenerados = Catalogo
                .OrderBy(_ => Random.Shared.NextDouble())
                .Take(cantidadTipos)
                .Select(producto => (producto.Nombre, Cantidad: Random.Shared.Next(1, 6)))
                .ToList();

            foreach (var producto in productosGenerados)
            {
                AgregarProductoAlCarrito(producto.Nombre, producto.Cantidad);
                _salida.EscribirLinea($"  + {producto.Nombre} × {producto.Cantidad}");
            }

            _salida.EscribirLinea("  ✓ Selección añadida. Revisa el resumen de tu carrito.");
        }

        private void MostrarCatalogo()
        {
            _salida.EscribirLinea("\n  ═══════════════════ CATÁLOGO ═══════════════════");
            _salida.EscribirLinea("  Nº  PRODUCTO           CATEGORÍA        PRECIO");
            _salida.EscribirLinea("  ───────────────────────────────────────────────");

            for (int indice = 0; indice < Catalogo.Length; indice++)
            {
                var producto = Catalogo[indice];
                _salida.EscribirLinea($"  {indice + 1,-3} {producto.Nombre,-19} {producto.Categoria,-15} S/{producto.Precio,6:F2}");
            }

            _salida.EscribirLinea("  ───────────────────────────────────────────────");
        }

        private int LeerEntero(string mensaje, int minimo, int maximo)
        {
            _salida.Escribir(mensaje);
            if (!int.TryParse(_entrada.LeerLinea(), out int valor) || valor < minimo || valor > maximo)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), $"Introduce un número entre {minimo} y {maximo}.");
            }

            return valor;
        }

        private void AgregarProductoAlCarrito(string nombre, int cantidad)
        {
            Producto? productoExistente = _productoRepository.BuscarPorNombre(nombre);
            if (productoExistente != null)
            {
                productoExistente.Cantidad += cantidad;
                return;
            }

            Producto nuevoProducto = _productoFactory.CrearProducto(nombre, cantidad);
            if (nuevoProducto == null)
            {
                throw new ArgumentException("El producto seleccionado no está disponible.", nameof(nombre));
            }

            _productoRepository.AgregarOActualizar(nuevoProducto);
        }

        private void MostrarCarrito()
        {
            List<Producto> carrito = _productoRepository.ObtenerTodos()
                .OrderBy(producto => producto.Nombre)
                .ToList();

            _salida.EscribirLinea("\n  ═══════════════════ TU CARRITO ═══════════════════");
            if (carrito.Count == 0)
            {
                _salida.EscribirLinea("  Aún no has añadido productos. ¡Explora el catálogo!");
                return;
            }

            _salida.EscribirLinea("  PRODUCTO                       CANTIDAD     SUBTOTAL");
            _salida.EscribirLinea("  ───────────────────────────────────────────────────");
            foreach (Producto producto in carrito)
            {
                _salida.EscribirLinea($"  {producto.Nombre,-30} {producto.Cantidad,5}       S/{producto.CalcularSubtotal(),7:F2}");
            }

            _salida.EscribirLinea("  ───────────────────────────────────────────────────");
            _salida.EscribirLinea($"  Total ({carrito.Sum(producto => producto.Cantidad)} artículos):                  S/{_productoRepository.CalcularTotal():F2}");
        }

        private bool FinalizarCompra()
        {
            List<Producto> carrito = _productoRepository.ObtenerTodos();
            if (carrito.Count == 0)
            {
                _salida.EscribirLinea("\nTu carrito está vacío. ¡Vuelve pronto!");
                return true;
            }

            MostrarCarrito();
            IPago formaDePago = SeleccionarMetodoDePago();
            if (!formaDePago.ProcesarPago(_productoRepository.CalcularTotal()))
            {
                MostrarAviso("No se pudo completar el pago. Puedes intentarlo de nuevo.");
                return false;
            }

            _salida.EscribirLinea("\n  ✓ ¡Gracias por tu compra! Pedido confirmado.");
            _salida.EscribirLinea("  Recibirás tu comprobante al finalizar la operación.");
            return true;
        }

        private void MostrarAviso(string mensaje)
        {
            _salida.EscribirLinea($"\n  ⚠ {mensaje}");
        }

        private IPago SeleccionarMetodoDePago()
        {
            _salida.EscribirLinea("\n  ═══════════════ MÉTODO DE PAGO ═══════════════");
            _salida.EscribirLinea("  1. Efectivo");
            _salida.EscribirLinea("  2. Tarjeta");
            _salida.Escribir("  Selecciona el método: ");
            string metodo = _entrada.LeerLinea().Trim();

            return metodo switch
            {
                "1" => new PagoEfectivo(_entrada, _salida),
                "2" => new PagoTarjeta(_entrada, _salida),
                _ => throw new ArgumentException("Metodo de pago invalido.", nameof(metodo))
            };
        }

    }
}
