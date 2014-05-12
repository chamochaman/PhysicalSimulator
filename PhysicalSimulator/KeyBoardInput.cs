using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace PhysicalSimulator
{
    class KeyBoardInput
    {
        private Dictionary<char, bool> PressedKeys;
        public KeyBoardInput()
        {
            this.PressedKeys = new Dictionary<char, bool>();
            for (char i = '0'; i <= '9'; ++i)
            {
                PressedKeys.Add(i, false);
            }
            PressedKeys.Add('-', false);
        }

        public string getCurrentKeyboardInput(string input, int size)
        {
            var keys = Keyboard.GetState().GetPressedKeys();

            foreach (var key in keys)
            {
                var currentKey = getKey(key);

                if (currentKey == "")
                    continue;

                if (PressedKeys[currentKey[0]] == false)
                {
                    if (currentKey == "-" && input.Length > 0)
                        input = input.Remove(input.Length - 1, 1);
                    else if(input.Length < size)
                        input = input + currentKey;
                    PressedKeys[currentKey[0]] = true;
                }                
            }

            activedKeys();

            return input;
        }

        private void activedKeys()
        {
            if (Keyboard.GetState().IsKeyUp(Keys.NumPad0))
                PressedKeys['0'] = false;
            if (Keyboard.GetState().IsKeyUp(Keys.NumPad1))
                PressedKeys['1'] = false;
            if (Keyboard.GetState().IsKeyUp(Keys.NumPad2))
                PressedKeys['2'] = false;
            if (Keyboard.GetState().IsKeyUp(Keys.NumPad3))
                PressedKeys['3'] = false;
            if (Keyboard.GetState().IsKeyUp(Keys.NumPad4))
                PressedKeys['4'] = false;
            if (Keyboard.GetState().IsKeyUp(Keys.NumPad5))
                PressedKeys['5'] = false;
            if (Keyboard.GetState().IsKeyUp(Keys.NumPad6))
                PressedKeys['6'] = false;
            if (Keyboard.GetState().IsKeyUp(Keys.NumPad7))
                PressedKeys['7'] = false;
            if (Keyboard.GetState().IsKeyUp(Keys.NumPad8))
                PressedKeys['8'] = false;
            if (Keyboard.GetState().IsKeyUp(Keys.NumPad9))
                PressedKeys['9'] = false;
            if (Keyboard.GetState().IsKeyUp(Keys.Delete))
                PressedKeys['-'] = false;
        }

        private string getKey(Keys key)
        {
            switch (key)
            {
                case Keys.NumPad0:
                    return "0";
                case Keys.NumPad1:
                    return "1";
                case Keys.NumPad2:
                    return "2";
                case Keys.NumPad3:
                    return "3";
                case Keys.NumPad4:
                    return "4";
                case Keys.NumPad5:
                    return "5";
                case Keys.NumPad6:
                    return "6";
                case Keys.NumPad7:
                    return "7";
                case Keys.NumPad8:
                    return "8";
                case Keys.NumPad9:
                    return "9";
                case Keys.D0:
                    return "0";
                case Keys.D1:
                    return "1";
                case Keys.D2:
                    return "2";
                case Keys.D3:
                    return "3";
                case Keys.D4:
                    return "4";
                case Keys.D5:
                    return "5";
                case Keys.D6:
                    return "6";
                case Keys.D7:
                    return "7";
                case Keys.D8:
                    return "8";
                case Keys.D9:
                    return "9";
                case Keys.Delete:
                    return "-";
                

                default:
                    return "";

            }
        }
    }
}
