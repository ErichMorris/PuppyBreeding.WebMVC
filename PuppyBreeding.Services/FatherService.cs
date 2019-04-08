using PuppyBreeding.Data;
using PuppyBreeding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Services
{
    public class FatherService
    {
        private readonly Guid _userId;

        public FatherService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateFather(FatherCreate model)
        {
            var entity =
                new Father()
                {
                    FatherName = model.FatherName,
                    FatherWeight = model.FatherWeight,
                    FatherAge = model.FatherAge
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Fathers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<FatherListItem> GetFathers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Fathers
                        .Select(
                            e =>
                                new FatherListItem
                                {
                                    FatherId = e.FatherId,
                                    FatherName = e.FatherName,
                                    FatherWeight = e.FatherWeight,
                                    FatherAge = e.FatherAge
                                }
                        );

                return query.ToArray();
            }
        }
        public FatherDetail GetFatherById(int fatherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Fathers
                        .Single(e => e.FatherId == fatherId);
                return
                    new FatherDetail
                    {
                        FatherId = entity.FatherId,
                        FatherName = entity.FatherName,
                        FatherWeight = entity.FatherWeight,
                        FatherAge = entity.FatherAge
                    };
            }
        }
        public bool UpdateFather(FatherEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Fathers
                        .Single(e => e.FatherId == model.FatherId);

                entity.FatherName = model.FatherName;
                entity.FatherAge = model.FatherAge;
                entity.FatherWeight = model.FatherWeight;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteFather(int fatherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Fathers
                        .Single(e => e.FatherId == fatherId);

                ctx.Fathers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
