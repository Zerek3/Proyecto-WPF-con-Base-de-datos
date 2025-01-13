using Proyecto_sql_base_de_datos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_sql_base_de_datos.Logica
{ //Comuicacion con la capa datos y por medio de los argumentos contruimos con dcCliente creamos registro
    internal class LCliente
    {


        public void crear(string nombres, string apellidos, string numId, string direccion, string telefono)
        {
            try
            {
                if (string.IsNullOrEmpty(nombres) || string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(numId))
                {
                    MessageBox.Show("Faltan datos para poder registrar al cliente");
                    return;
                }

                // Comunicar con la capa datos para mandar la info que tenemos de formulario y poder almacenar en la base de datos
                DCliente dc = new DCliente(nombres, apellidos, numId, direccion, telefono);

                // Comprobar si el Cliente existe o no
                if (!dc.existeCliente())
                {
                    if (dc.crear())
                    {
                        MessageBox.Show("Cliente registrado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el cliente");
                    }
                }
                else
                {
                    MessageBox.Show("El cliente ya existe");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("No se puede registrar cliente");
            }
        }

        public DCliente getDatosClientes(string numId)
        {
            try
            {
                DCliente dc = new DCliente();
                dc.NUM_ID = numId;

                return dc.getDatosCliente();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;

         
            }
        }

        public void actualizar(int idC,string nombres, string apellidos, string numId, string direccion, string telefono,string calificacion)
        {
            try
            {
                //Comunicar con la capa datos para mandar la info que tenemos de formulario y pocer almacenar en la base de datos
                DCliente dc = new DCliente(nombres, apellidos, numId, direccion, telefono,calificacion);

                dc.ID = idC;
                

                //Comprobar si el Cliente existe o no 
                if (dc.existeCliente() == true)
                {
                    if (dc.actualizar() == true)
                    {
                        MessageBox.Show("Cliente actualizado correctamente");

                    }
                    else
                    {
                        MessageBox.Show("No se puedo actualizar el cliente");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        public void eliminar (int idC)
        {
            try
            {
                //Comunicar con la capa datos para mandar la info que tenemos de formulario y pocer almacenar en la base de datos
                DCliente dc = new DCliente();

                dc.ID = idC;


                //Comprobar si el Cliente existe o no 
                if (dc.existeCliente() == true)
                {
                    if (dc.eliminar() == true)
                    {
                        MessageBox.Show("Cliente eliminado correctamente");

                    }
                    else
                    {
                        MessageBox.Show("No se puedo eliminar el cliente");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
    }
}
