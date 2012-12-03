using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PublicService.Framework.Autofac;

[assembly: WebActivator.PostApplicationStartMethod(typeof(PublicService.App_Start.AutofacConfigure), "Start")]
namespace PublicService.App_Start {
  public static class AutofacConfigure {
    public static void Start()
    {
      AutofacBuilder.Configure();
    }
  }
}
