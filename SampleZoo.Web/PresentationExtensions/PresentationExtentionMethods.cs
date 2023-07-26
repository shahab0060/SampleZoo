using SampleZoo.Domain.ViewModels.Common;
using System.Security.Claims;

namespace SampleZoo.Web.PresentationExtensions
{
    public static class PresentationExtentionMethods
    {
        public static BaseUserIdentityInformationDto GetBaseUserIdentityInformation(this ClaimsPrincipal claimsPrincipal, HttpContext context)
           => new BaseUserIdentityInformationDto()
           {
               UserIp = context.GetUserIp(),
               UserId = claimsPrincipal.GetNullableCurrentUserId(),
           };

        public static BaseUserIdentityInformationDto GetBaseUserIdentityInformation(this ClaimsPrincipal claimsPrincipal,
            HttpContext context, Guid userIdentityKey)
          => new BaseUserIdentityInformationDto()
          {
              UserIp = context.GetUserIp(),
              UserId = claimsPrincipal.GetNullableCurrentUserId(),
              UserIdentityKey = userIdentityKey
          };
    }
}
