using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyBackup
{
    /// <summary>
    /// 排程設定管理器
    /// </summary>
    public class ScheduleManager
    {
        /// <summary>
        /// 排程設定檔名
        /// </summary>
        private static readonly string scheduleFileName = "schedule.json";

        /// <summary>
        /// 排程設定清單
        /// </summary>
        private readonly List<Schedule> schedules = new List<Schedule>();

        /// <summary>
        /// 排程設定計數
        /// </summary>
        public int Count
        {
            get { return schedules.Count; }
        }

        /// <summary>
        /// Index operator
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns>排程設定物件</returns>
        public Schedule this[int index]
        {
            get { return schedules[index]; }
        }

        /// <summary>
        /// 排程設定檔轉換方法
        /// </summary>
        public void ProcessSchedules()
        {
            if (File.Exists(scheduleFileName) == false)
            {
                return;
            }

            // Parse json file
            JObject jObject = JObject.Parse(File.ReadAllText(scheduleFileName));

            // Cast json object to dynamic type
            dynamic dyObject = (dynamic)jObject;

            // Get array of configs
            List<dynamic> dynSchedules = ((JArray)dyObject["schedules"]).Cast<dynamic>().ToList();

            // Convert to objects of Schedule
            IEnumerable<Schedule> scheduleModels = dynSchedules.Select(x => new Schedule(
                (string)x["ext"],
                (string)x["time"],
                (string)x["interval"]));

            schedules.AddRange(scheduleModels);
        }
    }
}