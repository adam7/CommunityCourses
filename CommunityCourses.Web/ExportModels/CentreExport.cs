
using FileHelpers;
namespace CommunityCourses.Web.ExportModels
{
    [DelimitedRecord(",")]
    public class CentreExport
    {
        public string Name;
        public string Phone;
        public string ContactName;
        [FieldQuoted()]
        public string Address;
    }
}