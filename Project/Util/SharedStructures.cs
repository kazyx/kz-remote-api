using System.Collections.Generic;

namespace Kazyx.RemoteApi
{
    /// <summary>
    /// Response of getMethodTypes API.
    /// </summary>
    public class MethodType
    {
        /// <summary>
        /// Name of API
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// Request parameter types.
        /// </summary>
        public List<string> ReqTypes { set; get; }
        /// <summary>
        /// Response parameter types.
        /// </summary>
        public List<string> ResTypes { set; get; }
        /// <summary>
        /// Version of API
        /// </summary>
        public string Version { set; get; }
    }

    /// <summary>
    /// Set of current value and its candidates.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Capability<T>
    {
        /// <summary>
        /// Current value of the specified parameter.
        /// </summary>
        public virtual T Current { set; get; }

        /// <summary>
        /// Candidate values of the specified parameter.
        /// </summary>
        public virtual List<T> Candidates { set; get; }
    }
}
