﻿using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extansions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        // Her JWT'den gelen istek bize HttpContext olarak gelir
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
             _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }
        // roles.Split(',') --> virgülle ayrılan her bir string bir rol diyoruz ve array'e ekliyoruz 
        // SecuredOperation bir aspecct olduğu için Constroctorda enjekte edemiyoruz  _httpContextAccessor bizim aoutofacte yapmış olduğumuz Injection değerlerini alıcak
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
