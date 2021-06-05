using System.Threading.Tasks;

namespace Albergue.Administrator.HostedServices.Hub
{
    public interface ILocalesStatusHub
    {
        Task SendMessageAsync(string message);
        Task SendMessageToCallerAsync(string message);
        Task SendMessageToGroupAsync(string groupName, string message);
    }
}