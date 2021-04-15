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
    public class FaceController : ApiController
    {
        private FaceService CreateFaceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var faceService = new FaceService(userId);
            return faceService;
        }

        public IHttpActionResult Get()
        {
            FaceService faceService = CreateFaceService();
            var faces = faceService.GetFaces();
            return Ok(faces);
        }

        public IHttpActionResult Get(int id)
        {
            FaceService faceService = CreateFaceService();
            var face = faceService.GetFaceById(id);
            return Ok(face);
        }

        public IHttpActionResult Post(FaceCreate face)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFaceService();

            if (!service.CreateFace(face))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(FaceEdit face)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateFaceService();

            if (!service.UpdateFace(face))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateFaceService();

            if (!service.DeleteFace(id))
                return InternalServerError();

            return Ok();
        }
    }
}
