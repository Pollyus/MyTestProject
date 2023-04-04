using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Test> TestRepository { get; }
        public IGenericRepository<Person> PersonRepository { get; }
        public IGenericRepository<TestReport> TestReportRepository { get; }
        public IGenericRepository<TeamLeader> TeamLeaderRepository { get; }
    }
}
