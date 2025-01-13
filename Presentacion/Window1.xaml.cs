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
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

                try
                {    //LCLientes es la clase del a capa logica la cual se comunica con la capa datos y con la capa presentacion 
                    LCliente lc = new LCliente();

                    lc.crear(txtNombres.Text, txtApellidos.Text, txtNumId.Text, txtDireccion.Text, txtTelefono.Text);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            
        }
    }
}
