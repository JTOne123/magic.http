/*
 * Magic, Copyright(c) Thomas Hansen 2019 - thomas@gaiasoul.com
 * Permission to use under the terms of the MIT license is hereby granted, see
 * the enclosed LICENSE file for details.
 */

using System;
using System.IO;
using System.Threading.Tasks;

namespace magic.http.contracts
{
    /// <summary>
    /// Gives you easy one line of code access to invoke HTTP REST requests.
    ///
    /// If a non-successful HTTP response is returned from your endpoint, an
    /// HttpException will be thrown, from where you can retrieve the StatusCode
    /// and the friendly error message, if any from the HTTP endpoint.
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>
        /// Posts an object asynchronously to the specified URL. Notice, you can supply a Stream as your request,
        /// and the service will intelligently determine it's a stream, and serialize it directly on to the HTTP request stream.
        /// </summary>
        /// <typeparam name="Request">Type of request.</typeparam>
        /// <typeparam name="Response">Type of response.</typeparam>
        /// <param name="url">URL of your request.</param>
        /// <param name="request">Payload of your request.</param>
        /// <param name="contentType">Optional Content-Type for your request. Defaults to "application/json" if omitted.</param>
        /// <param name="token">Optional Bearer token for your request.</param>
        /// <returns>Object returned from your request.</returns>
        Task<Response> PostAsync<Request, Response>(
            string url,
            Request request,
            string contentType = "application/json",
            string token = null);

        /// <summary>
        /// Puts an object asynchronously to the specified URL. Notice, you can supply a Stream as your request,
        /// and the service will intelligently determine it's a stream, and serialize it directly on to the HTTP request stream.
        /// </summary>
        /// <typeparam name="Request">Type of request.</typeparam>
        /// <typeparam name="Response">Type of response.</typeparam>
        /// <param name="url">URL of your request.</param>
        /// <param name="request">Payload of your request.</param>
        /// <param name="contentType">Optional Content-Type for your request. Defaults to "application/json" if omitted.</param>
        /// <param name="token">Optional Bearer token for your request.</param>
        /// <returns>Object returned from your request.</returns>
        Task<Response> PutAsync<Request, Response>(
            string url,
            Request request,
            string contentType = "application/json",
            string token = null);

        /// <summary>
        /// Gets a resource from some URL.
        /// </summary>
        /// <typeparam name="Response">Type of response.</typeparam>
        /// <param name="url">URL of your request.</param>
        /// <param name="token">Optional Bearer token for your request.</param>
        /// <returns>Object returned from your request.</returns>
        Task<Response> GetAsync<Response>(
            string url,
            string token = null);

        /// <summary>
        /// Gets a resource from some URL. Notice, this overload requires you to supply
        /// an Action taking a Stream as its input, from where you can directly access the response content,
        /// without having to load it into memory. This is useful for downloading larger documents from some URL.
        /// </summary>
        /// <param name="url">URL of your request.</param>
        /// <param name="functor">Action lambda function given the response Stream for you to do whatever you wish with once the request returns.</param>
        /// <param name="token">Optional Bearer token for your request.</param>
        /// <returns>Async void Task</returns>
        Task GetAsync(
            string url,
            Action<Stream> functor,
            string token = null);

        /// <summary>
        /// Deletes some resource.
        /// </summary>
        /// <typeparam name="Response">Type of response.</typeparam>
        /// <param name="url">URL of your request.</param>
        /// <param name="token">Optional Bearer token for your request.</param>
        /// <returns>Result of your request.</returns>
        Task<Response> DeleteAsync<Response>(
            string url,
            string token = null);
    }
}