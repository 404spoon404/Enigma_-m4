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
        string[] dropdowns = { "drpintrotI", "drpintrotII", "drpintrotIII", "drpintrotIV", "drpoutrotI", "drpoutrotII", "drpoutrotIII", "drpoutrotIV" };
        string[] showcurrentlables = { "lblcurrentI", "lblcurrentII", "lblcurrentIII", "lblcurrentIV" };
        int[] rotorvalue = new int[5];
        int[] rotoroffset = new int[5];


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
        }
            
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void txbrotI_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbrotII_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbrotIII_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbrotIV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbukw_TextChanged(object sender, EventArgs e)
        {

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
        }

        private void drpoutrotII_SelectedIndexChanged(object sender, EventArgs e)
        {
            rotoroffset[1] = Convert.ToInt32(drpoutrotII.SelectedItem);
        }

        private void drpoutrotIII_SelectedIndexChanged(object sender, EventArgs e)
        {
            rotoroffset[2] = Convert.ToInt32(drpoutrotIII.SelectedItem);
        }

        private void drpoutrotIV_SelectedIndexChanged(object sender, EventArgs e)
        {
            rotoroffset[3] = Convert.ToInt32(drpoutrotIV.SelectedItem);
                //for testing
            //MessageBox.Show(rotoroffset[3].ToString());
        }
    }
}
