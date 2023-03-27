namespace TestReport
{
    /// <summary>
    /// Модель данных для отчета
    /// </summary>
    public class TestReportLoad
    {
        //Xml отчет
        public string xmlReport { get; set; }
        //html отчет
        public string htmlReport { get; set; }
        //Номер пайплайна
        public string PipelineId { get; set; }
        //Номер джоба
        public string JobId { get; set; }

    }
}