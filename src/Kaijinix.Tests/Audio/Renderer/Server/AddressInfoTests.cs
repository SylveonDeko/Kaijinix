using NUnit.Framework;
using Kaijinix.Audio.Renderer.Server.MemoryPool;
using System;
using System.Runtime.CompilerServices;

namespace Kaijinix.Tests.Audio.Renderer.Server
{
    class AddressInfoTests
    {
        [Test]
        public void EnsureTypeSize()
        {
            Assert.AreEqual(0x20, Unsafe.SizeOf<AddressInfo>());
        }

        [Test]
        public void TestGetReference()
        {
            MemoryPoolState[] memoryPoolState = new MemoryPoolState[1];
            memoryPoolState[0] = MemoryPoolState.Create(MemoryPoolState.LocationType.Cpu);
            memoryPoolState[0].SetCpuAddress(0x1000000, 0x10000);
            memoryPoolState[0].DspAddress = 0x4000000;

            AddressInfo addressInfo = AddressInfo.Create(0x1000000, 0x1000);

            addressInfo.ForceMappedDspAddress = 0x2000000;

            Assert.AreEqual(0x2000000, addressInfo.GetReference(true));

            addressInfo.SetupMemoryPool(memoryPoolState.AsSpan());

            Assert.AreEqual(0x4000000, addressInfo.GetReference(true));
        }
    }
}
