using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using ASE.MD.MDP2.Product.MDP2Service.Utils;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Classes
{
    public class CalendarParser
    {
        public static List<StandardWorkHours> GetStandardWorkHours(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml)) return null;

            XmlDocument doc = new XmlDocument { InnerXml = xml };
            if (doc.DocumentElement == null) return null;

            var res = new List<StandardWorkHours>();
            foreach (XmlElement node in doc.DocumentElement.ChildNodes)
            {
                if (node.Name == "StandardWorkHours")
                {
                    int dayOfWeek;
                    var workHours = node.GetElementsByTagName("WorkTime");
                    if (!Int32.TryParse(DayOfWeekToNumber(node.FirstChild.Return(x => x.InnerText)), out dayOfWeek) || workHours.Count == 0)
                        continue;

                    if (dayOfWeek == 7) dayOfWeek = 0;
                    var item = new StandardWorkHours { DayOfWeek = dayOfWeek };
                    foreach (XmlElement workHourNode in workHours)
                    {
                        TimeSpan start;
                        TimeSpan end;
                        if (workHourNode.ChildNodes.Count != 0 &&
                            TimeSpan.TryParse(workHourNode.FirstChild.Return(x => x.InnerText), out start) &&
                            TimeSpan.TryParse(workHourNode.FirstChild.NextSibling.Return(x => x.InnerText), out end))
                            item.WorkTimes.Add(new WorkTime(start, end.Add(TimeSpan.FromMinutes(1)))); //из примаверы время окончания приходит без одной минуты, поэтому добавляем ее
                    }
                    res.Add(item);
                }
            }
            return res;
        }

        public static List<HolidayOrExceptions> GetHolidayOrExceptions(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml)) return null;

            XmlDocument doc = new XmlDocument { InnerXml = xml };
            if (doc.DocumentElement == null) return null;

            var res = new List<HolidayOrExceptions>();
            foreach (XmlElement node in doc.DocumentElement.ChildNodes)
            {
                if (node.Name == "HolidayOrException")
                {
                    const string pattern = @"(\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2})(\d{2}:\d{2}:\d{2})?(\d{2}:\d{2}:\d{2})?"; //формат (YYYY:MM:DD T HH:MM:SS) (HH:MM:SS) (HH:MM:SS)
                    if (node.InnerText == null) continue;
                    
                    var part1_Data = Regex.Match(node.InnerText, pattern).Groups[1].Value;
                    var part2_TimeStart = Regex.Match(node.InnerText, pattern).Groups[2].Value;
                    var part3_TimeFinish = Regex.Match(node.InnerText, pattern).Groups[3].Value;
                    var workHours = node.GetElementsByTagName("WorkTime");

                    if (!DateTime.TryParse(part1_Data, out var date))
                        continue;

                    var item = new HolidayOrExceptions { Date = date };
                    foreach (XmlElement workHourNode in workHours)
                    {
                        if (TimeSpan.TryParse(part2_TimeStart, out var start) && TimeSpan.TryParse(part3_TimeFinish, out var end))
                            item.WorkTimes.Add(new WorkTime(start, end.Add(TimeSpan.FromMinutes(1))));
                    }
                    
                    res.Add(item);
                }
            }

            return res;
        }

        private static string DayOfWeekToNumber(string str)
        {
            switch (str)
            {
                case "Sunday":
                    return "0";
                case "Monday":
                    return "1";
                case "Tuesday":
                    return "2";
                case "Wednesday":
                    return "3";
                case "Thursday":
                    return "4";
                case "Friday":
                    return "5";
                case "Saturday":
                    return "6";
                default:
                    return str;
            }
        }
    }
}
