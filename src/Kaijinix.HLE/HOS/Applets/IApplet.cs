using Kaijinix.HLE.HOS.Services.Am.AppletAE;
using Kaijinix.HLE.UI;
using Kaijinix.Memory;
using System;
using System.Runtime.InteropServices;

namespace Kaijinix.HLE.HOS.Applets
{
    interface IApplet
    {
        event EventHandler AppletStateChanged;

        ResultCode Start(AppletSession normalSession,
                         AppletSession interactiveSession);

        ResultCode GetResult();

        bool DrawTo(RenderingSurfaceInfo surfaceInfo, IVirtualMemoryManager destination, ulong position)
        {
            return false;
        }

        static T ReadStruct<T>(ReadOnlySpan<byte> data) where T : unmanaged
        {
            return MemoryMarshal.Cast<byte, T>(data)[0];
        }
    }
}
