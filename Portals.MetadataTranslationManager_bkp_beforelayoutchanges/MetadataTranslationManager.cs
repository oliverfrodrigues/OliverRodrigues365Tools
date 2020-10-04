using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Portals.MetadataTranslationManager
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Portal Metadata Translation Manager"),
        ExportMetadata("Description", "This plugin helps you to manage Power Apps Portals Metadata Translations"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAABoAAAAaCAYAAACpSkzOAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAEnQAABJ0Ad5mH3gAAAPgSURBVEhL3VY7ixRZGD33VnVXd89DR1cU34IPUFRQwUwjI0UDFUQRRBEEA5lfoIGpiZgoqIli5CNREDERTUwUBfGFOiMiMopiM9Nd0/XYc76eZn11De6yG+yBorpu3Xu/+53vfKfaDS9dmuM/gJ+4/+v4nwbK8xx5o4F8dBR5s9l+TpL289gY8iyzyYJ+2xjntwc4V2s0V7/juP2e92/hhpYsyTE+jmjfPhvIP39GfOkSgmXLUNqyBa7VQpPPmiO4KVNQ3rzZAsUXLthYZfduoKcH8cWLCNevh1+0CNnbt0ju3IErl22OG5o9O68ePYqxY8cAZqEA4YoVyL5+Rfb8OZInT1A7cQLN48dtM+cc0vfvETFYys00P3n0CCnn+v5+RLt2oXHyJPyMGXCc34GH98iGh+GCAH5gAOmzZ3ALFhgVbv58O2H28iXA9wqiTKIdO2w8efAAfuFClNatQ3Vw0ChTxpUjR+BmzUKephNhFIiLoQHdO1BNOBbMm4fKnj1onjsHV6m035VKSB4/RvL0KQJm7ufMMarHb9xAeedONE6dMkqNTtWJdRO86PKLF9tpMtYnWLUK2atXRkNy/z4aDBJt346ctRIkBjGQ3LuHcPlypC9e2CFVCxOADikx8BJbHbTFwAmVw4fbyvnwAfGVKwgZMP/yBdm7dyht3YrWzZu2MFi92mooVcbnz8P19qJy8CCyT58Qnz2L6MABuFoNrbt3kb1+DUcGLJAsSLJER66qRRTZRtrY8dJJNSbkUt8E1aLTpE9523O1alK3rJihC0NbI/yW12X1Ovy0aUhHRhCw6N/VdRIUO4MakKezujBIHymK1q7FANshE83MzDKaKHgRugdSEF7i2Pf1WSairEkR1E+fRu/evUadiUCBJgnWnTouTCmGP86cQZ1Ftg3VWyy+amAWxHr279+PkUOH4KdOJZPdqQwGp0+nJfwMiaG8Zg3CmTMBSlsblak4xyBq7PLKlbaxZB9wTkKZf1v8H9E1IymtumkTxm7dMmtShjV63+jVq0ZnjZIfvXzZxnvYnI1r1/5q6l+gWAzcUJTpyihbnVzmWmKjJm/eWEDJ3hdk0kGhGKwuVFuJNPXSLGM6hURQojuHc+eitm2b2Uyu2kwihsKMZLRaXt24ES0aayj7V0Myg/jhQ4Q0VJmoBZHMC9A9kBbqpLzG5dLkX41qGVAA9oFjULMYieKfZCRKso8f4WiwAT8ZLX5CGrdvo3H9OiobNiClDyZDQ3AMYo1bgO6qY5+oBp7UZOoZ1Ux+pyz1nhkJnaats9+8eqwLCr3O/gtMctIOPB27CL9lqn8fwJ8YxPy6bEwdwQAAAABJRU5ErkJggg=="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MetadataTranslationManager : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MetadataTranslatorControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public MetadataTranslationManager()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}