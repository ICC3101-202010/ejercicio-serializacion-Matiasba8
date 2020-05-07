using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace Serializacion
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcion;
            Persona GESTORPERSONA = new Persona();
            Console.WriteLine("Ingrese entre una de las siguientes opciones:\n1.- Crear Persona \n2.-Mostrar todas las personas \n3.-Cargar Archivo \n4.- Serializar\n5.- Salir del programa\n");
            opcion=Console.ReadLine();
            while(opcion!="5")
            {   
                if (opcion == "1")
                {
                    Console.WriteLine("Escriba el nombre de la persona a ingresar:\n");
                    string name = Console.ReadLine();
                    Console.WriteLine("Escriba el apellido de la persona a ingresar:\n");
                    string LastName = Console.ReadLine();
                    Console.WriteLine("Escriba la edad de la persona a ingresar:\n");
                    string edad = Console.ReadLine();

                    Persona persona = new Persona(name, LastName, edad);

                    GESTORPERSONA.AddPerson(persona);

                    Console.WriteLine("Persona Agregada con exito!.");
                }
                else if (opcion == "2")
                {
                    GESTORPERSONA.ShowListPerson();
                }
                else if (opcion == "3")
                {


                }
                else if (opcion == "4")
                {
                    Stream stream = File.Open("PersonData.dat", FileMode.Create);

                    BinaryFormatter bf = new BinaryFormatter();

                    foreach (Persona persona in GESTORPERSONA.ReturnListPerson())
                    {
                        bf.Serialize(stream, persona);

                    }

                    stream.Close();
                }
                Console.WriteLine("Ingrese entre una de las siguientes opciones:\n1.- Crear Persona \n2.-Mostrar todas las personas \n3.-Cargar Archivo \n4.- Serializar\n5.- Salir del programa\n");
                opcion = Console.ReadLine();
            }
            
           

        }
    }
}
