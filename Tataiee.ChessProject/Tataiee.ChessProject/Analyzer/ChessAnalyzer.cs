using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tataiee.ChessProject.Analyzer
{

    public enum Turn
    {
        WHITE,
        BLACK
    }
    public enum Status
    {
        WHITE_WON,
        BLACK_WON,
        DRAW,
        CONTINUE,
        NONE,
    }
    public enum Home
    {
        EMPTY = -1,

        WHITE_PAWN = 101,
        WHITE_KNIGHT = 103,
        WHITE_BISHOP = 104,
        WHITE_ROCK = 105,
        WHITE_QUEEN = 109,
        WHITE_KING = 199,

        BLACK_PAWN = 201,
        BLACK_KNIGHT = 203,
        BLACK_BISHOP = 204,
        BLACK_ROCK = 205,
        BLACK_QUEEN = 209,
        BLACK_KING = 299,

    }

    public enum MoveType
    {
        NORMAL,//involve normal and excahnging
        EnPassant,
        O_O,
        O_O_O,
        PROMOTION,
    }

    public class StdChessAnalyzer
    {
        //default promotion : p -> Q
        public const int LENGTH = 8;
        public int[,] board;
        private Turn turn;
        private Status status;
        public int fifty_move_rule;
        //for recognition EnPassant
        public string lastMove;//format example -> P1456  <- stoneSymbol + srcRow + srcCol + desRow + desCol ; string.empty -< default
        public bool W_O_O_O_Possibility;//withe O-O-O Possibility
        public bool W_O_O_Possibility;
        public bool B_O_O_O_Possibility;
        public bool B_O_O_Possibility;////black O-O Possibility
        public int fullMove;

        public List<ThreefoldRepetition> threefoldRepetition = new List<ThreefoldRepetition>();


        public Turn Turn
        {
            get { return turn; }
            set { turn = value; }
        }
        public Status Status
        {
            get { return status; }
            set
            {
                status = value;
            }
        }



        public StdChessAnalyzer()
        {
            //board
            #region 1
            board = new int[LENGTH, LENGTH];
            for (int r = 0; r < LENGTH; r++)
            {
                for (int c = 0; c < LENGTH; c++)
                {
                    board[r, c] = (int)Home.EMPTY;
                }//end for
            }//end for

            board[0, 0] = (int)Home.WHITE_ROCK;
            board[0, 1] = (int)Home.WHITE_KNIGHT;
            board[0, 2] = (int)Home.WHITE_BISHOP;
            board[0, 3] = (int)Home.WHITE_KING;
            board[0, 4] = (int)Home.WHITE_QUEEN;
            board[0, 5] = (int)Home.WHITE_BISHOP;
            board[0, 6] = (int)Home.WHITE_KNIGHT;
            board[0, 7] = (int)Home.WHITE_ROCK;

            board[1, 0] = (int)Home.WHITE_PAWN;
            board[1, 1] = (int)Home.WHITE_PAWN;
            board[1, 2] = (int)Home.WHITE_PAWN;
            board[1, 3] = (int)Home.WHITE_PAWN;
            board[1, 4] = (int)Home.WHITE_PAWN;
            board[1, 5] = (int)Home.WHITE_PAWN;
            board[1, 6] = (int)Home.WHITE_PAWN;
            board[1, 7] = (int)Home.WHITE_PAWN;



            board[7, 0] = (int)Home.BLACK_ROCK;
            board[7, 1] = (int)Home.BLACK_KNIGHT;
            board[7, 2] = (int)Home.BLACK_BISHOP;
            board[7, 3] = (int)Home.BLACK_KING;
            board[7, 4] = (int)Home.BLACK_QUEEN;
            board[7, 5] = (int)Home.BLACK_BISHOP;
            board[7, 6] = (int)Home.BLACK_KNIGHT;
            board[7, 7] = (int)Home.BLACK_ROCK;

            board[6, 0] = (int)Home.BLACK_PAWN;
            board[6, 1] = (int)Home.BLACK_PAWN;
            board[6, 2] = (int)Home.BLACK_PAWN;
            board[6, 3] = (int)Home.BLACK_PAWN;
            board[6, 4] = (int)Home.BLACK_PAWN;
            board[6, 5] = (int)Home.BLACK_PAWN;
            board[6, 6] = (int)Home.BLACK_PAWN;
            board[6, 7] = (int)Home.BLACK_PAWN;
            #endregion
            fifty_move_rule = 0;
            turn = Turn.WHITE;
            status = Status.CONTINUE;
            lastMove = string.Empty;
            W_O_O_O_Possibility = true;
            W_O_O_Possibility = true;
            B_O_O_O_Possibility = true;
            B_O_O_Possibility = true;
            fullMove = 0;

            threefoldRepetition.Add(new ThreefoldRepetition(board));

        }//end StdChessAnalyzer contructor

        public StdChessAnalyzer(int[,] board, Turn turn, Status status, string lastMove, bool WOOO, bool WOO, bool BOO, bool BOOO,int fullMove=0)
        {
            W_O_O_O_Possibility = WOOO;
            W_O_O_Possibility = WOO;
            B_O_O_O_Possibility = BOOO;
            B_O_O_Possibility = BOO;
            this.lastMove = lastMove;
            this.status = status;
            this.turn = turn;
            fifty_move_rule = 0;
            this.board = new int[LENGTH, LENGTH];
            for (int r = 0; r < LENGTH; r++)
            {
                for (int c = 0; c < LENGTH; c++)
                {
                    this.board[r, c] = board[r, c];
                }//end for
            }//end for

            threefoldRepetition.Add(new ThreefoldRepetition(board));

        }//end StdChessAnalyzer contructor

        public StdChessAnalyzer SaveCurrentState()
        {
            StdChessAnalyzer newAnalyzer = new StdChessAnalyzer();

            newAnalyzer.board = this.CopyBoardElements();//refernce var
            newAnalyzer.turn = this.turn;
            newAnalyzer.status = this.status;
            newAnalyzer.lastMove = this.lastMove;
            newAnalyzer.W_O_O_O_Possibility = this.W_O_O_O_Possibility;
            newAnalyzer.W_O_O_Possibility = this.W_O_O_Possibility;
            newAnalyzer.B_O_O_O_Possibility = this.B_O_O_O_Possibility;
            newAnalyzer.B_O_O_Possibility = this.B_O_O_Possibility;
            newAnalyzer.fifty_move_rule = this.fifty_move_rule;
            newAnalyzer.fullMove=this.fullMove;

            return newAnalyzer;
        }//end method SaveCUrrentState

        private StdChessAnalyzer GetCurrentState()
        {
            return SaveCurrentState();
        }//end method SaveCUrrentState

        private int[,] CopyBoardElements()
        {
            int[,] newBoard = new int[LENGTH, LENGTH];
            for (int i = 0; i < LENGTH; i++)
            {
                for (int j = 0; j < LENGTH; j++)
                {
                    newBoard[i, j] = board[i, j];
                }
            }
            return newBoard;
        }

        public void UpdateStatus()
        {
            int countOfManExists = 0;

            //exists
            bool wk = false;
            bool wb1 = false;//فیل سفید سفید رو
            bool wb2 = false;//فیل سفید سیاه رو
            bool wn = false;

            bool bk = false;
            bool bb1 = false;//فیل سیاه سفید رو
            bool bb2 = false;//فیل سیاه سیاه رو
            bool bn = false;

            if (fifty_move_rule == 50 * 2)
            {
                status = Status.DRAW;//
                return;
            }//end if         
            status = Status.DRAW;//Stalemate

            bool isCheck = IsInCheck();

            if (isCheck)
                status = turn == Turn.WHITE ? Status.BLACK_WON : Status.WHITE_WON;

            if (turn == Turn.WHITE)
            {
                for (int i = 0; i < LENGTH; i++)
                {
                    for (int j = 0; j < LENGTH; j++)
                    {

                        #region InsufficientMaterial checker
                        if (board[i, j] != (int)Home.EMPTY)
                        {
                            countOfManExists++;

                            if (board[i, j] == (int)Home.WHITE_KNIGHT)
                            {
                                wn = true;
                            }//end if
                            else if (board[i, j] == (int)Home.BLACK_KNIGHT)
                            {
                                bn = true;
                            }//end if
                            else if (board[i, j] == (int)Home.WHITE_KING)
                            {
                                wk = true;
                            }//end else if
                            else if (board[i, j] == (int)Home.BLACK_KING)
                            {
                                bk = true;
                            }//end else if
                            else if (board[i, j] == (int)Home.WHITE_BISHOP)
                            {
                                if (i % 2 == 0)
                                {
                                    if (j % 2 == 0)
                                    {
                                        wb2 = true;
                                    }//end if
                                    else
                                    {
                                        wb1 = true;
                                    }//end else
                                }//end if
                                else
                                {
                                    if (j % 2 == 0)
                                    {
                                        wb1 = true;
                                    }//end if
                                    else
                                    {
                                        wb2 = true;
                                    }//end else
                                }//end else
                            }//end else if
                            else if (board[i, j] == (int)Home.BLACK_BISHOP)
                            {
                                if (i % 2 == 0)
                                {
                                    if (j % 2 == 0)
                                    {
                                        bb2 = true;
                                    }//end if
                                    else
                                    {
                                        bb1 = true;
                                    }//end else
                                }//end if
                                else
                                {
                                    if (j % 2 == 0)
                                    {
                                        bb1 = true;
                                    }//end if
                                    else
                                    {
                                        bb2 = true;
                                    }//end else
                                }//end else
                            }//end else if

                        }//end if
                        #endregion

                        if (IsItAWhiteStone(i, j))
                        {
                            for (int i2 = 0; i2 < LENGTH; i2++)
                            {
                                for (int j2 = 0; j2 < LENGTH; j2++)
                                {
                                    if (MainValidator(i, j, i2, j2))
                                        status = Status.CONTINUE;
                                }//end for
                            }//end for

                        }//end if
                    }//end for
                }//end for
            }//end if
            else if (turn == Turn.BLACK)
            {
                for (int i = 0; i < LENGTH; i++)
                {
                    for (int j = 0; j < LENGTH; j++)
                    {
                        #region InsufficientMaterial checker
                        if (board[i, j] != (int)Home.EMPTY)
                        {
                            countOfManExists++;

                            if (board[i, j] == (int)Home.WHITE_KNIGHT)
                            {
                                wn = true;
                            }//end if
                            else if (board[i, j] == (int)Home.BLACK_KNIGHT)
                            {
                                bn = true;
                            }//end if
                            else if (board[i, j] == (int)Home.WHITE_KING)
                            {
                                wk = true;
                            }//end else if
                            else if (board[i, j] == (int)Home.BLACK_KING)
                            {
                                bk = true;
                            }//end else if
                            else if (board[i, j] == (int)Home.WHITE_BISHOP)
                            {
                                if (i % 2 == 0)
                                {
                                    if (j % 2 == 0)
                                    {
                                        wb2 = true;
                                    }//end if
                                    else
                                    {
                                        wb1 = true;
                                    }//end else
                                }//end if
                                else
                                {
                                    if (j % 2 == 0)
                                    {
                                        wb1 = true;
                                    }//end if
                                    else
                                    {
                                        wb2 = true;
                                    }//end else
                                }//end else
                            }//end else if
                            else if (board[i, j] == (int)Home.BLACK_BISHOP)
                            {
                                if (i % 2 == 0)
                                {
                                    if (j % 2 == 0)
                                    {
                                        bb2 = true;
                                    }//end if
                                    else
                                    {
                                        bb1 = true;
                                    }//end else
                                }//end if
                                else
                                {
                                    if (j % 2 == 0)
                                    {
                                        bb1 = true;
                                    }//end if
                                    else
                                    {
                                        bb2 = true;
                                    }//end else
                                }//end else
                            }//end else if

                        }//end if
                        #endregion

                        if (IsItABlackStone(i, j))
                        {
                            for (int i2 = 0; i2 < LENGTH; i2++)
                            {
                                for (int j2 = 0; j2 < LENGTH; j2++)
                                {
                                    if (MainValidator(i, j, i2, j2))
                                        status = Status.CONTINUE;

                                }//end for
                            }//end for

                        }//end if
                    }//end for
                }//end for
            }//end if

            if (countOfManExists == 2 && wk && bk)
            {
                status = Status.DRAW;
            }//end if
            else if (countOfManExists == 3 && wk && bk && (wb1 ^ wb2 ^ wn ^ bb1 ^ bb2 ^ bn))
            {
                status = Status.DRAW;
            }//end else if
            else if (countOfManExists == 4)//countOfManValue == 4
            {
                if (wk && bk && ((wb1 && bb1) ^ (wb2 && bb2)))
                {
                    status = Status.DRAW;
                }//end if
            }//end else


            //threefoldRepetition
            bool f = true;
            for (int i = 0; i < threefoldRepetition.Count; i++)
            {
                if (threefoldRepetition[i].Equivalent(board))
                {
                    threefoldRepetition[i].CountOfRepetition++;
                    f = false;

                    if (threefoldRepetition[i].CountOfRepetition == 3)
                    {
                        status = Status.DRAW;
                        break;
                    }//end if
                }//end if           
            }//end for
            if (f)
                threefoldRepetition.Add(new ThreefoldRepetition(board));

        }//end method UpdateStatus

        public bool IsInCheck()
        {
            if (turn == Turn.WHITE)
            {
                int wrk = -1, wck = -1;//white row king
                #region find white king
                for (int i = 0; i < LENGTH; i++)
                {
                    for (int j = 0; j < LENGTH; j++)
                    {
                        if (board[i, j] == (int)Home.WHITE_KING)
                        {
                            wrk = i;
                            wck = j;
                            break;
                        }//end if
                    }//end for
                }//end for
                #endregion

                List<int> checkerRows = new List<int>();
                List<int> checkerCols = new List<int>();

                #region find checker stone
                for (int i = 0; i < LENGTH; i++)
                {
                    for (int j = 0; j < LENGTH; j++)
                    {
                        if (IsItABlackStone(i, j))
                        {
                            turn = turn == Turn.WHITE ? Turn.BLACK : Turn.WHITE;

                            if (IsThisMoveLegal(i, j, wrk, wck))
                            {
                                checkerRows.Add(i);
                                checkerCols.Add(j);
                            }//end if

                            turn = turn == Turn.WHITE ? Turn.BLACK : Turn.WHITE;
                        }//end if
                    }//end for
                }//end for
                #endregion

                if (checkerCols.Count == 0)
                    return false;
                else
                    return true;
            }
            else
            {
                int brk = -1, bck = -1;//white row king
                #region find white king
                for (int i = 0; i < LENGTH; i++)
                {
                    for (int j = 0; j < LENGTH; j++)
                    {
                        if (board[i, j] == (int)Home.BLACK_KING)
                        {
                            brk = i;
                            bck = j;
                            break;
                        }//end if
                    }//end for
                }//end for
                #endregion

                List<int> checkerRows = new List<int>();
                List<int> checkerCols = new List<int>();

                #region find checker stone
                for (int i = 0; i < LENGTH; i++)
                {
                    for (int j = 0; j < LENGTH; j++)
                    {
                        if (IsItAWhiteStone(i, j))
                        {
                            turn = turn == Turn.WHITE ? Turn.BLACK : Turn.WHITE;

                            if (IsThisMoveLegal(i, j, brk, bck))
                            {
                                checkerRows.Add(i);
                                checkerCols.Add(j);
                            }//end if

                            turn = turn == Turn.WHITE ? Turn.BLACK : Turn.WHITE;
                        }//end if
                    }//end for
                }//end for
                #endregion

                if (checkerCols.Count == 0)
                    return false;
                else
                    return true;
            }
        }//end method IsCheck



        public bool MainValidator(int srcRow, int srcCol, int desRow, int desCol)
        {
            if (IsThisMoveLegal(srcRow, srcCol, desRow, desCol) && WillBeInCheckAfterThisMove(srcRow, srcCol, desRow, desCol) == false)
            {
                return true;
            }//end if
            else
                return false;
        }//end method MainValidator

        public bool IsThisMoveLegal(int srcRow, int srcCol, int desRow, int desCol)
        {
            int srcIntValue = board[srcRow, srcCol];
            int desIntValue = board[desRow, desCol];

            #region General Rules

            //turn distriction
            if ((turn == Turn.WHITE && IsItABlackStone(srcRow, srcCol)) || (turn == Turn.BLACK && IsItAWhiteStone(srcRow, srcCol)))
                return false;

            //if srcHome is empty -> illegal
            if (board[srcRow, srcCol] == (int)Home.EMPTY)
                return false;

            //if srcHome & desHome have a same color stone -> illegal
            if ((IsItAWhiteStone(srcRow, srcCol) && IsItAWhiteStone(desRow, desCol))
                ||
                (IsItABlackStone(srcRow, srcCol) && IsItABlackStone(desRow, desCol))
                )
                return false;
            #endregion

            #region Specific stone rules
            switch (srcIntValue)
            {
                case (int)Home.BLACK_PAWN:
                    return IsThisMoveLegalForThePawn(srcRow, srcCol, desRow, desCol);
                //break;
                case (int)Home.WHITE_PAWN:
                    return IsThisMoveLegalForThePawn(srcRow, srcCol, desRow, desCol);
                //break;

                case (int)Home.BLACK_KNIGHT:
                    return IsThisMoveLegalForTheKnight(srcRow, srcCol, desRow, desCol);
                //break;
                case (int)Home.WHITE_KNIGHT:
                    return IsThisMoveLegalForTheKnight(srcRow, srcCol, desRow, desCol);
                //break;

                case (int)Home.BLACK_BISHOP:
                    return IsThisMoveLegalForTheBishop(srcRow, srcCol, desRow, desCol);
                //break;
                case (int)Home.WHITE_BISHOP:
                    return IsThisMoveLegalForTheBishop(srcRow, srcCol, desRow, desCol);
                //break;

                case (int)Home.BLACK_ROCK:
                    return IsThisMoveLegalForTheRock(srcRow, srcCol, desRow, desCol);
                //break;
                case (int)Home.WHITE_ROCK:
                    return IsThisMoveLegalForTheRock(srcRow, srcCol, desRow, desCol);
                //break;

                case (int)Home.BLACK_QUEEN:
                    return IsThisMoveLegalForTheQueen(srcRow, srcCol, desRow, desCol);
                //break;
                case (int)Home.WHITE_QUEEN:
                    return IsThisMoveLegalForTheQueen(srcRow, srcCol, desRow, desCol);
                //break;

                case (int)Home.BLACK_KING:
                    return IsThisMoveLegalForTheKing(srcRow, srcCol, desRow, desCol);
                //break;
                case (int)Home.WHITE_KING:
                    return IsThisMoveLegalForTheKing(srcRow, srcCol, desRow, desCol);
                    //break;
            }//end switch
            #endregion

            return true;
        }//end method IsThisMoveLegal


        public bool WillBeInCheckAfterThisMove(int srcRow, int srcCol, int desRow, int desCol)
        {

            StdChessAnalyzer tmp = SaveCurrentState();

            Move(srcRow, srcCol, desRow, desCol);

            int rk = -1, ck = -1;

            if (turn == Turn.WHITE)
            {

                for (int i = 0; i < LENGTH; i++)
                {
                    for (int j = 0; j < LENGTH; j++)
                    {
                        if (board[i, j] == (int)Home.BLACK_KING)
                        {
                            rk = i;
                            ck = j;
                            break;
                        }//end if
                    }//end for
                }//end for

                for (int i = 0; i < LENGTH; i++)
                {
                    for (int j = 0; j < LENGTH; j++)
                    {
                        if (IsItAWhiteStone(i, j))
                        {
                            if (IsThisMoveLegal(i, j, rk, ck))
                            {
                                CopyTmpToThis(tmp);
                                return true;
                            }//end if
                        }//end if
                    }//end for
                }//end for

            }//end if
            else// tuen -> Black
            {
                for (int i = 0; i < LENGTH; i++)
                {
                    for (int j = 0; j < LENGTH; j++)
                    {
                        if (board[i, j] == (int)Home.WHITE_KING)
                        {
                            rk = i;
                            ck = j;
                            break;
                        }//end if
                    }//end for
                }//end for

                for (int i = 0; i < LENGTH; i++)
                {
                    for (int j = 0; j < LENGTH; j++)
                    {
                        if (IsItABlackStone(i, j))
                        {
                            if (IsThisMoveLegal(i, j, rk, ck))
                            {
                                CopyTmpToThis(tmp);
                                return true;
                            }//end if
                        }//end if
                    }//end for
                }//end for

            }//edn else


            CopyTmpToThis(tmp);
            return false;
        }//end method IsTheNextMoveWillCheck


        private bool IsThisMoveLegalForThePawn(int srcRow, int srcCol, int desRow, int desCol)
        {
            bool iwp = board[srcRow, srcCol] == (int)Home.WHITE_PAWN ? true : false;//isWhitePawn

            if (iwp)//white pawn
            {
                if (srcCol == desCol && desRow - srcRow == 1 && board[desRow, desCol] == (int)Home.EMPTY)//jumping one step
                {
                    return true;
                }//end if
                else if (srcRow == 1 && desRow == 3 && srcCol == desCol && board[2, desCol] == (int)Home.EMPTY && board[3, desCol] == (int)Home.EMPTY)//jumping two step
                {
                    return true;
                }//end if
                else if (board[desRow, desCol] != (int)Home.EMPTY && desRow - srcRow == 1 && (srcCol - desCol == 1 || srcCol - desCol == -1))//normal exchanging
                {
                    return true;
                }//end else if
                else if (board[desRow, desCol] == (int)Home.EMPTY && srcRow == 4 && desRow == 5 && (srcCol - desCol == 1 || srcCol - desCol == -1)//EnPassant
                        && lastMove.CompareTo("P" + "6" + desCol + "4" + desCol) == 0
                       )
                {
                    return true;
                }//end else if
                else
                    return false;
            }//end if
            else//black pawn
            {
                if (srcCol == desCol && desRow - srcRow == -1 && board[desRow, desCol] == (int)Home.EMPTY)//jumping one step
                {
                    return true;
                }//end if
                else if (srcRow == 6 && desRow == 4 && srcCol == desCol && board[5, desCol] == (int)Home.EMPTY && board[4, desCol] == (int)Home.EMPTY)//jumping two step
                {
                    return true;
                }//end if
                else if (board[desRow, desCol] != (int)Home.EMPTY && desRow - srcRow == -1 && (srcCol - desCol == 1 || srcCol - desCol == -1))//normal exchanging
                {
                    return true;
                }//end else if
                else if (board[desRow, desCol] == (int)Home.EMPTY && srcRow == 3 && desRow == 2 && (srcCol - desCol == 1 || srcCol - desCol == -1)//EnPassant
                        && lastMove.CompareTo("P" + "1" + desCol + "3" + desCol) == 0
                       )
                {
                    return true;
                }//end else if
                else
                    return false;
            }//end else

        }//end method IsThisMoveLegalForThePawn

        private bool IsThisMoveLegalForTheKnight(int srcRow, int srcCol, int desRow, int desCol)
        {
            if (srcRow + 1 == desRow && srcCol + 2 == desCol)
                return true;
            else if (srcRow + 1 == desRow && srcCol - 2 == desCol)
                return true;
            else if (srcRow - 1 == desRow && srcCol + 2 == desCol)
                return true;
            else if (srcRow - 1 == desRow && srcCol - 2 == desCol)
                return true;

            else if (srcRow + 2 == desRow && srcCol + 1 == desCol)
                return true;
            else if (srcRow + 2 == desRow && srcCol - 1 == desCol)
                return true;
            else if (srcRow - 2 == desRow && srcCol + 1 == desCol)
                return true;
            else if (srcRow - 2 == desRow && srcCol - 1 == desCol)
                return true;
            else
                return false;
        }//end method IsThisMoveLegalForTheKnight

        private bool IsThisMoveLegalForTheBishop(int srcRow, int srcCol, int desRow, int desCol)
        {

            if (srcRow > desRow && srcCol < desCol && srcRow - desRow == desCol - srcCol)//top & right
            {
                int r = srcRow;
                int c = srcCol;
                bool success;
                while (r != desRow + 1 && c != desCol - 1)
                {
                    success = GoToTop_Right(r, c, out r, out c);
                    if (success && board[r, c] != (int)Home.EMPTY)
                        return false;
                }//end while
            }//end if
            else if (srcRow > desRow && srcCol > desCol && srcRow - desRow == srcCol - desCol)//top & left
            {
                int r = srcRow;
                int c = srcCol;
                bool success;
                while (r != desRow + 1 && c != desCol + 1)
                {
                    success = GoToTop_Left(r, c, out r, out c);
                    if (success && board[r, c] != (int)Home.EMPTY)
                        return false;
                }//end while
            }//end if
            else if (srcRow < desRow && srcCol > desCol && desRow - srcRow == srcCol - desCol)//bottom & left
            {
                int r = srcRow;
                int c = srcCol;
                bool success;
                while (r != desRow - 1 && c != desCol + 1)
                {
                    success = GoToBottom_Left(r, c, out r, out c);
                    if (success && board[r, c] != (int)Home.EMPTY)
                        return false;
                }//end while
            }//end if
            else if (srcRow < desRow && srcCol < desCol && desRow - srcRow == desCol - srcCol)//bottom & right
            {
                int r = srcRow;
                int c = srcCol;
                bool success;
                while (r != desRow - 1 && c != desCol - 1)
                {
                    success = GoToBottom_Right(r, c, out r, out c);
                    if (success && board[r, c] != (int)Home.EMPTY)
                        return false;
                }//end while
            }//end if
            else
                return false;

            return true;
        }//end method IsThisMoveLegalForTheBishop
        private bool IsThisMoveLegalForTheRock(int srcRow, int srcCol, int desRow, int desCol)
        {
            if (srcRow != desRow && srcCol == desCol)
            {
                int minR = Math.Min(srcRow, desRow);
                int maxR = Math.Max(srcRow, desRow);

                minR++;
                maxR--;

                while (minR <= maxR)
                {
                    if (board[maxR, srcCol] != (int)Home.EMPTY)
                        return false;
                    GoToTop(maxR, srcCol, out maxR, out srcCol);
                }//end while

            }//end if
            else if (srcRow == desRow && srcCol != desCol)
            {
                int minC = Math.Min(srcCol, desCol);
                int maxC = Math.Max(srcCol, desCol);

                minC++;
                maxC--;

                while (minC <= maxC)
                {
                    if (board[srcRow, maxC] != (int)Home.EMPTY)
                        return false;
                    GoToLeft(srcRow, maxC, out srcRow, out maxC);
                }//end while

            }//end else if
            else
                return false;

            return true;
        }//end method IsThisMoveLegalForTheRock
        private bool IsThisMoveLegalForTheQueen(int srcRow, int srcCol, int desRow, int desCol)
        {
            bool p = IsThisMoveLegalForTheRock(srcRow, srcCol, desRow, desCol);
            bool q = IsThisMoveLegalForTheBishop(srcRow, srcCol, desRow, desCol);

            if (p == true && q == false)
                return true;
            else if (p == false && q == true)
                return true;
            else
                return false;
        }//end method IsThisMoveLegalForTheQueen
        private bool IsThisMoveLegalForTheKing(int srcRow, int srcCol, int desRow, int desCol)
        {
            int newRow, newCol;
            bool success;

            #region general rules

            success = GoToTop(srcRow, srcCol, out newRow, out newCol);
            if (success && newRow == desRow && newCol == desCol)
            {
                return true;
            }//end if

            success = GoToBottom(srcRow, srcCol, out newRow, out newCol);
            if (success && newRow == desRow && newCol == desCol)
            {
                return true;
            }//end if

            success = GoToLeft(srcRow, srcCol, out newRow, out newCol);
            if (success && newRow == desRow && newCol == desCol)
            {
                return true;
            }//end if

            success = GoToRight(srcRow, srcCol, out newRow, out newCol);
            if (success && newRow == desRow && newCol == desCol)
            {
                return true;
            }//end if

            success = GoToTop_Right(srcRow, srcCol, out newRow, out newCol);
            if (success && newRow == desRow && newCol == desCol)
            {
                return true;
            }//end if

            success = GoToTop_Left(srcRow, srcCol, out newRow, out newCol);
            if (success && newRow == desRow && newCol == desCol)
            {
                return true;
            }//end if

            success = GoToBottom_Right(srcRow, srcCol, out newRow, out newCol);
            if (success && newRow == desRow && newCol == desCol)
            {
                return true;
            }//end if


            success = GoToBottom_Left(srcRow, srcCol, out newRow, out newCol);
            if (success && newRow == desRow && newCol == desCol)
            {
                return true;
            }//end if
            #endregion

            bool iwk = board[srcRow, srcCol] == (int)Home.WHITE_KING ? true : false;//is a white king
            if (iwk)
            {
                if (srcRow == 0 && desRow == 0 && srcCol == 3)
                {
                    if (desCol == 1)//O-O
                    {
                        if (W_O_O_Possibility && board[0, 2] == (int)Home.EMPTY && board[0, 1] == (int)Home.EMPTY && board[0, 0] == (int)Home.WHITE_ROCK)
                        {
                            #region W_O_O
                            if (board[1, 0] == (int)Home.BLACK_KNIGHT || board[2, 1] == (int)Home.BLACK_KNIGHT
                                || board[2, 3] == (int)Home.BLACK_KNIGHT || board[1, 4] == (int)Home.BLACK_KNIGHT
                                )
                                return false;
                            if (board[1, 1] == (int)Home.BLACK_KNIGHT || board[2, 2] == (int)Home.BLACK_KNIGHT
                               || board[2, 4] == (int)Home.BLACK_KNIGHT || board[1, 5] == (int)Home.BLACK_KNIGHT
                               )
                                return false;

                            turn = turn == Turn.BLACK ? Turn.WHITE : Turn.BLACK;
                            //before move
                            if (IsThisMoveLegal(0, 4, 0, 3) || IsThisMoveLegal(0, 5, 0, 3) || IsThisMoveLegal(0, 6, 0, 3) ||
                                IsThisMoveLegal(0, 7, 0, 3) || IsThisMoveLegal(1, 2, 0, 3) || IsThisMoveLegal(2, 1, 0, 3) ||
                                IsThisMoveLegal(3, 0, 0, 3) || IsThisMoveLegal(1, 4, 0, 3) || IsThisMoveLegal(2, 5, 0, 3) ||
                                IsThisMoveLegal(3, 6, 0, 3) || IsThisMoveLegal(4, 7, 0, 3) ||
                                IsThisMoveLegal(1, 3, 0, 3) || IsThisMoveLegal(2, 3, 0, 3) || IsThisMoveLegal(3, 3, 0, 3) ||
                                IsThisMoveLegal(4, 3, 0, 3) || IsThisMoveLegal(5, 3, 0, 3) || IsThisMoveLegal(6, 3, 0, 3) ||
                                IsThisMoveLegal(7, 3, 0, 3)
                               )
                            {
                                turn = turn == Turn.BLACK ? Turn.WHITE : Turn.BLACK;
                                return false;
                            }//end if
                            else
                            {
                                turn = turn == Turn.BLACK ? Turn.WHITE : Turn.BLACK;
                            }//end else

                            StdChessAnalyzer tmp = SaveCurrentState();
                            Move(srcRow, srcCol, desRow, 2);

                            if (IsThisMoveLegal(0, 4, 0, 2) || IsThisMoveLegal(0, 5, 0, 2) || IsThisMoveLegal(0, 6, 0, 2) ||
                                IsThisMoveLegal(0, 7, 0, 2) || IsThisMoveLegal(1, 2, 0, 2) || IsThisMoveLegal(2, 2, 0, 2) ||
                                IsThisMoveLegal(3, 2, 0, 2) || IsThisMoveLegal(4, 2, 0, 2) || IsThisMoveLegal(5, 2, 0, 2) ||
                                IsThisMoveLegal(6, 2, 0, 2) || IsThisMoveLegal(7, 2, 0, 2) ||
                                IsThisMoveLegal(2, 0, 0, 2) || IsThisMoveLegal(1, 1, 0, 2) || IsThisMoveLegal(1, 3, 0, 2) ||
                                IsThisMoveLegal(2, 4, 0, 2) || IsThisMoveLegal(3, 5, 0, 2) || IsThisMoveLegal(4, 6, 0, 2) ||
                                IsThisMoveLegal(5, 7, 0, 2)
                               )
                            {
                                CopyTmpToThis(tmp);
                                return false;
                            }//end if
                            else
                            {
                                CopyTmpToThis(tmp);
                                return true;
                            }//end else
                            #endregion
                        }//end if
                        else
                            return false;
                    }//end if
                    else if (desCol == 5)//O-O-O
                    {
                        if (W_O_O_O_Possibility && board[0, 4] == (int)Home.EMPTY && board[0, 5] == (int)Home.EMPTY && board[0, 6] == (int)Home.EMPTY

                            && board[0, 7] == (int)Home.WHITE_ROCK)
                        {
                            #region W_O_O_O

                            if (board[1, 2] == (int)Home.BLACK_KNIGHT || board[2, 3] == (int)Home.BLACK_KNIGHT
                                || board[2, 5] == (int)Home.BLACK_KNIGHT || board[1, 6] == (int)Home.BLACK_KNIGHT
                                )
                                return false;
                            if (board[1, 1] == (int)Home.BLACK_KNIGHT || board[2, 2] == (int)Home.BLACK_KNIGHT
                               || board[2, 4] == (int)Home.BLACK_KNIGHT || board[1, 5] == (int)Home.BLACK_KNIGHT
                               )
                                return false;

                            turn = turn == Turn.BLACK ? Turn.WHITE : Turn.BLACK;
                            //before move
                            if (IsThisMoveLegal(0, 4, 0, 3) || IsThisMoveLegal(0, 5, 0, 3) || IsThisMoveLegal(0, 6, 0, 3) ||
                                IsThisMoveLegal(0, 7, 0, 3) || IsThisMoveLegal(1, 2, 0, 3) || IsThisMoveLegal(2, 1, 0, 3) ||
                                IsThisMoveLegal(3, 0, 0, 3) || IsThisMoveLegal(1, 4, 0, 3) || IsThisMoveLegal(2, 5, 0, 3) ||
                                IsThisMoveLegal(3, 6, 0, 3) || IsThisMoveLegal(4, 7, 0, 3) ||
                                IsThisMoveLegal(1, 3, 0, 3) || IsThisMoveLegal(2, 3, 0, 3) || IsThisMoveLegal(3, 3, 0, 3) ||
                                IsThisMoveLegal(4, 3, 0, 3) || IsThisMoveLegal(5, 3, 0, 3) || IsThisMoveLegal(6, 3, 0, 3) ||
                                IsThisMoveLegal(7, 3, 0, 3)
                               )
                            {
                                turn = turn == Turn.BLACK ? Turn.WHITE : Turn.BLACK;
                                return false;
                            }//end if
                            else
                                turn = turn == Turn.BLACK ? Turn.WHITE : Turn.BLACK;

                            StdChessAnalyzer tmp = SaveCurrentState();
                            Move(srcRow, srcCol, desRow, 4);

                            if (IsThisMoveLegal(0, 0, 0, 4) || IsThisMoveLegal(0, 1, 0, 4) || IsThisMoveLegal(0, 2, 0, 4) ||
                                IsThisMoveLegal(1, 4, 0, 4) || IsThisMoveLegal(2, 4, 0, 4) || IsThisMoveLegal(3, 4, 0, 4) ||
                                IsThisMoveLegal(4, 4, 0, 4) || IsThisMoveLegal(5, 4, 0, 4) || IsThisMoveLegal(6, 4, 0, 4) ||
                                IsThisMoveLegal(7, 4, 0, 4) || IsThisMoveLegal(1, 3, 0, 4) ||
                                IsThisMoveLegal(2, 2, 0, 4) || IsThisMoveLegal(3, 1, 0, 4) || IsThisMoveLegal(4, 0, 0, 4) ||
                                IsThisMoveLegal(1, 5, 0, 4) || IsThisMoveLegal(2, 6, 0, 4) || IsThisMoveLegal(3, 7, 0, 4)
                               )
                            {
                                CopyTmpToThis(tmp);
                                return false;
                            }//end if
                            else
                            {
                                CopyTmpToThis(tmp);
                                return true;
                            }//end else
                            #endregion
                        }//end else if
                        else
                            return false;
                    }//end els eif
                }//end if
                else
                    return false;
            }//end if
            else//black king
            {

                if (srcRow == 7 && desRow == 7 && srcCol == 3)
                {
                    if (desCol == 1)//O-O
                    {
                        if (B_O_O_Possibility && board[7, 2] == (int)Home.EMPTY && board[7, 1] == (int)Home.EMPTY && board[7, 0] == (int)Home.BLACK_ROCK)
                        {
                            #region W_O_O
                            if (board[6, 0] == (int)Home.WHITE_KNIGHT || board[5, 1] == (int)Home.WHITE_KNIGHT
                                || board[5, 3] == (int)Home.WHITE_KNIGHT || board[6, 4] == (int)Home.WHITE_KNIGHT
                                )
                                return false;
                            if (board[6, 1] == (int)Home.WHITE_KNIGHT || board[5, 2] == (int)Home.WHITE_KNIGHT
                               || board[5, 4] == (int)Home.WHITE_KNIGHT || board[6, 5] == (int)Home.WHITE_KNIGHT
                               )
                                return false;

                            turn = turn == Turn.BLACK ? Turn.WHITE : Turn.BLACK;
                            //before move
                            if (IsThisMoveLegal(7 - 0, 4, 7, 3) || IsThisMoveLegal(7 - 0, 5, 7, 3) || IsThisMoveLegal(7 - 0, 6, 7, 3) ||
                                IsThisMoveLegal(7 - 0, 7, 7, 3) || IsThisMoveLegal(7 - 1, 2, 7, 3) || IsThisMoveLegal(7 - 2, 1, 7, 3) ||
                                IsThisMoveLegal(7 - 3, 0, 7, 3) || IsThisMoveLegal(7 - 1, 4, 7, 3) || IsThisMoveLegal(7 - 2, 5, 7, 3) ||
                                IsThisMoveLegal(7 - 3, 6, 7, 3) || IsThisMoveLegal(7 - 4, 7, 7, 3) ||
                                IsThisMoveLegal(7 - 1, 3, 7, 3) || IsThisMoveLegal(7 - 2, 3, 7, 3) || IsThisMoveLegal(7 - 3, 3, 7, 3) ||
                                IsThisMoveLegal(7 - 4, 3, 7, 3) || IsThisMoveLegal(7 - 5, 3, 7, 3) || IsThisMoveLegal(7 - 6, 3, 7, 3) ||
                                IsThisMoveLegal(7 - 7, 3, 7, 3)
                               )
                            {
                                turn = turn == Turn.BLACK ? Turn.WHITE : Turn.BLACK;
                                return false;
                            }//end if
                            else
                            {
                                turn = turn == Turn.BLACK ? Turn.WHITE : Turn.BLACK;
                            }//end else

                            StdChessAnalyzer tmp = SaveCurrentState();
                            Move(srcRow, srcCol, desRow, 2);

                            if (IsThisMoveLegal(7 - 0, 4, 7, 2) || IsThisMoveLegal(7 - 0, 5, 7, 2) || IsThisMoveLegal(7 - 0, 6, 7, 2) ||
                                IsThisMoveLegal(7 - 0, 7, 7, 2) || IsThisMoveLegal(7 - 1, 2, 7, 2) || IsThisMoveLegal(7 - 2, 2, 7, 2) ||
                                IsThisMoveLegal(7 - 3, 2, 7, 2) || IsThisMoveLegal(7 - 4, 2, 7, 2) || IsThisMoveLegal(7 - 5, 2, 7, 2) ||
                                IsThisMoveLegal(7 - 6, 2, 7, 2) || IsThisMoveLegal(7 - 7, 2, 7, 2) ||
                                IsThisMoveLegal(7 - 2, 0, 7, 2) || IsThisMoveLegal(7 - 1, 1, 7, 2) || IsThisMoveLegal(7 - 1, 3, 7, 2) ||
                                IsThisMoveLegal(7 - 2, 4, 7, 2) || IsThisMoveLegal(7 - 3, 5, 7, 2) || IsThisMoveLegal(7 - 4, 6, 7, 2) ||
                                IsThisMoveLegal(7 - 5, 7, 7, 2)
                               )
                            {
                                CopyTmpToThis(tmp);
                                return false;
                            }//end if
                            else
                            {
                                CopyTmpToThis(tmp);
                                return true;
                            }//end else
                            #endregion
                        }//end if
                        else
                            return false;
                    }//end if
                    else if (desCol == 5)//O-O-O
                    {
                        if (B_O_O_O_Possibility && board[7, 4] == (int)Home.EMPTY && board[7, 5] == (int)Home.EMPTY && board[7, 6] == (int)Home.EMPTY

                            && board[7, 7] == (int)Home.BLACK_ROCK)
                        {
                            #region W_O_O_O

                            if (board[6, 2] == (int)Home.WHITE_KNIGHT || board[5, 3] == (int)Home.WHITE_KNIGHT
                                || board[5, 5] == (int)Home.WHITE_KNIGHT || board[6, 6] == (int)Home.WHITE_KNIGHT
                                )
                                return false;
                            if (board[6, 1] == (int)Home.WHITE_KNIGHT || board[5, 2] == (int)Home.WHITE_KNIGHT
                               || board[5, 4] == (int)Home.WHITE_KNIGHT || board[6, 5] == (int)Home.WHITE_KNIGHT
                               )
                                return false;

                            turn = turn == Turn.BLACK ? Turn.WHITE : Turn.BLACK;
                            //before move
                            if (IsThisMoveLegal(7 - 0, 4, 7, 3) || IsThisMoveLegal(7 - 0, 5, 7, 3) || IsThisMoveLegal(7 - 0, 6, 7, 3) ||
                                IsThisMoveLegal(7 - 0, 7, 7, 3) || IsThisMoveLegal(7 - 1, 2, 7, 3) || IsThisMoveLegal(7 - 2, 1, 7, 3) ||
                                IsThisMoveLegal(7 - 3, 0, 7, 3) || IsThisMoveLegal(7 - 1, 4, 7, 3) || IsThisMoveLegal(7 - 2, 5, 7, 3) ||
                                IsThisMoveLegal(7 - 3, 6, 7, 3) || IsThisMoveLegal(7 - 4, 7, 7, 3) ||
                                IsThisMoveLegal(7 - 1, 3, 7, 3) || IsThisMoveLegal(7 - 2, 3, 7, 3) || IsThisMoveLegal(7 - 3, 3, 7, 3) ||
                                IsThisMoveLegal(7 - 4, 3, 7, 3) || IsThisMoveLegal(7 - 5, 3, 7, 3) || IsThisMoveLegal(7 - 6, 3, 7, 3) ||
                                IsThisMoveLegal(7 - 7, 3, 7, 3)
                               )
                            {
                                turn = turn == Turn.BLACK ? Turn.WHITE : Turn.BLACK;
                                return false;
                            }//end if
                            else
                                turn = turn == Turn.BLACK ? Turn.WHITE : Turn.BLACK;

                            StdChessAnalyzer tmp = SaveCurrentState();
                            Move(srcRow, srcCol, desRow, 4);

                            if (IsThisMoveLegal(7 - 0, 0, 7, 4) || IsThisMoveLegal(7 - 0, 1, 7, 4) || IsThisMoveLegal(7 - 0, 2, 7, 4) ||
                                IsThisMoveLegal(7 - 1, 4, 7, 4) || IsThisMoveLegal(7 - 2, 4, 7, 4) || IsThisMoveLegal(7 - 3, 4, 7, 4) ||
                                IsThisMoveLegal(7 - 4, 4, 7, 4) || IsThisMoveLegal(7 - 5, 4, 7, 4) || IsThisMoveLegal(7 - 6, 4, 7, 4) ||
                                IsThisMoveLegal(7 - 7, 4, 7, 4) || IsThisMoveLegal(7 - 1, 3, 7, 4) ||
                                IsThisMoveLegal(7 - 2, 2, 7, 4) || IsThisMoveLegal(7 - 3, 1, 7, 4) || IsThisMoveLegal(7 - 4, 0, 7, 4) ||
                                IsThisMoveLegal(7 - 1, 5, 7, 4) || IsThisMoveLegal(7 - 2, 6, 7, 4) || IsThisMoveLegal(7 - 3, 7, 7, 4)
                               )
                            {
                                CopyTmpToThis(tmp);
                                return false;
                            }//end if
                            else
                            {
                                CopyTmpToThis(tmp);
                                return true;
                            }//end else
                            #endregion
                        }//end else if
                        else
                            return false;
                    }//end els eif
                }//end if
                else
                    return false;

            }//end else

            return false;
        }//end method IsThisMoveLegalForTheKing


        #region Go To Func

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row">top home row</param>
        /// <param name="col">top home col</param>
        /// <param name="oRow"></param>
        /// <param name="oCol"></param>
        /// <returns>successful or faild</returns>
        private bool GoToTop(int row, int col, out int oRow, out int oCol)
        {
            oRow = -1;
            oCol = -1;

            row = row - 1;

            if (row >= 0)
            {
                oRow = row;
                oCol = col;
                return true;
            }//end if

            return false;
        }//end method GoToTop

        private bool GoToBottom(int row, int col, out int oRow, out int oCol)
        {
            oRow = -1;
            oCol = -1;
            row = row + 1;

            if (row < LENGTH)
            {
                oRow = row;
                oCol = col;
                return true;
            }//end if

            return false;
        }//end method GoToBottom


        private bool GoToLeft(int row, int col, out int oRow, out int oCol)
        {
            oRow = -1;
            oCol = -1;
            col = col - 1;

            if (col >= 0)
            {
                oRow = row;
                oCol = col;
                return true;
            }//end if

            return false;
        }//end method GoToLeft

        private bool GoToRight(int row, int col, out int oRow, out int oCol)
        {
            oRow = -1;
            oCol = -1;

            col = col + 1;

            if (col < LENGTH)
            {
                oRow = row;
                oCol = col;
                return true;
            }//end if

            return false;
        }//end method GoToRight


        private bool GoToTop_Right(int row, int col, out int oRow, out int oCol)
        {
            oRow = -1;
            oCol = -1;

            row = row - 1;
            col = col + 1;

            if (row >= 0 && col < LENGTH)
            {
                oRow = row;
                oCol = col;
                return true;
            }//end if

            return false;
        }//end method GoToRight

        private bool GoToTop_Left(int row, int col, out int oRow, out int oCol)
        {
            oRow = -1;
            oCol = -1;

            row = row - 1;
            col = col - 1;

            if (row >= 0 && col >= 0)
            {
                oRow = row;
                oCol = col;
                return true;
            }//end if

            return false;
        }//end method GoToRight


        private bool GoToBottom_Right(int row, int col, out int oRow, out int oCol)
        {
            oRow = -1;
            oCol = -1;

            row = row + 1;
            col = col + 1;

            if (row < LENGTH && col < LENGTH)
            {
                oRow = row;
                oCol = col;
                return true;
            }//end if

            return false;
        }//end method GoToRight

        private bool GoToBottom_Left(int row, int col, out int oRow, out int oCol)
        {
            oRow = -1;
            oCol = -1;

            row = row + 1;
            col = col - 1;

            if (row < LENGTH && col >= 0)
            {
                oRow = row;
                oCol = col;
                return true;
            }//end if

            return false;
        }//end method GoToRight

        #endregion


        private void CopyTmpToThis(StdChessAnalyzer tmp)
        {
            this.board = tmp.board;
            this.B_O_O_O_Possibility = tmp.B_O_O_O_Possibility;
            this.B_O_O_Possibility = tmp.B_O_O_Possibility;
            this.lastMove = tmp.lastMove;
            this.status = tmp.status;
            this.turn = tmp.turn;
            this.W_O_O_O_Possibility = tmp.W_O_O_O_Possibility;
            this.W_O_O_Possibility = tmp.W_O_O_Possibility;
            this.fifty_move_rule = tmp.fifty_move_rule;
        }//end method CopyTo

        protected MoveType Move(int srcRow, int srcCol, int desRow, int desCol)
        {
            MoveType moveType = MoveType.NORMAL;

            int stone = board[srcRow, srcCol];

            lastMove = StoneSymbol(stone) + srcRow.ToString() + srcCol.ToString() + desRow.ToString() + desCol.ToString();

            if (board[srcRow, srcCol] == (int)Home.WHITE_PAWN || board[srcRow, srcCol] == (int)Home.BLACK_PAWN || board[desRow, desCol] != (int)Home.EMPTY)//exchanging or pawn move
            {
                fifty_move_rule = 0;
            }//end if
            else//board[desRow,desCol]==(int)Home.EMPTY
            {
                fifty_move_rule++;
            }//end else if

            #region move type
            if (stone == (int)Home.WHITE_KING && srcRow == 0 && desRow == 0 && srcCol == 3 && desCol == 1)
            {
                board[desRow, desCol] = board[srcRow, srcCol];
                board[srcRow, srcCol] = (int)Home.EMPTY;
                //board[srcRow,2]= (int)Home.EMPTY;
                board[0, 0] = (int)Home.EMPTY;
                board[0, 2] = (int)Home.WHITE_ROCK;

                moveType = MoveType.O_O;
            }//end if
            else if (stone == (int)Home.WHITE_KING && srcRow == 0 && desRow == 0 && srcCol == 3 && desCol == 5)
            {
                board[desRow, desCol] = board[srcRow, srcCol];
                board[srcRow, srcCol] = (int)Home.EMPTY;
                //board[srcRow, 4] = (int)Home.EMPTY;
                board[0, 7] = (int)Home.EMPTY;
                board[0, 4] = (int)Home.WHITE_ROCK;

                moveType = MoveType.O_O_O;
            }//end else if
            else if (stone == (int)Home.BLACK_KING && srcRow == 7 && desRow == 7 && srcCol == 3 && desCol == 1)
            {
                board[desRow, desCol] = board[srcRow, srcCol];
                board[srcRow, srcCol] = (int)Home.EMPTY;
                //board[srcRow,2]= (int)Home.EMPTY;
                board[7, 0] = (int)Home.EMPTY;
                board[7, 2] = (int)Home.BLACK_ROCK;

                moveType = MoveType.O_O;
            }//end if
            else if (stone == (int)Home.BLACK_KING && srcRow == 7 && desRow == 7 && srcCol == 3 && desCol == 5)
            {
                board[desRow, desCol] = board[srcRow, srcCol];
                board[srcRow, srcCol] = (int)Home.EMPTY;
                //board[srcRow, 4] = (int)Home.EMPTY;
                board[7, 7] = (int)Home.EMPTY;
                board[7, 4] = (int)Home.BLACK_ROCK;

                moveType = MoveType.O_O_O;
            }//end else if
            else if (stone == (int)Home.WHITE_PAWN && board[desRow, desCol] == (int)Home.EMPTY && srcRow == 4 && desRow == 5 && (srcCol - desCol == 1 || srcCol - desCol == -1))
            {
                board[desRow, desCol] = board[srcRow, srcCol];
                board[srcRow, srcCol] = (int)Home.EMPTY;
                board[srcRow, desCol] = (int)Home.EMPTY;

                moveType = MoveType.EnPassant;
            }//end else if
            else if (stone == (int)Home.BLACK_PAWN && board[desRow, desCol] == (int)Home.EMPTY && srcRow == 3 && desRow == 2 && (srcCol - desCol == 1 || srcCol - desCol == -1))
            {
                board[desRow, desCol] = board[srcRow, srcCol];
                board[srcRow, srcCol] = (int)Home.EMPTY;
                board[srcRow, desCol] = (int)Home.EMPTY;

                moveType = MoveType.EnPassant;
            }//end else if
            else if (stone == (int)Home.WHITE_PAWN && desRow == 7)
            {
                board[desRow, desCol] = (int)Home.WHITE_QUEEN;//default promotion
                board[srcRow, srcCol] = (int)Home.EMPTY;

                moveType = MoveType.PROMOTION;
            }//end else if
            else if (stone == (int)Home.BLACK_PAWN && desRow == 0)
            {
                board[desRow, desCol] = (int)Home.BLACK_QUEEN;//default promotion
                board[srcRow, srcCol] = (int)Home.EMPTY;

                moveType = MoveType.PROMOTION;
            }//end else if
            else//NORMAL or NORMAL EXCHANGE
            {
                board[desRow, desCol] = board[srcRow, srcCol];
                board[srcRow, srcCol] = (int)Home.EMPTY;
                //moveType = MoveType.NORMAL;
            }//end else
            #endregion

            turn = turn == Turn.WHITE ? Turn.BLACK : Turn.WHITE;

            #region T
            if (stone == (int)Home.WHITE_KING)
            {
                W_O_O_O_Possibility = false;
                W_O_O_Possibility = false;
            }//end if
            else if (stone == (int)Home.WHITE_ROCK && srcRow == 0 && srcCol == 0)
            {
                W_O_O_Possibility = false;
            }//end else if
            else if (stone == (int)Home.WHITE_ROCK && srcRow == 0 && srcCol == 7)
            {
                W_O_O_O_Possibility = false;
            }//end else if

            else if (stone == (int)Home.BLACK_KING)
            {
                B_O_O_O_Possibility = false;
                B_O_O_Possibility = false;
            }//end if
            else if (stone == (int)Home.BLACK_ROCK && srcRow == 7 && srcCol == 0)
            {
                B_O_O_Possibility = false;
            }//end else if
            else if (stone == (int)Home.BLACK_ROCK && srcRow == 7 && srcCol == 7)
            {
                B_O_O_O_Possibility = false;
            }//end else if
            #endregion

            return moveType;
        }//end method Move

        public MoveType MainMove(int srcRow, int srcCol, int desRow, int desCol)
        {
            MoveType moveType = Move(srcRow, srcCol, desRow, desCol);

            if (Turn == Turn.BLACK)
                fullMove++;

            return moveType;
        }//end method MainMove


        public string MoveRecord(int srcRow, int srcCol, int desRow, int desCol, out bool isCapture)
        {
            int sameRow = 0;
            int sameCol = 0;
            int count = 0;


            if (board[desRow, desCol] != (int)Home.EMPTY)
                isCapture = true;
            else
                isCapture = false;

            if (StoneSymbol(board[srcRow, srcCol]) == 'P' && board[desRow, desCol] != (int)Home.EMPTY)
                return ColToFile(srcCol).ToString() + ColToFile(desCol).ToString() + (desRow + 1).ToString();
            else if (StoneSymbol(board[srcRow, srcCol]) == 'P' && board[desRow, desCol] == (int)Home.EMPTY)
                return ColToFile(desCol).ToString() + (desRow + 1).ToString();

            for (int i = 0; i < LENGTH; i++)
            {
                for (int j = 0; j < LENGTH; j++)
                {
                    if (board[i, j] == board[srcRow, srcCol] && (!(i == srcRow && j == srcCol)) && MainValidator(i, j, desRow, desCol))
                    {
                        if (i == srcRow && j != srcCol)
                            sameRow++;
                        else if (i != srcRow && j == srcCol)
                            sameCol++;

                        count++;
                    }//end if
                }//end for
            }//end for            



            if (count == 0)//1
                return StoneSymbol(board[srcRow, srcCol]).ToString() + ColToFile(desCol).ToString() + (desRow + 1).ToString();//example :Nf5
            else
            {

                if (sameRow == 0 && sameCol == 0)
                    return StoneSymbol(board[srcRow, srcCol]).ToString() + ColToFile(srcCol) + ColToFile(desCol) + (desRow + 1).ToString();//Ng3f5           
                else if (sameRow >= 1 && sameCol == 0)
                    return StoneSymbol(board[srcRow, srcCol]).ToString() + ColToFile(srcCol).ToString() + ColToFile(desCol).ToString() + (desRow + 1).ToString();//Ngf5
                else if (sameRow == 0 && sameCol >= 0)
                    return StoneSymbol(board[srcRow, srcCol]).ToString() + (srcRow + 1).ToString() + ColToFile(desCol).ToString() + (desRow + 1).ToString();//N3g5
                else
                    return StoneSymbol(board[srcRow, srcCol]).ToString() + ColToFile(srcCol) + ColToFile(desCol) + (desRow + 1).ToString();//Ng3f5
            }//end else if
        }//end method MoveRecord
        public string MoveRecordWithUnicodeSymbols(int srcRow, int srcCol, int desRow, int desCol, out bool isExchang)
        {
            int sameRow = 0;
            int sameCol = 0;
            int count = 0;


            if (board[desRow, desCol] != (int)Home.EMPTY)
                isExchang = true;
            else
                isExchang = false;

            if (StoneSymbol(board[srcRow, srcCol]) == 'P' && board[desRow, desCol] != (int)Home.EMPTY)
                return ColToFile(srcCol).ToString() + ColToFile(desCol).ToString() + (desRow + 1).ToString();
            else if (StoneSymbol(board[srcRow, srcCol]) == 'P' && board[desRow, desCol] == (int)Home.EMPTY)
                return ColToFile(desCol).ToString() + (desRow + 1).ToString();

            for (int i = 0; i < LENGTH; i++)
            {
                for (int j = 0; j < LENGTH; j++)
                {
                    if (board[i, j] == board[srcRow, srcCol] && (!(i == srcRow && j == srcCol)) && MainValidator(i, j, desRow, desCol))
                    {
                        if (i == srcRow && j != srcCol)
                            sameRow++;
                        else if (i != srcRow && j == srcCol)
                            sameCol++;

                        count++;
                    }//end if
                }//end for
            }//end for            



            if (count == 0)//1
                return UnicodeStoneSymbol(board[srcRow, srcCol]).ToString() + ColToFile(desCol).ToString() + (desRow + 1).ToString();//example :Nf5
            else
            {

                if (sameRow == 0 && sameCol == 0)
                    return UnicodeStoneSymbol(board[srcRow, srcCol]).ToString() + ColToFile(srcCol) + ColToFile(desCol) + (desRow + 1).ToString();//Ng3f5           
                else if (sameRow >= 1 && sameCol == 0)
                    return UnicodeStoneSymbol(board[srcRow, srcCol]).ToString() + ColToFile(srcCol).ToString() + ColToFile(desCol).ToString() + (desRow + 1).ToString();//Ngf5
                else if (sameRow == 0 && sameCol >= 0)
                    return UnicodeStoneSymbol(board[srcRow, srcCol]).ToString() + (srcRow + 1).ToString() + ColToFile(desCol).ToString() + (desRow + 1).ToString();//N3g5
                else
                    return UnicodeStoneSymbol(board[srcRow, srcCol]).ToString() + ColToFile(srcCol) + ColToFile(desCol) + (desRow + 1).ToString();//Ng3f5
            }//end else if
        }//end method MoveRecord



        public char StoneSymbol(int stone)
        {
            if ((int)Home.WHITE_PAWN == stone)
                return 'P';
            if ((int)Home.BLACK_PAWN == stone)
                return 'P';
            if ((int)Home.WHITE_KNIGHT == stone)
                return 'N';
            if ((int)Home.BLACK_KNIGHT == stone)
                return 'N';
            if ((int)Home.WHITE_BISHOP == stone)
                return 'B';
            if ((int)Home.BLACK_BISHOP == stone)
                return 'B';
            if ((int)Home.WHITE_ROCK == stone)
                return 'R';
            if ((int)Home.BLACK_ROCK == stone)
                return 'R';
            if ((int)Home.WHITE_QUEEN == stone)
                return 'Q';
            if ((int)Home.BLACK_QUEEN == stone)
                return 'Q';
            if ((int)Home.WHITE_KING == stone)
                return 'K';
            if ((int)Home.BLACK_KING == stone)
                return 'K';
            else
                return '#';
        }//end method StoneSymbol

        protected string UnicodeStoneSymbol(int stone)
        {
            if (stone == (int)Home.BLACK_KING)
            {
                return "\u265A";
            }//end if
            else if (stone == (int)Home.BLACK_QUEEN)
            {
                return "\u265B";
            }//end else
            else if (stone == (int)Home.BLACK_BISHOP)
            {
                return "\u265D";
            }//end else
            else if (stone == (int)Home.BLACK_ROCK)
            {
                return "\u265C";
            }//end else
            else if (stone == (int)Home.BLACK_KNIGHT)
            {
                return "\u265E";
            }//end else
            else if (stone == (int)Home.BLACK_PAWN)
            {
                return "\u265F";
            }//end else
            else if (stone == (int)Home.WHITE_KING)
            {
                return "\u2654";
            }//end else
            else if (stone == (int)Home.WHITE_QUEEN)
            {
                return "\u2655";
            }//end else
            else if (stone == (int)Home.WHITE_BISHOP)
            {
                return "\u2657";
            }//end else
            else if (stone == (int)Home.WHITE_ROCK)
            {
                return "\u2656";
            }//end else
            else if (stone == (int)Home.WHITE_KNIGHT)
            {
                return "\u2658";
            }//end else
            else if (stone == (int)Home.WHITE_PAWN)
            {
                return "\u2659";
            }//end else
            else
                throw new Exception();
        }//end method UnicodeStoneSymbol

        protected bool IsItAWhiteStone(int r, int c)
        {
            if (board[r, c] == (int)Home.WHITE_PAWN || board[r, c] == (int)Home.WHITE_KNIGHT ||
                board[r, c] == (int)Home.WHITE_BISHOP || board[r, c] == (int)Home.WHITE_ROCK ||
                board[r, c] == (int)Home.WHITE_QUEEN || board[r, c] == (int)Home.WHITE_KING)
                return true;
            else
                return false;
        }//end method IsWhiteSotne

        protected bool IsItABlackStone(int r, int c)
        {
            if (board[r, c] == (int)Home.BLACK_PAWN || board[r, c] == (int)Home.BLACK_KNIGHT ||
                board[r, c] == (int)Home.BLACK_BISHOP || board[r, c] == (int)Home.BLACK_ROCK ||
                board[r, c] == (int)Home.BLACK_QUEEN || board[r, c] == (int)Home.BLACK_KING)
                return true;
            else
                return false;
        }//end method IsBlackSotne

        public char ColToFile(int col)
        {
            if (col >= 0 && col < LENGTH)
            {
                if (col == 0)
                    return 'h';
                else if (col == 1)
                    return 'g';
                else if (col == 2)
                    return 'f';
                else if (col == 3)
                    return 'e';
                else if (col == 4)
                    return 'd';
                else if (col == 5)
                    return 'c';
                else if (col == 6)
                    return 'b';
                else if (col == 7)
                    return 'a';
                throw new Exception();
            }//end if
            else
                throw new Exception();

        }//end method ColToFile


        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcRow"></param>
        /// <param name="srcCol"></param>
        /// <param name="desRow"></param>
        /// <param name="desCol"></param>
        /// <param name="moveText"></param>
        /// <param name="moveType"></param>
        /// <returns>successfully/faild</returns>
        public bool MainGUICooperator(int srcRow, int srcCol, int desRow, int desCol,out string moveText,out MoveType moveType,bool UnicodeSymbol=true)
        {
            if (MainValidator(srcRow, srcCol, desRow, desCol))
            {
                bool isExchange;
                //string moveText1 = MoveRecord(srcRow, srcCol, desRow, desCol, out isExchange);MoveRecordWithUnicodeSymbols
                string moveText1 = UnicodeSymbol?MoveRecordWithUnicodeSymbols(srcRow, srcCol, desRow, desCol, out isExchange): MoveRecord(srcRow, srcCol, desRow, desCol, out isExchange);
                MoveType moveType1 = MainMove(srcRow, srcCol, desRow, desCol);
                Turn t = Turn == Turn.WHITE ? Turn.BLACK : Turn.WHITE;

                if (moveType1 == MoveType.O_O)
                {
                    moveText1 = "O-O";
                }//end if
                else if (moveType1 == MoveType.O_O_O)
                {
                    moveText1 = "O-O-O";
                }//end else if
                else if (moveType1 == MoveType.EnPassant)
                {
                    moveText1 = moveText1.Replace(moveText1.Substring(moveText1.Length - 2),ColToFile(srcCol) + "x" + moveText1.Substring(moveText1.Length - 2));
                }//end else if
                else if (moveType1 == MoveType.PROMOTION)
                {
                    if (isExchange)
                    {
                        moveText1 = moveText1.Replace(moveText1.Substring(moveText1.Length - 2), "x" + moveText1.Substring(moveText1.Length - 2));
                    }//end if
                    moveText1 += "=Q";
                }//end else if
                else if (moveType1 == MoveType.NORMAL)
                {
                    if (isExchange)
                    {
                        moveText1 = moveText1.Replace(moveText1.Substring(moveText1.Length - 2), "x" + moveText1.Substring(moveText1.Length - 2));
                    }//end if
                }//end else

                UpdateStatus();

                if (Status == Status.WHITE_WON || Status == Status.BLACK_WON)
                {
                    moveText1 += "#";
                    if (Status == Status.WHITE_WON)
                    {
                        moveText1 += " 1-0";
                    }//end if
                    else
                    {
                        moveText1 += " 0-1";
                    }//end else
                }
                else if (IsInCheck())
                {
                    moveText1 += "+";
                }

                if (Status == Status.DRAW)
                {
                    moveText1 += " 1/2-1/2";
                }

                moveText = moveText1;
                moveType = moveType1;                

                return true;
            }//end if
            else
            {
                moveText = string.Empty;
                moveType = MoveType.NORMAL;
                return false;
            }//end else
        }//end method MainGUICooperator

    }//end class ChessAnalzyer


    public class ThreefoldRepetition
    {
        public const int LENGTH = 8;
        public int[,] Board;
        public int CountOfRepetition;

        public ThreefoldRepetition(int[,] board)
        {
            Board = new int[LENGTH, LENGTH];
            CountOfRepetition = 1;
            for (int r = 0; r < LENGTH; r++)
            {
                for (int c = 0; c < LENGTH; c++)
                {
                    Board[r, c] = board[r, c];
                }
            }
        }

        public bool Equivalent(int[,] board)
        {
            for (int i = 0; i < LENGTH; i++)
            {
                for (int j = 0; j < LENGTH; j++)
                {
                    if (board[i, j] != Board[i, j])
                        return false;
                }
            }
            return true;
        }

        public ThreefoldRepetition CopyElementsAndAtrr()
        {
            int[,] board = new int[LENGTH, LENGTH];

            for (int i = 0; i < LENGTH; i++)
            {
                for (int j = 0; j < LENGTH; j++)
                {
                    board[i, j] = Board[i, j];
                }
            }

            ThreefoldRepetition th = new ThreefoldRepetition(board);
            th.CountOfRepetition = CountOfRepetition;

            return th;
        }

    }//end class ThreefoldRepetition

}//end namespace Tataiee.ChessProject.Analyzer
