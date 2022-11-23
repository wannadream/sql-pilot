using System;

namespace SQL_Pilot.Data
{
    public class SqlJobHistory
    {
        public int InstanceId { get; set; }
        public string Message { get; set; }
        public int StepId { get; set; }
        public string StepName { get; set; }
        public int RunDuration { get; set; }
        public DateTime RunTime { get; set; }

        public string RunDurationDislplay
        {
            get
            {
                string runDuration = RunDuration.ToString().PadLeft(6, '0');
                string hourStr = runDuration.Substring(0, 2);
                string minuteStr = runDuration.Substring(2, 2);
                string secondStr = runDuration.Substring(4, 2);

                int second = int.Parse(secondStr) % 60;
                int minute = (int.Parse(minuteStr) + int.Parse(secondStr) / 60) % 60;
                int hour = int.Parse(hourStr) + (int.Parse(minuteStr) + int.Parse(secondStr) / 60) / 60;

                string result = $"{second} s";
                if (minute > 0) result = $"{minute} m " + result;
                if (hour > 0) result = $"{hour} h " + result;

                return result;
            }
        }
        public int RunDurationInSeconds
        {
            get
            {
                string runDuration = RunDuration.ToString().PadLeft(6, '0');
                string hourStr = runDuration.Substring(0, 2);
                string minuteStr = runDuration.Substring(2, 2);
                string secondStr = runDuration.Substring(4, 2);
                return int.Parse(secondStr) + int.Parse(minuteStr) * 60 + int.Parse(hourStr) * 3600;
            }
        }

    }
}
