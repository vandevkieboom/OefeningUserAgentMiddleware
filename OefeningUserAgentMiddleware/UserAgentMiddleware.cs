namespace OefeningUserAgentMiddleware
{
    public class UserAgentMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<UserAgentMiddleware> _logger;

        public UserAgentMiddleware(RequestDelegate next, ILogger<UserAgentMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userAgent = context.Request.Headers["User-Agent"].FirstOrDefault();

            if (string.IsNullOrEmpty(userAgent))
            {
                userAgent = "Unknown User-Agent";
            }

            _logger.LogInformation("User-Agent: {UserAgent}", userAgent);

            context.Response.OnStarting(() =>
            {
                context.Response.Headers.TryAdd("X-User-Agent", userAgent);
                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}
