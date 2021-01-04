using System.Threading.Tasks;
using Fluentbot.ChatService.Contracts;
using Oakton;

namespace Fluentbot.ChatService.Commands
{
    public class StartCommand : OaktonAsyncCommand<StartServiceInput>
    {
        public override async Task<bool> Execute(StartServiceInput input)
        {
            throw new System.NotImplementedException();
        }
    }
}