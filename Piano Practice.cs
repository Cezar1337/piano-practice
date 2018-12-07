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
        bool playingEnabled = true;

        public void wait(int milliseconds)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
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

        private void HighlightKey(int keyNumber, bool playing)
        {
            switch (keyNumber)
            {
                case 0:
                    if (playing)
                    {
                        c_key.BackColor = Color.Orange;
                    }
                    else
                    {
                        c_key.BackColor = Color.White;
                    }
                    break;
                case 1:
                    if (playing)
                    {
                        d_key.BackColor = Color.Orange;
                    }
                    else
                    {
                        d_key.BackColor = Color.White;
                    }
                    break;
                case 2:
                    if (playing)
                    {
                        e_key.BackColor = Color.Orange;
                    }
                    else
                    {
                        e_key.BackColor = Color.White;
                    }
                    break;
                case 3:
                    if (playing)
                    {
                        f_key.BackColor = Color.Orange;
                    }
                    else
                    {
                        f_key.BackColor = Color.White;
                    }
                    break;
                case 4:
                    if (playing)
                    {
                        g_key.BackColor = Color.Orange;
                    }
                    else
                    {
                        g_key.BackColor = Color.White;
                    }
                    break;
                case 5:
                    if (playing)
                    {
                        a_key.BackColor = Color.Orange;
                    }
                    else
                    {
                        a_key.BackColor = Color.White;
                    }
                    break;
                case 6:
                    if (playing)
                    {
                        b_key.BackColor = Color.Orange;
                    }
                    else
                    {
                        b_key.BackColor = Color.White;
                    }
                    break;
                case 7:
                    if (playing)
                    {
                        c_sharp_key.BackColor = Color.DarkOrange;
                    }
                    else
                    {
                        c_sharp_key.BackColor = Color.Black;
                    }
                    break;
                case 8:
                    if (playing)
                    {
                        d_sharp_key.BackColor = Color.DarkOrange;
                    }
                    else
                    {
                        d_sharp_key.BackColor = Color.Black;
                    }
                    break;
                case 9:
                    if (playing)
                    {
                        f_sharp_key.BackColor = Color.DarkOrange;
                    }
                    else
                    {
                        f_sharp_key.BackColor = Color.Black;
                    }
                    break;
                case 10:
                    if (playing)
                    {
                        g_sharp_key.BackColor = Color.DarkOrange;
                    }
                    else
                    {
                        g_sharp_key.BackColor = Color.Black;
                    }
                    break;
                case 11:
                    if (playing)
                    {
                        a_sharp_key.BackColor = Color.DarkOrange;
                    }
                    else
                    {
                        a_sharp_key.BackColor = Color.Black;
                    }
                    break;
            }
        }
        private int ReturnKeyID(String keyCode)
        {
            int keyID = -1;
            switch (keyCode)
            {
                case "Z":
                    keyID = 0;
                    break;
                case "X":
                    keyID = 1;
                    break;
                case "C":
                    keyID = 2;
                    break;
                case "V":
                    keyID = 3;
                    break;
                case "B":
                    keyID = 4;
                    break;
                case "N":
                    keyID = 5;
                    break;
                case "M":
                    keyID = 6;
                    break;
                case "S":
                    keyID = 7;
                    break;
                case "D":
                    keyID = 8;
                    break;
                case "G":
                    keyID = 9;
                    break;
                case "H":
                    keyID = 10;
                    break;
                case "J":
                    keyID = 11;
                    break;
            }
            return keyID;
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (playingEnabled)
            {
                int code = ReturnKeyID(e.KeyCode.ToString());
                if (code >= 0)
                {
                    HighlightKey(code, true);
                    notes[code].Play();
                }
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (playingEnabled)
            {
                int code = ReturnKeyID(e.KeyCode.ToString());
                if (code >= 0)
                {
                    HighlightKey(code, false);
                    notes[code].playing = false;
                }
            }
        }

        private void btnPlaySequence_Click(object sender, EventArgs e)
        {
            Sequence s = new Sequence(lengthofSequence);
            sequence = s.ReturnSequence();
            //testing if a correct sequence is generated
            String sequenceText ="";
            for(int i=0;i<sequence.Length;i++)
            {
                sequenceText = sequenceText + " " + sequence[i].ToString();
            }
            label1.Text = sequenceText;
            //testing if a correct sequence is generated

            btnPlaySequence.Enabled = false; //disable further sequence generation
            playingEnabled = false; //disable playing while a sequence is being shown
            for(int i=0;i<sequence.Length;i++)
            {
                HighlightKey(sequence[i], true); //highlight a key
                wait(800);
                HighlightKey(sequence[i], false); //undo highlight
                wait(200);
            }
            btnPlaySequence.Enabled = true; //temporary until a sequence testing method is implemented
            playingEnabled = true; //enable playing
            this.Focus(); //added to prevent additional system sounds while playing notes
        }
    }
}
