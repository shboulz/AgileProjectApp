using AgileProject.Data;
using AgileProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileProject.Services
{
    public class BodyService
    {
        private readonly Guid _charBodyId;

        public BodyService(Guid CharBodyId)
        {
            _charBodyId = CharBodyId;
        }

        public bool CreateBody(BodyCreate model)
        {
            var entity =
                new Body()
                {
                    CharBodyId = _charBodyId,
                    BodyType = model.BodyType,
                    BodyDescription = model.BodyDescription,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Bodies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BodyListItem> GetBodies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Bodies
                        .Where(e => e.CharBodyId == _charBodyId)
                        .Select(
                            e =>
                                new BodyListItem
                                {
                                    BodyId = e.BodyId,
                                    BodyType = e.BodyType,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public BodyDetail GetBodyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Bodies
                        .Single(e => e.BodyId == id && e.CharBodyId == _charBodyId);
                return
                    new BodyDetail
                    {
                        BodyId = entity.BodyId,
                        BodyType = entity.BodyType,
                        BodyDescription = entity.BodyDescription,
                        CharBodyId = entity.CharBodyId,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc

                    };
            }
        }

        public bool UpdateBody(BodyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Bodies
                        .Single(e => e.BodyId == model.BodyId && e.CharBodyId == _charBodyId);

                entity.BodyType = model.BodyType;
                entity.BodyDescription = model.BodyDescription;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBody(int bodyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Bodies
                        .Single(e => e.BodyId == bodyId && e.CharBodyId == _charBodyId);

                ctx.Bodies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
