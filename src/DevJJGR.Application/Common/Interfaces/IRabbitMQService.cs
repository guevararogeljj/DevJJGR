using System;
namespace DevJJGR.Application.Common.Interfaces
{
	public interface IRabbitMQService
	{
		void SendMessage(string message);
	}
}

