using Business.Constants;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.IoC;
using Core.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
	//JWT (JSON Web Token) is a compact, URL-safe means of representing claims to be transferred between two parties.
	//The claims in a JWT are encoded as a JSON object that is used as the payload of a JSON Web Signature (JWS) structure or as the plaintext of a JSON Web Encryption (JWE) structure, enabling the claims to be digitally signed or integrity protected with a Message Authentication Code (MAC) and/or encrypted.
	// </summary>
	public class SecuredOperation : MethodInterception
	{
		private string[] _roles;
		private IHttpContextAccessor _httpContextAccessor;

		public SecuredOperation(string roles)
		{
			_roles = roles.Split(',');  //Admin,Editor,User -> [Admin,Editor,User]
			_httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();



		}

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
