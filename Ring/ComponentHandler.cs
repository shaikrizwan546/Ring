using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSM = Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;

using HelperLibrary;
using Ring;

namespace Column
{
     class ComponentHandler
    {
        Globals _global;
        TeklaModelling _tModel;
        public ComponentHandler(Globals global, TeklaModelling teklaModel)
        {
            _global = global;
            _tModel = teklaModel;

            //new ImportCustomComponent(_global, _tModel);

            new Stack(_global, _tModel);
            //new Chair(_global, _tModel);
            //new StackPlate(_global, _tModel);
            //new Stiffener(_global, _tModel);

            new RingCreation(_global, _tModel);
            





        }
    }
}
