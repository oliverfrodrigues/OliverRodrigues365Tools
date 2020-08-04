using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Portals.MetadataTranslationManager.Controls
{
    public partial class EntityPickerControl : UserControl
    {
        public readonly List<ListViewItem> _items = new List<ListViewItem>();
        public IOrganizationService _orgService { get; set; }

        public List<EntityMetadata> _entityMetadata { get; private set; }
        public List<EntityMetadata> _selectedEntityMetadata
        {
            get { return lvEntities.CheckedItems.Cast<ListViewItem>().Select(x => x.Tag as EntityMetadata).ToList(); }
        }

        public EntityPickerControl() { InitializeComponent(); }

        public EntityPickerControl(IOrganizationService service) : this()
        {
            _orgService = service;
            InitializeComponent();
        }

        public void LoadEntities()
        {
            string[] logicalNames = new string[] {
                "adx_contentsnippet",
                "adx_entityform",
                "adx_entityformmetadata",
                "adx_entitylist",
                "adx_webform",
                "adx_webformmetadata",
                "adx_webformstep",
                "adx_webpage",

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

            var fullResponse = (RetrieveMetadataChangesResponse)_orgService.Execute(request);

            _entityMetadata = fullResponse.EntityMetadata.ToList();

            _items.Clear();

            foreach (var metadata in _entityMetadata)
            {
                _items.Add(new ListViewItem(metadata.DisplayName?.UserLocalizedLabel?.Label ?? metadata.SchemaName)
                {
                    Tag = metadata,
                    Checked = true
                });
            }
        }

        public void PopulateList()
        {
            lvEntities.Items.Clear();
            lvEntities.Items.AddRange(_items.ToArray());
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvEntities.Items)
            {
                item.Checked = false;
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvEntities.Items)
            {
                item.Checked = true;
            }
        }
    }
}
