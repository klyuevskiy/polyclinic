using Models.DataAccess;
using Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class ReceiptDateProcess
    {
        static int oneReceiptMinutes = 30,
            doctorReceiptHours = 6,
            doctorReceiptHourStart = 8,
            doctorReceiptsNumber = doctorReceiptHours * 60 / oneReceiptMinutes;

        public static List<DateTime> GetAvailableDates(int doctorId)
        {
            List<DateTime> availableDays = new List<DateTime>();

            DateTime startDate = DateTime.Today,
                endDate = startDate.AddMonths(1);

            while (!startDate.Equals(endDate))
            {
                IEnumerable<Appeal> appeals = AppealDAL.GetDateDoctor(startDate, doctorId);

                if (appeals.Count() < doctorReceiptsNumber)
                    availableDays.Add(startDate);

                startDate.AddDays(1);
            }

            return availableDays;
        }

        public static List<DateTime> GetBlackoutDates(List<DateTime> availableDates)
        {
            var blackoutDates = new List<DateTime>();

            if (availableDates.Count == 0)
                return blackoutDates;

            DateTime time = availableDates.First();

            for (int i = 0; i < availableDates.Count; i++)
            {
                if (!availableDates.Contains(time))
                    blackoutDates.Add(time);

                time = time.AddDays(1);
            }

            return blackoutDates;
        }

        static List<TimeSpan> GetReceiptTimes(DateTime date, int doctorId)
        {
            IEnumerable<Appeal> appeals = AppealDAL.GetDateDoctor(date, doctorId);
            List<TimeSpan> times = new List<TimeSpan>();

            TimeSpan time = TimeSpan.FromHours(doctorReceiptHourStart),
                addMinutes = TimeSpan.FromMinutes(oneReceiptMinutes);

            for (int i = 0; i < doctorReceiptsNumber; i++)
            {
                if (appeals.FirstOrDefault(appeal =>
                appeal.ReceiptDate.TimeOfDay.Equals(time)) == null)
                    times.Add(time);

                time = time.Add(addMinutes);
            }

            return times;
        }
    }
}
