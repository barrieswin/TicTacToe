using Microsoft.JSInterop;
namespace BlazorOX.Pages
{
    public partial class Index
    {
        string[] board = { "", "", "", "", "", "", "", "", "" };
        string player = "X";
        int[][] winningMatches =
        {
            new int[3] {0,1,2},
            new int[3] {3,4,5},
            new int[3] {6,7,8},
            new int[3] {0,3,6},
            new int[3] {1,4,7},
            new int[3] {2,5,8},
            new int[3] {0,4,8},
            new int[3] {2,4,6}
        };

        private async Task SquareClicked(int idx)
        {

            //if board is empty do
            if (board[idx] == "")
            {
                board[idx] = player;
                //switch player turn
                player = player == "X" ? "O" : "X";  
            }
            

            foreach (int[] matches in winningMatches)
            {
                int pl1 = matches[0];
                int pl2 = matches[1];
                int pl3 = matches[2];

                //if there are still empty space on the board, continue.
                if (board[pl1] == String.Empty || board[pl2] == String.Empty || board[pl3] == String.Empty) continue;

                //if player matches the winning combo, player wins.
                if (board[pl1] == board[pl2] && board[pl2] == board[pl3] && board[pl1] == board[pl3])
                {
                    string winner = player == "X" ? "Player O" : "Player X";
                    await JS.InvokeVoidAsync("ShowWinner", winner);   
                    ResetGame();
                }
            }

            if (board.All(x => x != ""))
            {
                await JS.InvokeVoidAsync("ShowTie");
                ResetGame();
            }
        }

        private void ResetGame()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = "";
            }
        }
    }
}