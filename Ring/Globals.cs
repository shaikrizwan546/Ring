using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSM = Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
//using Newtonsoft.Json.Linq;
using Tekla.Structures.Model;
using Ring;
using System.Windows.Forms;
//using Newtonsoft.Json;

namespace Column
{
    public class Globals
    {
        public string ProfileStr;
        public const string MaterialStr = "IS2062";
        public string ClassStr;
        public string NameStr;
        public TSM.Position Position;
        //public JObject JData;

        public readonly TSM.ContourPoint Origin;
        
        public readonly List<double> StackSegList;
        public List<TSM.Part> platformParts = new List<TSM.Part>();
        public readonly List<TSM.Beam> SegmentPartList;
        
    public readonly double bottomDiameter;
    public readonly double topDiameter;
    public readonly double bottomRingStartHeight;
    public readonly double topRingStartHeight;
    public readonly double bottomRingWidth;
    public readonly double stiffenerCount;
    public readonly double tailingLugAngle;

    public Globals(double bottomDiameter, double topDiameter, double bottomRingStartHeight, double topRingStartHeight,
      double bottomRingWidth, double stiffenerCount, double tailingLugAngle)
        {

      this.bottomDiameter = bottomDiameter;
      this.topDiameter = topDiameter;
      this.bottomRingStartHeight = bottomRingStartHeight;
      this.topRingStartHeight = topRingStartHeight;
      this.bottomRingWidth = bottomRingWidth;
      this.stiffenerCount = stiffenerCount;
      this.tailingLugAngle = tailingLugAngle;
            Origin = new TSM.ContourPoint(new T3D.Point(0, 0, 0), null);
            ProfileStr = "";
            ClassStr = "";
            NameStr = "";
            Position = new TSM.Position();
            StackSegList = new List<double>();
            SegmentPartList = new List<TSM.Beam>();
            SetStackData();
            
        }
        public void SetStackData()
        {         
           // double bottomDiameter =; // inside bottom diamter
           // double topDiameter = 4980; // inside top diameter
            double thickness =10;
            double height = 4000;

            StackSegList.AddRange( new double[] { bottomDiameter, topDiameter, thickness, height });
        }


        

    }
}
