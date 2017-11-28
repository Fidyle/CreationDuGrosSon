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
        private int maxDistance;
        private Double volume;
        private bool loopable;
        public Sound(String nPath)
        {
            this.filePath = nPath;
            this.nameToShow = Path.GetFileNameWithoutExtension(nPath);
            this.type = Path.GetExtension(nPath);
            this.maxDistance = 100;
            this.volume = 1.00;
            this.loopable = true;
        }

        public string FilePath { get => filePath; set => filePath = value; }
        public string NameToShow { get => nameToShow; set => nameToShow = value; }
        public string Type { get => type; set => type = value; }
        public int MaxDistance { get => maxDistance; set => maxDistance = value; }
        public double Volume { get => volume; set => volume = value; }
        public bool Loopable { get => loopable; set => loopable = value; }

        public string getOriginalName()
        {
            return Path.GetFileNameWithoutExtension(this.filePath);
        }
    }
}
