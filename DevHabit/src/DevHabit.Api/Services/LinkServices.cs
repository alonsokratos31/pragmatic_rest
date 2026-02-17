using DevHabit.Api.DTOs.Common;

namespace DevHabit.Api.Services;

public class LinkServices(LinkGenerator linkGenerator, IHttpContextAccessor httpContextAccessor)
{
    public LinkDto Create(string endPointName, string rel, string method, object? value = null, string? controller = null)
    { 
        string? href = linkGenerator.GetUriByAction(httpContextAccessor.HttpContext!, endPointName, controller, value);

            return new LinkDto { 
            Href = href! ?? throw new Exception("Invalid endpoint name provider"),
            Rel = rel,
            Method = method
            };
    }

}
