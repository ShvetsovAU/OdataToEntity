using ASE.MD.MDP2.Product.MDP2Service.Localization;

namespace ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Enums
{
    public enum ModuleOperationType
    {
        [LocalizedDescription("Neo_AdminModule")]
        AdministrationModule,

        [LocalizedDescription("Neo_CommonSettings")]
        MainSettings,

        [LocalizedDescription("Neo_UsersSettings")]
        UserSettings,

        [LocalizedDescription("Neo_RelationImportSettings")]
        RelationImportSettings,

        [LocalizedDescription("Neo_RzModuleSettings")]
        RzModuleSettings,

        [LocalizedDescription("Neo_RolesSettings")]
        RolesSettings,

        [LocalizedDescription("Neo_ImportTasksModule")]
        ImportModule,

        [LocalizedDescription("Neo_ActivityImport")]
        TaskImport,

        [LocalizedDescription("Neo_StructureChange")]
        EpsEdit,

        [LocalizedDescription("Neo_Import3D")]
        Import3D,

        [LocalizedDescription("Neo_ActivityCreateModule")]
        ActivityCreateModule,

        [LocalizedDescription("Neo_RelationsImportModule")]
        RelationImportModule,

        [LocalizedDescription("Neo_RelationsCreateModule")]
        RelationCreateModule,

        [LocalizedDescription("Neo_ChangesModule")]
        ChangesModule,

        [LocalizedDescription("Neo_OptimizationModule")]
        OptimizationModule,

        [LocalizedDescription("Neo_RelationsBetweenActivities")]
        ActivitiesRelations,

        [LocalizedDescription("Neo_DraggingActivity")]
        ActivitiesMove,

        [LocalizedDescription("Neo_WorkTasksModule")]
        WorkTaskModule,

        [LocalizedDescription("Neo_WorkTaskEdit")]
        WorkTaskEdit,

#warning Remove WorkTask status!
        ////TODO: Remove WorkTask status!
        //[LocalizedDescription("Neo_FactDataEdit")]
        //FactDataEdit,

        [LocalizedDescription("Neo_DailyIntroductionPlanFact")]
        WorkTasksDailyIntroductionPlanFact,

        [LocalizedDescription("Neo_WorkTaskDocuments")]
        WorkTaskDocuments,

        [LocalizedDescription("Neo_ExportModule")]
        ExportModule,

        [LocalizedDescription("Neo_ReportingModule")]
        ReportsModule,

        [LocalizedDescription("Neo_GlobalReports")]
        GlobalReports,

        [LocalizedDescription("Neo_UserReports")]
        UserReports,

        [LocalizedDescription("Neo_Restructure")]
        RestructureModule,

        [LocalizedDescription("Neo_RestructureSettings")]
        RestructureSettings,

        [LocalizedDescription("Neo_WorkWithGlobalStore")]
        WorkWithGlobalStore,

        [LocalizedDescription("Neo_ContractorModuleTitle")]
        ContractorModule,

        [LocalizedDescription("Neo_ExportP3DB")]
        ExportP3Db,

        [LocalizedDescription("Neo_3DModel")]
        Model3D,

        [LocalizedDescription("Neo_ImportDictionaries")]
        ProjectCreationImportDictionaries,

        [LocalizedDescription("Neo_SubstitutionTable")]
        ProjectCreationSubstitutionTable,

        [LocalizedDescription("Neo_ActivityTypes")]
        ProjectCreationActivityType,

        [LocalizedDescription("Neo_Attributes")]
        ProjectCreationAttributeTemplate,

        [LocalizedDescription("Neo_NormTable")]
        ProjectCreationNormTable,

        [LocalizedDescription("Neo_SecondLevelProject")]
        ProjectCreationSecondGraph,

        [LocalizedDescription("Neo_ActivitiesCreation")]
        ProjectCreationActivityCreate,

        [LocalizedDescription("Neo_ActivitiesCreationGantt")]
        ProjectCreationActivityCreateGantt,

        [LocalizedDescription("Neo_ConnectionToOgSettings")]
        JointScheduleSettings,
        [LocalizedDescription("Neo_IndicatorsSettings")]
        IndicatorModuleSettings,
        [LocalizedDescription("Neo_JointScheduleIntegration")]
        JointScheduleIntegration,
        [LocalizedDescription("Neo_SupplierPortalIntegration")]
        SupplierPortalIntegration,
        [LocalizedDescription("Neo_SupplierPortalSettings")]
        SupplierPortalSettings,
        [LocalizedDescription("Neo_3dReporting")]
        Reports3D,

        [LocalizedDescription("Neo_ImportSettings")]
        ImportSettings,

        [LocalizedDescription("Neo_PrimaveraSettings")]
        PrimaveraSettings,

        [LocalizedDescription("Neo_ProjectsCreationSettings")]
        ProjectCreationSettings,

        [LocalizedDescription("Neo_AssemblyUnitsProperties")]
        AssemblyUnitsProperties,

        [LocalizedDescription("Neo_AssemblyUnitsReporting")]
        AssemblyUnitsModule,

        [LocalizedDescription("Neo_UserAudit")]
        UserAudit,

        [LocalizedDescription("Neo_GanttDiagram")]
        GanttDiagram,

        [LocalizedDescription("Neo_ActivityStartConstraint")]
        ActivityStartConstraint,

        [LocalizedDescription("Neo_WBSLevels")]
        WBSLevels,

        [LocalizedDescription("Neo_CalendarsAssigning")]
        CalendarsAssigning,

        #region WorkTasksByStatuses

        /// <summary>
        /// Сформировано
        /// </summary>
        [LocalizedDescription("Neo_WorkTaskStatusValue_Formed")]
        WorkTaskStatusFormed,

        /// <summary>
        /// Отклонено план (автоматическое)
        /// </summary>
        [LocalizedDescription("Neo_WorkTaskStatusValue_RejectedPlanAuto")]
        WorkTaskStatusRejectedPlanAuto,

        /// <summary>
        /// Согласование план (ручное)
        /// </summary>
        [LocalizedDescription("Neo_WorkTaskStatusValue_OnAgreementPlanManually")]
        WorkTaskStatusOnAgreementPlanManually,

        /// <summary>
        /// В разработке
        /// </summary>
        [LocalizedDescription("Neo_WorkTaskStatusValue_InDevelopment")]
        WorkTaskStatusInDevelopment,

        /// <summary>
        /// Выполенние (автоматическое)
        /// </summary>
        [LocalizedDescription("Neo_WorkTaskStatusValue_TakenToWorkAuto")]
        WorkTaskStatusTakenToWorkAuto,

        /// <summary>
        /// Согласование факт
        /// </summary>
        [LocalizedDescription("Neo_WorkTaskStatusValue_OnAgreementFact")]
        WorkTaskStatusOnAgreementFact,

        /// <summary>
        /// Завершено
        /// </summary>
        [LocalizedDescription("Neo_WorkTaskStatusValue_Completed")]
        WorkTaskStatusCompleted,

        /// <summary>
        /// Согласование план (автоматическое)
        /// </summary>
        [LocalizedDescription("Neo_WorkTaskStatusValue_OnAgreementPlanAuto")]
        WorkTaskStatusOnAgreementPlanAuto,

        /// <summary>
        /// Выполнение (ручное)
        /// </summary>
        [LocalizedDescription("Neo_WorkTaskStatusValue_TakenToWorkManually")]
        WorkTaskStatusTakenToWorkManually,

        //Статус из старого воркфлоу вместе со статусом Выполнение авто перешел в статус Согласование факт
        //// Выполнено (ручное)
        ///// </summary>
        //[LocalizedDescription("Neo_WorkTaskStatusValue_AchievedManually")]
        //AchievedManually = 9,

        /// <summary>
        /// Отклонено план(ручное)
        /// </summary>
        [LocalizedDescription("Neo_WorkTaskStatusValue_RejectedPlanManually")]
        WorkTaskStatusRejectedPlanManually,

        /// <summary>
        /// Согласование факт генподрядчик
        /// </summary>
        [LocalizedDescription("Neo_WorkTaskStatusValue_OnAgreementFactGencontractor")]
        WorkTaskStatusOnAgreementFactGencontractor,

        /// <summary>
        /// Отклонено факт
        /// </summary>
        [LocalizedDescription("Neo_WorkTaskStatusValue_RejectedFact")]
        WorkTaskStatusRejectedFact,

        #endregion

        None = int.MaxValue
    }
}