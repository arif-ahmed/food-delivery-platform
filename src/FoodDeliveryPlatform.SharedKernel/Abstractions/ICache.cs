namespace FoodDeliveryPlatform.SharedKernel.Abstractions
{
    public interface ICache
    {
        /// <summary>
        /// Gets a cached value by key. Returns default(T) if not found.
        /// </summary>
        Task<T?> GetAsync<T>(string key, CancellationToken ct = default);

        /// <summary>
        /// Sets a cached value by key with optional expirations.
        /// </summary>
        Task SetAsync<T>(
            string key,
            T value,
            TimeSpan? absoluteExpirationRelativeToNow = null,
            TimeSpan? slidingExpiration = null,
            CancellationToken ct = default);

        /// <summary>
        /// Returns true if the key exists in cache.
        /// </summary>
        Task<bool> ExistsAsync(string key, CancellationToken ct = default);

        /// <summary>
        /// Removes a cached entry by key.
        /// </summary>
        Task RemoveAsync(string key, CancellationToken ct = default);

        /// <summary>
        /// Removes multiple cached entries by keys.
        /// </summary>
        Task RemoveManyAsync(IEnumerable<string> keys, CancellationToken ct = default);

        /// <summary>
        /// Clears the cache (may be unsupported depending on the provider).
        /// </summary>
        Task ClearAsync(CancellationToken ct = default);

        /// <summary>
        /// Gets a value from cache, or creates + stores it atomically-ish.
        /// The factory is only called when the value is missing.
        /// </summary>
        Task<T> GetOrCreateAsync<T>(
            string key,
            Func<CancellationToken, Task<T>> factory,
            TimeSpan? absoluteExpirationRelativeToNow = null,
            TimeSpan? slidingExpiration = null,
            CancellationToken ct = default);

        /// <summary>
        /// Attempts to get a value from cache.
        /// </summary>
        Task<(bool Found, T? Value)> TryGetAsync<T>(string key, CancellationToken ct = default);

        /// <summary>
        /// Refreshes a key (useful for sliding expirations; no-op if unsupported).
        /// </summary>
        Task RefreshAsync(string key, CancellationToken ct = default);
    }
}
