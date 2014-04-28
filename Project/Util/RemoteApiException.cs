using System;

namespace Kazyx.RemoteApi
{
    /// <summary>
    /// Exception for Task style async request.
    /// </summary>
    public class RemoteApiException : Exception
    {
        /// <summary>
        /// Status code of this Remote API error.
        /// </summary>
        public StatusCode code { get; private set; }

        internal RemoteApiException(int code)
        {
            this.code = (StatusCode)code;
        }

        internal RemoteApiException(StatusCode code)
        {
            this.code = code;
        }
    }
}
