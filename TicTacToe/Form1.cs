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
        bool turno; // verdadero = si es el turno de la x
                    // falso = si es el tueno de la y
        int cont_turno = 0;

        public frmGato()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Por Eisner", "Gato", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

            cont_turno++;

            revisarGanador();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turno = true;
            cont_turno = 0;


            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }//end try
                catch
                { }
            }//end if

        }

        private void revisarGanador()
        {
            bool hay_un_ganador = false;
            //revisa hi hay un ganador por fila horizontal.
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))


                hay_un_ganador = true;

            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))

                hay_un_ganador = true;

            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))

                hay_un_ganador = true;


            //revisa hi hay un ganador por fila vertical.
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))

                hay_un_ganador = true;

            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))

                hay_un_ganador = true;

            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))

                hay_un_ganador = true;


            //revisa hi hay un ganador por fila DIAGONAL.
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))


                hay_un_ganador = true;


            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))

                hay_un_ganador = true;


            //Mensaje que indica quien es el ganador.
            if (hay_un_ganador)
            {
                dissableButtons();

                String winner = "";
                if (turno)
                {
                    winner = "O";
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                }
                else
                {
                    winner = "X";
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                }

                MessageBox.Show(winner, "GANADOR, YEY...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (cont_turno == 10)
                {
                    MessageBox.Show("Empate", "Bummer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                }
            }
            // fin del if
        }// FIN DEL EVENTO REVISAR SI EXISTE UN GANADOR.

        //desabilita todos los botones.
        private void dissableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch
            { }

        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turno)
                b.Text = "X";
            else
                b.Text = "O";
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void frmGato_Load(object sender, EventArgs e)
        {
            turno = false;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x_win_count.Text = "0";
            o_win_count.Text = "0";
            draw_count.Text = "0";

            turno = true;
            cont_turno = 0;


            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }//end try
                catch
                { }
            }//end if
        }
    }
}
