using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals.MetadataTranslationManager
{
    public static class JsonHelper
    {
        private static readonly string typeLanguageResource = "Adxstudio.Xrm.Web.UI.WebForms.LanguageResources, Adxstudio.Xrm";
        private static readonly string typeOverrideColumn= "Adxstudio.Xrm.Web.UI.CrmEntityListView.ViewColumn, Adxstudio.Xrm";
        /// <summary>
        /// Parse complex settings JSON for translation
        /// </summary>
        /// <param name="CRMDataList"></param>
        /// <returns></returns>
        public static List<CRMDataObject> ParseComplexJson(List<CRMDataObject> CRMDataList)
        {
            List<CRMDataObject> newCRMDataList = new List<CRMDataObject>();
            foreach (var CRMObject in CRMDataList)
            {
                List<ComplexJson> dataListJson = ParseComplexJsonToObjects(CRMObject.Value);
                //gets only the english
                foreach (var jsonData in dataListJson.Where(c => c.LCID == 1033))
                {
                    CRMDataObject temObj = new CRMDataObject(
                            CRMObject.EntityName,
                            CRMObject.GUID, jsonData.Value, "",
                            CRMObject.FieldName);
                    //replaces the path to irish
                    jsonData.Path = ReplaceLastOccurrence(jsonData.Path, "0", "1");
                    temObj.ValueIE = GetJsonObjectValue(jsonData.Path, CRMObject);
                    temObj.Path = jsonData.Path;
                    temObj.ComplexJson = CRMObject.Value;
                    newCRMDataList.Add(temObj);
                }

                //irish with no english value
                foreach (var jsonData in dataListJson.Where(c => c.LCID == 1046))
                {
                    CRMDataObject temObj = new CRMDataObject(
                            CRMObject.EntityName,
                            CRMObject.GUID,
                            string.Empty,
                            jsonData.Value,
                            CRMObject.FieldName);
                    //skip english value check for column overrides
                    if (jsonData.Path.StartsWith("ColumnOverrides"))
                    {
                        temObj.Path = jsonData.Path;
                        temObj.ComplexJson = CRMObject.Value;
                        newCRMDataList.Add(temObj);
                        continue;
                    }
                    else
                    {
                        //check english value is emppty
                        string englishPath = ReplaceLastOccurrence(jsonData.Path, "1", "0");
                        string enValue = GetJsonObjectValue(englishPath, CRMObject);
                        if (string.IsNullOrEmpty(enValue))
                        {
                            temObj.Path = jsonData.Path;
                            temObj.ComplexJson = CRMObject.Value;
                            newCRMDataList.Add(temObj);
                        }
                    }
                   
                }
            }
            return newCRMDataList;
        }

        private static CRMDataObject ParseJsonValueToCRMObject(List<string> jsonValueList, CRMDataObject crmData)
        {
            //insert the json data into crmdataObjects so it can be exported to excel
            if (jsonValueList.Count <= 0)
                return null;

            CRMDataObject tempObj = new CRMDataObject();

            tempObj.EntityName = crmData.EntityName;
            tempObj.GUID = crmData.GUID;
            tempObj.Value = jsonValueList.First();
            tempObj.FieldName = crmData.FieldName;
            if (jsonValueList.Count > 1)
                tempObj.ValueIE = jsonValueList[1];

            return tempObj;
        }

        /// <summary>
        /// Parse compelx json to list of ComplexJson objects
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        private static List<ComplexJson> ParseComplexJsonToObjects(string jsonString)
        {
            List<ComplexJson> complexJsonItems = new List<ComplexJson>();
            JObject rootObj = JObject.Parse(jsonString);

            //get objects with $type language resource
            var jsonObjects = rootObj.DescendantsAndSelf()
                .OfType<JObject>()
                .Where(obj=>obj.ContainsKey("$type") &&
                            obj["$type"].Value<string>().Equals(typeLanguageResource) &&
                            !string.IsNullOrEmpty(obj["Value"].Value<string>()));

            foreach (var jsonObject in jsonObjects)
            {
                ComplexJson complexJsonItem= JsonConvert.DeserializeObject<ComplexJson>(jsonObject.ToString());
                complexJsonItem.Path = jsonObject.Path;
                complexJsonItems.Add(complexJsonItem);
            }

            //get objects with $type column label
            jsonObjects = rootObj.DescendantsAndSelf()
                .OfType<JObject>()
                .Where(obj => obj.ContainsKey("$type") &&
                            obj["$type"].Value<string>().Equals(typeOverrideColumn) &&
                            !string.IsNullOrEmpty(obj["DisplayName"].Value<string>())
                            && (obj["DisplayName"].Value<string>().Contains("[")||
                                obj["DisplayName"].Value<string>().Contains("]")));

            foreach (var jsonObject in jsonObjects)
            {
                ComplexJson complexJsonItem = new ComplexJson(1046, jsonObject["DisplayName"].Value<string>(), jsonObject.Path);
                complexJsonItems.Add(complexJsonItem);
            }

            return complexJsonItems;
        }



        private static string GetJsonObjectValue(string irishPath, CRMDataObject CRMObject)
        {
            JToken dataToken = JToken.Parse(CRMObject.Value);
            return dataToken.SelectToken(irishPath + ".Value").ToString();

        }

        private static string ReplaceLastOccurrence(string Source, string Find, string Replace)
        {
            int Place = Source.LastIndexOf(Find);
            string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return result;
        }
    }

    public class CrmJsonData
    {
        public int LCID { get; set; }
        public string Value { get; set; }


        public CrmJsonData(int lcid, string value)
        {
            this.LCID = lcid;
            this.Value = value;
        }
    }
}
