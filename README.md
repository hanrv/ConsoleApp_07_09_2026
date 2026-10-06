# Go Market Online

Aplicación de consola en C# que simula una tienda online. Permite consultar el catálogo, añadir productos al carrito manualmente o mediante una selección aleatoria y finalizar una compra simulada.


## Cómo iniciar

Desde la carpeta raíz del repositorio, ejecuta:

```bash
dotnet run --project ConsoleApp_07_09_2026.csproj
```

## Catálogo

| Nº | Producto | Categoría | Precio |
|---:|---|---|---:|
| 1 | Hamburguesa | Comidas | S/ 8.50 |
| 2 | Empanada | Comidas | S/ 5.50 |
| 3 | Fanta | Bebidas | S/ 2.50 |
| 4 | Frugos | Bebidas | S/ 3.00 |
| 5 | Cuates | Snacks | S/ 1.00 |
| 6 | Chetos | Snacks | S/ 1.20 |

## Manual de usuario

Al iniciar, la aplicación muestra el menú principal y el total actual del carrito. Introduce el número de la opción y pulsa **Enter**:
<img width="547" height="370" alt="image" src="https://github.com/user-attachments/assets/f57e0d37-819e-44b4-9c7f-0869fd8e2d40" />

1. **Explorar catálogo y añadir productos**: selecciona un producto por su número y especifica una cantidad entre 1 y 99. Si ya está en el carrito, se suman las unidades.
<img width="512" height="248" alt="image" src="https://github.com/user-attachments/assets/88e3aef4-4a3f-42ab-a7a9-5a8dc757e2cd" />

3. **Añadir selección aleatoria (LINQ)**: indica cuántos productos distintos quieres incorporar, de 1 a 6. La aplicación selecciona productos del catálogo al azar y asigna a cada uno una cantidad aleatoria de 1 a 5.
<img width="577" height="187" alt="image" src="https://github.com/user-attachments/assets/4fdf8c62-2563-4fe8-8306-ebb7d494d34f" />

4. **Ver carrito**: muestra los productos, las cantidades y el total actualizado.
<img width="542" height="233" alt="image" src="https://github.com/user-attachments/assets/f9495741-359e-46f3-8624-ffca14652b60" />

0. **Pagar y salir**: muestra el resumen del carrito, permite seleccionar el método de pago y finaliza la aplicación.
<img width="537" height="263" alt="image" src="https://github.com/user-attachments/assets/61f4d41d-67a5-4bbe-844d-c7b006671387" />

### Métodos de pago

- **Efectivo**: introduce el importe recibido. Si cubre el total, se calcula y muestra el cambio; si no, puedes volver al menú e intentarlo de nuevo.
- **Tarjeta**: la simulación solicita un número de 16 caracteres.


## Notas

- El carrito se mantiene en memoria mientras la aplicación está abierta. Al salir, se descarta.
- Las entradas fuera de rango o las opciones no reconocidas muestran un aviso para poder continuar.
- El formato de los importes decimales depende de la configuración regional del sistema.
