using System;
using System.Threading.Tasks;
using UtilLibrary.MsSqlRepsoitory;

namespace ConsoleUITest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("running ");
            LibsysRepo repo = LibsysRepo.GetInstance();
            var visitor = new Visitor { Password = "hej", Firstname = "test", Lastname = "pest", IdentityNo = "198704012222" };
            //repo.AddNewVisitor(visitor);
            Console.WriteLine("visitor id: " + visitor.VisitorsID);
        }
    }
}
