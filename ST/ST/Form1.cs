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
    public partial class Form1 : Form
    {

        const string _patternUname = @"^[^1234567890][a-z1-5A-Z]+$";
       

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // LogIn(); // for testing
            
            bool hasError = true;
            if(uname.Text.Length > 4 && pword.Text.Length > 5)
            {
                hasError = !(ValidateRegex(_patternUname,uname.Text) && pword.Text.Length < 9);
            }
            if (hasError)
                MessageBox.Show("Error in credentials!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                LogIn();
            }
        }

        private bool ValidateRegex(string pattern, string text)
        {           
            Regex reg = new Regex(pattern);
            return reg.IsMatch(text);
        }

        private void LogIn()
        {
            PersonalData personalData = new PersonalData();
            personalData.Show();
        }
    }
}
