using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Messages;

namespace Portals.MetadataTranslator.Controls
{
    public partial class EntityPickerControl : UserControl
    {
        public readonly List<ListViewItem> _items = new List<ListViewItem>();
        public IOrganizationService _orgService { get; set; }

        public List<EntityMetadata> _entityMetadata { get; private set; }
        public List<EntityMetadata> _selecetedEntityMetadata { get; set; }

        public EntityPickerControl() { InitializeComponent(); }

        public EntityPickerControl(IOrganizationService service) : this()
        {
            _orgService = service;
            InitializeComponent();
        }

        public void LoadEntities()
        {

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
                        //"ManyToManyRelationships",
                        //"ManyToOneRelationships",
                        //"IsIntersect",
                        //"PrimaryNameAttribute",
                        "Attributes",
                        "ObjectTypeCode"
                    }
                },
                AttributeQuery = new AttributeQueryExpression
                {
                    Properties = new MetadataPropertiesExpression
                    {
                        AllProperties = false,
                        PropertyNames = { "IsValidForCreate", "IsValidForUpdate", "LogicalName", "Targets", "OptionSet", "DisplayName" }
                    }
                }
            };

            // TODO :: remove this if not used
            //if (logicalNames != null)
            //{
            //    entityQueryExpressionFull.Criteria = new MetadataFilterExpression
            //    {
            //        Conditions =
            //        {
            //            new MetadataConditionExpression("LogicalName", MetadataConditionOperator.In, logicalNames.ToArray())
            //        }
            //    };
            //}

            RetrieveMetadataChangesRequest request = new RetrieveMetadataChangesRequest
            {
                Query = adxEntitiesQueryExpression,
                ClientVersionStamp = null
            };

            var fullResponse = (RetrieveMetadataChangesResponse)_orgService.Execute(request);

            _entityMetadata = fullResponse.EntityMetadata.Where(e => e.LogicalName.StartsWith("adx_")).ToList();

            _items.Clear();

            // TODO :: restrict to only certain pages, this might not be needed
            foreach (var metadata in _entityMetadata.Where(m => m.IsIntersect == null || m.IsIntersect.Value == false))
            {
                _items.Add(new ListViewItem(metadata.DisplayName?.UserLocalizedLabel?.Label ?? metadata.SchemaName)
                {
                    Tag = metadata,
                    Checked = false//settings.SelectedEntities.Contains(metadata.LogicalName)
                });
            }
        }

        public void PopulateList()
        {
            lvEntities.Items.Clear();
            lvEntities.Items.AddRange(_items.ToArray());
        }
    }
}
