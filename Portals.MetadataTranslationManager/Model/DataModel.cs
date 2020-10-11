using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Portals.MetadataTranslationManager.Model
{
    public class DataModel
    {
        private static readonly string _typeLanguageResource = "Adxstudio.Xrm.Web.UI.WebForms.LanguageResources, Adxstudio.Xrm";
        private static readonly string _typeOverrideColumn = "Adxstudio.Xrm.Web.UI.CrmEntityListView.ViewColumn, Adxstudio.Xrm";

        public Guid ID { get; set; }
        public string Attribute { get; set; }
        public string AttributeLogicaName { get; set; }
        public string Name { get; set; }
        public List<CommonModel> Values { get; set; }

        public DataModel()
        {
            Values = new List<CommonModel>();
        }

        public static List<CommonModel> ParseGenericJson(string jsonValue)
        {
            List<CommonModel> data = new List<CommonModel>();
            List<string> parseJsonObjectValue = new List<string>();
            var objects = JArray.Parse(jsonValue);
            foreach (JObject root in objects)
            {
                CommonModel obj = JsonConvert.DeserializeObject<CommonModel>(root.ToString());
                if (!string.IsNullOrWhiteSpace(obj.Value.ToString()))
                    data.Add(obj);
            }

            return data;
        }

        public static List<CommonModel> ParseSettingsJson(string jsonValue)
        {
            List<CommonModel> data = new List<CommonModel>();

            JObject rootObj = JObject.Parse(jsonValue);

            //get objects with $type language resource
            var jsonObjects = rootObj.DescendantsAndSelf()
                .OfType<JObject>()
                .Where(obj => obj.ContainsKey("$type") &&
                            obj["$type"].Value<string>().Equals(_typeLanguageResource) &&
                            !string.IsNullOrEmpty(obj["Value"].Value<string>()));

            foreach (var jsonObject in jsonObjects)
            {
                var objectType = jsonObjects.Where(x => x.Children().Contains(jsonObject));

                CommonModel jsonItem = JsonConvert.DeserializeObject<CommonModel>(jsonObject.ToString());
                jsonItem.JsonPath = jsonObject.Path.Substring(0, jsonObject.Path.Length - 3); // remove last brackets with language index
                jsonItem.SettingsJson = jsonValue;
                data.Add(jsonItem);
            }

            return data;
        }

        public static string GetDisplayName(string attributeLogicalName, List<AttributeHelperModel> attributeList)
        {
            return attributeList.Where(x => x.AttributeLogicalName.Equals(attributeLogicalName)).FirstOrDefault().AttributeDisplayName;
        }

        public static string GetDisplayName(string attributeLogicalName, List<AttributeHelperModel> attributeList, string jsonPath)
        {
            string displayName = string.Empty;

            string index = string.Empty;
            if (Regex.IsMatch(jsonPath, @"^(.+?)\[\d+\]."))
            {
                index = Regex.Match(jsonPath, @"\d+").Value;

                jsonPath = jsonPath.Replace(index, "i");
            }
            AttributeHelperModel settingAttribute = attributeList.Where(x => x.AttributeLogicalName.Equals(attributeLogicalName) && x.AttributeJsonPath.Equals(jsonPath)).FirstOrDefault();
            if (settingAttribute != null)
                displayName = settingAttribute.AttributeDisplayName.Replace("[i]", "[" + index + "]");
            else
                displayName = jsonPath;

            return displayName;
        }

        public static List<AttributeHelperModel> GetAttributeListEntityList()
        {
            List<AttributeHelperModel> attributes = new List<AttributeHelperModel>();
            attributes.Add(new AttributeHelperModel("adx_name", "Name", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_emptylisttext", "Empty List Text", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_createbuttonlabel", "Create Button Label", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_filter_applybuttonlabel", "Filter - Apply Button Label", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_searchplaceholdertext", "Search Placeholder Text", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_searchtooltiptext", "Search Tooltip Text", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_detailsbuttonlabel", "Details Button Label", string.Empty));

            attributes.Add(new AttributeHelperModel("adx_views", "View[i] Display Name", "Views[i].DisplayName"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Success Message", "ViewActions[i].SuccessMessage"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Button Label", "ViewActions[i].ButtonLabel"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Button Toolip", "ViewActions[i].ButtonTooltip"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Confirmation", "ViewActions[i].Confirmation"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Loading Message", "LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Error Message", "ErrorMessage"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Access Denied Message", "AccessDeniedMessage"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Empty Message", "EmptyMessage"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Loading Message", "CreateFormDialog.LoadingMessage"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Item Action[i] Success Message", "ItemActions[i].SuccessMessage"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Item Action[i] Button Label", "ItemActions[i].ButtonLabel"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Item Action[i] Button Toolip", "ItemActions[i].ButtonTooltip"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Item Action[i] Confirmation", "ItemActions[i].Confirmation"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Item Action[i] Workflow Dialog Title", "ItemActions[i].WorkflowDialogTitle"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Item Action[i] Workflow Dialog Primary Button Text", "ItemActions[i].WorkflowDialogPrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Item Action[i] Workflow Dialog Close Button Text", "ItemActions[i].WorkflowDialogCloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Extented Item Action[i] Success Message", "ExtendedItemActions[i].SuccessMessage"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Extented Item Action[i] Button Label", "ExtendedItemActions[i].ButtonLabel"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Extented Item Action[i] Button Toolip", "ExtendedItemActions[i].ButtonTooltip"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Extented Item Action[i] Confirmation", "ExtendedItemActions[i].Confirmation"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Create Dialog - Title", "CreateFormDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Create Dialog - Dismiss", "CreateFormDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Error Dialog - Body", "ErrorDialog.Body"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Error Dialog - Title", "ErrorDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Error Dialog - Primary Button Text", "ErrorDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Error Dialog - Close Button Text", "ErrorDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Error Dialog - Dismiss Button Text", "ErrorDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Details Dialog - Loading Message", "DetailsFormDialog.LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Details Dialog - Title", "DetailsFormDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Details Dialog - Dismiss Button Text", "DetailsFormDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Edit Dialog - Loading Message", "EditFormDialog.LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Edit Dialog - Title", "EditFormDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Edit Dialog - Dismiss Button Text", "EditFormDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Delete Dialog - Primary Button Text", "DeleteDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Delete Dialog - Title", "DeleteDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Delete Dialog - Close Button Text", "DeleteDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Workflow Dialog - Title", "WorkflowDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Workflow Dialog - Dismiss Button Text", "WorkflowDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Workflow Dialog - Primary Button Text", "WorkflowDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Workflow Dialog - Close Button Text", "WorkflowDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Create Related Record Dialog - Loading Message", "CreateRelatedRecordDialog.LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Create Related Record Dialog - Title", "CreateRelatedRecordDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Create Related Record Dialog - Dismiss Button Text", "CreateRelatedRecordDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Activate Dialog - Title", "ActivateDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Activate Dialog - Dismiss Button Text", "ActivateDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Activate Dialog - Primary Button Text", "ActivateDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Activate Dialog - Close Button Text", "ActivateDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Deactivate Dialog - Title", "DeactivateDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Deactivate Dialog - Dismiss Button Text", "DeactivateDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Deactivate Dialog - Primary Button Text", "DeactivateDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Deactivate Dialog - Close Button Text", "DeactivateDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) ", "PATH"));

            return attributes;
        }

        public static List<AttributeHelperModel> GetAttributeListEntityForm()
        {
            List<AttributeHelperModel> attributes = new List<AttributeHelperModel>();
            attributes.Add(new AttributeHelperModel("adx_name", "Name", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_attachfilelabel", "Attach File Label", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_attachfilerequirederrormessage", "Attach File Required Error Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_attachfilesizeerrormessage", "Attach File Size Error Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_attachfiletypeerrormessage", "Attach File Type Error Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_validationsummaryheadertext", "Validation Summary Header Text", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_instructions", "Instructions", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_recordnotfoundmessage", "Record Not Found Message", string.Empty));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Success Message", "Actions[i].SuccessMessage"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Button Label", "Actions[i].ButtonLabel"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Button Busy Text", "Actions[i].ButtonBusyLabel"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Button Tooltip", "Actions[i].ButtonTooltip"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Confirmation", "Actions[i].Confirmation"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Workflow Dialog Title", "Actions[i].WorkflowDialogTitle"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Workflow Dialog Primary Button Text", "Actions[i].WorkflowDialogPrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Workflow Dialog Cancel Button Text", "Actions[i].WorkflowDialogCloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action Menu Label ", "ActionDropDownButtonLabel"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Save Changes Warning Message", "SaveChangesWarningMessage"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Activate Dialog - Title", "ActivateDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Activate Dialog - Close Button Text", "ActivateDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Activate Dialog - Dismiss Button Text", "ActivateDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Activate Dialog - Primary Button Text", "ActivateDialog.PrimaryButtonText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Delete Dialog - Title", "DeleteDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Delete Dialog - Close Button Text", "DeleteDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Delete Dialog - Dismiss Button Text", "DeleteDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Delete Dialog - Primary Button Text", "DeleteDialog.PrimaryButtonText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Workflow Dialog - Title", "WorkflowDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Workflow Dialog - Close Button Text", "WorkflowDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Workflow Dialog - Dismiss Button Text", "WorkflowDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Workflow Dialog - Primary Button Text", "WorkflowDialog.PrimaryButtonText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Deactivate Dialog - Title", "DeactivateDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Deactivate Dialog - Close Button Text", "DeactivateDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Deactivate Dialog - Dismiss Button Text", "DeactivateDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Deactivate Dialog - Primary Button Text", "DeactivateDialog.PrimaryButtonText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Create Related Record Dialog - Title", "CreateRelatedRecordDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Create Related Record Dialog - Close Button Text", "CreateRelatedRecordDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Create Related Record Dialog - Dismiss Button Text", "CreateRelatedRecordDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Create Related Record Dialog - Primary Button Text", "CreateRelatedRecordDialog.PrimaryButtonText"));

            //attributes.Add(new AttributeHelperModel("adx_settings", "(Settings) ", "PATH"));

            return attributes;
        }

        public static List<AttributeHelperModel> GetAttributeListEntityFormMetadata()
        {
            List<AttributeHelperModel> attributes = new List<AttributeHelperModel>();

            attributes.Add(new AttributeHelperModel("adx_entityform", "Entity Form", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_type", "Type", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_attributelogicalname", "Attribute Logical Name", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_subgrid_name", "Subgrid Name", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_tabname", "Tab Name", string.Empty));

            attributes.Add(new AttributeHelperModel("adx_description", "Description", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_label", "Label", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_requiredfieldvalidationerrormessage", "Required Field Validation Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_validationerrormessage", "Validation Error Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_validationregularexpressionerrormessage", "Regular Expression Validation Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_rangevalidationerrormessage", "Range Validation Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_geolocationvalidatorerrormessage", "Geolocation Validator Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_constantsumvalidationerrormessage", "Constant Sum Validation Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_multiplechoicevalidationerrormessage", "Multiple Choice Validation Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_rankordernotiesvalidationerrormessage", "Rank Order No Ties Validation Message", string.Empty));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Success Message", "ViewActions[i].SuccessMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Button Label", "ViewActions[i].ButtonLabel"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Button Toolip", "ViewActions[i].ButtonTooltip"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Confirmation", "ViewActions[i].Confirmation"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Success Message", "ItemActions[i].SuccessMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Button Label", "ItemActions[i].ButtonLabel"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Button Toolip", "ItemActions[i].ButtonTooltip"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Confirmation", "ItemActions[i].Confirmation"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Title", "ItemActions[i].WorkflowDialogTitle"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Primary Button Text", "ItemActions[i].WorkflowDialogPrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Close Button Text", "ItemActions[i].WorkflowDialogCloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Success Message", "ExtendedItemActions[i].SuccessMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Button Label", "ExtendedItemActions[i].ButtonLabel"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Button Toolip", "ExtendedItemActions[i].ButtonTooltip"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Confirmation", "ExtendedItemActions[i].Confirmation"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "Loading Message", "LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "Error Message", "ErrorMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "Access Denied Message", "AccessDeniedMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "Empty Message", "EmptyMessage"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Create Dialog - Loading Message", "CreateFormDialog.LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Create Dialog - Title", "CreateFormDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Create Dialog - Dismiss", "CreateFormDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Error Dialog - Body", "ErrorDialog.Body"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Error Dialog - Title", "ErrorDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Error Dialog - Primary Button Text", "ErrorDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Error Dialog - Close Button Text", "ErrorDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Error Dialog - Dismiss Button Text", "ErrorDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Loading Message", "LookupDialog.LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Select Records Title", "LookupDialog.SelectRecordsTitle"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Default Error Message", "LookupDialog.DefaultErrorMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Loading Message", "LookupDialog.GridSettings.LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Error Message", "LookupDialog.GridSettings.ErrorMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Access Denied Message", "LookupDialog.GridSettings.AccessDeniedMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Empty Message", "LookupDialog.GridSettings.EmptyMessage"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Title", "LookupDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Primary Button Text", "LookupDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Close Button Text", "LookupDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Dismiss Button Text", "LookupDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Details Dialog - Loading Message", "DetailsFormDialog.LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Details Dialog - Title", "DetailsFormDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Details Dialog - Dismiss Button Text", "DetailsFormDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Edit Dialog - Loading Message", "EditFormDialog.LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Edit Dialog - Title", "EditFormDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Edit Dialog - Dismiss Button Text", "EditFormDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Delete Dialog - Primary Button Text", "DeleteDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Delete Dialog - Title", "DeleteDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Delete Dialog - Close Button Text", "DeleteDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Delete Dialog - Dismiss Button Text", "DeleteDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Workflow Dialog - Title", "WorkflowDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Workflow Dialog - Dismiss Button Text", "WorkflowDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Workflow Dialog - Primary Button Text", "WorkflowDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Workflow Dialog - Close Button Text", "WorkflowDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Create Related Record Dialog - Loading Message", "CreateRelatedRecordDialog.LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Create Related Record Dialog - Title", "CreateRelatedRecordDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Create Related Record Dialog - Dismiss Button Text", "CreateRelatedRecordDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Disassociate Dialog - Title", "DisassociateDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Disassociate Dialog - Dismiss Button Text", "DisassociateDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Disassociate Dialog - Primary Button Text", "DisassociateDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Disassociate Dialog - Close Button Text", "DisassociateDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Activate Dialog - Title", "ActivateDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Activate Dialog - Dismiss Button Text", "ActivateDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Activate Dialog - Primary Button Text", "ActivateDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Activate Dialog - Close Button Text", "ActivateDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Deactivate Dialog - Title", "DeactivateDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Deactivate Dialog - Dismiss Button Text", "DeactivateDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Deactivate Dialog - Primary Button Text", "DeactivateDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Deactivate Dialog - Close Button Text", "DeactivateDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Add Note Button Label", "AddNoteButtonLabel"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Loading Message", "LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Error Message", "ErrorMessage"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Access Denied Message", "AccessDeniedMessage"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "List Title", "ListTitle"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Note Privacy Label", "NotePrivacyLabel"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Empty Message", "EmptyMessage"));

            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Create Dialog - Note Field Label", "CreateDialog.NoteFieldLabel"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Create Dialog - Privacy Option Field Label", "CreateDialog.PrivacyOptionFieldLabel"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Create Dialog - Attach File Label", "CreateDialog.AttachFileLabel"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Create Dialog - Title", "CreateDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Create Dialog - Primary Button Text", "CreateDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Create Dialog - Dismiss Button Text", "CreateDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Create Dialog - Close Button Text", "CreateDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Edit Dialog - Note Field Label", "EditDialog.NoteFieldLabel"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Edit Dialog - Privacy Option Field Label", "EditDialog.PrivacyOptionFieldLabel"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Edit Dialog - Attach File Label", "EditDialog.AttachFileLabel"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Edit Dialog - Title", "EditDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Edit Dialog - Primary Button Text", "EditDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Edit Dialog - Dismiss Button Text", "EditDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Edit Dialog - Close Button Text", "EditDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Delete Dialog - Confirmation", "DeleteDialog.Confirmation"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Delete Dialog - Title", "DeleteDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Delete Dialog - Primary Button Text", "DeleteDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Delete Dialog - Dismiss Button Text", "DeleteDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Delete Dialog - Close Button Text", "DeleteDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Restrict MIME Types Error Message", "AttachFileRestrictErrorMessage"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Maximum File Size Error Message", "AttachFileMaximumSizeErrorMessage"));

            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Add Note Button Label", "AddNoteButtonLabel"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Create Dialog - Note Field Label", "CreateDialog.NoteFieldLabel"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Create Dialog - Attach File Label", "CreateDialog.AttachFileLabel"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Create Dialog - Close Button Text", "CreateDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Create Dialog - Title", "CreateDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Create Dialog - Primary Button Text", "CreateDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Create Dialog - Dismiss Button Text", "CreateDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Loading Message", "LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Error Message", "ErrorMessage"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Access Denied Message", "AccessDeniedMessage"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Empty Message", "EmptyMessage"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "List Title", "ListTitle"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Restrict MIME Types Error Message", "AttachFileRestrictErrorMessage"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Maximum File Size Error Message", "AttachFileMaximumSizeErrorMessage"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Load More Button Label", "LoadMoreButtonLabel"));

            return attributes;
        }

        public static List<AttributeHelperModel> GetAttributeListWebForm()
        {
            List<AttributeHelperModel> attributes = new List<AttributeHelperModel>();
            attributes.Add(new AttributeHelperModel("adx_name", "Name", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_editexpiredmessage", "Edit Expired Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_editnotpermittedmessage", "Edit Not Permitted Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_savechangeswarningmessage", "Save Changes Warning Message", string.Empty));

            return attributes;
        }

        public static List<AttributeHelperModel> GetAttributeListWebFormStep()
        {
            List<AttributeHelperModel> attributes = new List<AttributeHelperModel>();
            attributes.Add(new AttributeHelperModel("adx_name", "Name", string.Empty));

            attributes.Add(new AttributeHelperModel("adx_validationsummaryheadertext", "Validation Summary Header Text", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_instructions", "Instructions", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_recordnotfoundmessage", "Record Not Found Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_successmessage", "Success Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_title", "Progress Indicator Title", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_previousbuttontext", "Previous Button Text", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_nextbuttontext", "Next Button Text", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_submitbuttontext", "Submit Button Text", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_submitbuttonbusytext", "Button Busy Text", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_attachfilelabel", "Attach File Label", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_attachfilerequirederrormessage", "Attach File Required Error Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_attachfilesizeerrormessage", "Attach File Size Error Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_attachfiletypeerrormessage", "Attach File Type Error Message", string.Empty));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Success Message", "Actions[i].SuccessMessage"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Button Label", "Actions[i].ButtonLabel"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Button Busy Text", "Actions[i].ButtonBusyLabel"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Button Tooltip", "Actions[i].ButtonTooltip"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Confirmation", "Actions[i].Confirmation"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Workflow Dialog Title", "Actions[i].WorkflowDialogTitle"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Workflow Dialog Primary Button Text", "Actions[i].WorkflowDialogPrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action[i] Workflow Dialog Cancel Button Text", "Actions[i].WorkflowDialogCloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Action Menu Label ", "ActionDropDownButtonLabel"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Activate Dialog - Title", "ActivateDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Activate Dialog - Close Button Text", "ActivateDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Activate Dialog - Dismiss Button Text", "ActivateDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Activate Dialog - Primary Button Text", "ActivateDialog.PrimaryButtonText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Delete Dialog - Title", "DeleteDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Delete Dialog - Close Button Text", "DeleteDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Delete Dialog - Dismiss Button Text", "DeleteDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Delete Dialog - Primary Button Text", "DeleteDialog.PrimaryButtonText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Workflow Dialog - Title", "WorkflowDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Workflow Dialog - Close Button Text", "WorkflowDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Workflow Dialog - Dismiss Button Text", "WorkflowDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Workflow Dialog - Primary Button Text", "WorkflowDialog.PrimaryButtonText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Deactivate Dialog - Title", "DeactivateDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Deactivate Dialog - Close Button Text", "DeactivateDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Deactivate Dialog - Dismiss Button Text", "DeactivateDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Deactivate Dialog - Primary Button Text", "DeactivateDialog.PrimaryButtonText"));

            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Create Related Record Dialog - Title", "CreateRelatedRecordDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Create Related Record Dialog - Close Button Text", "CreateRelatedRecordDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Create Related Record Dialog - Dismiss Button Text", "CreateRelatedRecordDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_settings", "(Config) Create Related Record Dialog - Primary Button Text", "CreateRelatedRecordDialog.PrimaryButtonText"));

            return attributes;
        }

        public static List<AttributeHelperModel> GetAttributeListWebFormMetadata()
        {
            List<AttributeHelperModel> attributes = new List<AttributeHelperModel>();
            attributes.Add(new AttributeHelperModel("adx_type", "Type", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_attributelogicalname", "Attribute Logical Name", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_subgrid_name", "Subgrid Name", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_tabname", "Tab Name", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_webformstep", "Web Form Step", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_sectionname", "Section Name", string.Empty)); 

            attributes.Add(new AttributeHelperModel("adx_description", "Description", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_label", "Label", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_requiredfieldvalidationerrormessage", "Required Field Validation Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_validationerrormessage", "Validation Error Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_validationregularexpressionerrormessage", "Regular Expression Validation Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_rangevalidationerrormessage", "Range Validation Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_geolocationvalidatorerrormessage", "Geolocation Validator Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_constantsumvalidationerrormessage", "Constant Sum Validation Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_multiplechoicevalidationerrormessage", "Multiple Choice Validation Message", string.Empty));
            attributes.Add(new AttributeHelperModel("adx_rankordernotiesvalidationerrormessage", "Rank Order No Ties Validation Message", string.Empty));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Success Message", "ViewActions[i].SuccessMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Button Label", "ViewActions[i].ButtonLabel"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Button Toolip", "ViewActions[i].ButtonTooltip"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Confirmation", "ViewActions[i].Confirmation"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Success Message", "ItemActions[i].SuccessMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Button Label", "ItemActions[i].ButtonLabel"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Button Toolip", "ItemActions[i].ButtonTooltip"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Confirmation", "ItemActions[i].Confirmation"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Title", "ItemActions[i].WorkflowDialogTitle"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Primary Button Text", "ItemActions[i].WorkflowDialogPrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Close Button Text", "ItemActions[i].WorkflowDialogCloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Success Message", "ExtendedItemActions[i].SuccessMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Button Label", "ExtendedItemActions[i].ButtonLabel"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Button Toolip", "ExtendedItemActions[i].ButtonTooltip"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Item Action[i] Confirmation", "ExtendedItemActions[i].Confirmation"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "Loading Message", "LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "Error Message", "ErrorMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "Access Denied Message", "AccessDeniedMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "Empty Message", "EmptyMessage"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Create Dialog - Loading Message", "CreateFormDialog.LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Create Dialog - Title", "CreateFormDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Create Dialog - Dismiss", "CreateFormDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Error Dialog - Body", "ErrorDialog.Body"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Error Dialog - Title", "ErrorDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Error Dialog - Primary Button Text", "ErrorDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Error Dialog - Close Button Text", "ErrorDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Error Dialog - Dismiss Button Text", "ErrorDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Loading Message", "LookupDialog.LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Select Records Title", "LookupDialog.SelectRecordsTitle"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Default Error Message", "LookupDialog.DefaultErrorMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Loading Message", "LookupDialog.GridSettings.LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Error Message", "LookupDialog.GridSettings.ErrorMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Access Denied Message", "LookupDialog.GridSettings.AccessDeniedMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Empty Message", "LookupDialog.GridSettings.EmptyMessage"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Title", "LookupDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Primary Button Text", "LookupDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Close Button Text", "LookupDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Lookup Dialog - Dismiss Button Text", "LookupDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Details Dialog - Loading Message", "DetailsFormDialog.LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Details Dialog - Title", "DetailsFormDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Details Dialog - Dismiss Button Text", "DetailsFormDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Edit Dialog - Loading Message", "EditFormDialog.LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Edit Dialog - Title", "EditFormDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Edit Dialog - Dismiss Button Text", "EditFormDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Delete Dialog - Primary Button Text", "DeleteDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Delete Dialog - Title", "DeleteDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Delete Dialog - Close Button Text", "DeleteDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Delete Dialog - Dismiss Button Text", "DeleteDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Workflow Dialog - Title", "WorkflowDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Workflow Dialog - Dismiss Button Text", "WorkflowDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Workflow Dialog - Primary Button Text", "WorkflowDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Workflow Dialog - Close Button Text", "WorkflowDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Create Related Record Dialog - Loading Message", "CreateRelatedRecordDialog.LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Create Related Record Dialog - Title", "CreateRelatedRecordDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Create Related Record Dialog - Dismiss Button Text", "CreateRelatedRecordDialog.DismissButtonSrText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Disassociate Dialog - Title", "DisassociateDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Disassociate Dialog - Dismiss Button Text", "DisassociateDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Disassociate Dialog - Primary Button Text", "DisassociateDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Disassociate Dialog - Close Button Text", "DisassociateDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Activate Dialog - Title", "ActivateDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Activate Dialog - Dismiss Button Text", "ActivateDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Activate Dialog - Primary Button Text", "ActivateDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Activate Dialog - Close Button Text", "ActivateDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Deactivate Dialog - Title", "DeactivateDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Deactivate Dialog - Dismiss Button Text", "DeactivateDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Deactivate Dialog - Primary Button Text", "DeactivateDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_subgrid_settings", "(Config) Deactivate Dialog - Close Button Text", "DeactivateDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Add Note Button Label", "AddNoteButtonLabel"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Loading Message", "LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Error Message", "ErrorMessage"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Access Denied Message", "AccessDeniedMessage"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "List Title", "ListTitle"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Note Privacy Label", "NotePrivacyLabel"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Empty Message", "EmptyMessage"));

            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Create Dialog - Note Field Label", "CreateDialog.NoteFieldLabel"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Create Dialog - Privacy Option Field Label", "CreateDialog.PrivacyOptionFieldLabel"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Create Dialog - Attach File Label", "CreateDialog.AttachFileLabel"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Create Dialog - Title", "CreateDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Create Dialog - Primary Button Text", "CreateDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Create Dialog - Dismiss Button Text", "CreateDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Create Dialog - Close Button Text", "CreateDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Edit Dialog - Note Field Label", "EditDialog.NoteFieldLabel"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Edit Dialog - Privacy Option Field Label", "EditDialog.PrivacyOptionFieldLabel"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Edit Dialog - Attach File Label", "EditDialog.AttachFileLabel"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Edit Dialog - Title", "EditDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Edit Dialog - Primary Button Text", "EditDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Edit Dialog - Dismiss Button Text", "EditDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Edit Dialog - Close Button Text", "EditDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Delete Dialog - Confirmation", "DeleteDialog.Confirmation"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Delete Dialog - Title", "DeleteDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Delete Dialog - Primary Button Text", "DeleteDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Delete Dialog - Dismiss Button Text", "DeleteDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Delete Dialog - Close Button Text", "DeleteDialog.CloseButtonText"));

            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Restrict MIME Types Error Message", "AttachFileRestrictErrorMessage"));
            attributes.Add(new AttributeHelperModel("adx_notes_settings", "Maximum File Size Error Message", "AttachFileMaximumSizeErrorMessage"));

            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Add Note Button Label", "AddNoteButtonLabel"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Create Dialog - Note Field Label", "CreateDialog.NoteFieldLabel"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Create Dialog - Attach File Label", "CreateDialog.AttachFileLabel"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Create Dialog - Close Button Text", "CreateDialog.CloseButtonText"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Create Dialog - Title", "CreateDialog.Title"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Create Dialog - Primary Button Text", "CreateDialog.PrimaryButtonText"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Create Dialog - Dismiss Button Text", "CreateDialog.DismissButtonSrText"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Loading Message", "LoadingMessage"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Error Message", "ErrorMessage"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Access Denied Message", "AccessDeniedMessage"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Empty Message", "EmptyMessage"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "List Title", "ListTitle"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Restrict MIME Types Error Message", "AttachFileRestrictErrorMessage"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Maximum File Size Error Message", "AttachFileMaximumSizeErrorMessage"));
            attributes.Add(new AttributeHelperModel("adx_timeline_settings", "Load More Button Label", "LoadMoreButtonLabel"));

            return attributes;
        }
    }
}
