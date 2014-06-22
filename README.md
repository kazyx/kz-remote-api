KzRemoteApi
=============
- Sony camera remote API wrapper for .NET
- Currently supports [Camera Remote API beta v1.6.0](https://developer.sony.com/develop/cameras/).

##Build
1. Clone repository.
 ``` bash
 git clone git@github.com:kazyx/KzRemoteApi.git
 ```

2. Open csproj file by Visual Studio.
 - /Project/KzRemoteApi.csproj for Windows Phone 8.
 - /Project/KzRemoteApiUniversal.csproj for Universal Windows application.

3. Add reference to [Json.NET](https://github.com/JamesNK/Newtonsoft.Json).

##Call camera remote APIs
1. Get end point URL of the services. See [KzSoDiscovery](https://github.com/kazyx/KzSoDiscovery).
 ``` cs
 discovery.ScalarDeviceDiscovered += (sender, e) => {
     var endpoints = e.ScalarDevice.Endpoints;
 }
 ```

2. Create ApiClient instance.
 ``` cs
 var camera = new CameraApiClient(endpoints["camera"]);
 ```

3. Call async API.
 ``` cs
 var picUrls = await camera.ActTakePictureAsync();
 ```

##License
This software is published under the [MIT License](http://opensource.org/licenses/mit-license).
