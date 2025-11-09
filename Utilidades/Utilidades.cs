using System;
using System.Collections.Generic;

namespace CajeroLite.Utilidades
{
    public static class Helper
    {
        /// <summary>
        /// Valida si un monto es aceptable para operaciones financieras.
        /// Por defecto, debe ser mayor a cero y menor o igual a un millón.
        /// </summary>
        public static bool EsMontoValido(decimal monto, decimal minimo = 0.01m, decimal maximo = 1000000m)
        {
            return monto >= minimo && monto <= maximo;
        }

        /// <summary>
        /// Verifica si una opción ingresada está dentro de las opciones válidas del menú.
        /// </summary>
        public static bool EsOpcionValida(string opcion, IEnumerable<string> opcionesValidas)
        {
            foreach (var valida in opcionesValidas)
            {
                if (string.Equals(opcion.Trim(), valida.Trim(), StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Pausa la ejecución hasta que el usuario presione una tecla.
        /// </summary>
        public static void Pausar()
        {
            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey(intercept: true);
        }
    }
}
