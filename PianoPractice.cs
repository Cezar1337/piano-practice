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
    public partial class PianoPractice : Form
    {
        private Note[] notes = new Note[12]; //array for all 12 Note objects
        private int[] sequence; //array for holding returned sequence
        private int lengthofSequence; //parameter for sequence generation, difficulty
        private bool playingEnabled = true; //bool allowing the player to use the keyboard
        private List<int> sequencePlayed = new List<int>(); //list containing user input
        private int sequenceCounter; //used to identify the right time to compare sequences
        private bool waitingForSequence = false; //bool that enables collecting user input
        private int score = 0; //player's score
        private int errors = 0; //number of errors; 3 result in the game ending
        private int roundsCompleted = 0; //used for difficulty scaling

        public void ClearGameInfo() //start the game over - reset score, errors, enable all buttons and playing
        {
            score = 0;
            errors = 0;
            roundsCompleted = 0;
            lengthofSequence = 3;
            lblScore.Text = "Score: " + score.ToString();
            lblErrors.Text = "Errors: " + errors.ToString() + "/3";
            btnPlaySequence.Enabled = true;
            playingEnabled = true;
            waitingForSequence = false;
            btnHelp.Enabled = true;
        }

        public bool AreSequencesEqual() //compare generated sequence with the player's
        {
            
            String sequence1 = ""; //convert both sequences to string
            String sequence2 = "";
            foreach(int i in sequencePlayed)
            {
                sequence1 += i.ToString();
            }
            for(int i = 0; i < lengthofSequence; i++)
            {
                sequence2 += sequence[i].ToString();
            }
            
            sequencePlayed.Clear(); //clear sequence
            waitingForSequence = false;
            sequenceCounter = 0;
           
            if (sequence1.Equals(sequence2)) //compare sequences in string
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void wait(int milliseconds) //stop the application for a desired amount of miliseconds
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
        public PianoPractice() //component initialization
        {
            InitializeComponent(); //initialize form components

            lengthofSequence = 3; //set starting parameteres
            sequenceCounter = 0;

            for(int i = 0; i < 12; i++) //create objects for all the keys
            {
                notes[i] = new Note(); 
            }

            notes[0].Translate("Z"); //fill note code fields for all the keys
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
            this.Focus(); //resolve focus problems

            lblMessages.Text = "Welcome to Piano Practice!\nPress \"Play sequence\" to start playing..."; //welcoming message
        }

        private void HighlightKey(int keyNumber, bool playing) //change back colors of keys when pressed
        {
            switch (keyNumber) //check which key to "highlight"
            {
                case 0:
                    if (playing) //if the key is being held down
                    {
                        c_key.BackColor = Color.Orange; //orange for keys with black font, dark orange for keys with white font
                    }
                    else //when it's released
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
        private int ReturnKeyID(String keyCode) //returns the ID of a key based on a keyboard button
        {
            int keyID = -1; //neutral value for any other keys
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
        private void Window_KeyDown(object sender, KeyEventArgs e) //listener for a key being held down
        {
            if (playingEnabled) //check if keyboard is enabled
            {
                int code = ReturnKeyID(e.KeyCode.ToString()); //get the key id for HighlightKey and the notes array
                if (code >= 0) //check if a correct button was pressed
                {
                    HighlightKey(code, true); //change key color to orange/dark orange
                    notes[code].Play(); //play the note
                }
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e) //listener for a key being released
        {
            if (playingEnabled) //check if keyboard is enabled
            {
                int code = ReturnKeyID(e.KeyCode.ToString()); //get key id for HighlightKey, notes and sequencePlayed
                if (code >= 0) //check if a correct button was released
                {
                    HighlightKey(code, false); //change key color to white/black
                    notes[code].playing = false; //enable the note to be played again after releasing the key
                    if (waitingForSequence) //if player input is being collected
                    {
                        sequencePlayed.Add(code); //add key to the list
                        sequenceCounter++; //increase the number of notes played
                    }
                }
                if(sequenceCounter == lengthofSequence && waitingForSequence) //if the player played sequence is the correct length
                {
                    if(AreSequencesEqual()) //if the sequence is correct
                    {
                        roundsCompleted++; //increase the number of completed rounds
                        score += 50 * lengthofSequence; //calculate score depending on the current difficulty
                        lblScore.Text = "Score: " + score.ToString(); //update score display
                        lblMessages.Text = "Sequence correct!\nPress \"Play sequence\" to continue..."; //info message
                        if (roundsCompleted % 3 == 0 && lengthofSequence < 10) //increase sequence length every 3 completed rounds
                        {
                            lengthofSequence++;
                        }
                    }
                    else
                    {
                        errors++; //increase error count
                        lblErrors.Text = "Errors: " + errors.ToString() + "/3"; //update error display
                        lblMessages.Text = "Sequence incorrect...\nPress \"Play sequence\" to continue..."; //info message
                        if(errors == 3) //end the game if the player made 3 mistakes
                        {
                            lblMessages.Text="Game over! Your score is: " + score + "\nPress \"Play sequence\" to play again..."; //display score
                            ClearGameInfo();
                        }
                    }
                    btnPlaySequence.Enabled = true; //enable playing another sequence after the check is complete
                }
            }
        }

        private void btnPlaySequence_Click(object sender, EventArgs e) //listener for clicking the "Play Sequence" button
        {
            Sequence s = new Sequence(lengthofSequence);
            sequence = s.ReturnSequence(); //get generated sequence
            waitingForSequence = true; //enable player input collection
            btnHelp.Enabled = false; //disable the "Help" button after the game starts
            lblMessages.Text = ""; //clear info messages

            btnPlaySequence.Enabled = false; //disable further sequence generation
            playingEnabled = false; //disable playing while a sequence is being shown
            for(int i = 0; i < sequence.Length; i++)
            {
                HighlightKey(sequence[i], true); //highlight a key
                wait(800);
                HighlightKey(sequence[i], false); //undo highlight
                wait(200);
            }
            playingEnabled = true; //enable playing
            this.Focus(); //added to prevent additional system sounds while playing notes
        }

        private void btnRestart_Click(object sender, EventArgs e) //listener for a "Reset" button press
        {
            lblMessages.Text = "Game restarted!\nPress \"Play Sequence\" to start over..."; //info message
            ClearGameInfo(); //restart the game
        }

        private void btnHelp_Click(object sender, EventArgs e) //listener for a "Help" button press
        {
            lblMessages.Text = "Replay sequences to earn points, after a few won rounds, the sequences get longer!\nPress \"Play sequence\" to start the game\nYou can restart the game at any point by pressing \"Restart\"!\nGood Luck!";
        }
    }
}
