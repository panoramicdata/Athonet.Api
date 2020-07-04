﻿using System;

namespace Athonet.Api.Exceptions
{
	public class ConfigurationException : Exception
	{
		public ConfigurationException() : base()
		{
		}

		public ConfigurationException(string message) : base(message)
		{
		}

		public ConfigurationException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
