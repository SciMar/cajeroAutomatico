using System;
using CajeroLite.Datos;
using CajeroLite.IO;
using CajeroLite.Operaciones;
using CajeroLite.Utilidades;

namespace CajeroLite.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IO.EntradaSalida.MostrarEncabezado("Bienvenido a CajeroLite");
            int indiceUsuario = -1;
            int intentos = 0;

            while (indiceUsuario == -1 && intentos < 3)
            {
                string id = IO.EntradaSalida.LeerConfidencial("Ingrese su ID:");
                string pin = IO.EntradaSalida.LeerConfidencial("Ingrese su PIN:");
                indiceUsuario = RepositorioDatos.ObtenerIndiceUsuario(id, pin);

                if (indiceUsuario == -1)
                {
                    IO.EntradaSalida.MostrarMensaje("Usuario o PIN incorrecto", true);
                    intentos++;
                }
            }

            if (indiceUsuario == -1)
            {
                IO.EntradaSalida.MostrarMensaje("Se superaron los intentos permitidos. Saliendo...", true);
                return;
            }

            Menu_Inicio(indiceUsuario);
        }

        public static void Menu_Inicio(int indice)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                IO.EntradaSalida.MostrarEncabezado("Menu principal");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Depositar");
                Console.WriteLine("3. Retirar");
                Console.WriteLine("4. Salir");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        decimal saldo = ServicioOperaciones.ConsultarSaldo(indice);
                        IO.EntradaSalida.MostrarMensaje($"Saldo disponible: {saldo:C}");
                        Helper.Pausar();
                        break;

                    case "2":
                        decimal montoDeposito = IO.EntradaSalida.CapturarEntrada<decimal>(
                            "Ingrese monto a depositar:", decimal.Parse);
                        if (ServicioOperaciones.RegistrarDeposito(indice, montoDeposito, out string msgDep))
                            IO.EntradaSalida.MostrarMensaje(msgDep);
                        else
                            IO.EntradaSalida.MostrarMensaje(msgDep, true);
                        Helper.Pausar();
                        break;

                    case "3":
                        decimal montoRetiro = IO.EntradaSalida.CapturarEntrada<decimal>(
                            "Ingrese monto a retirar:", decimal.Parse);
                        if (ServicioOperaciones.IntentarRetiro(indice, montoRetiro, out string msgRet))
                            IO.EntradaSalida.MostrarMensaje(msgRet);
                        else
                            IO.EntradaSalida.MostrarMensaje(msgRet, true);
                        Helper.Pausar();
                        break;

                    case "4":
                        salir = true;
                        IO.EntradaSalida.MostrarMensaje("Gracias por usar CajeroLite. ¡Hasta luego!");
                        break;

                    default:
                        IO.EntradaSalida.MostrarMensaje("Opción inválida", true);
                        Helper.Pausar();
                        break;
                }
            }
        }
    }
}