using Autofac;
using BusinessLogic.Interface;
using WebAPI.Controllers.api;

namespace WebAPI.WireUp
{
    public class ApiMapper : Module
    {

        /// <summary>
        /// Load method
        /// </summary>
        /// <param name="builder">builder</param>
        protected override void Load(ContainerBuilder builder)
        {            
            
            builder.RegisterType<UsersController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.UsersRepository = e.Context.Resolve<IUsersRepository>();
            });
            builder.RegisterType<BusinessRuleController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.BusinessRuleRepository = e.Context.Resolve<IBusinessRuleRepository>();
            });
            builder.RegisterType<BusinessUnitController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.BusinessUnitRepository = e.Context.Resolve<IBusinessUnitRepository>();
            });
            builder.RegisterType<CostCenterController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.CostCenterRepository = e.Context.Resolve<ICostCenterRepository>();
            });
            builder.RegisterType<EntityController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.EntityRepository = e.Context.Resolve<IEntityRepository>();
            });
            builder.RegisterType<LegalEntityController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.LegalEntityRepository = e.Context.Resolve<ILegalEntityRepository>();
            });
            builder.RegisterType<OrganizationUnitController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.OrganizationUnitRepository = e.Context.Resolve<IOrganizationUnitRepository>();
            });
            builder.RegisterType<ProcessController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.ProcessRepository = e.Context.Resolve<IProcessRepository>();
            });
            builder.RegisterType<ResourceCenterController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.ResourceCenterRepository = e.Context.Resolve<IResourceCenterRepository>();
            });
            builder.RegisterType<ResourcesController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.ResourcesRepository = e.Context.Resolve<IResourcesRepository>();
            });
            builder.RegisterType<RolesController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.RolesRepository = e.Context.Resolve<IRolesRepository>();
            });
            builder.RegisterType<UserRoleMappingController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.UserRoleMappingRepository = e.Context.Resolve<IUserRoleMappingRepository>();
            });
            builder.RegisterType<WorkflowController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.WorkflowRepository = e.Context.Resolve<IWorkflowRepository>();
            });
            builder.RegisterType<WorkflowStepsController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.WorkflowStepsRepository = e.Context.Resolve<IWorkflowStepsRepository>();
            });
        }
    }
}