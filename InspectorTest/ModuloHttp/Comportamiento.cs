using System;
using System.Web;

namespace ModuloHttp
{
    public class Comportamiento : IHttpModule
    {
        private HttpApplication httpApp;

        public void Init(HttpApplication httpApp)
        {
            this.httpApp = httpApp;
            httpApp.BeginRequest += new EventHandler(OnBeginRequest);
        }

        void OnBeginRequest(object sender, EventArgs a)
        {
            HttpContext contexto = ((HttpApplication)sender).Context;
            string filePath = contexto.Request.FilePath;
            if (filePath.Equals("/About"))
            {
                // obtener data de la url
                // contexto.Request.QueryString
                
                // obtener data del post
                // contexto.Request.Form

                // obtener data de sesion
                // contexto.Session
            }
        }

        public void Dispose() { }
    }
}
