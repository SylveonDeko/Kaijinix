using System.Runtime.InteropServices;

namespace Kaijinix.HLE.HOS.Services.Nv.NvDrvServices.NvMap
{
    [StructLayout(LayoutKind.Sequential)]
    struct NvMapFromId
    {
        public int Id;
        public int Handle;
    }
}
