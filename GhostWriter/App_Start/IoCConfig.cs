using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.Mvc;
using Ghostwriter.Entities;
using Ghostwriter.Repository;
using Microsoft.Practices.ServiceLocation;
using System.Reflection;
using System.Web.Mvc;

namespace GhostWriter
{
    public class IoCConfig
    {
        public static void RegisterAutoFac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterFilterProvider();

            builder.RegisterType<PostRepository>().As<IPostRepository>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>().InstancePerRequest();
            builder.RegisterType<VoteRepository>().As<IVoteRepository>().InstancePerRequest();
            builder.RegisterType<GhostWriterDbContext>().InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}