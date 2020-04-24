using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public interface IUsersProcessor
    {
        IUsers LoginUsersProcess(string IdentityNo, string Password);
        public ILibsysRepo _repo { get; set; }
    }
}