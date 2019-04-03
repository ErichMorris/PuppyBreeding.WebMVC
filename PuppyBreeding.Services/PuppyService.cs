using PuppyBreeding.Data;
using PuppyBreeding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyBreeding.Services
{
    public class PuppyService
    {
        private readonly Guid _userId;
        public PuppyService (Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePuppy(PuppyCreate model)
        {
            var entity =
                new Puppy()
                {
                    PuppyName = model.PuppyName,
                    Weight = model.Weight,
                    Age = model.Age,
                    Gender = model.Gender,
                    Price = model.Price 
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Puppies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PuppyListItem> GetPuppies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Puppies
                        .Select(
                            e =>
                                new PuppyListItem
                                {
                                    PuppyId = e.PuppyId,
                                    PuppyName = e.PuppyName,
                                    Weight = e.Weight,
                                    Age = e.Age,
                                    Gender = e.Gender,
                                    Price = e.Price
                                }
                        );

                return query.ToArray();
            }
        }
        public PuppyDetail GetPuppyById(int puppyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Puppies
                        .Single(e => e.PuppyId == puppyId);
                return
                    new PuppyDetail
                    {
                        PuppyId = entity.PuppyId,
                        PuppyName = entity.PuppyName,
                        Weight = entity.Weight,
                        Age = entity.Age,
                        Gender = entity.Gender,
                        Price = entity.Price
                    };
            }
        }
    }
}
