using System;
using CajeroLite.Utilidades;

namespace CajeroLite.Datos
{
    public static class RepositorioDatos
    {
        public static string[] Usuarios = { "1001", "2002" };
        public static string[] Pines = { "1234", "5678" };
        public static decimal[] Saldos = { 500000m, 1200000m };

        public static bool ValidarUsuarios(string id, string pin)
        {
            for (int i = 0; i < Usuarios.Length; i++)
            {
                if (Usuarios[i] == id && Pines[i] == pin)
                    return true;
            }
            return false;
        }

        public static int ObtenerIndiceUsuario(string id, string pin)
        {
            // Limpiar espacios en blanco
            id = id?.Trim() ?? "";
            pin = pin?.Trim() ?? "";

            for (int i = 0; i < Usuarios.Length; i++)
            {
                if (Usuarios[i] == id && Pines[i] == pin)
                    return i;
            }
            return -1;
        }

        public static decimal ConsultarSaldo(int indice)
        {
            return Saldos[indice];
        }

        public static bool RegistrarDeposito(int indice, decimal monto, out string mensaje)
        {
            if (!Helper.EsMontoValido(monto))
            {
                mensaje = "Monto inválido";
                return false;
            }
            Saldos[indice] += monto;
            mensaje = $"Depósito exitoso. Nuevo saldo: {Saldos[indice]:C}";
            return true;
        }

        public static bool IntentarRetiro(int indice, decimal monto, out string mensaje)
        {
            if (!Helper.EsMontoValido(monto))
            {
                mensaje = "Monto inválido";
                return false;
            }
            if (Saldos[indice] < monto)
            {
                mensaje = "Fondos insuficientes";
                return false;
            }
            Saldos[indice] -= monto;
            mensaje = $"Retiro exitoso. Nuevo saldo: {Saldos[indice]:C}";
            return true;
        }

        public static bool ActualizarSaldo(int indice, decimal nuevoSaldo)
        {
            if (indice >= 0 && indice < Saldos.Length)
            {
                Saldos[indice] = nuevoSaldo;
                return true;
            }
            return false;
        }
    }
}