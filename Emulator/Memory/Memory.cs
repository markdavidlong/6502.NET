using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Emulator;

[StructLayout(LayoutKind.Sequential)]
public readonly partial struct Memory : IMemory {
    private readonly uint8_t[] m_Data;

    public uint8_t[] DataArray() => this.m_Data;

#pragma warning disable IDE0290
    public Memory(int32_t size) => this.m_Data = new uint8_t[size];

    public ReadOnlySpan<uint8_t> Data => this.m_Data;
    public int32_t Size => this.m_Data.Length;

    public uint8_t this[uint16_t address] {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => this.m_Data[address];
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => this.m_Data[address] = value;
    }

    public uint8_t[] ReadBlock(uint16_t address, int32_t length)
    {
        int32_t availableLength = Math.Max(0, this.m_Data.Length - address);
        int32_t readLength = Math.Min(length, availableLength);

        uint8_t[] buffer = new uint8_t[readLength];
        Array.Copy(this.m_Data, address, buffer, 0, readLength);
        return buffer;
    }
    public uint8_t Read(uint16_t address) => this.m_Data[address];
    public void Write(uint16_t address, uint8_t data) => this.m_Data[address] = data;


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBlock(uint16_t offset, params uint8_t[] data) => data.CopyTo(this.m_Data, offset);
}