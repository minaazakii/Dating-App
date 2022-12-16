using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string>GetSecret()
        {
            return "secret Text";
        }

        [HttpGet("not-found")]
        public ActionResult<string>GetNotFound()
        {
           return NotFound();
        }

        [HttpGet("server-error")]
        public ActionResult<string>GetServerError()
        {
            var thing = _context.Users.Find(-1);
            var returnThing = thing.ToString() ;
            return returnThing;
        }
        [HttpGet("bad-request")]
        public ActionResult<string>GetBadRequest()
        {
            return BadRequest("This is Bad Request");
        }
    }
}