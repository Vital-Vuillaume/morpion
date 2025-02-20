using System;

namespace ConsoleApp4
{
    internal class Program
    {
        static string[,] board = {
            { " 0 ", " 0 ", " 0 " },
            { " 0 ", " 0 ", " 0 " },
            { " 0 ", " 0 ", " 0 " }
        };
        
        static bool finish = false;
        static bool alreadyFinish = false;
        
        static void Main(string[] args)
        {
            bool playerX = true;
            
            while(!finish)
            {
                ShowBoard();
    
                bool validInput = false;
    
                while(!validInput)
                {
                    try
                    {
                        int input1 = Convert.ToInt32(Console.ReadLine());
                        int input2 = Convert.ToInt32(Console.ReadLine());
                        
                        if(board[input1, input2] == " 0 ")
                        {
                            if(playerX)
                            {
                                board[input1, input2] = " x ";
                                playerX = false;
                            } else {
                                board[input1, input2] = " y ";
                                playerX = true;
                            }
                            
                            validInput = true;
                        } else {
                            Console.WriteLine("Already taken");
                        }
                    }
                    catch(Exception ex) 
                    {
                        Console.WriteLine("A number between 0 and 3");
                        validInput = false;
                    }
                }
                
                Verify();
            }
        }
        
        static void ShowBoard()
        {
            Console.WriteLine();
            
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
            
            Console.WriteLine();
        }
        
        static void Verify()
        {
            int nbZero = 0;
            
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != " 0 ")
                {
                    Win(board[i, 0]);
                } else if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != " 0 ")
                {
                    Win(board[0, i]);
                } else
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if(board[i, j] != " 0 ")
                        {
                            nbZero++;
                        }
                    }
                }
            }
            
            if(nbZero >= board.Length)
            {
                Win("egal");
            } else if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != " 0 " || board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != " 0 ")
            {
                Win(board[0, 2]);
            }
        }

        static void Win(string playerWin)
        {
            if(!alreadyFinish)
            {
                ShowBoard();
                
                finish = true;
                
                string msg = "";
    
                if(playerWin == " x ")
                {
                    msg = "Player x win";
                } else if(playerWin == " y ")
                {
                    msg = "Player y win";
                } else if(playerWin == "egal")
                {
                    msg = "it's egal";
                }
                
                Console.WriteLine(msg);
            }
            
            alreadyFinish = true;
        }
    }
}