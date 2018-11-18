using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace piano_practice
{
    public partial class window : Form
    {
        Note[] notes = new Note[12];
        int[] sequence;
        int lengthofSequence;

        public window()
        {
            InitializeComponent();

            lengthofSequence = 3;

            for(int i=0;i<12;i++)
            {
                notes[i] = new Note();
            }

            notes[0].Translate("Z");
            notes[1].Translate("X");
            notes[2].Translate("C");
            notes[3].Translate("V");
            notes[4].Translate("B");
            notes[5].Translate("N");
            notes[6].Translate("M");
            notes[7].Translate("S");
            notes[8].Translate("D");
            notes[9].Translate("G");
            notes[10].Translate("H");
            notes[11].Translate("J");
            this.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Z":
                    c_key.BackColor=Color.Aqua;
                    notes[0].Play();
                    break;
                case "X":
                    d_key.BackColor = Color.Aqua;
                    notes[1].Play();
                    break;
                case "C":
                    e_key.BackColor = Color.Aqua;
                    notes[2].Play();
                    break;
                case "V":
                    f_key.BackColor = Color.Aqua;
                    notes[3].Play();
                    break;
                case "B":
                    g_key.BackColor = Color.Aqua;
                    notes[4].Play();
                    break;
                case "N":
                    a_key.BackColor = Color.Aqua;
                    notes[5].Play();
                    break;
                case "M":
                    b_key.BackColor = Color.Aqua;
                    notes[6].Play();
                    break;
                case "S":
                    c_sharp_key.BackColor = Color.DarkBlue;
                    notes[7].Play();
                    break;
                case "D":
                    d_sharp_key.BackColor = Color.DarkBlue;
                    notes[8].Play();
                    break;
                case "G":
                    f_sharp_key.BackColor = Color.DarkBlue;
                    notes[9].Play();
                    break;
                case "H":
                    g_sharp_key.BackColor = Color.DarkBlue;
                    notes[10].Play();
                    break;
                case "J":
                    a_sharp_key.BackColor = Color.DarkBlue;
                    notes[11].Play();
                    break;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Z":
                    c_key.BackColor = Color.White;
                    notes[0].playing = false;
                    break;
                case "X":
                    d_key.BackColor = Color.White;
                    notes[1].playing = false;
                    break;
                case "C":
                    e_key.BackColor = Color.White;
                    notes[2].playing = false;
                    break;
                case "V":
                    f_key.BackColor = Color.White;
                    notes[3].playing = false;
                    break;
                case "B":
                    g_key.BackColor = Color.White;
                    notes[4].playing = false;
                    break;
                case "N":
                    a_key.BackColor = Color.White;
                    notes[5].playing = false;
                    break;
                case "M":
                    b_key.BackColor = Color.White;
                    notes[6].playing = false;
                    break;
                case "S":
                    c_sharp_key.BackColor = Color.Black;
                    notes[7].playing = false;
                    break;
                case "D":
                    d_sharp_key.BackColor = Color.Black;
                    notes[8].playing = false;
                    break;
                case "G":
                    f_sharp_key.BackColor = Color.Black;
                    notes[9].playing = false;
                    break;
                case "H":
                    g_sharp_key.BackColor = Color.Black;
                    notes[10].playing = false;
                    break;
                case "J":
                    a_sharp_key.BackColor = Color.Black;
                    notes[11].playing = false;
                    break;
            }
        }

        private void btnPlaySequence_Click(object sender, EventArgs e)
        {
            Sequence s = new Sequence(lengthofSequence);
            sequence = s.ReturnSequence();
            String sequenceText="";
            for(int i=0;i<sequence.Length;i++)
            {
                sequenceText = sequenceText + " " + sequence[i].ToString();
            }
            label1.Text = sequenceText;
            btnPlaySequence.Enabled = false;
            this.Focus();
        }
    }
}
