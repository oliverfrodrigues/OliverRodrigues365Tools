using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Portals.MetadataTranslationManager.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using System.Linq;
using System.Windows.Controls;
using Enums = Portals.MetadataTranslationManager.Model.Enums;
using Microsoft.Xrm.Sdk.Messages;

namespace Portals.MetadataTranslationManager
{
    public partial class MetadataTranslatorControl : PluginControlBase
    {
        #region Properties

        private Settings mySettings;
        private List<EntityMetadata> _entityMetadataList = new List<EntityMetadata>();
        List<LanguageModel> _selectedLanguages;
        List<EntityMetadata> _selectedEntities;
        public DataGridHelper _dataGridModel { get; set; }

        #endregion

        #region Constructors
        public MetadataTranslatorControl()
        {
            InitializeComponent();

            tbGrid.TabPages.Clear();
            
        }

        #endregion

        #region Control's Events

        private void MetadataTranslatorControl_Load(object sender, EventArgs e)
        {
            //ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetadataTranslatorControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        private void tsbLoadEnvironment_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
        }

        private void menuControl_ButtonCloseClicked(object sender, EventArgs e)
        {
            CloseTool();

        }

        private void menuControl_ButtonLoadEnvironmentClicked(object sender, EventArgs e)
        {
            ExecuteMethod(LoadEnvironmentSetup);
        }

        private void menuControl_ButtonLoadDataClicked(object sender, EventArgs e)
        {
            ExecuteMethod(LoadData);
        }

        #endregion

        private void LoadEnvironmentSetup()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading environment configuration",
                Work = (worker, args) =>
                {
                    entityPicker.LoadEntities();
                    _entityMetadataList = entityPicker._entityMetadata;

                    languagePicker.LoadLanguages();

                    LoadWebsites();

                    //args.Result = Service.Execute(new RetrieveAvailableLanguagesRequest());
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //var result = args.Result as EntityCollection;
                    //if (result != null)
                    //{
                    //    MessageBox.Show($"Found {result.Entities.Count} languages");
                    //}
                    entityPicker.PopulateList();
                    languagePicker.PopulateList();
                }
            });
        }

        private void LoadWebsites()
        {
            QueryExpression qe = new QueryExpression("adx_website");
            qe.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
            qe.ColumnSet = new ColumnSet("adx_name");
            EntityCollection ec = Service.RetrieveMultiple(qe);
            if (ec != null)
            {
                foreach (Entity w in ec.Entities)
                {
                    Invoke(new Action(() =>
                    {
                        ddlWebsite.Items.Add(new WebsiteModel()
                        {
                            ID = w.Id,
                            Text = w.GetAttributeValue<string>("adx_name")
                        });
                        ddlWebsite.SelectedIndex = 0;
                    }
                    ));
                }
            }
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }

            entityPicker._orgService = newService;
            languagePicker._orgService = newService;
        }

        private void LoadData()
        {
            _selectedEntities = entityPicker._selectedEntityMetadata;
            if (_selectedEntities.Count == 0)
            {
                MessageBox.Show(this, "Please select at least one entity!", "No entities selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _selectedLanguages = languagePicker._selectedLanguages;
            if (_selectedLanguages.Count == 0)
            {
                MessageBox.Show(this, "Please select at least one language!", "No languages selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ddlWebsite.SelectedItem == null)
            {
                MessageBox.Show(this, "Please select your website!", "No website selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ddlWebsite.Focus();
                return;
            }

            // clear tab control
            tbGrid.TabPages.Clear();

            //_dataGridModel = new DataGridHelper();

            // clear grid
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Data",
                IsCancelable = true,
                Work = (bw, evt) =>
                {

                    bw.WorkerReportsProgress = true;
                    if (bw.CancellationPending)
                    {
                        bw.ReportProgress(0, "Cancelling");
                        bw.CancelAsync();
                    }
                    bw.ReportProgress(0, "Retrieving selected entities data");

                    foreach (EntityMetadata e in _selectedEntities)
                    {
                        bw.ReportProgress(10, string.Format("Retrieving data for: {0}", e.LogicalName));

                        switch (e.LogicalName)
                        {
                            case "adx_entityform":
                                GetEntityFormData();
                                break;
                            case "adx_entityformmetadata":
                                GetEntityFormMetadataData();
                                break;
                            case "adx_entitylist":
                                GetEntityListData();
                                break;
                            default:
                                break;
                        }

                    }
                },
                PostWorkCallBack = evt =>
                {
                    // add status bar
                    if (evt.Cancelled)
                    {
                        return;
                    }
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, string.Format("An error occurred: {0}", evt.Error.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                },
                ProgressChanged = evt =>
                {
                    SetWorkingMessage(evt.UserState.ToString());
                    //SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(evt.UserState.ToString()));
                }
            });
        }

        #region Content Snippet 

        #endregion

        #region Entity List

        public void GetEntityListData()
        {
            _dataGridModel = new DataGridHelper();
            List<AttributeHelperModel> attributes = DataModel.GetAttributeListEntityList();

            QueryExpression qe = new QueryExpression("adx_entitylist");
            qe.ColumnSet = new ColumnSet(attributes.Select(x => x.AttributeLogicalName).Distinct().ToArray());
            SetCommonFilters(ref qe, null);

            EntityCollection ec = Service.RetrieveMultiple(qe);

            if (ec != null)
            {
                int countRecord = ec.Entities.Count;
                List<DataModel> dataModel = new List<DataModel>();

                DataGridView grid;
                TabPage tbPage = _dataGridModel.GenerateTab("Entity List", countRecord, out grid, this);

                string[] settingsJsonAttributes = new string[] { "adx_settings", "adx_views" };
                string[] ignoreAttributes = new string[] { "adx_name" };
                dataModel = GenerateData(attributes, ec, settingsJsonAttributes, ignoreAttributes);
                PopulateGrid(dataModel, grid, tbPage);
            }
        }

        #endregion

        #region Entity Form 

        private void GetEntityFormData()
        {
            _dataGridModel = new DataGridHelper();
            List<AttributeHelperModel> attributes = DataModel.GetAttributeListEntityForm();

            QueryExpression qe = new QueryExpression("adx_entityform");
            qe.ColumnSet = new ColumnSet(attributes.Select(x => x.AttributeLogicalName).Distinct().ToArray());
            SetCommonFilters(ref qe, null);

            EntityCollection ec = Service.RetrieveMultiple(qe);

            if (ec != null)
            {
                int countRecord = ec.Entities.Count;
                List<DataModel> dataModel = new List<DataModel>();

                DataGridView grid;
                TabPage tbPage = _dataGridModel.GenerateTab("Entity Form", countRecord, out grid, this);
                string[] settingsJsonAttributes = new string[] { "adx_settings" };
                string[] ignoreAttributes = new string[] { "adx_name" };
                dataModel = GenerateData(attributes, ec, settingsJsonAttributes, ignoreAttributes);
                //LogInfo(String.Format("{0} Records retrieved from adx_entityform entity", CRMDataList.Count));
                PopulateGrid(dataModel, grid, tbPage);
            }
        }

        #endregion

        #region Entity Form Metadata 
        private void GetEntityFormMetadataData()
        {
            _dataGridModel = new DataGridHelper();
            List<AttributeHelperModel> attributes = DataModel.GetAttributeListEntityFormMetadata();

            QueryExpression qe = new QueryExpression("adx_entityformmetadata");
            qe.ColumnSet = new ColumnSet(attributes.Select(x => x.AttributeLogicalName).Distinct().ToArray());
            LinkEntity le = new LinkEntity("adx_entityformmetadata", "adx_entityform", "adx_entityform", "adx_entityformid", JoinOperator.Inner);
            SetCommonFilters(ref qe, le);
            qe.LinkEntities.Add(le);

            EntityCollection ec = Service.RetrieveMultiple(qe);

            if (ec != null)
            {
                int countRecord = ec.Entities.Count;
                List<DataModel> dataModel = new List<DataModel>();

                DataGridView grid;
                TabPage tbPage = _dataGridModel.GenerateTab("Entity Form Metadata", countRecord, out grid, this);

                string[] settingsJsonAttributes = new string[] { "adx_subgrid_settings", "adx_notes_settings", "adx_timeline_settings" };
                string[] ignoreAttributes = new string[] { "adx_name", "adx_type", "adx_attributelogicalname", "adx_entityform", "adx_subgrid_name", "adx_tabname" };
                dataModel = GenerateData(attributes, ec, settingsJsonAttributes, ignoreAttributes);
                PopulateGrid(dataModel, grid, tbPage);
            }
        }

        #endregion

        #region Web Form 


        #endregion

        #region Web Form Metadata 

        #endregion

        #region Web Form Step 

        #endregion

        #region Web Page 

        #endregion

        #region Common Methods

        /// <summary>
        /// Populate Data Grid View
        /// </summary>
        /// <param name="dataModel"></param>
        /// <param name="grid"></param>
        /// <param name="tbPage"></param>
        private void PopulateGrid(List<DataModel> dataModel, DataGridView grid, TabPage tbPage)
        {
            grid.Columns.Clear();
            grid.Rows.Clear();

            grid.Columns.Add(_dataGridModel.IdColumn);
            grid.Columns.Add(_dataGridModel.NameColumn);
            grid.Columns.Add(_dataGridModel.AttributeColumnLogicalName);
            grid.Columns.Add(_dataGridModel.AttributeDisplayNameColumn);
            grid.Columns.Add(_dataGridModel.JsonPathColumn);
            grid.Columns.Add(_dataGridModel.SettingsJsonColumn);

            foreach (LanguageModel l in _selectedLanguages)
            {
                DataGridViewColumn languageColumn = new DataGridViewTextBoxColumn();
                languageColumn.Name = l.WebsiteLanguage.Id.ToString();
                languageColumn.HeaderText = l.LanguageName;

                grid.Columns.Add(languageColumn);
            }

            foreach (DataModel efm in dataModel)
            {
                int index = grid.Rows.Add();
                grid.Rows[index].Cells[_dataGridModel.IdColumn.Name].Value = efm.ID;
                grid.Rows[index].Cells[_dataGridModel.AttributeDisplayNameColumn.Name].Value = efm.Attribute;
                grid.Rows[index].Cells[_dataGridModel.AttributeColumnLogicalName.Name].Value = efm.AttributeLogicaName;
                grid.Rows[index].Cells[_dataGridModel.NameColumn.Name].Value = efm.Name;

                foreach (CommonModel cm in efm.Values)
                {
                    // only add data from JSON that the language has been selected
                    if (_selectedLanguages.Select(x => x.LCID).Contains(cm.LCID))
                    {
                        grid.Rows[index].Cells[_dataGridModel.JsonPathColumn.Name].Value = cm.JsonPath;
                        grid.Rows[index].Cells[_dataGridModel.SettingsJsonColumn.Name].Value = cm.SettingsJson;
                        grid.Rows[index].Cells[_selectedLanguages.Where(x => x.LCID.Equals(cm.LCID)).Select(x => x.WebsiteLanguage.Id).FirstOrDefault().ToString()].Value = cm.Value;
                    }
                }
            }

            Invoke(new Action(() => { tbGrid.TabPages.Add(tbPage); }));
        }

        /// <summary>
        /// Set common filters according to user selection in application form
        /// </summary>
        /// <param name="qe">Query Expression</param>
        /// <param name="le">Link Entity object for Website filtering</param>
        private void SetCommonFilters(ref QueryExpression qe, LinkEntity le)
        {
            if (cbxActiveRecords.Checked)
                qe.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
            if (cbxCreatedAfter.Checked && cbxModifiedAfter.Checked)
            {
                FilterExpression fe = qe.Criteria.AddFilter(LogicalOperator.Or);
                fe.AddCondition("createdon", ConditionOperator.OnOrAfter, dtpCreatedAfter.Value.Date);
                fe.AddCondition("modifiedon", ConditionOperator.OnOrAfter, dtpModifiedAfter.Value.Date);
            }
            else
            {
                if (cbxCreatedAfter.Checked)
                    qe.Criteria.AddCondition("createdon", ConditionOperator.OnOrAfter, dtpCreatedAfter.Value.Date);
                if (cbxModifiedAfter.Checked)
                    qe.Criteria.AddCondition("modifiedon", ConditionOperator.OnOrAfter, dtpModifiedAfter.Value.Date);
            }


            EntityReference selectedWebsite = null;
            Invoke(new Action(() =>
            {
                selectedWebsite = new EntityReference("adx_website", (ddlWebsite.SelectedItem as WebsiteModel).ID);
            }));

            if (le == null)
                qe.Criteria.AddCondition("adx_websiteid", ConditionOperator.Equal, selectedWebsite.Id);
            else
                le.LinkCriteria.AddCondition("adx_websiteid", ConditionOperator.Equal, selectedWebsite.Id);
        }

        private List<DataModel> GenerateData(List<AttributeHelperModel> attributes, EntityCollection ec, string[] settingsJsonAttributes, string[] ignoreAttributes)
        {
            List<DataModel> dataModel = new List<DataModel>();

            foreach (Entity entity in ec.Entities)
            {
                foreach (var attr in attributes.Select(x => x.AttributeLogicalName).Distinct())
                {
                    if (ignoreAttributes.Contains(attr)) continue;

                    if (!string.IsNullOrEmpty(entity.GetAttributeValue<string>(attr)))
                    {
                        string value = entity.GetAttributeValue<string>(attr);

                        List<CommonModel> values = new List<CommonModel>();
                        if (settingsJsonAttributes.Contains(attr))
                        {
                            values = DataModel.ParseSettingsJson(value);
                            List<string> jsonPaths = values.Select(x => x.JsonPath).Distinct().ToList();
                            foreach (string path in jsonPaths)
                            {
                                dataModel.Add(new DataModel()
                                {
                                    Attribute = DataModel.GetDisplayName(attr, attributes, path),
                                    AttributeLogicaName = attr,
                                    Name = GetRecordName(entity),
                                    ID = entity.Id,
                                    Values = values.Where(x => x.JsonPath.Equals(path)).ToList(),
                                });
                            }
                        }
                        else
                        {
                            values = DataModel.ParseGenericJson(value);

                            dataModel.Add(new DataModel()
                            {
                                Attribute = DataModel.GetDisplayName(attr, attributes),
                                AttributeLogicaName = attr,
                                Name = GetRecordName(entity),
                                ID = entity.Id,
                                Values = values
                            });
                        }
                    }
                }
            }
            return dataModel;
        }

        private string GetRecordName(Entity entity)
        {
            switch (entity.LogicalName)
            {
                case "adx_contentsnippet":
                case "adx_entityform":
                case "adx_webform":
                case "adx_entitylist":
                    return entity.GetAttributeValue<string>("adx_name");
                case "adx_entityformmetadata":
                    return GetEntityFormMetadataRecordName(entity);
                case "adx_webformmetadata":
                    return GetWebFormMetadataRecordName(entity);
                default:
                    return "";
            }
        }

        private string GetEntityFormMetadataRecordName(Entity entity)
        {
            string recordName = string.Empty;
            OptionSetValue type = entity.GetAttributeValue<OptionSetValue>("adx_type");
            EntityReference entityForm = entity.GetAttributeValue<EntityReference>("adx_entityform");
            if (type != null && entityForm != null)
            {
                Enums.EntityFormMetadata_Type typeEnum = (Enums.EntityFormMetadata_Type)type.Value;
                string entityFormName = entityForm.Name;
                string objectName = string.Empty;

                switch (typeEnum)
                {
                    case Enums.EntityFormMetadata_Type.Attribute:
                        {
                            Entity entityFormAdditionalData = GetEntityFormAdditionalData(entityForm);
                            objectName = GetAttributeDisplayNameByLogicalName(entityFormAdditionalData.GetAttributeValue<string>("adx_entityname"), entity.GetAttributeValue<string>("adx_attributelogicalname"));
                            recordName = string.Format("{0} - {1} - {2}", entityFormName, typeEnum.ToString(), objectName);
                            break;
                        }
                    case Enums.EntityFormMetadata_Type.Section:
                        break;
                    case Enums.EntityFormMetadata_Type.Tab:
                        objectName = entity.GetAttributeValue<string>("adx_tabname");
                        recordName = string.Format("{0} - {1} - {2}", entityFormName, typeEnum.ToString(), objectName);
                        break;
                    case Enums.EntityFormMetadata_Type.Subgrid:
                        objectName = entity.GetAttributeValue<string>("adx_subgrid_name");
                        recordName = string.Format("{0} - {1} - {2}", entityFormName, typeEnum.ToString(), objectName);
                        break;
                    case Enums.EntityFormMetadata_Type.Notes:
                        recordName = string.Format("{0} - {1}", entityFormName, typeEnum.ToString());
                        break;
                    case Enums.EntityFormMetadata_Type.Timeline:
                        recordName = string.Format("{0} - {1} - {2}", entityFormName, typeEnum.ToString(), "Timeline");
                        break;
                    default:
                        break;
                }
            }
            return recordName;
        }

        private Entity GetEntityFormAdditionalData(EntityReference entityForm)
        {
            string[] columnSet = new string[] { "adx_entityname", "adx_formname", "adx_tabname" };
            return Service.Retrieve(entityForm.LogicalName, entityForm.Id, new ColumnSet(columnSet));
        }

        private string GetAttributeDisplayNameByLogicalName(string entity, string attributeLogicalName)
        {
            RetrieveAttributeRequest attributeRequest = new RetrieveAttributeRequest();
            attributeRequest.EntityLogicalName = entity;
            attributeRequest.LogicalName = attributeLogicalName;
            attributeRequest.RetrieveAsIfPublished = true;

            RetrieveAttributeResponse attributeResponse = (RetrieveAttributeResponse)Service.Execute(attributeRequest);

            if (attributeResponse != null)
            {
                return ((AttributeMetadata)(attributeResponse.Results.FirstOrDefault().Value)).DisplayName.LocalizedLabels.FirstOrDefault().Label;
            }

            return string.Empty;
        }

        private string GetWebFormMetadataRecordName(Entity entity)
        {
            string recordName = string.Empty;
            OptionSetValue type = entity.GetAttributeValue<OptionSetValue>("adx_type");
            EntityReference webForm = entity.GetAttributeValue<EntityReference>("adx_webformid");
            if (type != null && webForm != null)
            {
                //switch ((Enums.WebFormMetadata_Type)type)
                //{
                //    case    type.
                //    default:
                //        break;
                //}
                Enums.WebFormMetadata_Type typeEnum = (Enums.WebFormMetadata_Type)type.Value;
                string webFormName = webForm.Name;
                recordName = string.Format("{0} - {1}", webFormName, type.ToString());
            }
            return recordName;
        }

        private void menuControl_ButtonExportDataClicked(object sender, EventArgs e)
        {

        }

        private void menuControl_ButtonImportDataClicked(object sender, EventArgs e)
        {

        }

        #endregion

        /*
         * 
         private void RetrieveEntityFormMetadataEntity()
        {
            string[] fieldNames = {
                "adx_description",
                "adx_label", "adx_subgrid_settings",
                "adx_notes_settings", "adx_timeline_settings", "adx_requiredfieldvalidationerrormessage" };

            QueryExpression qe = new QueryExpression("adx_entityformmetadata");
            qe.ColumnSet.AllColumns = true;
            qe.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
            if (modifiedAfterDate != null)
                qe.Criteria.AddCondition("modifiedon", ConditionOperator.GreaterEqual, modifiedAfterDate.Value.Date);

            LinkEntity linkForm = new LinkEntity("adx_entityformmetadata", "adx_entityform", "adx_entityform", "adx_entityformid", JoinOperator.Inner);
            linkForm.LinkCriteria.AddCondition("adx_websiteid", ConditionOperator.Equal, applicantPortalId);
            qe.LinkEntities.Add(linkForm);


            EntityCollection eCollection = _orgService.RetrieveMultiple(qe);

            foreach (var fieldName in fieldNames) //looping over each field
            {
                List<CRMDataObject> CRMDataList = new List<CRMDataObject>();
                if (eCollection != null)
                {
                    foreach (var entity in eCollection.Entities)
                    {
                        if (!string.IsNullOrEmpty(entity.GetAttributeValue<string>(fieldName)))
                        {
                            CRMDataList.Add(
                            new CRMDataObject("adx_entityformmetadata",
                            entity.GetAttributeValue<Guid>("adx_entityformmetadataid"), entity.GetAttributeValue<string>(fieldName), "", fieldName)
                            );
                        }
                    }
                }
                TraceMessage(String.Format("{0} Records retrieved from adx_entityformmetadata_{1} entity", CRMDataList.Count, fieldName));
                if (fieldName == "adx_subgrid_settings" ||
                    fieldName == "adx_notes_settings" ||
                    fieldName == "adx_timeline_settings")
                {
                    Insert_CRMObject_In_DataTable(JsonHelper.ParseComplexJson(CRMDataList));
                }
                else
                {

                    Insert_CRMObject_In_DataTable(JsonHelper.ParseSimpleJson(CRMDataList));
                }

            }

        }
        
        private void RetrieveWebFormMetadataEntity()
        {
            string[] fieldNames = { "adx_description", "adx_label", "adx_subgrid_settings" };

            QueryExpression qe = new QueryExpression("adx_webformmetadata");
            qe.ColumnSet.AllColumns = true;
            qe.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
            if (modifiedAfterDate != null)
                qe.Criteria.AddCondition("modifiedon", ConditionOperator.GreaterEqual, modifiedAfterDate.Value.Date);

            LinkEntity linkFormStep = new LinkEntity("adx_webformstep", "adx_webform", "adx_webform", "adx_webformid", JoinOperator.Inner);
            LinkEntity linkForm = new LinkEntity("adx_webformmetadata", "adx_webformstep", "adx_webformstep", "adx_webformstepid", JoinOperator.Inner);

            linkFormStep.LinkCriteria.AddCondition("adx_websiteid", ConditionOperator.Equal, applicantPortalId);
            linkForm.LinkEntities.Add(linkFormStep);
            qe.LinkEntities.Add(linkForm);

            EntityCollection eCollection = _orgService.RetrieveMultiple(qe);

            foreach (var fieldName in fieldNames)
            {
                List<CRMDataObject> CRMDataList = new List<CRMDataObject>();
                if (eCollection != null)
                {
                    foreach (var entity in eCollection.Entities)
                    {
                        if (!string.IsNullOrEmpty(entity.GetAttributeValue<string>(fieldName)))
                        {
                            CRMDataList.Add(
                            new CRMDataObject("adx_webformmetadata",
                            entity.GetAttributeValue<Guid>("adx_webformmetadataid"), entity.GetAttributeValue<string>(fieldName), "", fieldName)
                            );
                        }
                    }
                }
                TraceMessage(String.Format("{0} Records retrieved from adx_webformmetadata_{1} entity", CRMDataList.Count, fieldName));
                //parse json
                if (fieldName != "adx_subgrid_settings")
                    Insert_CRMObject_In_DataTable(JsonHelper.ParseSimpleJson(CRMDataList));
                else
                {
                    Insert_CRMObject_In_DataTable(JsonHelper.ParseComplexJson(CRMDataList));
                }
            }
        }


        private void RetrieveWebFormEntity()
        {
            string[] fieldNames = { "adx_savechangeswarningmessage", "adx_editexpiredmessage" };

            QueryExpression qe = new QueryExpression("adx_webform");
            qe.ColumnSet.AllColumns = true;
            qe.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
            qe.Criteria.AddCondition("adx_websiteid", ConditionOperator.Equal, applicantPortalId);
            if (modifiedAfterDate != null)
                qe.Criteria.AddCondition("modifiedon", ConditionOperator.GreaterEqual, modifiedAfterDate.Value.Date);

            EntityCollection eCollection = _orgService.RetrieveMultiple(qe); //it will retrieve the all attrributes

            foreach (var fieldName in fieldNames)
            {
                List<CRMDataObject> CRMDataList = new List<CRMDataObject>();

                if (eCollection != null)
                {
                    foreach (var entity in eCollection.Entities)
                    {
                        if (!string.IsNullOrEmpty(entity.GetAttributeValue<string>(fieldName)))
                        {
                            CRMDataList.Add(
                            new CRMDataObject("adx_webform",
                            entity.GetAttributeValue<Guid>("adx_webformid"), entity.GetAttributeValue<string>(fieldName), "", fieldName)
                            );
                        }
                    }
                }
                TraceMessage(String.Format("{0} Records retrieved from adx_webform_{1} entity", CRMDataList.Count, fieldName));
                Insert_CRMObject_In_DataTable(JsonHelper.ParseSimpleJson(CRMDataList));
            }
        }

        private void RetrieveEntityListEntity()
        {
            string[] fieldNames = { "adx_settings", "adx_emptylisttext", "adx_createbuttonlabel",
            "adx_filter_applybuttonlabel","adx_searchplaceholdertext","adx_searchtooltiptext","adx_detailsbuttonlabel", "adx_views"};

            QueryExpression qe = new QueryExpression("adx_entitylist");
            qe.ColumnSet.AllColumns = true;
            qe.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
            qe.Criteria.AddCondition("adx_name", ConditionOperator.NotLike, "%AP Test%");
            qe.Criteria.AddCondition("adx_name", ConditionOperator.NotLike, "%AP Design%");
            qe.Criteria.AddCondition("adx_websiteid", ConditionOperator.Equal, applicantPortalId);
            if (modifiedAfterDate != null)
                qe.Criteria.AddCondition("modifiedon", ConditionOperator.GreaterEqual, modifiedAfterDate.Value.Date);

            EntityCollection eCollection = _orgService.RetrieveMultiple(qe);

            foreach (var fieldName in fieldNames)
            {
                List<CRMDataObject> CRMDataList = new List<CRMDataObject>();
                if (eCollection != null)
                {
                    foreach (var entity in eCollection.Entities)
                    {
                        if (!string.IsNullOrEmpty(entity.GetAttributeValue<string>(fieldName)))
                        {
                            CRMDataList.Add(
                            new CRMDataObject("adx_entitylist",
                            entity.GetAttributeValue<Guid>("adx_entitylistid"), entity.GetAttributeValue<string>(fieldName), "", fieldName)
                            );
                        }
                    }
                }
                TraceMessage(String.Format("{0} Records retrieved from adx_entitylist_{1} entity", CRMDataList.Count, fieldName));
                //parse json
                if (fieldName != "adx_settings" &&
                    fieldName != "adx_views")
                    Insert_CRMObject_In_DataTable(JsonHelper.ParseSimpleJson(CRMDataList));
                else
                {
                    Insert_CRMObject_In_DataTable(JsonHelper.ParseComplexJson(CRMDataList));
                }
            }
        }

        private void RetrieveWebFormStepEntity()

        {
            string[] fieldNames =
            {
                "adx_editexpiredmessage",
                "adx_title",
                "adx_validationsummaryheadertext" ,
                "adx_successmessage" ,
                "adx_submitbuttontext",
                "adx_recordnotfoundmessage",
                "adx_previousbuttontext",
                "adx_nextbuttontext",
                "adx_instructions",
                "adx_attachfiletypeerrormessage",
                "adx_attachfilesizeerrormessage",
                "adx_attachfilerequirederrormessage",
                "adx_submitbuttonbusytext",
                "adx_attachfilelabel",
                "adx_settings"
                // ....
            }; 

            QueryExpression qe = new QueryExpression("adx_webformstep");
            qe.ColumnSet.AllColumns = true;
            // filters
            //qe.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
            //if (modifiedAfterDate != null)
            //    qe.Criteria.AddCondition("modifiedon", ConditionOperator.GreaterEqual, modifiedAfterDate.Value.Date);

            //LinkEntity linkFormStep = new LinkEntity("adx_webformstep", "adx_webform", "adx_webform", "adx_webformid", JoinOperator.Inner);
            //linkFormStep.LinkCriteria.AddCondition("adx_websiteid", ConditionOperator.Equal, applicantPortalId);
            //qe.LinkEntities.Add(linkFormStep);

            EntityCollection ec = Service.RetrieveMultiple(qe);

            foreach (var fieldName in fieldNames)
            {
                List<CRMDataObject> CRMDataList = new List<CRMDataObject>();
                if (ec != null)
                {
                    foreach (var entity in ec.Entities)
                    {
                        if (!string.IsNullOrEmpty(entity.GetAttributeValue<string>(fieldName)))
                        {
                            CRMDataList.Add(
                            new CRMDataObject("adx_webformstep",
                            entity.GetAttributeValue<Guid>("adx_webformstepid"), entity.GetAttributeValue<string>(fieldName), "", fieldName)
                            );
                        }
                    }
                }
                if (fieldName != "adx_settings")
                    Insert_CRMObject_In_DataTable(JsonHelper.ParseSimpleJson(CRMDataList));
                else
                {
                    Insert_CRMObject_In_DataTable(JsonHelper.ParseComplexJson(CRMDataList));
                }
                TraceMessage(String.Format("{0} Records retrieved from adx_webformstep_{1} entity", CRMDataList.Count, fieldName));

            }
        }

        private void RetrieveWebPagesEntity()
        {
            string[] fieldNames = { "adx_copy", "adx_title" };

            QueryExpression qe = new QueryExpression("adx_webpage");
            qe.ColumnSet.AllColumns = true;
            qe.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
            qe.Criteria.AddCondition("adx_name", ConditionOperator.NotNull);
            qe.Criteria.AddCondition("adx_name", ConditionOperator.NotLike, "%AP Design%");
            qe.Criteria.AddCondition("adx_name", ConditionOperator.NotLike, "%AP Award Engine%");
            qe.Criteria.AddCondition("adx_name", ConditionOperator.NotLike, "%AP Test%");
            qe.Criteria.AddCondition("adx_name", ConditionOperator.NotLike, "%Testing%");
            qe.Criteria.AddCondition("adx_rootwebpageid", ConditionOperator.NotNull);
            qe.Criteria.AddCondition("adx_websiteid", ConditionOperator.Equal, applicantPortalId);
            qe.Criteria.AddCondition("adx_webpagelanguageid", ConditionOperator.Equal, englishId);
            if (modifiedAfterDate != null)
                qe.Criteria.AddCondition("modifiedon", ConditionOperator.GreaterEqual, modifiedAfterDate.Value.Date);

            //all english webpages
            EntityCollection eCollection = _orgService.RetrieveMultiple(qe);

            List<CRMDoubleRecordObJect> recordEN_list = new List<CRMDoubleRecordObJect>();
            List<CRMDoubleRecordObJect> recordIE_list = new List<CRMDoubleRecordObJect>();
            foreach (var fieldName in fieldNames)
            {
                if (eCollection != null)
                {
                    foreach (var entity in eCollection.Entities)
                    {
                        if (!string.IsNullOrEmpty(entity.GetAttributeValue<string>(fieldName)))
                        {
                            CRMDoubleRecordObJect webPageEN = PopulateWebPageObjects(entity, fieldName);
                            CRMDoubleRecordObJect webPageIE;

                            //temporary code // not //missing data throws error. work around it
                            EntityCollection eCollectionObj = GetIrishWebPageRecord(webPageEN.Name, fieldName, webPageEN.WebPageRootId.Id);
                            if (eCollectionObj.Entities.Count == 0)
                            {
                                webPageIE = new CRMDoubleRecordObJect();
                                TraceMessage("Could not Find realted Irish Entity with the name : " + webPageEN.Name, MessageLevel.Warning);
                                LogMissingRecord(entity, "adx_name");
                            }
                            else
                                webPageIE = PopulateWebPageObjects(eCollectionObj.Entities.First(), fieldName);
                            //end temp code

                            if (fieldName == "adx_copy")
                            {
                                recordEN_list = ParseHTML(webPageEN);    // parse EN = list
                                if (webPageIE.Value == null)
                                {
                                    recordIE_list.Clear();
                                    for (int i = 0; recordIE_list.Count < recordEN_list.Count; i++)
                                    {
                                        recordIE_list.Add(webPageIE);
                                    }
                                }
                                else
                                    recordIE_list = ParseHTML(webPageIE);  // parse IE = list

                                var maxCount = 0;
                                if (recordEN_list.Count >= recordIE_list.Count)
                                {
                                    for (int i = recordIE_list.Count; recordIE_list.Count < recordEN_list.Count; i++)
                                    {
                                        recordIE_list.Add(new CRMDoubleRecordObJect());
                                    }
                                    maxCount = recordEN_list.Count;
                                }
                                else
                                {
                                    maxCount = recordIE_list.Count;
                                    for (int i = recordEN_list.Count; recordEN_list.Count < recordIE_list.Count; i++)
                                    {
                                        recordEN_list.Add(new CRMDoubleRecordObJect());
                                    }
                                }

                                DataRow dr;  //adding to the data table
                                for (int i = 0; i < maxCount; i++)
                                {
                                    dr = dtHtml.NewRow();

                                    dr[0] = recordEN_list.First().GUID;
                                    dr[1] = recordEN_list.First().EntityName;
                                    try
                                    {
                                        dr[3] = recordEN_list[i].Value;
                                        dr[4] = recordIE_list[i].Value;

                                        if (!string.IsNullOrEmpty(recordEN_list[i].HTML) && !string.IsNullOrEmpty(recordEN_list[i].Tag_Index))
                                        {
                                            dr[6] = recordEN_list[i].HTML;
                                            dr[7] = recordEN_list[i].Tag_Index;
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        dr[6] = recordEN_list[i].HTML;
                                        dr[7] = recordEN_list[i].Tag_Index;
                                        TraceMessage(e.Message.ToString(), MessageLevel.Warning);
                                    }

                                    if (recordIE_list.Count > 0)
                                        dr[5] = recordIE_list.First().GUID;
                                    //if IE html doesnt have any text inside
                                    else if (webPageIE.GUID != Guid.Empty)
                                        dr[5] = webPageIE.GUID;
                                    dr[2] = recordEN_list.First().FieldName;
                                    dtHtml.Rows.Add(dr);
                                }
                            }
                            else
                            {
                                GroupDoubleRecords(webPageEN, webPageIE);
                            }
                        }
                    }
                }
            }

        }
        private EntityCollection GetIrishWebPageRecord(string name, string fieldName, Guid rootPageId)
        {
            QueryExpression qeIE = new QueryExpression("adx_webpage");
            qeIE.ColumnSet.AllColumns = true;
            qeIE.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
            qeIE.Criteria.AddCondition("adx_rootwebpageid", ConditionOperator.Equal, rootPageId);
            qeIE.Criteria.AddCondition("adx_name", ConditionOperator.Equal, name);
            qeIE.Criteria.AddCondition("adx_name", ConditionOperator.NotLike, "%AP Design%");
            qeIE.Criteria.AddCondition("adx_name", ConditionOperator.NotLike, "%AP Award Engine%");
            qeIE.Criteria.AddCondition("adx_name", ConditionOperator.NotLike, "%AP Test%");
            qeIE.Criteria.AddCondition("adx_name", ConditionOperator.NotLike, "%Testing%");
            qeIE.Criteria.AddCondition("adx_websiteid", ConditionOperator.Equal, applicantPortalId);
            qeIE.Criteria.AddCondition("adx_webpagelanguageid", ConditionOperator.Equal, irishId);
            //if (modifiedAfterDate != null)
            //    qeIE.Criteria.AddCondition("modifiedon", ConditionOperator.GreaterEqual, modifiedAfterDate.Value.Date);

            return _orgService.RetrieveMultiple(qeIE);
        }
        private CRMDoubleRecordObJect PopulateWebPageObjects(Entity recordWP, string fieldName)
        {
            return new CRMDoubleRecordObJect
                (
                    recordWP.GetAttributeValue<string>(fieldName),
                    recordWP.GetAttributeValue<EntityReference>("adx_webpagelanguageid"),
                    recordWP.GetAttributeValue<Guid>("adx_webpageid"),
                    recordWP.GetAttributeValue<string>("adx_name"), "adx_webpage", fieldName,
                    recordWP.GetAttributeValue<EntityReference>("adx_rootwebpageid")
                    );
        }
        */
    }

    [Obsolete("This class is obsolete")]
    public class CRMDataObject
    {
        public string Value { get; set; }
        public Guid GUID { get; set; }

        public string FieldName { get; set; }

        public string EntityName { get; set; }

        public string Path { get; set; }
        public string ComplexJson { get; set; }

        public string HTML { get; set; }

        public string Tag_Index { get; set; }

        public string ValueIE { get; set; }

        [Obsolete("This method is obsolete")]
        public CRMDataObject(string entity, Guid guid, string value, string valueIE, string fieldname)
        {
            this.Value = value;
            this.GUID = guid;
            this.EntityName = entity;
            this.ValueIE = valueIE;
            this.FieldName = fieldname;
        }

        public CRMDataObject()
        { }
    }

    [Obsolete("This class is obsolete")]
    public class ComplexJson
    {
        public int LCID { get; set; }
        public string Value { get; set; }
        public string Path { get; set; }

        public ComplexJson(int LCID, string value, string path)
        {
            this.LCID = LCID;
            Value = value;
            Path = path;
        }
    }
}