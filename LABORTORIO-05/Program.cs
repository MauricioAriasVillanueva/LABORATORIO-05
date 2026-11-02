using System;

string[] codigos = new string[100];
string[] nombres = new string[100];
int[] cantidades = new int[100];
int totalProductos = 0;

    int opcion;
    do
    {
        Console.WriteLine("===== SISTEMA DE INVENTARIO =====");
        Console.WriteLine("1. Registrar Producto");
        Console.WriteLine("2. Mostrar Productos");
        Console.WriteLine("3. Buscar Producto");
        Console.WriteLine("4. Salir");

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
            Console.WriteLine("Ingrese el nombre del producto:");
            nombres[totalProductos] = Console.ReadLine() ?? "";
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
            // Lógica para buscar producto
            break;

        case 4:
            Console.WriteLine("Saliendo del sistema...");
            break;

        default:
            Console.WriteLine("Opción no válida.");
            break;

        }

    }while (opcion != 4);
