﻿using CeyenneNxt.Core.Enums;
using CeyenneNxt.Core.Interfaces;
using CeyenneNxt.Core.Interfaces.CoreModules;
using CeyenneNxt.Core.ServiceBus;
using CeyenneNxt.Settings.CoreModule;
using SimpleInjector;

namespace CeyenneNXT.ServiceBus
{
  public class Bindings : BindingContainer
  {
    public override void AddBindings(Container container, ApplicationType applicationType)
    {
      var lifeStyle = ApplicationTypeToLifeStyle(applicationType);

      switch (applicationType)
      {
        case ApplicationType.Process:
          {
            break;
          }
        case ApplicationType.WebApi:
          {
            break;
          }
        case ApplicationType.WebUI:
          {
            break;
          }
      }

      container.Register<ISettingModule, SettingModule>(lifeStyle);
    }
  }
}
