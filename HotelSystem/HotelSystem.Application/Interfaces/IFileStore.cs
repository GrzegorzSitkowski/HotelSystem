using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem.Application.Interfaces
{
    public interface  IFileStore
    {
        string SaveWriteFile(byte[] content, string sourceFileName, string path);
    }
}
