using Column;
using HelperLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ring
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        public double bottomDiameter1;
        public double topDiameter1;
        public double startHeight1;
        public double endHeight1;
        public double width1;   
        public double stiffenercount1;
        public double legangle;
        public void button1_Click(object sender, EventArgs e)
        {
            bottomDiameter1 = double.Parse(BottomDiaStacktextBox1.Text);
            topDiameter1 = double.Parse(TopDiaStackTextBox1.Text);
            startHeight1= double.Parse(BottomRingStartHeightTextBox1.Text);
            endHeight1 = double.Parse(TopRingStartHeightTextBox1.Text);
            width1 = double.Parse(BottomRingWidthTextBox1.Text);
            stiffenercount1 = int.Parse(StiffenerCountTextBox1.Text);
            legangle = double.Parse(TaleLegAngleTextBox1.Text);


         
            Globals global = new Globals();

            TeklaModelling teklaModel = new TeklaModelling(0, 0, 0);

            new ComponentHandler(global, teklaModel);
           


        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
    }
}
