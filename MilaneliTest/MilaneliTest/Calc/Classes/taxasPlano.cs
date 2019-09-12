using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilaneliTest.Calc.Classes
{
    public class taxasPlano 
    {
        private string origem;
        private string destino;
        private float taxa;

        public string Origem
        {
            get { return origem; }
            set { origem = value; }
        }

        public string Destino
        {
            get { return destino; }
            set { destino = value; }
        }

        public float Taxa
        {
            get { return taxa; }
            set { taxa = value; }
        }
    }
}