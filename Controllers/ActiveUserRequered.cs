

using App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


// [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
// public class ActiveUserRequiredAttribute : AuthorizeAttribute {

//     public ActiveUserRequiredAttribute(HttpContext httpContext) {
//           Console.WriteLine("CustomAuthorizeAttribute...");
//           var user = httpContext.Request.Headers["User"];
//           Console.WriteLine("CustomAuthorizeAttribute", user);

//           if (httpContext.Request.Headers.TryGetValue("User", out var username))
//           {
        
//           }
//           //httpContext.result new ForbidResult();
//     }

    //     protected override bool AuthorizeCore(HttpContext httpContext)
    // {
    //     var userService = httpContext.RequestServices.GetService<IUserService>();
    //    return true;
    //    // var currentUser = userService.GetUser(httpContext.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value);
    //     //return currentUser.IsActive && currentUser.HasPermissionToUpdateUsers;
    // }

    // protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    // {
    //     filterContext.Result = new HttpUnauthorizedResult("User is not authorized to update users");
    // }
    
//}


// public class ActiveUserRequiredAttribute : Attribute
// {

// }

// public class ActiveUserRequiredAttribute : AuthorizeAttribute
// {
//     protected override bool AuthorizeCore(HttpContext context)
//     {
//         var userService = context.RequestServices.GetService<IUserService>();
//         var currentUser = userService.GetUser(context.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value);
//         return true; //currentUser.IsActive;
//     }

//     protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
//     {
//         filterContext.Result = new HttpUnauthorizedResult("User is not active");
//     }
// }