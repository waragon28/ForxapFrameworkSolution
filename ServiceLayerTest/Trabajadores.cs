using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ServiceLayerTest
{



    public interface IAdd<T>
    {
        bool Add(object T);
    }

    public  class Trabajador
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }


        public Trabajador()
        {

        }

        public Trabajador (string nombre, string apellidos)
        {
            Nombre = nombre;
            Apellidos = apellidos;
        }
    }


    public abstract class BaseDAL 
    {
        private SqlConnection connection = new SqlConnection("Server=DESKTOP-UEPK13H\\RONETJOHN;DataBase= Practica;Integrated Security=true");
        public SqlConnection ConnectionOpen()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            return connection;
        }
        public SqlConnection ConnecctionClose()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
            return connection;
        }

        
        private string _connectionString = string.Empty;

	    public string ConecctionString
	    {
		    get { return _connectionString;}
		    set { _connectionString = value;}
	    }

	
    }


    public class TrabajadorBLL : IAdd<Trabajador>, IDisposable
    {

        public bool Add(string nombre, string apellidos)
        {
            bool ret = false;

            Trabajador trabajador = new Trabajador();

            trabajador.Nombre = nombre;
            trabajador.Apellidos = apellidos;

            using (TrabajadorBLL trabajadoresBLL = new TrabajadorBLL())
            {
                ret = trabajadoresBLL.Add(trabajador);
            }


            return ret;
        }


        public bool Add(object trabajador)
        {
            using (TrabajadoresDAL trabajadoresDAL = new TrabajadoresDAL())
            {
               return  trabajadoresDAL.Add(trabajador);

            } 
        }

           #region Disposable
        
        


        private bool disposing = false;
        /// <summary>
        /// Método de IDisposable para desechar la clase.
        /// </summary>
        public void Dispose()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        /// <summary>
        /// Método sobrecargado de Dispose que será el que
        /// libera los recursos, controla que solo se ejecute
        /// dicha lógica una vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name=”b”></param>
        protected virtual void Dispose(bool b)
        {
            // Si no se esta destruyendo ya…
            {
                if (!disposing)

                    // La marco como desechada ó desechandose,
                    // de forma que no se puede ejecutar este código
                    // dos veces.
                    disposing = true;
                // Indico al GC que no llame al destructor
                // de esta clase al recolectarla.
                GC.SuppressFinalize(this);
                // … libero los recursos… 
            }
        }




        /// <summary>
        /// Destructor de clase.
        /// En caso de que se nos olvide “desechar” la clase,
        /// el GC llamará al destructor, que tambén ejecuta la lógica
        /// anterior para liberar los recursos.
        /// </summary>
        ~TrabajadorBLL()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion





    }

    public class TrabajadoresDAL : BaseDAL,IAdd<Trabajador>, IDisposable
    {

        public bool Add(object T)
        {
            bool ret = false;

         

            return ret;


        }

        #region Disposable
        
        


        private bool disposing = false;
        /// <summary>
        /// Método de IDisposable para desechar la clase.
        /// </summary>
        public void Dispose()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        /// <summary>
        /// Método sobrecargado de Dispose que será el que
        /// libera los recursos, controla que solo se ejecute
        /// dicha lógica una vez y evita que el GC tenga que
        /// llamar al destructor de clase.
        /// </summary>
        /// <param name=”b”></param>
        protected virtual void Dispose(bool b)
        {
            // Si no se esta destruyendo ya…
            {
                if (!disposing)

                    // La marco como desechada ó desechandose,
                    // de forma que no se puede ejecutar este código
                    // dos veces.
                    disposing = true;
                // Indico al GC que no llame al destructor
                // de esta clase al recolectarla.
                GC.SuppressFinalize(this);
                // … libero los recursos… 
            }
        }




        /// <summary>
        /// Destructor de clase.
        /// En caso de que se nos olvide “desechar” la clase,
        /// el GC llamará al destructor, que tambén ejecuta la lógica
        /// anterior para liberar los recursos.
        /// </summary>
        ~TrabajadoresDAL()
        {
            // Llamo al método que contiene la lógica
            // para liberar los recursos de esta clase.
            Dispose(true);
        }

        #endregion

    }



}
