using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using PBZ_Lab2.Domain.Infrastructure;
using PBZ_Lab2.Web.Repository.Repositories;

namespace PBZ_Lab2.Web.Services.Modules
{
    public class DbModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>();
        }
    }
}
