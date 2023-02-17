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
        
        // 0 - bottom inner diameter, 1 - top inner diameter, 2 - thickness, 3 - height, 4 - height from base of stack to bottom of segment
        public readonly List<double> StackSegList;
        public List<TSM.Part> platformParts = new List<TSM.Part>();

        // list of stack segment parts
        public readonly List<TSM.Beam> SegmentPartList;
        //Form1 form = new Form1();
        public Globals()
        {
            Origin = new TSM.ContourPoint(new T3D.Point(0, 0, 0), null);
            ProfileStr = "";
            ClassStr = "";
            NameStr = "";
            Position = new TSM.Position();
            StackSegList = new List<double>();
            SegmentPartList = new List<TSM.Beam>();
            
            
            


            //string jDataString = File.ReadAllText("Data.json");
            //JData = JObject.Parse(jDataString);

            SetStackData();
            //CalculateElevation();
        }
        public void SetStackData()
        {

            ////List<JToken> stackList = JData["stack"].ToList();
            //foreach (JToken stackSeg in stackList)
            //{
            //    double bottomDiameter = (float)stackSeg["inside_dia_bottom"] * 1000; // inside bottom diamter
            //    double topDiameter = (float)stackSeg["inside_dia_top"] * 1000; // inside top diameter
            //    double thickness = (float)stackSeg["shell_thickness"] * 1000;
            //    double height = (float)stackSeg["seg_height"] * 1000;

            //    StackSegList.Add(new List<double> { bottomDiameter, topDiameter, thickness, height });
            //}
            //StackSegList.Reverse();


            double bottomDiameter = 4980; // inside bottom diamter
            double topDiameter = 4980; // inside top diameter
            double thickness =10;
            double height = 4000;

            StackSegList.AddRange( new double[] { bottomDiameter, topDiameter, thickness, height });
        }


        //void CalculateElevation()
        //{
        //    double elevation = 0;

        //    foreach (double segment in StackSegList)
        //    {
        //        segment.Add(elevation);
        //        elevation += segment[3];
        //    }
        //}

    }
}
