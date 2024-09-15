using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using InTheHand.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//namespace _2ndAttemptMedium
//{
    //internal class Program
    public class Program
    {
    //Add public to the below    
    public static void Main(string[] args)
        {
            // Create the Bluetooth client
            BluetoothClient client = new BluetoothClient();

            // Discover devices in range
            BluetoothDeviceInfo[] devices = client.DiscoverDevicesInRange();
            //BluetoothDeviceInfo bluetoothDevices = client.DiscoverDevices();
            //BluetoothDeviceInfo[] devices = client.DiscoverDevices();

            // If no devices were found, terminate the program
            if (devices.Length == 0)
            {
                Console.WriteLine("No devices found. Exiting...");
                return;
            }

            // Choose the first device
            BluetoothDeviceInfo device = devices[0];

            // Create the Bluetooth end point
            BluetoothEndPoint endPoint = new BluetoothEndPoint(device.DeviceAddress, BluetoothService.SerialPort);

            try
            {
                // Connect to the device
                client.Connect(endPoint);

                // Get the stream
                Stream stream = client.GetStream();

                // Your message to send
                string message = "Hello, Bluetooth!";

                // Convert your message to byte array
                byte[] messageBuffer = Encoding.ASCII.GetBytes(message);

                // Write the data to the stream
                stream.Write(messageBuffer, 0, messageBuffer.Length);

                // Close the stream
                stream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the client
                client.Close();
            }
        }
    }
    
//}
