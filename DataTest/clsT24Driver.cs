using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataTest
{
    public class clsT24Driver
    {
        //This section will handle communications with the T24 DLL

        [DllImport("t24drv.dll")]
        public static extern Single VERSION();

        [DllImport("t24drv.dll")]
        public static extern void INITIALISE(ref long iCallBackAddress);

        [DllImport("t24drv.dll")]
        public static extern int OPENPORT(int ComPort, long Baudrate);

        [DllImport("t24drv.dll")]
        public static extern int CLOSEPORT();

        [DllImport("t24drv.dll")]
        public static extern int OPENUSB();

        [DllImport("t24drv.dll")]
        public static extern void ENUMUSB();

        [DllImport("t24drv.dll")]
        public static extern int BIND(byte BaseStation, byte UseRemoteSettings, byte ConfigMode, byte Duration, ref long ID, ref long DataTag);

        [DllImport("t24drv.dll")]
        public static extern int BINDASYNC(byte BaseStation, byte UseRemoteSettings, byte ConfigMode, byte Duration);

        [DllImport("t24drv.dll")]
        public static extern int BINDASYNCPOLL(ref long ID, ref long DataTag);

        [DllImport("t24drv.dll")]
        public static extern int READREMOTE(byte BaseStation, long ID, byte Command, ref byte sData, ref long Length, ref int RSSI, ref int CV, ref int Flags);

        [DllImport("t24drv.dll")]
        public static extern int WRITEREMOTE(byte BaseStation, long ID, byte Command, ref byte sData, long Length, ref int RSSI, ref int CV, ref int flags);

        [DllImport("t24drv.dll")]
        public static extern int WRITEPACKET(byte BaseStation, ref byte sData, long Length);

        
        public delegate void processInBoundDataCallbackDelegate(ref long StringPtr, long Length); //to hold a function pointer to our callback


        public Single getVersion()
        {
            return VERSION();
        }

        public void initializeDriver()
        {
            processInBoundDataCallbackDelegate callBackHandler = new processInBoundDataCallbackDelegate(processInBoundDataCallback);

            long pointer;

            pointer = (long)Marshal.GetFunctionPointerForDelegate(callBackHandler);

            INITIALISE(ref pointer);//we must pass in the pointer of the processInBoundDataCallback function here
        }

        public int openUSB()
        {
            return OPENUSB();
        }

        public static void processInBoundDataCallback(ref long StringPtr, long Length)
        {
            Console.WriteLine("data recieved from pointer " + StringPtr + " data length: " + Length);


           


        }


        public void processInBoundData()
        {

        }









    }
}
