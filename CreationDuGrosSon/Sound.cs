using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CreationDuGrosSon
{
    class Sound
    {
        private String filePath;
        private String nameToShow;
        private String type;
        public Sound(String nPath)
        {
            this.filePath = nPath;
            this.nameToShow = Path.GetFileNameWithoutExtension(nPath);
            this.type = Path.GetExtension(nPath);
        }

        public string FilePath { get => filePath; set => filePath = value; }
        public string NameToShow { get => nameToShow; set => nameToShow = value; }
        public string Type { get => type; set => type = value; }

        public string getOriginalName()
        {
            return Path.GetFileNameWithoutExtension(this.filePath);
        }
    }
}
