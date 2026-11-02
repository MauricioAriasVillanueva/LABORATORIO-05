using System;
using System.IO;

string[] codigos = new string[100];
string[] nombres = new string[100];
int[] cantidades = new int[100];
int totalProductos = 0;

if (File.Exists("datos/inventario.csv"))
{
    using (StreamReader reader = new StreamReader("datos/inventario.csv"))
    {
        string? line;
        reader.ReadLine(); // Saltar la primera línea (encabezado)
        while ((line = reader.ReadLine()) != null)
        {
            string[] partes = line.Split(',');
            if (partes.Length == 3)
            {
                codigos[totalProductos] = partes[0];
                nombres[totalProductos] = partes[1];
                if (int.TryParse(partes[2], out int cantidad))
                {
                    cantidades[totalProductos] = cantidad;
                }
                totalProductos++;
            }
        }
    }
}

    int opcion;
    do
    {
        Console.WriteLine("===== SISTEMA DE INVENTARIO =====");
        Console.WriteLine("1. Registrar Producto");
        Console.WriteLine("2. Mostrar Productos");
        Console.WriteLine("3. Buscar Producto");
        Console.WriteLine("4. Guardar Productos");
        Console.WriteLine("5. Salir");

        Console.Write("Seleccione una opción: ");

        if (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine("Opción inválida. Por favor, ingrese un número.");
            continue;
        }

        switch(opcion)
        {
        case 1:

            if (totalProductos >= codigos.Length)
            {
                Console.WriteLine("No se pueden registrar más productos. Capacidad máxima alcanzada.");
                break;
            }

            Console.WriteLine("===== REGISTRO DE PRODUCTOS =====");
            Console.WriteLine("Ingrese el código del producto:");
            codigos[totalProductos] = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(codigos[totalProductos]))
            {
                Console.WriteLine("Código inválido. No puede estar vacío.");
                break;
            }

            bool codigoExistente = false;

            for (int i = 0; i < totalProductos; i++)
            {
                if (string.Equals(codigos[i], codigos[totalProductos], StringComparison.OrdinalIgnoreCase))
                {
                    codigoExistente = true;
                    break;
                }
            }

            if (codigoExistente)
            {
                Console.WriteLine("Código de producto ya existe.");
                break;
            }

            Console.WriteLine("Ingrese el nombre del producto:");
            nombres[totalProductos] = Console.ReadLine() ?? "";


            if (string.IsNullOrWhiteSpace(nombres[totalProductos]))
            {
                Console.WriteLine("Nombre inválido. No puede estar vacío.");
                break;
            }

            Console.WriteLine("Ingrese la cantidad del producto:");

            if (!int.TryParse(Console.ReadLine(), out cantidades[totalProductos]) || cantidades[totalProductos] < 0)
            {
                Console.WriteLine("Cantidad inválida. Ingrese un número entero mayor o igual a cero.");
                break;
            }

            totalProductos++;
            break;

        case 2:
            if (totalProductos == 0)
            {
                Console.WriteLine("No hay productos registrados.");
            }
            else
            {
                Console.WriteLine("===== LISTA DE PRODUCTOS =====");
                for (int i = 0; i < totalProductos; i++)
                {
                    Console.WriteLine($"Código: {codigos[i]}");
                    Console.WriteLine($"Nombre: {nombres[i]}");
                    Console.WriteLine($"Cantidad: {cantidades[i]}");
                    Console.WriteLine();
                }
            }

            break;

        case 3:
            Console.WriteLine("===== BÚSQUEDA DE PRODUCTO =====");
            Console.WriteLine("Ingrese el código del producto a buscar:");
            string codigoBusqueda = Console.ReadLine() ?? "";
            bool encontrado = false;

            for (int i = 0; i < totalProductos; i++)
            {
                if (string.Equals(codigos[i], codigoBusqueda, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Producto encontrado:");
                    Console.WriteLine($"Código: {codigos[i]}");
                    Console.WriteLine($"Nombre: {nombres[i]}");
                    Console.WriteLine($"Cantidad: {cantidades[i]}");
                    Console.WriteLine();
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Producto no encontrado.");
            }

            break;

        case 4:
            Directory.CreateDirectory("datos");
            using (StreamWriter writer = new StreamWriter("datos/inventario.csv"))
            {
                writer.WriteLine("Código,Nombre,Cantidad");
                for (int i = 0; i < totalProductos; i++)
                {
                    writer.WriteLine($"{codigos[i]},{nombres[i]},{cantidades[i]}");
                }
            }

            Console.WriteLine("Productos guardados en inventario.csv");

            break;

        case 5:
            Console.WriteLine("Saliendo del sistema...");
            break;

        default:
            Console.WriteLine("Opción no válida.");
            break;

        }

    }while (opcion != 5);
