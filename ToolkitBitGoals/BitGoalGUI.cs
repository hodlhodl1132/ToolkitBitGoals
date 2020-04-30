﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ToolkitBitGoals
{
    public static class BitGoalGUI
    {
        static int frameCounter = 100;
        static int currentBitCounterCached = 0;

        public static void DisplayCounter()
        {
            frameCounter++;

            RecacheCurrentBits();

            Rect rect = new Rect(UI.screenWidth - 360f, 10f, 360f, 28f);

            GameFont old = Text.Font;
            Text.Font = GameFont.Medium;

            Widgets.Label(rect, $"<b><color=#8B0000>Current Bits</color></b>: {currentBitCounterCached}/{ToolkitBitGoalsSettings.bitGoal}");

            Text.Font = old;
        }

        static void RecacheCurrentBits()
        {
            if (frameCounter >= 100)
            {
                frameCounter = 0;

                BitParser bitParser = Current.Game.GetComponent<BitParser>();

                if (bitParser != null)
                {
                    currentBitCounterCached = bitParser.currentBitCounter;
                }
            }
        }
    }
}
