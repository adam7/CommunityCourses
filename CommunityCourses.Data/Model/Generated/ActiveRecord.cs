


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using System.Collections;
using SubSonic;
using SubSonic.Repository;
using System.ComponentModel;
using System.Data.Common;
using CommunityCourses.Data;
using CommunityCourses.Data.Extensions;

namespace CommunityCourses.Data.Model
{
    
    
    /// <summary>
    /// A class which represents the Address table in the StudentTracking Database.
    /// </summary>
    public partial class Address: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Address> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Address>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Address> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Address item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Address item=new Address();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Address> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public Address(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Address.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Address>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Address(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Address(Expression<Func<Address, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Address> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<Address> _repo;
            
            if(db.TestMode){
                Address.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Address>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Address> GetRepo(){
            return GetRepo("","");
        }
        
        public static Address SingleOrDefault(Expression<Func<Address, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Address single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Address SingleOrDefault(Expression<Func<Address, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Address single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Address, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Address, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Address> Find(Expression<Func<Address, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Address> Find(Expression<Func<Address, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Address> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Address> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Address> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Address> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Address> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Address> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.FirstLine.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Address)){
                Address compare=(Address)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.FirstLine.ToString();
                    }

        public string DescriptorColumn() {
            return "FirstLine";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "FirstLine";
        }
        
        #region ' Foreign Keys '
        public IQueryable<Centre> Centres
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.Centre.GetRepo();
                  return from items in repo.GetAll()
                       where items.AddressId == _Id
                       select items;
            }
        }

        public IQueryable<Person> People
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.Person.GetRepo();
                  return from items in repo.GetAll()
                       where items.AddressId == _Id
                       select items;
            }
        }

        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _FirstLine;
        public string FirstLine
        {
            get { return _FirstLine; }
            set
            {
                if(_FirstLine!=value){
                    _FirstLine=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FirstLine");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _City;
        public string City
        {
            get { return _City; }
            set
            {
                if(_City!=value){
                    _City=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="City");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Postcode;
        public string Postcode
        {
            get { return _Postcode; }
            set
            {
                if(_Postcode!=value){
                    _Postcode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Postcode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Address, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Centre table in the StudentTracking Database.
    /// </summary>
    public partial class Centre: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Centre> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Centre>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Centre> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Centre item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Centre item=new Centre();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Centre> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public Centre(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Centre.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Centre>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Centre(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Centre(Expression<Func<Centre, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Centre> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<Centre> _repo;
            
            if(db.TestMode){
                Centre.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Centre>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Centre> GetRepo(){
            return GetRepo("","");
        }
        
        public static Centre SingleOrDefault(Expression<Func<Centre, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Centre single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Centre SingleOrDefault(Expression<Func<Centre, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Centre single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Centre, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Centre, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Centre> Find(Expression<Func<Centre, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Centre> Find(Expression<Func<Centre, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Centre> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Centre> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Centre> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Centre> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Centre> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Centre> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Centre)){
                Centre compare=(Centre)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        public Address Address      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Address.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _AddressId
                       select items).SingleOrDefault();
            }
						set { AddressId = value.Id; }
        }
        public IQueryable<Course> Courses
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.Course.GetRepo();
                  return from items in repo.GetAll()
                       where items.CentreId == _Id
                       select items;
            }
        }

        public IQueryable<TasterSession> TasterSessions
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.TasterSession.GetRepo();
                  return from items in repo.GetAll()
                       where items.CentreId == _Id
                       select items;
            }
        }

        public Person Contact      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Person.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _ContactId
                       select items).SingleOrDefault();
            }
						set { ContactId = value.Id; }
        }
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set
            {
                if(_Phone!=value){
                    _Phone=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Phone");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _AddressId;
        public int? AddressId
        {
            get { return _AddressId; }
            set
            {
                if(_AddressId!=value){
                    _AddressId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AddressId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _ContactId;
        public int? ContactId
        {
            get { return _ContactId; }
            set
            {
                if(_ContactId!=value){
                    _ContactId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ContactId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Centre, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Course table in the StudentTracking Database.
    /// </summary>
    public partial class Course: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Course> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Course>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Course> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Course item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Course item=new Course();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Course> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public Course(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Course.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Course>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Course(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Course(Expression<Func<Course, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Course> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<Course> _repo;
            
            if(db.TestMode){
                Course.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Course>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Course> GetRepo(){
            return GetRepo("","");
        }
        
        public static Course SingleOrDefault(Expression<Func<Course, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Course single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Course SingleOrDefault(Expression<Func<Course, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Course single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Course, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Course, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Course> Find(Expression<Func<Course, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Course> Find(Expression<Func<Course, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Course> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Course> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Course> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Course> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Course> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Course> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Course)){
                Course compare=(Course)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        public Centre Centre      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Centre.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _CentreId
                       select items).SingleOrDefault();
            }
						set { CentreId = value.Id; }
        }
        public IQueryable<CourseModule> CourseModules
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.CourseModule.GetRepo();
                  return from items in repo.GetAll()
                       where items.CourseId == _Id
                       select items;
            }
        }

        public IQueryable<CourseSession> CourseSessions
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.CourseSession.GetRepo();
                  return from items in repo.GetAll()
                       where items.CourseId == _Id
                       select items;
            }
        }

        public IQueryable<StudentCourseModule> StudentCourseModules
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.StudentCourseModule.GetRepo();
                  return from items in repo.GetAll()
                       where items.CourseId == _Id
                       select items;
            }
        }

        public IQueryable<StudentCourseSession> StudentCourseSessions
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.StudentCourseSession.GetRepo();
                  return from items in repo.GetAll()
                       where items.CourseId == _Id
                       select items;
            }
        }

        public Tutor Tutor      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Tutor.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _TutorId
                       select items).SingleOrDefault();
            }
						set { TutorId = value.Id; }
        }
        public Unit Unit      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Unit.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _UnitId
                       select items).SingleOrDefault();
            }
						set { UnitId = value.Id; }
        }
        public Verifier Verifier      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Verifier.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _VerifierId
                       select items).SingleOrDefault();
            }
						set { VerifierId = value.Id; }
        }
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _UnitId;
        public int? UnitId
        {
            get { return _UnitId; }
            set
            {
                if(_UnitId!=value){
                    _UnitId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UnitId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _CentreId;
        public int? CentreId
        {
            get { return _CentreId; }
            set
            {
                if(_CentreId!=value){
                    _CentreId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CentreId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _EndDate;
        public DateTime? EndDate
        {
            get { return _EndDate; }
            set
            {
                if(_EndDate!=value){
                    _EndDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EndDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _StartDate;
        public DateTime? StartDate
        {
            get { return _StartDate; }
            set
            {
                if(_StartDate!=value){
                    _StartDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StartDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _TutorId;
        public int? TutorId
        {
            get { return _TutorId; }
            set
            {
                if(_TutorId!=value){
                    _TutorId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TutorId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _VerifierId;
        public int? VerifierId
        {
            get { return _VerifierId; }
            set
            {
                if(_VerifierId!=value){
                    _VerifierId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="VerifierId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Course, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the CourseModule table in the StudentTracking Database.
    /// </summary>
    public partial class CourseModule: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<CourseModule> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<CourseModule>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<CourseModule> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(CourseModule item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                CourseModule item=new CourseModule();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<CourseModule> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public CourseModule(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                CourseModule.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<CourseModule>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public CourseModule(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public CourseModule(Expression<Func<CourseModule, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<CourseModule> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<CourseModule> _repo;
            
            if(db.TestMode){
                CourseModule.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<CourseModule>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<CourseModule> GetRepo(){
            return GetRepo("","");
        }
        
        public static CourseModule SingleOrDefault(Expression<Func<CourseModule, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            CourseModule single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static CourseModule SingleOrDefault(Expression<Func<CourseModule, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            CourseModule single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<CourseModule, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<CourseModule, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<CourseModule> Find(Expression<Func<CourseModule, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<CourseModule> Find(Expression<Func<CourseModule, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<CourseModule> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<CourseModule> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<CourseModule> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<CourseModule> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<CourseModule> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<CourseModule> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.CourseId.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(CourseModule)){
                CourseModule compare=(CourseModule)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.CourseId.ToString();
                    }

        public string DescriptorColumn() {
            return "CourseId";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "CourseId";
        }
        
        #region ' Foreign Keys '
        public Course Course      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Course.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _CourseId
                       select items).SingleOrDefault();
            }
						set { CourseId = value.Id; }
        }
        public IQueryable<StudentCourseModule> StudentCourseModules
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.StudentCourseModule.GetRepo();
                  return from items in repo.GetAll()
                       where items.CourseModuleId == _Id
                       select items;
            }
        }

        public Module Module      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Module.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _ModuleId
                       select items).SingleOrDefault();
            }
						set { ModuleId = value.Id; }
        }
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _CourseId;
        public int CourseId
        {
            get { return _CourseId; }
            set
            {
                if(_CourseId!=value){
                    _CourseId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CourseId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _ModuleId;
        public int ModuleId
        {
            get { return _ModuleId; }
            set
            {
                if(_ModuleId!=value){
                    _ModuleId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ModuleId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<CourseModule, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the CourseSession table in the StudentTracking Database.
    /// </summary>
    public partial class CourseSession: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<CourseSession> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<CourseSession>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<CourseSession> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(CourseSession item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                CourseSession item=new CourseSession();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<CourseSession> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public CourseSession(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                CourseSession.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<CourseSession>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public CourseSession(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public CourseSession(Expression<Func<CourseSession, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<CourseSession> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<CourseSession> _repo;
            
            if(db.TestMode){
                CourseSession.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<CourseSession>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<CourseSession> GetRepo(){
            return GetRepo("","");
        }
        
        public static CourseSession SingleOrDefault(Expression<Func<CourseSession, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            CourseSession single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static CourseSession SingleOrDefault(Expression<Func<CourseSession, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            CourseSession single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<CourseSession, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<CourseSession, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<CourseSession> Find(Expression<Func<CourseSession, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<CourseSession> Find(Expression<Func<CourseSession, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<CourseSession> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<CourseSession> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<CourseSession> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<CourseSession> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<CourseSession> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<CourseSession> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.SessionId.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(CourseSession)){
                CourseSession compare=(CourseSession)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.SessionId.ToString();
                    }

        public string DescriptorColumn() {
            return "SessionId";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "SessionId";
        }
        
        #region ' Foreign Keys '
        public Course Course      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Course.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _CourseId
                       select items).SingleOrDefault();
            }
						set { CourseId = value.Id; }
        }
        public IQueryable<StudentCourseSession> StudentCourseSessions
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.StudentCourseSession.GetRepo();
                  return from items in repo.GetAll()
                       where items.CourseSessionId == _Id
                       select items;
            }
        }

        public Session Session      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Session.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _SessionId
                       select items).SingleOrDefault();
            }
						set { SessionId = value.Id; }
        }
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _SessionId;
        public int SessionId
        {
            get { return _SessionId; }
            set
            {
                if(_SessionId!=value){
                    _SessionId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SessionId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _CourseId;
        public int CourseId
        {
            get { return _CourseId; }
            set
            {
                if(_CourseId!=value){
                    _CourseId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CourseId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _Date;
        public DateTime? Date
        {
            get { return _Date; }
            set
            {
                if(_Date!=value){
                    _Date=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Date");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<CourseSession, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Disability table in the StudentTracking Database.
    /// </summary>
    public partial class Disability: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Disability> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Disability>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Disability> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Disability item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Disability item=new Disability();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Disability> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public Disability(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Disability.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Disability>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Disability(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Disability(Expression<Func<Disability, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Disability> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<Disability> _repo;
            
            if(db.TestMode){
                Disability.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Disability>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Disability> GetRepo(){
            return GetRepo("","");
        }
        
        public static Disability SingleOrDefault(Expression<Func<Disability, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Disability single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Disability SingleOrDefault(Expression<Func<Disability, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Disability single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Disability, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Disability, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Disability> Find(Expression<Func<Disability, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Disability> Find(Expression<Func<Disability, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Disability> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Disability> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Disability> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Disability> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Disability> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Disability> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Disability)){
                Disability compare=(Disability)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        public IQueryable<PersonDisability> PersonDisabilities
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.PersonDisability.GetRepo();
                  return from items in repo.GetAll()
                       where items.DisabilityId == _Id
                       select items;
            }
        }

        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Disability, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Ethnicity table in the StudentTracking Database.
    /// </summary>
    public partial class Ethnicity: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Ethnicity> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Ethnicity>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Ethnicity> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Ethnicity item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Ethnicity item=new Ethnicity();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Ethnicity> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public Ethnicity(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Ethnicity.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Ethnicity>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Ethnicity(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Ethnicity(Expression<Func<Ethnicity, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Ethnicity> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<Ethnicity> _repo;
            
            if(db.TestMode){
                Ethnicity.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Ethnicity>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Ethnicity> GetRepo(){
            return GetRepo("","");
        }
        
        public static Ethnicity SingleOrDefault(Expression<Func<Ethnicity, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Ethnicity single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Ethnicity SingleOrDefault(Expression<Func<Ethnicity, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Ethnicity single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Ethnicity, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Ethnicity, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Ethnicity> Find(Expression<Func<Ethnicity, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Ethnicity> Find(Expression<Func<Ethnicity, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Ethnicity> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Ethnicity> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Ethnicity> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Ethnicity> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Ethnicity> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Ethnicity> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Ethnicity)){
                Ethnicity compare=(Ethnicity)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        public IQueryable<Person> People
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.Person.GetRepo();
                  return from items in repo.GetAll()
                       where items.EthnicityId == _Id
                       select items;
            }
        }

        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Ethnicity, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Module table in the StudentTracking Database.
    /// </summary>
    public partial class Module: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Module> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Module>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Module> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Module item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Module item=new Module();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Module> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public Module(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Module.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Module>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Module(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Module(Expression<Func<Module, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Module> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<Module> _repo;
            
            if(db.TestMode){
                Module.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Module>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Module> GetRepo(){
            return GetRepo("","");
        }
        
        public static Module SingleOrDefault(Expression<Func<Module, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Module single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Module SingleOrDefault(Expression<Func<Module, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Module single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Module, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Module, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Module> Find(Expression<Func<Module, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Module> Find(Expression<Func<Module, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Module> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Module> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Module> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Module> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Module> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Module> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Module)){
                Module compare=(Module)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        public IQueryable<CourseModule> CourseModules
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.CourseModule.GetRepo();
                  return from items in repo.GetAll()
                       where items.ModuleId == _Id
                       select items;
            }
        }

        public Unit Unit      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Unit.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _UnitId
                       select items).SingleOrDefault();
            }
						set { UnitId = value.Id; }
        }
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _UnitId;
        public int? UnitId
        {
            get { return _UnitId; }
            set
            {
                if(_UnitId!=value){
                    _UnitId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UnitId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Module, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Person table in the StudentTracking Database.
    /// </summary>
    public partial class Person: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Person> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Person>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Person> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Person item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Person item=new Person();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Person> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public Person(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Person.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Person>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Person(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Person(Expression<Func<Person, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Person> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<Person> _repo;
            
            if(db.TestMode){
                Person.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Person>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Person> GetRepo(){
            return GetRepo("","");
        }
        
        public static Person SingleOrDefault(Expression<Func<Person, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Person single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Person SingleOrDefault(Expression<Func<Person, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Person single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Person, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Person, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Person> Find(Expression<Func<Person, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Person> Find(Expression<Func<Person, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Person> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Person> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Person> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Person> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Person> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Person> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Title.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Person)){
                Person compare=(Person)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.Title.ToString();
                    }

        public string DescriptorColumn() {
            return "Title";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Title";
        }
        
        #region ' Foreign Keys '
        public Address Address      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Address.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _AddressId
                       select items).SingleOrDefault();
            }
						set { AddressId = value.Id; }
        }
        public Ethnicity Ethnicity      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Ethnicity.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _EthnicityId
                       select items).SingleOrDefault();
            }
						set { EthnicityId = value.Id; }
        }
        public IQueryable<Centre> Centres
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.Centre.GetRepo();
                  return from items in repo.GetAll()
                       where items.ContactId == _Id
                       select items;
            }
        }

        public IQueryable<PersonDisability> PersonDisabilities
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.PersonDisability.GetRepo();
                  return from items in repo.GetAll()
                       where items.PersonId == _Id
                       select items;
            }
        }

        public IQueryable<Student> Students
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.Student.GetRepo();
                  return from items in repo.GetAll()
                       where items.PersonId == _Id
                       select items;
            }
        }

        public IQueryable<Tutor> Tutors
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.Tutor.GetRepo();
                  return from items in repo.GetAll()
                       where items.PersonId == _Id
                       select items;
            }
        }

        public IQueryable<Verifier> Verifiers
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.Verifier.GetRepo();
                  return from items in repo.GetAll()
                       where items.PersonId == _Id
                       select items;
            }
        }

        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                if(_Title!=value){
                    _Title=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Title");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if(_FirstName!=value){
                    _FirstName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FirstName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if(_LastName!=value){
                    _LastName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _AddressId;
        public int? AddressId
        {
            get { return _AddressId; }
            set
            {
                if(_AddressId!=value){
                    _AddressId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AddressId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set
            {
                if(_Phone!=value){
                    _Phone=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Phone");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Mobile;
        public string Mobile
        {
            get { return _Mobile; }
            set
            {
                if(_Mobile!=value){
                    _Mobile=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Mobile");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                if(_Email!=value){
                    _Email=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Email");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CriminalRecordsBureauReferenceNumber;
        public string CriminalRecordsBureauReferenceNumber
        {
            get { return _CriminalRecordsBureauReferenceNumber; }
            set
            {
                if(_CriminalRecordsBureauReferenceNumber!=value){
                    _CriminalRecordsBureauReferenceNumber=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CriminalRecordsBureauReferenceNumber");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Notes;
        public string Notes
        {
            get { return _Notes; }
            set
            {
                if(_Notes!=value){
                    _Notes=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Notes");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _DateOfBirth;
        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set
            {
                if(_DateOfBirth!=value){
                    _DateOfBirth=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DateOfBirth");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _EthnicityId;
        public int EthnicityId
        {
            get { return _EthnicityId; }
            set
            {
                if(_EthnicityId!=value){
                    _EthnicityId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EthnicityId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _GenderId;
        public int GenderId
        {
            get { return _GenderId; }
            set
            {
                if(_GenderId!=value){
                    _GenderId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="GenderId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Person, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the PersonDisability table in the StudentTracking Database.
    /// </summary>
    public partial class PersonDisability: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<PersonDisability> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<PersonDisability>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<PersonDisability> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(PersonDisability item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                PersonDisability item=new PersonDisability();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<PersonDisability> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public PersonDisability(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                PersonDisability.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PersonDisability>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public PersonDisability(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public PersonDisability(Expression<Func<PersonDisability, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<PersonDisability> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<PersonDisability> _repo;
            
            if(db.TestMode){
                PersonDisability.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PersonDisability>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<PersonDisability> GetRepo(){
            return GetRepo("","");
        }
        
        public static PersonDisability SingleOrDefault(Expression<Func<PersonDisability, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            PersonDisability single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static PersonDisability SingleOrDefault(Expression<Func<PersonDisability, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            PersonDisability single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<PersonDisability, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<PersonDisability, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<PersonDisability> Find(Expression<Func<PersonDisability, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<PersonDisability> Find(Expression<Func<PersonDisability, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<PersonDisability> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<PersonDisability> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<PersonDisability> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<PersonDisability> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<PersonDisability> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<PersonDisability> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.PersonId.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(PersonDisability)){
                PersonDisability compare=(PersonDisability)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.PersonId.ToString();
                    }

        public string DescriptorColumn() {
            return "PersonId";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "PersonId";
        }
        
        #region ' Foreign Keys '
        public Disability Disability      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Disability.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _DisabilityId
                       select items).SingleOrDefault();
            }
						set { DisabilityId = value.Id; }
        }
        public Person Person      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Person.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _PersonId
                       select items).SingleOrDefault();
            }
						set { PersonId = value.Id; }
        }
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _PersonId;
        public int PersonId
        {
            get { return _PersonId; }
            set
            {
                if(_PersonId!=value){
                    _PersonId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PersonId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _DisabilityId;
        public int DisabilityId
        {
            get { return _DisabilityId; }
            set
            {
                if(_DisabilityId!=value){
                    _DisabilityId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DisabilityId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<PersonDisability, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Placement table in the StudentTracking Database.
    /// </summary>
    public partial class Placement: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Placement> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Placement>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Placement> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Placement item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Placement item=new Placement();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Placement> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public Placement(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Placement.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Placement>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Placement(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Placement(Expression<Func<Placement, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Placement> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<Placement> _repo;
            
            if(db.TestMode){
                Placement.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Placement>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Placement> GetRepo(){
            return GetRepo("","");
        }
        
        public static Placement SingleOrDefault(Expression<Func<Placement, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Placement single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Placement SingleOrDefault(Expression<Func<Placement, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Placement single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Placement, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Placement, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Placement> Find(Expression<Func<Placement, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Placement> Find(Expression<Func<Placement, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Placement> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Placement> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Placement> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Placement> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Placement> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Placement> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.StudentId.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Placement)){
                Placement compare=(Placement)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.StudentId.ToString();
                    }

        public string DescriptorColumn() {
            return "StudentId";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "StudentId";
        }
        
        #region ' Foreign Keys '
        public PlacementLocation PlacementLocation      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.PlacementLocation.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _PlacementLocationId
                       select items).SingleOrDefault();
            }
						set { PlacementLocationId = value.Id; }
        }
        public PlacementType PlacementType      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.PlacementType.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _PlacementTypeid
                       select items).SingleOrDefault();
            }
						set { PlacementTypeid = value.Id; }
        }
        public Student Student      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Student.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _StudentId
                       select items).SingleOrDefault();
            }
						set { StudentId = value.Id; }
        }
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _StudentId;
        public int? StudentId
        {
            get { return _StudentId; }
            set
            {
                if(_StudentId!=value){
                    _StudentId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StudentId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _Date;
        public DateTime? Date
        {
            get { return _Date; }
            set
            {
                if(_Date!=value){
                    _Date=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Date");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _Hours;
        public decimal? Hours
        {
            get { return _Hours; }
            set
            {
                if(_Hours!=value){
                    _Hours=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Hours");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _PlacementLocationId;
        public int? PlacementLocationId
        {
            get { return _PlacementLocationId; }
            set
            {
                if(_PlacementLocationId!=value){
                    _PlacementLocationId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PlacementLocationId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _PlacementTypeid;
        public int? PlacementTypeid
        {
            get { return _PlacementTypeid; }
            set
            {
                if(_PlacementTypeid!=value){
                    _PlacementTypeid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PlacementTypeid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Placement, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the PlacementLocation table in the StudentTracking Database.
    /// </summary>
    public partial class PlacementLocation: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<PlacementLocation> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<PlacementLocation>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<PlacementLocation> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(PlacementLocation item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                PlacementLocation item=new PlacementLocation();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<PlacementLocation> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public PlacementLocation(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                PlacementLocation.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PlacementLocation>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public PlacementLocation(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public PlacementLocation(Expression<Func<PlacementLocation, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<PlacementLocation> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<PlacementLocation> _repo;
            
            if(db.TestMode){
                PlacementLocation.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PlacementLocation>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<PlacementLocation> GetRepo(){
            return GetRepo("","");
        }
        
        public static PlacementLocation SingleOrDefault(Expression<Func<PlacementLocation, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            PlacementLocation single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static PlacementLocation SingleOrDefault(Expression<Func<PlacementLocation, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            PlacementLocation single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<PlacementLocation, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<PlacementLocation, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<PlacementLocation> Find(Expression<Func<PlacementLocation, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<PlacementLocation> Find(Expression<Func<PlacementLocation, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<PlacementLocation> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<PlacementLocation> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<PlacementLocation> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<PlacementLocation> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<PlacementLocation> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<PlacementLocation> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(PlacementLocation)){
                PlacementLocation compare=(PlacementLocation)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        public IQueryable<Placement> Placements
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.Placement.GetRepo();
                  return from items in repo.GetAll()
                       where items.PlacementLocationId == _Id
                       select items;
            }
        }

        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<PlacementLocation, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the PlacementType table in the StudentTracking Database.
    /// </summary>
    public partial class PlacementType: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<PlacementType> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<PlacementType>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<PlacementType> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(PlacementType item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                PlacementType item=new PlacementType();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<PlacementType> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public PlacementType(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                PlacementType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PlacementType>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public PlacementType(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public PlacementType(Expression<Func<PlacementType, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<PlacementType> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<PlacementType> _repo;
            
            if(db.TestMode){
                PlacementType.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PlacementType>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<PlacementType> GetRepo(){
            return GetRepo("","");
        }
        
        public static PlacementType SingleOrDefault(Expression<Func<PlacementType, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            PlacementType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static PlacementType SingleOrDefault(Expression<Func<PlacementType, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            PlacementType single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<PlacementType, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<PlacementType, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<PlacementType> Find(Expression<Func<PlacementType, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<PlacementType> Find(Expression<Func<PlacementType, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<PlacementType> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<PlacementType> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<PlacementType> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<PlacementType> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<PlacementType> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<PlacementType> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(PlacementType)){
                PlacementType compare=(PlacementType)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        public IQueryable<Placement> Placements
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.Placement.GetRepo();
                  return from items in repo.GetAll()
                       where items.PlacementTypeid == _Id
                       select items;
            }
        }

        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<PlacementType, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Session table in the StudentTracking Database.
    /// </summary>
    public partial class Session: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Session> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Session>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Session> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Session item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Session item=new Session();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Session> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public Session(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Session.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Session>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Session(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Session(Expression<Func<Session, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Session> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<Session> _repo;
            
            if(db.TestMode){
                Session.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Session>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Session> GetRepo(){
            return GetRepo("","");
        }
        
        public static Session SingleOrDefault(Expression<Func<Session, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Session single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Session SingleOrDefault(Expression<Func<Session, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Session single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Session, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Session, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Session> Find(Expression<Func<Session, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Session> Find(Expression<Func<Session, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Session> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Session> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Session> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Session> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Session> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Session> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Session)){
                Session compare=(Session)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        public IQueryable<CourseSession> CourseSessions
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.CourseSession.GetRepo();
                  return from items in repo.GetAll()
                       where items.SessionId == _Id
                       select items;
            }
        }

        public Unit Unit      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Unit.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _UnitId
                       select items).SingleOrDefault();
            }
						set { UnitId = value.Id; }
        }
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _UnitId;
        public int? UnitId
        {
            get { return _UnitId; }
            set
            {
                if(_UnitId!=value){
                    _UnitId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UnitId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Session, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Student table in the StudentTracking Database.
    /// </summary>
    public partial class Student: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Student> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Student>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Student> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Student item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Student item=new Student();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Student> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public Student(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Student.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Student>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Student(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Student(Expression<Func<Student, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Student> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<Student> _repo;
            
            if(db.TestMode){
                Student.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Student>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Student> GetRepo(){
            return GetRepo("","");
        }
        
        public static Student SingleOrDefault(Expression<Func<Student, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Student single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Student SingleOrDefault(Expression<Func<Student, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Student single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Student, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Student, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Student> Find(Expression<Func<Student, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Student> Find(Expression<Func<Student, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Student> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Student> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Student> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Student> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Student> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Student> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.PersonId.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Student)){
                Student compare=(Student)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.PersonId.ToString();
                    }

        public string DescriptorColumn() {
            return "PersonId";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "PersonId";
        }
        
        #region ' Foreign Keys '
        public Person Person      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Person.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _PersonId
                       select items).SingleOrDefault();
            }
						set { PersonId = value.Id; }
        }
        public IQueryable<Placement> Placements
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.Placement.GetRepo();
                  return from items in repo.GetAll()
                       where items.StudentId == _Id
                       select items;
            }
        }

        public IQueryable<StudentCourseModule> StudentCourseModules
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.StudentCourseModule.GetRepo();
                  return from items in repo.GetAll()
                       where items.StudentId == _Id
                       select items;
            }
        }

        public IQueryable<StudentCourseSession> StudentCourseSessions
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.StudentCourseSession.GetRepo();
                  return from items in repo.GetAll()
                       where items.StudentId == _Id
                       select items;
            }
        }

        public IQueryable<StudentTasterSession> StudentTasterSessions
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.StudentTasterSession.GetRepo();
                  return from items in repo.GetAll()
                       where items.StudentId == _Id
                       select items;
            }
        }

        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _PersonId;
        public int? PersonId
        {
            get { return _PersonId; }
            set
            {
                if(_PersonId!=value){
                    _PersonId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PersonId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Student, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the StudentCourseModule table in the StudentTracking Database.
    /// </summary>
    public partial class StudentCourseModule: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<StudentCourseModule> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<StudentCourseModule>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<StudentCourseModule> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(StudentCourseModule item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                StudentCourseModule item=new StudentCourseModule();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<StudentCourseModule> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public StudentCourseModule(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                StudentCourseModule.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<StudentCourseModule>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public StudentCourseModule(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public StudentCourseModule(Expression<Func<StudentCourseModule, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<StudentCourseModule> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<StudentCourseModule> _repo;
            
            if(db.TestMode){
                StudentCourseModule.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<StudentCourseModule>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<StudentCourseModule> GetRepo(){
            return GetRepo("","");
        }
        
        public static StudentCourseModule SingleOrDefault(Expression<Func<StudentCourseModule, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            StudentCourseModule single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static StudentCourseModule SingleOrDefault(Expression<Func<StudentCourseModule, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            StudentCourseModule single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<StudentCourseModule, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<StudentCourseModule, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<StudentCourseModule> Find(Expression<Func<StudentCourseModule, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<StudentCourseModule> Find(Expression<Func<StudentCourseModule, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<StudentCourseModule> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<StudentCourseModule> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<StudentCourseModule> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<StudentCourseModule> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<StudentCourseModule> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<StudentCourseModule> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.StudentId.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(StudentCourseModule)){
                StudentCourseModule compare=(StudentCourseModule)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.StudentId.ToString();
                    }

        public string DescriptorColumn() {
            return "StudentId";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "StudentId";
        }
        
        #region ' Foreign Keys '
        public Course Course      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Course.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _CourseId
                       select items).SingleOrDefault();
            }
						set { CourseId = value.Id; }
        }
        public CourseModule CourseModule      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.CourseModule.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _CourseModuleId
                       select items).SingleOrDefault();
            }
						set { CourseModuleId = value.Id; }
        }
        public Student Student      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Student.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _StudentId
                       select items).SingleOrDefault();
            }
						set { StudentId = value.Id; }
        }
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _StudentId;
        public int StudentId
        {
            get { return _StudentId; }
            set
            {
                if(_StudentId!=value){
                    _StudentId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StudentId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _CourseModuleId;
        public int CourseModuleId
        {
            get { return _CourseModuleId; }
            set
            {
                if(_CourseModuleId!=value){
                    _CourseModuleId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CourseModuleId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _Complete;
        public bool Complete
        {
            get { return _Complete; }
            set
            {
                if(_Complete!=value){
                    _Complete=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Complete");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _CourseId;
        public int CourseId
        {
            get { return _CourseId; }
            set
            {
                if(_CourseId!=value){
                    _CourseId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CourseId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<StudentCourseModule, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the StudentCourseSession table in the StudentTracking Database.
    /// </summary>
    public partial class StudentCourseSession: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<StudentCourseSession> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<StudentCourseSession>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<StudentCourseSession> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(StudentCourseSession item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                StudentCourseSession item=new StudentCourseSession();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<StudentCourseSession> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public StudentCourseSession(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                StudentCourseSession.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<StudentCourseSession>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public StudentCourseSession(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public StudentCourseSession(Expression<Func<StudentCourseSession, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<StudentCourseSession> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<StudentCourseSession> _repo;
            
            if(db.TestMode){
                StudentCourseSession.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<StudentCourseSession>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<StudentCourseSession> GetRepo(){
            return GetRepo("","");
        }
        
        public static StudentCourseSession SingleOrDefault(Expression<Func<StudentCourseSession, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            StudentCourseSession single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static StudentCourseSession SingleOrDefault(Expression<Func<StudentCourseSession, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            StudentCourseSession single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<StudentCourseSession, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<StudentCourseSession, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<StudentCourseSession> Find(Expression<Func<StudentCourseSession, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<StudentCourseSession> Find(Expression<Func<StudentCourseSession, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<StudentCourseSession> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<StudentCourseSession> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<StudentCourseSession> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<StudentCourseSession> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<StudentCourseSession> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<StudentCourseSession> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.StudentId.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(StudentCourseSession)){
                StudentCourseSession compare=(StudentCourseSession)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.StudentId.ToString();
                    }

        public string DescriptorColumn() {
            return "StudentId";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "StudentId";
        }
        
        #region ' Foreign Keys '
        public Course Course      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Course.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _CourseId
                       select items).SingleOrDefault();
            }
						set { CourseId = value.Id; }
        }
        public CourseSession CourseSession      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.CourseSession.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _CourseSessionId
                       select items).SingleOrDefault();
            }
						set { CourseSessionId = value.Id; }
        }
        public Student Student      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Student.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _StudentId
                       select items).SingleOrDefault();
            }
						set { StudentId = value.Id; }
        }
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _StudentId;
        public int StudentId
        {
            get { return _StudentId; }
            set
            {
                if(_StudentId!=value){
                    _StudentId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StudentId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _CourseSessionId;
        public int CourseSessionId
        {
            get { return _CourseSessionId; }
            set
            {
                if(_CourseSessionId!=value){
                    _CourseSessionId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CourseSessionId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _Complete;
        public bool Complete
        {
            get { return _Complete; }
            set
            {
                if(_Complete!=value){
                    _Complete=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Complete");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _CourseId;
        public int CourseId
        {
            get { return _CourseId; }
            set
            {
                if(_CourseId!=value){
                    _CourseId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CourseId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<StudentCourseSession, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the StudentTasterSession table in the StudentTracking Database.
    /// </summary>
    public partial class StudentTasterSession: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<StudentTasterSession> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<StudentTasterSession>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<StudentTasterSession> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(StudentTasterSession item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                StudentTasterSession item=new StudentTasterSession();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<StudentTasterSession> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public StudentTasterSession(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                StudentTasterSession.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<StudentTasterSession>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public StudentTasterSession(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public StudentTasterSession(Expression<Func<StudentTasterSession, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<StudentTasterSession> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<StudentTasterSession> _repo;
            
            if(db.TestMode){
                StudentTasterSession.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<StudentTasterSession>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<StudentTasterSession> GetRepo(){
            return GetRepo("","");
        }
        
        public static StudentTasterSession SingleOrDefault(Expression<Func<StudentTasterSession, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            StudentTasterSession single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static StudentTasterSession SingleOrDefault(Expression<Func<StudentTasterSession, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            StudentTasterSession single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<StudentTasterSession, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<StudentTasterSession, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<StudentTasterSession> Find(Expression<Func<StudentTasterSession, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<StudentTasterSession> Find(Expression<Func<StudentTasterSession, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<StudentTasterSession> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<StudentTasterSession> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<StudentTasterSession> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<StudentTasterSession> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<StudentTasterSession> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<StudentTasterSession> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.StudentId.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(StudentTasterSession)){
                StudentTasterSession compare=(StudentTasterSession)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.StudentId.ToString();
                    }

        public string DescriptorColumn() {
            return "StudentId";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "StudentId";
        }
        
        #region ' Foreign Keys '
        public Student Student      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Student.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _StudentId
                       select items).SingleOrDefault();
            }
						set { StudentId = value.Id; }
        }
        public TasterSession TasterSession      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.TasterSession.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _TasterSessionId
                       select items).SingleOrDefault();
            }
						set { TasterSessionId = value.Id; }
        }
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _StudentId;
        public int? StudentId
        {
            get { return _StudentId; }
            set
            {
                if(_StudentId!=value){
                    _StudentId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StudentId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _TasterSessionId;
        public int? TasterSessionId
        {
            get { return _TasterSessionId; }
            set
            {
                if(_TasterSessionId!=value){
                    _TasterSessionId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TasterSessionId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<StudentTasterSession, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the TasterSession table in the StudentTracking Database.
    /// </summary>
    public partial class TasterSession: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<TasterSession> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<TasterSession>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<TasterSession> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(TasterSession item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                TasterSession item=new TasterSession();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<TasterSession> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public TasterSession(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                TasterSession.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<TasterSession>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public TasterSession(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public TasterSession(Expression<Func<TasterSession, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<TasterSession> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<TasterSession> _repo;
            
            if(db.TestMode){
                TasterSession.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<TasterSession>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<TasterSession> GetRepo(){
            return GetRepo("","");
        }
        
        public static TasterSession SingleOrDefault(Expression<Func<TasterSession, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            TasterSession single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static TasterSession SingleOrDefault(Expression<Func<TasterSession, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            TasterSession single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<TasterSession, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<TasterSession, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<TasterSession> Find(Expression<Func<TasterSession, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<TasterSession> Find(Expression<Func<TasterSession, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<TasterSession> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<TasterSession> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<TasterSession> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<TasterSession> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<TasterSession> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<TasterSession> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(TasterSession)){
                TasterSession compare=(TasterSession)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        public Centre Centre      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Centre.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _CentreId
                       select items).SingleOrDefault();
            }
						set { CentreId = value.Id; }
        }
        public IQueryable<StudentTasterSession> StudentTasterSessions
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.StudentTasterSession.GetRepo();
                  return from items in repo.GetAll()
                       where items.TasterSessionId == _Id
                       select items;
            }
        }

        public Tutor Tutor      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Tutor.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _TutorId
                       select items).SingleOrDefault();
            }
						set { TutorId = value.Id; }
        }
        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _CentreId;
        public int? CentreId
        {
            get { return _CentreId; }
            set
            {
                if(_CentreId!=value){
                    _CentreId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CentreId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _TutorId;
        public int? TutorId
        {
            get { return _TutorId; }
            set
            {
                if(_TutorId!=value){
                    _TutorId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TutorId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _DateAndTime;
        public DateTime? DateAndTime
        {
            get { return _DateAndTime; }
            set
            {
                if(_DateAndTime!=value){
                    _DateAndTime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DateAndTime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<TasterSession, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Tutor table in the StudentTracking Database.
    /// </summary>
    public partial class Tutor: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Tutor> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Tutor>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Tutor> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Tutor item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Tutor item=new Tutor();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Tutor> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public Tutor(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Tutor.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Tutor>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Tutor(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Tutor(Expression<Func<Tutor, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Tutor> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<Tutor> _repo;
            
            if(db.TestMode){
                Tutor.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Tutor>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Tutor> GetRepo(){
            return GetRepo("","");
        }
        
        public static Tutor SingleOrDefault(Expression<Func<Tutor, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Tutor single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Tutor SingleOrDefault(Expression<Func<Tutor, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Tutor single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Tutor, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Tutor, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Tutor> Find(Expression<Func<Tutor, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Tutor> Find(Expression<Func<Tutor, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Tutor> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Tutor> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Tutor> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Tutor> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Tutor> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Tutor> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.PersonId.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Tutor)){
                Tutor compare=(Tutor)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.PersonId.ToString();
                    }

        public string DescriptorColumn() {
            return "PersonId";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "PersonId";
        }
        
        #region ' Foreign Keys '
        public Person Person      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Person.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _PersonId
                       select items).SingleOrDefault();
            }
						set { PersonId = value.Id; }
        }
        public IQueryable<Course> Courses
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.Course.GetRepo();
                  return from items in repo.GetAll()
                       where items.TutorId == _Id
                       select items;
            }
        }

        public IQueryable<TasterSession> TasterSessions
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.TasterSession.GetRepo();
                  return from items in repo.GetAll()
                       where items.TutorId == _Id
                       select items;
            }
        }

        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _PersonId;
        public int? PersonId
        {
            get { return _PersonId; }
            set
            {
                if(_PersonId!=value){
                    _PersonId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PersonId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Tutor, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Unit table in the StudentTracking Database.
    /// </summary>
    public partial class Unit: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Unit> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Unit>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Unit> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Unit item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Unit item=new Unit();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Unit> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public Unit(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Unit.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Unit>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Unit(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Unit(Expression<Func<Unit, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Unit> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<Unit> _repo;
            
            if(db.TestMode){
                Unit.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Unit>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Unit> GetRepo(){
            return GetRepo("","");
        }
        
        public static Unit SingleOrDefault(Expression<Func<Unit, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Unit single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Unit SingleOrDefault(Expression<Func<Unit, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Unit single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Unit, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Unit, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Unit> Find(Expression<Func<Unit, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Unit> Find(Expression<Func<Unit, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Unit> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Unit> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Unit> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Unit> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Unit> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Unit> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Unit)){
                Unit compare=(Unit)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        public IQueryable<Course> Courses
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.Course.GetRepo();
                  return from items in repo.GetAll()
                       where items.UnitId == _Id
                       select items;
            }
        }

        public IQueryable<Module> Modules
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.Module.GetRepo();
                  return from items in repo.GetAll()
                       where items.UnitId == _Id
                       select items;
            }
        }

        public IQueryable<Session> Sessions
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.Session.GetRepo();
                  return from items in repo.GetAll()
                       where items.UnitId == _Id
                       select items;
            }
        }

        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Unit, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the Verifier table in the StudentTracking Database.
    /// </summary>
    public partial class Verifier: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Verifier> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Verifier>(new CommunityCourses.Data.Model.StudentTrackingDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Verifier> testlist){
            SetTestRepo();
            _testRepo._items = testlist;
        }
        public static void Setup(Verifier item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Verifier item=new Verifier();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Verifier> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        CommunityCourses.Data.Model.StudentTrackingDB _db;
        public Verifier(string connectionString, string providerName) {

            _db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Verifier.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Verifier>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Verifier(){
             _db=new CommunityCourses.Data.Model.StudentTrackingDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Verifier(Expression<Func<Verifier, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Verifier> GetRepo(string connectionString, string providerName){
            CommunityCourses.Data.Model.StudentTrackingDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new CommunityCourses.Data.Model.StudentTrackingDB();
            }else{
                db=new CommunityCourses.Data.Model.StudentTrackingDB(connectionString, providerName);
            }
            IRepository<Verifier> _repo;
            
            if(db.TestMode){
                Verifier.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Verifier>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Verifier> GetRepo(){
            return GetRepo("","");
        }
        
        public static Verifier SingleOrDefault(Expression<Func<Verifier, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Verifier single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Verifier SingleOrDefault(Expression<Func<Verifier, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Verifier single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Verifier, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Verifier, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Verifier> Find(Expression<Func<Verifier, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Verifier> Find(Expression<Func<Verifier, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Verifier> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Verifier> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Verifier> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Verifier> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Verifier> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Verifier> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.PersonId.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Verifier)){
                Verifier compare=(Verifier)obj;
                return (int)compare.KeyValue()==(int)this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.PersonId.ToString();
                    }

        public string DescriptorColumn() {
            return "PersonId";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "PersonId";
        }
        
        #region ' Foreign Keys '
        public Person Person      
				{
            get
            {
                  var repo=CommunityCourses.Data.Model.Person.GetRepo();
                  return (from items in repo.GetAll()
                       where items.Id == _PersonId
                       select items).SingleOrDefault();
            }
						set { PersonId = value.Id; }
        }
        public IQueryable<Course> Courses
        {
            get
            {
                
                  var repo=CommunityCourses.Data.Model.Course.GetRepo();
                  return from items in repo.GetAll()
                       where items.VerifierId == _Id
                       select items;
            }
        }

        #endregion
        

        int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _PersonId;
        public int? PersonId
        {
            get { return _PersonId; }
            set
            {
                if(_PersonId!=value){
                    _PersonId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PersonId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){            
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
            Validate();
            
            if(this._dirtyColumns.Count>0)
                _repo.Update(this,provider);
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){
            Validate();
            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Verifier, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        
        public void Validate()
        {
            if(!this.IsValid())
            {
                throw new ValidationException(this.GetErrors());
            }
        }

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
}
