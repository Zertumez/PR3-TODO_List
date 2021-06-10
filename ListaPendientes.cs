using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace PR3_TODO_List
{
    class ListaPendientes
    {
        public List<Pendiente> listaDePendientes;

        // Crear nueva lista de pendientes.
        public ListaPendientes()
        {
            listaDePendientes = new List<Pendiente>();
        }

        // Añadir o registrar un pendiente en una lista de pendientes.
        public void RegistrarPendiente(string informacion, Estado estado)
        {
            listaDePendientes.Add(new Pendiente(informacion, estado));
        }

        // Borrar un pendiente de la lista de pendientes.
        public void BorrarPendiente(int numeroPendienteBorrar)
        {
            listaDePendientes.RemoveAt(numeroPendienteBorrar);
        }

        // Marcar pendiente de la lista como completado.
        public void MarcarPendienteCompletado(int pendienteMarcarCompletado)
        {
            listaDePendientes[pendienteMarcarCompletado].estadoDelPendiente = Estado.COMPLETADO;
        }

        // Marcar pendiente de la lista como incompleto.
        public void MarcarPendienteIncompleto(int pendienteMarcarIncompleto)
        {
            listaDePendientes[pendienteMarcarIncompleto].estadoDelPendiente = Estado.INCOMPLETO;
        }

        // Mostrar todos los pendientes de la lista.
        public void MostrarTodosPendientes()
        {
            if (listaDePendientes.Count == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("La lista está vacía. ¿No quieres añadir un pendiente?");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Los pendientes que se encuentran en su lista son los siguientes:");
                for (int i = 0; i < listaDePendientes.Count; i++)
                {
                    int posicionEnLista = i + 1;
                    Console.Write(posicionEnLista + ") " + listaDePendientes[i].fechaHoy + " - ");
                    Console.WriteLine(listaDePendientes[i].descripcion);
                }
                Console.WriteLine("");
            }
        }

        // Mostrar todos los detalles de pendientes para exportar a archivo de texto.
        public void ExportarADocumentoDeTexto(string tituloParaArchivo)
        {
            using (StreamWriter sw = new StreamWriter(tituloParaArchivo))
            {
                if (listaDePendientes.Count == 0)
                {
                    sw.WriteLine("La lista está vacía. Por eso aquí te dejamos una carita feliz para recompensar todo tu esfuerzo por dejar la lista vacía.");
                    sw.WriteLine(" :^) ");
                }
                else
                {
                    sw.WriteLine("Los pendientes que se encuentran en su lista son los siguientes:");
                    sw.WriteLine("");
                    for (int i = 0; i < listaDePendientes.Count; i++)
                    {
                        int posicionEnLista = i + 1;
                        sw.Write(posicionEnLista + ") " + listaDePendientes[i].fechaHoy + " - ");
                        sw.Write(listaDePendientes[i].descripcion);
                        if (listaDePendientes[i].estadoDelPendiente == Estado.INCOMPLETO)
                        {
                            sw.WriteLine(" - Estado del pendiente: Incompleto");
                        }
                        else
                        {
                            sw.WriteLine(" - Estado del pendiente: Completado");
                        }
                    }
                    sw.WriteLine("");
                }
            }
        }

        // Mostrar solo los pendientes por hacer.
        public void MostrarPendientesIncompletos()
        {
            if (listaDePendientes.Count == 0)
            {
                Console.WriteLine("No hay pendientes incompletos en su lista, ¡buen trabajo y a descansar!.");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Los pendientes incompletos(o por hacer) que se encuentran en su lista son los siguientes:");
                for (int i = 0; i < listaDePendientes.Count; i++)
                {
                    if (listaDePendientes[i].estadoDelPendiente == Estado.INCOMPLETO)
                    {
                        int posicionEnLista = i + 1;
                        Console.Write(posicionEnLista + ") " + listaDePendientes[i].fechaHoy + " - ");
                        Console.WriteLine(listaDePendientes[i].descripcion);
                    }
                }
                Console.WriteLine("");
            }

        }

        // Mostrar solo los pendientes que ya han sido completados.
        public void MostrarPendientesCompletados()
        {
            if (listaDePendientes.Count == 0)
            {
                Console.WriteLine("No hay pendientes completados en su lista, ¡parece que es hora de ponerse las pilas!.");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Los pendientes completados(o realizados) que se encuentran en su lista son los siguientes:");
                for (int i = 0; i < listaDePendientes.Count; i++)
                {
                    if (listaDePendientes[i].estadoDelPendiente == Estado.COMPLETADO)
                    {
                        int posicionEnLista = i + 1;
                        Console.Write(posicionEnLista + ") " + listaDePendientes[i].fechaHoy + " - ");
                        Console.WriteLine(listaDePendientes[i].descripcion);
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}