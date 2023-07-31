namespace PJ_RESTAURANTE_5TO_CICLO.Conexion
{
    public abstract class SqlServer
    {
        public string? bd_restaurante_5to_ciclo() 
        {
            string? cadena_conexion = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("connection1");

            return cadena_conexion;
        }
    }
}
