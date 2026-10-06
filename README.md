<div align="center">

<img src="https://capsule-render.vercel.app/api?type=waving&color=0:512BD4,100:9B4F96&height=200&section=header&text=Go%20Market%20Online&fontSize=50&fontColor=ffffff&fontAlignY=38&desc=Tu%20tienda%20online%20simulada%20en%20consola&descAlignY=58&descSize=18" alt="Go Market Online" width="100%" />

<a href="https://learn.microsoft.com/dotnet/csharp/">
  <img src="https://img.shields.io/badge/C%23-Console%20App-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C#" />
</a>
<a href="https://dotnet.microsoft.com/">
  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET" />
</a>
<a href="https://learn.microsoft.com/dotnet/csharp/linq/">
  <img src="https://img.shields.io/badge/LINQ-Language%20Integrated%20Query-9B4F96?style=for-the-badge&logo=dotnet&logoColor=white" alt="LINQ" />
</a>
<img src="https://img.shields.io/badge/Terminal-Windows%20%7C%20macOS%20%7C%20Linux-4D4D4D?style=for-the-badge&logo=gnometerminal&logoColor=white" alt="Terminal" />

<br /><br />

<img src="https://skillicons.dev/icons?i=cs,dotnet,visualstudio,git,github&perline=5" alt="Tecnologías" />

</div>

---

## 📖 Descripción

**Go Market Online** es una aplicación de consola en **C#** que simula una tienda online. Permite:

- 📦 Consultar el catálogo de productos
- ➕ Añadir productos al carrito de forma manual
- 🎲 Añadir una selección aleatoria de productos con **LINQ**
- 💳 Finalizar una compra simulada con distintos métodos de pago

---

## 📑 Tabla de contenidos

- [🚀 Cómo iniciar](#-cómo-iniciar)
- [🏷️ Catálogo](#️-catálogo)
- [📘 Manual de usuario](#-manual-de-usuario)
- [💰 Métodos de pago](#-métodos-de-pago)
- [📝 Notas](#-notas)

---

## 🚀 Cómo iniciar

Desde la carpeta raíz del repositorio, ejecuta:

```bash
dotnet run --project ConsoleApp_07_09_2026.csproj
```

---

## 🏷️ Catálogo

| Nº | Producto | Categoría | Precio |
|:--:|:---|:---:|---:|
| 1 | 🍔 Hamburguesa | 🍽️ Comidas | S/ 8.50 |
| 2 | 🥟 Empanada | 🍽️ Comidas | S/ 5.50 |
| 3 | 🥤 Fanta | 🧃 Bebidas | S/ 2.50 |
| 4 | 🧃 Frugos | 🧃 Bebidas | S/ 3.00 |
| 5 | 🍿 Cuates | 🍟 Snacks | S/ 1.00 |
| 6 | 🌶️ Chetos | 🍟 Snacks | S/ 1.20 |

---

## 📘 Manual de usuario

Al iniciar, la aplicación muestra el **menú principal** y el **total actual del carrito**. Introduce el número de la opción y pulsa **Enter** ⌨️

<div align="center">
  <img width="547" height="370" alt="Menú principal" src="https://github.com/user-attachments/assets/f57e0d37-819e-44b4-9c7f-0869fd8e2d40" />
</div>

### 1️⃣ Explorar catálogo y añadir productos 🛍️

Selecciona un producto por su número y especifica una cantidad **entre 1 y 99**. Si el producto ya está en el carrito, se **suman** las unidades.

<div align="center">
  <img width="512" height="248" alt="Explorar catálogo" src="https://github.com/user-attachments/assets/88e3aef4-4a3f-42ab-a7a9-5a8dc757e2cd" />
</div>

### 2️⃣ Añadir selección aleatoria (LINQ) 🎲

Indica cuántos productos distintos quieres incorporar, **de 1 a 6**. La aplicación elige productos del catálogo al azar y asigna a cada uno una cantidad aleatoria **de 1 a 5**.

<div align="center">
  <img width="577" height="187" alt="Selección aleatoria" src="https://github.com/user-attachments/assets/4fdf8c62-2563-4fe8-8306-ebb7d494d34f" />
</div>

### 3️⃣ Ver carrito 🧺

Muestra los productos, las cantidades y el **total actualizado**.

<div align="center">
  <img width="542" height="233" alt="Ver carrito" src="https://github.com/user-attachments/assets/f9495741-359e-46f3-8624-ffca14652b60" />
</div>

### 0️⃣ Pagar y salir 💳

Muestra el resumen del carrito, permite seleccionar el método de pago y **finaliza la aplicación**.

<div align="center">
  <img width="537" height="263" alt="Pagar y salir" src="https://github.com/user-attachments/assets/61f4d41d-67a5-4bbe-844d-c7b006671387" />
</div>

---

## 💰 Métodos de pago

| Método | Funcionamiento |
|:---|:---|
| 💵 **Efectivo** | Introduce el importe recibido. Si cubre el total, se calcula y muestra el **cambio**; si no, puedes volver al menú e intentarlo de nuevo. |
| 💳 **Tarjeta** | La simulación solicita un número de **16 caracteres**. |

---

## 📝 Notas

> [!NOTE]
> 🧠 El carrito se mantiene **en memoria** mientras la aplicación está abierta. Al salir, se descarta.

> [!TIP]
> ⚠️ Las entradas fuera de rango o las opciones no reconocidas muestran un aviso para poder continuar.

> [!IMPORTANT]
> 🌍 El formato de los importes decimales depende de la **configuración regional** del sistema.

---

<div align="center">

Hecho con ❤️ y C# 

⭐ ¡Si te gustó el proyecto, dale una estrella!

</div>
