namespace BtcAlarm.Global.Auth
{
    using BtcAlarm.Model;

    public interface IUserProvider
    {
        User User { get; set; }
    }
}
