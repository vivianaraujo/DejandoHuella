using DejandoHuellaW10.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DejandoHuellaW10.Database
{
    public class EventoParse
    {
        public async void insertEvento(Eventos e)
        {

            ParseObject evento = new ParseObject("Evento");
            evento["fecha"] = e.Fecha;
            evento["hora"] = e.Hora;
            evento["lugar"] = e.Lugar;
            evento["descripcion"] = e.Descripcion;
            //evento["foto"] = e.Foto;
            evento["nombre"] = e.Nombre;
            // evento["id_fundacion"] = e.Id_Fundacion;
            await evento.SaveAsync();
        }
        public async void updateEvento(Eventos evento)
        {
            ParseObject e = await EventoById(evento.ObjectId);
            e["fecha"] = evento.Fecha;

            e["lugar"] = evento.Lugar;
            e["nombre"] = evento.Nombre;
            e["descripcion"] = evento.Descripcion;
            e["hora"] = evento.Hora;
            //e["foto"] = evento.Foto;
            await e.SaveAsync();

        }

        public async Task<ParseObject> EventoById(string id)
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Evento");
            ParseObject evento = await query.GetAsync(id);
            return evento;
        }

        //public async void deleteEvento(string objectId)
        //{

        //}
        

        public async Task<IEnumerable<ParseObject>> AllEventos()
        {
            var query = from eventos in ParseObject.GetQuery("Evento")
                        orderby eventos.CreatedAt descending
                        select eventos;
            var comments = await query.FindAsync();
            return comments;

        }


    }
}
