using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Portals.MetadataTranslationManager.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Portals.MetadataTranslationManager.Controls
{
    public partial class LanguagePickerControl : UserControl
    {
        public readonly List<ListViewItem> _items = new List<ListViewItem>();
        public IOrganizationService _orgService { get; set; }

        public List<LanguageModel> _languageData { get; private set; }
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

        public LanguagePickerControl() { InitializeComponent(); }

        public LanguagePickerControl(IOrganizationService service) : this()
        {
            _orgService = service;
            InitializeComponent();
        }

        public void LoadLanguages()
        {
            RetrieveAvailableLanguagesRequest request = new RetrieveAvailableLanguagesRequest();

            RetrieveAvailableLanguagesResponse fullResponse = (RetrieveAvailableLanguagesResponse)_orgService.Execute(request);

            List<int> LCIDs = fullResponse.LocaleIds.ToList();

            _items.Clear();

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

                _items.Add(listItem);
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

            EntityCollection ec = _orgService.RetrieveMultiple(qe);
            Guid websiteLanguageGuid = Guid.Empty;

            if (ec != null && ec.Entities.Count > 0)
                websiteLanguageGuid = ec.Entities.FirstOrDefault().Id;

            return new EntityReference("adx_websitelanguage", websiteLanguageGuid);
        }

        public void PopulateList()
        {
            lvLanguages.Items.Clear();
            lvLanguages.Items.AddRange(_items.ToArray());
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvLanguages.Items)
            {
                item.Checked = false;

            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvLanguages.Items)
            {
                if (new Guid(item.Tag.ToString()) != (Guid.Empty))
                    item.Checked = true;
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
    }
}
