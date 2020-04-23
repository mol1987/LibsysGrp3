using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public interface IVisitorsProcessor
    {
        IVisitors LoginVisitor(string IdentityNo, string Password);
    }
}