using Persistence.DbContext;
using Domain.Entities;
using Application.Common.Interfaces;

namespace Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TestAppDbContext _context;
        private GenericRepository<Test> _testRepository;
        private GenericRepository<Person> _personRepository;
        private GenericRepository<TeamLeader> _teamLeaderRepository;
        private GenericRepository<TestReport> _testReportRepository;

        public UnitOfWork(TestAppDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Test> TestRepository => _testRepository ??= new GenericRepository<Test>(_context);
        public IGenericRepository<Person> PersonRepository => _personRepository ??= new GenericRepository<Person>(_context);

        public IGenericRepository<TestReport> TestReportRepository => _testReportRepository ??= new GenericRepository<TestReport>(_context);
        public IGenericRepository<TeamLeader> TeamLeaderRepository => _teamLeaderRepository ??= new GenericRepository<TeamLeader>(_context);

        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
