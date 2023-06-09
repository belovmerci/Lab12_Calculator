﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; // allows for DataTable().Compute()
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab12_Calculator
{
    public partial class Form1 : Form
    {
        private string currentCalculation = "";
        public Form1()
        {
            InitializeComponent();
        }

        // Button 1: numbers
        private void button_Click(object sender, EventArgs e)
        {
            // This adds value to calculation
            // currentCalculation += (Button as sender).Text;
            currentCalculation += (sender as Button).Text;
            textBoxOutput.Text = currentCalculation;
        }
        // Button 2: actions
        private void button_Clear_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Text == "C")
            {
                // Reset calculation & empty the textbox
                textBoxOutput.Text = "0";
                currentCalculation = "";
            }
            else if ((sender as Button).Text == "=")
            {
                string formattedCalculation = currentCalculation.ToString().Replace("X", "*").ToString().Replace("&divide;", "/");

                try
                {
                    // System.Data allows for such computation
                    textBoxOutput.Text = new DataTable().Compute(formattedCalculation, null).ToString();
                    currentCalculation = textBoxOutput.Text;
                }
                catch (Exception ex)
                {
                    textBoxOutput.Text = "0";
                    currentCalculation = "";
                    Console.WriteLine($"Caught {ex} exception");
                }
            }
            else // should only be CE, but good to have it catch all
            {
                // If calculation is not empty, remove last character entered
                if (currentCalculation.Length > 0)
                {
                    currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
                }
                else currentCalculation = "0";
                textBoxOutput.Text = currentCalculation;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // this is required by Windows Forms for the textbox, idk
        }
    }
}
