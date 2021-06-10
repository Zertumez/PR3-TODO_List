using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace PR3_TODO_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Te damos la bienvenida a:");
            Console.WriteLine("  ____                    _                    _                 _       _ ");
            Console.WriteLine(@" |  _ \                  | |                  | |               | |     | |");
            Console.WriteLine(" | |_) |_   _  ___ ______| |__  _   _  ___    | |_ ___ ______ __| | ___ | |");
            Console.WriteLine(@" |  _ <| | | |/ _ \______| '_ \| | | |/ _ \   | __/ _ \______/ _` |/ _ \| |");
            Console.WriteLine(" | |_) | |_| |  __/      | |_) | |_| |  __/   | || (_) |    | (_| | (_) |_|");
            Console.WriteLine(@" |____/ \__, |\___|      |_.__/ \__, |\___|    \__\___/      \__,_|\___/(_)");
            Console.WriteLine($"         __/ |                   __/ |                                     ");
            Console.WriteLine("        |___/                   |___/                                      ");
            Console.WriteLine("");

            Console.WriteLine("¿Desea crear una lista de pendientes? Introduzca SI para crear una lista, o introduzca NO para no crear una lista y cerrar el programa.");
            string crearLista = Console.ReadLine().ToUpper();

            if (crearLista == "SI")
            {
                // Se crea la nueva lista con el método creado.
                ListaPendientes listaNueva = new ListaPendientes();

                Console.WriteLine("");
                Console.WriteLine("¡Te damos la bienvenida a tu lista!");
                Console.WriteLine("");

                string opcion = "";
                while (opcion != "9")
                {
                    opcion = "";
                    while (opcion != "1" && opcion != "2" && opcion != "3" && opcion != "4" && opcion != "5" && opcion != "6" && opcion != "7" && opcion != "9")
                    {
                        Console.WriteLine(" ________________________________________________________");
                        Console.WriteLine("| 1) Crear un pendiente.                                 |");
                        Console.WriteLine("| 2) Borrar el pendiente creado más reciente.            |");
                        Console.WriteLine("| 3) Marcar un pendiente como completado o incompleto.   |");
                        Console.WriteLine("| 4) Mostrar todos los pendientes.                       |");
                        Console.WriteLine("| 5) Mostrar los pendientes incompletos.                 |");
                        Console.WriteLine("| 6) Mostrar los pendientes completados.                 |");
                        Console.WriteLine("| 7) Exportar lista de pendientes a un archivo de texto. |");
                        Console.WriteLine("| 9) Salir                                               |");
                        Console.WriteLine("|________________________________________________________|");

                        Console.WriteLine("");
                        Console.WriteLine("Por favor selecciona una opción:");
                        opcion = Console.ReadLine();
                        Console.WriteLine("");

                        if (opcion != "1" && opcion != "2" && opcion != "3" && opcion != "4" && opcion != "5" && opcion != "6" && opcion != "7" && opcion != "9")
                        {
                            Console.WriteLine("La opción seleccionada no es correcta.");
                            Console.WriteLine("");
                        }

                    }
                    if (opcion == "1")
                    {
                        bool pendienteAñadido = false;

                        Console.WriteLine("Introduzca la descripción de su pendiente por hacer:");
                        string descripcion = Console.ReadLine();
                        Console.WriteLine("");

                        while (pendienteAñadido == false)
                        {
                            Console.WriteLine("Indique si este pendiente ya fue realizado o no.");
                            Console.WriteLine("Introduzca R para indicar si el pendiente ya está realizado, o al contrario introduzca I para indicar que este pendiente está incompleto o que no ha sido realizado todavía:");
                            string estadoDePendiente = Console.ReadLine().ToUpper();
                            Console.WriteLine("");

                            if (estadoDePendiente == "R")
                            {
                                listaNueva.RegistrarPendiente(descripcion, Estado.COMPLETADO);
                                Console.WriteLine("Su pendiente, con descripción de:");
                                Console.WriteLine("- " + listaNueva.listaDePendientes[0].descripcion + " -");
                                Console.WriteLine("Ha sido añadido exitosamente a la lista de pendientes.");
                                Console.WriteLine("");
                                pendienteAñadido = true;
                            }
                            else if (estadoDePendiente == "I")
                            {
                                listaNueva.RegistrarPendiente(descripcion, Estado.INCOMPLETO);
                                Console.WriteLine("Su pendiente, con descripción de:");
                                Console.WriteLine(listaNueva.listaDePendientes[0].descripcion);
                                Console.WriteLine("");
                                Console.WriteLine("Ha sido añadido exitosamente a la lista de pendientes.");
                                Console.WriteLine("");
                                pendienteAñadido = true;
                            }
                            else
                            {
                                Console.WriteLine("Disculpe, no pudimos reconocer ese comando, favor de verificarlo y escribirlo de nuevo.");
                                Console.WriteLine("");
                            }
                        }
                    }
                    else if (opcion == "2")
                    {
                        bool pendienteABorrar = false;
                        while (pendienteABorrar == false)
                        {
                            Console.WriteLine("¿Cuál pendiente de la lista desea eliminar?");
                            listaNueva.MostrarTodosPendientes();

                            Console.WriteLine("Elija el pendiente que desee eliminar por su numero de lista, o si presionó esta opción por accidente, introduzca el número 0:");
                            string eleccionBorrar = Console.ReadLine();
                            int eleccionBorrarInt = Int32.Parse(eleccionBorrar);

                            if (eleccionBorrarInt == 0)
                            {
                                pendienteABorrar = true;
                            }
                            else if (eleccionBorrarInt <= listaNueva.listaDePendientes.Count)
                            {
                                string descripcionPorBorrar = listaNueva.listaDePendientes[eleccionBorrarInt - 1].descripcion;
                                listaNueva.BorrarPendiente(eleccionBorrarInt - 1);
                                pendienteABorrar = true;
                                Console.WriteLine("");
                                Console.WriteLine("El pendiente con descripción: -" + descripcionPorBorrar + " - ha sido eliminado correctamente.");
                            }
                            else
                            {
                                Console.WriteLine("El número que introdujo no corresponde a ningún pendiente en la lista, favor de introducir un número válido.");
                            }
                        }
                        Console.WriteLine("");
                    }
                    else if (opcion == "3")
                    {
                        bool pendienteAMarcar = false;
                        while (pendienteAMarcar == false)
                        {
                            Console.WriteLine("¿Cuál pendiente de la lista desea marcar?");
                            listaNueva.MostrarTodosPendientes();

                            Console.WriteLine("Elija el pendiente que desee marcar por su numero de lista, o si presionó esta opción por accidente, introduzca el número 0");
                            string eleccionMarcar = Console.ReadLine();
                            int eleccionMarcarInt = Int32.Parse(eleccionMarcar);

                            if (eleccionMarcarInt == 0)
                            {
                                pendienteAMarcar = true;
                            }
                            else if (eleccionMarcarInt <= listaNueva.listaDePendientes.Count)
                            {
                                Console.WriteLine("Para marcar este pendiente como COMPLETADO introduzca la letra C, si al contrario, desea marcarlo como INCOMPLETO, introduzca la letra I");
                                string marcar = Console.ReadLine().ToUpper();
                                bool estadoAElegir = false;
                                while (estadoAElegir == false)
                                {
                                    if (marcar == "C")
                                    {
                                        listaNueva.MarcarPendienteCompletado(eleccionMarcarInt - 1);
                                        estadoAElegir = true;
                                        Console.WriteLine("");
                                        Console.WriteLine("El pendiente que contiene de descripción: - " + listaNueva.listaDePendientes[eleccionMarcarInt - 1].descripcion + " - se ha marcado como COMPLETADO.");
                                    }
                                    else if (marcar == "I")
                                    {
                                        listaNueva.MarcarPendienteIncompleto(eleccionMarcarInt - 1);
                                        estadoAElegir = true;
                                        Console.WriteLine("");
                                        Console.WriteLine("El pendiente que contiene de descripción: - " + listaNueva.listaDePendientes[eleccionMarcarInt - 1].descripcion + " - se ha marcado como INCOMPLETO.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("La letra que introdujo no corresponde a ninguna opción dada previamente, favor de introducir una opción válida.");

                                        estadoAElegir = true;
                                    }
                                }
                                Console.WriteLine("");
                                pendienteAMarcar = true;
                            }
                            else
                            {
                                Console.WriteLine("El número que introdujo no corresponde a ningún pendiente en la lista, favor de introducir un número válido.");
                            }
                        }
                    }
                    else if (opcion == "4")
                    {
                        listaNueva.MostrarTodosPendientes();
                    }
                    else if (opcion == "5")
                    {
                        listaNueva.MostrarPendientesIncompletos();
                    }
                    else if (opcion == "6")
                    {
                        listaNueva.MostrarPendientesCompletados();
                    }
                    else if (opcion == "7")
                    {
                        Console.WriteLine("Introduzca el nombre deseado para el archivo de su lista a exportar, o si eligió esta opción por accidente, introduzca el numero 0");
                        string tituloDeArchivo = Console.ReadLine();

                        bool checarExportacion = false;
                        while (checarExportacion == false)
                        {
                            if (tituloDeArchivo == "0")
                            {
                                checarExportacion = true;
                            }
                            else
                            {
                                listaNueva.ExportarADocumentoDeTexto(tituloDeArchivo + ".txt");
                                Console.WriteLine("");
                                Console.WriteLine("¡Su lista ha sido exportada a un archivo de texto exitosamente!");
                                Console.WriteLine("");
                                checarExportacion = true;
                            }
                        }
                    }
                    else if (opcion == "9")
                    {
                        // Preguntar si desea guardar los cambios en el archivo de texto.
                        Console.WriteLine("¡Gracias por usar nuestra aplicación, esperamos que vuelva pronto!");
                    }
                    else
                    {

                    }
                }
            }
            else if (crearLista == "NO")
            {
                Console.WriteLine("");
                Console.WriteLine("¡Gracias por usar nuestra aplicación, esperamos que vuelva pronto!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Disculpe, no pudimos reconocer ese comando, favor de verificarlo y escribirlo de nuevo.");
                Console.WriteLine("");
            }
        }
    }
}
