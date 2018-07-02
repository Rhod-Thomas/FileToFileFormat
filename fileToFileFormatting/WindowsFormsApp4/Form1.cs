using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;

using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {

        private const int END_OF_FILE = -1, COMMA = 44, CARRIAGE_RETURN = 13, LINE_FEED = 10; 


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string filename = Data.Text;
            string filename2 = fileToWrite.Text; 

            StringBuilder inData = new StringBuilder(); 
            
            if (filename != null)
            {

                FileStream F1 = new FileStream(filename, FileMode.Open, FileAccess.Read);
                FileStream F2 = new FileStream(filename2, FileMode.OpenOrCreate, FileAccess.Write);

                try
                {
                    
                    // F.write

                    int intDataIn; 

                    while ((intDataIn = F1.ReadByte()) != END_OF_FILE) //check for end of file
                    {

                        if (intDataIn == CARRIAGE_RETURN)
                        {
                            intDataIn = COMMA;
                            F2.WriteByte((byte)intDataIn);
                        }
                        else
                        {
                            F2.WriteByte((byte)intDataIn);
                        }

                    }

                    F1.Close();
                    F2.Close();
                }

                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    F1.Close();
                    F2.Close();
                }

            }
        }
    }
}
