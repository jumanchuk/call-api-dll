//***************************************************************
//                Jury Umanchuk - Octubre 2019                  *
//***************************************************************

using System;
using System.Runtime.InteropServices;
using CallApi;

namespace CallApi
{
    // Guid for the interface 
    [Guid("B1E8D75E-B746-4C21-923F-26E0361B5175")]
    // Indica que la interfaz está expuesta a COM como una interfaz dual, 
    // que permite la vinculación temprana y tardía.
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    // exposing the member
    [ComVisible(true)]
    public interface IService
    {
        [DispId(1)]
        string GetResult(String Url, String Mascara);
        string GetResult(String Url, String Mascara, String Token);
    }
    // Guid for the coclass
    [Guid("98DA6850-EEEA-4878-A3A4-8A4CB8F3FCB4")]
    // Unica forma de exponer la funcionalidad a través de interfaces implementadas explícitamente por la clase.
    [ClassInterface(ClassInterfaceType.None)]
    // Motodo A Exponer
    [ComVisible(true)]
    [ProgId("Api.Service")]
    public class Service : IService
    {
        // Constructor sin parámetros Necesario porque para instanciar un objeto COM necesitas ese constructor 
        // y aparentemente el que crea implícitamente el compilador no nos sirve. No cuesta nada: es una línea.
        public Service() { }

        public String GetResult(String Url, String Mascara)
        {
            //Instancia del gestor a utilizar
            GestorApi gestorApi = new GestorApi();
            String result = gestorApi.Get(Url, Mascara);

            return result;
        }

        public String GetResult(String Url, String Mascara, String token)
        {
            //Instancia del gestor a utilizar
            GestorApi gestorApi = new GestorApi();
            String result = gestorApi.Get(Url, Mascara, token);

            return result;
        }
    }
}
