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
                //Add a new empty record to the database.
                var id = await addFirst();

                //Fetch the record
                var thing = await db.TestModels.SingleAsync(x => x.Id == id);
                
                //Add a new string to the List
                thing.PropFour.Add(1234);

                Console.WriteLine($"The one we modified: {thing.PropFour.First()}. These shouldn't return anything but do: {thing.PropTwo.First()} {thing.PropThree.First()}");

                Console.WriteLine($"Lists of different type are unaffected: {thing.PropOne.FirstOrDefault()}");
            }
        }

        static async Task<Guid> addFirst()
        {
            using var db = new DatabaseContext();
            var newRec = new TestModel();
            db.TestModels.Add(newRec);
            await db.SaveChangesAsync();
            return newRec.Id;
        }
    }
}
