﻿using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace CeyenneNxt.Core.Mvc
{
  public class IocControllerFactory : DefaultControllerFactory
  {
    public SimpleInjector.Container Kernel { get; private set; }

    public IocControllerFactory(SimpleInjector.Container container)
    {

      this.Kernel = container;
    }

    protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
    {
      if (controllerType == null)
      {
        return null;
      }

      var controller = (IController) Kernel.GetInstance(controllerType);
      if (controller == null)
      {
        return base.GetControllerInstance(requestContext, controllerType);
      }
      else
      {
        return controller;
      }
    }

    protected override Type GetControllerType(RequestContext requestContext, string controllerName)
    {
      if (controllerName == null)
      {
        return base.GetControllerType(requestContext, controllerName);
      }

      var registrations = Kernel.GetCurrentRegistrations();
      var registration =
        registrations.FirstOrDefault(
          p => typeof(IController).IsAssignableFrom(p.Registration.ImplementationType)
            && p.Registration.ImplementationType.Name.StartsWith(controllerName,StringComparison.InvariantCultureIgnoreCase));
      if (registration == null)
      {
        return base.GetControllerType(requestContext, controllerName);
      }
      else
      {
        return registration.Registration.ImplementationType;
      }
    }

  }
}