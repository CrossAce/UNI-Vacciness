using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ST
{
    public partial class PersonalData : Form
    {
        private const string First_LastName_pattern = "^[А-Я]{1}[а-я]+$";
        private const string EGN_pattern = "^[0-9]{10}";
        private const string errorMessage = "Invalid Data Entered. Please return and correct it!";
     

        public PersonalData()
        {
            InitializeComponent();
        }

        //egn textbox
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text.Length == 10)
            {
                CalculateAgeAndDateOfBirth(); 
            }
        }

        private void CalculateAgeAndDateOfBirth()
        {
           
            try
            {
                int year = int.Parse(textBox3.Text.Substring(0, 2));
                int month = int.Parse(textBox3.Text.Substring(2, 2));
                int day = int.Parse(textBox3.Text.Substring(4, 2));

                if ((month - 40) > 0)
                {
                    month = month - 40;
                    year = 2000 + year;
                }
                else if ((month - 20) > 0)
                {
                    month = month - 20;
                    year = 1800 + year;
                }
                else           
                    year = 1900 + year;
                

                CalculateSex(textBox3.Text.ElementAt(8));

                textBox4.Text = (DateTime.Now.Year - year).ToString();
                DateTime birthDate = new DateTime(year, month, day);
                dateTimePicker1.Value = birthDate;
            }
            catch (Exception ex)
            {
                if(ex is FormatException)
                {
                    MessageBox.Show("Invalid EGN Format.\nPlease Use Only Numbers From [0-9]!", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(ex is ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Invalid EGN Format.\nPlease Enter a Valid EGN!", "Error",
                                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              
                textBox3.Text = "";
            }
            
            
        }

        private void CalculateSex(char digit)
        {
            int _digit = 0;
            if(int.TryParse(digit.ToString(), out _digit))
            {
                if (_digit % 2 == 0)
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
            }
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool hasError = true;

            Regex reg = new Regex(First_LastName_pattern);

            hasError = !(reg.IsMatch(textBox1.Text) && reg.IsMatch(textBox2.Text));

            if (!hasError)
            {
                reg = new Regex(EGN_pattern);
                hasError = !(reg.IsMatch(textBox3.Text));
            }
            if(hasError)
            {
                MessageBox.Show(errorMessage,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Data Correct - Proceeding to Vaccine List!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Vaccines vac = new Vaccines()
                {
                    Years = int.Parse(textBox4.Text),
                    Data = new string[] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Value.ToString() }
                };

                vac.Show();
            }
         
        }
    }
}
