using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Library.Persistence.Contexts;

public class LibraryContextInitialiser
{
    private readonly ILogger<LibraryContextInitialiser> _logger;
    private readonly LibraryContext _context;

    public LibraryContextInitialiser(ILogger<LibraryContextInitialiser> logger, LibraryContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            //var exist = _context.Database.SqlQueryRaw<bool>("select cast(1 as bit) where EXISTS(SELECT * FROM sys.sysdatabases where [name]=@db_name)", new[] { new SqlParameter("db_name", "Library_DB") }).First();
            //if (!exist)
            //{
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            //}
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

}
