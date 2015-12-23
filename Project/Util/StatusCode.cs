
namespace Kazyx.RemoteApi
{
    /// <summary>
    /// Status code definition.
    /// </summary>
    public enum StatusCode
    {
        Cancelled = -3,
        NetworkError = -2,
        Undefined = -1,
        OK = 0,
        Any = 1,
        Timeout = 2,
        IllegalArgument = 3,
        IllegalDataFormat = 4,
        IllegalRequest = 5,
        IllegalResponse = 6,
        IllegalState = 7,
        IllegalType = 8,
        IndexOutOfBounds = 9,
        NoSuchElement = 10,
        NoSuchField = 11,
        NoSuchMethod = 12,
        NullPointer = 13,
        UnsupportedVersion = 14,
        UnsupportedOperation = 15,
        Unauthrorized = 401,
        Forbidden = 403,
        NotFound = 404,
        NotAcceptable = 406,
        RequestEntityTooLarge = 413,
        RequestUriTooLong = 414,
        NotImplemented = 501,
        ServiceUnavailable = 503,
        ShootingFailure = 40400,
        CameraNotReady = 40401,
        DuplicatePolling = 40402,
        StillCapturingNotFinished = 40403,
        ContentProtected = 41000,
        ContentDoesNotExist = 41001,
        StorageRemoved = 41002,
        FailedToDelete = 41003,
    }
}
