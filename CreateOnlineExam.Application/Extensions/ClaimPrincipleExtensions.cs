using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CreateOnlineExam.Application.Extensions
{
   public static class ClaimPrincipleExtensions
    {
        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
