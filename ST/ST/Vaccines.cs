using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ST
{
    public partial class Vaccines : Form
    {
        public int Years { get; set; }
        public string[] Data { get; set; }
        

        public Vaccines()
        {
            InitializeComponent();
        }

        

        private void Vaccines_Load(object sender, EventArgs e)
        {
            if (Years > 0 && Years < 7) radioButton1.Checked = true;
            else if (Years > 6 && Years < 13) radioButton2.Checked = true;
            else if (Years > 13 && Years < 19) radioButton3.Checked = true;
            else MessageBox.Show("You are too old for this program!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = Application.StartupPath;
            using (var writer = new System.IO.StreamWriter(path, true))
            {
                foreach(var s in Data)
                {
                    writer.WriteLine(s);
                }
                writer.WriteLine(Environment.NewLine);
            }
        }
    }
}
