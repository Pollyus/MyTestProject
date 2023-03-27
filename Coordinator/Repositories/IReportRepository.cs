using TestAppData;
using TestReport;

namespace Coordinator.Repositories
{
    public interface IReportRepository
    {
        //Добавление отчета
        bool AddReport(TestReportLoad report);

        //Коллекция отчетов
        ICollection <TestReportLoad> Reports();

        

    }
}
