using System;
using FileHelpers;

namespace CommunityCourses.Web.ExportModels
{
    [DelimitedRecord(",")]
    public class PersonExport
    {
        public string Name;

        [FieldQuoted()]
        public string Roles;

        public string CriminalRecordsBureauReferenceNumber;

        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime? CriminalRecordsBureauExpiryDate;

        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy")]
        public DateTime? DateOfBirth;

        [FieldQuoted()]
        public string Disabilities;
        
        public string Email;

        public string Ethnicity;

        public string Gender;

        public string Mobile;

        public string Notes;

        public string Phone;

        [FieldQuoted()]
        public string Address;
    }
}