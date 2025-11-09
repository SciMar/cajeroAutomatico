using System;

namespace CajeroLite.IO
{
    public static class EntradaSalida
    {
        public static void MostrarMensaje(string mensaje, bool esError = false)
        {
            string tipo = esError ? "[ERROR] " : "[INFORMACIÓN] ";
            Console.WriteLine(tipo + mensaje);
        }

        public static T CapturarEntrada<T>(string mensaje, Func<string, T> validador)
        {
            while (true)
            {
                Console.Write(mensaje + " ");
                string entrada = Console.ReadLine();
                try
                {
                    return validador(entrada);
                }
                catch
                {
                    MostrarMensaje("Entrada inválida. Intenta de nuevo.", true);
                }
            }
        }

        public static string LeerConfidencial(string mensaje)
        {
            Console.Write(mensaje + " ");
            // Versión simple para depuración
            string respuesta = Console.ReadLine();
            return respuesta ?? "";
        }
        /*string respuesta = "";
        ConsoleKeyInfo tecla;
        do
        {
            tecla = Console.ReadKey(intercept: true);
            if (tecla.Key == ConsoleKey.Enter)
                break;
            if (tecla.Key == ConsoleKey.Backspace && respuesta.Length > 0)
                respuesta = respuesta.Substring(0, respuesta.Length - 1);
            else if (!char.IsControl(tecla.KeyChar))
                respuesta += tecla.KeyChar;
        } while (true);
        Console.WriteLine();
        return respuesta;
    }*/

        public static void MostrarEncabezado(string titulo)
        {
            Console.WriteLine("=== " + titulo.ToUpper() + " ===");
        }
    }
}
