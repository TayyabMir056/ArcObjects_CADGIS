using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CADtoGIS_Test1
{
    public class CADtoGIS_Tool : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        public CADtoGIS_Tool()
        {
        }

        protected override void OnUpdate()
        {

        }
        protected override void OnActivate()
        {
            Form_BrowseCADFile browseFile = new Form_BrowseCADFile();
            browseFile.Visible = true;
            
        }
        protected override void OnMouseUp(MouseEventArgs arg)
        {

        }
        protected override bool OnDeactivate()
        {
            return true;
        }
        
    }

}
