using Microsoft.EntityFrameworkCore;

using var db = new CursoEFCore.Data.ApplicationContext();
//db.Database.Migrate();

var MigrationPendente = db.Database.GetPendingMigrations().Any();
if (MigrationPendente)
{
    // regra de negocio...
}

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
