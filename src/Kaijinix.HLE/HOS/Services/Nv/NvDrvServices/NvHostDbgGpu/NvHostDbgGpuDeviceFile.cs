using Kaijinix.Memory;

namespace Kaijinix.HLE.HOS.Services.Nv.NvDrvServices.NvHostDbgGpu
{
    class NvHostDbgGpuDeviceFile : NvDeviceFile
    {
        public NvHostDbgGpuDeviceFile(ServiceCtx context, IVirtualMemoryManager memory, ulong owner) : base(context, owner) { }

        public override void Close() { }
    }
}
