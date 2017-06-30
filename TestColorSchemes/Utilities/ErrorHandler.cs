using DllColorSchemes.ErrorHandlingService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TestColorSchemes.Utilities
{
	/// <summary>
	/// Provide a central point for logging all exceptions.
	/// </summary>
	public static class ErrorHandler
	{
		#region Private fields

		private static readonly object _LockObject = new object();
		private static ResourceManager _RM = new ResourceManager("DllColorSchemes.Properties.Resources",
											typeof(ErrorHandler).Assembly);
		#endregion

		#region Public Log Error method
		/// <summary>
		/// Call a WCF service to log the given exception.
		/// </summary>
		/// <param name="ex">Exception to log</param>
		/// <returns>Generalized user-friendly error message</returns>
		public static string Log(Exception ex)
		{
			string result = _RM.GetString("DefaultErrorMessage");

			try
			{
				// If the error service is available...
				if (CheckService())
				{
					// Set targetSite with the method that caught the exception.
					MethodBase mb = ex.TargetSite;
					string targetSite = null;
					if (mb != null)
						targetSite = mb.ToString();

					lock (_LockObject)
					{
						// Prepare to use the error logging service.
						using (LocalErrorServiceClient errorService = new LocalErrorServiceClient())
						{
							// Use a memory stream to pass the exception data.
							using (MemoryStream ms = new MemoryStream())
							{
								BinaryFormatter bf = new BinaryFormatter();
								bf.Serialize(ms, ex);

								// Log the error and grab the returned generalized error message.
								result = errorService.Add(DateTime.Now, Assembly.GetExecutingAssembly().GetName().Name,
										 targetSite, ms.ToArray());
							}
						}
					}
				}
				return result;
			}
			catch (Exception)
			{
				return result;
			}
		}
		#endregion

		#region Private Method to see if error service is available
		/// <summary>
		/// See if the error logging service is available.
		/// </summary>
		/// <returns>True if service available.</returns>
		public static bool CheckService()
		{
			bool _ReturnCode = false;

			try
			{
				lock (_LockObject)
				{
					using (LocalErrorServiceClient errorService = new LocalErrorServiceClient())
					{
						_ReturnCode = errorService.ServiceAvail();
					}
				}
			}
			catch (Exception)
			{
				return _ReturnCode;
			}
			return _ReturnCode;
		}
		#endregion

	}
}
