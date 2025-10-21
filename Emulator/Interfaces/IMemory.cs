using System.Text;

namespace Emulator
{
    public interface IMemory
    {
        // Essential properties
    //    ReadOnlySpan<uint8_t> Data { get; }
        int32_t Size { get; }

        // Core memory operations
        uint8_t Read(uint16_t address);
        void Write(uint16_t address, uint8_t data);
        void WriteBlock(uint16_t offset, params uint8_t[] data);

        uint8_t[] DataArray();
        // Indexer
        uint8_t this[uint16_t address] { get; set; }

        // Debug/Utility methods
       // void DumpPage(int pageNumber, StringBuilder stringBuilder, int width = 1, bool writeHeader = true, bool writeFooter = true);
       // void DumpPages(Range range, StringBuilder stringBuilder, int width = 1);
    }
}
