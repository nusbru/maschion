namespace maschion.API.Helpers.CQS;

public interface IQueryAsync<T, R> where T : IQuery where R : IQueryResult
{
    Task<R> HandleAsync(T query);
}

