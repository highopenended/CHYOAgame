using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.Sets.Prefabs
{
    public class Scene
    {

        protected SceneTool_Master SceneTools = new SceneTool_Master();
        protected CEdit.Shapes.Mtool mTool = new CEdit.Shapes.Mtool();

        public SetManager SetManager;

        public virtual void Display_Scene() { }
    }
}
