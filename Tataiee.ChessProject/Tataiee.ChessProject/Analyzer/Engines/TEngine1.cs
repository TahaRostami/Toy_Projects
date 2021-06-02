using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tataiee.ChessProject.Analyzer.Engines
{
    public class TEngine1
    {
        public double Evaluation(StdChessAnalyzer pos)
        {
            if (pos.Status == Status.BLACK_WON)
                return (int)ResultScore.BW;
            else if (pos.Status == Status.WHITE_WON)
                return (int)ResultScore.WW;
            else if (pos.Status == Status.DRAW)
                return (int)ResultScore.D;

            int[,] board = pos.board;

            double w = 0;
            double b = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == (int)Home.BLACK_PAWN)
                        b += -1;
                    else if (board[i, j] == (int)Home.BLACK_KNIGHT)
                        b += -3;
                    else if (board[i, j] == (int)Home.BLACK_BISHOP)
                        b += -3.5;
                    else if (board[i, j] == (int)Home.BLACK_ROCK)
                        b += -5;
                    else if (board[i, j] == (int)Home.BLACK_QUEEN)
                        b += -9;
                    else if (board[i, j] == (int)Home.BLACK_KING)
                        b += -100;
                    if (board[i, j] == (int)Home.WHITE_PAWN)
                        w += 1;
                    else if (board[i, j] == (int)Home.WHITE_KNIGHT)
                        w += 3;
                    else if (board[i, j] == (int)Home.WHITE_BISHOP)
                        w += 3.5;
                    else if (board[i, j] == (int)Home.WHITE_ROCK)
                        w += 5;
                    else if (board[i, j] == (int)Home.WHITE_QUEEN)
                        w += 9;
                    else if (board[i, j] == (int)Home.WHITE_KING)
                        w += 100;
                }
            }

            return w + b;
        }//end method Evaluation

        public double MiniMax(StdChessAnalyzer pos, int depth = 3)
        {
            if (pos.Status == Status.BLACK_WON || pos.Status == Status.WHITE_WON || pos.Status == Status.DRAW || depth == 0)
                return Evaluation(pos);
            else
            {
                double alpha = -1000;

                #region find all legal moves

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (pos.board[i, j] != (int)Home.EMPTY)
                        {
                            for (int r = 0; r < 8; r++)
                            {
                                for (int c = 0; c < 8; c++)
                                {
                                    if (pos.MainValidator(i, j, r, c))
                                    {
                                        //legal move
                                        StdChessAnalyzer copy = pos.SaveCurrentState();
                                        copy.MainMove(i, j, r, c);
                                        alpha = Math.Max(alpha, -MiniMax(copy, depth - 1));

                                    }//end if
                                }//end for
                            }//end for
                        }//end if
                    }//end for
                }//end for

                return alpha;
                #endregion

            }//end else
        }//end method MiniMax

        public Tuple<double, string> AlphaBeta(StdChessAnalyzer pos, double alpha, double beta, int depth = 2)//alpha white score , // beta black scroe // double -> score
        {//string-> text move

            string move = "";

            if (pos.Status == Status.WHITE_WON)
                return Tuple.Create(1000.0, "");
            else if (pos.Status == Status.BLACK_WON)
                return Tuple.Create(-1000.0, "");
            else if (pos.Status == Status.DRAW)
                return Tuple.Create(0.0, "");

            if (depth == 0)
            {
                double eval = Evaluation(pos);
                string moveSign = "";
                if (eval > 0)
                    moveSign = "";
                else if (eval < 0)
                    moveSign = "";
                return pos.Turn == Turn.WHITE ? Tuple.Create(eval, moveSign) : Tuple.Create(eval, moveSign);
            }//end if
            #region find all legal moves

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((pos.Turn == Turn.WHITE && (pos.board[i, j] == (int)Home.WHITE_BISHOP ||
                                    pos.board[i, j] == (int)Home.WHITE_KING || pos.board[i, j] == (int)Home.WHITE_KNIGHT ||
                                    pos.board[i, j] == (int)Home.WHITE_PAWN || pos.board[i, j] == (int)Home.WHITE_QUEEN ||
                                    pos.board[i, j] == (int)Home.WHITE_ROCK))
                                    ||
                                    (pos.Turn == Turn.BLACK && (pos.board[i, j] == (int)Home.BLACK_BISHOP ||
                                    pos.board[i, j] == (int)Home.BLACK_KING || pos.board[i, j] == (int)Home.BLACK_KNIGHT ||
                                    pos.board[i, j] == (int)Home.BLACK_PAWN || pos.board[i, j] == (int)Home.BLACK_QUEEN ||
                                    pos.board[i, j] == (int)Home.BLACK_ROCK))
                                    )
                    {
                        for (int r = 0; r < 8; r++)
                        {
                            for (int c = 0; c < 8; c++)
                            {
                                if (pos.MainValidator(i, j, r, c))
                                {
                                    //legal move

                                    StdChessAnalyzer copy = pos.SaveCurrentState();
                                    copy.MainMove(i, j, r, c);
                                    var res = AlphaBeta(copy, alpha, beta, depth - 1);
                                    double score = res.Item1;
                                    move = res.Item2;

                                    if (pos.Turn == Turn.WHITE)
                                    {
                                        if (score > alpha)
                                        {
                                            alpha = score;
                                        }//end if
                                        else if (alpha >= beta)
                                        {
                                            return Tuple.Create(alpha, move + "," + copy.lastMove);
                                        }//end else if
                                    }//end if
                                    else if (pos.Turn == Turn.BLACK)
                                    {
                                        if (score < beta)
                                        {
                                            beta = score;
                                        }//end if
                                        else if (alpha >= beta)
                                        {
                                            return Tuple.Create(beta, move + "," + copy.lastMove);
                                        }//end else if
                                    }//end else if

                                }//end if
                            }//end for
                        }//end for
                    }//end if
                }//end for
            }//end for

            return pos.Turn == Turn.WHITE ? Tuple.Create(alpha, move + ",") : Tuple.Create(beta, move + ",");
            #endregion


        }//end method AlphaBeta


        public enum ResultScore
        {
            WW=1000,
            BW=-1000,
            D=0
        }

        public Node AlphaBetaPruning(Node node,double alpha,double beta,int depth=2)
        {
            Node child=null;
            if (depth == 0 || node.Position.Status==Status.BLACK_WON || node.Position.Status==Status.WHITE_WON || node.Position.Status==Status.DRAW)
                return new Node() { Score=Evaluation(node.Position), MoveText="", Position=node.Position.SaveCurrentState() };
            else
            {
                #region find all legal moves

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if ((node.Position.Turn == Turn.WHITE && (node.Position.board[i, j] == (int)Home.WHITE_BISHOP ||
                                        node.Position.board[i, j] == (int)Home.WHITE_KING || node.Position.board[i, j] == (int)Home.WHITE_KNIGHT ||
                                        node.Position.board[i, j] == (int)Home.WHITE_PAWN || node.Position.board[i, j] == (int)Home.WHITE_QUEEN ||
                                        node.Position.board[i, j] == (int)Home.WHITE_ROCK))
                                        ||
                                        (node.Position.Turn == Turn.BLACK && (node.Position.board[i, j] == (int)Home.BLACK_BISHOP ||
                                        node.Position.board[i, j] == (int)Home.BLACK_KING || node.Position.board[i, j] == (int)Home.BLACK_KNIGHT ||
                                        node.Position.board[i, j] == (int)Home.BLACK_PAWN || node.Position.board[i, j] == (int)Home.BLACK_QUEEN ||
                                        node.Position.board[i, j] == (int)Home.BLACK_ROCK))
                                        )
                        {
                            for (int r = 0; r < 8; r++)
                            {
                                for (int c = 0; c < 8; c++)
                                {
                                    if (node.Position.MainValidator(i, j, r, c))
                                    {
                                        //legal move

                                        StdChessAnalyzer copy = node.Position.SaveCurrentState();
                                        copy.MainMove(i, j, r, c);
                                        bool isCapture;
                                        child = new Node() { Position = copy, MoveText = node.Position.MoveRecord(i, j, r, c, out isCapture) };
                                        node.Children.Add(child);
                                        var res = AlphaBetaPruning(child, alpha, beta, depth - 1);

                                        if (node.Position.Turn == Turn.WHITE)
                                        {
                                            if (res.Score > alpha)
                                            {
                                                alpha = res.Score;
                                            }//end if
                                            else if (alpha >= beta)
                                            {
                                                child.Score = alpha;//node? child?
                                                return child;

                                                //node.Score = alpha;
                                                //return node;
                                                //return Tuple.Create(alpha, move + "," + copy.lastMove);
                                            }//end else if
                                        }//end if
                                        else if (node.Position.Turn == Turn.BLACK)
                                        {
                                            if (res.Score < beta)
                                            {
                                                beta = res.Score;
                                            }//end if
                                            else if (alpha >= beta)
                                            {
                                                child.Score = beta;
                                                return child;
                                                //node.Score = alpha;
                                                //return node;
                                                //return Tuple.Create(beta, move + "," + copy.lastMove);
                                            }//end else if
                                        }//end else if

                                    }//end if
                                }//end for
                            }//end for
                        }//end if
                    }//end for
                }//end for

                if(node.Position.Turn==Turn.WHITE)
                {
                    node.Score = alpha;
                    return node;
                }
                else
                {
                    node.Score = beta;
                    return node;
                }

                #endregion
            }//end else

        }//end method AlphaBetaPruning

    }//end class TEngine1

    public class MoveInfo
    {

        public MoveInfo()
        {
            SrcRow = -1;
            SrcCol = -1;
            DesRow = -1;
            DesCol = -1;
        }
        public int SrcRow { get; set; }
        public int SrcCol { get; set; }
        public int DesRow { get; set; }
        public int DesCol { get; set; }

        public double score { get; set; }

    }//end class MoveInfo

    public class Node
    {
        public double Score { get; set; }

        public string MoveText { get; set; }

        public StdChessAnalyzer Position { get; set; }

        public List<Node> Children = new List<Node>();

    }//end class Node

}//end namespace tataiee.ChessProject.Ananlyzer.Engines
