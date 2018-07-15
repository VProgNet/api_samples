using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using System.Security.Claims;
using System.Threading;

namespace AwesomeSauce.Server
{
    public class AwesomeHttpContext : HttpContext
    {
        //
        // Summary:
        //     Gets the collection of HTTP features provided by the server and middleware available
        //     on this request.
        private readonly IFeatureCollection _features;

        public override IFeatureCollection Features { get; }

        
        private readonly HttpRequest _request;
        //
        // Summary:
        //     Gets the Microsoft.AspNetCore.Http.HttpRequest object for this request.
        public override HttpRequest Request { get; }
        
        //
        // Summary:
        //     Gets the Microsoft.AspNetCore.Http.HttpResponse object for this request.
        private readonly HttpResponse _response;
        public override HttpResponse Response { get; }

        public AwesomeHttpContext(IFeatureCollection features, string path)
        {
            this.Features = features;
            this.Request = new FileHttpRequest(this, path);
            this.Response = new FileHttpResponse(this, path);
        }
        //
        // Summary:
        //     Gets information about the underlying connection for this request.
        public override ConnectionInfo Connection 
        { 
            get => throw new NotImplementedException(); 
        }
        //
        // Summary:
        //     Gets an object that manages the establishment of WebSocket connections for this
        //     request.
        public override WebSocketManager WebSockets 
        { 
            get => throw new NotImplementedException(); 
        }
        //
        // Summary:
        //     This is obsolete and will be removed in a future version. The recommended alternative
        //     is to use Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.
        //     See https://go.microsoft.com/fwlink/?linkid=845470.
        [Obsolete("This is obsolete and will be removed in a future version. The recommended alternative is to use Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions. See https://go.microsoft.com/fwlink/?linkid=845470.")]
        public override AuthenticationManager Authentication 
        { 
            get => throw new NotImplementedException(); 
        }
        //
        // Summary:
        //     Gets or sets the user for this request.
        public override ClaimsPrincipal User 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }
        //
        // Summary:
        //     Gets or sets a key/value collection that can be used to share data within the
        //     scope of this request.
        public override IDictionary<object, object> Items 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }
        //
        // Summary:
        //     Gets or sets the System.IServiceProvider that provides access to the request's
        //     service container.
        public override IServiceProvider RequestServices 
        { 
            get => throw new NotImplementedException();
            set => throw new NotImplementedException(); 
        }
        //
        // Summary:
        //     Notifies when the connection underlying this request is aborted and thus request
        //     operations should be cancelled.
        public override CancellationToken RequestAborted 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException();
        }
        //
        // Summary:
        //     Gets or sets a unique identifier to represent this request in trace logs.
        public override string TraceIdentifier 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }
        //
        // Summary:
        //     Gets or sets the object used to manage user session data for this request.
        public override ISession Session 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        //
        // Summary:
        //     Aborts the connection underlying this request.
        public override void Abort()
        {
            throw new NotImplementedException();
        }
    }

}
