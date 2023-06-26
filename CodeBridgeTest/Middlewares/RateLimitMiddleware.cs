using System.Collections.Concurrent;

namespace CodeBridgeTest.Middlewares
{
    public class RateLimitMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RateLimitMiddleware> _logger;
        private readonly ConcurrentDictionary<string, List<DateTime>> _requestDictionary;
        private const int _maxRequests = 10;

        public RateLimitMiddleware(RequestDelegate next, ILogger<RateLimitMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _requestDictionary = new ConcurrentDictionary<string, List<DateTime>>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();
            var currentTime = DateTime.UtcNow;

            if (IsRateLimitExceeded(ipAddress, currentTime))
            {
                _logger.LogInformation($"Rate limit exceeded for IP address: {ipAddress}");
                context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                await context.Response.WriteAsync("Too many requests. Please try again later.");
                return;
            }

            await _next(context);

            _requestDictionary.AddOrUpdate(ipAddress, new List<DateTime> { currentTime }, (_, value) =>
            {
                value.Add(currentTime);
                return value;
            });
        }

        private bool IsRateLimitExceeded(string ipAddress, DateTime currentTime)
        {
            if (_requestDictionary.TryGetValue(ipAddress, out var requestTimes))
            {
                requestTimes.RemoveAll(x => (currentTime - x).TotalSeconds > 10);

                if (requestTimes.Count == 0)
                {
                    _requestDictionary.TryRemove(ipAddress, out _);
                }
                return requestTimes.Count > _maxRequests;
            }

            return false;
        }
    }
}