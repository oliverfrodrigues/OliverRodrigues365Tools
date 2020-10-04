using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals.MetadataTranslationManager.Model
{
    public class CommonModel
    {
        public int LCID { get; set; }
        public string Value { get; set; }
        public string JsonPath { get; set; }
        public string SettingsJson { get; set; }

        public CommonModel(int lcid, string value, string path, string settingsJson)
        {
            LCID = lcid;
            Value = value;
            JsonPath = path;
            SettingsJson = settingsJson;
        }
    }
}
