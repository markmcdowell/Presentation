using System;

namespace Presentation.Interfaces
{
    /// <summary>
    /// Defines the startup of the application.
    /// </summary>
    public interface IBootstrapper : IDisposable
    {
        /// <summary>
        /// Initialize the bootstrapper
        /// </summary>
        void Initialize();
    }
}