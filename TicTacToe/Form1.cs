using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class frmGato : Form
    {
        bool turno = true; // verdadero = si es el turno de la x
                           // falso = si es el tueno de la y
        int cont_turno = 0;

        public frmGato()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Por Eisner", "Gato",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmGato_Load(object sender, EventArgs e)
        {
            A1.Enabled = false;
            A2.Enabled = false;
            A3.Enabled = false;
            B1.Enabled = false;
            B2.Enabled = false;
            B3.Enabled = false;
            C1.Enabled = false;
            C2.Enabled = false;
            C3.Enabled = false;
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turno)
                b.Text = "X";
            else
                b.Text = "O";

            turno = !turno;
            b.Enabled = false;
            revisarGanador();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A1.Enabled = true;
            A2.Enabled = true;
            A3.Enabled = true;
            B1.Enabled = true;
            B2.Enabled = true;
            B3.Enabled = true;
            C1.Enabled = true;
            C2.Enabled = true;
            C3.Enabled = true;
        }

        private void revisarGanador()
        {
            bool hay_un_ganador = false;
            //revisa hi hay un ganador por fila horizontal.
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text))
            {
                hay_un_ganador = true;
            }
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text))
            {
                hay_un_ganador = true;
            }
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text))
            {
                hay_un_ganador = true;
            }
            //Mensaje que indica quien es el ganador.
            if (hay_un_ganador)
            {
                String winner = "";
                if (turno)
                    winner = "O";
                else
                    winner = "X";

                MessageBox.Show("Ganador", " = " + winner , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // fin del if
        }
    }
}
