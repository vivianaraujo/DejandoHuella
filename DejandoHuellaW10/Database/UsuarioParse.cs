using DejandoHuellaW10.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DejandoHuellaW10.Database
{
    public class UsuarioParse
    {
        public async void insertEvento(Usuario e)
        {

            ParseObject user = new ParseObject("Usuario");
            user["nombreUsuario"] = e.UsuarioNombre;
            user["profesion"] = e.Profesion;
            user["email"] = e.Email;
            user["contrasenia"] = e.Contrasenia;
            //evento["foto"] = e.Foto;


            await user.SaveAsync();
        }
        public async void updateEvento(Usuario e)
        {
            ParseObject user = await UsuarioById(e.ObjectId);
            user["nombreUsuario"] = e.UsuarioNombre;
            user["profesion"] = e.Profesion;
            user["email"] = e.Email;
            user["contrasenia"] = e.Contrasenia;
            //evento["foto"] = e.Foto;
            await user.SaveAsync();

        }

        public async Task<ParseObject> UsuarioById(string id)
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Usuario");
            ParseObject usuario = await query.GetAsync(id);
            return usuario;
        }
    }
}
