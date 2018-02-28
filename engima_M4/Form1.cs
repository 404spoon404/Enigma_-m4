using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engima_M4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        System.Object[] comboboxoptions = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
        string[] plugboardlabels = { "txbplugA", "txbplugB", "txbplugC", "txbplugD", "txbplugE", "txbplugF", "txbplugG", "txbplugH", "txbplugI", "txbplugJ", "txbplugK", "txbplugL", "txbplugM", "txbplugN", "txbplugO", "txbplugP", "txbplugQ", "txbplugR", "txbplugS", "txbplugT", "txbplugU", "txbplugV", "txbplugW", "txbplugX", "txbplugY", "txbplugZ" };
        string[] dropdowns = { "drpintrotI", "drpintrotII", "drpintrotIII", "drpintrotIV", "drpoutrotI", "drpoutrotII", "drpoutrotIII", "drpoutrotIV" };
        string[] showcurrentlables = { "lblcurrentI", "lblcurrentII", "lblcurrentIII", "lblcurrentIV" };
        int[] rotorvalue = new int[5];
        int[] rotoroffset = new int[5];
        int[] rotorchoice = new int[5];
        int[] savedrotor = new int[5];
        int livecode = 0;
        char output = 'A';
        int[] plugboard = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25};

        private void FillCombo(System.Object[] comboboxoptions, ComboBox boxname)
        {
            for (int i = 0; i <= 25; i++)
            {
                comboboxoptions[i] = i;
            }
            boxname.Items.AddRange(comboboxoptions);
        }
            
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dropdowns.Length; i++)
            {
                //Remember this:
                ComboBox cb = this.Controls.Find(dropdowns[i], true).FirstOrDefault() as ComboBox;
                FillCombo(comboboxoptions, cb);

            }
            lblcurrentI.Text = "A";
            lblcurrentII.Text = "A";
            lblcurrentIII.Text = "A";
            lblcurrentIV.Text = "A";
            txbrotI.Text = "1";
            txbrotII.Text = "2";
            txbrotIII.Text = "3";
            txbrotIV.Text = "10";
            txbukw.Text = "11";
            int[] rotorchoice = { 1, 2, 3, 10, 11 };

        }
        
        

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void txbrotI_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //check for int input, check for value <9 and check for duplicates
                rotorchoice[0] = int.Parse(txbrotI.Text);
                if (rotorchoice[0] > 8 || rotorchoice[0] < 1)
                {
                    MessageBox.Show("The number needs to be between 1 and 8");
                }
                else if (rotorchoice[0] == rotorchoice[1] || rotorchoice[0] == rotorchoice[2])
                {
                    MessageBox.Show("You can only choose every rotor once");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void txbrotII_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //check for int input, check for value <9 and check for duplicates
                rotorchoice[1] = int.Parse(txbrotII.Text);
                if (rotorchoice[1] > 8 || rotorchoice[1] <1)
                {
                    MessageBox.Show("The number needs to be between 1 and 8");
                }
                else if (rotorchoice[1] == rotorchoice[2] || rotorchoice[1] == rotorchoice[0])
                {
                    MessageBox.Show("You can only choose every rotor once");
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void txbrotIII_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //check for int input, check for value <9 and check for duplicates
                rotorchoice[2] = int.Parse(txbrotIII.Text);
                if (rotorchoice[2] > 8 || rotorchoice[2] < 1)
                {
                    MessageBox.Show("The number needs to be between 1 and 8");
                }
                else if (rotorchoice[2] == rotorchoice[1] || rotorchoice[2] == rotorchoice[0])
                {
                    MessageBox.Show("You can only choose every rotor once");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void txbrotIV_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //check for int input, check for value <9 and check for duplicates
                rotorchoice[3] = int.Parse(txbrotIV.Text);
                if (rotorchoice[3] > 10 || rotorchoice[3] < 9)
                {
                    MessageBox.Show("The number needs to be 9 or 10");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void txbukw_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //check for int input, check for value <9 and check for duplicates
                rotorchoice[4] = int.Parse(txbukw.Text);
                if (rotorchoice[4] > 12 || rotorchoice[4] < 11)
                {
                    MessageBox.Show("The number needs to be 11 or 12");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void drpintrotI_SelectedIndexChanged(object sender, EventArgs e)
        {
            rotorvalue[0] = Convert.ToInt32(drpintrotI.SelectedItem);
        }
        
        private void drpintrotII_SelectedIndexChanged(object sender, EventArgs e)
        {
            rotorvalue[1] = Convert.ToInt32(drpintrotII.SelectedItem);
        }

        private void drpintrotIII_SelectedIndexChanged(object sender, EventArgs e)
        {
            rotorvalue[2] = Convert.ToInt32(drpintrotIII.SelectedItem);
        }

        private void drpintrotIV_SelectedIndexChanged(object sender, EventArgs e)
        {
            rotorvalue[3] = Convert.ToInt32(drpintrotIV.SelectedItem);
            //for testing
            //MessageBox.Show(rotorvalue[3].ToString());
        }

        private void drpoutrotI_SelectedIndexChanged(object sender, EventArgs e)
        {
            rotoroffset[0] = Convert.ToInt32(drpoutrotI.SelectedItem);
            byte letter = 65;
            lblcurrentI.Text = Convert.ToChar(letter+ rotoroffset[0]).ToString();
        }

        private void drpoutrotII_SelectedIndexChanged(object sender, EventArgs e)
        {
            rotoroffset[1] = Convert.ToInt32(drpoutrotII.SelectedItem);
            byte letter = 65;
            lblcurrentII.Text = Convert.ToChar(letter + rotoroffset[1]).ToString();
        }

        private void drpoutrotIII_SelectedIndexChanged(object sender, EventArgs e)
        {
            rotoroffset[2] = Convert.ToInt32(drpoutrotIII.SelectedItem);
            byte letter = 65;
            lblcurrentIII.Text = Convert.ToChar(letter + rotoroffset[2]).ToString();
        }

        private void drpoutrotIV_SelectedIndexChanged(object sender, EventArgs e)
        {
            rotoroffset[3] = Convert.ToInt32(drpoutrotIV.SelectedItem);
            byte letter = 65;
            lblcurrentIV.Text = Convert.ToChar(letter + rotoroffset[3]).ToString();
            //for testing
            //MessageBox.Show(rotoroffset[3].ToString());
        }

        private void Liveinput_TextChanged(object sender, EventArgs e)
        {
            //Takes the input from the textfield (any single character value)
            // if a - z capitalize
            // if A - Z make A 1, B 2 and so on
            // if any other character ignore. (no error, just ignore)
            // clear the text field...?


            char halfway;
            char.TryParse(Liveinput.Text.ToUpper(), out halfway);
            try
            {
                //should this be 65? if not why? This will never be 0(if using letters)
                // See livecode -1
                livecode = Convert.ToByte(halfway - 64);
            }
            // IS PROBLEM (See rotor advance)
            catch (Exception exception)
            {

            }
            //for testing
            //MessageBox.Show(livecode.ToString());

            //send all variables to class enigmahardware after input of single letter
            //Add 65 to get an ascii value
            //and return value to txbcurrentout
            int test = new Enigmahardware(savedrotor).Encrypt(rotorchoice, rotorvalue, rotoroffset, livecode-1) + 65;
            output = Convert.ToChar(test);
            txbcurrentout.Text = Convert.ToString(output);
            int lableI = savedrotor[0] + 65;
            output = Convert.ToChar(lableI);
            lblcurrentI.Text = Convert.ToString(output);

            int lableII = savedrotor[1] + 65;
            output = Convert.ToChar(lableII);
            lblcurrentII.Text = Convert.ToString(output);

            int lableIII = savedrotor[2] + 65;
            output = Convert.ToChar(lableIII);
            lblcurrentIII.Text = Convert.ToString(output);

            int lableIV = savedrotor[3] + 65;
            output = Convert.ToChar(lableIV);
            lblcurrentIV.Text = Convert.ToString(output);

            
        }

        private void btnstarttext_Click(object sender, EventArgs e)
        {
            int textchar = 0;
            char toconvert = 'a';
            
            foreach (char character in txbinputtext.Text.ToUpper())
            {
                //Get character from string, change it to an int.
                //put int trough encryption
                //output text in txboutputtext
                textchar = Convert.ToByte(character) -64 ;
                int longoutput = new Enigmahardware(savedrotor).Encrypt(rotorchoice, rotorvalue, rotoroffset, textchar - 1) + 65;
                toconvert = Convert.ToChar(longoutput);
                txboutputtext.Text += toconvert.ToString();

                int lableI = savedrotor[0] + 65;
                output = Convert.ToChar(lableI);
                lblcurrentI.Text = Convert.ToString(output);

                int lableII = savedrotor[1] + 65;
                output = Convert.ToChar(lableII);
                lblcurrentII.Text = Convert.ToString(output);

                int lableIII = savedrotor[2] + 65;
                output = Convert.ToChar(lableIII);
                lblcurrentIII.Text = Convert.ToString(output);

                int lableIV = savedrotor[3] + 65;
                output = Convert.ToChar(lableIV);
                lblcurrentIV.Text = Convert.ToString(output);
            }
        }

        private void plugboardena_CheckedChanged(object sender, EventArgs e)
        {
            if (plugboardena.Checked)
            {
                for (int i = 0; i < plugboardlabels.Length; i++)
                {
                    //Remember this:
                    TextBox tb = this.Controls.Find(plugboardlabels[i], true).FirstOrDefault() as TextBox;
                    tb.Enabled=true;

                }
                
            }
        }

        private void plugboardnot_CheckedChanged(object sender, EventArgs e)
        {
            if (plugboardnot.Checked)
            {
                for (int i = 0; i < plugboardlabels.Length; i++)
                {
                    //Remember this:
                    TextBox tb = this.Controls.Find(plugboardlabels[i], true).FirstOrDefault() as TextBox;
                    tb.Enabled = false;
                }
            }
        }
        
        public void Plugboard (TextBox textbox)
        {
            char plugletter;
            char.TryParse(textbox.Text.ToUpper(), out plugletter);
            try
            {
                livecode = Convert.ToByte(plugletter - 65);
                textbox.Text = plugletter.ToString();
                string textname = textbox.Name;
                //MessageBox.Show(textname);
                //check that the plug is not referencing itself
                if (livecode == Array.IndexOf(plugboardlabels, textname))
                    {
                    MessageBox.Show("Plug cannot reference itself");
                    }
                //change the value in the corresponding textbox
                //and change the corresponding value in array
                string textboxvalue = plugboardlabels[livecode];
                int arrayposition = Array.IndexOf(plugboardlabels, textboxvalue);
                plugboard[arrayposition] = Array.IndexOf(plugboardlabels, textname);
                txbplugB.Text = arrayposition.ToString();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void txbplugA_TextChanged(object sender, EventArgs e)
        {
            Plugboard(txbplugA);
            plugboard[0] = livecode;
        }
    }
}
