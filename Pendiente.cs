using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace PR3_TODO_List
{
    enum Estado
    {
        INCOMPLETO, 
        COMPLETADO
    }
    class Pendiente
    {
        public string descripcion;

        public Estado estadoDelPendiente;
        public string fechaHoy;

        public Pendiente(string descripcion, Estado estadoDelPendiente)
        {
            this.descripcion = descripcion;
            this.estadoDelPendiente = estadoDelPendiente;
            this.fechaHoy = DateTime.Today.ToString(new CultureInfo("es-MX").DateTimeFormat.ShortDatePattern).Replace("/", "-");
        }
    }
}