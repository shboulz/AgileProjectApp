using AgileProject.Data;
using AgileProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileProject.Services
{
    public class FaceService
    {
        private readonly Guid _userId;

        public FaceService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFace(FaceCreate model)
        {
            var entity = new Face()
            {
                CharFaceId = _userId,
                FaceShape = model.FaceShape,
                EyeShape = model.EyeShape,
                EyeColor = model.EyeColor,
                EyebrowShape = model.EyebrowShape,
                Nose = model.Nose,
                Mouth = model.Mouth,
                EarHeight = model.EarHeight,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Faces.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FaceListItem> GetFaces()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Faces
                    .Where(e => e.CharFaceId == _userId)
                    .Select(
                    e =>
                    new FaceListItem
                    {
                        FaceId = e.FaceId,
                        CharFaceId = e.CharFaceId,
                    }
                  );
                return query.ToArray();
            }
        }
        public FaceDetail GetFaceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Faces
                        .Single(e => e.FaceId == id && e.CharFaceId == _userId);
                return
                    new FaceDetail
                    {
                        CharFaceId = _userId,
                        FaceShape = entity.FaceShape,
                        EyeShape = entity.EyeShape,
                        EyeColor = entity.EyeColor,
                        EyebrowShape = entity.EyebrowShape,
                        Nose = entity.Nose,
                        Mouth = entity.Mouth,
                        EarHeight = entity.EarHeight,
                    };
            }
        }

        public bool UpdateFace(FaceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Faces
                        .Single(e => e.FaceId == model.FaceId && e.CharFaceId == _userId);

                entity.FaceShape = model.FaceShape;
                entity.EyeShape = model.EyeShape;
                entity.EyeColor = model.EyeColor;
                entity.EyebrowShape = entity.EyebrowShape;
                entity.Nose = model.Nose;
                entity.Mouth = model.Mouth;
                entity.EarHeight = model.EarHeight;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFace(int faceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Faces
                        .Single(e => e.FaceId == faceId && e.CharFaceId == _userId);

                ctx.Faces.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
