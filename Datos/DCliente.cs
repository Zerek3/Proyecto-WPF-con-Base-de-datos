using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace Proyecto_sql_base_de_datos.Datos
{
    internal class DCliente:Conexion
    {
        
        private string nombres;
        private string apellidos;
        private string numId;
        private string direccion;
        private string telefono;
        private string calificacion;
        private int id;


        private SqlCommand cmd;
        
        public DCliente(string nombres,string apellidos, string numId,string direccion,string telefono)
        {
            
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.direccion = direccion;
            this.telefono = telefono;
            this.numId = numId;
           
            
        }
        public DCliente(string nombres, string apellidos, string numId, string direccion, string telefono, string cal)
        {

            this.nombres = nombres;
            this.apellidos = apellidos;
            this.numId = numId;
            this.direccion = direccion;
            this.telefono = telefono;
            this.calificacion = cal;

        }
        public DCliente()
        {

   

        }
        public string NOMBRES
        {
            get { return nombres; }

            set { nombres = value; }
        }

        public string APELLIDOS
        {
            get { return apellidos; }

            set { apellidos = value; }
        }
         public string DIRECCION
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string TELEFONO
        {
            get { return telefono; }

            set { telefono = value; }
        }

        
       public string NUM_ID
        {
            get { return numId; }

            set { numId = value; }
        }

        public string CALIFICACION
        {
            get { return calificacion; }

            set { calificacion = value; }
        }
        public int ID
        {
            get { return id; }
            set{ id = value; }
        }
        /* public bool crear()
         {
             try
             {
                 conectar();
                 //Crear objeto sqlComand
                 cmd = new SqlCommand("INSERT INTO [tienda].[tienda].[clientes] (NOMBRES,APELLIDOS,DIRECCION,TELEFONO,CALIFICACION,NUM_ID)"
                 + "VALUES ('" + nombres + "','" + apellidos + "','" + direccion + "','" + telefono + "','A',"+"'" + numId + "')") ;
                 //Assignar cadena de conexiones para poder ejecutar la consulta
               cmd.Connection = bd;
                 //Ejecutamos consulta dentro de if para verificar si se consulto bien
                 //al ser valor mayor que 0 significa que si se ingreso correctamente
               if(cmd.ExecuteNonQuery() > 0) 
               {
                 return true;

               }
               else 
               { 
                     return false; 
               }

             } catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
                 return false;
             }
             finally
             {
                 desconectar();
             }
         }
        */
        public bool crear()
        {
            try
            {
                conectar();
                // Crear objeto SqlCommand con parámetros
                cmd = new SqlCommand("INSERT INTO [tienda].[tienda].[clientes] (NOMBRES, APELLIDOS, DIRECCION, TELEFONO, CALIFICACION, NUM_ID) " +
                                     "VALUES (@nombres, @apellidos, @direccion, @telefono, @calificacion, @numId)", bd);

                // Asignar valores a los parámetros
                cmd.Parameters.AddWithValue("@nombres", nombres);
                cmd.Parameters.AddWithValue("@apellidos", apellidos);
                cmd.Parameters.AddWithValue("@direccion", direccion);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@calificacion", "A"); // Asignar calificación fija
                cmd.Parameters.AddWithValue("@numId", numId);

                // Ejecutar consulta y verificar si se insertó correctamente
                if (cmd.ExecuteNonQuery() > 0)
                {
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
            finally
            {
                desconectar();
            }
        }

        public DCliente getDatosCliente()
        {
         
                try
                {

                    conectar();
                    //Vamos a obtener en la tabla cliente  el cliente cuyo numId este 
                    //almacenado en el atributo numId en la tabla cliente
                    string consulta = "SELECT * FROM  [tienda].[tienda].[clientes] WHERE NUM_ID='" + numId + "'";

                    cmd = new SqlCommand(consulta, bd);
                    //-1 quiere decir que se ejecuto correctamente la pregunta select devuelve menos 1
                    if (cmd.ExecuteNonQuery() == -1)
                    {
                        DataTable dt = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);

                    adp.Fill(dt);

                    DataRow dr= dt.Rows[0];

                    DCliente dc = new DCliente(dr["NOMBRES"].ToString(), dr["APELLIDOS"].ToString(), numId, dr["DIRECCION"].ToString(), dr["TELEFONO"].ToString());
                    dc.id=int.Parse(dr["ID"].ToString());
                    dc.calificacion = dr["CALIFICACION"].ToString();
                    return dc;
                
                }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
                finally
                {
                    desconectar();
                }
            
             
        }

    


        //Metodo para comprovar si existe un cliente dentro de la tabla
        //para no volverlo a registrar
        public bool existeCliente()
        {
            try
            {
                conectar();
                // Vamos a obtener en la tabla cliente el cliente cuyo numId esté almacenado en el atributo numId en la tabla cliente
                string consulta = "SELECT COUNT(*) FROM tienda.CLIENTES WHERE NUM_ID = @numId";

                cmd = new SqlCommand(consulta, bd);
                cmd.Parameters.AddWithValue("@numId", numId);

                // Usar ExecuteScalar para obtener el número de filas que coinciden
                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
            catch (Exception ex)
            {
                // Registrar el error y mostrar un mensaje amigable
                MessageBox.Show("Ocurrió un error al verificar la existencia del cliente. Por favor, intente nuevamente.");
                // Aquí se podría registrar el error en un log
                return false;
            }
            finally
            {
                desconectar();
            }
        }
        public bool actualizar()
        {
            try
            {

                conectar();
                //Vamos a obtener en la tabla cliente  el cliente cuyo numId este 
                //almacenado en el atributo numId en la tabla cliente
                string consulta = "UPDATE [tienda].[tienda].[clientes] SET NOMBRES='" + nombres + "',APELLIDOS='" + apellidos + "'," +
                    "" + "DIRECCION='" + direccion + "',TELEFONO='" + telefono + "'," +
                    "NUM_ID='" + numId + "' WHERE ID=" + id;

                cmd = new SqlCommand(consulta, bd);
                //-1 quiere decir que se ejecuto correctamente la pregunta select devuelve menos 1
                if (cmd.ExecuteNonQuery() > 0)
                {
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
            finally
            {
                desconectar();
            }

        }

        public bool eliminar()
        {
            try
            {

                conectar();
                //Vamos a obtener en la tabla cliente  el cliente cuyo numId este 
                //almacenado en el atributo numId en la tabla cliente
                string consulta = "DELETE FROM TIENDA.CLIENTES WHERE ID=" + id;

                cmd = new SqlCommand(consulta, bd);
                //-1 quiere decir que se ejecuto correctamente la pregunta select devuelve menos 1
                if (cmd.ExecuteNonQuery() > 0)
                {
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
            finally
            {
                desconectar();
            }

        }
    }
}


