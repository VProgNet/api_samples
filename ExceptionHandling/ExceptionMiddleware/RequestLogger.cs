using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace ExceptionMiddleware
{
    public static class RequestLogger
    {
        public static void LogError(ILogger logger, HttpContext context)
        {
                string scheme = context.Request.Scheme;

                string localAddr = context.Request.HttpContext.Connection.LocalIpAddress.ToString() 
                                + context.Request.HttpContext.Connection.LocalPort.ToString();
            
                string relativePath = context.Request.Path.Value;

                string fullPath = scheme + "://" + localAddr + ":" + relativePath;

                if (context.Request.QueryString.HasValue)
                {
                    fullPath = fullPath + context.Request.QueryString.Value;
                }

                string method = context.Request.Method.ToString();
                string protocol = context.Request.Protocol;

                logger.LogError($"Request: {protocol} {method} {fullPath}");

                string ip = context.Request.HttpContext.Connection.RemoteIpAddress.ToString();
                string port = context.Request.HttpContext.Connection.RemotePort.ToString();
                
                if (context.User.Identity.IsAuthenticated) {
                    logger.LogError($"User: {context.User.Identity.Name} {ip}:{port}");
                }
                else
                {
                    logger.LogError($"User: anonymous user {ip}:{port}");
                }
                                                
                if (context.Request.Cookies.Count > 0) 
                {
                    foreach (var cookie in context.Request.Cookies)
                    {
                        logger.LogError($"Cookies: {cookie.Key}:{cookie.Value}");
                    }
                    
                }
                else
                {
                    logger.LogError($"Cookies: No cookies presented");
                }
                
                if (context.Request.Headers.Count > 0)
                {
                    foreach (var header in context.Request.Headers)
                    {
                        logger.LogError($"Header: {header.Key}:{header.Value}");
                    }
                }
                else
                {
                    logger.LogError($"Headers: no headers presented");
                }
                
                string body = new StreamReader(context.Request.Body).ReadToEnd();
                if (body.Length > 0)
                {
                    logger.LogError($"Body length {body.Length}");
                    logger.LogError($"Body content: {body}");
                }
                else
                {
                    logger.LogError("Body: no body resented");
                }
        }
    }
}