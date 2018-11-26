//-----------------------------------------------------------------------
// <copyright file="RepositoryMapper.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BusinessLogic.WireUp
{
    using Autofac;
    using BusinessLogic.Interface;

    /// <summary>
    /// Repostory mapper class
    /// </summary>
    public class RepositoryMapper: Module
    {
        /// <summary>
        /// Load method
        /// </summary>
        /// <param name="builder">Container builder</param>
        protected override void Load(ContainerBuilder builder)
        {
           
            builder.RegisterType<UsersRepository>().As<IUsersRepository>();
            builder.RegisterType<BusinessRuleRepository>().As<IBusinessRuleRepository>();
            builder.RegisterType<BusinessUnitRepository>().As<IBusinessUnitRepository>();
            builder.RegisterType<CostCenterRepository>().As<ICostCenterRepository>();
            builder.RegisterType<EntityRepository>().As<IEntityRepository>();
            builder.RegisterType<LegalEntityRepository>().As<ILegalEntityRepository>();
            builder.RegisterType<OrganizationUnitRepository>().As<IOrganizationUnitRepository>();
            builder.RegisterType<ProcessRepository>().As<IProcessRepository>();
            builder.RegisterType<ResourceCenterRepository>().As<IResourceCenterRepository>();
            builder.RegisterType<ResourcesRepository>().As<IResourcesRepository>();
            builder.RegisterType<RolesRepository>().As<IRolesRepository>();
            builder.RegisterType<UserRoleMappingRepository>().As<IUserRoleMappingRepository>();
            builder.RegisterType<WorkflowRepository>().As<IWorkflowRepository>();
            builder.RegisterType<WorkflowStepsRepository>().As<IWorkflowStepsRepository>();
        }

    }
}
