using DocsRepositoryData.Abstract;
using DocsRepositoryData.Concrete;
using Ninject.Injection;
using Ninject;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using DocsRepositoryData.Entities;
using BicycleAuth;

namespace DocsRepository.Infrastucture
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IDocumentsRepository>().To<XMLDocumentsRepository>();
            //ninjectKernel.Bind<IDocumentsRepository>().To<EFDocumentsRepository>();
            ninjectKernel.Bind<IUsersRepository>().To<UsersRepository>();
        }
    }
}