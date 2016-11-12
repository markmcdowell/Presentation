using System;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using Presentation.Interfaces;

namespace Presentation.Bootstrappers
{
    /// <summary>
    /// Extensions on <see cref="IBootstrapper"/>
    /// </summary>
    public static class BootstrapperExtensions
    {
        public static IBootstrapper InitalizeModules(this IBootstrapper bootstrapper, ExportProvider exportProvider)
        {
            return new ModuleInitializingBootstrapper(bootstrapper, exportProvider);
        }

        public static IBootstrapper CatchTaskExceptions(this IBootstrapper bootstrapper, Func<AggregateException, bool> handler)
        {
            return new UnobservedTaskExceptionBootstrapper(bootstrapper, handler);
        }

        public static IBootstrapper CatchAppDomainExceptions(this IBootstrapper bootstrapper, AppDomain appDomain, Action<Exception, bool> handler)
        {
            return new UnhandledAppDomainExceptionBootstrapper(bootstrapper, appDomain, handler);
        }

        public static IBootstrapper CatchDispatcherExceptions(this IBootstrapper bootstrapper, Application application, Func<Exception, bool> handler)
        {
            return new UnhandledDispatcherExceptionBootstrapper(bootstrapper, application, handler);
        }
    }
}