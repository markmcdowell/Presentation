using System;

namespace Presentation.Interfaces
{
    /// <summary>
    /// Interface defining a module
    /// </summary>
    public interface IModule : IDisposable
    {
        /// <summary>
        /// Initialize the module
        /// </summary>
        void Initialize();
    }
}