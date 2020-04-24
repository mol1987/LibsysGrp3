using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public interface IVisitorsProcessor
    {
        IVisitors LoginUsersProcess(string IdentityNo, string Password);
    }
}