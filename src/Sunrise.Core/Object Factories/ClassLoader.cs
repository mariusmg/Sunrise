/*

	file : ClassLoader.cs
description: A mini IOC system used to attach dependencies to a entity at runtime
	author: Marius Gheorghe


*/

using System;
using System.Reflection;

namespace voidsoft.Sunrise.Core
{
	/// <summary>
	/// ClassLoader
	/// </summary>
	public class ClassLoader
	{
		private Assembly asm;

		/// <summary>
		/// 
		/// </summary>
		private ClassLoader()
		{
		}

		/// <summary>
		/// Creates a new instance of ClassLoader
		/// </summary>
		/// <param name="filePath">Path to the assembly</param>
		/// <returns></returns>
		public static ClassLoader CreateClassLoader(string filePath)
		{
			try
			{
				ClassLoader loader = new ClassLoader();
				loader.asm = Assembly.LoadFrom(filePath);
				return loader;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Returns an instance of the specified type
		/// </summary>
		/// <param name="typeName">Type for which we create a new instance</param>
		/// <param name="constructorArguments">Type constructor arguments</param>
		/// <returns></returns>
		public object GetInstance(string typeName, params object[] constructorArguments)
		{
			try
			{
				Type localType = asm.GetType(typeName);

				object instance = null;

				if (constructorArguments != null && constructorArguments.Length > 0)
				{
					instance = Activator.CreateInstance(localType, constructorArguments);
				}
				else
				{
					instance = Activator.CreateInstance(localType);
				}

				return instance;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Invokes a instance method of the specified type
		/// </summary>
		/// <param name="typeName">Type which contains the method</param>
		/// <param name="methodName">Name of the method which will be invoked</param>
		/// <param name="classConstructorParameters">Type constructor arguments</param>
		/// <param name="methodParameters">Method arguments</param>
		/// <returns></returns>
		public object InvokeInstanceMethod(string typeName, string methodName, object[] classConstructorParameters, object[] methodParameters)
		{
			try
			{
				Type currentType = asm.GetType(typeName);
				object instance = Activator.CreateInstance(currentType, classConstructorParameters);
				return currentType.InvokeMember(methodName, BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, instance, methodParameters);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Invokes a static method of the specified type
		/// </summary>
		/// <param name="typeName">Type which contains the method</param>
		/// <param name="methodName">Name of the static </param>
		/// <param name="methodParameters">Method arguments</param>
		/// <returns></returns>
		public object InvokeStaticMethod(string typeName, string methodName, params object[] methodParameters)
		{
			try
			{
				Type currentType = asm.GetType(typeName);
				return currentType.InvokeMember(methodName, BindingFlags.InvokeMethod | BindingFlags.Static, null, null, methodParameters);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}