using Dapper;
using MoE.ERS.Tests.Automation.Entities;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;

namespace MoE.ERS.Tests.Automation.DataSource
{
    public class RealTestData<Entity> where Entity : EntityBase, new()
    {
        public string TestDataSheetPath { get; set; }
        private static string TestDataFileConnection()
        {
            //var fileName = Directory.GetCurrentDirectory() + "\\MoE.ERS.Tests.Automation.DataSource1\\TestData.xlsx";
            var fileName = @"D:\Ayyappan\Official\ERS\LocalRepository\MoE.ERS.Tests.Automation\MoE.ERS.Tests.Automation.DataSource\TestData.xlsx";
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }
        public static IList<Entity> GetTestData(string sheetName)
        {
            string query = string.Empty;
            IEnumerable<Entity> entityList = null;
            try
            {
                query = QueryBuilder(sheetName);
                entityList = GetQueryResult(query);
            }
            catch (Exception)
            { throw; }

            return entityList.ToList();
        }
        public static IList<Entity> GetTestData(string sheetName, string selectList)
        {
            string query = string.Empty;
            IEnumerable<Entity> entityList = null;
            try
            {
                query = QueryBuilder(sheetName, selectList);
                entityList = GetQueryResult(query);
            }
            catch (Exception)
            { throw; }

            return entityList.ToList();
        }
        public static List<Entity> GetTestData(string sheetName, string selectList, string whereExpression)
        {
            string query = string.Empty;
            IEnumerable<Entity> entityList = null;
            try
            {
                query = QueryBuilder(sheetName, selectList, whereExpression);
                entityList = GetQueryResult(query);
            }
            catch (Exception)
            {}

            return entityList.ToList();
        }        
        public static Entity GetLastData(string sheetName)
        {
            return GetTestData(sheetName)
                   .Skip(GetTestData(sheetName).ToList().Count - 1)
                   .Single();
        }
       
        private static IEnumerable<Entity> GetQueryResult(string query)
        {
            try
            {
                using (var connection = new OleDbConnection(TestDataFileConnection()))
                {
                    connection.Open();
                    var entityList = connection.Query<Entity>(query);
                    connection.Close();
                    return entityList;
                }
            }
            catch(Exception)
            { throw; }
        }
        private static string QueryBuilder(string sheetName, string selectList = null, string whereExpression = null)
        {
            StringBuilder excelQueryBuilder = new StringBuilder();
            try
            {
                excelQueryBuilder.Append("SELECT ");
                selectList = string.IsNullOrEmpty(selectList) ? " * " : selectList;
                excelQueryBuilder.Append(selectList);
                excelQueryBuilder.Append(" FROM [");
                excelQueryBuilder.Append(sheetName + "$]");
                if (!string.IsNullOrEmpty(whereExpression))
                {
                    excelQueryBuilder.Append(" WHERE ");
                    excelQueryBuilder.Append(whereExpression);
                }
            }
            catch (Exception)
            { throw; }
            return excelQueryBuilder.ToString();
        }
    }
}