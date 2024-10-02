namespace InventaryWMS
{
    internal class Migracion
    {
        private System.Data.SqlClient.SqlConnection _connection { get; set; }
        SelectSQL select = new SelectSQL();
        public Migracion()
        {
            _connection = DBConections.GetConnection();
        }

    }
}
