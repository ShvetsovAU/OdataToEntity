using dbReverse.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums;

namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest
{
    public class Test_OData_DbContext : DbContext
    {
    
        //    public Test_OData_DbContext()
    //    {}

        public Test_OData_DbContext(DbContextOptions<Test_OData_DbContext> options)
            : base(options)
        { }

        #region DbSet's
        
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityAttributeTemplate> ActivityAttributeTemplates { get; set; }
        public virtual DbSet<ActivityCode> ActivityCodes { get; set; }
        public virtual DbSet<ActivityCodeType> ActivityCodeTypes { get; set; }
        public virtual DbSet<ActivityExpense> ActivityExpenses { get; set; }
        public virtual DbSet<ActivityPerformerTeamRef> ActivityPerformerTeamRefs { get; set; }
        public virtual DbSet<ActivityPeriodActual> ActivityPeriodActuals { get; set; }
        public virtual DbSet<ActivityPeriodFact> ActivityPeriodFacts { get; set; }
        public virtual DbSet<ActivityTemplate> ActivityTemplates { get; set; }
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<ActivityUDF> ActivityUDFs { get; set; }
        public virtual DbSet<ActivityWorkTaskRef> ActivityWorkTaskRefs { get; set; }
        public virtual DbSet<Annotation> Annotations { get; set; }
        public virtual DbSet<AnnotationCondition> AnnotationConditions { get; set; }
        public virtual DbSet<AnnotationInfo> AnnotationInfoes { get; set; }
        public virtual DbSet<AssemblyUnit> AssemblyUnits { get; set; }
        public virtual DbSet<AssemblyUnitCondition> AssemblyUnitConditions { get; set; }
        public virtual DbSet<AssemblyUnitState> AssemblyUnitStates { get; set; }
        public virtual DbSet<AssemblyUnitsImportRule> AssemblyUnitsImportRules { get; set; }
        public virtual DbSet<AttributesType> AttributesTypes { get; set; }
        public virtual DbSet<Calendar> Calendars { get; set; }
        public virtual DbSet<CodeActivity> CodeActivities { get; set; }
        public virtual DbSet<CodeResource> CodeResources { get; set; }
        public virtual DbSet<CommonCondition> CommonConditions { get; set; }
        public virtual DbSet<Curator> Curators { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentNodeRef> DocumentNodeRefs { get; set; }
        public virtual DbSet<DocumentWorkTask> DocumentWorkTasks { get; set; }
        public virtual DbSet<EPS> EPs { get; set; }
        public virtual DbSet<Element3D> Element3Ds { get; set; }
        public virtual DbSet<FilterAnnotaion> FilterAnnotaions { get; set; }
        public virtual DbSet<Indicator> Indicators { get; set; }
        public virtual DbSet<IndicatorCondition> IndicatorConditions { get; set; }
        public virtual DbSet<JournalRecord> JournalRecords { get; set; }
        //public virtual DbSet<OBEY> OBEYs { get; set; }
        public virtual DbSet<OgRecord> OgRecords { get; set; }
        public virtual DbSet<OgToActivityMapping> OgToActivityMappings { get; set; }
        public virtual DbSet<OgUDFValue> OgUDFValues { get; set; }
        public virtual DbSet<OgUdfType> OgUdfTypes { get; set; }
        public virtual DbSet<P3DBActivitiesRelation> P3DBActivitiesRelations { get; set; }
        public virtual DbSet<P3DBAttribute> P3DBAttributes { get; set; }
        public virtual DbSet<P3DBIsometricDrawingAttributeRelation> P3DBIsometricDrawingAttributeRelations { get; set; }
        public virtual DbSet<P3DBModel> P3DBModels { get; set; }
        public virtual DbSet<P3DBModelAttributeRelation> P3DBModelAttributeRelations { get; set; }
        public virtual DbSet<P3DBModelElement> P3DBModelElements { get; set; }
        public virtual DbSet<P3DbActivitiesRelationProfile> P3DbActivitiesRelationProfiles { get; set; }
        public virtual DbSet<PaintingCondition> PaintingConditions { get; set; }
        public virtual DbSet<PaintingQuerry> PaintingQuerries { get; set; }
        public virtual DbSet<PartActivityId> PartActivityIds { get; set; }
        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<PerformerActivityCode> PerformerActivityCodes { get; set; }
        public virtual DbSet<PerformerTeam> PerformerTeams { get; set; }
        public virtual DbSet<Period> Periods { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectRole> ProjectRoles { get; set; }
        public virtual DbSet<Relationship> Relationships { get; set; }
        public virtual DbSet<Report3D> Report3Ds { get; set; }
        public virtual DbSet<Report3DWorkTask> Report3DWorkTasks { get; set; }
        public virtual DbSet<ReportTemplate> ReportTemplates { get; set; }
        public virtual DbSet<ResAssignUDF> ResAssignUDFs { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<ResourceAssignment> ResourceAssignments { get; set; }
        public virtual DbSet<ResourceCode> ResourceCodes { get; set; }
        public virtual DbSet<ResourceCodeType> ResourceCodeTypes { get; set; }
        public virtual DbSet<ResourceRate> ResourceRates { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RuleCreateActivityId> RuleCreateActivityIds { get; set; }
        public virtual DbSet<Substitution> Substitutions { get; set; }
        public virtual DbSet<SupplierMappingRule> SupplierMappingRules { get; set; }
        public virtual DbSet<SupplierPortalJournal> SupplierPortalJournals { get; set; }
        public virtual DbSet<SupplierRecord> SupplierRecords { get; set; }
        public virtual DbSet<SupplierRecordsToActivity> SupplierRecordsToActivities { get; set; }
        public virtual DbSet<SupplierUDF> SupplierUDFs { get; set; }
        public virtual DbSet<SupplierUDFType> SupplierUDFTypes { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<UDFType> UDFTypes { get; set; }
        public virtual DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAudit> UserAudits { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<UserGroupEPS> UserGroupEPs { get; set; }
        public virtual DbSet<UserGroupUser> UserGroupUsers { get; set; }
        public virtual DbSet<UserStateSettings> UserStateSettings { get; set; }
        public virtual DbSet<View_2> View_2s { get; set; }
        public virtual DbSet<WorkBreakdownStructure> WBs { get; set; }
        public virtual DbSet<WorkTask> WorkTasks { get; set; }
        public virtual DbSet<WorkTaskAttributeValue> WorkTaskAttributeValues { get; set; }
        public virtual DbSet<WorkTaskNumberPart> WorkTaskNumberParts { get; set; }
        public virtual DbSet<WorkTaskP3DBModel> WorkTaskP3DBModels { get; set; }
        public virtual DbSet<WorkType> WorkTypes { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        //public virtual DbSet<__MigrationHistory> __MigrationHistories { get; set; }
        //public virtual DbSet<__ScriptMigrationHistory> __ScriptMigrationHistories { get; set; }
        //public virtual DbSet<tmp_nsz> tmp_nszs { get; set; }
        //public virtual DbSet<Дубликаты_кодов_работ> Дубликаты_кодов_работs { get; set; }

        #endregion DbSet's

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost; Database=Test_OData_Db; Trusted_Connection=true; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Activity");

                entity.ToTable("Activity");

                entity.HasIndex(e => e.WBSObjectId, "IX_WBSObjectId");

                entity.Property(e => e.ActualDuration).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ActualFinishDate).HasColumnType("datetime");
                entity.Property(e => e.ActualLaborCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ActualLaborUnits).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ActualLaborUnitsManualValue).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ActualNonLaborCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ActualNonLaborUnits).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ActualStartDate).HasColumnType("datetime");
                entity.Property(e => e.ActualThisPeriodLaborCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ActualThisPeriodLaborUnits).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.ActualThisPeriodNonLaborCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ActualThisPeriodNonLaborUnits).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.ActualUnitsPerTime).HasColumnType("decimal(16, 8)");
                entity.Property(e => e.AtCompletionDuration).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.AtCompletionLaborCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.AtCompletionLaborUnits).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.AtCompletionNonLaborCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.AtCompletionNonLaborUnits).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.DurationPercentComplete).HasColumnType("decimal(7, 4)");
                entity.Property(e => e.EstimatedWeight).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.ExpectedFinishDate).HasColumnType("datetime");
                entity.Property(e => e.ExternalEarlyStartDate).HasColumnType("datetime");
                entity.Property(e => e.ExternalLateFinishDate).HasColumnType("datetime");
                entity.Property(e => e.Feedback).HasMaxLength(4000);
                entity.Property(e => e.FinishDate).HasColumnType("datetime");
                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.MinimumPercentComplete).HasColumnType("decimal(7, 4)");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.NonLaborUnitsPercentComplete).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.PercentComplete).HasColumnType("decimal(7, 4)");
                entity.Property(e => e.PhysicalPercentComplete).HasColumnType("decimal(20, 4)");
                entity.Property(e => e.PlannedDateOfDelivery).HasColumnType("datetime");
                entity.Property(e => e.PlannedDuration).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.PlannedFinishDate).HasColumnType("datetime");
                entity.Property(e => e.PlannedLaborCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PlannedLaborUnits).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.PlannedNonLaborCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PlannedNonLaborUnits).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.PlannedStartDate).HasColumnType("datetime");
                entity.Property(e => e.PrimaryConstraintDate).HasColumnType("datetime");
                entity.Property(e => e.RemainingDuration).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.RemainingEarlyFinishDate).HasColumnType("datetime");
                entity.Property(e => e.RemainingEarlyStartDate).HasColumnType("datetime");
                entity.Property(e => e.RemainingLaborCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.RemainingLaborUnits).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.RemainingLateFinishDate).HasColumnType("datetime");
                entity.Property(e => e.RemainingLateStartDate).HasColumnType("datetime");
                entity.Property(e => e.RemainingNonLaborCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.RemainingNonLaborUnits).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.ResumeDate).HasColumnType("datetime");
                entity.Property(e => e.SecondaryConstraintDate).HasColumnType("datetime");
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.Property(e => e.SuspendDate).HasColumnType("datetime");
                entity.Property(e => e.UnitsPercentComplete).HasColumnType("decimal(7, 4)");

                entity.HasOne(d => d.ActivityType)
                    //.WithMany(p => p.Activities)
                    .WithMany()
                    .HasForeignKey(d => d.ActivityTypeObjectId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_dbo.Activity_dbo.ActivityTypes_ActivityTypeObjectId");

                entity.HasOne(d => d.WorkBreakdownStructure)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.WBSObjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.Activity_dbo.WBS_WBSObjectId");
            });

            modelBuilder.Entity<ActivityAttributeTemplate>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.ActivityAttributeTemplates");

                entity.Property(e => e.PlannedUnitsPerTime).HasColumnType("decimal(16, 8)");

                entity.HasOne(d => d.ActivityType)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(d => d.ActivityTypeId)
                    .HasConstraintName("FK_dbo.ActivityAttributeTemplates_dbo.ActivityTypes_ActivityTypeId");
            });

            modelBuilder.Entity<ActivityCode>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.ActivityCode");

                entity.ToTable("ActivityCode");

                entity.HasIndex(e => e.ParentObjectId, "IX_ParentObjectId");

                entity.Property(e => e.CodeValue)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Description).HasMaxLength(120);
                
                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.ParentObjectId)
                    .HasConstraintName("FK_dbo.ActivityCode_dbo.ActivityCode_ParentObjectId");
            });

            modelBuilder.Entity<ActivityCodeType>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.ActivityCodeType");

                entity.ToTable("ActivityCodeType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<ActivityExpense>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.ActivityExpense");

                entity.ToTable("ActivityExpense");

                entity.HasIndex(e => e.ActivityObjectId, "IX_ActivityObjectId");

                entity.Property(e => e.ActualCost).HasColumnType("decimal(23, 6)");
                entity.Property(e => e.ActualUnits).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.DocumentNumber).HasMaxLength(32);
                entity.Property(e => e.ExpenseItem)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.ExpensePercentComplete).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PlannedCost).HasColumnType("decimal(23, 6)");
                entity.Property(e => e.PlannedUnits).HasColumnType("decimal(19, 6)");
                entity.Property(e => e.PricePerUnit).HasColumnType("decimal(21, 8)");
                entity.Property(e => e.RemainingCost).HasColumnType("decimal(23, 6)");
                entity.Property(e => e.RemainingUnits).HasColumnType("decimal(19, 6)");
                entity.Property(e => e.UnitOfMeasure).HasMaxLength(30);
                entity.Property(e => e.Vendor).HasMaxLength(100);
                
                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityExpenses)
                    .HasForeignKey(d => d.ActivityObjectId)
                    .HasConstraintName("FK_dbo.ActivityExpense_dbo.Activity_ActivityObjectId");
            });

            modelBuilder.Entity<ActivityPerformerTeamRef>(entity =>
            {
                entity.HasKey(e => new { e.ActivityId, e.PerformerTeamId })
                    .HasName("PK_dbo.ActivityPerformerTeamRefs");

                entity.HasIndex(e => e.ActivityId, "IX_ActivityId");
                entity.HasIndex(e => e.PerformerTeamId, "IX_PerformerTeamId");

                entity.HasOne(d => d.Activity)
                    //.WithMany(p => p.ActivityPerformerTeamRefs)
                    .WithMany()
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_dbo.ActivityPerformerTeamRefs_dbo.Activity_ActivityId");

                entity.HasOne(d => d.PerformerTeam)
                    //.WithMany(p => p.ActivityPerformerTeamRefs)
                    .WithMany()
                    .HasForeignKey(d => d.PerformerTeamId)
                    .HasConstraintName("FK_dbo.ActivityPerformerTeamRefs_dbo.PerformerTeams_PerformerTeamId");
            });

            modelBuilder.Entity<ActivityPeriodActual>(entity =>
            {
                entity.ToTable("ActivityPeriodActual");

                entity.HasIndex(e => e.ActivityObjectId, "IX_ActivityObjectId");

                entity.Property(e => e.ActualExpenseCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ActualLaborCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ActualLaborUnits).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ActualNonLaborCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ActualNonLaborUnits).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.EarnedValueCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.EarnedValueLaborUnits).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PlannedValueCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PlannedValueLaborUnits).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityPeriodActuals)
                    .HasForeignKey(d => d.ActivityObjectId)
                    .HasConstraintName("FK_dbo.ActivityPeriodActual_dbo.Activity_ActivityObjectId");
            });

            modelBuilder.Entity<ActivityPeriodFact>(entity =>
            {
                entity.HasKey(e => new { e.ActivityId, e.PeriodId })
                    .HasName("PK_dbo.ActivityPeriodFacts");

                entity.HasIndex(e => e.ActivityId, "IX_ActivityId");

                entity.HasIndex(e => e.PeriodId, "IX_PeriodId");

                entity.Property(e => e.ActualLaborUnits).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ActualPhysicalVolume).HasColumnType("decimal(17, 6)");

                entity.Property(e => e.ActualUnitsPerTime).HasColumnType("decimal(16, 8)");

                entity.Property(e => e.PlannedLaborUnits).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PlannedPhysicalVolume).HasColumnType("decimal(17, 6)");

                entity.Property(e => e.PlannedUnitsPerTime).HasColumnType("decimal(16, 8)");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityPeriodFacts)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_dbo.ActivityPeriodFacts_dbo.Activity_ActivityId");

                entity.HasOne(d => d.Period)
                    //.WithMany(p => p.ActivityPeriodFacts)
                    .WithMany()
                    .HasForeignKey(d => d.PeriodId)
                    .HasConstraintName("FK_dbo.ActivityPeriodFacts_dbo.Periods_PeriodId");
            });

            modelBuilder.Entity<ActivityTemplate>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.ActivityTemplates");
            });

            modelBuilder.Entity<ActivityType>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.ActivityTypes");

                entity.HasIndex(e => e.CalendarObjectId, "IX_CalendarObjectId");
                entity.HasIndex(e => e.RuleId, "IX_RuleId");

                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.PercentCompleteType).HasDefaultValueSql("((2))");

                entity.HasOne(d => d.ActivityTemplate)
                    .WithMany(p => p.ActivityTypes)
                    .HasForeignKey(d => d.ActivityTemplateObjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.ActivityTypes_dbo.ActivityTemplates_ActivityTemplateObjectId");

                entity.HasOne(d => d.Calendar)
                    //.WithMany(p => p.ActivityTypes)
                    .WithMany()
                    .HasForeignKey(d => d.CalendarObjectId)
                    .HasConstraintName("FK_dbo.ActivityTypes_dbo.Calendar_CalendarObjectId");

                entity.HasOne(d => d.RuleCreateActivityId)
                    .WithMany(p => p.ActivityTypes)
                    .HasForeignKey(d => d.RuleId)
                    .HasConstraintName("FK_dbo.ActivityTypes_dbo.RuleCreateActivityIds_RuleId");
            });

            modelBuilder.Entity<ActivityUDF>(entity =>
            {
                entity.ToTable("ActivityUDF");

                entity.HasIndex(e => e.ActivityId, "IX_ActivityId");
                entity.HasIndex(e => e.TypeObjectId, "IX_TypeObjectId");

                entity.Property(e => e.CostValue).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.DoubleValue).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.FinishDateValue).HasColumnType("datetime");
                entity.Property(e => e.StartDateValue).HasColumnType("datetime");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityUDFs)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_dbo.ActivityUDF_dbo.Activity_ActivityId");

                entity.HasOne(d => d.UDFType)
                    .WithMany(p => p.ActivityUDFs)
                    .HasForeignKey(d => d.TypeObjectId)
                    .HasConstraintName("FK_dbo.ActivityUDF_dbo.UDFType_TypeObjectId");
            });

            modelBuilder.Entity<ActivityWorkTaskRef>(entity =>
            {
                entity.HasKey(e => new { e.ActivityId, e.WorkTaskId })
                    .HasName("PK_dbo.ActivityWorkTaskRefs");

                entity.HasIndex(e => e.ActivityId, "IX_ActivityId");
                entity.HasIndex(e => e.WorkTaskId, "IX_WorkTaskId");

                entity.Property(e => e.DurationPercentComplete).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.PlannedDurationPercent).HasColumnType("decimal(19, 16)");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.WorkTasks)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_dbo.ActivityWorkTaskRefs_dbo.Activity_ActivityId");

                entity.HasOne(d => d.WorkTask)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.WorkTaskId)
                    .HasConstraintName("FK_dbo.ActivityWorkTaskRefs_dbo.WorkTasks_WorkTaskId");
            });

            modelBuilder.Entity<Annotation>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Annotations");

                entity.HasIndex(e => e.Report3dObjectId, "IX_Report3dObjectId");

                entity.HasOne(d => d.Report3D)
                    .WithMany(p => p.Annotations)
                    .HasForeignKey(d => d.Report3dObjectId)
                    .HasConstraintName("FK_dbo.Annotations_dbo.Report3D_Report3dObjectId");
            });

            modelBuilder.Entity<AnnotationCondition>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.AnnotationConditions");

                entity.HasIndex(e => e.AnnotationObjectId, "IX_AnnotationObjectId");

                entity.HasOne(d => d.Annotation)
                    .WithMany(p => p.Conditions)
                    .HasForeignKey(d => d.AnnotationObjectId)
                    .HasConstraintName("FK_dbo.AnnotationConditions_dbo.Annotations_Annotation_ObjectId");
            });

            modelBuilder.Entity<AnnotationInfo>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.AnnotationInfoes");

                entity.HasIndex(e => e.AnnotationObjectId, "IX_AnnotationObjectId");

                entity.HasOne(d => d.Annotation)
                    .WithMany(p => p.AnnotationsInfo)
                    .HasForeignKey(d => d.AnnotationObjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.AnnotationInfoes_dbo.Annotations_AnnotationObjectId");
            });

            modelBuilder.Entity<AssemblyUnit>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.AssemblyUnits");

                entity.HasIndex(e => e.P3DBModelId, "IX_P3DBModelId");
                entity.HasIndex(e => e.UserObjectId, "IX_UserObjectId");

                entity.Property(e => e.ImportDate).HasColumnType("datetime");
                entity.Property(e => e.InternalPath).IsRequired();
                entity.Property(e => e.NominalDiameter).HasColumnType("decimal(18, 9)");
                entity.Property(e => e.OuterDiameter).HasColumnType("decimal(18, 9)");
                entity.Property(e => e.PipeWallLength).HasColumnType("decimal(18, 9)");

                entity.HasOne(d => d.Model)
                    //.WithMany(p => p.AssemblyUnits)
                    .WithMany()
                    .HasForeignKey(d => d.P3DBModelId)
                    .HasConstraintName("FK_dbo.AssemblyUnits_dbo.P3DbModel_P3DBModelId");

                entity.HasOne(d => d.User)
                    //.WithMany(p => p.AssemblyUnits)
                    .WithMany()
                    .HasForeignKey(d => d.UserObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AssemblyUnits_dbo.Users_UserObjectId");
            });

            modelBuilder.Entity<AssemblyUnitCondition>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.AssemblyUnitConditions");

                entity.HasIndex(e => e.AssemblyUnitsImportRultId, "IX_AssemblyUnitsImportRultId");

                entity.HasOne(d => d.AssemblyUnitsImportRule)
                    .WithMany(p => p.Conditions)
                    .HasForeignKey(d => d.AssemblyUnitsImportRultId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.AssemblyUnitConditions_dbo.AssemblyUnitsImportRules_AssemblyUnitsImportRultId");
            });

            modelBuilder.Entity<AssemblyUnitState>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.AssemblyUnitStates");

                entity.HasIndex(e => e.ObjectId, "IX_ObjectId");

                entity.Property(e => e.ObjectId).ValueGeneratedNever();
                entity.Property(e => e.LastFinishDate).HasColumnType("datetime");
                entity.Property(e => e.ManualFinishDate).HasColumnType("datetime");

                entity.HasOne(d => d.AssemblyUnit)
                    .WithOne(p => p.UnitState)
                    .HasForeignKey<AssemblyUnitState>(d => d.ObjectId)
                    .HasConstraintName("FK_dbo.AssemblyUnitStates_dbo.AssemblyUnits_ObjectId");
            });

            modelBuilder.Entity<AssemblyUnitsImportRule>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.AssemblyUnitsImportRules");
            });

            modelBuilder.Entity<AttributesType>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.AttributesTypes");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Calendar>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Calendar");

                entity.ToTable("Calendar");

                entity.HasIndex(e => e.ProjectObjectId, "IX_ProjectObjectId");

                entity.Property(e => e.HolidayOrExceptions).HasColumnType("xml");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.StandardWorkWeek).HasColumnType("xml");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Calendars)
                    .HasForeignKey(d => d.ProjectObjectId)
                    .HasConstraintName("FK_dbo.Calendar_dbo.Projects_ProjectObjectId");
            });

            modelBuilder.Entity<CodeActivity>(entity =>
            {
                entity.HasKey(e => new { e.ActivityObjectId, e.TypeObjectId, e.ValueObjectId })
                    .HasName("PK_dbo.CodeActivity");

                entity.ToTable("CodeActivity");

                entity.HasIndex(e => e.ActivityObjectId, "IX_ActivityObjectId");
                entity.HasIndex(e => e.TypeObjectId, "IX_TypeObjectId");
                entity.HasIndex(e => e.ValueObjectId, "IX_ValueObjectId");

                entity.Property(e => e.ValueName).HasMaxLength(100);

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.CodeActivities)
                    .HasForeignKey(d => d.ActivityObjectId)
                    .HasConstraintName("FK_dbo.CodeActivity_dbo.Activity_ActivityObjectId");

                entity.HasOne(d => d.ActivityCodeType)
                    .WithMany(p => p.CodeActivities)
                    .HasForeignKey(d => d.TypeObjectId)
                    .HasConstraintName("FK_dbo.CodeActivity_dbo.ActivityCodeType_TypeObjectId");

                entity.HasOne(d => d.ActivityCode)
                    .WithMany(p => p.CodeActivities)
                    .HasForeignKey(d => d.ValueObjectId)
                    .HasConstraintName("FK_dbo.CodeActivity_dbo.ActivityCode_ValueObjectId");
            });

            modelBuilder.Entity<CodeResource>(entity =>
            {
                entity.HasKey(e => new { e.ResourceObjectId, e.TypeObjectId, e.ValueObjectId })
                    .HasName("PK_dbo.CodeResource");

                entity.ToTable("CodeResource");

                entity.HasIndex(e => e.ResourceObjectId, "IX_ResourceObjectId");
                entity.HasIndex(e => e.TypeObjectId, "IX_TypeObjectId");
                entity.HasIndex(e => e.ValueObjectId, "IX_ValueObjectId");

                entity.Property(e => e.ValueName).HasMaxLength(100);

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.CodeResources)
                    .HasForeignKey(d => d.ResourceObjectId)
                    .HasConstraintName("FK_dbo.CodeResource_dbo.Resource_ResourceObjectId");

                entity.HasOne(d => d.ResourceCodeType)
                    .WithMany(p => p.CodeResources)
                    .HasForeignKey(d => d.TypeObjectId)
                    .HasConstraintName("FK_dbo.CodeResource_dbo.ResourceCodeType_TypeObjectId");

                entity.HasOne(d => d.ResourceCode)
                    .WithMany(p => p.CodeResources)
                    .HasForeignKey(d => d.ValueObjectId)
                    .HasConstraintName("FK_dbo.CodeResource_dbo.ResourceCode_ValueObjectId");
            });

            modelBuilder.Entity<CommonCondition>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.CommonConditions");

                entity.HasIndex(e => e.PaintingQuerryObjectId, "IX_PaintingQuerryObjectId");

                entity.HasOne(d => d.PaintingQuerry)
                    .WithMany(p => p.CommonConditions)
                    .HasForeignKey(d => d.PaintingQuerryObjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.CommonConditions_dbo.PaintingQuerries_PaintingQuerryObjectId");
            });

            modelBuilder.Entity<Curator>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Curators");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Currency");

                entity.ToTable("Currency");

                entity.Property(e => e.DecimalSymbol)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.DigitGroupingSymbol)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ExchangeRate).HasColumnType("decimal(22, 6)");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Documents");

                entity.Property(e => e.ObjectId).ValueGeneratedNever();

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasDefaultValueSql("(0x)");

                entity.Property(e => e.MD5).HasMaxLength(32);

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<DocumentNodeRef>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.DocumentNodeRefs");

                entity.HasIndex(e => e.DocumentId, "IX_DocumentId");

                entity.Property(e => e.ObjectId).ValueGeneratedNever();

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.DocumentNodeRefs)
                    .HasForeignKey(d => d.DocumentId)
                    .HasConstraintName("FK_dbo.DocumentNodeRefs_dbo.Documents_DocumentId");
            });

            modelBuilder.Entity<DocumentWorkTask>(entity =>
            {
                entity.HasKey(e => new { e.Document_ObjectId, e.WorkTask_ObjectId })
                    .HasName("PK_dbo.DocumentWorkTasks");

                entity.HasIndex(e => e.Document_ObjectId, "IX_Document_ObjectId");
                entity.HasIndex(e => e.WorkTask_ObjectId, "IX_WorkTask_ObjectId");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.DocumentWorkTasks)
                    .HasForeignKey(d => d.Document_ObjectId)
                    .HasConstraintName("FK_dbo.DocumentWorkTasks_dbo.Documents_Document_ObjectId");

                entity.HasOne(d => d.WorkTask)
                    .WithMany(p => p.DocumentWorkTasks)
                    .HasForeignKey(d => d.WorkTask_ObjectId)
                    .HasConstraintName("FK_dbo.DocumentWorkTasks_dbo.WorkTasks_WorkTask_ObjectId");
            });

            modelBuilder.Entity<EPS>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.EPS");

                entity.ToTable("EPS");

                entity.HasIndex(e => e.P3DBModel_ObjectId, "IX_P3DBModel_ObjectId");
                entity.HasIndex(e => e.ParentId, "IX_ParentId");

                entity.Property(e => e.CodeName).HasMaxLength(200);

                entity.HasOne(d => d.P3DBModel)
                    .WithMany(p => p.EPS)
                    .HasForeignKey(d => d.P3DBModel_ObjectId)
                    .HasConstraintName("FK_dbo.EPS_dbo.P3DBModel_P3DBModel_ObjectId");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_dbo.EPS_dbo.EPS_ParentId");
            });

            modelBuilder.Entity<Element3D>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Element3D");

                entity.ToTable("Element3D");

                entity.HasIndex(e => e.Report3dObjectId, "IX_Report3dObjectId");

                entity.HasOne(d => d.Report3D)
                    .WithMany(p => p.Elements3D)
                    .HasForeignKey(d => d.Report3dObjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.Element3D_dbo.Report3D_Report3dObjectId");
            });

            modelBuilder.Entity<FilterAnnotaion>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.FilterAnnotaions");

                entity.HasIndex(e => e.AnnotationObjectId, "IX_AnnotationObjectId");

                entity.HasOne(d => d.Annotation)
                    .WithMany(p => p.Filters)
                    .HasForeignKey(d => d.AnnotationObjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.FilterAnnotaions_dbo.Annotations_AnnotationObjectId");
            });

            modelBuilder.Entity<Indicator>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Indicators");
            });

            modelBuilder.Entity<IndicatorCondition>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.IndicatorConditions");
            });

            modelBuilder.Entity<JournalRecord>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.JournalRecords");

                entity.HasIndex(e => e.User_ObjectId, "IX_User_ObjectId");
                entity.HasIndex(e => e.WorkTask_ObjectId, "IX_WorkTask_ObjectId");

                entity.Property(e => e.ObjectId).ValueGeneratedNever();
                entity.Property(e => e.EventDate).HasColumnType("datetime");
                entity.Property(e => e.EventMessage).IsRequired();

                entity.HasOne(d => d.User)
                    //.WithMany(p => p.JournalRecords)
                    .WithMany()
                    .HasForeignKey(d => d.User_ObjectId)
                    .HasConstraintName("FK_dbo.JournalRecords_dbo.Users_User_ObjectId");

                entity.HasOne(d => d.WorkTask)
                    .WithMany(p => p.LogMessages)
                    .HasForeignKey(d => d.WorkTask_ObjectId)
                    .HasConstraintName("FK_dbo.JournalRecords_dbo.WorkTasks_WorkTask_ObjectId");
            });

            //modelBuilder.Entity<OBEY>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("OBEY");

            //    entity.Property(e => e.A1_Proliv).HasMaxLength(100);

            //    entity.Property(e => e.A3_1_GI_CP).HasMaxLength(100);

            //    entity.Property(e => e.A3_2_GO).HasMaxLength(100);

            //    entity.Property(e => e.ActualFinishDate).HasColumnType("datetime");

            //    entity.Property(e => e.ActualStartDate).HasColumnType("datetime");

            //    entity.Property(e => e.Budget)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Building).HasMaxLength(100);

            //    entity.Property(e => e.Contractor).HasMaxLength(120);

            //    entity.Property(e => e.Diameter)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ID_ресурса)
            //        .IsRequired()
            //        .HasMaxLength(40)
            //        .HasColumnName("ID ресурса");

            //    entity.Property(e => e.Id)
            //        .IsRequired()
            //        .HasMaxLength(40);

            //    entity.Property(e => e.Labor).HasColumnType("decimal(38, 6)");

            //    entity.Property(e => e.MD_Group).HasMaxLength(100);

            //    entity.Property(e => e.Material)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(120);

            //    entity.Property(e => e.NumberDrawing)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PlannedFinishDate).HasColumnType("datetime");

            //    entity.Property(e => e.PlannedStartDate).HasColumnType("datetime");

            //    entity.Property(e => e.PointBudget)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Project_Part).HasMaxLength(100);

            //    entity.Property(e => e.Resource_Name)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.Resource_Units_Act).HasColumnType("decimal(17, 6)");

            //    entity.Property(e => e.Resource_Units_Pl).HasColumnType("decimal(17, 6)");

            //    entity.Property(e => e.SMR_Code)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Schedule_Point)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.System_Code).HasMaxLength(100);

            //    entity.Property(e => e.UnitMeasure)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Unit_Weight)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UoM)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.Used_on_1st_block).HasMaxLength(100);

            //    entity.Property(e => e.Vent_System)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Volume)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<OgRecord>(entity =>
            {
                entity.HasKey(e => e.RecordGuid)
                    .HasName("PK_dbo.OgRecords");

                entity.HasIndex(e => e.ActivityObjectId, "IX_ActivityObjectId");

                entity.Property(e => e.RecordGuid).ValueGeneratedNever();
                entity.Property(e => e.ImportDate).HasColumnType("datetime");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.OgRecords)
                    .HasForeignKey(d => d.ActivityObjectId)
                    .HasConstraintName("FK_dbo.OgRecords_dbo.Activity_ActivityObjectId");
            });

            modelBuilder.Entity<OgToActivityMapping>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.OgToActivityMappings");

                entity.HasIndex(e => e.OgAttributeId, "IX_OgAttributeId");

                entity.HasIndex(e => e.ProjectObjectId, "IX_ProjectObjectId");

                entity.HasOne(d => d.OgAttribute)
                    //.WithMany(p => p.OgToActivityMappings)
                    .WithMany()
                    .HasForeignKey(d => d.OgAttributeId)
                    .HasConstraintName("FK_dbo.OgToActivityMappings_dbo.OgUdfTypes_OgAttributeId");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.OgToActivityMappings)
                    .HasForeignKey(d => d.ProjectObjectId)
                    .HasConstraintName("FK_dbo.OgToActivityMappings_dbo.Projects_ProjectObjectId");
            });

            modelBuilder.Entity<OgUDFValue>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.OgUDFValues");

                entity.HasIndex(e => e.GUID, "IX_GUID");

                entity.Property(e => e.DateValue).HasColumnType("datetime");

                entity.HasOne(d => d.OgRecord)
                    .WithMany(p => p.OgUdfValues)
                    .HasForeignKey(d => d.GUID)
                    .HasConstraintName("FK_dbo.OgUDFValues_dbo.OgRecords_GUID");
            });

            modelBuilder.Entity<OgUdfType>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.OgUdfTypes");
            });

            modelBuilder.Entity<P3DBActivitiesRelation>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.P3DBActivitiesRelations");

                entity.HasIndex(e => e.ActivityObjectId, "IX_ActivityObjectId");

                entity.HasIndex(e => e.P3DBModelId, "IX_P3DBModelId");

                entity.Property(e => e.InternalPath).IsRequired();

                entity.HasOne(d => d.Activity)
                    //.WithMany(p => p.P3DBActivitiesRelations)
                    .WithMany()
                    .HasForeignKey(d => d.ActivityObjectId)
                    .HasConstraintName("FK_dbo.P3DBActivitiesRelations_dbo.Activity_ActivityObjectId");

                entity.HasOne(d => d.Model)
                    //.WithMany(p => p.P3DBActivitiesRelations)
                    .WithMany()
                    .HasForeignKey(d => d.P3DBModelId)
                    .HasConstraintName("FK_dbo.P3DBActivitiesRelations_dbo.P3DBModel_P3DBModelId");
            });

            modelBuilder.Entity<P3DBAttribute>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.P3DBAttribute");

                entity.ToTable("P3DBAttribute");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<P3DBIsometricDrawingAttributeRelation>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.P3DBIsometricDrawingAttributeRelations");

                entity.HasIndex(e => e.IsometricDrawingObjectId, "IX_IsometricDrawingObjectId");

                entity.Property(e => e.AttributeName).IsRequired();

                entity.HasOne(d => d.IsometricDrawing)
                    //.WithMany(p => p.P3DBIsometricDrawingAttributeRelations)
                    .WithMany()
                    .HasForeignKey(d => d.IsometricDrawingObjectId)
                    .HasConstraintName("FK_dbo.P3DBIsometricDrawingAttributeRelations_dbo.Documents_IsometricDrawingObjectId");

                entity.HasOne(d => d.ModelAttributeRelation)
                    .WithMany(p => p.IsometricDrawingAttributeRelations)
                    .HasForeignKey(d => d.ModelAttributeRelationObjectId)
                    .HasConstraintName("FK_dbo.P3DBIsometricDrawingAttributeRelations_dbo.P3DBModelAttributeRelations_ModelAttributeRelationObjectId");
            });

            modelBuilder.Entity<P3DBModel>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.P3DBModel");

                entity.ToTable("P3DBModel");

                entity.HasIndex(e => e.RelationsLastUpdateUser_ObjectId, "IX_RelationsLastUpdateUser_ObjectId");
                entity.HasIndex(e => e.User_ObjectId, "IX_User_ObjectId");

                entity.Property(e => e.ObjectId).ValueGeneratedNever();

                //TODO: этого свойства нет в модели MDP1.0, оно грузится специальным менеджером
                //entity.Property(e => e.Content)
                //    .IsRequired()
                //    .HasDefaultValueSql("(0x)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.MD5).HasMaxLength(32);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.RelationsLastUpdateDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.User_ObjectId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.RelationsLastUpdateUser)
                    //.WithMany(p => p.P3DBModelRelationsLastUpdateUser_Objects)
                    .WithMany()
                    .HasForeignKey(d => d.RelationsLastUpdateUser_ObjectId)
                    .HasConstraintName("FK_dbo.P3DBModel_dbo.Users_RelationsLastUpdateUser_ObjectId");

                entity.HasOne(d => d.User)
                    //.WithMany(p => p.P3DBModelUser_Objects)
                    .WithMany()
                    .HasForeignKey(d => d.User_ObjectId)
                    .HasConstraintName("FK_dbo.P3DBModel_dbo.Users_User_ObjectId");
            });

            modelBuilder.Entity<P3DBModelAttributeRelation>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.P3DBModelAttributeRelations");

                entity.HasIndex(e => e.ModelObjectId, "IX_ModelObjectId");

                entity.Property(e => e.AttributeName).IsRequired();

                entity.HasOne(d => d.Model)
                    //.WithMany(p => p.P3DBModelAttributeRelations)
                    .WithMany()
                    .HasForeignKey(d => d.ModelObjectId)
                    .HasConstraintName("FK_dbo.P3DBModelAttributeRelations_dbo.P3DbModel_ModelObjectId");
            });

            modelBuilder.Entity<P3DBModelElement>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.P3DBModelElement");

                entity.ToTable("P3DBModelElement");

                entity.HasIndex(e => e.P3DBModelId, "IX_P3DBModelId");

                entity.Property(e => e.InternalPath).IsRequired();
                entity.Property(e => e.UID).IsRequired();

                entity.HasOne(d => d.Model)
                    //.WithMany(p => p.P3DBModelElements)
                    .WithMany()
                    .HasForeignKey(d => d.P3DBModelId)
                    .HasConstraintName("FK_dbo.P3DBModelElement_dbo.P3DBModel_P3DBModelId");
            });

            modelBuilder.Entity<P3DbActivitiesRelationProfile>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.P3DbActivitiesRelationProfile");

                entity.ToTable("P3DbActivitiesRelationProfile");

                entity.Property(e => e.ActivityCsvHeader).IsRequired();
                entity.Property(e => e.ActivityProperty).IsRequired();
                entity.Property(e => e.P3DbCsvHeader).IsRequired();
                entity.Property(e => e.P3DbProperty).IsRequired();
                entity.Property(e => e.Separator).IsRequired();
            });

            modelBuilder.Entity<PaintingCondition>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.PaintingConditions");

                entity.HasIndex(e => e.PaintingQuerryObjectId, "IX_PaintingQuerryObjectId");

                entity.HasOne(d => d.PaintingQuerry)
                    .WithMany(p => p.PaintingConditions)
                    .HasForeignKey(d => d.PaintingQuerryObjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.PaintingConditions_dbo.PaintingQuerries_PaintingQuerryObjectId");
            });

            modelBuilder.Entity<PaintingQuerry>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.PaintingQuerries");

                entity.HasIndex(e => e.Report3dObjectId, "IX_Report3dObjectId");

                entity.HasOne(d => d.Report3D)
                    .WithMany(p => p.PaintingQuerries)
                    .HasForeignKey(d => d.Report3dObjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.PaintingQuerries_dbo.Report3D_Report3dObjectId");
            });

            modelBuilder.Entity<PartActivityId>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.PartActivityIds");

                entity.HasIndex(e => e.RuleId, "IX_RuleId");

                entity.HasOne(d => d.RuleCreateActivityId)
                    .WithMany(p => p.PartActivityIds)
                    .HasForeignKey(d => d.RuleId)
                    .HasConstraintName("FK_dbo.PartActivityIds_dbo.RuleCreateActivityIds_RuleId");
            });

            modelBuilder.Entity<Performer>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Performers");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<PerformerActivityCode>(entity =>
            {
                entity.HasKey(e => new { e.Performer_ObjectId, e.Project_ObjectId })
                    .HasName("PK_dbo.PerformerActivityCodes");

                entity.HasOne(d => d.PerformerCode)
                    //.WithMany(p => p.PerformerActivityCodes)
                    .WithMany()
                    .HasForeignKey(d => d.PerformerCode_ObjectId)
                    .HasConstraintName("FK_dbo.PerformerActivityCodes_dbo.ActivityCode_PerformerCode_ObjectId");

                entity.HasOne(d => d.Performer)
                    .WithMany(p => p.PerformerCodes)
                    .HasForeignKey(d => d.Performer_ObjectId)
                    .HasConstraintName("FK_dbo.PerformerActivityCodes_dbo.Performers_Performer_ObjectId");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.PerformerActivityCodes)
                    .HasForeignKey(d => d.Project_ObjectId)
                    .HasConstraintName("FK_dbo.PerformerActivityCodes_dbo.Projects_Project_ObjectId");
            });

            modelBuilder.Entity<PerformerTeam>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.PerformerTeams");

                entity.HasIndex(e => e.PerformerId, "IX_PerformerId");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Performer)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.PerformerId)
                    .HasConstraintName("FK_dbo.PerformerTeams_dbo.Performers_PerformerId");
            });

            modelBuilder.Entity<Period>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Periods");

                entity.HasIndex(e => new { e.StartDate, e.EndDate }, "UQ_Period_Start_End")
                    .IsUnique();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Projects");

                entity.HasIndex(e => e.CodeForArchiveProjectNumber_ObjectId, "IX_CodeForArchiveProjectNumber_ObjectId");
                entity.HasIndex(e => e.CodeTypeForPerformer_ObjectId, "IX_CodeTypeForPerformer_ObjectId");
                entity.HasIndex(e => e.EPS_ObjectId, "IX_EPS_ObjectId");
                entity.HasIndex(e => e.LastUpdateUser_ObjectId, "IX_LastUpdateUser_ObjectId");
                entity.HasIndex(e => e.UDFTypeForPlacement_ObjectId, "IX_UDFTypeForPlacement_ObjectId");

                entity.Property(e => e.DataDate).HasColumnType("datetime");
                entity.Property(e => e.HasErrors)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.LastUpdateDateTime).HasColumnType("datetime");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.CodeForArchiveProjectNumber)
                    .WithMany(p => p.ProjectCodeForArchiveProjectNumber_Objects)
                    .HasForeignKey(d => d.CodeForArchiveProjectNumber_ObjectId)
                    .HasConstraintName("FK_dbo.Projects_dbo.UDFType_CodeForArchiveProjectNumber_ObjectId");

                entity.HasOne(d => d.CodeForBudgetNumber)
                    .WithMany(p => p.ProjectCodeForBudgetNumber_Objects)
                    .HasForeignKey(d => d.CodeForBudgetNumber_ObjectId)
                    .HasConstraintName("FK_dbo.Projects_dbo.UDFType_CodeForBudgetNumber_ObjectId");

                entity.HasOne(d => d.CodeForSystemName)
                    .WithMany(p => p.ProjectCodeForSystemName_Objects)
                    .HasForeignKey(d => d.CodeForSystemName_ObjectId)
                    .HasConstraintName("FK_dbo.Projects_dbo.UDFType_CodeForSystemName_ObjectId");

                entity.HasOne(d => d.CodeTypeForConstructionObject)
                    .WithMany(p => p.ProjectsCodeTypeForConstructionObject)
                    .HasForeignKey(d => d.CodeTypeForConstructionObject_ObjectId)
                    .HasConstraintName("FK_dbo.Projects_dbo.ActivityCodeType_CodeTypeForConstructionObject_ObjectId");

                entity.HasOne(d => d.CodeTypeForPerformer)
                    .WithMany(p => p.ProjectsWithCodeTypeForPerformer)
                    .HasForeignKey(d => d.CodeTypeForPerformer_ObjectId)
                    .HasConstraintName("FK_dbo.Projects_dbo.ActivityCodeType_CodeTypeForPerformer_ObjectId");

                entity.HasOne(d => d.CodeTypeForProjectPart)
                    .WithMany(p => p.ProjectsCodeTypeForProjectPart)
                    .HasForeignKey(d => d.CodeTypeForProjectPart_ObjectId)
                    .HasConstraintName("FK_dbo.Projects_dbo.ActivityCodeType_CodeTypeForProjectPart_ObjectId");

                entity.HasOne(d => d.EPS_Object)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.EPS_ObjectId)
                    .HasConstraintName("FK_dbo.Projects_dbo.EPS_EPS_ObjectId");

                entity.HasOne(d => d.LastUpdateUser_Object)
                    //.WithMany(p => p.Projects)
                    .WithMany()
                    .HasForeignKey(d => d.LastUpdateUser_ObjectId)
                    .HasConstraintName("FK_dbo.Projects_dbo.Users_LastUpdateUser_ObjectId");

                entity.HasOne(d => d.UDFTypeForPlacement_Object)
                    .WithMany(p => p.ProjectUDFTypeForPlacement_Objects)
                    .HasForeignKey(d => d.UDFTypeForPlacement_ObjectId)
                    .HasConstraintName("FK_dbo.Projects_dbo.UDFType_UDFTypeForPlacement_ObjectId");
            });

            modelBuilder.Entity<ProjectRole>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.ProjectRole");

                entity.ToTable("ProjectRole");

                entity.HasIndex(e => e.ParentObjectId, "IX_ParentObjectId");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.ParentObjectId)
                    .HasConstraintName("FK_dbo.ProjectRole_dbo.ProjectRole_ParentObjectId");
            });

            modelBuilder.Entity<Relationship>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Relationship");

                entity.ToTable("Relationship");

                entity.HasIndex(e => e.PredecessorActivityObjectId, "IX_PredecessorActivityObjectId");
                entity.HasIndex(e => e.ProjectObjectId, "IX_ProjectObjectId");
                entity.HasIndex(e => e.SuccessorActivityObjectId, "IX_SuccessorActivityObjectId");

                entity.Property(e => e.Lag).HasColumnType("decimal(17, 6)");

                entity.HasOne(d => d.PredecessorActivityObject)
                    .WithMany(p => p.PredecessorActivityRelationships)
                    .HasForeignKey(d => d.PredecessorActivityObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Relationship_dbo.Activity_PredecessorActivityObjectId");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Relationships)
                    .HasForeignKey(d => d.ProjectObjectId)
                    .HasConstraintName("FK_dbo.Relationship_dbo.Projects_ProjectObjectId");

                entity.HasOne(d => d.SuccessorActivityObject)
                    .WithMany(p => p.SuccessorActivityRelationships)
                    .HasForeignKey(d => d.SuccessorActivityObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Relationship_dbo.Activity_SuccessorActivityObjectId");
            });

            modelBuilder.Entity<Report3D>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Report3D");

                entity.ToTable("Report3D");

                entity.HasIndex(e => e.P3DbModelObjectId, "IX_P3DbModelObjectId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.P3DbModel)
                    .WithMany(p => p.Reports3D)
                    .HasForeignKey(d => d.P3DbModelObjectId)
                    .HasConstraintName("FK_dbo.Report3D_dbo.P3DbModel_P3DbModelObjectId");
            });

            modelBuilder.Entity<Report3DWorkTask>(entity =>
            {
                entity.HasKey(e => new { e.Report3D_ObjectId, e.WorkTask_ObjectId })
                    .HasName("PK_dbo.Report3DWorkTask");

                entity.ToTable("Report3DWorkTask");

                entity.HasIndex(e => e.Report3D_ObjectId, "IX_Report3D_ObjectId");
                entity.HasIndex(e => e.WorkTask_ObjectId, "IX_WorkTask_ObjectId");

                entity.HasOne(d => d.Report3D)
                    .WithMany(p => p.Report3DWorkTasks)
                    .HasForeignKey(d => d.Report3D_ObjectId)
                    .HasConstraintName("FK_dbo.Report3DWorkTask_dbo.Report3D_Report3D_ObjectId");

                entity.HasOne(d => d.WorkTask)
                    .WithMany(p => p.Report3DWorkTasks)
                    .HasForeignKey(d => d.WorkTask_ObjectId)
                    .HasConstraintName("FK_dbo.Report3DWorkTask_dbo.WorkTasks_WorkTask_ObjectId");
            });

            modelBuilder.Entity<ReportTemplate>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<ResAssignUDF>(entity =>
            {
                entity.ToTable("ResAssignUDF");

                entity.HasIndex(e => e.ResAssignId, "IX_ResAssignId");
                entity.HasIndex(e => e.TypeObjectId, "IX_TypeObjectId");

                entity.Property(e => e.CostValue).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.DoubleValue).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.FinishDateValue).HasColumnType("datetime");
                entity.Property(e => e.StartDateValue).HasColumnType("datetime");

                entity.HasOne(d => d.ResourceAssignment)
                    .WithMany(p => p.ResAssignUDFs)
                    .HasForeignKey(d => d.ResAssignId)
                    .HasConstraintName("FK_dbo.ResAssignUDF_dbo.ResourceAssignment_ResAssignId");

                entity.HasOne(d => d.UDFType)
                    .WithMany(p => p.ResAssignUDFs)
                    .HasForeignKey(d => d.TypeObjectId)
                    .HasConstraintName("FK_dbo.ResAssignUDF_dbo.UDFType_TypeObjectId");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Resource");

                entity.ToTable("Resource");

                entity.HasIndex(e => e.CalendarObjectId, "IX_CalendarObjectId");

                entity.HasIndex(e => e.CurrencyObjectId, "IX_CurrencyObjectId");

                entity.HasIndex(e => e.Parent_ObjectId, "IX_Parent_ObjectId");

                entity.HasIndex(e => e.UnitOfMeasureObjectId, "IX_UnitOfMeasureObjectId");

                entity.Property(e => e.DefaultUnitsPerTime).HasColumnType("decimal(16, 8)");

                entity.Property(e => e.EmailAddress).HasMaxLength(120);

                entity.Property(e => e.EmployeeId).HasMaxLength(40);

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OfficePhone).HasMaxLength(32);

                entity.Property(e => e.OtherPhone).HasMaxLength(32);

                entity.Property(e => e.OvertimeFactor).HasColumnType("decimal(5, 3)");

                entity.Property(e => e.ResourceNotes).HasMaxLength(4000);

                entity.Property(e => e.Title).HasMaxLength(40);

                entity.HasOne(d => d.Calendar)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.CalendarObjectId)
                    .HasConstraintName("FK_dbo.Resource_dbo.Calendar_CalendarObjectId");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.CurrencyObjectId)
                    .HasConstraintName("FK_dbo.Resource_dbo.Currency_CurrencyObjectId");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.Parent_ObjectId)
                    .HasConstraintName("FK_dbo.Resource_dbo.Resource_Parent_ObjectId");

                entity.HasOne(d => d.UnitOfMeasure)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.UnitOfMeasureObjectId)
                    .HasConstraintName("FK_dbo.Resource_dbo.UnitOfMeasure_UnitOfMeasureObjectId");
            });

            modelBuilder.Entity<ResourceAssignment>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.ResourceAssignment");

                entity.ToTable("ResourceAssignment");

                entity.HasIndex(e => e.ActivityObjectId, "IX_ActivityObjectId");
                entity.HasIndex(e => e.ResourceObjectId, "IX_ResourceObjectId");

                entity.Property(e => e.ActualCost).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ActualFinishDate).HasColumnType("datetime");
                entity.Property(e => e.ActualOvertimeCost).HasColumnType("decimal(23, 6)");
                entity.Property(e => e.ActualOvertimeUnits).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.ActualRegularCost).HasColumnType("decimal(23, 6)");
                entity.Property(e => e.ActualRegularUnits).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.ActualStartDate).HasColumnType("datetime");
                entity.Property(e => e.ActualThisPeriodCost).HasColumnType("decimal(23, 6)");
                entity.Property(e => e.ActualThisPeriodUnits).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.ActualUnits).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.AtCompletionCost).HasColumnType("decimal(23, 6)");
                entity.Property(e => e.AtCompletionUnits).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.FinishDate).HasColumnType("datetime");
                entity.Property(e => e.OvertimeFactor).HasColumnType("decimal(5, 3)");
                entity.Property(e => e.PendingActualOvertimeUnits).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.PendingActualRegularUnits).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.PendingPercentComplete).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.PendingRemainingUnits).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.PlannedCost).HasColumnType("decimal(23, 6)");
                entity.Property(e => e.PlannedDuration).HasColumnType("decimal(23, 6)");
                entity.Property(e => e.PlannedFinishDate).HasColumnType("datetime");
                entity.Property(e => e.PlannedLag).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.PlannedStartDate).HasColumnType("datetime");
                entity.Property(e => e.PlannedUnits).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.PlannedUnitsPerTime).HasColumnType("decimal(16, 8)");
                entity.Property(e => e.PricePerUnit).HasColumnType("decimal(21, 8)");
                entity.Property(e => e.RemainingCost).HasColumnType("decimal(23, 6)");
                entity.Property(e => e.RemainingDuration).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.RemainingFinishDate).HasColumnType("datetime");
                entity.Property(e => e.RemainingLag).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.RemainingStartDate).HasColumnType("datetime");
                entity.Property(e => e.RemainingUnits).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.RemainingUnitsPerTime).HasColumnType("decimal(16, 8)");
                entity.Property(e => e.ResourceRequest).HasMaxLength(1);
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.Property(e => e.UnitsPercentComplete).HasColumnType("decimal(19, 16)");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ResourceAssignments)
                    .HasForeignKey(d => d.ActivityObjectId)
                    .HasConstraintName("FK_dbo.ResourceAssignment_dbo.Activity_ActivityObjectId");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.ResourceAssignments)
                    .HasForeignKey(d => d.ResourceObjectId)
                    .HasConstraintName("FK_dbo.ResourceAssignment_dbo.Resource_ResourceObjectId");
            });

            modelBuilder.Entity<ResourceCode>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.ResourceCode");

                entity.ToTable("ResourceCode");

                entity.HasIndex(e => e.ParentObjectId, "IX_ParentObjectId");

                entity.Property(e => e.CodeValue)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.ParentObject)
                    .WithMany(p => p.InverseParentObject)
                    .HasForeignKey(d => d.ParentObjectId)
                    .HasConstraintName("FK_dbo.ResourceCode_dbo.ResourceCode_ParentObjectId");
            });

            modelBuilder.Entity<ResourceCodeType>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.ResourceCodeType");

                entity.ToTable("ResourceCodeType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<ResourceRate>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.ResourceRate");

                entity.ToTable("ResourceRate");

                entity.HasIndex(e => e.ResourceObjectId, "IX_ResourceObjectId");

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
                entity.Property(e => e.MaxUnitsPerTime).HasColumnType("decimal(16, 8)");
                entity.Property(e => e.PricePerUnit).HasColumnType("decimal(21, 8)");
                entity.Property(e => e.PricePerUnit2).HasColumnType("decimal(21, 8)");
                entity.Property(e => e.PricePerUnit3).HasColumnType("decimal(21, 8)");
                entity.Property(e => e.PricePerUnit4).HasColumnType("decimal(21, 8)");
                entity.Property(e => e.PricePerUnit5).HasColumnType("decimal(21, 8)");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.ResourceRates)
                    .HasForeignKey(d => d.ResourceObjectId)
                    .HasConstraintName("FK_dbo.ResourceRate_dbo.Resource_ResourceObjectId");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Roles");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<RuleCreateActivityId>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.RuleCreateActivityIds");
            });

            modelBuilder.Entity<Substitution>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Substitutions");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.Substitutions)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_dbo.Substitutions_dbo.P3DBAttribute_AttributeId");
            });

            modelBuilder.Entity<SupplierMappingRule>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.SupplierMappingRules");

                entity.Property(e => e.Condition).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<SupplierPortalJournal>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.SupplierPortalJournals");

                entity.HasIndex(e => e.UserObjectId, "IX_UserObjectId");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.HasOne(d => d.UserObject)
                    //.WithMany(p => p.SupplierPortalJournals)
                    .WithMany()
                    .HasForeignKey(d => d.UserObjectId)
                    .HasConstraintName("FK_dbo.SupplierPortalJournals_dbo.Users_UserObjectId");
            });

            modelBuilder.Entity<SupplierRecord>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.SupplierRecords");

                entity.Property(e => e.ObjectId).ValueGeneratedNever();

                entity.Property(e => e.ImportDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SupplierRecordsToActivity>(entity =>
            {
                entity.HasKey(e => new { e.ActivityId, e.RecordId })
                    .HasName("PK_dbo.SupplierRecordsToActivities");

                entity.HasIndex(e => e.ActivityId, "IX_ActivityId");

                entity.HasIndex(e => e.RecordId, "IX_RecordId");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.SupplierRecordsToActivities)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_dbo.SupplierRecordsToActivities_dbo.Activity_ActivityId");

                entity.HasOne(d => d.Record)
                    .WithMany(p => p.SupplierRecordsToActivities)
                    .HasForeignKey(d => d.RecordId)
                    .HasConstraintName("FK_dbo.SupplierRecordsToActivities_dbo.SupplierRecords_RecordId");
            });

            modelBuilder.Entity<SupplierUDF>(entity =>
            {
                entity.ToTable("SupplierUDF");

                entity.HasIndex(e => e.SupplierRecordId, "IX_SupplierRecordId");

                entity.HasIndex(e => e.UdfTypeObjectId, "IX_UdfTypeObjectId");

                entity.Property(e => e.CostValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DoubleValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FinishDateValue).HasColumnType("datetime");

                entity.Property(e => e.StartDateValue).HasColumnType("datetime");

                entity.HasOne(d => d.SupplierRecord)
                    .WithMany(p => p.SupplierUDFs)
                    .HasForeignKey(d => d.SupplierRecordId)
                    .HasConstraintName("FK_dbo.SupplierUDF_dbo.SupplierRecords_SupplierRecordId");

                entity.HasOne(d => d.UdfTypeObject)
                    .WithMany(p => p.SupplierUDFs)
                    .HasForeignKey(d => d.UdfTypeObjectId)
                    .HasConstraintName("FK_dbo.SupplierUDF_dbo.SupplierUDFType_UdfTypeObjectId");
            });

            modelBuilder.Entity<SupplierUDFType>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.SupplierUDFType");

                entity.ToTable("SupplierUDFType");

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<SystemConfig>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.SystemConfigs");

                entity.HasIndex(e => e.Name, "IX_Name")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<UDFType>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.UDFType");

                entity.ToTable("UDFType");

                entity.Property(p => p.DataType)
                    .HasConversion(new EnumToNumberConverter<UDFDataType, byte>());

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<UnitOfMeasure>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.UnitOfMeasure");

                entity.ToTable("UnitOfMeasure");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Users");

                entity.HasIndex(e => e.Performer_ObjectId, "IX_Performer_ObjectId");
                entity.HasIndex(e => e.UserRole_ObjectId, "IX_UserRole_ObjectId");

                entity.Property(e => e.DomainName).HasMaxLength(120);
                entity.Property(e => e.Email).HasMaxLength(256);
                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Password).HasMaxLength(128);
                entity.Property(e => e.PhoneNumber).HasMaxLength(40);

                entity.HasOne(d => d.Curator)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CuratorObjectId)
                    .HasConstraintName("FK_dbo.Users_dbo.Curators_CuratorObjectId");

                entity.HasOne(d => d.Performer)
                    .WithMany(p => p.PerformerUsers)
                    .HasForeignKey(d => d.Performer_ObjectId)
                    .HasConstraintName("FK_dbo.Users_dbo.Performers_Performer_ObjectId");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRole_ObjectId)
                    .HasConstraintName("FK_dbo.Users_dbo.Roles_UserRole_ObjectId");
            });

            modelBuilder.Entity<UserAudit>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.UserAudits");

                entity.HasIndex(e => e.UserObjectId, "IX_UserObjectId");

                entity.Property(e => e.DateEvent).HasColumnType("datetime");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.UserObject)
                    //.WithMany(p => p.UserAudits)
                    .WithMany()
                    .HasForeignKey(d => d.UserObjectId)
                    .HasConstraintName("FK_dbo.UserAudits_dbo.Users_UserObjectId");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.UserGroups");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<UserGroupEPS>(entity =>
            {
                entity.HasKey(e => new { e.UserGroup_ObjectId, e.EPS_ObjectId })
                    .HasName("PK_dbo.UserGroupEPS");

                entity.ToTable("UserGroupEPS");

                entity.HasIndex(e => e.EPS_ObjectId, "IX_EPS_ObjectId");

                entity.HasIndex(e => e.UserGroup_ObjectId, "IX_UserGroup_ObjectId");

                entity.HasOne(d => d.EPS_Object)
                    .WithMany(p => p.UserGroupEPs)
                    .HasForeignKey(d => d.EPS_ObjectId)
                    .HasConstraintName("FK_dbo.UserGroupEPS_dbo.EPS_EPS_ObjectId");

                entity.HasOne(d => d.UserGroup_Object)
                    .WithMany(p => p.UserGroupEPs)
                    .HasForeignKey(d => d.UserGroup_ObjectId)
                    .HasConstraintName("FK_dbo.UserGroupEPS_dbo.UserGroups_UserGroup_ObjectId");
            });

            modelBuilder.Entity<UserGroupUser>(entity =>
            {
                entity.HasKey(e => new { e.UserGroup_ObjectId, e.User_ObjectId })
                    .HasName("PK_dbo.UserGroupUsers");

                entity.HasIndex(e => e.UserGroup_ObjectId, "IX_UserGroup_ObjectId");

                entity.HasIndex(e => e.User_ObjectId, "IX_User_ObjectId");

                entity.HasOne(d => d.UserGroup_Object)
                    .WithMany(p => p.UserGroupUsers)
                    .HasForeignKey(d => d.UserGroup_ObjectId)
                    .HasConstraintName("FK_dbo.UserGroupUsers_dbo.UserGroups_UserGroup_ObjectId");

                entity.HasOne(d => d.User_Object)
                    .WithMany(p => p.UserGroupUsers)
                    .HasForeignKey(d => d.User_ObjectId)
                    .HasConstraintName("FK_dbo.UserGroupUsers_dbo.Users_User_ObjectId");
            });

            modelBuilder.Entity<UserStateSettings>(entity =>
            {
                entity.HasKey(e => e.User_ObjectId)
                    .HasName("PK_dbo.UserStateSettings");

                entity.HasIndex(e => e.User_ObjectId, "IX_User_ObjectId");

                entity.Property(e => e.User_ObjectId).ValueGeneratedNever();

                entity.HasOne(d => d.User_Object)
                    .WithOne(p => p.StateSettings)
                    .HasForeignKey<UserStateSettings>(d => d.User_ObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.UserStateSettings_dbo.Users_User_ObjectId");
            });

            //modelBuilder.Entity<View_2>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("View_2");

            //    entity.Property(e => e.Id)
            //        .IsRequired()
            //        .HasMaxLength(40);

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(120);

            //    entity.Property(e => e.ValueName).HasMaxLength(100);
            //});

            modelBuilder.Entity<WorkBreakdownStructure>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.WBS");

                entity.ToTable("WBS");

                entity.HasIndex(e => e.ParentObjectId, "IX_ParentObjectId");
                entity.HasIndex(e => e.ProjectObjectId, "IX_ProjectObjectId");

                entity.Property(e => e.AnticipatedFinishDate).HasColumnType("datetime");
                entity.Property(e => e.AnticipatedStartDate).HasColumnType("datetime");
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.EarnedValueETCUserValue).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.EarnedValueUserPercent).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.EstimatedWeight).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.IndependentETCLaborUnits).HasColumnType("decimal(17, 6)");
                entity.Property(e => e.IndependentETCTotalCost).HasColumnType("decimal(23, 6)");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OriginalBudget).HasColumnType("decimal(23, 6)");

                entity.HasOne(d => d.ParentObject)
                    .WithMany(p => p.InverseParentObject)
                    .HasForeignKey(d => d.ParentObjectId)
                    .HasConstraintName("FK_dbo.WBS_dbo.WBS_ParentObjectId");

                entity.HasOne(d => d.ProjectObject)
                    .WithMany(p => p.WBs)
                    .HasForeignKey(d => d.ProjectObjectId)
                    .HasConstraintName("FK_dbo.WBS_dbo.Projects_ProjectObjectId");
            });

            modelBuilder.Entity<WorkTask>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.WorkTasks");

                entity.HasIndex(e => e.Curator_ObjectId, "IX_Curator_ObjectId");
                entity.HasIndex(e => e.Performer_ObjectId, "IX_Performer_ObjectId");
                entity.HasIndex(e => e.ProjectId, "IX_ProjectId");

                entity.Property(e => e.ActualDataToPrimaveraAPIDateTime).HasColumnType("datetime");
                entity.Property(e => e.DateOfIssue).HasColumnType("datetime");
                entity.Property(e => e.LastStatusChangedTime).HasColumnType("datetime");
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Number).IsRequired();
                entity.Property(e => e.PlannedDateEnd).HasColumnType("datetime");
                entity.Property(e => e.PlannedDateStart).HasColumnType("datetime");

                entity.HasOne(d => d.ConstructionObject)
                    //.WithMany(p => p.WorkTaskConstructionObjects)
                    .WithMany()
                    .HasForeignKey(d => d.ConstructionObjectId)
                    .HasConstraintName("FK_dbo.WorkTasks_dbo.ActivityCode_ConstructionObjectId");

                entity.HasOne(d => d.Curator)
                    .WithMany(p => p.WorkTasks)
                    .HasForeignKey(d => d.Curator_ObjectId)
                    .HasConstraintName("FK_dbo.WorkTasks_dbo.Curators_Curator_ObjectId");

                entity.HasOne(d => d.Performer)
                    .WithMany(p => p.PerformerWorkTasks)
                    .HasForeignKey(d => d.Performer_ObjectId)
                    .HasConstraintName("FK_dbo.WorkTasks_dbo.Performers_Performer_ObjectId");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.WorkTasks)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.WorkTasks_dbo.Projects_ProjectId");

                entity.HasOne(d => d.ProjectPart)
                    //.WithMany(p => p.WorkTaskProjectParts)
                    .WithMany()
                    .HasForeignKey(d => d.ProjectPartId)
                    .HasConstraintName("FK_dbo.WorkTasks_dbo.ActivityCode_ProjectPartId");

                entity.HasOne(d => d.SystemName)
                    //.WithMany(p => p.WorkTaskSystemNames)
                    .WithMany()
                    .HasForeignKey(d => d.SystemNameId)
                    .HasConstraintName("FK_dbo.WorkTasks_dbo.ActivityCode_SystemNameId");
            });

            modelBuilder.Entity<WorkTaskAttributeValue>(entity =>
            {
                entity.HasIndex(e => e.AttributeType_ObjectId, "IX_AttributeType_ObjectId");

                entity.HasIndex(e => e.WorkTask_ObjectId, "IX_WorkTask_ObjectId");

                entity.HasOne(d => d.AttributeType_Object)
                    .WithMany(p => p.WorkTaskAttributeValues)
                    .HasForeignKey(d => d.AttributeType_ObjectId)
                    .HasConstraintName("FK_dbo.WorkTaskAttributeValues_dbo.AttributesTypes_AttributeType_ObjectId");

                entity.HasOne(d => d.WorkTask_Object)
                    .WithMany(p => p.WorkTaskAttributeValues)
                    .HasForeignKey(d => d.WorkTask_ObjectId)
                    .HasConstraintName("FK_dbo.WorkTaskAttributeValues_dbo.WorkTasks_WorkTask_ObjectId");
            });

            modelBuilder.Entity<WorkTaskNumberPart>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.WorkTaskNumberParts");
            });

            modelBuilder.Entity<WorkTaskP3DBModel>(entity =>
            {
                entity.HasKey(e => new { e.WorkTask_ObjectId, e.P3DBModel_ObjectId })
                    .HasName("PK_dbo.WorkTaskP3DBModel");

                entity.ToTable("WorkTaskP3DBModel");

                entity.HasIndex(e => e.P3DBModel_ObjectId, "IX_P3DBModel_ObjectId");

                entity.HasIndex(e => e.WorkTask_ObjectId, "IX_WorkTask_ObjectId");

                entity.HasOne(d => d.P3DBModel)
                    .WithMany(p => p.WorkTaskP3DBModels)
                    .HasForeignKey(d => d.P3DBModel_ObjectId)
                    .HasConstraintName("FK_dbo.WorkTaskP3DBModel_dbo.P3DBModel_P3DBModel_ObjectId");

                entity.HasOne(d => d.WorkTask)
                    .WithMany(p => p.WorkTaskP3DBModels)
                    .HasForeignKey(d => d.WorkTask_ObjectId)
                    .HasConstraintName("FK_dbo.WorkTaskP3DBModel_dbo.WorkTasks_WorkTask_ObjectId");
            });

            modelBuilder.Entity<WorkType>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.WorkTypes");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_dbo.Workers");

                entity.HasIndex(e => e.Performer_ObjectId, "IX_Performer_ObjectId");

                entity.Property(e => e.ObjectId).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.MiddleName).HasMaxLength(80);

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasDefaultValueSql("(0x)");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Performer_Object)
                    //.WithMany(p => p.Workers)
                    .WithMany()
                    .HasForeignKey(d => d.Performer_ObjectId)
                    .HasConstraintName("FK_dbo.Workers_dbo.Performers_Performer_ObjectId");
            });

            //modelBuilder.Entity<__MigrationHistory>(entity =>
            //{
            //    entity.HasKey(e => new { e.MigrationId, e.ContextKey })
            //        .HasName("PK_dbo.__MigrationHistory");

            //    entity.ToTable("__MigrationHistory");

            //    entity.Property(e => e.MigrationId).HasMaxLength(150);
            //    entity.Property(e => e.ContextKey).HasMaxLength(300);
            //    entity.Property(e => e.Model).IsRequired();
            //    entity.Property(e => e.ProductVersion)
            //        .IsRequired()
            //        .HasMaxLength(32);
            //});

            //modelBuilder.Entity<__ScriptMigrationHistory>(entity =>
            //{
            //    entity.HasKey(e => e.ScriptName)
            //        .HasName("PK_dbo.__ScriptMigrationHistory");

            //    entity.ToTable("__ScriptMigrationHistory");

            //    entity.Property(e => e.ScriptName).HasMaxLength(4000);

            //    entity.Property(e => e.Hash).HasMaxLength(20);
            //});

            //modelBuilder.Entity<tmp_nsz>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("tmp_nsz");

            //    entity.Property(e => e.A1_Proliv).HasMaxLength(100);
            //    entity.Property(e => e.A3_HGO).HasMaxLength(100);
            //    entity.Property(e => e.ActualFinishDate).HasColumnType("datetime");
            //    entity.Property(e => e.ActualStartDate).HasColumnType("datetime");
            //    entity.Property(e => e.Budget)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Building).HasMaxLength(100);
            //    entity.Property(e => e.Contractor).HasMaxLength(120);
            //    entity.Property(e => e.Diameter)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ID_ресурса)
            //        .IsRequired()
            //        .HasMaxLength(40)
            //        .HasColumnName("ID ресурса");

            //    entity.Property(e => e.Id)
            //        .IsRequired()
            //        .HasMaxLength(40);

            //    entity.Property(e => e.Labor).HasColumnType("decimal(38, 6)");
            //    entity.Property(e => e.MD_Group).HasMaxLength(100);

            //    entity.Property(e => e.Material)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(120);

            //    entity.Property(e => e.NumberDrawing)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PlannedFinishDate).HasColumnType("datetime");
            //    entity.Property(e => e.PlannedStartDate).HasColumnType("datetime");
            //    entity.Property(e => e.PointBudget)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Project_Part).HasMaxLength(100);
            //    entity.Property(e => e.Resource_Name)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.Resource_Units_Act).HasColumnType("decimal(17, 6)");
            //    entity.Property(e => e.Resource_Units_Pl).HasColumnType("decimal(17, 6)");
            //    entity.Property(e => e.SMR_Code)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Schedule_Point)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.System_Code).HasMaxLength(100);
            //    entity.Property(e => e.UnitMeasure)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Unit_Weight)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UoM)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.Volume)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<Дубликаты_кодов_работ>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToView("Дубликаты кодов работ");

            //    entity.Property(e => e.Title).IsRequired();
            //});

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}