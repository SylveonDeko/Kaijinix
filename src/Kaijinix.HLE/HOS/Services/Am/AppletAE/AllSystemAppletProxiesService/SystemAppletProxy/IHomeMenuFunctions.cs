using Kaijinix.Common.Logging;
using Kaijinix.HLE.HOS.Ipc;
using Kaijinix.HLE.HOS.Kernel.Threading;
using Kaijinix.Horizon.Common;
using System;

namespace Kaijinix.HLE.HOS.Services.Am.AppletAE.AllSystemAppletProxiesService.SystemAppletProxy
{
    class IHomeMenuFunctions : IpcService
    {
        private readonly KEvent _channelEvent;
        private int _channelEventHandle;

        public IHomeMenuFunctions(Horizon system)
        {
            // TODO: Signal this Event somewhere in future.
            _channelEvent = new KEvent(system.KernelContext);
        }

        [CommandCmif(10)]
        // RequestToGetForeground()
        public ResultCode RequestToGetForeground(ServiceCtx context)
        {
            Logger.Stub?.PrintStub(LogClass.ServiceAm);

            return ResultCode.Success;
        }

        [CommandCmif(21)]
        // GetPopFromGeneralChannelEvent() -> handle<copy>
        public ResultCode GetPopFromGeneralChannelEvent(ServiceCtx context)
        {
            if (_channelEventHandle == 0)
            {
                if (context.Process.HandleTable.GenerateHandle(_channelEvent.ReadableEvent, out _channelEventHandle) != Result.Success)
                {
                    throw new InvalidOperationException("Out of handles!");
                }
            }

            context.Response.HandleDesc = IpcHandleDesc.MakeCopy(_channelEventHandle);

            Logger.Stub?.PrintStub(LogClass.ServiceAm);

            return ResultCode.Success;
        }
    }
}
