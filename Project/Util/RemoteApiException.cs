using System;

namespace Kazyx.RemoteApi
{
    /// <summary>
    /// Exception for Task style async request.
    /// </summary>
    public class RemoteApiException : Exception
    {
        [Obsolete("Use StatusCode instead")]
        public StatusCode code { get { return StatusCode; } }

        /// <summary>
        /// Status code of this Remote API error.
        /// </summary>
        public StatusCode StatusCode { get; private set; }

        internal RemoteApiException(int code)
        {
            if (Enum.IsDefined(typeof(StatusCode), code))
            {
                StatusCode = (StatusCode)code;
            }
            else
            {
                StatusCode = StatusCode.Undefined;
            }
        }

        internal RemoteApiException(StatusCode code)
        {
            StatusCode = code;
        }
    }
}
