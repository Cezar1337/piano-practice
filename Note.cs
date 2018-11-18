using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace piano_practice
{
    public class Note
    {
        private Color highlight_color;
        private Color original_color;
        private string note_code;
        public bool playing = false;

        public Note()
        {
            this.highlight_color = Color.Aqua;
            this.note_code = "";
            this.original_color = Color.White;
            this.playing = false;
        }

        public void Translate(string code)
        {
            switch(code)
            {
                case "Z":
                    this.note_code = "C";
                    break;
                case "X":
                    this.note_code = "D";
                    break;
                case "C":
                    this.note_code = "E";
                    break;
                case "V":
                    this.note_code = "F";
                    break;
                case "B":
                    this.note_code = "G";
                    break;
                case "N":
                    this.note_code = "A";
                    break;
                case "M":
                    this.note_code = "B";
                    break;
                case "S":
                    this.note_code = "C#";
                    break;
                case "D":
                    this.note_code = "D#";
                    break;
                case "G":
                    this.note_code = "F#";
                    break;
                case "H":
                    this.note_code = "G#";
                    break;
                case "J":
                    this.note_code = "A#";
                    break;
            }
        }

        public void Play()
        {
            var key = new System.Windows.Media.MediaPlayer();
            if (!playing)
            {
                playing = true;
                key.Open(new System.Uri(@"sound\" + this.note_code + ".wav", UriKind.Relative));
                key.Play();
            }
        }
    }
}
