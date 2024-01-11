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
}