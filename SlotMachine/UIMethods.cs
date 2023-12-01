﻿using Microsoft.VisualBasic;
using SlotMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class UIMethods
    {
        public static void DisplayGameRules()
        {
            Console.WriteLine("\t\t\t=SLOT MACHINE=");
            Console.WriteLine($"This is a {Constants.SLOT_MACHINE_ROWS} by {Constants.SLOT_MACHINE_COLUMNS} slot machine.");
            Console.WriteLine("Insert credit amount then choose between three game types, Horizontal(H), Vertical(V) or Diagonal(D).");
            Console.WriteLine($"Each round you will be asked to bet either {Constants.BET_ONE_DOLLAR}, {Constants.BET_TWO_DOLLARS} up to {Constants.SLOT_MACHINE_ROWS} lines.");
            Console.WriteLine("Credit will be deducted from your balance proportionally with the number of lines you're playing, and " +
                $"will be added back into your account in case of a win for each matching line (e.g.match {Constants.BET_TWO_DOLLARS} then win ${Constants.BET_TWO_DOLLARS})");
            Console.WriteLine("Press any key to start!");
            Console.ReadKey();
            Console.Clear();
        }
        public static GameMode ChooseGameMode()
        {
            GameMode gameModeEnum = GameMode.invalid;

            while (gameModeEnum == GameMode.invalid)
            {
                Console.WriteLine("Choose game mode: (h, v, d)");
                ConsoleKeyInfo userAnswer = Console.ReadKey();
                char userGameMode = userAnswer.KeyChar;
                Console.Clear();
                Console.WriteLine();
                switch (userGameMode)
                {
                    case 'h': gameModeEnum = GameMode.horizontal; break;
                    case 'v': gameModeEnum = GameMode.vertical; break;
                    case 'd': gameModeEnum = GameMode.diagonal; break;
                    default: gameModeEnum = GameMode.invalid;
                        Console.WriteLine("Selection not available!"); break;
                }
            }
            return (GameMode)gameModeEnum;
        }
        public static int SetBetAmount(GameMode chosenMode)
        {
            int betAmount = 0;
            bool betAmountPass = false;
                       
            switch (chosenMode)
            {
                case GameMode.horizontal:
                case GameMode.vertical:
                    while(!betAmountPass)
                    {
                        Console.WriteLine($"How many lines would you like to play?: ({Constants.BET_ONE_DOLLAR} to {Constants.SLOT_MACHINE_ROWS})");                                                              
                        ConsoleKeyInfo getAnswer = Console.ReadKey();
                        betAmount = int.Parse(getAnswer.KeyChar.ToString());
                        Console.Clear();

                        if (betAmount >= Constants.BET_ONE_DOLLAR && betAmount <= Constants.SLOT_MACHINE_ROWS)
                        {
                            betAmountPass = true;
                        }
                        else
                        {
                            betAmountPass = false;
                            Console.WriteLine("Selection not available");
                        }
                    }                    
                    break;
                case GameMode.diagonal:
                    betAmount = Constants.BET_TWO_DOLLARS;
                    break;
            }
            return betAmount;
        }
    }
}