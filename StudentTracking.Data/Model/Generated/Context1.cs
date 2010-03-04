


using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using SubSonic.Linq.Structure;
using SubSonic.Query;
using SubSonic.Schema;
using System.Data.Common;
using System.Collections.Generic;

namespace StudentTracking.Data.Model
{
    public partial class StudentTrackingDB : IQuerySurface
    {

        public IDataProvider DataProvider;
        public DbQueryProvider provider;
        
        public bool TestMode
		{
            get
			{
                return DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public StudentTrackingDB() 
        { 
            DataProvider = ProviderFactory.GetProvider("StudentTracking");
            Init();
        }

        public StudentTrackingDB(string connectionStringName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionStringName);
            Init();
        }

		public StudentTrackingDB(string connectionString, string providerName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionString,providerName);
            Init();
        }

		public ITable FindByPrimaryKey(string pkName)
        {
            return DataProvider.Schema.Tables.SingleOrDefault(x => x.PrimaryKey.Name.Equals(pkName, StringComparison.InvariantCultureIgnoreCase));
        }

        public Query<T> GetQuery<T>()
        {
            return new Query<T>(provider);
        }
        
        public ITable FindTable(string tableName)
        {
            return DataProvider.FindTable(tableName);
        }
               
        public IDataProvider Provider
        {
            get { return DataProvider; }
            set {DataProvider=value;}
        }
        
        public DbQueryProvider QueryProvider
        {
            get { return provider; }
        }
        
        BatchQuery _batch = null;
        public void Queue<T>(IQueryable<T> qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void Queue(ISqlQuery qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void ExecuteTransaction(IList<DbCommand> commands)
		{
            if(!TestMode)
			{
                using(var connection = commands[0].Connection)
				{
                   if (connection.State == ConnectionState.Closed)
                        connection.Open();
                   
                   using (var trans = connection.BeginTransaction()) 
				   {
                        foreach (var cmd in commands) 
						{
                            cmd.Transaction = trans;
                            cmd.Connection = connection;
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    connection.Close();
                }
            }
        }

        public IDataReader ExecuteBatch()
        {
            if (_batch == null)
                throw new InvalidOperationException("There's nothing in the queue");
            if(!TestMode)
                return _batch.ExecuteReader();
            return null;
        }
			
        public Query<Address> Addresses { get; set; }
        public Query<Centre> Centres { get; set; }
        public Query<Course> Courses { get; set; }
        public Query<CourseModule> CourseModules { get; set; }
        public Query<CourseSession> CourseSessions { get; set; }
        public Query<Disability> Disabilities { get; set; }
        public Query<Ethnicity> Ethnicities { get; set; }
        public Query<Module> Modules { get; set; }
        public Query<Person> People { get; set; }
        public Query<PersonDisability> PersonDisabilities { get; set; }
        public Query<Placement> Placements { get; set; }
        public Query<PlacementLocation> PlacementLocations { get; set; }
        public Query<PlacementType> PlacementTypes { get; set; }
        public Query<Session> Sessions { get; set; }
        public Query<Student> Students { get; set; }
        public Query<StudentCourseModule> StudentCourseModules { get; set; }
        public Query<StudentCourseSession> StudentCourseSessions { get; set; }
        public Query<StudentTasterSession> StudentTasterSessions { get; set; }
        public Query<TasterSession> TasterSessions { get; set; }
        public Query<Tutor> Tutors { get; set; }
        public Query<Unit> Units { get; set; }
        public Query<Verifier> Verifiers { get; set; }

			

        #region ' Aggregates and SubSonic Queries '
        public Select SelectColumns(params string[] columns)
        {
            return new Select(DataProvider, columns);
        }

        public Select Select
        {
            get { return new Select(this.Provider); }
        }

        public Insert Insert
		{
            get { return new Insert(this.Provider); }
        }

        public Update<T> Update<T>() where T:new()
		{
            return new Update<T>(this.Provider);
        }

        public SqlQuery Delete<T>(Expression<Func<T,bool>> column) where T:new()
        {
            LambdaExpression lamda = column;
            SqlQuery result = new Delete<T>(this.Provider);
            result = result.From<T>();
            result.Constraints=lamda.ParseConstraints().ToList();
            return result;
        }

        public SqlQuery Max<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = DataProvider.FindTable(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Max)).From(tableName);
        }

        public SqlQuery Min<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Min)).From(tableName);
        }

        public SqlQuery Sum<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Sum)).From(tableName);
        }

        public SqlQuery Avg<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Avg)).From(tableName);
        }

        public SqlQuery Count<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Count)).From(tableName);
        }

        public SqlQuery Variance<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Var)).From(tableName);
        }

        public SqlQuery StandardDeviation<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.StDev)).From(tableName);
        }

        #endregion

        void Init()
        {
            provider = new DbQueryProvider(this.Provider);

            #region ' Query Defs '
            Addresses = new Query<Address>(provider);
            Centres = new Query<Centre>(provider);
            Courses = new Query<Course>(provider);
            CourseModules = new Query<CourseModule>(provider);
            CourseSessions = new Query<CourseSession>(provider);
            Disabilities = new Query<Disability>(provider);
            Ethnicities = new Query<Ethnicity>(provider);
            Modules = new Query<Module>(provider);
            People = new Query<Person>(provider);
            PersonDisabilities = new Query<PersonDisability>(provider);
            Placements = new Query<Placement>(provider);
            PlacementLocations = new Query<PlacementLocation>(provider);
            PlacementTypes = new Query<PlacementType>(provider);
            Sessions = new Query<Session>(provider);
            Students = new Query<Student>(provider);
            StudentCourseModules = new Query<StudentCourseModule>(provider);
            StudentCourseSessions = new Query<StudentCourseSession>(provider);
            StudentTasterSessions = new Query<StudentTasterSession>(provider);
            TasterSessions = new Query<TasterSession>(provider);
            Tutors = new Query<Tutor>(provider);
            Units = new Query<Unit>(provider);
            Verifiers = new Query<Verifier>(provider);
            #endregion


            #region ' Schemas '
        	if(DataProvider.Schema.Tables.Count == 0)
			{
            	DataProvider.Schema.Tables.Add(new AddressTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new CentreTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new CourseTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new CourseModuleTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new CourseSessionTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new DisabilityTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new EthnicityTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new ModuleTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new PersonTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new PersonDisabilityTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new PlacementTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new PlacementLocationTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new PlacementTypeTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new SessionTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new StudentTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new StudentCourseModuleTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new StudentCourseSessionTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new StudentTasterSessionTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new TasterSessionTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new TutorTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new UnitTable(DataProvider));
            	DataProvider.Schema.Tables.Add(new VerifierTable(DataProvider));
            }
            #endregion
        }
    }
}