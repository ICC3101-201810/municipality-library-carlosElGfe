using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ClassLibrary1;


namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            //ERROR DONDE EL ADRES NO SE PUEDE ACCEDER AL IGUAL QUE EL OWNER DE UNA CASA
            //FECHA A UTILIZAR : 2009-05-08 14:40:52,531
            DateTime value = new DateTime(2017, 1, 18);
            ClassLibrary1.Address adress_prueba = new Address("prueba", 1, null, null, null, 1, 1, 1, true, true);
            // yo soy persona prueba
            ClassLibrary1.Person person_prueba = new Person(null, null, value, adress_prueba, null, null, null);
            ClassLibrary1.Person la_ex = new Person(null, null, value, adress_prueba, null, null, null);
            
            ClassLibrary1.Car car_prueba = new Car("prueba", "prueba", 1, null, null, 1, true);
            
            Type o = car_prueba.GetType();
            MethodInfo[] methodInfo = o.GetMethods();
            person_prueba.getAbandoned();
            List<Person> personas = new List<Person>();
            List<Address> casas = new List<Address>();
            List<Car> autos = new List<Car>();
            personas.Add(person_prueba);
            personas.Add(la_ex);
            casas.Add(adress_prueba);
            autos.Add(car_prueba);
            foreach (MethodInfo po in methodInfo)
            {
                Console.WriteLine(o.GetMethod(po.Name));
                
            }
           
            Console.WriteLine("Bienvenido al registro civil");
            string opcion;
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Ingrese opcion a realizar \n\t opcion 1 = adoptar \n\t opcion 2 = SerAabandonado \n\t opcion 3 = Inscribir un auto a nombre de 3ro o solo inscribir \n\t opcion 4 = administrar casa ");
                string opcionn = Console.ReadLine();
                if (opcionn == "1")
                {
                    Console.WriteLine("OOps , Hay que INSCRIBIR a tu esposa \nIngrese nombre de la esposa ");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese apellido");
                    string apellido = Console.ReadLine();
                    Console.WriteLine("Ingrese fecha de nacimiento");
                    string nacimiento = Console.ReadLine();
                    DateTime myDate = DateTime.ParseExact(nacimiento, "yyyy-MM-dd HH:mm:ss,fff",
                    System.Globalization.CultureInfo.InvariantCulture);
                    Console.WriteLine("Ingrese rut ");
                    string rutt = Console.ReadLine();
                    Person esposa = new Person(nombre, apellido, myDate, adress_prueba, rutt, null,null);
                    personas.Add(esposa);
                    Console.WriteLine("Esposa INSCRITA con exito");
                    Console.WriteLine("OOps , Hay que INSCRIBIR a tu HIJO \nIngrese nombre del hijo ");
                    string nombre1 = Console.ReadLine();
                    Console.WriteLine("Ingrese apellido");
                    string apellido1 = Console.ReadLine();
                    Console.WriteLine("Ingrese fecha de nacimiento");
                    string nacimiento1 = Console.ReadLine();
                    DateTime myDate1 = DateTime.ParseExact(nacimiento, "yyyy-MM-dd HH:mm:ss,fff",
                    System.Globalization.CultureInfo.InvariantCulture);
                    Console.WriteLine("Ingrese rut ");
                    string rutt1 = Console.ReadLine();
                    Person esposa1 = new Person(nombre, apellido, myDate, adress_prueba, rutt, null, null);
                    //implementacion metodo de persona
                    esposa1.getAdopted(person_prueba,esposa);
                    personas.Add(esposa);
                    Console.WriteLine("hijo INSCRITO con exito");
                    

                }
                if (opcionn == "2")
                {
                    Console.WriteLine("Estas siendo abandonado");
                    person_prueba.getAbandoned();
                    Console.WriteLine("Fuiste abandonado... \nRetornando");
                }
                if (opcionn == "3")
                {
                    Console.WriteLine("OOps al programa se le olvido su auto \n A continuacion tiene que INSCRIBIR su auto");
                    Console.WriteLine("Ingrese Marca");
                    string marca = Console.ReadLine();
                    Console.WriteLine("Ingrese modelo");
                    string modelo = Console.ReadLine();
                    Console.WriteLine("Ingrese ano");
                    string anoo = Console.ReadLine();
                    int ano = Convert.ToInt32(anoo);
                    Console.WriteLine("Ingrese Patente");
                    string patente = Console.ReadLine();
                    Console.WriteLine("Ingrese numero cinturones");
                    string cinturon = Console.ReadLine();
                    int cintu = Convert.ToInt32(cinturon);
                    
                    bool disl = true;
                    bool loop1 = true;
                    while (loop1)
                    {
                        Console.WriteLine("Diesel o no? \n 1 Yes/ 2 No");
                        string opcion_disel = Console.ReadLine();
                        if (opcion_disel == "1")
                        {
                            disl = true;
                            loop1 = false;
                        }
                        if (opcion_disel == "2")
                        {
                            disl = false;
                            loop1 = false;
                        }
                        if (opcion_disel != "1" && opcion_disel != "2")
                        {
                            Console.WriteLine("opcion ingresada no valida... \nRetornando");
                            continue;
                        }
                    }
                    Car car = new Car(marca, modelo, ano, person_prueba, patente, cintu, disl);
                    autos.Add(car);
                    Console.WriteLine("desea pasarlo a un 3ro?");
                    bool loopauto = true;
                    while (loopauto)
                    {
                        Console.WriteLine("opcion 1 = si \n opcion 2 = no \n opcion 3 volver al menu");
                        string opcionauto = Console.ReadLine();
                        if (opcionauto == "1")
                        {
                            //se transfiere el auto utilizando el metodo a la ex :c
                            car.giveUpOwnershipToThirdParty(la_ex);
                            Console.WriteLine("auto entregado a tu ex  :´c");
                            loopauto = false;
                        }
                        if (opcionauto == "2")
                        {
                            Console.WriteLine("retornando");
                            loopauto = false;
                        }
                        if (opcionauto == "3")
                        {
                            Console.WriteLine("retornando..");
                            loopauto = false;
                        }
                        if (opcionauto != "1" && opcionauto != "2" && opcionauto != "3")
                        {
                            Console.WriteLine("Opcion ingresada no valida \n retornando....");
                        }
                    }
                }
                if (opcionn == "4")
                {
                    bool loopcasa = true;
                    while (loopcasa)
                    {
                        Console.WriteLine("Opcion 1 = INSCRIBIR CASA \nOpcion 2 = editar datos \nOpcion3 = transpasar casa \nOpcion 4 = Salir del menu casa");
                        string opcioncasa = Console.ReadLine();
                        if (opcioncasa == "1")
                        {
                            Console.WriteLine("Ingrese calle");
                            string calle = Console.ReadLine();
                            Console.WriteLine("Ingrese numero");
                            string num = Console.ReadLine();
                            int numero_casa = Convert.ToInt32(num);
                            Console.WriteLine("Ingrese nombre comuna");
                            string comuna = Console.ReadLine();
                            Console.WriteLine("Ingrese  ciudad");
                            string ciudad = Console.ReadLine();
                            Console.WriteLine("ingrese año de construccion");
                            string ano_contru = Console.ReadLine();
                            int ano_p = Convert.ToInt32(ano_contru);
                            Console.WriteLine("ingrese numero baños");
                            string nummm = Console.ReadLine();
                            int num_ban = Convert.ToInt32(nummm);
                            Console.WriteLine("Ingrese numero dormitorios");
                            string nummm1 = Console.ReadLine();
                            int num_ban1 = Convert.ToInt32(nummm1);
                            bool loopbano = true;
                            bool patio = true;
                            while (loopbano)
                            {
                                Console.WriteLine("menu  patio \n 1 Yes/ 2 No ");
                                string opcionpatio = Console.ReadLine();
                                if (opcionpatio == "1")
                                {
                                    patio = true;
                                    loopbano = false;
                                }
                                if (opcionpatio == "2")
                                {
                                    patio = false;
                                    loopbano = false;
                                }
                                if (opcionpatio != "1" && opcionpatio != "2")
                                {
                                    Console.WriteLine("Opcion ingresada no valida... retornando");
                                }
                            }
                            bool loopbano1 = true;
                            bool pool = true;
                            while (loopbano1)
                            {
                                Console.WriteLine("menu  piscina \n 1 Yes/ 2 No ");
                                string opcionpatio = Console.ReadLine();
                                if (opcionpatio == "1")
                                {
                                    pool = true;
                                    loopbano1 = false;
                                }
                                if (opcionpatio == "2")
                                {
                                    pool = false;
                                    loopbano1 = false;
                                }
                                if (opcionpatio != "1" && opcionpatio != "2")
                                {
                                    Console.WriteLine("Opcion ingresada no valida... retornando");
                                }
                            }
                            Address nuevo_adres = new Address(calle,numero_casa,comuna,ciudad,person_prueba,ano_p,num_ban1,num_ban,patio,pool);
                            casas.Add(nuevo_adres);
                            Console.WriteLine("Casa Ingresada con Exito!");
                            foreach  (Address a in casas)
                            {
                                Console.WriteLine(a.Commune);
                                
                            }
                            loopcasa = false;
                        }
                        if (opcioncasa == "2")
                        {
                            Console.WriteLine("desea agregar baños a su casa?");
                            bool loopbano = true;
                            while (loopbano)
                            {
                                Console.WriteLine("opcion 1 = si \nopcion 2 = no ");
                                string oopcionbano = Console.ReadLine();
                                if (oopcionbano == "1")
                                {
                                    //metodo banos
                                    Console.WriteLine("Ingrese numero de baños");
                                    string nuevo = Console.ReadLine();
                                    int nuevo_bano = Convert.ToInt32(nuevo);
                                    adress_prueba.addBathrooms(nuevo_bano);
                                    loopbano = false;
                                }
                                if (oopcionbano == "2")
                                {
                                    Console.WriteLine("retornando..");
                                    loopbano = false;

                                }
                                if (oopcionbano != "1" && oopcionbano != "2")
                                {
                                    Console.WriteLine("opcion ingresada no valida");
                                }
                            }
                            Console.WriteLine("desea agregar dormitorios a su casa?");
                            bool loopbano1 = true;
                            while (loopbano1)
                            {
                                Console.WriteLine("opcion 1 = si \nopcion 2 = no ");
                                string oopcionbano = Console.ReadLine();
                                if (oopcionbano == "1")
                                {
                                    //metodo dormitorios
                                    Console.WriteLine("Ingrese cantidad de dormitorios nuevos");
                                    string nuevo = Console.ReadLine();
                                    int nuevo_bano = Convert.ToInt32(nuevo);
                                    adress_prueba.addBeedrooms(nuevo_bano);
                                    loopbano1 = false;
                                }
                                if (oopcionbano == "2")
                                {
                                    Console.WriteLine("retornando..");
                                    
                                    loopbano1 = false;

                                }
                                if (oopcionbano != "1" && oopcionbano != "2")
                                {
                                    Console.WriteLine("opcion ingresada no valida");
                                }
                            }
                        }
                        if (opcioncasa == "3")
                        {
                            //metodo de adress
                            adress_prueba.changeOwner(la_ex);
                            Console.WriteLine("Tu casa fue transpasada a tu ex");
                            loopcasa = false;
                        }
                        if (opcioncasa == "4")
                        {
                            loopcasa = false;
                        }
                        if (opcioncasa != "1"&& opcioncasa != "2" && opcioncasa != "3" && opcioncasa != "4")
                        {
                            Console.WriteLine("opcion ingresada no valida \nretornando....");
                        }
                        
                    }

                    
                }
                if (opcionn != "1" && opcionn != "2" && opcionn != "3" && opcionn != "4")
                {
                    Console.WriteLine("opcion ingresada no valida \nRetornando...");
                }
            }
            
        }
    }
}
