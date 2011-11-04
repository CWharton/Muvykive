using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace Muvykive.Web.UI
{
    public class IoCControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// Resolve dependencies in controllers
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
            {
                return ObjectFactory.GetInstance(controllerType) as IController;
            }
            return null;
        }
    }
}