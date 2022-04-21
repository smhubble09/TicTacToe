namespace TicTacToe {
    public partial class PlayGame : Form {
        string value = "X";
        int turnCount = 0;
        int xWins = 0;
        int oWins = 0;
        int draws = 0;

        public PlayGame() {
            InitializeComponent();
            DrawsLabel.Text = "Draws: " + draws;
            XWinsLabel.Text = "X Wins: " + xWins;
            OWinsLabel.Text = "O Wins: " + oWins;
            TurnLabel.Text = "It's X's turn";
        }

        private void SquareButton_Click(object sender, EventArgs e) {
            Button button = sender as Button;
            if (value == "X") {
                button.Text = value;
                button.Enabled = false;
            }
            else {
                button.Text = value;
                button.Enabled = false;
            }
            turnCount++;
            checkWinner();
        }

        private void ResetButton_Click(object sender, EventArgs e) {
            AA.Text = "";
            AB.Text = "";
            AC.Text = "";
            BA.Text = "";
            BB.Text = "";
            BC.Text = "";
            CA.Text = "";
            CB.Text = "";
            CC.Text = "";
            AA.Enabled = true;
            AB.Enabled = true;
            AC.Enabled = true;
            BA.Enabled = true;
            BB.Enabled = true;
            BC.Enabled = true;
            CA.Enabled = true;
            CB.Enabled = true;
            CC.Enabled = true;
            turnCount = 0;
            value = "X";
            TurnLabel.Text = "It's X's turn";
        }

        private void checkWinner() {
            bool weHaveWinner = false;

            //horizontal win
            if (AA.Text == AB.Text && AB.Text == AC.Text && !AB.Enabled)
                weHaveWinner = true;
            else if (BA.Text == BB.Text && BB.Text == BC.Text && !BB.Enabled)
                weHaveWinner = true;
            else if (CA.Text == CB.Text && CB.Text == CC.Text && !CB.Enabled)
                weHaveWinner = true;

            //vertical win
            else if (AA.Text == BA.Text && BA.Text == CA.Text && !BA.Enabled)
                weHaveWinner = true;
            else if (AB.Text == BB.Text && BB.Text == CB.Text && !BB.Enabled)
                weHaveWinner = true;
            else if (AC.Text == BC.Text && BC.Text == CC.Text && !BC.Enabled)
                weHaveWinner = true;

            //diagonal win
            else if (AA.Text == BB.Text && BB.Text == CC.Text && !BB.Enabled)
                weHaveWinner = true;
            else if (AC.Text == BB.Text && BB.Text == CA.Text && !BB.Enabled)
                weHaveWinner = true;

            if (weHaveWinner) {
                string winner = value;
                MessageBox.Show(winner + " Wins!", "Good Game");
                if (value == "X") {
                    xWins++;
                    XWinsLabel.Text = "X Wins: " + xWins;
                }
                else {
                    oWins++;
                    OWinsLabel.Text = "O Wins: " + oWins;
                }

                AA.Enabled = false;
                AB.Enabled = false;
                AC.Enabled = false;
                BA.Enabled = false;
                BB.Enabled = false;
                BC.Enabled = false;
                CA.Enabled = false;
                CB.Enabled = false;
                CC.Enabled = false;
            }
            else {
                if (turnCount == 9) {
                    MessageBox.Show("Draw", "No Winner");
                    draws++;
                    DrawsLabel.Text = "Draws: " + draws;
                }
                    
                if (value == "X") {
                    value = "O";
                    TurnLabel.Text = "It's " + value + "'s turn";
                }  
                else {
                    value = "X";
                    TurnLabel.Text = "It's " + value + "'s turn";
                }    
            }
        }
    }
}
