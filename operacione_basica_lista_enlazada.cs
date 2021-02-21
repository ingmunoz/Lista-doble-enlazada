using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 // clase nodo 
    class Nodo
    {
        // propieda de que requiere la case, tipo privado
        private int dato; // tengo un dato
        private Nodo siguiente; // un apuntador hacia sigueinte
        private Nodo atras; // un apuntador hacia atra, es doblemente enlazada

        // encasulamiento de los metodo get y set
         public int Dato
        {
            get { return dato; }// retorna un dato
            set { dato = value; }// acepta un dato y lo evalua
        }
        public Nodo Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }

        }
        public Nodo Atras
        {
            get { return atras; }
            set { atras = value; }
        }
    }

    // clase lista que tambien tendra algunos apuntadores 
    class Lista
    {
        private Nodo primero = new Nodo();// nodo actua como cabeza de la lista
        private Nodo ultimo = new Nodo(); // el apuntador ultimo en la lista

        // constructor de la clase
        public Lista()
        {
            // mientra la lista este vacia esto valores seran nulo
            primero = null;
            ultimo = null;
        }

        // el metodo inseptar nodo, el cual permitira inseptar a la lista
        public void inseptarNodo()
        {
            Nodo nuevo = new Nodo(); // crear  un nuevo nodo
            Console.Write(" Ingrese el dato que contendra en nuevo Nodo: ");
            nuevo.Dato = int.Parse(Console.ReadLine()); // tomar el valor de nuevo ingresado por el usiario

            if(primero == null) // idetificar si este es el primero
            {
                primero = nuevo; // agregar el primer nodo a la lista
                primero.Siguiente = null; // el apuntador asiguiente igual a null
                primero.Atras = null;
                ultimo = primero;
            }
            else
            {
                ultimo.Siguiente = nuevo;
                nuevo.Siguiente = null;
                nuevo.Atras = ultimo;
                ultimo = nuevo;
            }
            Console.Write("\n Nuevo nodo ingresado con exito \n");
        }
        
        // metodo para desplegar la lista del primero al ultimo
        public void DesplejarListaPU()
        {
            Nodo actual = new Nodo(); // para recorrer la lista
            actual = primero;
            while (actual != null) 
            {
                Console.WriteLine(" " + actual.Dato);
                actual = actual.Siguiente;
            }
        }
        
        // recorrer la lista del ultimo al primero
        public void DesplejarListaUp()
        {
            Nodo actual = new Nodo(); // para recorrer la lista
            actual = ultimo;
            while (actual != null) 
            {
                Console.WriteLine(" " + actual.Dato);
                actual = actual.Atras;
            }
        }

         public void buscarNodo()
        {
            Nodo actual = new Nodo();
            actual = primero;
            bool encontrado = false;
            Console.WriteLine("Ingrese el dato del nodo a buscar: ");
            int nodoBuscar = int.Parse(Console.ReadLine());
            while (actual !=null && encontrado == false)
            {
                if (actual.Dato == nodoBuscar)
                {
                    Console.WriteLine("\n Nodo con el dato ({0}) encontrado \n", actual.Dato);
                    encontrado = true;
                }
               
                actual = actual.Siguiente;
            }
            if (!encontrado)
            {
                Console.WriteLine("\n Nodo no encontrado\n");
            }
        }

            // metodo eliminar nodo
         public void EliminarNodo()
        {
            Nodo actual = new Nodo();
            Nodo anterio = new Nodo();
            anterio = null;
            actual = primero;
            bool encontrado = false;
            Console.Write(" Ingrese el dato del nodo a eliminar: ");
            int nodoBuscacado = int.Parse(Console.ReadLine());
            while (actual != null && encontrado == false)
            {
                if (actual.Dato == nodoBuscacado)
                {
                    if (actual == primero)
                    {
                        primero = primero.Siguiente;
                        primero.Atras = null;
                    }
                    else if (actual == ultimo)
                    {
                        anterio.Siguiente = null;
                        ultimo = anterio;
                    }
                    else
                    {
                        anterio.Siguiente = actual.Siguiente;
                        actual.Siguiente.Atras = anterio; 
                    }
                    Console.WriteLine("\n Nodo con el dato ({0}) fue eliminado \n", actual.Dato);
                    encontrado = true;
                }
                anterio = actual;
                actual = actual.Siguiente;
            }
            if (!encontrado)
            {
                Console.WriteLine("\n Nodo no encontrado\n");
            }
        }

        // metodo para modificar un nodo
        public void Modificarnodo()
        {
            Nodo actual = new Nodo();// construcion de un nodo referencia para buscar el nodo a modifical
            actual = primero;
            bool encontrado = false;
            Console.WriteLine("Ingrese el dato del nodo a modificar:");
            int nodoBuscar = int.Parse(Console.ReadLine());
            while (actual !=null && encontrado == false)
            {
                if (actual.Dato == nodoBuscar)
                {
                    Console.WriteLine("\n Nodo con el dato ({0}) encontrado \n", actual.Dato);
                    Console.Write("Ingrese el nuevo dato para este nodo: ");
                    actual.Dato = int.Parse(Console.ReadLine());
                    Console.Write("\n Nodo modificado con exito \n");
                    encontrado = true;
                }
               
                actual = actual.Siguiente;
            }
            if (!encontrado)
            {
                Console.WriteLine("\n Nodo no encontrado\n");
            }
        }
    } 

namespace Listas_doblemente_enlazadas
{
    class Program
    {
        static void Main(string[] args)
        {
           Lista l =new Lista();

            int opcionmenu = 0;

            do
            {
                Console.WriteLine("\n |-------------------------------------------|");
                Console.WriteLine(" |    ~ LISTA DOBLEMENTE ENLAZADA ~          |");
                Console.WriteLine(" |---------------------|---------------------|");
                Console.WriteLine(" | 1. Insertar         | 4. Eliminar         |");
                Console.WriteLine(" | 2. Buscar           | 5. Desplegar del PU |");
                Console.WriteLine(" | 3. Modificar        | 6. Desplgar del UP  |");
                Console.WriteLine(" | 4. Eliminar         | 7. Salir            |");
                Console.WriteLine(" |_____________________|_____________________|");
                Console.WriteLine(" Escoje una Opcion: ");

                
                opcionmenu = int.Parse(Console.ReadLine());

                switch (opcionmenu)
                {
                    case 1:
                        Console.WriteLine("\n Inserta nodo en la lista \n");
                        l.inseptarNodo();
                    break;
                    case 2:
                        Console.WriteLine("\n Buscar un nodo en la lista \n");
                        l.buscarNodo();
                    break;
                    case 3:
                        Console.WriteLine("\n Modificar un nodo de la lista \n");
                        l.Modificarnodo();
                    break;

                    case 4:
                        Console.WriteLine("\n Eliminar un nodo en la lista \n");
                        l.EliminarNodo();
                    break;

                    case 5:
                        Console.WriteLine("\n Desplegar lista del primero al ultimo \n");
                        l.DesplejarListaPU();
                    break;
                    case 6:
                        Console.WriteLine("\n Desplegar lista del  ultimo al primero \n");
                        l.DesplejarListaUp();
                    break;
                }
            }
            while (opcionmenu != 7);
            
            Console.ReadKey();
        }
    }
}
