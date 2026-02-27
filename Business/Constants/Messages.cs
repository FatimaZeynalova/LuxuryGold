using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
	public static class Messages
	{
		public static string ProductAdded = "Product added successfully.";
		public static string ProductNameInvalid = "Product name is invalid.";
		public static string ProductListed = "Products listed successfully.";
		public static string ProductDeleted = "Product deleted successfully.";
		public static string ProductUpdated = "Product updated successfully.";
		public static string CategoryAdded = "Category added successfully.";
		public static string CategoryDeleted = "Category deleted successfully.";
		public static string CategoryUpdated = "Category updated successfully.";
		public static string MaintenanceTime = "System is under maintenance. Please try again later.";

		public static string ProductPriceInvalid = "Product price must be greater than zero.";
		public static string ProductCountOfCategoryError = "There can only be 10 products in a category.";
		public static string ProductNameAlreadyExists="Product name is already exists.";
		internal static string CategoryLimitExceded= "You cannot add a new product to the category because you have exceeded the limit.";

		public static string? AuthorizationDenied { get; internal set; }
	}
}
