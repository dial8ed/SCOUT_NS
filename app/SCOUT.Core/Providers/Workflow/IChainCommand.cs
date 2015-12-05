namespace SCOUT.Core.Providers.Workflow
{
    public interface IChainCommand : ICommand
    {
        void SetSuccessor(IChainCommand command);

    }
}