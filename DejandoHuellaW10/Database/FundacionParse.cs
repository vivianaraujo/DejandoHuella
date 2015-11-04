using DejandoHuellaW10.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DejandoHuellaW10.Database
{
    public class FundacionParse
    {
        public async void insertFundacion(Fundacion fundacion)
        {

            ParseObject e = new ParseObject("Fundacion");

            var stream = await fundacion.ArchivoImg.OpenAsync(FileAccessMode.Read);
            ParseFile fileP = new ParseFile(fundacion.ArchivoImg.Name, stream.AsStream());
            await fileP.SaveAsync();

            e["foto"] = fileP;
            e["nombre"] = fundacion.Nombre;
            e["direccion"] = fundacion.Direccion;
            e["descripcion"] = fundacion.Descripcion;
            e["cuenta_bancaria"] = fundacion.Cuenta_bancaria;
            e["correo"] = fundacion.Correo;
            e["telefono"] = fundacion.Telefono;
            //fundacion["id_usuario"] = e.Id_usuario;

            await e.SaveAsync(); 
        }

        public async void updateFundacion(Fundacion fundacion)
        {
            ParseObject e = await FundacionById(fundacion.ObjectId);

            var stream = await fundacion.ArchivoImg.OpenAsync(FileAccessMode.Read);
            ParseFile fileP = new ParseFile(fundacion.ArchivoImg.Name, stream.AsStream());
            await fileP.SaveAsync();

            e["foto"] = fileP;
            e["nombre"] = fundacion.Nombre;
            e["direccion"] = fundacion.Direccion;
            e["descripcion"] = fundacion.Descripcion;
            e["cuenta_bancaria"] = fundacion.Cuenta_bancaria;
            e["correo"] = fundacion.Correo;
            e["telefono"] = fundacion.Telefono;
            await e.SaveAsync();
        }

        public async Task<ParseObject> FundacionById(string id)
        {
            ParseQuery<ParseObject> query = ParseObject.GetQuery("Fundacion");
            ParseObject fundacion = await query.GetAsync(id);
            return fundacion;
        }

        public async void deleteFundacion(string objectId)
        {
            ParseObject e = await FundacionById(objectId);
            await e.DeleteAsync();
        }

        public async Task<IEnumerable<ParseObject>> AllFundaciones()
        {
            var query = from fundaciones in ParseObject.GetQuery("Fundacion")
                        orderby fundaciones.CreatedAt descending
                        select fundaciones;
            var comments = await query.FindAsync();
            return comments;

        }

        
        public async void getFundaciones() {
            var fundaciones = await this.AllFundaciones();
        }

    }
}
