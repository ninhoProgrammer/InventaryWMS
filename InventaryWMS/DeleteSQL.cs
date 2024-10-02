using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventaryWMS
{
    internal class DeleteSQL
    {
        private System.Data.SqlClient.SqlConnection _connection { get; set; }
        private SqlDataReader _dr { get; set; }
        public string message { get; set; }
        public DeleteSQL()
        {
            _connection = DBConections.GetConnection();
        }

        public bool DeleteUser(int IDUSER, string USERNAME)
        {
            bool queryExecute = false;

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[USERS] WHERE IDUSER = " + IDUSER + " AND USERNAME = '" + USERNAME + "'", _connection);
                int filasafectadas = cmd.ExecuteNonQuery();
                if (filasafectadas > 0)
                {
                    MessageBox.Show("¡Registro eliminado con exito!");
                    queryExecute = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return queryExecute;
        }

        public bool DeleteClient(int IDCLIENTS, string NAME)
        {
            bool queryExecute = false;

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[CLIENTS] WHERE IDCLIENTS = " + IDCLIENTS + " AND NAME = '" + NAME + "'", _connection);
                int filasafectadas = cmd.ExecuteNonQuery();
                if (filasafectadas > 0)
                {
                    MessageBox.Show("¡Registro eliminado con exito!");
                    queryExecute = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return queryExecute;
        }

        public bool DeletePermissions(string IDPERMISSIONS, string NAME)
        {
            bool queryExecute = false;

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[PERMISSIONS] WHERE IDPERMISSIONS = " + IDPERMISSIONS + " AND NAME = '" + NAME + "'", _connection);
                int filasafectadas = cmd.ExecuteNonQuery();
                if (filasafectadas > 0)
                {
                    MessageBox.Show("¡Registro eliminado con exito!");
                    queryExecute = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return queryExecute;
        }


        public bool DeleteEmailsClients(int IDCLIENT_EMAILS, string ADDRESS)
        {
            bool queryExecute = false;

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[CLIENT_EMAILS] WHERE IDCLIENT_EMAILS = " + IDCLIENT_EMAILS + " AND ADDRESS = '" + ADDRESS + "'", _connection);
                int filasafectadas = cmd.ExecuteNonQuery();
                if (filasafectadas > 0)
                {
                    MessageBox.Show("¡Registro eliminado con exito!");
                    queryExecute = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return queryExecute;
        }

        public bool DeleteProducts(int IDCLINTE, string IDPRODUCTS, string DESCRIPTION)
        {
            bool queryExecute = false;

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[PRODUCTS] WHERE [IDCLINTE] = " + IDCLINTE + " AND IDPRODUCTS = " + IDPRODUCTS + " AND [DESCRIPTION] = '" + DESCRIPTION + "'", _connection);
                int filasafectadas = cmd.ExecuteNonQuery();
                if (filasafectadas > 0)
                {
                    MessageBox.Show("¡Registro eliminado con exito!");
                    queryExecute = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return queryExecute;
        }

        public bool DeleteWarehouse(string IDWAREHOUSES, string NAME)
        {
            bool queryExecute = false;

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[WAREHOUSES] WHERE IDWAREHOUSES = " + IDWAREHOUSES + " AND NAME = '" + NAME + "'", _connection);
                int filasafectadas = cmd.ExecuteNonQuery();
                if (filasafectadas > 0)
                {
                    MessageBox.Show("¡Registro eliminado con exito!");
                    queryExecute = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return queryExecute;
        }

        public bool DeleteClientsWarehouse(int IDCLIENT, int IDWAREHOUSES)
        {
            bool queryExecute = false;

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[CLIENT_EMAILS] WHERE IDCLIENT = " + IDCLIENT + " AND IDWAREHOUSES = '" + IDWAREHOUSES + "'", _connection);
                int filasafectadas = cmd.ExecuteNonQuery();
                if (filasafectadas > 0)
                {
                    MessageBox.Show("¡Registro eliminado con exito!");
                    queryExecute = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return queryExecute;
        }
    }
}
