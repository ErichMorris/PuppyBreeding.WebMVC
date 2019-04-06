using PuppyBreeding.Data;
using PuppyBreeding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Services
{
    public class MotherService
    {
        private readonly Guid _userId;

        public MotherService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateMother(MotherCreate model)
        {
            var entity =
                new Mother()
                {
                   MotherName = model.MotherName,
                   MotherAge = model.MotherAge,
                   MotherWeight = model.MotherWeight
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Mothers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MotherListItem> GetMothers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Mothers
                        .Select(
                            e =>
                                new MotherListItem
                                {
                                    MotherId = e.MotherId,
                                    MotherName = e.MotherName,
                                    MotherWeight = e.MotherWeight,
                                    MotherAge = e.MotherAge
                                }
                        );

                return query.ToArray();
            }
        }
        public MotherDetail GetMotherById(int motherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Mothers
                        .Single(e => e.MotherId == motherId);
                return
                    new MotherDetail
                    {
                        MotherId = entity.MotherId,
                        MotherName = entity.MotherName,
                        MotherWeight = entity.MotherWeight,
                        MotherAge = entity.MotherAge
                    };
            }
        }
        public bool UpdateMother(MotherEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Mothers
                        .Single(e => e.MotherId == model.MotherId);

                entity.MotherName = model.MotherName;
                entity.MotherWeight = model.MotherWeight;
                entity.MotherAge = model.MotherAge;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteMother(int motherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Mothers
                        .Single(e => e.MotherId == motherId);

                ctx.Mothers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
