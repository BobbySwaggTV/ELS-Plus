﻿using CitizenFX.Core;
using CitizenFX.Core.Native;
using ELS.configuration;
using ELS.NUI;
using System;


namespace ELS.Light
{
    public class LightPattern
    {
        /// <summary>
        /// List of Patterns More to be added
        /// </summary>
        public static uint[] Patterns = {
            858993459,
            859002155,
            2863311530,
            1431655765,
            3435965013,
            3435973836,
            3817748650,
            477218645,
            2694881440,
            168430090,
            84215045,
            1347440720
        };

        /// <summary>
        /// List of patterns in binary string format
        /// </summary>
        public static string[] StringPatterns =
        {
            "0101010100000000",
            "0000000001010101",
            "0101000001010000",
            "0000010100000101",
            "0101010101010101",
            "1010101010101010",
            "0011001100110011",
            "1100110011001100",
            "1110111011101110",
            "0111011101110111",
            "0001000100010001",
            "1000100010001000",
            "0100010001000100",
            "0110011001100110",
            "1011001100110011",
            "1001100110011001",
            "1000000110000001",
            "0111111001111110",
            "0011111100111111",
            "1110001110001110",
            "0001110001110001",
            "1010000010100000",
            "0101000001010000",
            "1000011111111111",
            "1100001111111111",
            "1111000011111111",
            "1111100001111111",
            "1111110000111111",
            "1111111000011111",
            "1111111100001111",
            "1111111110000111",
            "1111111111000011",
            "1111111111100001",
            "1111111111110000",
            "0111111111111000",
            "0011111111111100",
            "0001111111111110",
            "0000111111111111",
            "0000000011111111",
            "1111111100000000"
        };

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string SweepPattern()
        {
            return StringPatterns[33] + Reverse(StringPatterns[33]);
        }

        public static string RandomPattern()
        {
            Random rnd = new Random(StringPatterns.Length);
            return StringPatterns[rnd.Next() - 1];
        }

        internal static async void RunLightPattern(Vehicle vehicle, int extra, string patt, string color, int delay)
        {
            string light = $"#extra{extra}";
            do
            {
                foreach (char c in patt.ToCharArray())
                {
                    if (!ElsUiPanel._runPattern)
                    {
                        break;
                    }
                    if (c.Equals('0'))
                    {
                        ElsUiPanel.SendLightData(false, light, "");
                        vehicle.ToggleExtra(extra, false);
                    }
                    else
                    {
                        ElsUiPanel.SendLightData(true, light, color);
                        vehicle.ToggleExtra(extra, true);
                    }
                    await ELS.Delay(delay);
                    //ElsUiPanel.SendLightData(false, light, "");
                }
            } while (ElsUiPanel._runPattern);
            ElsUiPanel.SendLightData(false, light, "");
            vehicle.ToggleExtra(extra, false);
        }

        public static async void RunLightPattern(Vehicle vehicle, int extra, uint upatt, string color, int delay)
        {
            string patt = Convert.ToString(upatt, 2);
            string light = $"#extra{extra}";
            do
            {
                foreach (char c in patt.ToCharArray())
                {
                    if (!ElsUiPanel._runPattern)
                    {
                        break;
                    }
                    if (c.Equals('0'))
                    {
                        ElsUiPanel.SendLightData(false, light, "");
                        vehicle.ToggleExtra(extra, false);
                    }
                    else
                    {
                        ElsUiPanel.SendLightData(true, light, color);
                        vehicle.ToggleExtra(extra, true);
                    }
                    await ELS.Delay(delay);
                }
            } while (ElsUiPanel._runPattern);
            ElsUiPanel.SendLightData(false, light, "");
            vehicle.ToggleExtra(extra, false);
        }
    }
}
