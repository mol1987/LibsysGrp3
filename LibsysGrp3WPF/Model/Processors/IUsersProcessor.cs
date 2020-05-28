using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public interface IUsersProcessor
    {
        public ILibsysRepo _repo { get; set; }
        IUsers LoginUsersProcess(string IdentityNo, string Password);
        public void AddUserProcess(IUsers user);
        public void RemoveUserProcess(IUsers user);
        public void EditUserProcess(IUsers user);
        public void CheckInItemProcess(IStockWithBorrow stock);
    }
}