using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM_DoorsLibrary
{
    public class KVDPartInfo
    {
        public Command_KVD Command { get; }
        public string MaketName { get; }
        public string FileName { get; }

        public KVDPartInfo(Command_KVD command, string maketName, string fileName)
        {
            Command = command;
            MaketName = maketName;
            FileName = fileName;
        }
    }
}
