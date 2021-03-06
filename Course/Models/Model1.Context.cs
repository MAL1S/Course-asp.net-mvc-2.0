//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Course.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class UniversityDB2Entities : DbContext
    {
        public UniversityDB2Entities()
            : base("name=UniversityDB2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Journal> Journal { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
    
        public virtual ObjectResult<GetFirstTask_Result> GetFirstTask(Nullable<System.DateTime> dateFrom, Nullable<System.DateTime> dateTo)
        {
            var dateFromParameter = dateFrom.HasValue ?
                new ObjectParameter("dateFrom", dateFrom) :
                new ObjectParameter("dateFrom", typeof(System.DateTime));
    
            var dateToParameter = dateTo.HasValue ?
                new ObjectParameter("dateTo", dateTo) :
                new ObjectParameter("dateTo", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFirstTask_Result>("GetFirstTask", dateFromParameter, dateToParameter);
        }
    
        public virtual ObjectResult<GetSecondTask_Result> GetSecondTask(Nullable<int> maxFives)
        {
            var maxFivesParameter = maxFives.HasValue ?
                new ObjectParameter("maxFives", maxFives) :
                new ObjectParameter("maxFives", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetSecondTask_Result>("GetSecondTask", maxFivesParameter);
        }
    
        public virtual int InflateJournalData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InflateJournalData");
        }
    
        public virtual int InflateStudentData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InflateStudentData");
        }
    
        public virtual int InflateSubjectData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InflateSubjectData");
        }
    
        public virtual int Journal_D(Nullable<int> recordID)
        {
            var recordIDParameter = recordID.HasValue ?
                new ObjectParameter("RecordID", recordID) :
                new ObjectParameter("RecordID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Journal_D", recordIDParameter);
        }
    
        public virtual int Journal_I(Nullable<int> subject_ID, Nullable<int> student_ID, string mark, Nullable<System.DateTime> markDate)
        {
            var subject_IDParameter = subject_ID.HasValue ?
                new ObjectParameter("Subject_ID", subject_ID) :
                new ObjectParameter("Subject_ID", typeof(int));
    
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            var markParameter = mark != null ?
                new ObjectParameter("Mark", mark) :
                new ObjectParameter("Mark", typeof(string));
    
            var markDateParameter = markDate.HasValue ?
                new ObjectParameter("MarkDate", markDate) :
                new ObjectParameter("MarkDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Journal_I", subject_IDParameter, student_IDParameter, markParameter, markDateParameter);
        }
    
        public virtual ObjectResult<Journal_S_Result> Journal_S()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Journal_S_Result>("Journal_S");
        }
    
        public virtual int Journal_U(Nullable<int> recordID, Nullable<int> subject_ID, Nullable<int> student_ID, string mark, Nullable<System.DateTime> markDate)
        {
            var recordIDParameter = recordID.HasValue ?
                new ObjectParameter("RecordID", recordID) :
                new ObjectParameter("RecordID", typeof(int));
    
            var subject_IDParameter = subject_ID.HasValue ?
                new ObjectParameter("Subject_ID", subject_ID) :
                new ObjectParameter("Subject_ID", typeof(int));
    
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            var markParameter = mark != null ?
                new ObjectParameter("Mark", mark) :
                new ObjectParameter("Mark", typeof(string));
    
            var markDateParameter = markDate.HasValue ?
                new ObjectParameter("MarkDate", markDate) :
                new ObjectParameter("MarkDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Journal_U", recordIDParameter, subject_IDParameter, student_IDParameter, markParameter, markDateParameter);
        }
    
        public virtual int Student_D(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Student_D", idParameter);
        }
    
        public virtual int Student_I(Nullable<int> id, string name, string address, Nullable<long> phoneNumber, string parentsName)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("address", address) :
                new ObjectParameter("address", typeof(string));
    
            var phoneNumberParameter = phoneNumber.HasValue ?
                new ObjectParameter("phoneNumber", phoneNumber) :
                new ObjectParameter("phoneNumber", typeof(long));
    
            var parentsNameParameter = parentsName != null ?
                new ObjectParameter("parentsName", parentsName) :
                new ObjectParameter("parentsName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Student_I", idParameter, nameParameter, addressParameter, phoneNumberParameter, parentsNameParameter);
        }
    
        public virtual ObjectResult<Student_S_Result> Student_S()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Student_S_Result>("Student_S");
        }
    
        public virtual int Student_U(Nullable<int> id, string name, string address, Nullable<long> phoneNumber, string parentsName)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("address", address) :
                new ObjectParameter("address", typeof(string));
    
            var phoneNumberParameter = phoneNumber.HasValue ?
                new ObjectParameter("phoneNumber", phoneNumber) :
                new ObjectParameter("phoneNumber", typeof(long));
    
            var parentsNameParameter = parentsName != null ?
                new ObjectParameter("parentsName", parentsName) :
                new ObjectParameter("parentsName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Student_U", idParameter, nameParameter, addressParameter, phoneNumberParameter, parentsNameParameter);
        }
    
        public virtual int Subject_D(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Subject_D", iDParameter);
        }
    
        public virtual int Subject_I(string subjectName, string teacherName)
        {
            var subjectNameParameter = subjectName != null ?
                new ObjectParameter("SubjectName", subjectName) :
                new ObjectParameter("SubjectName", typeof(string));
    
            var teacherNameParameter = teacherName != null ?
                new ObjectParameter("TeacherName", teacherName) :
                new ObjectParameter("TeacherName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Subject_I", subjectNameParameter, teacherNameParameter);
        }
    
        public virtual ObjectResult<Subject_S_Result> Subject_S()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Subject_S_Result>("Subject_S");
        }
    
        public virtual int Subject_U(Nullable<int> id, string subjectName, string teacherName)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var subjectNameParameter = subjectName != null ?
                new ObjectParameter("subjectName", subjectName) :
                new ObjectParameter("subjectName", typeof(string));
    
            var teacherNameParameter = teacherName != null ?
                new ObjectParameter("teacherName", teacherName) :
                new ObjectParameter("teacherName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Subject_U", idParameter, subjectNameParameter, teacherNameParameter);
        }
    }
}
