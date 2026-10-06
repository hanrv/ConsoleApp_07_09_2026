using System.Collections.Generic;
using ConsoleApp_07_09_2026.Clases;

namespace ConsoleApp_07_09_2026.Interfaces
{
    /// <summary>
    /// Define las operaciones de persistencia y consulta del catálogo de productos.
    /// </summary>
    public interface IProductoRepository
    {
        void AgregarOActualizar(Producto producto);
        Producto? BuscarPorNombre(string nombre);
        List<Producto> ObtenerTodos();
        List<Producto> ObtenerConPrecioMayorA(decimal precioMinimo);
        decimal CalcularTotal();
    }
}
