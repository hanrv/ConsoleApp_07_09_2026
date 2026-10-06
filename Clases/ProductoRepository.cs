using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp_07_09_2026.Interfaces;

namespace ConsoleApp_07_09_2026.Clases
{
    /// <summary>
    /// Repositorio en memoria que almacena productos por nombre y permite consultarlos con LINQ.
    /// </summary>
    public class ProductoRepository : IProductoRepository
    {
        private readonly Dictionary<string, Producto> _productos = new(StringComparer.OrdinalIgnoreCase);

        public void AgregarOActualizar(Producto producto)
        {
            ArgumentNullException.ThrowIfNull(producto);

            if (_productos.TryGetValue(producto.Nombre, out Producto? productoExistente))
            {
                productoExistente.Cantidad += producto.Cantidad;
                return;
            }

            _productos.Add(producto.Nombre, producto);
        }

        public Producto? BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre del producto no puede estar vacío.", nameof(nombre));
            }

            return _productos.GetValueOrDefault(nombre);
        }

        public List<Producto> ObtenerTodos()
        {
            return _productos.Values.ToList();
        }

        public List<Producto> ObtenerConPrecioMayorA(decimal precioMinimo)
        {
            return _productos.Values
                .Where(producto => producto.Precio > precioMinimo)
                .ToList();
        }

        public decimal CalcularTotal()
        {
            return _productos.Values.Sum(producto => producto.CalcularSubtotal());
        }
    }
}
