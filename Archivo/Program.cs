﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EditarArchivos
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombreArchivo = PedirNombreArchivo();
            string contenidoArchivo = LeerArchivo(nombreArchivo);

            while (true)
            {
                Console.WriteLine("\n¿Qué deseas hacer?");
                Console.WriteLine("1. Editar archivo");
                Console.WriteLine("2. Mostrar contenido del archivo");
                Console.WriteLine("3. Finalizar");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        contenidoArchivo += PedirContenidoArchivo();
                        EscribirArchivo(nombreArchivo, contenidoArchivo);
                        break;
                    case "2":
                        Console.WriteLine("Contenido del archivo:");
                        Console.WriteLine(contenidoArchivo);
                        break;
                    case "3":
                        Console.WriteLine("Programa finalizado.");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, elige una opción válida.");
                        break;
                }
            }
        }

        static string PedirNombreArchivo()
        {
            Console.Write("Ingresa un nombre para el archivo: ");
            return Console.ReadLine();
        }

        static string PedirContenidoArchivo()
        {
            Console.WriteLine("Ingresa el contenido que deseas agregar (termina con una línea en blanco):");
            string contenido = "";
            string linea;
            while (!string.IsNullOrWhiteSpace(linea = Console.ReadLine()))
            {
                contenido += linea + Environment.NewLine;
            }
            return contenido;
        }

        static void EscribirArchivo(string nombreArchivo, string contenido)
        {
            try
            {
                File.WriteAllText(nombreArchivo, contenido);
                Console.WriteLine("Archivo editado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el archivo: {ex.Message}");
            }
        }

        static string LeerArchivo(string nombreArchivo)
        {
            try
            {
                if (File.Exists(nombreArchivo))
                {
                    return File.ReadAllText(nombreArchivo);
                }
                else
                {
                    Console.WriteLine("El archivo no existe. Se creará uno nuevo.");
                    return "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al abrir el archivo: {ex.Message}");
                return "";
            }
        }
    }
}