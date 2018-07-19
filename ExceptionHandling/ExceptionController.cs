using Microsoft.AspNetCore.Mvc;
using System;

using ExceptionMiddleware;
using Microsoft.AspNetCore.Http;

namespace ExceptionHandling
{
    public class ExceptionController : Controller
    {
        [HttpGet("~/broken")]
        public string Get(int id)
        {
            //throw new ArgumentNullException();
            throw new HttpStatusCodeException(StatusCodes.Status400BadRequest, @"You sent bad stuff");
        }
    }
}