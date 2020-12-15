using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NpgSqlTests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var db = new DatabaseContext())
            {
                var id = await addFirst();

                var first = await db.TestModels.SingleAsync(x => x.Id == id);
                first.PropFour.Add(1234);
            }
        }

        static async Task<Guid> addFirst()
        {
            using var db = new DatabaseContext();
            var newModel = new TestModel();
            db.TestModels.Add(newModel);
            await db.SaveChangesAsync();
            return newModel.Id;
        }
    }
}
