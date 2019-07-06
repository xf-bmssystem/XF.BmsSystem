﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClownFish.Base.Framework
{
	/// <summary>
	/// 当前应用程序的运行时环境
	/// </summary>
	public static class RunTimeEnvironment
	{
		/// <summary>
		/// 当前运行的程序是不是ASP.NET程序
		/// </summary>
		public static readonly bool IsAspnetApp = (HttpRuntime.AppDomainAppId != null);


		/// <summary>
		/// 当前程序是否以DEBUG模式运行
		/// </summary>
		public static readonly bool IsDebugMode = WebConfig.IsDebugMode;


		private static Assembly[] GetLoadAssemblies()
		{
			if( IsAspnetApp ) {
				System.Collections.ICollection collection = System.Web.Compilation.BuildManager.GetReferencedAssemblies();
				return (from a in collection.Cast<Assembly>() select a).ToArray();
			}
			else
				return System.AppDomain.CurrentDomain.GetAssemblies();
		}

		/// <summary>
		/// 获取当前程序加载的所有程序集
		/// </summary>
		/// <param name="ignoreSystemAssembly">是否忽略以System开头和动态程序集，通常用于反射时不搜索它们。</param>
		/// <returns></returns>
		public static Assembly[] GetLoadAssemblies(bool ignoreSystemAssembly = false)
		{
			Assembly[] assemblies = GetLoadAssemblies();
			if( ignoreSystemAssembly == false )
				return assemblies;
			


			// 过滤一些反射中几乎用不到的程序集
			List<Assembly> list = new List<Assembly>(128);

			foreach( Assembly assembly in assemblies ) {
				if( assembly.IsDynamic )    // 动态程序通常是不需要参考的
					continue;

				// 过滤以【System】开头的程序集，加快速度
				if( assembly.FullName.StartsWith("System", StringComparison.OrdinalIgnoreCase) )
					continue;

				list.Add(assembly);
			}
			return list.ToArray();
		}
	}
}
