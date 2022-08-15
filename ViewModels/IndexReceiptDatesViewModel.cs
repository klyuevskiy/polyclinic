using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace ViewModels
{
    public class IndexReceiptDatesViewModel : ViewModel
    {
        public Calendar Calendar { get; set; }

        public void Update(int doctorId)
        {
            Calendar.BlackoutDates.Clear();

            var availableDates = ReceiptDateProcess.GetAvailableDates(doctorId);

            if (availableDates.Count > 0)
            {
                Calendar.DisplayDateStart = availableDates.First();
                Calendar.DisplayDateEnd = availableDates.Last();

                List<DateTime> blackoutDates = ReceiptDateProcess.GetBlackoutDates(availableDates);

                foreach (var item in blackoutDates)
                {
                    Calendar.BlackoutDates.Add(new CalendarDateRange(item));
                }
            }
        }
    }
}
