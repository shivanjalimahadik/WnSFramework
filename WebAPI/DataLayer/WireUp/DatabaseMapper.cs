//-----------------------------------------------------------------------
// <copyright file="DatabaseMapper.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DataAccess.WireUp
{
    using Autofac;
    using DataAccess.Interface;
    using DataAccess.Util;

    /// <summary>
    /// Database mapper class
    /// </summary>
    public class DatabaseMapper : Module
    {
        /// <summary>
        /// Load method
        /// </summary>
        /// <param name="builder">Container builder</param>
        protected override void Load(ContainerBuilder builder)
        {
            this.RegisterConnectionString(builder);

            builder.RegisterType<BusinessRuleDA>().As<IBusinessRuleDA>();
            builder.RegisterType<UsersDA>().As<IUsersDA>();
            builder.RegisterType<BusinessUnitDA>().As<IBusinessUnitDA>();
            builder.RegisterType<CostCenterDA>().As<ICostCenterDA>();
            builder.RegisterType<EntityDA>().As<IEntityDA>();
            builder.RegisterType<LegalEntityDA>().As<ILegalEntityDA>();
            builder.RegisterType<OrganizationUnitDA>().As<IOrganizationUnitDA>();
            builder.RegisterType<ProcessDA>().As<IProcessDA>();
            builder.RegisterType<ResourceCenterDA>().As<IResourceCenterDA>();
            builder.RegisterType<ResourcesDA>().As<IResourcesDA>();
            builder.RegisterType<RolesDA>().As<IRolesDA>();
            builder.RegisterType<UserRoleMappingDA>().As<IUserRoleMappingDA>();
            builder.RegisterType<WorkflowDA>().As<IWorkflowDA>();
            builder.RegisterType<WorkflowStepsDA>().As<IWorkflowStepsDA>();
        }

        /// <summary>
        /// Registers connection string
        /// </summary>
        /// <param name="builder">Container builder</param>
        private void RegisterConnectionString(ContainerBuilder builder)
        {
            builder.RegisterType<SqlDatabaseSettings>().As<ISqlDatabaseSettings>().InstancePerLifetimeScope();
        }
    }
}
