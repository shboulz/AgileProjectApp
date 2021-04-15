using AgileProject.Models;
using AgileProject.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgileProject.Controllers
{
    [Authorize]
    public class BodyController : ApiController
    {
        private BodyService CreateBodyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bodyService = new BodyService(userId);
            return bodyService;
        }

        public IHttpActionResult Get()
        {
            BodyService bodyService = CreateBodyService();
            var bodies = bodyService.GetBodies();
            return Ok(bodies);
        }

        public IHttpActionResult Post(BodyCreate body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBodyService();

            if (!service.CreateBody(body))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            BodyService bodyService = CreateBodyService();
            var body = bodyService.GetBodyById(id);
            return Ok(body);
        }

        public IHttpActionResult Put(BodyEdit body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBodyService();

            if (!service.UpdateBody(body))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateBodyService();

            if (!service.DeleteBody(id))
                return InternalServerError();

            return Ok();
        }
    }
}
