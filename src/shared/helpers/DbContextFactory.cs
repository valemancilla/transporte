using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using transporte.src.shared.context;

namespace transporte.src.shared.helpers;

public class DbContextFactory
{
    public static AppDbContext Create()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        string? connectionString = Environment.GetEnvironmentVariable("MYSQL_CONNECTION")
                                ?? config.GetConnectionString("MySqlDB")
                                ?? config.GetConnectionString("Transporte_db");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException(
                "No se encontró una cadena de conexión. Use MYSQL_CONNECTION o ConnectionStrings:MySqlDB en appsettings.json.");

        var detectedVersion = MySqlVersionResolver.DetectVersion(connectionString);
        var minVersion = new Version(8, 0, 0);
        if (detectedVersion < minVersion)
            throw new NotSupportedException($"Versión de MySQL no soportada: {detectedVersion}. Requiere {minVersion} o superior.");

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseMySql(connectionString, new MySqlServerVersion(detectedVersion))
            .Options;
        return new AppDbContext(options);
    }
}
