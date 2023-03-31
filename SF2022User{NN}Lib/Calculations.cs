using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF2022User_NN_Lib
{
    public class AvailablePeriods
    {
        public static string[] GetAvailablePeriods(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            var result = new List<string>();
            var endConsultationTime = beginWorkingTime + TimeSpan.FromMinutes(consultationTime);
            var endOfDay = endWorkingTime - TimeSpan.FromMinutes(consultationTime);

            for (var i = 0; i < startTimes.Length; i++)
            {
                var startTime = startTimes[i];
                var endTime = startTime + TimeSpan.FromMinutes(durations[i]);

                if (startTime < beginWorkingTime)
                {
                    startTime = beginWorkingTime;
                }

                if (endTime > endOfDay)
                {
                    break;
                }

                if (startTime >= endConsultationTime)
                {
                    result.Add($"{startTime:hh\\:mm}-{endTime:hh\\:mm}");
                }

                beginWorkingTime = endTime;
            }

            if (beginWorkingTime < endOfDay && beginWorkingTime >= endConsultationTime)
            {
                result.Add($"{beginWorkingTime:hh\\:mm}-{endOfDay:hh\\:mm}");
            }

            return result.ToArray();
        }
    }
}
