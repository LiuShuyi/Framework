namespace Framework.Network.Http
{
    /// <summary>
    /// HttpRequest Processing Delegate
    /// </summary>
    /// <param name="httpRequest"></param>
    public delegate HttpResponseInfo HttpProcessingDelegate(HttpRequestInfo httpRequest);
}