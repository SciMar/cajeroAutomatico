using System;
using CajeroLite.Datos;
using CajeroLite.Utilidades;

namespace CajeroLite.Operaciones
{
    public class ServicioOperaciones
    {
        public static bool RegistrarDeposito(int indice, decimal monto, out string mensaje)
        {
            if (!Helper.EsMontoValido(monto))
            {
                mensaje = "Monto inválido. Debe ser un número positivo mayor a cero.";
                return false;
            }
            decimal saldoActual = RepositorioDatos.ConsultarSaldo(indice);
            decimal nuevoSaldo = saldoActual + monto;
            RepositorioDatos.ActualizarSaldo(indice, nuevoSaldo);
            mensaje = $"Depósito exitoso. Nuevo saldo: {nuevoSaldo:C}";
            return true;
        }

        public static bool IntentarRetiro(int indice, decimal monto, out string mensaje)
        {
            if (!Helper.EsMontoValido(monto))
            {
                mensaje = "Monto inválido. Debe ser un número positivo mayor a cero.";
                return false;
            }
            decimal saldoActual = RepositorioDatos.ConsultarSaldo(indice);
            if (monto > saldoActual)
            {
                mensaje = "Fondos insuficientes para realizar el retiro.";
                return false;
            }
            decimal nuevoSaldo = saldoActual - monto;
            RepositorioDatos.ActualizarSaldo(indice, nuevoSaldo);
            mensaje = $"Retiro exitoso. Nuevo saldo: {nuevoSaldo:C}";
            return true;
        }

        public static decimal ConsultarSaldo(int indice)
        {
            return RepositorioDatos.ConsultarSaldo(indice);
        }
    }
}
