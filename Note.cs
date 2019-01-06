using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace piano_practice
{
    /// <summary>
    /// Contains information about a single note
    /// </summary>
    public class Note
    {
        /// <summary>
        /// String used in the construction of sound load paths
        /// </summary>
        private string note_code;
        /// <summary>
        /// Bool for preventing sound overwrite
        /// </summary>
        public bool playing = false;

        /// <summary>
        /// Sets default value to fields
        /// </summary>
        public Note()
        {
            this.note_code = "";
            this.playing = false;
        }
        /// <summary>
        /// Translates a keyboard button into a note name
        /// </summary>
        /// <param name="code">Text used in construction of load paths</param>
        public void Translate(string code) //
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
        /// <summary>
        /// Playes the sound from a media player
        /// </summary>
        public void Play()
        {
            var key = new System.Windows.Media.MediaPlayer();
            if (!playing) //is a sound currently being played?
            {
                playing = true; //prevent starting new playback
                key.Open(new System.Uri(@"sound\" + this.note_code + ".wav", UriKind.Relative)); //example path: sound\D#.wav
                key.Play();
            }
        }
    }
}
