using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoE.ERS.Tests.Automation.Entities;
using MoE.ERS.Tests.Automation.DataSource;
using Dapper;
using excel = Microsoft.Office.Interop.Excel;
using System.Configuration;
using System.IO;
using System.Diagnostics;

namespace MoE.ERS.Tests.Automation.TestRunner
{
    public class TestRunner
    {
        private static StringBuilder executableCMD = new StringBuilder();   
        static void Main(string[] args)
        {
            ApplicationConfiguration appConfiguration = ApplicationConfigurationData.GetConfiguredData();
            Console.WriteLine("Starting TestExecution...");
            Console.WriteLine("Generating TestExecutables...");
            GenerateTestExecutor(appConfiguration.TestDataContainer,appConfiguration.ExecutableContainer);
            if (File.Exists(ConfigurationManager.AppSettings["ExecutableContainer"].ToString()))
            {
                Console.WriteLine("Tirggering TestExecutor...");
                TriggerTestExecutor(appConfiguration.ExecutableContainer);
            }           
        }    

        private static void ExecutorBuilder(List<EntityBase> lstTestData)
        {
            foreach (EntityBase entityBase in lstTestData)
                executableCMD.Append("MoE.ERS.Tests.Automation.TestScripts." + entityBase.TestContainerName + "."+ entityBase.TestName + ",");
        }
        private static void GenerateTestExecutor(string testDataContainer,string exeContainer)
        {
            string rootDrive = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory()).Substring(0, Directory.GetDirectoryRoot(Directory.GetCurrentDirectory()).Length - 1);
            StreamWriter streamWriter = new StreamWriter(exeContainer, false);
            List<EntityBase> lstTestData;
            excel.Application xlAppTestData = new excel.Application();
            excel.Workbook xlWBTestData = xlAppTestData.Workbooks.Open(testDataContainer);
            string executablePath = exeContainer.Substring(0, exeContainer.ToString().LastIndexOf(@"\"));

            streamWriter.WriteLine(rootDrive);
            streamWriter.WriteLine("CD " + executablePath);
            foreach (excel._Worksheet worksheet in xlWBTestData.Sheets)
            {
                if (worksheet.Name.ToUpper().Equals("LOGINCONFIGURATION")
                    || worksheet.Name.ToUpper().Equals("REPORTCONFIGURATION"))
                    continue;
                lstTestData = RealTestData<EntityBase>.GetTestData(worksheet.Name, "TestContainerName,TestName", "CanExecute= 'Y' or CanExecute='y'");
                if (lstTestData.Count == 0)
                    continue;                
                ExecutorBuilder(lstTestData);
            }
            streamWriter.WriteLine("nunit3-console --test=" + executableCMD.ToString().Remove(executableCMD.ToString().Length - 1, 1)
                                       + " " + System.Reflection.Assembly.GetExecutingAssembly().Location
                                       .Substring(0, System.Reflection.Assembly.GetExecutingAssembly()
                                       .Location.LastIndexOf("MoE.ERS.Tests.Automation.TestRunner"))
                                       + @"\MoE.ERS.Tests.Automation\bin\Debug\MoE.ERS.Tests.Automation.dll");
            streamWriter.Flush();
            streamWriter.Close();
            xlWBTestData.Close();
            xlAppTestData.Quit();
        }
        private static void TriggerTestExecutor(string exeContainer)
        {
            string workingDirectory = exeContainer.Substring(0, exeContainer.ToString().LastIndexOf(@"\"));
            int delimitPosition = exeContainer.LastIndexOf("\\")+1;
            string fileName = exeContainer.Substring(delimitPosition,exeContainer.Length - delimitPosition);
            Process process = new Process();
            process.StartInfo.WorkingDirectory= 
            process.StartInfo.FileName = exeContainer;
            process.StartInfo.CreateNoWindow = false;
            process.Start();
            process.WaitForExit();
            Console.WriteLine("Executables Completed Successfully.");
        }
    }
}
