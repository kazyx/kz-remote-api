using System;

namespace Kazyx.RemoteApi
{
    public class ApiMetaAttribute : Attribute
    {
        public ApiMetaAttribute(string apiName)
        {
            ApiName = apiName;
        }

        public string ApiName { private set; get; }
    }
}
