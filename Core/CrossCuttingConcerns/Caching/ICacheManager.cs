using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
	public interface ICacheManager
	{
		T Get<T>(string key);
		object Get(string key);
		void Add(string key, object value, int duration);//duration is a time 
		bool IsAdd(string key); //Is the data cached or not?
		void Remove(string key); //Removing data by key
		void RemoveByPattern(string pattern); //Removing data by pattern




	}
}
