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
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            System.Media.SoundPlayer key = new System.Media.SoundPlayer();
            switch (e.KeyCode.ToString())
            {
                case "Z":
                    c_key.BackColor=Color.Aqua;
                    key.SoundLocation = @"sound\C.wav";
                    key.Load();
                    key.Play();
                    break;
                case "X":
                    d_key.BackColor = Color.Aqua;
                    key.SoundLocation = @"sound\D.wav";
                    key.Load();
                    key.Play();
                    break;
                case "C":
                    e_key.BackColor = Color.Aqua;
                    key.SoundLocation = @"sound\E.wav";
                    key.Load();
                    key.Play();
                    break;
                case "V":
                    f_key.BackColor = Color.Aqua;
                    key.SoundLocation = @"sound\F.wav";
                    key.Load();
                    key.Play();
                    break;
                case "B":
                    g_key.BackColor = Color.Aqua;
                    key.SoundLocation = @"sound\G.wav";
                    key.Load();
                    key.Play();
                    break;
                case "N":
                    a_key.BackColor = Color.Aqua;
                    key.SoundLocation = @"sound\A.wav";
                    key.Load();
                    key.Play();
                    break;
                case "M":
                    b_key.BackColor = Color.Aqua;
                    key.SoundLocation = @"sound\B.wav";
                    key.Load();
                    key.Play();
                    break;
                case "S":
                    c_sharp_key.BackColor = Color.DarkBlue;
                    key.SoundLocation = @"sound\C#.wav";
                    key.Load();
                    key.Play();
                    break;
                case "D":
                    d_sharp_key.BackColor = Color.DarkBlue;
                    key.SoundLocation = @"sound\D#.wav";
                    key.Load();
                    key.Play();
                    break;
                case "G":
                    f_sharp_key.BackColor = Color.DarkBlue;
                    key.SoundLocation = @"sound\F#.wav";
                    key.Load();
                    key.Play();
                    break;
                case "H":
                    g_sharp_key.BackColor = Color.DarkBlue;
                    key.SoundLocation = @"sound\G#.wav";
                    key.Load();
                    key.Play();
                    break;
                case "J":
                    a_sharp_key.BackColor = Color.DarkBlue;
                    key.SoundLocation = @"sound\A#.wav";
                    key.Load();
                    key.Play();
                    break;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Z":
                    c_key.BackColor = Color.White;
                    break;
                case "X":
                    d_key.BackColor = Color.White;
                    break;
                case "C":
                    e_key.BackColor = Color.White;
                    break;
                case "V":
                    f_key.BackColor = Color.White;
                    break;
                case "B":
                    g_key.BackColor = Color.White;
                    break;
                case "N":
                    a_key.BackColor = Color.White;
                    break;
                case "M":
                    b_key.BackColor = Color.White;
                    break;
                case "S":
                    c_sharp_key.BackColor = Color.Black;
                    break;
                case "D":
                    d_sharp_key.BackColor = Color.Black;
                    break;
                case "G":
                    f_sharp_key.BackColor = Color.Black;
                    break;
                case "H":
                    g_sharp_key.BackColor = Color.Black;
                    break;
                case "J":
                    a_sharp_key.BackColor = Color.Black;
                    break;
            }
        }
    }
}
