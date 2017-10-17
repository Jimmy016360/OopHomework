using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyBackup
{
    /// <summary>
    /// 檔案處理管理器
    /// </summary>
    public class ConfigManager
    {
        /// <summary>
        /// 檔案處理清單
        /// </summary>
        public List<Config> configs = new List<Config>();

        /// <summary>
        /// 檔案處理檔名
        /// </summary>
        private static readonly string configFileName = "config.json";

        /// <summary>
        /// 檔案處理計數
        /// </summary>
        public int Count
        {
            get { return configs.Count; }
        }

        /// <summary>
        /// Index operator
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns>檔案處理物件</returns>
        public Config this[int index]
        {
            get { return configs[index]; }
        }

        /// <summary>
        /// 檔案處理設定檔轉換方法
        /// </summary>
        public void ProcessConfigs()
        {
            if (File.Exists(configFileName) == false)
            {
                return;
            }

            // Parse json file
            JObject jObject = JObject.Parse(File.ReadAllText(configFileName));

            // Cast json object to dynamic type
            dynamic dyObject = (dynamic)jObject;

            // Get array of configs
            List<dynamic> dynConfigs = ((JArray)dyObject["configs"]).Cast<dynamic>().ToList();

            // Convert to objects of Config
            IEnumerable<Config> configModels = dynConfigs.Select(x => new Config(
                                                                            (string)x["ext"],
                                                                            (string)x["location"],
                                                                            (bool)x["subDirectory"],
                                                                            (string)x["unit"],
                                                                            (bool)x["remove"],
                                                                            (string)x["handler"],
                                                                            (string)x["destination"],
                                                                            (string)x["dir"],
                                                                            (string)x["connectionString"]));

            configs.AddRange(configModels);
        }
    }
}