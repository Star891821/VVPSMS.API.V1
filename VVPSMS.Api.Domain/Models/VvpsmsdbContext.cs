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

    public virtual DbSet<AdmissionEnquiryDetail> AdmissionEnquiryDetails { get; set; }

    public virtual DbSet<AdmissionForm> AdmissionForms { get; set; }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<ArAdmissionDocument> ArAdmissionDocuments { get; set; }

    public virtual DbSet<ArAdmissionEnquiryDetail> ArAdmissionEnquiryDetails { get; set; }

    public virtual DbSet<ArAdmissionForm> ArAdmissionForms { get; set; }

    public virtual DbSet<ArEmergencyContactDetail> ArEmergencyContactDetails { get; set; }

    public virtual DbSet<ArFamilyOrGuardianInfoDetail> ArFamilyOrGuardianInfoDetails { get; set; }

    public virtual DbSet<ArPreviousSchoolDetail> ArPreviousSchoolDetails { get; set; }

    public virtual DbSet<ArSiblingInfo> ArSiblingInfos { get; set; }

    public virtual DbSet<ArStudentHealthInfoDetail> ArStudentHealthInfoDetails { get; set; }

    public virtual DbSet<ArStudentIllnessDetail> ArStudentIllnessDetails { get; set; }

    public virtual DbSet<ArStudentInfoDetail> ArStudentInfoDetails { get; set; }

    public virtual DbSet<ArTransportDetail> ArTransportDetails { get; set; }

    public virtual DbSet<EmergencyContactDetail> EmergencyContactDetails { get; set; }

    public virtual DbSet<FamilyOrGuardianInfoDetail> FamilyOrGuardianInfoDetails { get; set; }

    public virtual DbSet<MstAcademicYear> MstAcademicYears { get; set; }

    public virtual DbSet<MstAdmissionStatus> MstAdmissionStatuses { get; set; }

    public virtual DbSet<MstClass> MstClasses { get; set; }

    public virtual DbSet<MstDocumentType> MstDocumentTypes { get; set; }

    public virtual DbSet<MstEnquiryAnswerDetail> MstEnquiryAnswerDetails { get; set; }

    public virtual DbSet<MstEnquiryQuestionDetail> MstEnquiryQuestionDetails { get; set; }

    public virtual DbSet<MstEnquiryQuestionTypeDetail> MstEnquiryQuestionTypeDetails { get; set; }

    public virtual DbSet<MstGroupOfSchool> MstGroupOfSchools { get; set; }

    public virtual DbSet<MstPermission> MstPermissions { get; set; }

    public virtual DbSet<MstRoleGroup> MstRoleGroups { get; set; }

    public virtual DbSet<MstRoleType> MstRoleTypes { get; set; }

    public virtual DbSet<MstSchool> MstSchools { get; set; }

    public virtual DbSet<MstSchoolGrade> MstSchoolGrades { get; set; }

    public virtual DbSet<MstSchoolStream> MstSchoolStreams { get; set; }

    public virtual DbSet<MstUser> MstUsers { get; set; }

    public virtual DbSet<MstUserRole> MstUserRoles { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<ParentDocument> ParentDocuments { get; set; }

    public virtual DbSet<PreviousSchoolDetail> PreviousSchoolDetails { get; set; }

    public virtual DbSet<RolePermissionsMapping> RolePermissionsMappings { get; set; }

    public virtual DbSet<SiblingInfo> SiblingInfos { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentDocument> StudentDocuments { get; set; }

    public virtual DbSet<StudentHealthInfoDetail> StudentHealthInfoDetails { get; set; }

    public virtual DbSet<StudentIllnessDetail> StudentIllnessDetails { get; set; }

    public virtual DbSet<StudentInfoDetail> StudentInfoDetails { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherDocument> TeacherDocuments { get; set; }

    public virtual DbSet<TrackAdmissionStatus> TrackAdmissionStatuses { get; set; }

    public virtual DbSet<TransportDetail> TransportDetails { get; set; }

    public virtual DbSet<UserRegistration> UserRegistrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI;Initial Catalog=VVPSMSDB;User Id=sa;Password=1992;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;Integrated Security=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdmissionDocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Admissio__9666E8ACE9FA084E");

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
            entity.Property(e => e.MstdocumenttypesId).HasColumnName("mstdocumenttypes_id");

            entity.HasOne(d => d.Form).WithMany(p => p.AdmissionDocuments)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("FK__Admission__form___30992191");

            entity.HasOne(d => d.Mstdocumenttypes).WithMany(p => p.AdmissionDocuments)
                .HasForeignKey(d => d.MstdocumenttypesId)
                .HasConstraintName("FK__Admission__mstdo__318D45CA");
        });

        modelBuilder.Entity<AdmissionEnquiryDetail>(entity =>
        {
            entity.HasKey(e => e.AdmissionenquirydetailsId).HasName("PK__Admissio__88CE46A22BB430DD");

            entity.Property(e => e.AdmissionenquirydetailsId).HasColumnName("admissionenquirydetails_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EnquiryResponse)
                .HasMaxLength(255)
                .HasColumnName("enquiry_response");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.MstenquiryquestiondetailsId).HasColumnName("mstenquiryquestiondetails_id");

            entity.HasOne(d => d.Form).WithMany(p => p.AdmissionEnquiryDetails)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("FK__Admission__form___14F1071C");

            entity.HasOne(d => d.Mstenquiryquestiondetails).WithMany(p => p.AdmissionEnquiryDetails)
                .HasForeignKey(d => d.MstenquiryquestiondetailsId)
                .HasConstraintName("FK__Admission__msten__15E52B55");
        });

        modelBuilder.Entity<AdmissionForm>(entity =>
        {
            entity.HasKey(e => e.FormId).HasName("PK__Admissio__190E16C93DAB2F65");

            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.AcademicId).HasColumnName("academic_id");
            entity.Property(e => e.AdmissionStatus).HasColumnName("admission_status");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.SchoolId).HasColumnName("school_id");
            entity.Property(e => e.StreamId).HasColumnName("stream_id");
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Announce__3ED787662F6F2517");

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
                .HasConstraintName("FK__Announcem__user___324172E1");
        });

        modelBuilder.Entity<ArAdmissionDocument>(entity =>
        {
            entity.HasKey(e => e.ArdocumentId).HasName("PK__ArAdmiss__1A41F9E1728CCCFD");

            entity.Property(e => e.ArdocumentId).HasColumnName("ardocument_id");
            entity.Property(e => e.ArformId).HasColumnName("arform_id");
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
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.MstdocumenttypesId).HasColumnName("mstdocumenttypes_id");

            entity.HasOne(d => d.Arform).WithMany(p => p.ArAdmissionDocuments)
                .HasForeignKey(d => d.ArformId)
                .HasConstraintName("FK__ArAdmissi__arfor__26DAAD2D");
        });

        modelBuilder.Entity<ArAdmissionEnquiryDetail>(entity =>
        {
            entity.HasKey(e => e.AradmissionenquirydetailsId).HasName("PK__ArAdmiss__F8977DB840CCFC4C");

            entity.Property(e => e.AradmissionenquirydetailsId).HasColumnName("aradmissionenquirydetails_id");
            entity.Property(e => e.ArformId).HasColumnName("arform_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EnquiryResponse)
                .HasMaxLength(255)
                .HasColumnName("enquiry_response");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.MstenquiryquestiondetailsId).HasColumnName("mstenquiryquestiondetails_id");

            entity.HasOne(d => d.Arform).WithMany(p => p.ArAdmissionEnquiryDetails)
                .HasForeignKey(d => d.ArformId)
                .HasConstraintName("FK__ArAdmissi__arfor__27CED166");
        });

        modelBuilder.Entity<ArAdmissionForm>(entity =>
        {
            entity.HasKey(e => e.ArformId).HasName("PK__ArAdmiss__E16173DEA782B820");

            entity.Property(e => e.ArformId).HasColumnName("arform_id");
            entity.Property(e => e.AcademicId).HasColumnName("academic_id");
            entity.Property(e => e.AdmissionStatus).HasColumnName("admission_status");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.SchoolId).HasColumnName("school_id");
            entity.Property(e => e.StreamId).HasColumnName("stream_id");
        });

        modelBuilder.Entity<ArEmergencyContactDetail>(entity =>
        {
            entity.HasKey(e => e.AremergencycontactdetailsId).HasName("PK__ArEmerge__77D76A8A0028CD2A");

            entity.Property(e => e.AremergencycontactdetailsId).HasColumnName("aremergencycontactdetails_id");
            entity.Property(e => e.ArformId).HasColumnName("arform_id");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(100)
                .HasColumnName("contact_number");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameofparentIncaseofstaffWard)
                .HasMaxLength(255)
                .HasColumnName("nameofparent_incaseofstaff_ward");
            entity.Property(e => e.Relationship)
                .HasMaxLength(255)
                .HasColumnName("relationship");

            entity.HasOne(d => d.Arform).WithMany(p => p.ArEmergencyContactDetails)
                .HasForeignKey(d => d.ArformId)
                .HasConstraintName("FK__ArEmergen__arfor__52EE3995");
        });

        modelBuilder.Entity<ArFamilyOrGuardianInfoDetail>(entity =>
        {
            entity.HasKey(e => e.ArfamilyorguardianinfodetailsId).HasName("PK__ArFamily__B13E14275E6AE9D0");

            entity.Property(e => e.ArfamilyorguardianinfodetailsId).HasColumnName("arfamilyorguardianinfodetails_id");
            entity.Property(e => e.AadharNumber)
                .HasMaxLength(20)
                .HasColumnName("aadhar_number");
            entity.Property(e => e.AnnualIncome).HasColumnName("annual_income");
            entity.Property(e => e.ArformId).HasColumnName("arform_id");
            entity.Property(e => e.Contact)
                .HasMaxLength(15)
                .HasColumnName("contact");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DesignationNameofcompany)
                .HasMaxLength(80)
                .HasColumnName("designation_nameofcompany");
            entity.Property(e => e.Dob)
                .HasMaxLength(255)
                .HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.HighestQualification)
                .HasMaxLength(255)
                .HasColumnName("highest_qualification");
            entity.Property(e => e.Legalguardian).HasColumnName("legalguardian");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Occupation)
                .HasMaxLength(100)
                .HasColumnName("occupation");
            entity.Property(e => e.OfficeAddress)
                .HasMaxLength(255)
                .HasColumnName("office_address");
            entity.Property(e => e.PanNumber)
                .HasMaxLength(100)
                .HasColumnName("pan_number");
            entity.Property(e => e.Passportexpirydate)
                .HasColumnType("datetime")
                .HasColumnName("passportexpirydate");
            entity.Property(e => e.Passportissuedate)
                .HasColumnType("datetime")
                .HasColumnName("passportissuedate");
            entity.Property(e => e.Passportnumber)
                .HasMaxLength(100)
                .HasColumnName("passportnumber");
            entity.Property(e => e.Preferredcontact)
                .HasMaxLength(255)
                .HasColumnName("preferredcontact");
            entity.Property(e => e.Relationshiptype)
                .HasMaxLength(100)
                .HasColumnName("relationshiptype");

            entity.HasOne(d => d.Arform).WithMany(p => p.ArFamilyOrGuardianInfoDetails)
                .HasForeignKey(d => d.ArformId)
                .HasConstraintName("FK__ArFamilyO__arfor__094A4A46");
        });

        modelBuilder.Entity<ArPreviousSchoolDetail>(entity =>
        {
            entity.HasKey(e => e.ArpreviousschooldetailsId).HasName("PK__ArPrevio__9CE648D1ABE2B3DC");

            entity.Property(e => e.ArpreviousschooldetailsId).HasColumnName("arpreviousschooldetails_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.ArformId).HasColumnName("arform_id");
            entity.Property(e => e.ClassCompleted)
                .HasMaxLength(255)
                .HasColumnName("class_completed");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Curriculum)
                .HasMaxLength(255)
                .HasColumnName("curriculum");
            entity.Property(e => e.DateOfLeavingschool)
                .HasColumnType("datetime")
                .HasColumnName("dateOf_leavingschool");
            entity.Property(e => e.HasapplicanteverExpelledorsuspended)
                .HasMaxLength(255)
                .HasColumnName("hasapplicantever_expelledorsuspended");
            entity.Property(e => e.MediumofInstruction)
                .HasMaxLength(255)
                .HasColumnName("mediumof_instruction");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.NameSchool)
                .HasMaxLength(255)
                .HasColumnName("name_school");
            entity.Property(e => e.ReasonForleaving)
                .HasMaxLength(255)
                .HasColumnName("reason_forleaving");
            entity.Property(e => e.Reasonforsuspension)
                .HasMaxLength(25)
                .HasColumnName("reasonforsuspension");
            entity.Property(e => e.YearsAttended)
                .HasMaxLength(255)
                .HasColumnName("years_attended");

            entity.HasOne(d => d.Arform).WithMany(p => p.ArPreviousSchoolDetails)
                .HasForeignKey(d => d.ArformId)
                .HasConstraintName("FK__ArPreviou__arfor__54D68207");
        });

        modelBuilder.Entity<ArSiblingInfo>(entity =>
        {
            entity.HasKey(e => e.ArsiblingId).HasName("PK__ArSiblin__43F3CB251BED0F78");

            entity.ToTable("ArSiblingInfo");

            entity.Property(e => e.ArsiblingId).HasColumnName("arsibling_id");
            entity.Property(e => e.ArformId).HasColumnName("arform_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
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

            entity.HasOne(d => d.Arform).WithMany(p => p.ArSiblingInfos)
                .HasForeignKey(d => d.ArformId)
                .HasConstraintName("FK__ArSibling__arfor__55CAA640");
        });

        modelBuilder.Entity<ArStudentHealthInfoDetail>(entity =>
        {
            entity.HasKey(e => e.ArstudenthealthinfodetailsId).HasName("PK__ArStuden__BE3BCE9F178FE93F");

            entity.Property(e => e.ArstudenthealthinfodetailsId).HasColumnName("arstudenthealthinfodetails_id");
            entity.Property(e => e.AllergiesIfAny)
                .HasMaxLength(255)
                .HasColumnName("allergies_ifAny");
            entity.Property(e => e.ArformId).HasColumnName("arform_id");
            entity.Property(e => e.BloodGroup)
                .HasMaxLength(255)
                .HasColumnName("blood_group");
            entity.Property(e => e.ChildName)
                .HasMaxLength(255)
                .HasColumnName("child_name");
            entity.Property(e => e.Class)
                .HasMaxLength(255)
                .HasColumnName("class");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.HealthHistory)
                .HasMaxLength(255)
                .HasColumnName("health_history");
            entity.Property(e => e.Height)
                .HasMaxLength(25)
                .HasColumnName("height");
            entity.Property(e => e.IdentificationMarks)
                .HasMaxLength(255)
                .HasColumnName("identification_marks");
            entity.Property(e => e.ImmunizationStatus)
                .HasMaxLength(255)
                .HasColumnName("immunization_status");
            entity.Property(e => e.LearningDisabilities)
                .HasMaxLength(255)
                .HasColumnName("learning_disabilities");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.RegularmedicineTakenbystudent)
                .HasMaxLength(255)
                .HasColumnName("regularmedicine_takenbystudent");
            entity.Property(e => e.SpecialNeeds)
                .HasMaxLength(255)
                .HasColumnName("special_needs");
            entity.Property(e => e.VisionLeft)
                .HasMaxLength(255)
                .HasColumnName("vision_left");
            entity.Property(e => e.VisionRight)
                .HasMaxLength(255)
                .HasColumnName("vision_right");
            entity.Property(e => e.Weight)
                .HasMaxLength(100)
                .HasColumnName("weight");

            entity.HasOne(d => d.Arform).WithMany(p => p.ArStudentHealthInfoDetails)
                .HasForeignKey(d => d.ArformId)
                .HasConstraintName("FK__ArStudent__arfor__56BECA79");
        });

        modelBuilder.Entity<ArStudentIllnessDetail>(entity =>
        {
            entity.HasKey(e => e.ArstudentillnessdetailsId).HasName("PK__ArStuden__B5758E025F19B952");

            entity.Property(e => e.ArstudentillnessdetailsId).HasColumnName("arstudentillnessdetails_id");
            entity.Property(e => e.ArformId).HasColumnName("arform_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.IllnessDate)
                .HasMaxLength(255)
                .HasColumnName("illness_date");
            entity.Property(e => e.IllnessDetails)
                .HasMaxLength(255)
                .HasColumnName("illness_details");
            entity.Property(e => e.IllnessName)
                .HasMaxLength(255)
                .HasColumnName("illness_name");
            entity.Property(e => e.IllnessType)
                .HasMaxLength(255)
                .HasColumnName("illness_type");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

            entity.HasOne(d => d.Arform).WithMany(p => p.ArStudentIllnessDetails)
                .HasForeignKey(d => d.ArformId)
                .HasConstraintName("FK__ArStudent__arfor__57B2EEB2");
        });

        modelBuilder.Entity<ArStudentInfoDetail>(entity =>
        {
            entity.HasKey(e => e.ArstudentinfoId).HasName("PK__ArStuden__09A3E45E2A07E415");

            entity.Property(e => e.ArstudentinfoId).HasColumnName("arstudentinfo_id");
            entity.Property(e => e.AadharNumber)
                .HasMaxLength(20)
                .HasColumnName("aadhar_number");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.ArformId).HasColumnName("arform_id");
            entity.Property(e => e.Caste)
                .HasMaxLength(100)
                .HasColumnName("caste");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DateOfExpiry)
                .HasColumnType("datetime")
                .HasColumnName("date_of_expiry");
            entity.Property(e => e.DateOfIssue)
                .HasColumnType("datetime")
                .HasColumnName("date_of_issue");
            entity.Property(e => e.Dob)
                .HasMaxLength(255)
                .HasColumnName("dob");
            entity.Property(e => e.DobInWords)
                .HasMaxLength(255)
                .HasColumnName("dob_in_words");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(80)
                .HasColumnName("gender");
            entity.Property(e => e.Ispresentaddresspermanentaddress).HasDefaultValueSql("('FALSE')");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(255)
                .HasColumnName("middle_name");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.MotherTongue)
                .HasMaxLength(255)
                .HasColumnName("mother_tongue");
            entity.Property(e => e.Nationality)
                .HasMaxLength(100)
                .HasColumnName("nationality");
            entity.Property(e => e.NoOfFamilymembers).HasColumnName("no_of_familymembers");
            entity.Property(e => e.OtherKnownLanguages)
                .HasMaxLength(255)
                .HasColumnName("other_knownLanguages");
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(100)
                .HasColumnName("passport_number");
            entity.Property(e => e.PermanentAddress)
                .HasMaxLength(255)
                .HasColumnName("permanent_address");
            entity.Property(e => e.PresentAddress)
                .HasMaxLength(255)
                .HasColumnName("present_address");
            entity.Property(e => e.Religion)
                .HasMaxLength(100)
                .HasColumnName("religion");
            entity.Property(e => e.SatsChildNumber)
                .HasMaxLength(100)
                .HasColumnName("sats_child_number");
            entity.Property(e => e.StudentLivesWith)
                .HasMaxLength(255)
                .HasColumnName("student_lives_with");
            entity.Property(e => e.TypeofFamily)
                .HasMaxLength(255)
                .HasColumnName("typeof_family");
            entity.Property(e => e.UDiseCode)
                .HasMaxLength(100)
                .HasColumnName("u_dise_code");

            entity.HasOne(d => d.Arform).WithMany(p => p.ArStudentInfoDetails)
                .HasForeignKey(d => d.ArformId)
                .HasConstraintName("FK__ArStudent__arfor__029D4CB7");
        });

        modelBuilder.Entity<ArTransportDetail>(entity =>
        {
            entity.HasKey(e => e.ArtransportdetailsId).HasName("PK__ArTransp__08F3E051C9F3BE1B");

            entity.Property(e => e.ArtransportdetailsId).HasColumnName("artransportdetails_id");
            entity.Property(e => e.Academicid).HasColumnName("academicid");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.AdmittedTo)
                .HasMaxLength(255)
                .HasColumnName("admitted_to");
            entity.Property(e => e.ArformId).HasColumnName("arform_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DateofApplication)
                .HasColumnType("datetime")
                .HasColumnName("dateof_application");
            entity.Property(e => e.FatherEmail)
                .HasMaxLength(100)
                .HasColumnName("father_email");
            entity.Property(e => e.FatherName)
                .HasMaxLength(255)
                .HasColumnName("father_name");
            entity.Property(e => e.FatherPhone).HasColumnName("father_phone");
            entity.Property(e => e.LandMark)
                .HasMaxLength(255)
                .HasColumnName("land_mark");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.MotherEmail)
                .HasMaxLength(100)
                .HasColumnName("mother_email");
            entity.Property(e => e.MotherName)
                .HasMaxLength(255)
                .HasColumnName("mother_name");
            entity.Property(e => e.MotherPhone).HasColumnName("mother_phone");
            entity.Property(e => e.NameofStudent)
                .HasMaxLength(255)
                .HasColumnName("nameof_student");
            entity.Property(e => e.PreferredDropPoint)
                .HasMaxLength(255)
                .HasColumnName("preferred_drop_point");
            entity.Property(e => e.PreferredPickupPoint)
                .HasMaxLength(255)
                .HasColumnName("preferred_pickup_point");

            entity.HasOne(d => d.Arform).WithMany(p => p.ArTransportDetails)
                .HasForeignKey(d => d.ArformId)
                .HasConstraintName("FK__ArTranspo__arfor__28C2F59F");
        });

        modelBuilder.Entity<EmergencyContactDetail>(entity =>
        {
            entity.HasKey(e => e.EmergencycontactdetailsId).HasName("PK__Emergenc__BFAEBFB9EE31B3C8");

            entity.Property(e => e.EmergencycontactdetailsId).HasColumnName("emergencycontactdetails_id");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(100)
                .HasColumnName("contact_number");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameofparentIncaseofstaffWard)
                .HasMaxLength(255)
                .HasColumnName("nameofparent_incaseofstaff_ward");
            entity.Property(e => e.Relationship)
                .HasMaxLength(100)
                .HasColumnName("relationship");

            entity.HasOne(d => d.Form).WithMany(p => p.EmergencyContactDetails)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("FK__Emergency__form___32B6742D");
        });

        modelBuilder.Entity<FamilyOrGuardianInfoDetail>(entity =>
        {
            entity.HasKey(e => e.FamilyorguardianinfodetailsId).HasName("PK__FamilyOr__8B52AFBED9FAC11C");

            entity.Property(e => e.FamilyorguardianinfodetailsId).HasColumnName("familyorguardianinfodetails_id");
            entity.Property(e => e.AadharNumber)
                .HasMaxLength(20)
                .HasColumnName("aadhar_number");
            entity.Property(e => e.AnnualIncome)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("annual_income");
            entity.Property(e => e.Contact)
                .HasMaxLength(15)
                .HasColumnName("contact");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DesignationNameofcompany)
                .HasMaxLength(80)
                .HasColumnName("designation_nameofcompany");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.HighestQualification)
                .HasMaxLength(255)
                .HasColumnName("highest_qualification");
            entity.Property(e => e.Legalguardian).HasColumnName("legalguardian");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Occupation)
                .HasMaxLength(100)
                .HasColumnName("occupation");
            entity.Property(e => e.OfficeAddress)
                .HasMaxLength(500)
                .HasColumnName("office_address");
            entity.Property(e => e.PanNumber)
                .HasMaxLength(100)
                .HasColumnName("pan_number");
            entity.Property(e => e.Passportexpirydate)
                .HasColumnType("datetime")
                .HasColumnName("passportexpirydate");
            entity.Property(e => e.Passportissuedate)
                .HasColumnType("datetime")
                .HasColumnName("passportissuedate");
            entity.Property(e => e.Passportnumber)
                .HasMaxLength(100)
                .HasColumnName("passportnumber");
            entity.Property(e => e.Preferredcontact)
                .HasMaxLength(255)
                .HasColumnName("preferredcontact");
            entity.Property(e => e.Relationshiptype)
                .HasMaxLength(100)
                .HasColumnName("relationshiptype");

            entity.HasOne(d => d.Form).WithMany(p => p.FamilyOrGuardianInfoDetails)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("FK__FamilyOrG__form___0579B962");
        });

        modelBuilder.Entity<MstAcademicYear>(entity =>
        {
            entity.HasKey(e => e.AcademicId).HasName("PK__MstAcade__B5573C11017E2C8D");

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
            entity.HasKey(e => e.ClassId).HasName("PK__MstClass__FDF47986DAD93171");

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

        modelBuilder.Entity<MstDocumentType>(entity =>
        {
            entity.HasKey(e => e.MstdocumenttypesId).HasName("PK__MstDocum__45001145801B6953");

            entity.Property(e => e.MstdocumenttypesId).HasColumnName("mstdocumenttypes_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.MstdocumenttypesDescription)
                .HasMaxLength(255)
                .HasColumnName("mstdocumenttypes_description");
        });

        modelBuilder.Entity<MstEnquiryAnswerDetail>(entity =>
        {
            entity.HasKey(e => e.MstenquiryanswerdetailsId).HasName("PK__MstEnqui__E575C6F307DEA4DF");

            entity.Property(e => e.MstenquiryanswerdetailsId).HasColumnName("mstenquiryanswerdetails_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EnquiryAnswerDetails)
                .HasMaxLength(255)
                .HasColumnName("enquiry_answer_details");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.MstenquiryquestiondetailsId).HasColumnName("mstenquiryquestiondetails_id");

            entity.HasOne(d => d.Mstenquiryquestiondetails).WithMany(p => p.MstEnquiryAnswerDetails)
                .HasForeignKey(d => d.MstenquiryquestiondetailsId)
                .HasConstraintName("FK__MstEnquir__msten__11207638");
        });

        modelBuilder.Entity<MstEnquiryQuestionDetail>(entity =>
        {
            entity.HasKey(e => e.MstenquiryquestiondetailsId).HasName("PK__MstEnqui__F6F5767706136E6C");

            entity.Property(e => e.MstenquiryquestiondetailsId).HasColumnName("mstenquiryquestiondetails_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EnquiryQuestion)
                .HasMaxLength(255)
                .HasColumnName("enquiry_question");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.MstenquiryquestiontypedetailsId).HasColumnName("mstenquiryquestiontypedetails_id");

            entity.HasOne(d => d.Mstenquiryquestiontypedetails).WithMany(p => p.MstEnquiryQuestionDetails)
                .HasForeignKey(d => d.MstenquiryquestiontypedetailsId)
                .HasConstraintName("FK__MstEnquir__msten__0D4FE554");
        });

        modelBuilder.Entity<MstEnquiryQuestionTypeDetail>(entity =>
        {
            entity.HasKey(e => e.MstenquiryquestiontypedetailsId).HasName("PK__MstEnqui__EA5F015C77A05307");

            entity.Property(e => e.MstenquiryquestiontypedetailsId).HasColumnName("mstenquiryquestiontypedetails_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EnquiryQuestionType)
                .HasMaxLength(255)
                .HasColumnName("enquiry_question_type");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
        });

        modelBuilder.Entity<MstGroupOfSchool>(entity =>
        {
            entity.HasKey(e => e.GroupofSchoolsId).HasName("PK__MstGroup__037B607A1B07ABC6");

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

        modelBuilder.Entity<MstPermission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK__MstPermi__E5331AFACD9EB2E9");

            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
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
            entity.Property(e => e.PermissionDetails)
                .HasMaxLength(255)
                .HasColumnName("permission_details");
            entity.Property(e => e.PermissionName)
                .HasMaxLength(255)
                .HasColumnName("permission_name");
        });

        modelBuilder.Entity<MstRoleGroup>(entity =>
        {
            entity.HasKey(e => e.RolegroupId).HasName("PK__MstRoleG__680F3A92C8753B77");

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
                .HasConstraintName("FK__MstRoleGr__role___0EF836A4");
        });

        modelBuilder.Entity<MstRoleType>(entity =>
        {
            entity.HasKey(e => e.RoletypeId).HasName("PK__MstRoleT__5C2E375ACF32A7B6");

            entity.Property(e => e.RoletypeId).HasColumnName("roletype_id");
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
            entity.Property(e => e.RoletypeName)
                .HasMaxLength(255)
                .HasColumnName("roletype_name");
        });

        modelBuilder.Entity<MstSchool>(entity =>
        {
            entity.HasKey(e => e.SchoolId).HasName("PK__MstSchoo__27CA6CF4A7759CC2");

            entity.Property(e => e.SchoolId).HasColumnName("school_id");
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
            entity.Property(e => e.SchoolCode)
                .HasMaxLength(255)
                .HasColumnName("school_code");
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
            entity.HasKey(e => e.GradeId).HasName("PK__MstSchoo__3A8F732C3487D037");

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
            entity.HasKey(e => e.StreamId).HasName("PK__MstSchoo__9DD95BAEC8FBB24B");

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
            entity.HasKey(e => e.UserId).HasName("PK__MstUsers__B9BE370F849DE5AD");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
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
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserGivenName)
                .HasMaxLength(255)
                .HasColumnName("user_givenName");
            entity.Property(e => e.UserLoginType)
                .HasMaxLength(255)
                .HasColumnName("user_loginType");
            entity.Property(e => e.UserPhone)
                .HasMaxLength(15)
                .HasColumnName("user_phone");
            entity.Property(e => e.UserSurname)
                .HasMaxLength(255)
                .HasColumnName("user_surname");
            entity.Property(e => e.Useremail)
                .HasMaxLength(255)
                .HasColumnName("useremail");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
            entity.Property(e => e.Userpassword)
                .HasMaxLength(255)
                .HasColumnName("userpassword");

            entity.HasOne(d => d.Role).WithMany(p => p.MstUsers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MstUsers__role_i__2E70E1FD");
        });

        modelBuilder.Entity<MstUserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__MstUserR__760965CCBE8EE8E2");

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
            entity.Property(e => e.RoletypeId).HasColumnName("roletype_id");

            entity.HasOne(d => d.Roletype).WithMany(p => p.MstUserRoles)
                .HasForeignKey(d => d.RoletypeId)
                .HasConstraintName("FK__MstUserRo__rolet__492FC531");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.ParentId).HasName("PK__Parents__F2A6081933E7E8E8");

            entity.Property(e => e.ParentId).HasColumnName("parent_id");
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
            entity.Property(e => e.ParentGivenName)
                .HasMaxLength(255)
                .HasColumnName("parent_givenName");
            entity.Property(e => e.ParentLoginType)
                .HasMaxLength(255)
                .HasColumnName("parent_loginType");
            entity.Property(e => e.ParentPassword)
                .HasMaxLength(255)
                .HasColumnName("parent_password");
            entity.Property(e => e.ParentPhone)
                .HasMaxLength(15)
                .HasColumnName("parent_phone");
            entity.Property(e => e.ParentRole)
                .HasMaxLength(255)
                .HasColumnName("parent_role");
            entity.Property(e => e.ParentSurname)
                .HasMaxLength(255)
                .HasColumnName("parent_surname");
            entity.Property(e => e.ParentUsername)
                .HasMaxLength(255)
                .HasColumnName("parent_username");
        });

        modelBuilder.Entity<ParentDocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__ParentDo__9666E8AC33250FF1");

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
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");

            entity.HasOne(d => d.Parent).WithMany(p => p.ParentDocuments)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documents_Parents");
        });

        modelBuilder.Entity<PreviousSchoolDetail>(entity =>
        {
            entity.HasKey(e => e.PreviousschooldetailsId).HasName("PK__Previous__76F1996458CAAA8B");

            entity.Property(e => e.PreviousschooldetailsId).HasColumnName("previousschooldetails_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.ClassCompleted)
                .HasMaxLength(255)
                .HasColumnName("class_completed");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Curriculum)
                .HasMaxLength(255)
                .HasColumnName("curriculum");
            entity.Property(e => e.DateOfLeavingschool)
                .HasColumnType("datetime")
                .HasColumnName("dateOf_leavingschool");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.HasapplicanteverExpelledorsuspended)
                .HasMaxLength(255)
                .HasColumnName("hasapplicantever_expelledorsuspended");
            entity.Property(e => e.MediumofInstruction)
                .HasMaxLength(255)
                .HasColumnName("mediumof_instruction");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.NameSchool)
                .HasMaxLength(255)
                .HasColumnName("name_school");
            entity.Property(e => e.ReasonForleaving)
                .HasMaxLength(255)
                .HasColumnName("reason_forleaving");
            entity.Property(e => e.Reasonforsuspension)
                .HasMaxLength(25)
                .HasColumnName("reasonforsuspension");
            entity.Property(e => e.YearsAttended)
                .HasMaxLength(255)
                .HasColumnName("years_attended");

            entity.HasOne(d => d.Form).WithMany(p => p.PreviousSchoolDetails)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("FK__PreviousS__form___2BD46C74");
        });

        modelBuilder.Entity<RolePermissionsMapping>(entity =>
        {
            entity.HasKey(e => e.MappingId).HasName("PK__RolePerm__5AE900451BE9AAE0");

            entity.ToTable("RolePermissionsMapping");

            entity.Property(e => e.MappingId).HasColumnName("mapping_id");
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
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissionsMappings)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RolePermi__permi__483BA0F8");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissionsMappings)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RolePermi__role___46535886");
        });

        modelBuilder.Entity<SiblingInfo>(entity =>
        {
            entity.HasKey(e => e.SiblingId).HasName("PK__SiblingI__7A415E3FE090BAB7");

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
                .HasConstraintName("FK__SiblingIn__form___2FDA0782");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__2A33069A23A2C28A");

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

        modelBuilder.Entity<StudentDocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__StudentD__9666E8AC665C9150");

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
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentDocuments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documents_Students");
        });

        modelBuilder.Entity<StudentHealthInfoDetail>(entity =>
        {
            entity.HasKey(e => e.StudenthealthinfodetailsId).HasName("PK__StudentH__CC8B9F537B99EB80");

            entity.Property(e => e.StudenthealthinfodetailsId).HasColumnName("studenthealthinfodetails_id");
            entity.Property(e => e.AllergiesIfAny)
                .HasMaxLength(255)
                .HasColumnName("allergies_ifAny");
            entity.Property(e => e.BloodGroup)
                .HasMaxLength(255)
                .HasColumnName("blood_group");
            entity.Property(e => e.ChildName)
                .HasMaxLength(255)
                .HasColumnName("child_name");
            entity.Property(e => e.Class)
                .HasMaxLength(255)
                .HasColumnName("class");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.HealthHistory)
                .HasMaxLength(255)
                .HasColumnName("health_history");
            entity.Property(e => e.Height)
                .HasMaxLength(255)
                .HasColumnName("height");
            entity.Property(e => e.IdentificationMarks)
                .HasMaxLength(255)
                .HasColumnName("identification_marks");
            entity.Property(e => e.ImmunizationStatus)
                .HasMaxLength(255)
                .HasColumnName("immunization_status");
            entity.Property(e => e.LearningDisabilities)
                .HasMaxLength(255)
                .HasColumnName("learning_disabilities");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.RegularmedicineTakenbystudent)
                .HasMaxLength(255)
                .HasColumnName("regularmedicine_takenbystudent");
            entity.Property(e => e.SpecialNeeds)
                .HasMaxLength(255)
                .HasColumnName("special_needs");
            entity.Property(e => e.VisionLeft)
                .HasMaxLength(255)
                .HasColumnName("vision_left");
            entity.Property(e => e.VisionRight)
                .HasMaxLength(255)
                .HasColumnName("vision_right");
            entity.Property(e => e.Weight)
                .HasMaxLength(100)
                .HasColumnName("weight");

            entity.HasOne(d => d.Form).WithMany(p => p.StudentHealthInfoDetails)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("FK__StudentHe__form___25276EE5");
        });

        modelBuilder.Entity<StudentIllnessDetail>(entity =>
        {
            entity.HasKey(e => e.StudentillnessdetailsId).HasName("PK__StudentI__AACB9DE0630A8A74");

            entity.Property(e => e.StudentillnessdetailsId).HasColumnName("studentillnessdetails_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.IllnessDate)
                .HasMaxLength(255)
                .HasColumnName("illness_date");
            entity.Property(e => e.IllnessDetails)
                .HasMaxLength(255)
                .HasColumnName("illness_details");
            entity.Property(e => e.IllnessName)
                .HasMaxLength(255)
                .HasColumnName("illness_name");
            entity.Property(e => e.IllnessType)
                .HasMaxLength(255)
                .HasColumnName("illness_type");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

            entity.HasOne(d => d.Form).WithMany(p => p.StudentIllnessDetails)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("FK__StudentIl__form___1D864D1D");
        });

        modelBuilder.Entity<StudentInfoDetail>(entity =>
        {
            entity.HasKey(e => e.StudentinfoId).HasName("PK__StudentI__C396B23FA6ABBAC9");

            entity.Property(e => e.StudentinfoId).HasColumnName("studentinfo_id");
            entity.Property(e => e.AadharNumber)
                .HasMaxLength(20)
                .HasColumnName("aadhar_number");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Caste)
                .HasMaxLength(100)
                .HasColumnName("caste");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DateOfExpiry)
                .HasColumnType("datetime")
                .HasColumnName("date_of_expiry");
            entity.Property(e => e.DateOfIssue)
                .HasColumnType("datetime")
                .HasColumnName("date_of_issue");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("dob");
            entity.Property(e => e.DobInWords)
                .HasMaxLength(255)
                .HasColumnName("dob_in_words");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.Gender)
                .HasMaxLength(80)
                .HasColumnName("gender");
            entity.Property(e => e.Ispresentaddresspermanentaddress).HasDefaultValueSql("('FALSE')");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(255)
                .HasColumnName("middle_name");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.MotherTongue)
                .HasMaxLength(255)
                .HasColumnName("mother_tongue");
            entity.Property(e => e.Nationality)
                .HasMaxLength(100)
                .HasColumnName("nationality");
            entity.Property(e => e.NoOfFamilymembers).HasColumnName("no_of_familymembers");
            entity.Property(e => e.OtherKnownLanguages)
                .HasMaxLength(255)
                .HasColumnName("other_knownLanguages");
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(100)
                .HasColumnName("passport_number");
            entity.Property(e => e.PermanentAddress)
                .HasMaxLength(500)
                .HasColumnName("permanent_address");
            entity.Property(e => e.PresentAddress)
                .HasMaxLength(500)
                .HasColumnName("present_address");
            entity.Property(e => e.Religion)
                .HasMaxLength(100)
                .HasColumnName("religion");
            entity.Property(e => e.SatsChildNumber)
                .HasMaxLength(100)
                .HasColumnName("sats_child_number");
            entity.Property(e => e.StudentLivesWith)
                .HasMaxLength(255)
                .HasColumnName("student_lives_with");
            entity.Property(e => e.TypeofFamily)
                .HasMaxLength(255)
                .HasColumnName("typeof_family");
            entity.Property(e => e.UDiseCode)
                .HasMaxLength(100)
                .HasColumnName("u_dise_code");

            entity.HasOne(d => d.Form).WithMany(p => p.StudentInfoDetails)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("FK__StudentIn__form___7ECCBBD3");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teachers__03AE777E4FDDE195");

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

        modelBuilder.Entity<TeacherDocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__TeacherD__9666E8AC185AEAD7");

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
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherDocuments)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documents_Teachers");
        });

        modelBuilder.Entity<TrackAdmissionStatus>(entity =>
        {
            entity.HasKey(e => e.TrackId).HasName("PK__TrackAdm__24ECC82EF88EE004");

            entity.ToTable("TrackAdmissionStatus");

            entity.Property(e => e.TrackId).HasColumnName("track_id");
            entity.Property(e => e.AdmissionStatus).HasColumnName("admission_status");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.FormId).HasColumnName("form_id");
        });

        modelBuilder.Entity<TransportDetail>(entity =>
        {
            entity.HasKey(e => e.TransportdetailsId).HasName("PK__Transpor__68A767EB51DD5348");

            entity.Property(e => e.TransportdetailsId).HasColumnName("transportdetails_id");
            entity.Property(e => e.Academicid).HasColumnName("academicid");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.AdmittedTo)
                .HasMaxLength(255)
                .HasColumnName("admitted_to");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DateofApplication)
                .HasColumnType("datetime")
                .HasColumnName("dateof_application");
            entity.Property(e => e.FatherEmail)
                .HasMaxLength(100)
                .HasColumnName("father_email");
            entity.Property(e => e.FatherName)
                .HasMaxLength(255)
                .HasColumnName("father_name");
            entity.Property(e => e.FatherPhone)
                .HasMaxLength(15)
                .HasColumnName("father_phone");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.LandMark)
                .HasMaxLength(255)
                .HasColumnName("land_mark");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.MotherEmail)
                .HasMaxLength(100)
                .HasColumnName("mother_email");
            entity.Property(e => e.MotherName)
                .HasMaxLength(255)
                .HasColumnName("mother_name");
            entity.Property(e => e.MotherPhone)
                .HasMaxLength(15)
                .HasColumnName("mother_phone");
            entity.Property(e => e.NameofStudent)
                .HasMaxLength(255)
                .HasColumnName("nameof_student");
            entity.Property(e => e.PreferredDropPoint)
                .HasMaxLength(255)
                .HasColumnName("preferred_drop_point");
            entity.Property(e => e.PreferredPickupPoint)
                .HasMaxLength(255)
                .HasColumnName("preferred_pickup_point");

            entity.HasOne(d => d.Academic).WithMany(p => p.TransportDetails)
                .HasForeignKey(d => d.Academicid)
                .HasConstraintName("FK__Transport__acade__5F54107A");

            entity.HasOne(d => d.Form).WithMany(p => p.TransportDetails)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("FK__Transport__form___2156DE01");
        });

        modelBuilder.Entity<UserRegistration>(entity =>
        {
            entity.HasKey(e => e.RegisterId).HasName("PK__UserRegi__1418262F505BE758");

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
