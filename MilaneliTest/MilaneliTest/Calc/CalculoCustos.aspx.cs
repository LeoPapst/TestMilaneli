using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MilaneliTest.Calc.Classes;
namespace MilaneliTest
{
    public partial class CalculoCustos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillDrops();
                fillDropPlanos();
            }
        }

        protected void fillDrops()
        {
            dropOrigem.Items.Clear();
            dropOrigem.Items.Add("011");
            dropOrigem.Items.Add("016");
            dropOrigem.Items.Add("017");
            dropOrigem.Items.Add("018");
            dropDestino.Items.Clear();
            dropDestino.Items.Add("011");
            dropDestino.Items.Add("016");
            dropDestino.Items.Add("017");
            dropDestino.Items.Add("018");
        }
        protected void fillDropPlanos()
        {
            //dropPlanos.Items.Clear(); 
            dropPlanos.DataSource = RetornaLista();
            dropPlanos.DataValueField = "Minutos";
            dropPlanos.DataTextField = "Nome";
            dropPlanos.DataBind(); 
        }

        private List<planoTelefonico> RetornaLista() 
        {
            List<planoTelefonico> lista = new List<planoTelefonico>();

            planoTelefonico plano1 = new planoTelefonico(); 
            plano1.Nome = "FaleMais 30";
            plano1.Minutos = 30;
            lista.Add(plano1);

            planoTelefonico plano2 = new planoTelefonico(); 
            plano2.Nome = "FaleMais 60";
            plano2.Minutos = 60;
            lista.Add(plano2);

            planoTelefonico plano3 = new planoTelefonico(); 
            plano3.Nome = "FaleMais 120";
            plano3.Minutos = 120;
            lista.Add(plano3);

            return lista;
        }
        private List<taxasPlano> RetornaTaxas()
        {
            List<taxasPlano> lista = new List<taxasPlano>();

            taxasPlano taxa1 = new taxasPlano();
            taxa1.Origem = "011";
            taxa1.Destino = "016";
            taxa1.Taxa = 1.9f;
            lista.Add(taxa1);

            taxasPlano taxa2 = new taxasPlano();
            taxa2.Origem = "011";
            taxa2.Destino = "017";
            taxa2.Taxa = 1.7f;
            lista.Add(taxa2);

            taxasPlano taxa3 = new taxasPlano();
            taxa3.Origem = "011";
            taxa3.Destino = "018";
            taxa3.Taxa = 0.9f;
            lista.Add(taxa3);

            taxasPlano taxa4 = new taxasPlano();
            taxa4.Origem = "016";
            taxa4.Destino = "011";
            taxa4.Taxa = 2.9f;
            lista.Add(taxa4);

            taxasPlano taxa5 = new taxasPlano();
            taxa5.Origem = "017";
            taxa5.Destino = "011";
            taxa5.Taxa = 2.7f;
            lista.Add(taxa5);

            taxasPlano taxa6 = new taxasPlano();
            taxa6.Origem = "018";
            taxa6.Destino = "011";
            taxa6.Taxa = 1.9f;
            lista.Add(taxa6);

            return lista;
        }

        protected void btoCalculo_Click(object sender, EventArgs e)
        {
            string valOrigem = dropOrigem.SelectedValue;
            string valDestino = dropDestino.SelectedValue;
            int planoEscolhido = Convert.ToInt16(dropPlanos.SelectedValue);
            int minutosCalculo = 0;
            if (txtMinLigacao.Text != "") { Convert.ToInt16(txtMinLigacao.Text); }

            List<taxasPlano> listaTaxas = RetornaTaxas();

            int posicaoTaxa = getPosicaoListaTaxa(listaTaxas, valOrigem, valDestino);
            float taxaPlano = 0;
            
            float valComPlano = 0;
            float valSemPlano = 0;

            if (posicaoTaxa != -1)
            {
                taxaPlano = listaTaxas[posicaoTaxa].Taxa; 
                valComPlano = calculaTaxaPlano(taxaPlano, minutosCalculo, planoEscolhido);
                valSemPlano = taxaPlano * minutosCalculo;
                resultaComPlano.Text = Convert.ToString(valComPlano);
                resultaSemPlano.Text = Convert.ToString(valSemPlano);
                labelOrigem.Text = valOrigem;
                labelDestino.Text = valDestino;
                labelTempo.Text = Convert.ToString(minutosCalculo);
                labelPlano.Text = "FaleMais " + Convert.ToString(planoEscolhido);
                resultaComPlano.Text = "R$ " + String.Format("{0:0,0.00}",Convert.ToString(valComPlano));
                resultaSemPlano.Text = "R$ " + String.Format("{0:0,0.00}", Convert.ToString(valSemPlano));
                msgErro.Text = "";
            }
            else
            {
                resultaComPlano.Text = "-";
                resultaSemPlano.Text = "-";
                labelOrigem.Text = "-";
                labelDestino.Text = "-";
                labelTempo.Text = "-";
                labelPlano.Text = "-";
                resultaComPlano.Text = "-";
                resultaSemPlano.Text = "-";
                resultaSemPlano.Text = "-";
                msgErro.Text = "Combinação de DDDs inválida!";
            }
        }
        private int getPosicaoListaTaxa(List<taxasPlano> listaTaxas, string origem, string destino)
        {
            int posicaoTaxa = 0;
            foreach (taxasPlano taxa in listaTaxas)
            {
                if (taxa.Origem == origem)
                {
                    if (taxa.Destino == destino) { return posicaoTaxa; }
                }
                posicaoTaxa++;
            }
            return -1;
        }
        private float calculaTaxaPlano(float taxa, int minutosGastos, int minutosPlano)
        {
            float resultado = 0;
            int minutosCobrados = minutosGastos - minutosPlano;
            if (minutosCobrados < 0)
            {
                resultado = 0;
            }
            else
            {
                resultado = minutosCobrados * (taxa + (taxa * 0.1f));
            }

            return resultado;
        }
    }
}