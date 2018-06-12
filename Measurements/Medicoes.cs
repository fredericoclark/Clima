using System;
using System.Collections.Generic;
using System.Text;

namespace Measurements
{
    [Serializable]
    public class Medicoes
    {
        public string MAC { get; set; }
        public string REGIAO { get; set; }
        public float TEMP { get; set; }
        public float UMIDADE { get; set; }
        public string CHUVAS { get; set; }
        public string CHUVAI { get; set; }
        public string IP { get; set; }
    }
}
