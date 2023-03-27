using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using TestAppData;
using TestReport;


namespace Coordinator.Repositories
{
    

    //Репозиторий отчетов
    public class ReportRepository: IReportRepository
    {
        private readonly ConcurrentDictionary<string, TestReportLoad> _reports = new();
        private TestAppContext dataBase;

        //Отчеты
        public ICollection<TestReportLoad> Reports()
        {
            return _reports.Values;
        }

        //Добавление отчетов в репозиторий
        public bool AddReport(TestReportLoad report)
        {
            return _reports.TryAdd(report.JobId, report);
        }

        
    }
}
