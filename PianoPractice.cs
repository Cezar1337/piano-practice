using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Namespace containing all classes regarding Piano Practice
/// </summary>
namespace piano_practice
{
    /// <summary>
    /// Main form class
    /// </summary>
    public partial class PianoPractice : Form
    {
        /// <summary>
        /// Array for all 12 Note objects
        /// </summary>
        private Note[] notes = new Note[12];
        /// <summary>
        /// Array holding returned sequence
        /// </summary>
        private int[] sequence;
        /// <summary>
        /// Parameter for sequence generation, difficulty
        /// </summary>
        public int lengthofSequence;
        /// <summary>
        /// Bool allowing the player to use the keyboard
        /// </summary>
        public bool playingEnabled = true;
        /// <summary>
        /// List containing user input
        /// </summary>
        public List<int> sequencePlayed = new List<int>();
        /// <summary>
        /// Amount of keys the player has input
        /// </summary>
        public int sequenceCounter;
        /// <summary>
        /// Bool that enables collecting user input
        /// </summary>
        public bool waitingForSequence = false;
        /// <summary>
        /// Player's score
        /// </summary>
        public int score = 0;
        /// <summary>
        /// Number of errors; 3 result in the game ending
        /// </summary>
        public int errors = 0;
        /// <summary>
        /// Used for difficulty scaling
        /// </summary>
        public int roundsCompleted = 0;

        /// <summary>
        /// Starts the game over - reset score, errors, enable all buttons and playing
        /// </summary>
        public void ClearGameInfo()
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
        /// <summary>
        /// Compare generated sequence with the player's
        /// </summary>
        /// <returns>True or false</returns>
        public bool AreSequencesEqual()
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

        /// <summary>
        /// Stop the application for a desired amount of miliseconds
        /// </summary>
        /// <param name="milliseconds">Time in milliseconds</param>
        public void wait(int milliseconds) //
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
        /// <summary>
        /// Initiates components
        /// </summary>
        public PianoPractice()
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
        /// <summary>
        /// Change the back colors of keys when pressed
        /// </summary>
        /// <param name="keyNumber">Key identifier</param>
        /// <param name="playing">Flag indicating if playback is in progress</param>
        public void HighlightKey(int keyNumber, bool playing) //
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
        /// <summary>
        /// Get the ID of a key based on a keyboard button
        /// </summary>
        /// <param name="keyCode">Integer value from 0 to 11</param>
        /// <returns>Key code from 0 to 11</returns>
        public int ReturnKeyID(String keyCode) //
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
        /// <summary>
        /// Listener for a key being held down
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        public void Window_KeyDown(object sender, KeyEventArgs e)
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
        /// <summary>
        /// Listener for a key being released
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        public void Window_KeyUp(object sender, KeyEventArgs e)
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
        /// <summary>
        /// Listener for clicking the "Play Sequence" button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        public void btnPlaySequence_Click(object sender, EventArgs e)
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
        /// <summary>
        /// Listener for a "Reset" button press
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        public void btnRestart_Click(object sender, EventArgs e)
        {
            lblMessages.Text = "Game restarted!\nPress \"Play Sequence\" to start over..."; //info message
            ClearGameInfo(); //restart the game
        }
        /// <summary>
        /// Listener for a "Help" button press
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        public void btnHelp_Click(object sender, EventArgs e)
        {
            lblMessages.Text = "Replay sequences to earn points, after a few won rounds, the sequences get longer!\nPress \"Play sequence\" to start the game\nYou can restart the game at any point by pressing \"Restart\"!\nGood Luck!";
        }
    }
}
