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
            string respuesta = "";
            ConsoleKeyInfo tecla;

            do
            {
                tecla = Console.ReadKey(intercept: true);
                if (tecla.Key == ConsoleKey.Enter)
                    break;
                if (tecla.Key == ConsoleKey.Backspace && respuesta.Length > 0)
                {
                    respuesta = respuesta.Substring(0, respuesta.Length - 1);
                    Console.Write("\b \b"); // Borra el carácter en pantalla
                }
                else if (!char.IsControl(tecla.KeyChar))
                {
                    respuesta += tecla.KeyChar;
                    Console.Write("*"); // Oculta el carácter ingresado
                }
            } while (true);

            Console.WriteLine();
            return respuesta;
        }

        public static void MostrarEncabezado(string titulo)
        {
            Console.WriteLine("=== " + titulo.ToUpper() + " ===");
        }
    }
}


