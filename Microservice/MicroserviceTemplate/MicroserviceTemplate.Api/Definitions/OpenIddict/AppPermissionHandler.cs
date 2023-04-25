﻿using System.Security.Claims;
using Calabonga.Microservice.Module.Web.Definitions.OpenIddict;
using MicroserviceTemplate.Base.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace MicroserviceTemplate.Api.Definitions.OpenIddict;

/// <summary>
/// Permission handler for custom authorization implementations
/// </summary>
public class AppPermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    /// <inheritdoc />
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        if (context.User.Identity is null)
        {
            return Task.CompletedTask;
        }

        var identity = (ClaimsIdentity)context.User.Identity;
        var claim = ClaimsHelper.GetValue<string>(identity, requirement.PermissionName);
        if (claim == null)
        {
            return Task.CompletedTask;
        }

        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}