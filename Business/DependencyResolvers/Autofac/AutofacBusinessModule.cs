using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule: Module
	{
		override protected void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
			builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

			builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
			builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

			builder.RegisterType<ProductImageManager>().As<IProductImageService>().SingleInstance();
			builder.RegisterType<EfProductImageDal>().As<IProductImageDal>().SingleInstance();


			var assembly = System.Reflection.Assembly.GetExecutingAssembly();

			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
				.EnableInterfaceInterceptors(new ProxyGenerationOptions()
				{
					Selector = new AspectInterceptorSelector()
				}).SingleInstance();
		}
	}
}
