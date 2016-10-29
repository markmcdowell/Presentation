using System;

namespace Presentation.Interfaces
{
    /// <summary>
    /// Defines a module.
    /// </summary>
    public interface IModule : IDisposable
    {
        /// <summary>
        /// Initialize the module
        /// </summary>
        void Initialize();
    }
}