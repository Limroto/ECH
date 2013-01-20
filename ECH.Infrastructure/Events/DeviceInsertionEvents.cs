using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ECH.Infrastructure.Implementation;
using Microsoft.Practices.Prism.Events;

namespace ECH.Infrastructure.Events
{
    public class DeviceInsertionEvents : NativeWindow
    {
        private readonly IEventAggregator _eventAggregator;

        // Contains information about a logical volume.
        [StructLayout(LayoutKind.Sequential)]
        public struct DEV_BROADCAST_STK500
        {
            public int dbcv_size;			// size of the struct
            public int dbcv_devicetype;		// DBT_DEVTYP_VOLUME
            public int dbcv_reserved;		// reserved; do not use
            public int dbcv_unitmask;		// Bit 0=A, bit 1=B, and so on (bitmask)
            public short dbcv_flags;		// DBTF_MEDIA=0x01, DBTF_NET=0x02 (bitmask)
        }

        private const int WM_DEVICECHANGE = 0x0219;				// device state change
        private const int DBT_DEVICEARRIVAL = 0x8000;			// detected a new device
        private const int DBT_DEVICEQUERYREMOVE = 0x8001;		// preparing to remove
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;	// removed 
        private const int DBT_DEVTYP_COMSERIAL = 0x00000003;    // Port device

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if ((message.Msg == WM_DEVICECHANGE) && (message.LParam != IntPtr.Zero))
            {
                DEV_BROADCAST_STK500 vol2 = (DEV_BROADCAST_STK500)Marshal.PtrToStructure(
                    message.LParam, typeof(DEV_BROADCAST_STK500));

                if (vol2.dbcv_devicetype == DBT_DEVTYP_COMSERIAL)
                {
                    switch (message.WParam.ToInt32())
                    {
                        case DBT_DEVICEARRIVAL:
                            SignalDeviceChange(StkStateChange.Added, vol2);
                            break;

                        case DBT_DEVICEREMOVECOMPLETE:
                            SignalDeviceChange(StkStateChange.Removed, vol2);
                            break;
                    }
                }
            }
        }

        private void SignalDeviceChange(StkStateChange state, DEV_BROADCAST_STK500 volume)
        {
            string name = ToUnitName(volume.dbcv_unitmask);

            var board = new StkBoard(name, volume.dbcv_devicetype, state);

            _eventAggregator.GetEvent<STKConnectionEvent>().Publish(board);
        }


        /// <summary>
        /// Translate the dbcv_unitmask bitmask to a drive letter by finding the first
        /// enabled low-order bit; its offset equals the letter where offset 0 is 'A'.
        /// </summary>
        /// <param name="mask"></param>
        /// <returns></returns>

        private string ToUnitName(int mask)
        {
            int offset = 0;
            while ((offset < 26) && ((mask & 0x00000001) == 0))
            {
                mask = mask >> 1;
                offset++;
            }

            if (offset < 26)
            {
                return String.Format("{0}:", Convert.ToChar(Convert.ToInt32('A') + offset));
            }

            return "?:";
        }

        public DeviceInsertionEvents(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            // create a generic window with no class name
            base.CreateHandle(new CreateParams());
        }

        public void Dispose()
        {
            base.DestroyHandle();
            GC.SuppressFinalize(this);
        }


        public event UsbStateChangedEventHandler StateChanged;
    }
}