using MediatR;
using Shared.Abstractions.Caching;

namespace Shared.Cache;

public abstract class StreamCacheRequest<TRequest, TResponse> : IStreamCacheRequest<TRequest, TResponse>
    where TRequest : IStreamRequest<TResponse>
{
    public virtual TimeSpan AbsoluteExpirationRelativeToNow => TimeSpan.FromMinutes(5);

    // public virtual TimeSpan SlidingExpiration => TimeSpan.FromSeconds(30);
    // public virtual DateTime? AbsoluteExpiration => null;
    public virtual string Prefix => "Ch_";

    public virtual string CacheKey(TRequest request) => $"{Prefix}{typeof(TRequest).Name}";
}
