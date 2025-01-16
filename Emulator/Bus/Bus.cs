namespace Emulator;

public class Bus : IBus {
    public IMemory RAM { get; } = new Memory(64 * KB);
    public uint64_t SystemClockCounter => this.m_SystemClockCounter;

    private uint64_t m_SystemClockCounter;
    private CPU? m_CPU;

    public void Connect(CPU cpu) {
   
        this.m_CPU = cpu;
        this.m_CPU.Connect(this);
    }

    public uint8_t CpuRead(uint16_t address, bool readOnly = false) {
        return this.RAM.Read(address);
    }

    public void CpuWrite(uint16_t address, uint8_t data) {
        this.RAM.Write(address, data);
    }

    public void Clock() {
        this.m_CPU!.Clock();

        this.m_SystemClockCounter++;
    }

    public void Reset() {
        this.m_CPU!.Reset();
        this.m_SystemClockCounter = 0;
    }
}