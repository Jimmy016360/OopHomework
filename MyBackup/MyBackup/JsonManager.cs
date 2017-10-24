using Newtonsoft.Json.Linq;
using System.IO;

namespace MyBackup
{
    /// <summary>
    /// Json 設定檔管理抽象類別
    /// </summary>
    public abstract class JsonManager
    {
        /// <summary>
        /// 根據檔案位置取得 Json 動態物件
        /// </summary>
        /// <param name="filePath">檔案位置</param>
        /// <returns>動態物件</returns>
        public dynamic GetJsonObject(string filePath)
        {
            if (File.Exists(filePath) == false)
            {
                return null;
            }

            // Parse json file
            JObject jObject = JObject.Parse(File.ReadAllText(filePath));

            // Cast json object to dynamic type
            dynamic dyObject = (dynamic)jObject;

            return dyObject;
        }

        /// <summary>
        /// Json 設定處理方法
        /// </summary>
        public abstract void ProcessJsonConfig();
    }
}