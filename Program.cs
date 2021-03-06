﻿using System;
using ChessConsole.Board;
using ChessConsole.Board.Exceptions;
using ChessConsole.Game;
using ChessConsole.View;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();
                while (!match.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.ShowMatch(match);

                        Console.WriteLine();
                        Console.Write("Posição Origem: ");
                        Position source = Screen.ReadChessPosition().ToPosition();
                        match.ValidateOriginPosition(source);

                        bool[,] possiblePositions = match.Chessboard.Piece(source).PossibleMoves();
                    
                        Console.Clear();
                        Screen.ShowBoard(match.Chessboard, possiblePositions);
                        Console.WriteLine();
                        Console.Write("Posição Destino: ");
                        Position target  = Screen.ReadChessPosition().ToPosition();
                        match.ValidateDestinationPosition(source, target);
                    
                        match.PerformPlay(source, target);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Pressione ENTER ");
                        Console.ReadLine();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Posição inexistente! Insira uma posição correta (ex. a1)");
                        Console.WriteLine("Pressione ENTER ");
                        Console.ReadLine();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Formato invalido! Insira uma posição correta (ex. a1)");
                        Console.WriteLine("Pressione ENTER ");
                        Console.ReadLine();
                    }

                }
                Console.Clear();
                Screen.ShowMatch(match);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
