using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VVPSMS.Domain.Models;

public partial class VvpsmsdbContext : DbContext
{
    public VvpsmsdbContext()
    {
    }

    public VvpsmsdbContext(DbContextOptions<VvpsmsdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdmissionDocument> AdmissionDocuments { get; set; }

    public virtual DbSet<AdmissionForm> AdmissionForms { get; set; }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<ArAdmissionDocument> ArAdmissionDocuments { get; set; }

    public virtual DbSet<ArAdmissionForm> ArAdmissionForms { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<MstAcademicYear> MstAcademicYears { get; set; }

    public virtual DbSet<MstAdmissionStatus> MstAdmissionStatuses { get; set; }

    public virtual DbSet<MstClass> MstClasses { get; set; }

    public virtual DbSet<MstGroupOfSchool> MstGroupOfSchools { get; set; }

    public virtual DbSet<MstRoleGroup> MstRoleGroups { get; set; }

    public virtual DbSet<MstSchool> MstSchools { get; set; }

    public virtual DbSet<MstSchoolGrade> MstSchoolGrades { get; set; }

    public virtual DbSet<MstSchoolStream> MstSchoolStreams { get; set; }

    public virtual DbSet<MstUser> MstUsers { get; set; }

    public virtual DbSet<MstUserRole> MstUserRoles { get; set; }

    public virtual DbSet<SiblingInfo> SiblingInfos { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<UserRegistration> UserRegistrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.59.3;Initial Catalog=VVPSMSDB;User Id=sa;Password=D#$q2023P@s;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;Integrated Security=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdmissionDocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Admissio__9666E8ACF17E9C5A");

            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DocumentName)
                .HasMaxLength(255)
                .HasColumnName("document_name");
            entity.Property(e => e.DocumentPath)
                .HasMaxLength(255)
                .HasColumnName("document_path");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

            entity.HasOne(d => d.Form).WithMany(p => p.AdmissionDocuments)
                .HasForeignKey(d => d.FormId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Admission__form___5BE2A6F2");
        });

        modelBuilder.Entity<AdmissionForm>(entity =>
        {
            entity.HasKey(e => e.FormId).HasName("PK__Admissio__190E16C96D57F416");

            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.AcademicId).HasColumnName("academic_id");
            entity.Property(e => e.AdmissionStatus).HasColumnName("admission_status");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Declaration).HasColumnName("declaration");
            entity.Property(e => e.DetailsExpulsion)
                .HasColumnType("text")
                .HasColumnName("details_expulsion");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.HighestQualification1)
                .HasMaxLength(255)
                .HasColumnName("highest_qualification1");
            entity.Property(e => e.HighestQualification2)
                .HasMaxLength(255)
                .HasColumnName("highest_qualification2");
            entity.Property(e => e.LearningDisabilities).HasColumnName("learning_disabilities");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ParentContact1)
                .HasMaxLength(15)
                .HasColumnName("parent_contact1");
            entity.Property(e => e.ParentContact2)
                .HasMaxLength(15)
                .HasColumnName("parent_contact2");
            entity.Property(e => e.ParentEmail1)
                .HasMaxLength(255)
                .HasColumnName("parent_email1");
            entity.Property(e => e.ParentEmail2)
                .HasMaxLength(255)
                .HasColumnName("parent_email2");
            entity.Property(e => e.ParentName1)
                .HasMaxLength(255)
                .HasColumnName("parent_name1");
            entity.Property(e => e.ParentName2)
                .HasMaxLength(255)
                .HasColumnName("parent_name2");
            entity.Property(e => e.PreferredContact)
                .HasMaxLength(15)
                .HasColumnName("preferred_contact");
            entity.Property(e => e.PreviousSchool)
                .HasMaxLength(255)
                .HasColumnName("previous_school");
            entity.Property(e => e.ReasonDescription)
                .HasColumnType("text")
                .HasColumnName("reason_description");
            entity.Property(e => e.SchoolCode).HasColumnName("school_code");
            entity.Property(e => e.SiblingsYn)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("siblings_YN");
            entity.Property(e => e.SpecialNeeds).HasColumnName("special_needs");
            entity.Property(e => e.StreamId).HasColumnName("stream_id");
            entity.Property(e => e.StudentAge).HasColumnName("student_age");
            entity.Property(e => e.StudentDob)
                .HasColumnType("datetime")
                .HasColumnName("student_dob");
            entity.Property(e => e.StudentExpelled).HasColumnName("student_expelled");
            entity.Property(e => e.StudentGender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("student_gender");
            entity.Property(e => e.StudentGivenName)
                .HasMaxLength(255)
                .HasColumnName("student_givenName");
            entity.Property(e => e.StudentSurname)
                .HasMaxLength(255)
                .HasColumnName("student_surname");

            entity.HasOne(d => d.Class).WithMany(p => p.AdmissionForms)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Admission__class__5CD6CB2B");

            entity.HasOne(d => d.Grade).WithMany(p => p.AdmissionForms)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Admission__grade__5DCAEF64");

            entity.HasOne(d => d.Stream).WithMany(p => p.AdmissionForms)
                .HasForeignKey(d => d.StreamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Admission__strea__5EBF139D");
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Announce__3ED787664E1D801B");

            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.PostDescription)
                .HasColumnType("text")
                .HasColumnName("post_description");
            entity.Property(e => e.PostGroups)
                .HasMaxLength(255)
                .HasColumnName("post_groups");
            entity.Property(e => e.PostTitle)
                .HasMaxLength(255)
                .HasColumnName("post_title");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Announcements)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Announcem__user___5FB337D6");
        });

        modelBuilder.Entity<ArAdmissionDocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__ArAdmiss__9666E8ACE0582680");

            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DocumentName)
                .HasMaxLength(255)
                .HasColumnName("document_name");
            entity.Property(e => e.DocumentPath)
                .HasMaxLength(255)
                .HasColumnName("document_path");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
        });

        modelBuilder.Entity<ArAdmissionForm>(entity =>
        {
            entity.HasKey(e => e.FormId).HasName("PK__ArAdmiss__190E16C9760839DF");

            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.AcademicId).HasColumnName("academic_id");
            entity.Property(e => e.AdmissionStatus).HasColumnName("admission_status");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Declaration).HasColumnName("declaration");
            entity.Property(e => e.DetailsExpulsion)
                .HasColumnType("text")
                .HasColumnName("details_expulsion");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.HighestQualification1)
                .HasMaxLength(255)
                .HasColumnName("highest_qualification1");
            entity.Property(e => e.HighestQualification2)
                .HasMaxLength(255)
                .HasColumnName("highest_qualification2");
            entity.Property(e => e.LearningDisabilities).HasColumnName("learning_disabilities");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ParentContact1)
                .HasMaxLength(15)
                .HasColumnName("parent_contact1");
            entity.Property(e => e.ParentContact2)
                .HasMaxLength(15)
                .HasColumnName("parent_contact2");
            entity.Property(e => e.ParentEmail1)
                .HasMaxLength(255)
                .HasColumnName("parent_email1");
            entity.Property(e => e.ParentEmail2)
                .HasMaxLength(255)
                .HasColumnName("parent_email2");
            entity.Property(e => e.ParentName1)
                .HasMaxLength(255)
                .HasColumnName("parent_name1");
            entity.Property(e => e.ParentName2)
                .HasMaxLength(255)
                .HasColumnName("parent_name2");
            entity.Property(e => e.PreferredContact)
                .HasMaxLength(15)
                .HasColumnName("preferred_contact");
            entity.Property(e => e.PreviousSchool)
                .HasMaxLength(255)
                .HasColumnName("previous_school");
            entity.Property(e => e.ReasonDescription)
                .HasColumnType("text")
                .HasColumnName("reason_description");
            entity.Property(e => e.SchoolCode).HasColumnName("school_code");
            entity.Property(e => e.SiblingsYn)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("siblings_YN");
            entity.Property(e => e.SpecialNeeds).HasColumnName("special_needs");
            entity.Property(e => e.StreamId).HasColumnName("stream_id");
            entity.Property(e => e.StudentAge).HasColumnName("student_age");
            entity.Property(e => e.StudentDob)
                .HasColumnType("datetime")
                .HasColumnName("student_dob");
            entity.Property(e => e.StudentExpelled).HasColumnName("student_expelled");
            entity.Property(e => e.StudentGender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("student_gender");
            entity.Property(e => e.StudentGivenName)
                .HasMaxLength(255)
                .HasColumnName("student_givenName");
            entity.Property(e => e.StudentSurname)
                .HasMaxLength(255)
                .HasColumnName("student_surname");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Document__9666E8AC80E08E5F");

            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DocumentName)
                .HasMaxLength(255)
                .HasColumnName("document_name");
            entity.Property(e => e.DocumentPath)
                .HasMaxLength(255)
                .HasColumnName("document_path");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
        });

        modelBuilder.Entity<MstAcademicYear>(entity =>
        {
            entity.HasKey(e => e.AcademicId).HasName("PK__MstAcade__B5573C11CF284802");

            entity.Property(e => e.AcademicId).HasColumnName("academicId");
            entity.Property(e => e.AcademicEnddate)
                .HasColumnType("datetime")
                .HasColumnName("academic_enddate");
            entity.Property(e => e.AcademicStartdate)
                .HasColumnType("datetime")
                .HasColumnName("academic_startdate");
            entity.Property(e => e.AcademictermNo)
                .HasMaxLength(255)
                .HasColumnName("academicterm_no");
            entity.Property(e => e.AcademicyearFrom)
                .HasColumnType("datetime")
                .HasColumnName("academicyear_from");
            entity.Property(e => e.AcademicyearName)
                .HasMaxLength(255)
                .HasColumnName("academicyear_name");
            entity.Property(e => e.AcademicyearTo)
                .HasColumnType("datetime")
                .HasColumnName("academicyear_to");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
        });

        modelBuilder.Entity<MstAdmissionStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId);

            entity.ToTable("MstAdmissionStatus");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.StatusCode).HasColumnName("status_code");
            entity.Property(e => e.StatusDescription)
                .HasMaxLength(255)
                .HasColumnName("status_description");
        });

        modelBuilder.Entity<MstClass>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__MstClass__FDF479865F589D45");

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.ActiveYn).HasColumnName("activeYN");
            entity.Property(e => e.ClassName)
                .HasMaxLength(255)
                .HasColumnName("class_name");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
        });

        modelBuilder.Entity<MstGroupOfSchool>(entity =>
        {
            entity.HasKey(e => e.GroupofSchoolsId).HasName("PK__MstGroup__037B607A42BAAE9A");

            entity.Property(e => e.GroupofSchoolsId).HasColumnName("groupofSchools_id");
            entity.Property(e => e.ActiveYn).HasColumnName("activeYN");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.GroupAddress)
                .HasMaxLength(255)
                .HasColumnName("group_address");
            entity.Property(e => e.GroupofSchoolsCode)
                .HasMaxLength(255)
                .HasColumnName("groupofSchools_Code");
            entity.Property(e => e.GroupofSchoolsLogo)
                .HasMaxLength(255)
                .HasColumnName("groupofSchools_Logo");
            entity.Property(e => e.GroupofSchoolsName)
                .HasMaxLength(255)
                .HasColumnName("groupofSchools_Name");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
        });

        modelBuilder.Entity<MstRoleGroup>(entity =>
        {
            entity.HasKey(e => e.RolegroupId).HasName("PK__MstRoleG__680F3A928876E98D");

            entity.Property(e => e.RolegroupId).HasColumnName("rolegroup_id");
            entity.Property(e => e.ActiveYn).HasColumnName("activeYN");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RolegroupDescription)
                .HasMaxLength(255)
                .HasColumnName("rolegroup_description");
            entity.Property(e => e.RolegroupName)
                .HasMaxLength(255)
                .HasColumnName("rolegroup_name");

            entity.HasOne(d => d.Role).WithMany(p => p.MstRoleGroups)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MstRoleGr__role___628FA481");
        });

        modelBuilder.Entity<MstSchool>(entity =>
        {
            entity.HasKey(e => new { e.SchoolId, e.SchoolCode }).HasName("PK__MstSchoo__BDAC4F174F7A91D2");

            entity.Property(e => e.SchoolId)
                .ValueGeneratedOnAdd()
                .HasColumnName("school_id");
            entity.Property(e => e.SchoolCode)
                .HasMaxLength(255)
                .HasColumnName("school_code");
            entity.Property(e => e.ActiveYn).HasColumnName("activeYN");
            entity.Property(e => e.ClassesAvailable)
                .HasMaxLength(255)
                .HasColumnName("classes_available");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.GradesAvailable)
                .HasMaxLength(255)
                .HasColumnName("grades_available");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.SchoolAddress1)
                .HasMaxLength(255)
                .HasColumnName("school_address1");
            entity.Property(e => e.SchoolAddress2)
                .HasMaxLength(255)
                .HasColumnName("school_address2");
            entity.Property(e => e.SchoolCoordinates)
                .HasMaxLength(255)
                .HasColumnName("school_coordinates");
            entity.Property(e => e.SchoolCountry)
                .HasMaxLength(255)
                .HasColumnName("school_country");
            entity.Property(e => e.SchoolDescription)
                .HasMaxLength(255)
                .HasColumnName("school_description");
            entity.Property(e => e.SchoolDistrict)
                .HasMaxLength(255)
                .HasColumnName("school_district");
            entity.Property(e => e.SchoolLandmark)
                .HasMaxLength(255)
                .HasColumnName("school_landmark");
            entity.Property(e => e.SchoolLogopath)
                .HasMaxLength(255)
                .HasColumnName("school_logopath");
            entity.Property(e => e.SchoolName)
                .HasMaxLength(255)
                .HasColumnName("school_name");
            entity.Property(e => e.SchoolPhone)
                .HasMaxLength(15)
                .HasColumnName("school_phone");
            entity.Property(e => e.SchoolState)
                .HasMaxLength(255)
                .HasColumnName("school_state");
            entity.Property(e => e.SchoolWebsite)
                .HasMaxLength(255)
                .HasColumnName("school_website");
            entity.Property(e => e.StreamsAvailable)
                .HasMaxLength(255)
                .HasColumnName("streams_available");
        });

        modelBuilder.Entity<MstSchoolGrade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__MstSchoo__3A8F732C455B7EA8");

            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.ActiveYn).HasColumnName("activeYN");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.GradeName)
                .HasMaxLength(255)
                .HasColumnName("grade_name");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
        });

        modelBuilder.Entity<MstSchoolStream>(entity =>
        {
            entity.HasKey(e => e.StreamId).HasName("PK__MstSchoo__9DD95BAE4AB55786");

            entity.Property(e => e.StreamId).HasColumnName("stream_id");
            entity.Property(e => e.ActiveYn).HasColumnName("activeYN");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.StreamName)
                .HasMaxLength(255)
                .HasColumnName("stream_name");
        });

        modelBuilder.Entity<MstUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__MstUsers__B9BE370F794D4AC2");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Enforce2Fa).HasColumnName("enforce2FA");
            entity.Property(e => e.LastloginAt)
                .HasColumnType("datetime")
                .HasColumnName("lastlogin_at");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.UserGivenName)
                .HasMaxLength(255)
                .HasColumnName("user_givenName");
            entity.Property(e => e.UserLoginType)
                .HasMaxLength(255)
                .HasColumnName("user_loginType");
            entity.Property(e => e.UserPhone)
                .HasMaxLength(15)
                .HasColumnName("user_phone");
            entity.Property(e => e.UserRole)
                .HasMaxLength(255)
                .HasColumnName("user_role");
            entity.Property(e => e.UserSurname)
                .HasMaxLength(255)
                .HasColumnName("user_surname");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
            entity.Property(e => e.Userpassword)
                .HasMaxLength(255)
                .HasColumnName("userpassword");
        });

        modelBuilder.Entity<MstUserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__MstUserR__760965CCA52A7C48");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.ActiveYn).HasColumnName("activeYN");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<SiblingInfo>(entity =>
        {
            entity.HasKey(e => e.SiblingId).HasName("PK__SiblingI__7A415E3F49157DBC");

            entity.ToTable("SiblingInfo");

            entity.Property(e => e.SiblingId).HasColumnName("sibling_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.SiblingDob)
                .HasColumnType("datetime")
                .HasColumnName("sibling_dob");
            entity.Property(e => e.SiblingGender)
                .HasMaxLength(255)
                .HasColumnName("sibling_gender");
            entity.Property(e => e.SiblingName)
                .HasMaxLength(255)
                .HasColumnName("sibling_name");
            entity.Property(e => e.SiblingSchool)
                .HasMaxLength(255)
                .HasColumnName("sibling_school");

            entity.HasOne(d => d.Form).WithMany(p => p.SiblingInfos)
                .HasForeignKey(d => d.FormId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SiblingIn__form___6383C8BA");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__2A33069A04934CFA");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Enforce2Fa).HasColumnName("enforce2FA");
            entity.Property(e => e.LastloginAt)
                .HasColumnType("datetime")
                .HasColumnName("lastlogin_at");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.StudentGivenName)
                .HasMaxLength(255)
                .HasColumnName("student_givenName");
            entity.Property(e => e.StudentLoginType)
                .HasMaxLength(255)
                .HasColumnName("student_loginType");
            entity.Property(e => e.StudentPassword)
                .HasMaxLength(255)
                .HasColumnName("student_password");
            entity.Property(e => e.StudentPhone)
                .HasMaxLength(15)
                .HasColumnName("student_phone");
            entity.Property(e => e.StudentRole)
                .HasMaxLength(255)
                .HasColumnName("student_role");
            entity.Property(e => e.StudentSurname)
                .HasMaxLength(255)
                .HasColumnName("student_surname");
            entity.Property(e => e.StudentUsername)
                .HasMaxLength(255)
                .HasColumnName("student_username");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teachers__03AE777E1B21B22D");

            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Enforce2Fa).HasColumnName("enforce2FA");
            entity.Property(e => e.LastloginAt)
                .HasColumnType("datetime")
                .HasColumnName("lastlogin_at");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.SchoolCode).HasColumnName("school_code");
            entity.Property(e => e.TeacherGivenName)
                .HasMaxLength(255)
                .HasColumnName("teacher_givenName");
            entity.Property(e => e.TeacherLoginType)
                .HasMaxLength(255)
                .HasColumnName("teacher_loginType");
            entity.Property(e => e.TeacherPassword)
                .HasMaxLength(255)
                .HasColumnName("teacher_password");
            entity.Property(e => e.TeacherPhone)
                .HasMaxLength(15)
                .HasColumnName("teacher_phone");
            entity.Property(e => e.TeacherRole)
                .HasMaxLength(255)
                .HasColumnName("teacher_role");
            entity.Property(e => e.TeacherSurname)
                .HasMaxLength(255)
                .HasColumnName("teacher_surname");
            entity.Property(e => e.TeacherUsername)
                .HasMaxLength(255)
                .HasColumnName("teacher_username");
        });

        modelBuilder.Entity<UserRegistration>(entity =>
        {
            entity.HasKey(e => e.RegisterId).HasName("PK__UserRegi__1418262FB3813CF7");

            entity.ToTable("UserRegistration");

            entity.Property(e => e.RegisterId).HasColumnName("register_id");
            entity.Property(e => e.ActiveYn).HasColumnName("activeYN");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Enforce2Fa).HasColumnName("enforce2FA");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.RegisterEmail)
                .HasMaxLength(255)
                .HasColumnName("register_email");
            entity.Property(e => e.RegisterGivenname)
                .HasMaxLength(255)
                .HasColumnName("register_givenname");
            entity.Property(e => e.RegisterPassword)
                .HasMaxLength(255)
                .HasColumnName("register_password");
            entity.Property(e => e.RegisterPhone)
                .HasMaxLength(15)
                .HasColumnName("register_phone");
            entity.Property(e => e.RegisterSurname)
                .HasMaxLength(255)
                .HasColumnName("register_surname");
            entity.Property(e => e.RegisterType)
                .HasMaxLength(255)
                .HasColumnName("register_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
