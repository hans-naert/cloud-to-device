using Microsoft.Azure.Devices;
using System.Text;

ServiceClient serviceClient;
string connectionString = "HostName=YourIoTHubNameHN.azure-devices.net;SharedAccessKeyName=service;SharedAccessKey=FglCwvqHJlDhCQcoQbiVsHt9fM2Ed7f9owwBFXat/1U=";
string targetDevice = "TC74";

async Task SendCloudToDeviceMessageAsync()
{
     var commandMessage = new
      Message(Encoding.ASCII.GetBytes("Cloud to device message."));
     await serviceClient.SendAsync(targetDevice, commandMessage);
}

Console.WriteLine("Send Cloud-to-Device message\n");
serviceClient = ServiceClient.CreateFromConnectionString(connectionString);

Console.WriteLine("Press any key to send a C2D message.");
Console.ReadLine();
SendCloudToDeviceMessageAsync().Wait();
Console.ReadLine();