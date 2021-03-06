﻿using Dapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data.SqlClient;
using System.Linq;
using static Dapper.SqlMapper;
using System.Data;
using zzrdh.Dapper.Models;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace zzrdh.Dapper
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("ES201721.xml");
            Console.WriteLine(doc.Root.Element("PRO_LIST").Elements().Count());

            //File.WriteAllText(@"X:\ES201721.json", JsonConvert.SerializeXNode(doc.Root.Element("PRO_LIST")));

            dynamic pro_list = JObject.Parse(JsonConvert.SerializeXNode(doc.Root.Element("PRO_LIST")));
            var connection = GetOpenConnection();

            var count = connection.ExecuteScalar<int>("select count(1) from product");
            Console.WriteLine(count);

            var sql = @"INSERT INTO PRODUCT
SELECT *
FROM OPENJSON(@PRODUCT)
WITH(
  PUR_ITEM_CODE  VARCHAR(500),
  PUR_ITEM_NUM  VARCHAR(500),
  PUR_ITEM_NAME VARCHAR(500),
  PRODUCT_DIR_TYPE  VARCHAR(500),
  CERT_CODE VARCHAR(500),
  CERT_EXPIR VARCHAR(500),
  GOODS_SPEC VARCHAR(500),
  BRAND_ZH_NAME VARCHAR(500),
  MANUF_NAME VARCHAR(500)
)";
            if (count <= 0)
            {
                connection.Execute(sql, new { product = pro_list.PRO_LIST.PRO.ToString() });
            }

            //SqlMapper.AddTypeHandler(JObjectHandler.Instance);

            //Console.WriteLine("Hello World!");
            //var connection = GetOpenConnection();
            //var origReader = connection.Query<WfSchemeContent>("select top 1 * from WF_SchemeContent");
            //var list = origReader.ToList();

            //string json = JsonConvert.SerializeObject(list, Formatting.None);

            //Console.WriteLine(json);
            Console.ReadKey();
        }

        public static SqlConnection GetOpenConnection(bool mars = false)
        {


            var cs = @"Server=127.0.0.1;Database=TestDB;User ID=sa;Password=Yyc@123456;connection timeout=1200";

            if (mars)
            {
                var scsb = new SqlConnectionStringBuilder(cs)
                {
                    MultipleActiveResultSets = true
                };
                cs = scsb.ConnectionString;
            }
            var connection = new SqlConnection(cs);
            connection.Open();
            return connection;
        }

        class JObjectHandler : TypeHandler<JObject>
        {
            private JObjectHandler() { }
            public static JObjectHandler Instance { get; } = new JObjectHandler();
            public override JObject Parse(object value)
            {
                try
                {
                    var json = (string)value;
                    return json == null ? null : JObject.Parse(json);
                }
                catch (Exception ex)
                {
                    dynamic o = new JObject();
                    o.value = value;
                    return o;
                }

            }

            public override void SetValue(IDbDataParameter parameter, JObject value)
            {
                parameter.Value = value?.ToString(Newtonsoft.Json.Formatting.None);
            }
        }

    }
}
