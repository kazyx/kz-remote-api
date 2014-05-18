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
            if (Enum.IsDefined(typeof(StatusCode), code))
            {
                this.code = (StatusCode)code;
            }
            else
            {
                this.code = StatusCode.Undefined;
            }
        }

        internal RemoteApiException(StatusCode code)
        {
            this.code = code;
        }
    }
}
