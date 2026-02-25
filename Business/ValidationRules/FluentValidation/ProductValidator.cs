using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class ProductValidator:AbstractValidator<Product>
	{

		public ProductValidator()
		{
			RuleFor(p=>p.Name).NotEmpty();
			RuleFor(p => p.Name).MinimumLength(2);
			RuleFor(p => p.Price).GreaterThan(0);
			RuleFor(p => p.Price).NotEmpty();
			RuleFor(p => p.StockQuantity).GreaterThanOrEqualTo(0);
			RuleFor(p => p.Name).Must(StartWithA).WithMessage("Products must start with A.");
			//Spacial rule for product name, it must start with A.
			//You can create any rule you want with Must method.

		}

		private bool StartWithA(string arg)
		{
			return arg.StartsWith("A");
		}
	}
}
