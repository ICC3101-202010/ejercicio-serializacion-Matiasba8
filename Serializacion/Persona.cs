using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Serializacion
{
    [Serializable]
    class Persona : ISerializable
    {
        private string nombre;
        private string apellido;
        private string edad;

        //Lista persona
        private List<Persona> ListaPersona = new List<Persona>();

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Edad { get => edad; set => edad = value; }

        public Persona(string nombre, string apellido, string edad)
        {
            this.Nombre = nombre;
            this.Nombre = apellido;
            this.Nombre = edad;

        }
        public Persona()
        {

        }
        public void AddPerson(Persona persona)
        {
            ListaPersona.Add(persona);
        }
        public void ShowListPerson()
        {
            foreach (Persona persona in ListaPersona)
            {
                Console.WriteLine("Name: " + persona.nombre + " LastName:" + persona.Apellido + " Edad:" + persona.Edad);
            }
        }
        public List<Persona> ReturnListPerson()
        {
            return ListaPersona;
        }

        //Serializacion
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name:", Nombre);
            info.AddValue("LatName:", Apellido);
            info.AddValue("Age:", Edad);
        }
        public Persona(SerializationInfo info, StreamingContext context)
        {
            Nombre = (string)info.GetValue("Name", typeof(string));
            Apellido = (string)info.GetValue("LastName", typeof(string));
            Edad = (string)info.GetValue("Age", typeof(string));

        }
    }


}
