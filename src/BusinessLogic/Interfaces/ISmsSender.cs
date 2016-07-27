using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
