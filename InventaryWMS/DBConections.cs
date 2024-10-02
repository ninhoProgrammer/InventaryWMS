namespace InventaryWMS
{
    internal class DBConections
    {
        public DBConections() { }
        public static System.Data.SqlClient.SqlConnection GetConnection()
        {
            Security security = new Security();
            string con = security.createFile("conections.txt");
            string[] conectionsString = con.Split('|');
            System.Data.SqlClient.SqlConnection conection = new System.Data.SqlClient.SqlConnection(@"Data Source=" + conectionsString[0] + "; Initial Catalog=INVENTARY; MultipleActiveResultSets=true; TrustServerCertificate=True; User ID=" + conectionsString[1] + "; Password=" + conectionsString[2] + " ");

            //System.Data.SqlClient.SqlConnection conection = new System.Data.SqlClient.SqlConnection(@"Data Source=192.168.101.100; Initial Catalog=INVENTARY; MultipleActiveResultSets=true; TrustServerCertificate=True; User ID=sa; Password=Admin_sqlABG");
            return conection;
        }
    }
}