using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.DataSourcesFile;

namespace CADtoGIS_Test1
{
    public partial class Form_BrowseCADFile : Form
    {
        public Form_BrowseCADFile()
        {
            InitializeComponent();

            //Setting all items of Checkbox List  to true by default, for ignoring layer.
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "CAD Files (*.dwg)|*.dwg";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    textBox_FilePath.Text = openFileDialog.FileName;
                }
            }

            
        }


        private void OpenCADFile(string filePath,string outputFilePath)
        {
            try
            {
                Debug.WriteLine("Start Time: " + DateTime.Now.ToShortTimeString());
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;


                String nameOfPath = System.IO.Path.GetDirectoryName(filePath);
                String nameOfCADFile = System.IO.Path.GetFileName(filePath);

                #region Open CAD Workspace from File Path
                //Set the workspace.
                ESRI.ArcGIS.Geodatabase.IWorkspaceFactory pWorkspaceFact = new
                   ESRI.ArcGIS.DataSourcesFile.CadWorkspaceFactory();
                ESRI.ArcGIS.Geodatabase.IWorkspaceFactory defaultWorkspaceFact = new FileGDBWorkspaceFactory();
                //Open the workspace.
                ESRI.ArcGIS.Geodatabase.IWorkspace pWorkspace = pWorkspaceFact.OpenFromFile(nameOfPath, 0);
                //Get the CADDrawingWorkspace.
                ESRI.ArcGIS.DataSourcesFile.ICadDrawingWorkspace pCadDwgWorkspace;
                pCadDwgWorkspace = (ESRI.ArcGIS.DataSourcesFile.ICadDrawingWorkspace)pWorkspace;
                //Open the CadDrawingDataset.
                ESRI.ArcGIS.DataSourcesFile.ICadDrawingDataset pCadDwgDataset;
                pCadDwgDataset = pCadDwgWorkspace.OpenCadDrawingDataset(nameOfCADFile);

                //Set the feature workspace. 
                ESRI.ArcGIS.Geodatabase.IFeatureWorkspace pFeatureWorkspace = (ESRI.ArcGIS.Geodatabase.IFeatureWorkspace)pWorkspace;
                //Open the Feature Class. 

                #endregion


                #region Getting Polygon, polylines, and annotation from Cad file

                ESRI.ArcGIS.Geodatabase.IFeatureClass pFeatClass =
                    pFeatureWorkspace.OpenFeatureClass(System.String.Concat(nameOfCADFile,
                    ":Polygon"));

                ESRI.ArcGIS.Geodatabase.IFeatureClass pFeatClass_Plyline =
                    pFeatureWorkspace.OpenFeatureClass(System.String.Concat(nameOfCADFile,
                    ":Polyline"));

                ESRI.ArcGIS.Geodatabase.IFeatureClass pFeatClass_Anno =
                    pFeatureWorkspace.OpenFeatureClass(System.String.Concat(nameOfCADFile,
                    ":Annotation"));
                #endregion


                UID CLSID_def = new UIDClass();
                CLSID_def.Value = "esriGeoDatabase.Feature";

                #region Creating Layers from Feature Classes
                //Polygons
                ESRI.ArcGIS.Carto.IFeatureLayer pFeatLayer = new ESRI.ArcGIS.Carto.CadFeatureLayer()
                as ESRI.ArcGIS.Carto.IFeatureLayer;
                pFeatLayer.FeatureClass = pFeatClass;
                pFeatLayer.Name = "Polygons";
                ESRI.ArcGIS.DataSourcesFile.ICadDrawingLayers pCadDwgLayers = (ESRI.ArcGIS.DataSourcesFile.ICadDrawingLayers)pFeatLayer;

                //Annotation
                ESRI.ArcGIS.Carto.IFeatureLayer pFeatLayer_Anno = new ESRI.ArcGIS.Carto.CadFeatureLayer()
                as ESRI.ArcGIS.Carto.IFeatureLayer;
                pFeatLayer_Anno.FeatureClass = pFeatClass_Anno;
                pFeatLayer_Anno.Name = "Annotation";
                ESRI.ArcGIS.DataSourcesFile.ICadDrawingLayers pCadDwgLayers_Anno =
                    (ESRI.ArcGIS.DataSourcesFile.ICadDrawingLayers)pFeatLayer_Anno;

                //Polylines
                ESRI.ArcGIS.Carto.IFeatureLayer pFeatLayer_Plyline = new ESRI.ArcGIS.Carto.CadFeatureLayer()
                as ESRI.ArcGIS.Carto.IFeatureLayer;
                pFeatLayer_Plyline.FeatureClass = pFeatClass_Plyline;
                pFeatLayer_Plyline.Name = "Polylines";
                ESRI.ArcGIS.DataSourcesFile.ICadDrawingLayers pCadDwgLayers_Plyline =
                    (ESRI.ArcGIS.DataSourcesFile.ICadDrawingLayers)pFeatLayer_Plyline;
                #endregion

                #region Creating In-Memory workspace
                IWorkspaceFactory WF = new InMemoryWorkspaceFactory();
                ESRI.ArcGIS.esriSystem.IName name = WF.Create("", "MyWorkspace", null, 0) as ESRI.ArcGIS.esriSystem.IName;
                IWorkspace inMemWorkspace = (IWorkspace)name.Open();
                IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)inMemWorkspace;
                #endregion

                #region Creating new Fields

                IObjectClassDescription objectClassDescription = new FeatureClassDescription();

                // create the fields using the required fields method  
                IFields exportFields = new Fields();
                IFieldsEdit fieldsEdit = (IFieldsEdit)exportFields;

                //OID
                IField field = new Field();
                IField oidField = new Field();
                IFieldEdit oidFieldEdit = (IFieldEdit)oidField;
                oidFieldEdit.Name_2 = "OID";
                oidFieldEdit.Type_2 = esriFieldType.esriFieldTypeOID;
                fieldsEdit.AddField(oidField);

                // Create a geometry definition (and spatial reference) for the feature class
                IGeometryDef geometryDef = new GeometryDef();
                IGeometryDefEdit geometryDefEdit = (IGeometryDefEdit)geometryDef;
                geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
                IGeoDataset dataSet = (IGeoDataset)pFeatClass.FeatureDataset;
                ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironment();

                ISpatialReference spatialReference = dataSet.SpatialReference;
                ISpatialReferenceResolution spatialReferenceResolution = (ISpatialReferenceResolution)spatialReference;
                spatialReferenceResolution.ConstructFromHorizon();
                ISpatialReferenceTolerance spatialReferenceTolerance = (ISpatialReferenceTolerance)spatialReference;
                spatialReferenceTolerance.SetDefaultXYTolerance();
                geometryDefEdit.SpatialReference_2 = spatialReference;


                // Add a geometry field to the fields collection. This is where the geometry definition is applied.
                IField geometryField = new Field();
                IFieldEdit geometryFieldEdit = (IFieldEdit)geometryField;
                geometryFieldEdit.Name_2 = "Shape";
                geometryFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
                geometryFieldEdit.GeometryDef_2 = geometryDef;
                fieldsEdit.AddField(geometryField);
                #endregion


                #region Creating New Shapefile for Final output
                UID CLSID = new UIDClass();
                CLSID.Value = "esriGeoDatabase.Feature";

                //using the In-Memory Workspace created above
                IFeatureClass output = featureWorkspace.CreateFeatureClass("myPolygons", pFeatClass.Fields, CLSID, null, esriFeatureType.esriFTSimple, "Shape", null);
                IFeatureClass polylines_cleaned = featureWorkspace.CreateFeatureClass("polylines_cleaned", pFeatClass_Plyline.Fields, CLSID, null, esriFeatureType.esriFTSimple, "Shape", null);
                IFeatureClass annotation_cleaned = featureWorkspace.CreateFeatureClass("annotation_cleaned", pFeatClass_Anno.Fields, CLSID, null, esriFeatureType.esriFTSimple, "Shape", null);
                #endregion

                #region Appending features from CADWorkspaceFeatureClass to In-Memory FeatureClass Because Update cursor not in Cad workspace
                Geoprocessor GP = new Geoprocessor();

                //Polylines
                ESRI.ArcGIS.DataManagementTools.Append append = new Append();
                append.inputs = pFeatClass_Plyline;
                append.target = polylines_cleaned;
                GP.Execute(append, null);
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatClass_Plyline);
                GC.Collect();

                //Annotation
                append = new Append();
                append.inputs = pFeatClass_Anno;
                append.target = annotation_cleaned;
                GP.Execute(append, null);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatClass_Anno);
                GC.Collect();

                //Polygons to output
                append = new Append();
                append.inputs = pFeatClass;
                append.target = output;
                GP.Execute(append, null);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatClass);
                GC.Collect();
                #endregion

                #region Query Filter to Filter Layers

                string queryString = "";
                //using the checked box list and comma seperated list to create where clause string

                //Adding Items from Check Box List
                foreach (var checkedItem in checkedListBox1.CheckedItems)
                    queryString = queryString + "Layer NOT LIKE '" + checkedItem.ToString() + "' AND ";
                //Adding Items from Comma separated string
                if (textBox_commaSeparated.Text.Length > 0)
                    foreach (var item in textBox_commaSeparated.Text.Split(','))
                        queryString = queryString + "Layer NOT LIKE '" + item.ToString() + "' AND ";

                //Removing Last 'AND' FROM queryString
                if (queryString.Length > 0) //if Atleast one item added
                    queryString = queryString.Remove(queryString.Length - 4);


                IQueryFilter queryFilter = new QueryFilter();
                queryFilter.SubFields = "";
                if (queryString.Length > 0)
                    queryFilter.WhereClause = queryString;
                else
                    queryFilter.WhereClause = "1=1";


                #endregion



                #region Removing Null Geometries

                string ignoreList = queryString.Replace("Layer NOT LIKE '", "").Replace("' AND ", ",").Replace("' ", "");

                Debug.WriteLine("lines Count before:" + polylines_cleaned.FeatureCount(new QueryFilter()).ToString());
                //From Polylines_cleaned
                IFeatureCursor updateCursor = polylines_cleaned.Update(new QueryFilter(), false);
                IFeature feat = updateCursor.NextFeature();
                while (feat != null)
                {
                    string lyr = Convert.ToString(feat.get_Value(feat.Fields.FindField("Layer")));
                    lyr = lyr.ToUpper();
                    if (feat.Shape.IsEmpty || ignoreList.ToUpper().Split(',').ToList<string>().Any(l => lyr.Contains(l)))
                        updateCursor.DeleteFeature();
                    feat = updateCursor.NextFeature();
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(updateCursor);
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(feat);
                GC.Collect();
                Debug.WriteLine("lines Count After:" + polylines_cleaned.FeatureCount(new QueryFilter()).ToString());


                //From output
                Debug.WriteLine("polygons Count before:" + output.FeatureCount(new QueryFilter()).ToString());
                updateCursor = output.Update(new QueryFilter(), false);
                feat = updateCursor.NextFeature();
                while (feat != null)
                {
                    string lyr = Convert.ToString(feat.get_Value(feat.Fields.FindField("Layer")));
                    lyr = lyr.ToUpper();
                    if (feat.Shape.IsEmpty || ignoreList.ToUpper().Split(',').ToList<string>().Any(l => lyr.Contains(l)))
                        updateCursor.DeleteFeature();
                    feat = updateCursor.NextFeature();
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(updateCursor);
                GC.Collect();
                Debug.WriteLine("polygons Count after:" + output.FeatureCount(new QueryFilter()).ToString());

                //From Annotation
                Debug.WriteLine("Annotation Count before:" + annotation_cleaned.FeatureCount(new QueryFilter()).ToString());
                updateCursor = annotation_cleaned.Update(new QueryFilter(), false);
                feat = updateCursor.NextFeature();
                while (feat != null)
                {
                    string lyr = Convert.ToString(feat.get_Value(feat.Fields.FindField("Layer")));
                    lyr = lyr.ToUpper();
                    if (feat.Shape.IsEmpty || ignoreList.ToUpper().Split(',').ToList<string>().Any(l => lyr.Contains(l)))
                        updateCursor.DeleteFeature();
                    feat = updateCursor.NextFeature();
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(updateCursor);
                GC.Collect();
                Debug.WriteLine("Annotation Count after:" + annotation_cleaned.FeatureCount(new QueryFilter()).ToString());
                #endregion


                #region Convert lines feature class to feature Cursor

                IFeatureCursor linesFCursor = polylines_cleaned.Search(new QueryFilter(), false);

                #endregion


                #region Deleting all columns of polygons to match with output

                IFields _fieldsP = output.Fields;
                IFieldsEdit _fieldsEditP = (IFieldsEdit)_fieldsP;
                for (int i = 0; i < output.Fields.FieldCount; i++)
                {
                    IField _field = output.Fields.get_Field(i);
                    if (_field.Name != "Shape" && _field.Name != "FID")
                    {
                        output.DeleteField(_field);
                        if (i < output.Fields.FieldCount)
                            i--;
                    }
                }

                System.Runtime.InteropServices.Marshal.ReleaseComObject(_fieldsP);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_fieldsEditP);
                GC.Collect();
                #endregion

                #region Setting Envelop information
                IEnvelope envelop = new Envelope() as IEnvelope;
                IGeoDataset dataSetEnv = (IGeoDataset)pFeatClass_Plyline.FeatureDataset;
                envelop.SpatialReference = dataSet.SpatialReference;
                envelop.PutCoords(dataSet.Extent.XMin, dataSet.Extent.YMin, dataSet.Extent.XMax, dataSet.Extent.YMax);
                #endregion


                #region Construct Polygons from Lines Cursor (usting Feature Construct)
                IFeatureConstruction featureConstruct = new FeatureConstruction() as IFeatureConstruction;
                ISelectionSet selectionSet = null;
                //atureConstruct.ConstructPolygonsFromFeaturesFromCursor(null,output,envelop,false,false,linesFCursor,null,0.001,null);
                featureConstruct.AutoCompleteFromFeaturesFromCursor(output, envelop, linesFCursor, null, -1, null, out selectionSet);

                #endregion

                System.Runtime.InteropServices.Marshal.ReleaseComObject(featureConstruct);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(linesFCursor);

                GC.Collect();



                Debug.WriteLine("polygons Count after PolygonConstruct :" + output.FeatureCount(new QueryFilter()).ToString());




                #region SPATIAL JOIN
                GP = new Geoprocessor();
                ESRI.ArcGIS.AnalysisTools.SpatialJoin spatialJoin = new ESRI.ArcGIS.AnalysisTools.SpatialJoin();

                spatialJoin.join_features = annotation_cleaned;
                spatialJoin.target_features = output;
                spatialJoin.join_operation = "JOIN_ONE_TO_MANY";
                spatialJoin.join_type = "KEEP_ALL";
                spatialJoin.match_option = "CONTAINS";
                spatialJoin.out_feature_class = outputFilePath;

                GP.Execute(spatialJoin, null);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(annotation_cleaned);
                GC.Collect();


                #endregion

                #region Remove All Fields of Annotation except Text

                ShapefileWorkspaceFactory wsf = new ShapefileWorkspaceFactory();
                IFeatureWorkspace work = (IFeatureWorkspace)wsf.OpenFromFile(System.IO.Path.GetDirectoryName(outputFilePath), 0);
                IFeatureClass output_AfterJoin_FClasss = work.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(outputFilePath));

                IFields _fields = output_AfterJoin_FClasss.Fields;
                IFieldsEdit _fieldsEdit = (IFieldsEdit)_fields;
                for (int i = 0; i < _fields.FieldCount; i++)
                {
                    IField _field = output_AfterJoin_FClasss.Fields.get_Field(i);
                    if (_field.Name != "Text_" && _field.Name != "Text" && _field.Name != "Shape" && _field.Name != "FID")
                    {
                        output_AfterJoin_FClasss.DeleteField(_field);
                        i--;
                    }
                    else
                    {
                        if (field.Name == "Text_" || _field.Name == "Text")
                        {
                            IFieldEdit fieldEdit = (IFieldEdit)_field;
                            fieldEdit.Name_2 = "PlotNumber";
                            fieldEdit.AliasName_2 = "PlotNumber";
                        }
                    }
                }

                System.Runtime.InteropServices.Marshal.ReleaseComObject(_fields);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_fieldsEdit);
                GC.Collect();

                #endregion
                System.Windows.Forms.Cursor.Current = Cursors.Default;
                Debug.WriteLine("End Time: " + DateTime.Now.ToShortTimeString());
                MessageBox.Show("Import Complete!");

            }
            catch
            {
                MessageBox.Show("Error Importing. Something wrong with the CAD File");
            }

        }

        private void button_Open_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Test!");
            if (File.Exists(textBox_FilePath.Text))
                if (textBox_Output.Text != "")
                {
                    if (!File.Exists(textBox_Output.Text))
                        OpenCADFile(textBox_FilePath.Text, textBox_Output.Text);
                    else
                        MessageBox.Show("Shapefile Already exists. Kindly Select a new Shapefile name");
                }
                else
                    MessageBox.Show("Enter output shapefile location!");
            else
                MessageBox.Show("Please Select valid file first!");


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Shapefile (*.shp)|*.shp";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_Output.Text = saveFileDialog1.FileName;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label_tempGDB.Enabled = checkBox_repairGeom.Checked;
            textBox_tempGDB.Enabled = checkBox_repairGeom.Checked;
            pictureBox_tempGDB.Enabled = checkBox_repairGeom.Checked;
        }

    }
}
