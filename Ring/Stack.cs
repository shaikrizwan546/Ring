using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSM = Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
//using Newtonsoft.Json.Linq;

using System.Net;
using System.Reflection;
using HelperLibrary;

namespace Column
{
    class Stack
    {
        Globals _global;
        TeklaModelling _tModel;

        public Stack(Globals global, TeklaModelling tModel)
        {
            _global = global;
            _tModel = tModel;

            CreateStack();
        }

        void CreateStack()
        {
            int i = 0;
            _global.Position.Depth = TSM.Position.DepthEnum.MIDDLE;
            _global.Position.Plane = TSM.Position.PlaneEnum.MIDDLE;
            _global.Position.Rotation = TSM.Position.RotationEnum.FRONT;
            _global.ClassStr = "1";

            
                T3D.Point startpoint = new T3D.Point(_global.Origin.X, _global.Origin.Y, _global.Origin.Z);
                T3D.Point endpoint = _tModel.ShiftVertically(new TSM.ContourPoint(startpoint, null), _global.StackSegList[3]);
                _global.NameStr="segment"+(i+1);

                // CHS profile requires outer diameter, we get inner diameter fom user input. Hence outerDiameter = innerDiameter + (2 * segmentThickness)
                _global.ProfileStr = "CHS" + (_global.StackSegList[0] + (2 * _global.StackSegList[2])) + "*" + (_global.StackSegList[1] + (2 * _global.StackSegList[2])) + "*" + _global.StackSegList[2];
                TSM.Beam segment = _tModel.CreateBeam(startpoint, endpoint, _global.ProfileStr, Globals.MaterialStr, _global.ClassStr, _global.Position, "myBeam");
                _global.SegmentPartList.Add(segment);
            
        }
    }
}
