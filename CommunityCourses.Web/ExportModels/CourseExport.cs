using System;
using FileHelpers;

namespace CommunityCourses.Web.ExportModels
{
    [DelimitedRecord(",")]
    public class CourseExport
    {
        public string Name;

        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime? StartDate;

        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime? EndDate;
    }
}