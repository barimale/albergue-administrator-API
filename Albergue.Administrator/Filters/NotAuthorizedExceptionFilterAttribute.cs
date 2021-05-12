using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Albergue.Administrator.Filters
{
    public class NotAuthorizedExceptionFilterAttribute: ExceptionFilterAttribute
    {
        private readonly ILogger<NotAuthorizedExceptionFilterAttribute> _logger;

        public NotAuthorizedExceptionFilterAttribute(ILogger<NotAuthorizedExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            _logger.LogError("Bad request", context.Exception);
        }
    }
}
