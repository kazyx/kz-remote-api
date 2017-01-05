using System.Collections.Generic;
using System.Linq;

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

        public override bool Equals(object o)
        {
            if (o == null) { return false; }
            if (!(o is Capability<T>)) { return false; }
            var other = o as Capability<T>;
            if (!Current.Equals(other.Current)) { return false; }
            if (Candidates?.Count != other.Candidates?.Count) { return false; }
            return Candidates.SequenceEqual(other.Candidates);
        }

        public override int GetHashCode()
        {
            return Current.GetHashCode() + Candidates.GetHashCode();
        }

        public static bool operator ==(Capability<T> x, Capability<T> y)
        {
            if (ReferenceEquals(x, null))
            {
                return ReferenceEquals(y, null);
            }
            return x.Equals(y);
        }

        public static bool operator !=(Capability<T> x, Capability<T> y)
        {
            if (ReferenceEquals(x, null))
            {
                return !ReferenceEquals(y, null);
            }
            return !x.Equals(y);
        }
    }
}
