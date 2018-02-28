using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
         * rotorvalue is the current letter show in the rotor screen (5)
         * rotor offset is the difference between the shown rotor and the output (26)
         * keypress is the current letter to encrypt
        */
        public Enigmahardware(int[] savedrotor)
        {
            _Savedrotor = savedrotor;
        }

        int[] _Savedrotor = new int[5];
        int plusone = 0;

        public int Encrypt (int[] rotor, int[] rotorvalue, int[] rotoroffset, int keypress)
        {
            int input = keypress;
            int encrypted = 0;
            //Form _Form = form;
            
            //The loop to put the value to be encrypted trough the rotors
            //5 x forward (4 rotors and UKW)
            for (int i = 0; i < 5; i++)
            {
                string namerotor = "rotor" + rotor[i].ToString();
                input = RotorConversionForward(input, rotorvalue[i], rotoroffset[i], namerotor);
                //MessageBox.Show("forward1" + namerotor.ToString() + input);
            }
            //4 x backward (4 rotors (UKW is allready done))
            for (int i = 3; i >= 0; i--)
            {
                string namerotor = "rotor" + rotor[i].ToString();
                input = RotorConversionBackward(input, rotorvalue[i], rotoroffset[i], namerotor);
                //MessageBox.Show("back" + namerotor.ToString() + input);
            }
            // advance the rotor as needed (every 26 rotations of each)
            
            //MessageBox.Show(input.ToString());

            int counter = 0;
            foreach (int i in rotor)
            {
                rotorvalue[counter] = RotorSwitch(rotorvalue[counter], rotor[counter], counter);
                saverotor(rotorvalue, counter);
                counter++;
                
            }
            plusone = 0;
            //use the plugboard (only changes output if configured(probably...))

            encrypted = letters[input];
            return encrypted;
            
        }

        public int[] saverotor(int[] rotorstate, int counter)
        {
            _Savedrotor[counter] = rotorstate[counter];
            return _Savedrotor;
        }

                
        //The arrays for the rotor configuration
        int[] rotor1 = { 4, 10, 12, 5, 11, 6, 3, 16, 21, 25, 13, 19, 14, 23, 24, 9, 23, 20, 18, 15, 0, 8, 1, 17, 2, 9 };
        int[] rotor2 = { 0, 9, 3, 10, 18, 8, 17, 20, 23, 1, 11, 7, 22, 19, 12, 2, 16, 6, 25, 13, 15, 24, 5, 21, 14, 4 };
        int[] rotor3 = { 1, 3, 5, 7, 9, 11, 2, 15, 17, 19, 23, 21, 25, 13, 24, 4, 8, 22, 6, 0, 10, 12, 20, 18, 16, 14 };
        int[] rotor4 = { 4, 18, 14, 21, 15, 25, 9, 0, 24, 16, 20, 8, 17, 7, 23, 11, 13, 5, 19, 6, 10, 3, 2, 12, 22, 1 };
        int[] rotor5 = { 21, 25, 1, 17, 6, 8, 19, 24, 20, 15, 18, 3, 13, 7, 11, 23, 0, 22, 12, 9, 16, 14, 5, 4, 2, 10 };
        int[] rotor6 = { 9, 15, 6, 21, 14, 20, 12, 5, 24, 16, 1, 4, 13, 7, 25, 17, 3, 10, 0, 18, 23, 11, 8, 2, 19, 22 };
        int[] rotor7 = { 13, 25, 9, 7, 6, 17, 2, 23, 12, 24, 18, 22, 1, 14, 20, 5, 0, 8, 21, 11, 15, 4, 10, 16, 3, 19 };
        int[] rotor8 = { 5, 10, 16, 7, 19, 11, 23, 14, 2, 1, 9, 18, 15, 3, 25, 17, 0, 12, 4, 22, 13, 8, 20, 24, 6, 21 };
        int[] rotor9 = { 11, 4, 24, 9, 21, 2, 13, 8, 23, 22, 15, 1, 16, 12, 3, 17, 19, 0, 10, 25, 6, 5, 20, 7, 14, 18 };
        int[] rotor10 = { 5, 18, 14, 10, 0, 13, 20, 4, 17, 7, 12, 1, 19, 8, 24, 2, 22, 11, 16, 15, 25, 23, 21, 6, 9, 3 };
        int[] rotor11 = { 4, 13, 10, 16, 0, 20, 24, 22, 9, 8, 2, 14, 15, 1, 11, 12, 3, 23, 25, 21, 5, 19, 7, 17, 6, 18 };
        int[] rotor12 = { 17, 3, 14, 1, 9, 13, 19, 10, 21, 4, 7, 12, 11, 5, 2, 22, 25, 0, 23, 6, 24, 8, 15, 18, 20, 16 };
        int[] letters = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };

        //The function to convert a letter (input) to the value after the rotor, going forward.
        // NOTE, does this not return a value 1 to high
        int RotorConversionForward(int input, int rotorvalue, int rotoroffset, string namerotor)
        {
            //increase the starting value (letter) according to the current rotor settings and postion 
            int startletter = (input + rotoroffset + rotorvalue) % 25;
            //Return the corresponding value from the right array
            int encrypt = 0;
            //MessageBox.Show("2"+startletter.ToString());
            switch (namerotor)
            {
                case "rotor1":
                    encrypt = rotor1[startletter];
                    break;
                case "rotor2":
                    encrypt = rotor2[startletter];
                    break;
                case "rotor3":
                    encrypt = rotor3[startletter];
                    break;
                case "rotor4":
                    encrypt = rotor4[startletter];
                    break;
                case "rotor5":
                    encrypt = rotor5[startletter];
                    break;
                case "rotor6":
                    encrypt = rotor6[startletter];
                    break;
                case "rotor7":
                    encrypt = rotor7[startletter];
                    break;
                case "rotor8":
                    encrypt = rotor8[startletter];
                    break;
                case "rotor9":
                    encrypt = rotor9[startletter];
                    break;
                case "rotor10":
                    encrypt = rotor10[startletter];
                    break;
                case "rotor11":
                    encrypt = rotor11[startletter];
                    break;
                case "rotor12":
                    encrypt = rotor12[startletter];
                    break;
            }


            //ERROR ERROR ERROR ERROR ERROR (outputting nonsense) ERROR ERROR ERROR ERROR ERROR
            //MessageBox.Show(namerotor[startletter].ToString());
            //int encrypt = namerotor[startletter];
            //MessageBox.Show("encrypt 3" + encrypt.ToString() + namerotor.ToString());
            return encrypt;
            
        }

        //The function to convert a letter (input) to the value after the rotor, going backwards.
        // NOTE, does this not return a value 1 to high
        int RotorConversionBackward(int input, int rotorvalue, int rotoroffset, string namerotor)
        {
            //MessageBox.Show(input.ToString());
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
                    currentletter = Array.IndexOf(rotor3, input );
                    break;
                case "rotor4":
                    currentletter = Array.IndexOf(rotor4, input);
                    break;
                case "rotor5":
                    currentletter = Array.IndexOf(rotor5, input );
                    break;
                case "rotor6":
                    currentletter = Array.IndexOf(rotor6, input );
                    break;
                case "rotor7":
                    currentletter = Array.IndexOf(rotor7, input );
                    break;
                case "rotor8":
                    currentletter = Array.IndexOf(rotor8, input );
                    break;
                case "rotor9":
                    currentletter = Array.IndexOf(rotor9, input );
                    break;
                case "rotor10":
                    currentletter = Array.IndexOf(rotor10, input );
                    break;
                case "rotor11":
                    currentletter = Array.IndexOf(rotor11, input );
                    break;
                case "rotor12":
                    currentletter = Array.IndexOf(rotor12, input );
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
        //did this change with the array changes?
        public int RotorSwitch(int currentval, int rotor, int counter)
        {
            //Add 1 to the first rotor 
            currentval = currentval % 25;
            switch (counter)
            {
                case 0:
                    currentval++;
                    break;
                case 1:
                    currentval = currentval + plusone;
                    plusone = 0;
                    break;
                case 2:
                    currentval = currentval + plusone;
                    plusone = 0;
                    break;
                case 3:
                    currentval = currentval + plusone;
                    plusone = 0;
                    break;
                case 4:
                    currentval = currentval + plusone;
                    plusone = 0;
                    break;
            }

            if (currentval == 17 && rotor == 1)
            {
                plusone++;
                
            }
            else if (currentval == 5 && rotor == 2)
            {
                plusone++;
            }
            else if (currentval == 22 && rotor == 3)
            {
                plusone++;
            }
            else if (currentval == 10 && rotor == 4)
            {
                plusone++;
            }
            else if (currentval == 26 && rotor == 5)
            {
                plusone++;
            }
            else if ((currentval == 13 || currentval == 26) && (rotor == 6 || rotor == 7 || rotor == 8))
            {
                plusone++;
            }
            
            return currentval;
        }
    }
}
