using Ninject;
using School.BLL;
using School.BLL.DomainModel;
using School.BLL.Implements;
using School.BLL.Interfaces;
using School.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace School.CompositionRoot
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind(typeof(IRepository<>)).To(typeof(RepositoryImpl<>));
            kernel.Bind(typeof(IService)).To(typeof(ServiceImpl));
        //    kernel.Bind(typeof(IAdminService)).To(typeof(AdminServiceImpl));
         //   kernel.Bind(typeof(IMinistryService)).To(typeof(MinistryServiceImpl));
       //     kernel.Bind(typeof(IStudentService)).To(typeof(StudentServiceImpl));
            kernel.Bind(typeof(IUnitOfWork)).To(typeof(UnitOfWorkImpl));
          //  kernel.Bind<Itest>().To<Test>();
        }
    }
}
