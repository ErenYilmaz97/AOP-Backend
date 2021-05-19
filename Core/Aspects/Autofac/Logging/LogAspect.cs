using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.Utilities.Interceptors;
using Core.Utilities.IOC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private ILog _loggerServiceBase;

        public LogAspect(Type loggerService)
        {
            if (!typeof(ILog).IsAssignableFrom(loggerService))
            {
                throw new System.Exception("Bu Bir Logger Değil");
            }

            _loggerServiceBase = (ILog)Activator.CreateInstance(loggerService);

        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _loggerServiceBase.Info(GetLogDetail(invocation));
        }



        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.ReflectedType.FullName + invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetail;
        }
    }
}