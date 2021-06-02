using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tataiee.ChessProject.Analyzer;

namespace Tataiee.ChessProject.Notation
{
    public class TatiNotation
    {
        //rnbqkbnrppppppppEEEEEEEEEEEEEEEEEEEEPEEEEEEEEEEEPPPP1PPPRNBQKBNR b KQkq lastmove 0 1 status
        public static string ToTatiNotation(StdChessAnalyzer stdObj)
        {
            string result = string.Empty;

            #region 1
            for (int i = 7; i >= 0; i--)
            {
                for (int j = 7; j >= 0; j--)
                {
                    if (stdObj.board[i, j] == (int)Home.EMPTY)
                    {
                        result += "E";//empty
                    }//end if

                    else if (stdObj.board[i, j] == (int)Home.WHITE_KING)
                    {
                        result += "K";
                    }//end if
                    else if (stdObj.board[i, j] == (int)Home.WHITE_QUEEN)
                    {
                        result += "Q";
                    }//end else if
                    else if (stdObj.board[i, j] == (int)Home.WHITE_ROCK)
                    {
                        result += "R";
                    }//end else if
                    else if (stdObj.board[i, j] == (int)Home.WHITE_BISHOP)
                    {
                        result += "B";
                    }//end else if
                    else if (stdObj.board[i, j] == (int)Home.WHITE_KNIGHT)
                    {
                        result += "N";
                    }//end else if
                    else if (stdObj.board[i, j] == (int)Home.WHITE_PAWN)
                    {
                        result += "P";
                    }//end else if
                    else if (stdObj.board[i, j] == (int)Home.BLACK_KING)
                    {
                        result += "k";
                    }//end if
                    else if (stdObj.board[i, j] == (int)Home.BLACK_QUEEN)
                    {
                        result += "q";
                    }//end else if
                    else if (stdObj.board[i, j] == (int)Home.BLACK_ROCK)
                    {
                        result += "r";
                    }//end else if
                    else if (stdObj.board[i, j] == (int)Home.BLACK_BISHOP)
                    {
                        result += "b";
                    }//end else if
                    else if (stdObj.board[i, j] == (int)Home.BLACK_KNIGHT)
                    {
                        result += "n";
                    }//end else if
                    else if (stdObj.board[i, j] == (int)Home.BLACK_PAWN)
                    {
                        result += "p";
                    }//end else if
                }//end for

                if (i > 0)
                {
                    //result += "/";
                }//end else

            }//end for
            #endregion

            result += " ";

            #region 2
            result += stdObj.Turn == Turn.WHITE ? "w" : "b";
            #endregion

            result += " ";

            #region 3

            if (stdObj.W_O_O_Possibility == true)
                result += "1";
            else
                result += "0";

            if (stdObj.W_O_O_O_Possibility == true)
                result += "1";
            else
                result += "0";

            if (stdObj.B_O_O_Possibility == true)
                result += "1";
            else
                result += "0";

            if (stdObj.B_O_O_Possibility == true)
                result += "1";
            else
                result += "0";

            #endregion

            result += " ";

            #region 4
            if (string.IsNullOrWhiteSpace(stdObj.lastMove))
                result += "-";
            else if (stdObj.lastMove.Length == 5)
            {
                result += stdObj.lastMove;
            }//end else
            else
                throw new FormatException();
            #endregion

            result += " ";


            #region 5
            result += stdObj.fifty_move_rule.ToString();
            #endregion

            result += " ";

            #region 6
            result += stdObj.fullMove.ToString();
            #endregion

            result += " ";

            #region 7
            /*
            WHITE_WON,
            BLACK_WON,
            DRAW,
            CONTINUE,
            NONE,
             */
            if (stdObj.Status == Status.CONTINUE)
                result += "C";
            else if (stdObj.Status == Status.WHITE_WON)
                result += "W";
            else if (stdObj.Status == Status.BLACK_WON)
                result += "B";
            else if (stdObj.Status == Status.DRAW)
                result += "D";
            else if (stdObj.Status == Status.NONE)
                result += "N";

            #endregion

            return result;
        }//end method ToTatiNotation

        public static StdChessAnalyzer ToStdChessAnalyzer(string tatiNotation)
        {
            StdChessAnalyzer std = new StdChessAnalyzer();
            string[] token = tatiNotation.Split(' ');
            int k = 0;// pointer to the current tokent

            #region 1
            for (int i = 7; i >= 0; i--)
            {
                for (int j = 7; j >= 0; j--)
                {
                    char c = token[0][k];
                    if (c == 'E')
                        std.board[i, j] = (int)Home.EMPTY;
                    else if (c == 'K')
                        std.board[i, j] = (int)Home.WHITE_KING;
                    else if (c == 'Q')
                        std.board[i, j] = (int)Home.WHITE_QUEEN;
                    else if (c == 'R')
                        std.board[i, j] = (int)Home.WHITE_ROCK;
                    else if (c == 'N')
                        std.board[i, j] = (int)Home.WHITE_KNIGHT;
                    else if (c == 'B')
                        std.board[i, j] = (int)Home.WHITE_BISHOP;
                    else if (c == 'P')
                        std.board[i, j] = (int)Home.WHITE_PAWN;
                    else if (c == 'k')
                        std.board[i, j] = (int)Home.BLACK_KING;
                    else if (c == 'q')
                        std.board[i, j] = (int)Home.BLACK_QUEEN;
                    else if (c == 'r')
                        std.board[i, j] = (int)Home.BLACK_ROCK;
                    else if (c == 'n')
                        std.board[i, j] = (int)Home.BLACK_KNIGHT;
                    else if (c == 'b')
                        std.board[i, j] = (int)Home.BLACK_BISHOP;
                    else if (c == 'p')
                        std.board[i, j] = (int)Home.BLACK_PAWN;
                    else
                        throw new FormatException();
                    k++;
                }//end for
            }//end for
            #endregion

            #region 2
            std.Turn = token[1] == "w" ? Turn.WHITE : Turn.BLACK;
            #endregion

            #region 3
            std.W_O_O_Possibility = token[2][0] == '0' ? false : true;
            std.W_O_O_O_Possibility = token[2][1] == '0' ? false : true;
            std.B_O_O_Possibility = token[2][2] == '0' ? false : true;
            std.B_O_O_O_Possibility = token[2][3] == '0' ? false : true;
            #endregion

            #region 4
            std.lastMove = token[3] == "-" ? "" : token[3];
            #endregion

            #region 5
            std.fifty_move_rule = Convert.ToInt32(token[4]);
            #endregion

            #region 6
            std.fullMove = Convert.ToInt32(token[5]);
            #endregion

            #region 7
            if (token[6] == "C")
                std.Status = Status.CONTINUE;
            else if (token[6] == "W")
                std.Status = Status.WHITE_WON;
            else if (token[6] == "B")
                std.Status = Status.BLACK_WON;
            else if (token[6] == "C")
                std.Status = Status.CONTINUE;
            else if (token[6] == "N")
                std.Status = Status.NONE;
            #endregion

            return std;
        }//end method ToStdChessAnalyzer

    }//end class Forsyth_Edwards
}//end namespace Tataiee.ChessProject.Notation
