using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilaneliTest.Calc.Classes
{
    public class planoTelefonico
    {
        private string nome;
        private int minutos;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Minutos
        {
            get { return minutos; }
            set { minutos = value; }
        }
    }
}