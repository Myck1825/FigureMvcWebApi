using AutoMapper;
using FigureMvcWebApi.Model;
using FigureMvcWebApi.Model.Controllers.Services;
using FigureMvcWebApi.Model.Database;
using FigureMvcWebApi.Model.Database.HeadLog;
using FigureMvcWebApi.Model.Database.Repository;
using FigureMvcWebApi.Model.Database.Services.Controllers;
using FigureMvcWebApi.Model.HeadLog;
using Ninject;
using Ninject.Modules;
using Ninject.Web.WebApi.Filter;
using System.Data.Entity;
using System.Web.Http;

namespace FigureMvcWebApi
{
    /// <summary>
    /// Dependency configuration
    /// </summary>
    public class DependencyMapper : NinjectModule
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Load()
        {
            Database.SetInitializer<FigureDbContext>(null);
            this.Bind<IFigureDbContext>().To<FigureDbContext>();

            this.Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
            this.Bind<IRepository<IEntity>>().To<Repository<IEntity>>();
            this.Bind<IRectangleService>().To<RectangleService>();
            this.Bind<IHeadLog>().To<HeadLog>();
            this.Bind<IAOResultLogger>().To<AOResultLogger>();

            var headLog = this.Kernel.Get<IHeadLog>();
            AOResultLoggerProvider.SetAOResultLogger(new AOResultLogger(headLog));
        }

        private IMapper AutoMapper(Ninject.Activation.IContext context)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ConstructServicesUsing(type => context.Kernel.Get(type));
                cfg.AddProfile<EntityToModelProfile>();
            });

            config.AssertConfigurationIsValid();
            return new Mapper(config);
        }
    }
}