using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace engima_M4
{
    class Enigmahardware
    {
        /*the class will get the following variables from the form
         * rotor1choice, rotor2choice, rotor3choice,rotor4choice,ukwchoice
         * rotor1current, rotor2current, rotor3current, rotor4current
         * input
         * The input will be passed to the right rotor (if statements?) and continue to the next
         * every rotor is used twice once forward once backwards
         * So rot1,rot2,rot3,rot4,umkw,rot4,rot3,rot2,rot1
         * 
         * Vars per rotor position
         * rot1 choice, rot2 choice, rot3 choice, rot4 choice, ukw choice
         * rot1 secrpos, rot2 secrpos rot3 secrpos rot4 secrpos
         * rot1 vispos, rot2 vispos, rot3 vispos, rot4 vispos
         */


        /* rotor is currently selected rotor for each position in machine (5)
         * rotorvalue is the current letter show in the rotor screen (4)
         * rotor offset is the difference between the shown rotor and the output
         * keypress is the current letter to encrypt
        */
        public Enigmahardware(int[] rotor, int[] rotorvalue, int[] rotoroffset, int keypress)
        {
            int input = keypress;
            int encrypted = 0;

            //The loop to put the value to be encrypted trough the rotors
            //5 x forward (4 rotors and UKW)
            for (int i = 0; i < 5; i++)
            {
                string namerotor = "rotor" + rotor[i].ToString();
                input = RotorConversionForward(input, rotorvalue[i], rotoroffset[i], namerotor);
            }
            //4 x backward (4 rotors (UKW is allready done))
            for (int i = 4; i > 0; i--)
            {
                string namerotor = "rotor" + rotor[i].ToString();
                input = RotorConversionBackward(input, rotorvalue[i], rotoroffset[i], namerotor);
            }
            // advance the rotor as needed (every 26 rotations of each)
            //Duh every rotor, not one...
            foreach (int i in rotor)
                rotorvalue[i + 1] = RotorSwitch(rotorvalue[i], rotor[i]);

            //use the plugboard (only changes output if configured(probably...))
            encrypted = letters[input];


        }

        //The arrays for the rotor configuration
        int[] rotor1 = { 5, 11, 13, 6, 12, 7, 4, 17, 22, 26, 14, 20, 15, 23, 25, 8, 24, 21, 19, 16, 1, 9, 2, 18, 3, 10 };
        int[] rotor2 = { 1, 10, 4, 11, 19, 9, 18, 21, 24, 2, 12, 8, 23, 20, 13, 3, 17, 7, 26, 14, 16, 25, 6, 22, 15, 5 };
        int[] rotor3 = { 2, 4, 6, 8, 10, 12, 3, 16, 18, 20, 24, 22, 26, 14, 25, 5, 9, 23, 7, 1, 11, 13, 21, 19, 17, 15 };
        int[] rotor4 = { 5, 19, 15, 22, 16, 26, 10, 1, 25, 17, 21, 9, 18, 8, 24, 12, 14, 6, 20, 7, 11, 4, 3, 13, 23, 2 };
        int[] rotor5 = { 22, 26, 2, 18, 7, 9, 20, 25, 21, 16, 19, 4, 14, 8, 12, 24, 1, 23, 13, 10, 17, 15, 6, 5, 3, 11 };
        int[] rotor6 = { 10, 16, 7, 22, 15, 21, 13, 6, 25, 17, 2, 5, 14, 8, 26, 18, 4, 11, 1, 19, 24, 12, 9, 3, 20, 23 };
        int[] rotor7 = { 14, 26, 10, 8, 7, 18, 3, 24, 13, 25, 19, 23, 2, 15, 21, 6, 1, 9, 22, 12, 16, 5, 11, 17, 4, 20 };
        int[] rotor8 = { 6, 11, 17, 8, 20, 12, 24, 15, 3, 2, 10, 19, 16, 4, 26, 18, 1, 13, 5, 23, 14, 9, 21, 25, 7, 22 };
        int[] rotor9 = { 12, 5, 25, 10, 22, 3, 14, 9, 24, 23, 16, 2, 17, 13, 4, 18, 20, 1, 11, 26, 7, 6, 21, 8, 15, 19 };
        int[] rotor10 = { 6, 19, 15, 11, 1, 14, 21, 5, 18, 8, 13, 2, 20, 9, 25, 3, 23, 12, 17, 16, 26, 24, 22, 7, 10, 4 };
        int[] rotor11 = { 5, 14, 11, 17, 1, 21, 25, 23, 10, 9, 3, 15, 16, 2, 12, 13, 4, 24, 26, 22, 6, 20, 8, 18, 7, 19 };
        int[] rotor12 = { 18, 4, 15, 2, 10, 14, 20, 11, 22, 5, 8, 13, 12, 6, 3, 23, 26, 1, 24, 7, 25, 9, 16, 19, 21, 17 };
        int[] letters = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };

        //The function to convert a letter (input) to the value after the rotor, going forward.
        // NOTE, does this not return a value 1 to high
        int RotorConversionForward(int input, int rotorvalue, int rotoroffset, string namerotor)
        {
            //increase the starting value (letter) according to the current rotor settings and postion 
            int startletter = (input + rotoroffset + rotorvalue) % 26;
            //Return the corresponding value from the right array
            int encrypt = namerotor[startletter];
            return encrypt;
        }

        //The function to convert a letter (input) to the value after the rotor, going backwards.
        // NOTE, does this not return a value 1 to high
        int RotorConversionBackward(int input, int rotorvalue, int rotoroffset, string namerotor)
        {

            int currentletter = 0;
            //increase the starting value (letter) according to the current rotor settings and postion 
            switch (namerotor)
            {
                case "rotor1":
                    currentletter = Array.IndexOf(rotor1, input);
                    break;
                case "rotor2":
                    currentletter = Array.IndexOf(rotor2, input);
                    break;
                case "rotor3":
                    currentletter = Array.IndexOf(rotor3, input);
                    break;
                case "rotor4":
                    currentletter = Array.IndexOf(rotor4, input);
                    break;
                case "rotor5":
                    currentletter = Array.IndexOf(rotor5, input);
                    break;
                case "rotor6":
                    currentletter = Array.IndexOf(rotor6, input);
                    break;
                case "rotor7":
                    currentletter = Array.IndexOf(rotor7, input);
                    break;
                case "rotor8":
                    currentletter = Array.IndexOf(rotor8, input);
                    break;
                case "rotor9":
                    currentletter = Array.IndexOf(rotor9, input);
                    break;
                case "rotor10":
                    currentletter = Array.IndexOf(rotor10, input);
                    break;
                case "rotor11":
                    currentletter = Array.IndexOf(rotor11, input);
                    break;
                case "rotor12":
                    currentletter = Array.IndexOf(rotor12, input);
                    break;
            }

            //is this + or -???
            //Return the corresponding value based on the right array
            int encrypt = (currentletter + rotorvalue + rotoroffset) % 26;
            return encrypt;
        }

        //This wil change one value in the array for the plugboard and will return the changed array
        //called every time a letter in the plugboard is changed.
        void Plugboardconfig(int baseletter, int changeletter)
        {
            //gets postion of letter in array and changes the value
            letters[baseletter] = changeletter;
        }

        //takes the last value from the rotors (input) and changes it to the value stored in the array.
        int Plugboardoutput(int input, int[] plugboard)
        {
            int encrypt = plugboard[input];
            return encrypt;
        }

        //some code for the rotation of the rotor
        // At certain points in the rotor, the next rotor has to advance. 1 value for rotors 1,2,3,4 and 5
        // 2 values for 6,7 and 8

        // 17 5 22 10 26 13
        int RotorSwitch(int currentval, int rotor)
        {
            if (currentval == 17 && rotor == 1)
            {
                currentval = +1;
            }
            else if (currentval == 5 && rotor == 2)
            {
                currentval = +1;
            }
            else if (currentval == 22 && rotor == 3)
            {
                currentval = +1;
            }
            else if (currentval == 10 && rotor == 4)
            {
                currentval = +1;
            }
            else if (currentval == 26 && rotor == 5)
            {
                currentval = 1;
            }
            else if ((currentval == 13 || currentval == 26) && (rotor == 6 || rotor == 7 || rotor == 8))
            {
                currentval = 1;
            }
            return currentval;
        }
    }
}
