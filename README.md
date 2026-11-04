# 📦 Laboratorio 05 | Sistema de Inventario en C#

[![Estado](https://img.shields.io/badge/Estado-Finalizado-brightgreen.svg)](#)
[![Lenguaje](https://img.shields.io/badge/Lenguaje-C%23-512BD4.svg)](#)
[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4.svg)](#)
[![Tema](https://img.shields.io/badge/Tema_5-Persistencia_de_Datos-blue.svg)](#)

## 📌 Descripción del proyecto

Proyecto académico desarrollado para el **Laboratorio 05 de Fundamentos de Programación** de la **Universidad Privada del Norte (UPN)**.

Consiste en un sistema de inventario por consola escrito en **C#**, que permite registrar, listar y buscar productos. El objetivo principal es demostrar la **persistencia de datos**: almacenar información en archivos para recuperarla incluso después de cerrar y volver a ejecutar el programa.

El sistema emplea **archivos de texto CSV** como almacenamiento principal y permite realizar, de forma complementaria, pruebas de escritura y lectura con **archivos binarios**.

---

## 🎯 Objetivos

- Registrar productos con **código, nombre y cantidad**.
- Mostrar y buscar productos almacenados en memoria.
- Guardar y recuperar registros mediante archivos **CSV**.
- Conservar los registros de sesiones anteriores al cargar el CSV antes de guardar nuevas incorporaciones.
- Escribir y leer registros en un archivo **binario**.
- Organizar las operaciones del programa en **métodos**.

---

## ⚙️ Funcionalidades

| Opción | Funcionalidad | Descripción |
| :---: | :--- | :--- |
| **1** | Registrar producto | Solicita código, nombre y cantidad; valida datos y evita códigos repetidos. |
| **2** | Mostrar productos | Lista los productos registrados. |
| **3** | Buscar producto | Busca por código, sin distinguir mayúsculas y minúsculas. |
| **4** | Guardar productos (CSV) | Escribe el inventario completo en `datos/inventario.csv`. |
| **5** | Guardar productos (binario) | Escribe la cantidad de registros y sus datos en `datos/inventario.bin`. |
| **6** | Leer productos (binario) | Recupera y muestra los datos binarios sin modificar el inventario principal. |
| **7** | Salir | Finaliza el programa. |

## 📂 Estructura del repositorio

```text
LABORATORIO-05/
├── LABORTORIO-05/
│   ├── Program.cs                 # Menú, validaciones, métodos y persistencia
│   └── LABORTORIO-05.csproj       # Configuración del proyecto C# (.NET 10)
└── datos/
    ├── inventario.csv            # Registros de ejemplo en texto
    └── inventario.bin            # Registros de ejemplo en formato binario
```

> **Nota:** El nombre de la carpeta y del proyecto es `LABORTORIO-05`, tal como está definido en este repositorio. Se conserva para que los comandos coincidan con los archivos reales.

### 🧩 Organización del código

En `Program.cs`, el menú utiliza un `switch` para llamar a métodos con responsabilidades específicas:

| Método | Responsabilidad |
| :--- | :--- |
| `CargarProductosCSV()` | Recuperar los datos del CSV al iniciar. |
| `MostrarMenu()` | Presentar las opciones disponibles. |
| `RegistrarProductos()` | Solicitar y validar un nuevo registro. |
| `MostrarProductos()` | Listar el inventario actual. |
| `BuscarProducto()` | Buscar un producto por su código. |
| `GuardarProductosCSV()` | Almacenar el inventario en formato CSV. |
| `GuardarProductosBinario()` | Almacenar los registros en formato binario. |
| `LeerProductosBinario()` | Leer y mostrar el contenido del archivo binario. |

Los registros se mantienen durante la ejecución mediante tres **arreglos paralelos** (`codigos`, `nombres` y `cantidades`) con capacidad para **100 productos**.

---

## 🛠️ Tecnologías utilizadas

- **Lenguaje:** C#
- **Plataforma:** .NET 10
- **Editor:** Visual Studio Code
- **Persistencia de texto:** `StreamReader` y `StreamWriter`
- **Persistencia binaria:** `BinaryReader` y `BinaryWriter`
- **Control de versiones:** Git y GitHub

## ▶️ Cómo ejecutar el proyecto

**Requisito:** tener instalado el **SDK de .NET 10**.

1. Clona este repositorio:

   ```bash
   git clone https://github.com/MauricioAriasVillanueva/LABORATORIO-05.git
   ```

2. Entra a la carpeta raíz:

   ```bash
   cd LABORATORIO-05
   ```

3. Ejecuta el proyecto **desde esa carpeta raíz**:

   ```bash
   dotnet run --project LABORTORIO-05/LABORTORIO-05.csproj
   ```

> **Importante:** El programa utiliza rutas relativas como `datos/inventario.csv`. Por eso es necesario ejecutarlo desde la raíz `LABORATORIO-05`, donde se encuentra la carpeta `datos`.

## 💾 ¿Cómo funciona la persistencia?

### Archivo de texto: CSV

El programa lee `datos/inventario.csv` al comenzar y carga los productos en los arreglos. Cuando eliges la opción **4**, guarda **todo el inventario actual** en ese archivo.

Ejemplo del contenido:

```csv
Código,Nombre,Cantidad
M01,Cargador,20
M02,Mouse,15
M03,Pantalla 4K,240
```

Así, al registrar otro producto, guardar, cerrar y volver a abrir el programa, se recuperan tanto los registros anteriores como el nuevo. La escritura del CSV **reescribe el inventario completo**; no usa el modo de adición directa al final del archivo.

### Archivo binario: BIN

La opción **5** guarda primero el número de productos y luego, por cada registro, el **código** (`string`), **nombre** (`string`) y **cantidad** (`int`). La opción **6** los lee en el mismo orden y los muestra en consola.

El binario funciona como una **práctica complementaria**; el inventario principal se carga automáticamente desde el CSV.

---

## ✅ Pruebas realizadas

- Registro de productos y validación de entradas.
- Detección de códigos duplicados sin distinguir mayúsculas y minúsculas.
- Listado y búsqueda de productos.
- Guardado del CSV y recuperación de los datos al reiniciar el programa.
- Escritura y lectura del archivo binario, verificando los datos mostrados.

---

## 👨‍💻 Autor

**Mauricio Arias Villanueva**  
Estudiante de Ingeniería de Sistemas Computacionales — **Universidad Privada del Norte (UPN)**  
Curso: **Fundamentos de Programación** · **2026**

🔗 [Perfil de GitHub](https://github.com/MauricioAriasVillanueva)

---

*Repositorio académico correspondiente al Tema 5: Persistencia de Datos con Archivos de Texto y Binarios.*
