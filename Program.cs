using Microsoft.Azure.Devices;
using System.Text;

ServiceClient serviceClient;
string connectionString = "HostName=IoT-hub-HN-2023.azure-devices.net;SharedAccessKeyName=service;SharedAccessKey=fp1DS3bTW5QEzrOYjRpS/B8rHGVF+E7HzAIoTN31gU0=";
string targetDevice = "rpi-hn-home";

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
