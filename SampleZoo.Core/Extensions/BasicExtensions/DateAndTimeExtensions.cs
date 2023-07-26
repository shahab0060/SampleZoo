﻿using System.Globalization;

namespace SampleZoo.Core.Extensions.BasicExtensions
{
    public static class CustomDateAndTimeExtensions
    {
        #region To Shamsi

        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
        }

        public static string ToShamsi(this DateTime? value)
        => (value is not null) ? ((DateTime)value).ToShamsi() : "-";

        #endregion

        public static string ToPersianYear(this DateTime dateTime)
            => dateTime.ToPersianYearNumber().ToString();
        public static int ToPersianYearNumber(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(dateTime);
        }

        public static string ToPersianDayOfWeekName(this DateTime dateTime)
     => dateTime.DayOfWeek switch
     {
         DayOfWeek.Friday => "جمعه",
         DayOfWeek.Saturday => "شنبه",
         DayOfWeek.Sunday => "یک شنبه",
         DayOfWeek.Monday => "دو شنبه",
         DayOfWeek.Tuesday => "سه شنبه",
         DayOfWeek.Wednesday => "چهار شنبه",
         DayOfWeek.Thursday => "پنج شنبه",
         _ => ""
     };

        public static int ToPersianDayOfMonth(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            return persianCalendar.GetDayOfMonth(time: dateTime);
        }

        public static int ToPersianMonth(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            return persianCalendar.GetMonth(time: dateTime);
        }

        public static int ToPersianHour(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            return persianCalendar.GetHour(time: dateTime);
        }

        public static int ToPersianMinute(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            return persianCalendar.GetMinute(time: dateTime);
        }

        public static string ToPersianMonthName(this DateTime dateTime) => dateTime.Month.ToPersianMonthName();

        public static string ToPersianMonthName(this int month) => month switch
        {
            1 => "فروردین",
            2 => "اردیبهشت",
            3 => "خرداد",
            4 => "تبر",
            5 => "مرداد",
            6 => "شهریور",
            7 => "مهر",
            8 => "آبان",
            9 => "آذر",
            10 => "دی",
            11 => "بهمن",
            12 => "اسفند",
            _ => "",
        };

        public static string ToPersianDateTimeText(this DateTime dateTime)
        => dateTime.ToPersianDayOfWeekName() + " " + dateTime.ToPersianDayOfMonth() + " " + dateTime.ToPersianMonth().ToPersianMonthName() + " " +
                   dateTime.ToPersianYearNumber() + " " + dateTime.ToPersianHour().ToPersianHourAndMinute(dateTime.ToPersianMinute());

        public static string ToPersianDateText(this DateTime dateTime)
       => dateTime.ToPersianDayOfWeekName() + " " + dateTime.ToPersianDayOfMonth() + " " + dateTime.ToPersianMonth().ToPersianMonthName() + " " +
                   dateTime.ToPersianYearNumber();

        public static string ToPersianHourAndMinute(this int hour, int minute)
        {
            string daySituationTitle = hour switch
            {
                < 12 => "صبح",
                12 => "ظهر",
                > 12 and < 20 => "بعد از ظهر",
                > 20 => "شب",
                _ => "شب"
            };

            int easyHour = hour switch
            {
                <= 12 => hour,
                > 12 => hour - 12,
            };

            return $"ساعت {easyHour}:{minute:00} دقیقه {daySituationTitle}";
        }

        public static string ToShortTime(this DateTime value) => $"{value.Year}-{(value.Month < 10 ? "0" + value.Month : value.Month)}-{(value.Day < 10 ? "0" + value.Day : value.Day)}";

        public static string GetPersianDateDiff(this DateTime dateTime)
        {
            // Calculate the difference between the input date and current date
            TimeSpan timeSpan = DateTime.Now.Date - dateTime.Date;
            int diffDays = (int)timeSpan.TotalDays;

            // Convert the difference to a human-readable text format in Persian language
            if (diffDays == 0)
                return "امروز";

            if (diffDays == 1)
                return "دیروز";

            if (diffDays <= 30)
                return $"{diffDays} روز پیش";

            if (diffDays < 365)
                return $"{diffDays / 30} ماه پیش";

            return $"{diffDays / 365} سال پیش";
        }

    }
}
