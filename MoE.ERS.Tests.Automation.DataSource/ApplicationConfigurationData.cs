using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MoE.ERS.Tests.Automation.Entities;
using System.IO;

namespace MoE.ERS.Tests.Automation.DataSource
{
    public class ApplicationConfigurationData
    {
        public static ApplicationConfiguration GetConfiguredData()
        {
            ApplicationConfiguration appConfiguration = new ApplicationConfiguration();           
            string configurationFile = File.ReadAllText(Directory.GetCurrentDirectory()
                                                         .Substring(0, Directory.GetCurrentDirectory().IndexOf("MoE.ERS.Tests.Automation"))
                                                         + "MoE.ERS.Tests.Automation\\MoE.ERS.Tests.Automation.TestRunner\\"
                                                         + "Configuration.xml");            
            XmlDocument configDoc = new XmlDocument();
            configDoc.LoadXml(configurationFile);
            XmlNode testContainerNode = configDoc.GetElementsByTagName("TestContainer")[0];
            XmlNode exeContainerNode = configDoc.GetElementsByTagName("ExecutableContainer")[0];
            XmlNode providerNameNode = configDoc.GetElementsByTagName("ProviderName")[0];
            appConfiguration.TestDataContainer = testContainerNode.InnerText;
            appConfiguration.ExecutableContainer = exeContainerNode.InnerText;
            appConfiguration.ProviderName = providerNameNode.InnerText;

            return appConfiguration;
        }
    }
}
