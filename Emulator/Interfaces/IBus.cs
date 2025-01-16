
namespace Emulator 
{
    public interface IBus
    {
        IMemory RAM { get; }
        uint64_t SystemClockCounter { get; }
        void Connect(CPU cpu);
        uint8_t CpuRead(uint16_t address, bool readOnly = false);
        void CpuWrite(uint16_t address, uint8_t data);
        void Clock();
        void Reset();
    }
}
