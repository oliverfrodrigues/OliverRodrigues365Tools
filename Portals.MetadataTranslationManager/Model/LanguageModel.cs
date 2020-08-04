using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals.MetadataTranslationManager.Model
{
    public class LanguageModel
    {
        public int LCID { get; set; }
        public string LanguageName { get; set; }
        public EntityReference WebsiteLanguage { get; set; }
    }
}
