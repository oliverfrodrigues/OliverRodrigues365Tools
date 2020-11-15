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
//using System.Windows.Controls;
using Enums = Portals.MetadataTranslationManager.Model.Enums;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Crm.Sdk.Messages;
using System.Globalization;
using Microsoft.Xrm.Sdk.Metadata.Query;

namespace Portals.MetadataTranslationManager
{
    public partial class MetadataTranslatorControl : PluginControlBase
    {
        #region Properties

        private Settings mySettings;
        private List<EntityMetadata> _entityMetadataList = new List<EntityMetadata>();
        public readonly List<ListViewItem> _languageItems = new List<ListViewItem>();
        public readonly List<ListViewItem> _entityItems = new List<ListViewItem>();

        public List<LanguageModel> _selectedLanguages
        {
            get
            {
                return lvLanguages.CheckedItems.Cast<ListViewItem>().ToList().Select(x => new LanguageModel
                {
                    WebsiteLanguage = new EntityReference("adx_websitelanguage", Guid.Parse(x.Tag.ToString())),
                    LCID = int.Parse(x.Text.Substring(x.Text.Length - 4, 4)),
                    LanguageName = x.Text.Substring(0, x.Text.IndexOf(" - "))
                }).ToList();
            }
        }
        public List<LanguageModel> _languageData { get; private set; }

        public List<EntityMetadata> _entityMetadata { get; private set; }
        public List<EntityMetadata> _selectedEntities
        {
            get
            {
                return lvEntities.CheckedItems.Cast<ListViewItem>().ToList().Select(x => x.Tag as EntityMetadata).ToList();
            }

            //get { return (List<EntityMetadata>)Invoke(new Action(() => { lvEntities.CheckedItems.Cast<ListViewItem>().Select(x => x.Tag as EntityMetadata).ToList(); })); }
        }

        public DataGridHelper _dataGridModel { get; set; }

        #endregion

        #region Constructors
        public MetadataTranslatorControl()
        {
            InitializeComponent();

            tbGrid.TabPages.Clear();
            btnImportData.Visible = false;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void btnImportData_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportData();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadData);
        }

        private void btnLoadEnvironment_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadEnvironmentSetup);
        }

        private void btnSelectAllEntities_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvEntities.Items)
            {
                item.Checked = true;
            }
        }

        private void btnClearSelectionEntities_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvEntities.Items)
            {
                item.Checked = false;
            }
        }

        private void btnSelectAllLanguages_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvLanguages.Items)
            {
                if (new Guid(item.Tag.ToString()) != (Guid.Empty))
                    item.Checked = true;
            }
        }

        private void btnClearSelectionLanguages_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvLanguages.Items)
            {
                item.Checked = false;
            }
        }

        private void lvLanguages_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked && new Guid(e.Item.Tag.ToString()) == (Guid.Empty))
            {
                MessageBox.Show("This language is available in your CDS/D365, but missing Website Language linked to your Portals");
                e.Item.Checked = false;
            }
        }

        private void menuControl_ButtonExportDataClicked(object sender, EventArgs e)
        {

        }

        private void menuControl_ButtonImportDataClicked(object sender, EventArgs e)
        {

        }

        #endregion

        private void LoadEnvironmentSetup()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading environment configuration",
                Work = (worker, args) =>
                {
                    LoadEntities();

                    LoadLanguages();
                    LoadWebsites();
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    PopulateEntitiesList();
                    PopulateLanguageList();
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
        }

        private void LoadData()
        {
            List<EntityMetadata> selectedEntities = _selectedEntities;
            List<LanguageModel> selectedLanguages = _selectedLanguages;
            if (selectedEntities.Count == 0)
            {
                MessageBox.Show(this, "Please select at least one entity!", "No entities selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (selectedLanguages.Count == 0)
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

            _dataGridModel = new DataGridHelper();

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

                    foreach (EntityMetadata e in selectedEntities)
                    {
                        bw.ReportProgress(10, string.Format("Retrieving data for: {0}", e.LogicalName));

                        switch (e.LogicalName)
                        {
                            case "adx_entityform":
                                GetEntityFormData(selectedLanguages);
                                break;
                            case "adx_entityformmetadata":
                                GetEntityFormMetadataData(selectedLanguages);
                                break;
                            case "adx_entitylist":
                                GetEntityListData(selectedLanguages);
                                break;
                            case "adx_webform":
                                GetWebFormData(selectedLanguages);
                                break;
                            case "adx_webformstep":
                                GetWebFormStepData(selectedLanguages);
                                break;
                            case "adx_webformmetadata":
                                GetWebFormMetadataData(selectedLanguages);
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

        public void GetEntityListData(List<LanguageModel> selectedLanguages)
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
                PopulateGrid(dataModel, grid, tbPage, selectedLanguages);
            }
        }

        #endregion

        #region Entity Form 

        private void GetEntityFormData(List<LanguageModel> selectedLanguages)
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
                PopulateGrid(dataModel, grid, tbPage, selectedLanguages);
            }
        }

        #endregion

        #region Entity Form Metadata 
        private void GetEntityFormMetadataData(List<LanguageModel> selectedLanguages)
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
                PopulateGrid(dataModel, grid, tbPage, selectedLanguages);
            }
        }

        #endregion

        #region Web Form 

        private void GetWebFormData(List<LanguageModel> selectedLanguages)
        {
            _dataGridModel = new DataGridHelper();
            List<AttributeHelperModel> attributes = DataModel.GetAttributeListWebForm();

            QueryExpression qe = new QueryExpression("adx_webform");
            qe.ColumnSet = new ColumnSet(attributes.Select(x => x.AttributeLogicalName).Distinct().ToArray());
            SetCommonFilters(ref qe, null);

            EntityCollection ec = Service.RetrieveMultiple(qe);

            if (ec != null)
            {
                int countRecord = ec.Entities.Count;
                List<DataModel> dataModel = new List<DataModel>();

                DataGridView grid;
                TabPage tbPage = _dataGridModel.GenerateTab("Web Form", countRecord, out grid, this);
                string[] settingsJsonAttributes = new string[] { };
                string[] ignoreAttributes = new string[] { "adx_name" };
                dataModel = GenerateData(attributes, ec, settingsJsonAttributes, ignoreAttributes);
                //LogInfo(String.Format("{0} Records retrieved from adx_entityform entity", CRMDataList.Count));
                PopulateGrid(dataModel, grid, tbPage, selectedLanguages);
            }
        }


        #endregion

        #region Web Form Step 

        private void GetWebFormStepData(List<LanguageModel> selectedLanguages)
        {
            _dataGridModel = new DataGridHelper();
            List<AttributeHelperModel> attributes = DataModel.GetAttributeListWebFormStep();

            QueryExpression qe = new QueryExpression("adx_webformstep");
            qe.ColumnSet = new ColumnSet(attributes.Select(x => x.AttributeLogicalName).Distinct().ToArray());
            LinkEntity le = new LinkEntity("adx_webformstep", "adx_webform", "adx_webform", "adx_webformid", JoinOperator.Inner);
            SetCommonFilters(ref qe, le);
            qe.LinkEntities.Add(le);

            EntityCollection ec = Service.RetrieveMultiple(qe);

            if (ec != null)
            {
                int countRecord = ec.Entities.Count;
                List<DataModel> dataModel = new List<DataModel>();

                DataGridView grid;
                TabPage tbPage = _dataGridModel.GenerateTab("Web Form Step", countRecord, out grid, this);
                string[] settingsJsonAttributes = new string[] { "adx_settings" };
                string[] ignoreAttributes = new string[] { "adx_name" };
                dataModel = GenerateData(attributes, ec, settingsJsonAttributes, ignoreAttributes);
                //LogInfo(String.Format("{0} Records retrieved from adx_entityform entity", CRMDataList.Count));
                PopulateGrid(dataModel, grid, tbPage, selectedLanguages);
            }
        }

        #endregion

        #region Web Form Metadata 
        private void GetWebFormMetadataData(List<LanguageModel> selectedLanguages)
        {
            _dataGridModel = new DataGridHelper();
            List<AttributeHelperModel> attributes = DataModel.GetAttributeListWebFormMetadata();

            QueryExpression qe = new QueryExpression("adx_webformmetadata");
            qe.ColumnSet = new ColumnSet(attributes.Select(x => x.AttributeLogicalName).Distinct().ToArray());
            LinkEntity le = new LinkEntity("adx_webformmetadata", "adx_webformstep", "adx_webformstep", "adx_webformstepid", JoinOperator.Inner);
            LinkEntity le2 = new LinkEntity("adx_webformstep", "adx_webform", "adx_webform", "adx_webformid", JoinOperator.Inner);
            SetCommonFilters(ref qe, le2);
            qe.LinkEntities.Add(le);

            EntityCollection ec = Service.RetrieveMultiple(qe);

            if (ec != null)
            {
                int countRecord = ec.Entities.Count;
                List<DataModel> dataModel = new List<DataModel>();

                DataGridView grid;
                TabPage tbPage = _dataGridModel.GenerateTab("Web Form Metadata", countRecord, out grid, this);

                string[] settingsJsonAttributes = new string[] { "adx_subgrid_settings", "adx_notes_settings", "adx_timeline_settings" };
                string[] ignoreAttributes = new string[] { "adx_type", "adx_attributelogicalname", "adx_webform", "adx_subgrid_name", "adx_tabname", "adx_webformstep", "adx_sectionname" };
                dataModel = GenerateData(attributes, ec, settingsJsonAttributes, ignoreAttributes);
                PopulateGrid(dataModel, grid, tbPage, selectedLanguages);
            }
        }

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
        private void PopulateGrid(List<DataModel> dataModel, DataGridView grid, TabPage tbPage, List<LanguageModel> selectedLanguages)
        {
            grid.Columns.Clear();
            grid.Rows.Clear();

            grid.Columns.Add(_dataGridModel.IdColumn);
            grid.Columns.Add(_dataGridModel.NameColumn);
            grid.Columns.Add(_dataGridModel.AttributeColumnLogicalName);
            grid.Columns.Add(_dataGridModel.AttributeDisplayNameColumn);
            grid.Columns.Add(_dataGridModel.JsonPathColumn);
            grid.Columns.Add(_dataGridModel.SettingsJsonColumn);

            foreach (LanguageModel l in selectedLanguages)
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
                    if (selectedLanguages.Select(x => x.LCID).Contains(cm.LCID))
                    {
                        grid.Rows[index].Cells[_dataGridModel.JsonPathColumn.Name].Value = cm.JsonPath;
                        grid.Rows[index].Cells[_dataGridModel.SettingsJsonColumn.Name].Value = cm.SettingsJson;
                        grid.Rows[index].Cells[selectedLanguages.Where(x => x.LCID.Equals(cm.LCID)).Select(x => x.WebsiteLanguage.Id).FirstOrDefault().ToString()].Value = cm.Value;
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
                case "adx_webformstep":
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

        private Entity GetWebFormAdditionalData(EntityReference webForm)
        {
            string[] columnSet = new string[] { "adx_targetentitylogicalname", "adx_formname", "adx_tabname" };
            return Service.Retrieve(webForm.LogicalName, webForm.Id, new ColumnSet(columnSet));
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
            EntityReference webFormstep = entity.GetAttributeValue<EntityReference>("adx_webformstep");
            if (type != null && webFormstep != null)
            {
                Enums.WebFormMetadata_Type typeEnum = (Enums.WebFormMetadata_Type)type.Value;
                string entityFormName = webFormstep.Name;
                string objectName = string.Empty;

                switch (typeEnum)
                {
                    case Enums.WebFormMetadata_Type.Attribute:
                        {
                            Entity webFormAdditionalData = GetWebFormAdditionalData(webFormstep);
                            objectName = GetAttributeDisplayNameByLogicalName(webFormAdditionalData.GetAttributeValue<string>("adx_targetentitylogicalname"), entity.GetAttributeValue<string>("adx_attributelogicalname"));
                            recordName = string.Format("{0} - {1} - {2}", entityFormName, typeEnum.ToString(), objectName);
                            break;
                        }
                    case Enums.WebFormMetadata_Type.Section:
                        objectName = entity.GetAttributeValue<string>("adx_sectionname");
                        recordName = string.Format("{0} - {1} - {2}", entityFormName, typeEnum.ToString(), objectName);
                        break;
                    case Enums.WebFormMetadata_Type.Tab:
                        objectName = entity.GetAttributeValue<string>("adx_tabname");
                        recordName = string.Format("{0} - {1} - {2}", entityFormName, typeEnum.ToString(), objectName);
                        break;
                    case Enums.WebFormMetadata_Type.Subgrid:
                        objectName = entity.GetAttributeValue<string>("adx_subgrid_name");
                        recordName = string.Format("{0} - {1} - {2}", entityFormName, typeEnum.ToString(), objectName);
                        break;
                    case Enums.WebFormMetadata_Type.Notes:
                        recordName = string.Format("{0} - {1}", entityFormName, typeEnum.ToString());
                        break;
                    case Enums.WebFormMetadata_Type.Timeline:
                        recordName = string.Format("{0} - {1} - {2}", entityFormName, typeEnum.ToString(), "Timeline");
                        break;
                    //case Enums.WebFormMetadata_Type.Purchase:
                    //    recordName = string.Format("{0} - {1} - {2}", entityFormName, typeEnum.ToString(), "Timeline");
                    //    break;
                    default:
                        break;
                }
            }
            return recordName;
        }

        public void LoadLanguages()
        {
            RetrieveAvailableLanguagesRequest request = new RetrieveAvailableLanguagesRequest();

            RetrieveAvailableLanguagesResponse fullResponse = (RetrieveAvailableLanguagesResponse)Service.Execute(request);

            List<int> LCIDs = fullResponse.LocaleIds.ToList();

            _languageItems.Clear();

            _languageData = new List<LanguageModel>();

            foreach (int l in LCIDs)
            {
                CultureInfo cInfo = CultureInfo.GetCultureInfo(l);
                EntityReference websiteLanguage = GetWebsiteLanguage(l);

                _languageData.Add(new LanguageModel()
                {
                    LCID = l,
                    LanguageName = cInfo.DisplayName,
                    WebsiteLanguage = websiteLanguage
                });

                string displayName = string.Format("{0} - {1}", cInfo.DisplayName, l);
                ListViewItem listItem = new ListViewItem(displayName);
                listItem.Tag = websiteLanguage.Id;
                listItem.Checked = true;
                if (websiteLanguage.Id == Guid.Empty)
                {
                    listItem.Text += " - Unavailable";
                    listItem.BackColor = System.Drawing.Color.DarkSlateGray;
                    listItem.ToolTipText = "This language is available in your CDS/D365, but missing Website Language linked to your Portals";
                    listItem.Checked = false;
                    listItem.ForeColor = System.Drawing.Color.Orange;
                }

                _languageItems.Add(listItem);
            }
        }

        public void LoadEntities()
        {
            string[] logicalNames = new string[] {
                //"adx_contentsnippet",
                "adx_entityform",
                "adx_entityformmetadata",
                "adx_entitylist",
                "adx_webform",
                "adx_webformmetadata",
                "adx_webformstep",
                //"adx_webpage",

                // POLL
                // WEB LINK
                // SITE MARKER
            };

            EntityQueryExpression adxEntitiesQueryExpression = new EntityQueryExpression
            {
                Properties = new MetadataPropertiesExpression
                {
                    AllProperties = false,
                    PropertyNames =
                    {
                        "DisplayName",
                        "LogicalName",
                        "SchemaName",
                        "Attributes",
                        "ObjectTypeCode"
                    }
                },
                AttributeQuery = new AttributeQueryExpression
                {
                    Properties = new MetadataPropertiesExpression
                    {
                        AllProperties = false
                        //,
                        //PropertyNames = { "IsValidForCreate", "IsValidForUpdate", "LogicalName", "Targets", "OptionSet", "DisplayName" }
                    }
                },
                Criteria = new MetadataFilterExpression
                {
                    Conditions =
                    {
                        new MetadataConditionExpression("LogicalName", MetadataConditionOperator.In, logicalNames.ToArray())
                    }
                }
            };

            RetrieveMetadataChangesRequest request = new RetrieveMetadataChangesRequest
            {
                Query = adxEntitiesQueryExpression,
                ClientVersionStamp = null
            };

            var fullResponse = (RetrieveMetadataChangesResponse)Service.Execute(request);

            _entityMetadata = fullResponse.EntityMetadata.ToList();

            _entityItems.Clear();

            foreach (var metadata in _entityMetadata)
            {
                _entityItems.Add(new ListViewItem(metadata.DisplayName?.UserLocalizedLabel?.Label ?? metadata.SchemaName)
                {
                    Tag = metadata,
                    Checked = true
                });
            }
        }

        private EntityReference GetWebsiteLanguage(int lcid)
        {
            QueryExpression qe = new QueryExpression("adx_websitelanguage");
            qe.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
            qe.TopCount = 1;

            LinkEntity le = qe.AddLink("adx_portallanguage", "adx_portallanguageid", "adx_portallanguageid", JoinOperator.Inner);
            le.LinkCriteria.AddCondition("statecode", ConditionOperator.Equal, 0);
            le.LinkCriteria.AddCondition("adx_lcid", ConditionOperator.Equal, lcid);
            le.EntityAlias = "pl";

            EntityCollection ec = Service.RetrieveMultiple(qe);
            Guid websiteLanguageGuid = Guid.Empty;

            if (ec != null && ec.Entities.Count > 0)
                websiteLanguageGuid = ec.Entities.FirstOrDefault().Id;

            return new EntityReference("adx_websitelanguage", websiteLanguageGuid);
        }

        public void PopulateLanguageList()
        {
            lvLanguages.Items.Clear();
            lvLanguages.Items.AddRange(_languageItems.ToArray());
        }

        public void PopulateEntitiesList()
        {
            lvEntities.Items.Clear();
            lvEntities.Items.AddRange(_entityItems.ToArray());
        }

        private void ExportData()
        {
            if (tbGrid.TabPages.Count == 0)
            {
                MessageBox.Show(this, "Please make sure you have data loaded before exporting it!", "No data loaded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.ShowDialog();
            saveDialog.Filter = "Excel |*.xlsx";
            if (!string.IsNullOrEmpty(saveDialog.FileName))
            {

                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Exporting data",
                    Work = (worker, args) =>
                    {
                        Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

                        int tabPagesIndex = 0;
                        foreach (TabPage tp in tbGrid.TabPages)
                        {
                            foreach (Control control in tp.Controls)
                            {
                                if (control is DataGridView)
                                {
                                    DataGridView dgv = (DataGridView)control;

                                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                                    if (tabPagesIndex > 0)
                                    {
                                        int count = workbook.Worksheets.Count;
                                        worksheet = workbook.Worksheets.Add(Type.Missing, workbook.Worksheets[count], Type.Missing, Type.Missing);
                                    }
                                    tabPagesIndex++;

                                    app.Visible = false;
                                    worksheet = workbook.Sheets["Sheet" + tabPagesIndex];
                                    worksheet = workbook.ActiveSheet;
                                    worksheet.Name = tp.Text;

                                    for (int i = 1; i < dgv.Columns.Count + 1; i++)
                                    {
                                        worksheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
                                    }
                                    for (int i = 0; i < dgv.Rows.Count - 1; i++)
                                    {
                                        for (int j = 0; j < dgv.Columns.Count; j++)
                                        {
                                            worksheet.Cells[i + 2, j + 1] = (dgv.Rows[i].Cells[j].Value != null ? dgv.Rows[i].Cells[j].Value.ToString() : "");
                                        }
                                    }

                                }
                            }
                        }
                        // save the application  
                        workbook.SaveAs(saveDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        // Exit from the application  
                        app.Quit();

                    },
                    PostWorkCallBack = (args) =>
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(saveDialog.FileName);
                        }
                        catch (Exception)
                        {

                            //throw;
                        }
                        
                    }
                });
            }
        }

        #endregion
    }
}