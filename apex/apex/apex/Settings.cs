using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace apex
{
    [DataContract]
    class Settings
    {
        [DataMember]
        public bool Aimbot { get; set; }

        [DataMember]
        public bool SmoothAim { get; set; }

        [DataMember]
        public bool NoRecoil { get; set; }

        [DataMember]
        public int SmoothDivider { get; set; }

        [DataMember]
        public bool Glow { get; set; }

        [DataMember]
        public bool Health { get; set; }

        [DataMember]
        public bool Shields { get; set; }

        [DataMember]
        public int Aimkey { get; set; }

        [DataMember]
        public int FOV { get; set; }

        [DataMember]
        public bool DistanceCheck { get; set; }

        [DataMember]
        public int DistanceMax { get; set; }

        [DataMember]
        public bool RandomizeAim { get; set; }
    }
}
