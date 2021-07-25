using System;
using Microsoft.EntityFrameworkCore;
using POS.Data;

namespace POS.Tests
{
    public class Config : IDisposable
    {
        protected IUnitOfWork _unitOfWork;
        protected ApplicationDbContext _context;

        public Config()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .EnableSensitiveDataLogging()
                .Options;

            _context = new ApplicationDbContext(options);

            _context.Database.EnsureCreated();

            _unitOfWork = new UnitOfWork(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}