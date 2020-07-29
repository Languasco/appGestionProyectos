 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Entidades;
using Entidades.Acceso;
using Microsoft.VisualBasic;
using Negocio.Resultados;

namespace WebApi_GestionProyectos.Controllers.Acceso
{
    [EnableCors("*", "*", "*")]
    public class loginController : ApiController
    {
        private DsigeProyectosEntities  db = new DsigeProyectosEntities();

        public object GetLogin(int opcion, string filtro)
        {
            Resultado res = new Resultado();
            object resul = null;
            try
            {
                if (opcion == 1)
                {
                    string[] parametros = filtro.Split('|');
                    string login = parametros[0].ToString();
                    string contra = parametros[1].ToString();

                    string claveEncriptada = EncriptarClave(contra, true);            

                    var flagLogin = db.Pub_Usuarios.Count(e => e.Pub_Usua_Login == login && e.Pub_Usua_Clave == claveEncriptada);

                    if (flagLogin == 0)
                    {
                        res.ok = false;
                        res.data = "El usuario y/o contraseña no son correctos, verifique ";
                        res.totalpage = 0;
                        resul = res;
                    }
                    else
                    {
                        Menu listamenu = new Menu();
                        Pub_Usuarios objUsuario = db.Pub_Usuarios.Where(p => p.Pub_Usua_Login == login && p.Pub_Usua_Clave == claveEncriptada).SingleOrDefault();

                        //res.ok = true;
                        //res.data = (from a in db.tbl_Usuarios
                        //            where a.login_usuario == login && a.contrasenia_usuario == contra
                        //            select new
                        //            {
                        //                id_usuario = a.id_Usuario,
                        //                nombre_usuario = a.apellidos_usuario + " " + a.nombres_usuario 
                        //            }).ToList();
                        //res.totalpage = 0;
                        //resul = res;

                        listamenu.id_usuario = objUsuario.Pub_Usua_Codigo;
                        listamenu.nombre_usuario = objUsuario.Pub_Usua_Nombre; 
          

                        res.ok = true;
                        res.data = listamenu;
                        res.totalpage = 0;

                        resul = res;

                    }
                }
 
                else
                {
                    resul = "Opcion seleccionada invalida";
                }
            }
            catch (Exception ex)
            {
                res.ok = false;
                res.data = ex.Message;
                res.totalpage = 0;
                resul = res;
            }
            return resul;
        }

        public static string EncriptarClave(string cExpresion, bool bEncriptarCadena)
        {
            string cResult = "";
            string cPatron = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwwyz";
            string cEncrip = "^çºªæÆöûÿø£Ø×ƒ¬½¼¡«»ÄÅÉêèï7485912360^çºªæÆöûÿø£Ø×ƒ¬½¼¡«»ÄÅÉêèï";


            if (bEncriptarCadena == true)
            {
                cResult = CHRTRAN(cExpresion, cPatron, cEncrip);
            }
            else
            {
                cResult = CHRTRAN(cExpresion, cEncrip, cPatron);
            }

            return cResult;

        }
        
        public static string CHRTRAN(string cExpresion, string cPatronBase, string cPatronReemplazo)
        {
            string cResult = "";

            int rgChar;
            int nPosReplace;

            for (rgChar = 1; rgChar <= Strings.Len(cExpresion); rgChar++)
            {
                nPosReplace = Strings.InStr(1, cPatronBase, Strings.Mid(cExpresion, rgChar, 1));

                if (nPosReplace == 0)
                {
                    nPosReplace = rgChar;
                    cResult = cResult + Strings.Mid(cExpresion, nPosReplace, 1);
                }
                else
                {
                    if (nPosReplace > cPatronReemplazo.Length)
                    {
                        nPosReplace = rgChar;
                        cResult = cResult + Strings.Mid(cExpresion, nPosReplace, 1);
                    }
                    else
                    {
                        cResult = cResult + Strings.Mid(cPatronReemplazo, nPosReplace, 1);
                    }
                }
            }
            return cResult;
        }

    }
}
