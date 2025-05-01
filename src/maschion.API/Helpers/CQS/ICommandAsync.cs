namespace maschion.API.Helpers.CQS;

public interface ICommandAsync<T> where T : ICommand
{
    Task HandleAsync(T command);
}

