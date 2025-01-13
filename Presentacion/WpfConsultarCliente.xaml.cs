using Proyecto_sql_base_de_datos.Datos;
using Proyecto_sql_base_de_datos.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_sql_base_de_datos.Presentacion
{
    /// <summary>
    /// Lógica de interacción para WPFConsultarCliente.xaml
    /// </summary>
    public partial class WpfConsultarCliente : Window
    {
        public WpfConsultarCliente()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LCliente lc =new LCliente();

            try
            {
                DCliente dcte = lc.getDatosClientes(txtNumId.Text);
                if (dcte != null) 
                { 
                    txtId.Text = dcte.ID.ToString();
                txtNombres.Text = dcte.NOMBRES;
                txtApellidos.Text= dcte.APELLIDOS;
                txtDireccion.Text = dcte.DIRECCION;
                txtTelefono.Text = dcte.TELEFONO;
                txtCalificacion.Text = dcte.CALIFICACION;
                }

                else
                {
                    MessageBox.Show("No se encontraron datos para el ID proporcionado.");
                }


            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

    

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                LCliente lc =new LCliente();


                lc.actualizar(int.Parse(txtId.Text),txtNombres.Text, txtApellidos.Text, txtNumId.Text, txtDireccion.Text, txtTelefono.Text, txtCalificacion.Text);

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                LCliente lc = new LCliente();


                lc.eliminar(int.Parse(txtId.Text));

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
