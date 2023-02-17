using Column;
using HelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;

namespace Ring
{

    internal class RingCreation
    {
        Form1 form = new Form1();
        public double _startHeight = 1000;
        public double _endHeight = 1500;
        public double width = 500;
        public int _stiffnerRingCount = 2;
        public double stiffnerCount = 4;
        public double tailingLeg = 90;
        List<ContourPoint> _pointList;
        Globals _global;
        TeklaModelling _tModel;
        


        public RingCreation(Globals globals, TeklaModelling teklaModelling)
        {
            _global=globals;
            _tModel = teklaModelling;
            _pointList = new List<ContourPoint>();

            //_startHeight = form.startHeight1;
            //_endHeight = form.endHeight1;
            //width = form.width1;
            //stiffnerCount = form.stiffenercount1;
            //tailingLeg = form.legangle;







            CreateRing();
            CreateStiffener();
        }
        /// <summary>
        /// Creation of stifferner using 4 points            s4Point----------------s3Point
        ///                                                        |                |
        ///                                                        |                |
        ///                                                        |                |
        ///                                                       s1----------------s2      
        /// </summary>
        private void CreateStiffener()
        {
            
            double stiffnerSpacing = (2 * Math.PI) / stiffnerCount;
            ContourPoint origin1 = _tModel.ShiftVertically(_global.Origin, _startHeight);
            ContourPoint origin2 = _tModel.ShiftVertically(_global.Origin, _endHeight);
            double elevation = _startHeight;
            double elevation1 = _endHeight;

            for (int i = 0; i < stiffnerCount; i++)
            {
                if ((stiffnerSpacing * i) != (tailingLeg * Math.PI / 180))
                {
                    
                    double radius = _tModel.GetRadiusAtElevation(elevation, _global.StackSegList);
                    double radius1=_tModel.GetRadiusAtElevation(elevation1,_global.StackSegList);
                   
                    radius += _global.StackSegList[2];// adding thickness of cylinder radius at lower level
                    radius1 += _global.StackSegList[2];// adding thickness of cylinder radius at upper level
                    double length = radius + width;
                    double length1 = radius1 + width;
                    //Tekla.Structures.Geometry3d.Point s1Point = new ContourPoint(_tModel.ShiftHorizontallyRad(origin1, radius, 1, stiffnerSpacing * i), null);
                    //Tekla.Structures.Geometry3d.Point s2Point = new ContourPoint(_tModel.ShiftHorizontallyRad(origin1, length, 1, stiffnerSpacing * i), null);

                    ContourPoint s1= new ContourPoint(_tModel.ShiftHorizontallyRad(origin1, radius, 1, stiffnerSpacing * i), null);
                    ContourPoint s2 = new ContourPoint(_tModel.ShiftHorizontallyRad(origin1, length, 1, stiffnerSpacing * i), null);

                    ContourPoint s3Point = new ContourPoint(_tModel.ShiftHorizontallyRad(origin2, length1, 1, stiffnerSpacing * i), null);
                    ContourPoint s4Point = new ContourPoint(_tModel.ShiftHorizontallyRad(origin2, radius1, 1, stiffnerSpacing * i), null);


                    //_global.ClassStr = "5";
                    //_global.Position.Plane = Tekla.Structures.Model.Position.PlaneEnum.MIDDLE;
                    //_global.Position.Rotation = Tekla.Structures.Model.Position.RotationEnum.BELOW;
                    //_global.Position.Depth = Tekla.Structures.Model.Position.DepthEnum.FRONT;
                    //_global.ProfileStr = "PLT10X" + width;
                    //_tModel.CreateBeam(s1Point, s2Point, _global.ProfileStr, "IS2062", _global.ClassStr, _global.Position, "Stiffener");



                    _pointList.Add(s1);
                    _pointList.Add(s4Point);
                    _pointList.Add(s3Point);
                    _pointList.Add(s2);
                    _global.ClassStr = "9";
                    _global.Position.Plane = Tekla.Structures.Model.Position.PlaneEnum.RIGHT;
                    _global.Position.Rotation = Tekla.Structures.Model.Position.RotationEnum.FRONT;
                    _global.Position.Depth = Tekla.Structures.Model.Position.DepthEnum.MIDDLE;
                    _global.ProfileStr = "PLT10";
                    _tModel.CreateContourPlate(_pointList, _global.ProfileStr, Globals.MaterialStr, _global.ClassStr, _global.Position, "stiffnerRing" + i);


                    _pointList.Clear();
                }

            }
        }
        /// <summary>
        /// Cretae Ring around cylinder by deviding ring at four parts
        /// </summary>
        public void CreateRing()
        {
            
            double spacing = _startHeight - _endHeight;
            ContourPoint origin = _tModel.ShiftVertically(_global.Origin, _startHeight);
            double elevation = _startHeight;
            for(int i = 0; i < _stiffnerRingCount; i++)
            {
                double radius = _tModel.GetRadiusAtElevation(elevation,_global.StackSegList,true);
                //radius += _global.StackSegList[2];
                ContourPoint s1Point = new ContourPoint(_tModel.ShiftHorizontallyRad(origin,radius,1),null);
                ContourPoint m1Point = new ContourPoint(_tModel.ShiftAlongCircumferenceRad(s1Point, Math.PI / 4, 1), new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT));
                ContourPoint e1Point = new ContourPoint(_tModel.ShiftAlongCircumferenceRad(s1Point, Math.PI / 2, 1), new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT));

                ContourPoint m2Point = new ContourPoint(_tModel.ShiftAlongCircumferenceRad(s1Point, 3*Math.PI / 4, 1), new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT));
                ContourPoint e2Point = new ContourPoint(_tModel.ShiftHorizontallyRad(origin, radius, 3), null);

                ContourPoint m3Point = new ContourPoint(_tModel.ShiftAlongCircumferenceRad(s1Point, 5 * Math.PI / 4, 1), new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT));
                ContourPoint e3Point = new ContourPoint(_tModel.ShiftHorizontallyRad(origin, radius, 4), null);

                ContourPoint m4Point = new ContourPoint(_tModel.ShiftAlongCircumferenceRad(s1Point, 7 * Math.PI / 4, 1), new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT));

                _pointList.Add(s1Point);
                _pointList.Add(m1Point);
                _pointList.Add(e1Point);

                _global.ClassStr = "9";
                _global.Position.Plane = Tekla.Structures.Model.Position.PlaneEnum.RIGHT;
                _global.Position.Rotation = Tekla.Structures.Model.Position.RotationEnum.FRONT;
                if(i==0)
                {
                    _global.Position.Depth = Tekla.Structures.Model.Position.DepthEnum.BEHIND;
                }
                else
                {
                    _global.Position.Depth = Tekla.Structures.Model.Position.DepthEnum.FRONT;
                }
                
                _global.ProfileStr = "PLT10X"+width;
                _tModel.CreatePolyBeam(_pointList, _global.ProfileStr, Globals.MaterialStr, _global.ClassStr, _global.Position, "stiffnerRing" + i);
                _pointList.Clear();


                _pointList.Add(e1Point);
                _pointList.Add(m2Point);
                _pointList.Add(e2Point);

                _global.ClassStr = "9";
                _global.Position.Plane = Tekla.Structures.Model.Position.PlaneEnum.RIGHT;
                _global.Position.Rotation = Tekla.Structures.Model.Position.RotationEnum.FRONT;
                if (i == 0)
                {
                    _global.Position.Depth = Tekla.Structures.Model.Position.DepthEnum.BEHIND;
                }
                else
                {
                    _global.Position.Depth = Tekla.Structures.Model.Position.DepthEnum.FRONT;
                }
                _global.ProfileStr = "PLT10X" + width;
                _tModel.CreatePolyBeam(_pointList, _global.ProfileStr, Globals.MaterialStr, _global.ClassStr, _global.Position, "stiffnerRing" + i);
                _pointList.Clear();


                _pointList.Add(e2Point);
                _pointList.Add(m3Point);
                _pointList.Add(e3Point);

                _global.ClassStr = "9";
                _global.Position.Plane = Tekla.Structures.Model.Position.PlaneEnum.RIGHT;
                _global.Position.Rotation = Tekla.Structures.Model.Position.RotationEnum.FRONT;
                if (i == 0)
                {
                    _global.Position.Depth = Tekla.Structures.Model.Position.DepthEnum.BEHIND;
                }
                else
                {
                    _global.Position.Depth = Tekla.Structures.Model.Position.DepthEnum.FRONT;
                }
                _global.ProfileStr = "PLT10X" + width;
                _tModel.CreatePolyBeam(_pointList, _global.ProfileStr, Globals.MaterialStr, _global.ClassStr, _global.Position, "stiffnerRing" + i);
                _pointList.Clear();


                _pointList.Add(e3Point);
                _pointList.Add(m4Point);
                _pointList.Add(s1Point);

                _global.ClassStr = "9";
                _global.Position.Plane = Tekla.Structures.Model.Position.PlaneEnum.RIGHT;
                _global.Position.Rotation = Tekla.Structures.Model.Position.RotationEnum.FRONT;
                if (i == 0)
                {
                    _global.Position.Depth = Tekla.Structures.Model.Position.DepthEnum.BEHIND;
                }
                else
                {
                    _global.Position.Depth = Tekla.Structures.Model.Position.DepthEnum.FRONT;
                }
                _global.ProfileStr = "PLT10X" + width;
                _tModel.CreatePolyBeam(_pointList, _global.ProfileStr, Globals.MaterialStr, _global.ClassStr, _global.Position, "stiffnerRing" + i);
                _pointList.Clear();

                elevation = _endHeight;
                origin = _tModel.ShiftVertically(_global.Origin, elevation);
                double radius1 = _tModel.GetRadiusAtElevation(elevation, _global.StackSegList, true);
                width = width + (radius - radius1);


            }
            width = 500;
        }
    }
}
