using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TestAppData

{
    //Создание таблицы для хранения отчетов
    [Table("testResults")]
    public class TestResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdReport")]
        public int Id { get; set; }
        //Название отчета
        [Column("NameReport")]
        public string Name { get;set; }
        //Комментарии
        [Column("Comment")]
        public string Description { get;set; }
        // Отчет в формате xml
        [Column("XmlReport")]
        public string XmlString { get; set; }
        //Отчет в формате html
        [Column("HtmlReport")]
        public string HtmlString { get; set; }

        [Column("Result")]
        public bool? Result { get; set; }

    }
}
