using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public interface IVisitorsProcessor
    {
        IVisitors LoginVisitorProcess(string IdentityNo, string Password);
    }
}