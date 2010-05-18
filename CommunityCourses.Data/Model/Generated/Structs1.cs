


using System;
using SubSonic.Schema;
using System.Collections.Generic;
using SubSonic.DataProviders;
using System.Data;

namespace CommunityCourses.Data.Model {
	
        /// <summary>
        /// Table: Address
        /// Primary Key: Id
        /// </summary>

        public class AddressTable: DatabaseTable {
            
            public AddressTable(IDataProvider provider):base("Address",provider){
                ClassName = "Address";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("FirstLine", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200
                });

                Columns.Add(new DatabaseColumn("City", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Postcode", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn FirstLine{
                get{
                    return this.GetColumn("FirstLine");
                }
            }
				
   			public static string FirstLineColumn{
			      get{
        			return "FirstLine";
      			}
		    }
            
            public IColumn City{
                get{
                    return this.GetColumn("City");
                }
            }
				
   			public static string CityColumn{
			      get{
        			return "City";
      			}
		    }
            
            public IColumn Postcode{
                get{
                    return this.GetColumn("Postcode");
                }
            }
				
   			public static string PostcodeColumn{
			      get{
        			return "Postcode";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Centre
        /// Primary Key: Id
        /// </summary>

        public class CentreTable: DatabaseTable {
            
            public CentreTable(IDataProvider provider):base("Centre",provider){
                ClassName = "Centre";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Phone", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("AddressId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ContactId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
            
            public IColumn Phone{
                get{
                    return this.GetColumn("Phone");
                }
            }
				
   			public static string PhoneColumn{
			      get{
        			return "Phone";
      			}
		    }
            
            public IColumn AddressId{
                get{
                    return this.GetColumn("AddressId");
                }
            }
				
   			public static string AddressIdColumn{
			      get{
        			return "AddressId";
      			}
		    }
            
            public IColumn ContactId{
                get{
                    return this.GetColumn("ContactId");
                }
            }
				
   			public static string ContactIdColumn{
			      get{
        			return "ContactId";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Course
        /// Primary Key: Id
        /// </summary>

        public class CourseTable: DatabaseTable {
            
            public CourseTable(IDataProvider provider):base("Course",provider){
                ClassName = "Course";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("UnitId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CentreId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("EndDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("StartDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("TutorId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("VerifierId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
            
            public IColumn UnitId{
                get{
                    return this.GetColumn("UnitId");
                }
            }
				
   			public static string UnitIdColumn{
			      get{
        			return "UnitId";
      			}
		    }
            
            public IColumn CentreId{
                get{
                    return this.GetColumn("CentreId");
                }
            }
				
   			public static string CentreIdColumn{
			      get{
        			return "CentreId";
      			}
		    }
            
            public IColumn EndDate{
                get{
                    return this.GetColumn("EndDate");
                }
            }
				
   			public static string EndDateColumn{
			      get{
        			return "EndDate";
      			}
		    }
            
            public IColumn StartDate{
                get{
                    return this.GetColumn("StartDate");
                }
            }
				
   			public static string StartDateColumn{
			      get{
        			return "StartDate";
      			}
		    }
            
            public IColumn TutorId{
                get{
                    return this.GetColumn("TutorId");
                }
            }
				
   			public static string TutorIdColumn{
			      get{
        			return "TutorId";
      			}
		    }
            
            public IColumn VerifierId{
                get{
                    return this.GetColumn("VerifierId");
                }
            }
				
   			public static string VerifierIdColumn{
			      get{
        			return "VerifierId";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: CourseModule
        /// Primary Key: Id
        /// </summary>

        public class CourseModuleTable: DatabaseTable {
            
            public CourseModuleTable(IDataProvider provider):base("CourseModule",provider){
                ClassName = "CourseModule";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CourseId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ModuleId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn CourseId{
                get{
                    return this.GetColumn("CourseId");
                }
            }
				
   			public static string CourseIdColumn{
			      get{
        			return "CourseId";
      			}
		    }
            
            public IColumn ModuleId{
                get{
                    return this.GetColumn("ModuleId");
                }
            }
				
   			public static string ModuleIdColumn{
			      get{
        			return "ModuleId";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: CourseSession
        /// Primary Key: Id
        /// </summary>

        public class CourseSessionTable: DatabaseTable {
            
            public CourseSessionTable(IDataProvider provider):base("CourseSession",provider){
                ClassName = "CourseSession";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("SessionId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CourseId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn SessionId{
                get{
                    return this.GetColumn("SessionId");
                }
            }
				
   			public static string SessionIdColumn{
			      get{
        			return "SessionId";
      			}
		    }
            
            public IColumn CourseId{
                get{
                    return this.GetColumn("CourseId");
                }
            }
				
   			public static string CourseIdColumn{
			      get{
        			return "CourseId";
      			}
		    }
            
            public IColumn Date{
                get{
                    return this.GetColumn("Date");
                }
            }
				
   			public static string DateColumn{
			      get{
        			return "Date";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Disability
        /// Primary Key: Id
        /// </summary>

        public class DisabilityTable: DatabaseTable {
            
            public DisabilityTable(IDataProvider provider):base("Disability",provider){
                ClassName = "Disability";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Ethnicity
        /// Primary Key: Id
        /// </summary>

        public class EthnicityTable: DatabaseTable {
            
            public EthnicityTable(IDataProvider provider):base("Ethnicity",provider){
                ClassName = "Ethnicity";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Module
        /// Primary Key: Id
        /// </summary>

        public class ModuleTable: DatabaseTable {
            
            public ModuleTable(IDataProvider provider):base("Module",provider){
                ClassName = "Module";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("UnitId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
            
            public IColumn UnitId{
                get{
                    return this.GetColumn("UnitId");
                }
            }
				
   			public static string UnitIdColumn{
			      get{
        			return "UnitId";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Person
        /// Primary Key: Id
        /// </summary>

        public class PersonTable: DatabaseTable {
            
            public PersonTable(IDataProvider provider):base("Person",provider){
                ClassName = "Person";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Title", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("FirstName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("LastName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("AddressId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Phone", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Mobile", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("Email", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("CriminalRecordsBureauReferenceNumber", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 12
                });

                Columns.Add(new DatabaseColumn("Notes", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 500
                });

                Columns.Add(new DatabaseColumn("DateOfBirth", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("EthnicityId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("GenderId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn Title{
                get{
                    return this.GetColumn("Title");
                }
            }
				
   			public static string TitleColumn{
			      get{
        			return "Title";
      			}
		    }
            
            public IColumn FirstName{
                get{
                    return this.GetColumn("FirstName");
                }
            }
				
   			public static string FirstNameColumn{
			      get{
        			return "FirstName";
      			}
		    }
            
            public IColumn LastName{
                get{
                    return this.GetColumn("LastName");
                }
            }
				
   			public static string LastNameColumn{
			      get{
        			return "LastName";
      			}
		    }
            
            public IColumn AddressId{
                get{
                    return this.GetColumn("AddressId");
                }
            }
				
   			public static string AddressIdColumn{
			      get{
        			return "AddressId";
      			}
		    }
            
            public IColumn Phone{
                get{
                    return this.GetColumn("Phone");
                }
            }
				
   			public static string PhoneColumn{
			      get{
        			return "Phone";
      			}
		    }
            
            public IColumn Mobile{
                get{
                    return this.GetColumn("Mobile");
                }
            }
				
   			public static string MobileColumn{
			      get{
        			return "Mobile";
      			}
		    }
            
            public IColumn Email{
                get{
                    return this.GetColumn("Email");
                }
            }
				
   			public static string EmailColumn{
			      get{
        			return "Email";
      			}
		    }
            
            public IColumn CriminalRecordsBureauReferenceNumber{
                get{
                    return this.GetColumn("CriminalRecordsBureauReferenceNumber");
                }
            }
				
   			public static string CriminalRecordsBureauReferenceNumberColumn{
			      get{
        			return "CriminalRecordsBureauReferenceNumber";
      			}
		    }
            
            public IColumn Notes{
                get{
                    return this.GetColumn("Notes");
                }
            }
				
   			public static string NotesColumn{
			      get{
        			return "Notes";
      			}
		    }
            
            public IColumn DateOfBirth{
                get{
                    return this.GetColumn("DateOfBirth");
                }
            }
				
   			public static string DateOfBirthColumn{
			      get{
        			return "DateOfBirth";
      			}
		    }
            
            public IColumn EthnicityId{
                get{
                    return this.GetColumn("EthnicityId");
                }
            }
				
   			public static string EthnicityIdColumn{
			      get{
        			return "EthnicityId";
      			}
		    }
            
            public IColumn GenderId{
                get{
                    return this.GetColumn("GenderId");
                }
            }
				
   			public static string GenderIdColumn{
			      get{
        			return "GenderId";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: PersonDisability
        /// Primary Key: Id
        /// </summary>

        public class PersonDisabilityTable: DatabaseTable {
            
            public PersonDisabilityTable(IDataProvider provider):base("PersonDisability",provider){
                ClassName = "PersonDisability";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("PersonId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("DisabilityId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn PersonId{
                get{
                    return this.GetColumn("PersonId");
                }
            }
				
   			public static string PersonIdColumn{
			      get{
        			return "PersonId";
      			}
		    }
            
            public IColumn DisabilityId{
                get{
                    return this.GetColumn("DisabilityId");
                }
            }
				
   			public static string DisabilityIdColumn{
			      get{
        			return "DisabilityId";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Placement
        /// Primary Key: Id
        /// </summary>

        public class PlacementTable: DatabaseTable {
            
            public PlacementTable(IDataProvider provider):base("Placement",provider){
                ClassName = "Placement";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("StudentId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Hours", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("PlacementLocationId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("PlacementTypeid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn StudentId{
                get{
                    return this.GetColumn("StudentId");
                }
            }
				
   			public static string StudentIdColumn{
			      get{
        			return "StudentId";
      			}
		    }
            
            public IColumn Date{
                get{
                    return this.GetColumn("Date");
                }
            }
				
   			public static string DateColumn{
			      get{
        			return "Date";
      			}
		    }
            
            public IColumn Hours{
                get{
                    return this.GetColumn("Hours");
                }
            }
				
   			public static string HoursColumn{
			      get{
        			return "Hours";
      			}
		    }
            
            public IColumn PlacementLocationId{
                get{
                    return this.GetColumn("PlacementLocationId");
                }
            }
				
   			public static string PlacementLocationIdColumn{
			      get{
        			return "PlacementLocationId";
      			}
		    }
            
            public IColumn PlacementTypeid{
                get{
                    return this.GetColumn("PlacementTypeid");
                }
            }
				
   			public static string PlacementTypeidColumn{
			      get{
        			return "PlacementTypeid";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: PlacementLocation
        /// Primary Key: Id
        /// </summary>

        public class PlacementLocationTable: DatabaseTable {
            
            public PlacementLocationTable(IDataProvider provider):base("PlacementLocation",provider){
                ClassName = "PlacementLocation";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: PlacementType
        /// Primary Key: Id
        /// </summary>

        public class PlacementTypeTable: DatabaseTable {
            
            public PlacementTypeTable(IDataProvider provider):base("PlacementType",provider){
                ClassName = "PlacementType";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Session
        /// Primary Key: Id
        /// </summary>

        public class SessionTable: DatabaseTable {
            
            public SessionTable(IDataProvider provider):base("Session",provider){
                ClassName = "Session";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("UnitId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
            
            public IColumn UnitId{
                get{
                    return this.GetColumn("UnitId");
                }
            }
				
   			public static string UnitIdColumn{
			      get{
        			return "UnitId";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Student
        /// Primary Key: Id
        /// </summary>

        public class StudentTable: DatabaseTable {
            
            public StudentTable(IDataProvider provider):base("Student",provider){
                ClassName = "Student";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("PersonId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn PersonId{
                get{
                    return this.GetColumn("PersonId");
                }
            }
				
   			public static string PersonIdColumn{
			      get{
        			return "PersonId";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: StudentCourseModule
        /// Primary Key: Id
        /// </summary>

        public class StudentCourseModuleTable: DatabaseTable {
            
            public StudentCourseModuleTable(IDataProvider provider):base("StudentCourseModule",provider){
                ClassName = "StudentCourseModule";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("StudentId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CourseModuleId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Complete", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CourseId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn StudentId{
                get{
                    return this.GetColumn("StudentId");
                }
            }
				
   			public static string StudentIdColumn{
			      get{
        			return "StudentId";
      			}
		    }
            
            public IColumn CourseModuleId{
                get{
                    return this.GetColumn("CourseModuleId");
                }
            }
				
   			public static string CourseModuleIdColumn{
			      get{
        			return "CourseModuleId";
      			}
		    }
            
            public IColumn Complete{
                get{
                    return this.GetColumn("Complete");
                }
            }
				
   			public static string CompleteColumn{
			      get{
        			return "Complete";
      			}
		    }
            
            public IColumn CourseId{
                get{
                    return this.GetColumn("CourseId");
                }
            }
				
   			public static string CourseIdColumn{
			      get{
        			return "CourseId";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: StudentCourseSession
        /// Primary Key: Id
        /// </summary>

        public class StudentCourseSessionTable: DatabaseTable {
            
            public StudentCourseSessionTable(IDataProvider provider):base("StudentCourseSession",provider){
                ClassName = "StudentCourseSession";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("StudentId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CourseSessionId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Complete", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CourseId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn StudentId{
                get{
                    return this.GetColumn("StudentId");
                }
            }
				
   			public static string StudentIdColumn{
			      get{
        			return "StudentId";
      			}
		    }
            
            public IColumn CourseSessionId{
                get{
                    return this.GetColumn("CourseSessionId");
                }
            }
				
   			public static string CourseSessionIdColumn{
			      get{
        			return "CourseSessionId";
      			}
		    }
            
            public IColumn Complete{
                get{
                    return this.GetColumn("Complete");
                }
            }
				
   			public static string CompleteColumn{
			      get{
        			return "Complete";
      			}
		    }
            
            public IColumn CourseId{
                get{
                    return this.GetColumn("CourseId");
                }
            }
				
   			public static string CourseIdColumn{
			      get{
        			return "CourseId";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: StudentTasterSession
        /// Primary Key: Id
        /// </summary>

        public class StudentTasterSessionTable: DatabaseTable {
            
            public StudentTasterSessionTable(IDataProvider provider):base("StudentTasterSession",provider){
                ClassName = "StudentTasterSession";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("StudentId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("TasterSessionId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn StudentId{
                get{
                    return this.GetColumn("StudentId");
                }
            }
				
   			public static string StudentIdColumn{
			      get{
        			return "StudentId";
      			}
		    }
            
            public IColumn TasterSessionId{
                get{
                    return this.GetColumn("TasterSessionId");
                }
            }
				
   			public static string TasterSessionIdColumn{
			      get{
        			return "TasterSessionId";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: TasterSession
        /// Primary Key: Id
        /// </summary>

        public class TasterSessionTable: DatabaseTable {
            
            public TasterSessionTable(IDataProvider provider):base("TasterSession",provider){
                ClassName = "TasterSession";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("CentreId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("TutorId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("DateAndTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
            
            public IColumn CentreId{
                get{
                    return this.GetColumn("CentreId");
                }
            }
				
   			public static string CentreIdColumn{
			      get{
        			return "CentreId";
      			}
		    }
            
            public IColumn TutorId{
                get{
                    return this.GetColumn("TutorId");
                }
            }
				
   			public static string TutorIdColumn{
			      get{
        			return "TutorId";
      			}
		    }
            
            public IColumn DateAndTime{
                get{
                    return this.GetColumn("DateAndTime");
                }
            }
				
   			public static string DateAndTimeColumn{
			      get{
        			return "DateAndTime";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Tutor
        /// Primary Key: Id
        /// </summary>

        public class TutorTable: DatabaseTable {
            
            public TutorTable(IDataProvider provider):base("Tutor",provider){
                ClassName = "Tutor";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("PersonId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn PersonId{
                get{
                    return this.GetColumn("PersonId");
                }
            }
				
   			public static string PersonIdColumn{
			      get{
        			return "PersonId";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Unit
        /// Primary Key: Id
        /// </summary>

        public class UnitTable: DatabaseTable {
            
            public UnitTable(IDataProvider provider):base("Unit",provider){
                ClassName = "Unit";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Verifier
        /// Primary Key: Id
        /// </summary>

        public class VerifierTable: DatabaseTable {
            
            public VerifierTable(IDataProvider provider):base("Verifier",provider){
                ClassName = "Verifier";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("PersonId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
   			public static string IdColumn{
			      get{
        			return "Id";
      			}
		    }
            
            public IColumn PersonId{
                get{
                    return this.GetColumn("PersonId");
                }
            }
				
   			public static string PersonIdColumn{
			      get{
        			return "PersonId";
      			}
		    }
            
                    
        }
        
}