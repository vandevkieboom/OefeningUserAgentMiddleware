namespace OefeningUserAgentMiddleware
{
    public static class UserAgentMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserAgentMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserAgentMiddleware>();
        }
    }
}
