using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals.MetadataTranslationManager.Model
{
    public class AttributeHelperModel
    {
        public string AttributeLogicalName { get; set; }
        public string AttributeDisplayName { get; set; }
        public string AttributeJsonPath { get; set; }

        public AttributeHelperModel(string logicalName, string displayName, string jsonPath)
        {
            AttributeLogicalName = logicalName;
            AttributeDisplayName = displayName;
            AttributeJsonPath = jsonPath;
        }
    }


}
