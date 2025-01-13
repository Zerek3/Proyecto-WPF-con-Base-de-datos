using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

namespace Proyecto_sql_base_de_datos.Datos
{
    internal class Conexion
    { 
        protected  SqlConnection bd = new SqlConnection("Data Source=ZEREK;Initial Catalog=tienda;Integrated Security=True;Encrypt=False");
       
        public bool conectar()
        {
            try
            {
                bd.Open();

                if(bd.State==ConnectionState.Open) { 

                    
                    return true;
                    

                    
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {

              MessageBox.Show(ex.Message);
                return false;
            }

        }
        

        public void desconectar()
        {
            try
            {
                if (bd.State==ConnectionState.Open)
                {
                    bd.Close();
                }
            }

           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
