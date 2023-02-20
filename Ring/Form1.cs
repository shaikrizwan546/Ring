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
using System.Configuration;


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
     Globals global;
    public void button1_Click(object sender, EventArgs e)
    {
      //bottomDiameter1 = double.Parse(BottomDiaStacktextBox1.Text);
      //topDiameter1 = double.Parse(TopDiaStackTextBox1.Text);
      //startHeight1= double.Parse(BottomRingStartHeightTextBox1.Text);
      //endHeight1 = double.Parse(TopRingStartHeightTextBox1.Text);
      //width1 = double.Parse(BottomRingWidthTextBox1.Text);
      //stiffenercount1 = int.Parse(StiffenerCountTextBox1.Text);
      //legangle = double.Parse(TaleLegAngleTextBox1.Text);
      handleInputs();
      SendInputs();


      //Globals global = new Globals();

      TeklaModelling teklaModel = new TeklaModelling(0, 0, 0);

      new ComponentHandler(global, teklaModel);

    }
    private void handleInputs()
    {
      if(BottomDiaStacktextBox1.Text==""|| BottomDiaStacktextBox1.Text==null)
        BottomDiaStacktextBox1.Text = ConfigurationManager.AppSettings["bottomDiaOfStack"];

      if (TopDiaStackTextBox1.Text == "" || TopDiaStackTextBox1.Text == null)
        TopDiaStackTextBox1.Text = ConfigurationManager.AppSettings["topDiaOfStack"];
      
      if (BottomRingStartHeightTextBox1.Text == "" || BottomRingStartHeightTextBox1.Text == null)
        BottomRingStartHeightTextBox1.Text = ConfigurationManager.AppSettings["bottomRingStartHeight"];

      if (TopRingStartHeightTextBox1.Text == "" || TopRingStartHeightTextBox1.Text == null)
        TopRingStartHeightTextBox1.Text = ConfigurationManager.AppSettings["topRingStartHeight"];

      if (BottomRingWidthTextBox1.Text == "" || BottomRingWidthTextBox1.Text == null)
        BottomRingWidthTextBox1.Text = ConfigurationManager.AppSettings["bottomRingWidth"];

      if (StiffenerCountTextBox1.Text == "" || StiffenerCountTextBox1.Text == null)
        StiffenerCountTextBox1.Text = ConfigurationManager.AppSettings["stiffenerCount"];

      if (TaleLegAngleTextBox1.Text == "" || TaleLegAngleTextBox1.Text == null)
        TaleLegAngleTextBox1.Text = ConfigurationManager.AppSettings["tailingLugAngle"];

    }

    void SendInputs()
    {
      

       global = new Globals(
          Convert.ToDouble(BottomDiaStacktextBox1.Text),
          Convert.ToDouble(TopDiaStackTextBox1.Text),
          Convert.ToDouble(BottomRingStartHeightTextBox1.Text),
          Convert.ToDouble(TopRingStartHeightTextBox1.Text),
          Convert.ToDouble(BottomRingWidthTextBox1.Text),
          Convert.ToDouble(StiffenerCountTextBox1.Text),
          Convert.ToDouble(TaleLegAngleTextBox1.Text)
          );

     
      


    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
  }
}
