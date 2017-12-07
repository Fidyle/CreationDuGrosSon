using System;
using System.ComponentModel;
using System.IO;

namespace CreationDuGrosSon
{
    class Sound
    {
        private String filePath;
        private String type;
        private String nameToShow;
        private int maxDistance;
        private Double volume;
        private bool loopable;
        private String bitRate;
        private String waveType;
        public Sound(String nPath)
        {
            this.filePath = nPath;
            this.nameToShow = Path.GetFileNameWithoutExtension(nPath);
            this.type = Path.GetExtension(nPath);
            this.maxDistance = 100;
            this.volume = 1.00;
            this.loopable = true;
            this.bitRate = "44100";
            this.waveType = "D2";
            
        }
        [DisplayName("File path")]
        public string FilePath { get => filePath; set => filePath = value; }
        [DisplayName("Type")]
        public string Type { get => type; set => type = value; }
        [DisplayName("Name to show")]
        public string NameToShow { get => nameToShow; set => nameToShow = value; }
        [DisplayName("Max distance")]
        public int MaxDistance { get => maxDistance; set => maxDistance = value; }
        [DisplayName("Volume")]
        public double Volume { get => volume; set => volume = value; }
        [DisplayName("Loopable")]
        public bool Loopable { get => loopable; set => loopable = value; }
        [DisplayName("Bit rate")]
        public string BitRate { get => bitRate; set => bitRate = value; }
        [DisplayName("Wave type")]
        public string WaveType { get => waveType; set => waveType = value; }

        public string getOriginalName()
        {
            return Path.GetFileNameWithoutExtension(this.filePath);
        }
    }
}
