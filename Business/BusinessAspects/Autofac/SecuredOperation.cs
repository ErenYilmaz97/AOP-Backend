﻿using System;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using Castle.DynamicProxy;
using Core.Exceptions;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IOC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
        //JWT
        public class SecuredOperation : MethodInterception
        {
            private string[] _roles;
            private IHttpContextAccessor _httpContextAccessor;
            

            public SecuredOperation(string roles)
            {
                _roles = roles.Split(',');
                _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

            }

            protected override void OnBefore(IInvocation invocation)
            {
                var userEmail = _httpContextAccessor.HttpContext.User.Claims.Where(x=>x.Type == ClaimTypes.Email).FirstOrDefault()?.Value;

                if (userEmail == null)
                {
                    throw new AuthenticationException("Authentication Failure");
                }


                var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
                foreach (var role in _roles)
                {
                    if (roleClaims.Contains(role))
                    {
                        return;
                    }
                }
                throw new AuthorizationException("Authorization Failure"); 
            }

            
        }
    }
