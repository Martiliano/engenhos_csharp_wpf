using System;

namespace Lantern.Helpers
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
