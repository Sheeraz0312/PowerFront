using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerFront.Common
{
    public static class DateTimeManagement
    {
        public static string RelativeTime(int Minutes)
        {
            var relativeTime = "";
            var SECOND   = 0.01;
            var MINUTE   = 1;
            var HOUR  = 60;
            var DAY   = 1440;

            var days = Minutes / DAY;
            if (days > 0 )
            {
                relativeTime = $"{relativeTime}{days}d";
            }

            var hours = (Minutes % DAY) /HOUR;
            if (hours > 0)
            {
                relativeTime = $"{relativeTime} {hours}h";
            }

            var minutes = ((Minutes % DAY) % HOUR) /MINUTE;
            if (minutes > 0)
            {
                relativeTime = $"{relativeTime} {minutes}m";
            }

            var seconds = (((Minutes % DAY) % HOUR) % MINUTE) /SECOND;
            if (seconds > 0)
            {
                relativeTime = $"{relativeTime} {seconds}s";
            }

            return relativeTime;
        }

        public static DateTime PreviousTime(string DefinedLabel,DateTime inputDate)
        {
            var PreviousTime = new DateTime();
           

            return PreviousTime;
        }
    }
}