using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class TableRepository : GenericRepository<Table>, ITableRepository
{
    private readonly SignalRContext _context;

    public TableRepository(SignalRContext context) : base(context)
    {
        _context = context;
    }

    public async Task<int> GetTableCount()
    {
        return await _context.Tables.CountAsync();
    }

    public int GetTableCountForSignalR()
    {
        return _context.Tables.Count();
    }

    public List<Table> GetAllTables()
    {
        return _context.Tables.ToList();
    }

    public async Task ChangeTableStatus(Guid id, bool status)
    {
        var table = await _context.Tables.FindAsync(id);
        if (table != null)
        {
            table.Status = status;
            _context.SaveChanges();
        }
        //todo: when if condition is false throw exception or return custom result type
    }
}