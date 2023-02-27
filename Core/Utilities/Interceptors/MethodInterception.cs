using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            //Projedeki bütün metotlar bu try catchden geçiyor yani her yere try catch yazma gereksimini duymuyorum.
            //Benim bütün metodlarım direkt çalışmayacak burada ki kurallardan geçicek bunuda aop sayesinde yapıyoruz
            //Aspectte Yukadrıdaki metotların hangisinin içini doldurursan metodun içinde o kısım çalısır 
            var isSuccess = true;
            OnBefore(invocation); //Metotdun başı
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);//Hata aldığında
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);//Başarılı olduğu
                }
            }
            OnAfter(invocation);//Metodun sonunda
        }
    }

}
