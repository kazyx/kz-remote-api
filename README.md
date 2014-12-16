kz-remote-api
=============
- Sony camera remote API wrapper for .NET
- Currently supports [Camera Remote API beta v1.9.0](https://developer.sony.com/develop/cameras/).

##Build
1. Clone repository.
 ``` bash
 git clone git@github.com:kazyx/kz-remote-api.git
 ```

2. Open csproj file by Visual Studio.
 - /Project/KzRemoteApi.csproj for Windows Phone 8 or 8.1 application.
 - /Project/KzRemoteApiUniversal.csproj for Universal Windows application.
 - /Project/KzRemoteApiDesktop.csproj for Desktop Windows application.

3. Add reference to [Json.NET](https://github.com/JamesNK/Newtonsoft.Json).

##Call camera remote APIs
1. Get end point URL of the services. See [kz-ssdp-discovery](https://github.com/kazyx/kz-ssdp-discovery).
 ``` cs
 discovery.SonyCameraDeviceDiscovered += (sender, e) => {
     var endpoints = e.SonyCameraDevice.Endpoints;
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
