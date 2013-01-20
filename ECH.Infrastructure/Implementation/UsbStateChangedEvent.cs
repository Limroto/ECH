using System;

namespace ECH.Infrastructure.Implementation
{
    public class UsbStateChangedEventArgs : EventArgs
    {

        /// <summary>
        /// Initialize a new instance with the specified state and disk.
        /// </summary>
        /// <param name="state">The state change code.</param>
        /// <param name="disk">The USB disk description.</param>
        public UsbStateChangedEventArgs(StkStateChange state, StkBoard disk)
        {
            State = state;
            Disk = disk;
        }


        /// <summary>
        /// Gets the STK board's information.
        /// </summary>
        public StkBoard Disk
        {
            get;
            private set;
        }


        /// <summary>
        /// Gets the state change code.
        /// </summary>
        public StkStateChange State
        {
            get;
            private set;
        }
    }
}