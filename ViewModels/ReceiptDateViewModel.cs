using System;

namespace ViewModels
{
    public class ReceiptDateViewModel : ViewModel
    {
        DateTime receiptDate;
        TimeSpan receiptTime;

        public DateTime ReceiptDate
        {
            get => receiptDate;
            set
            {
                receiptDate = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan ReceiptTime
        {
            get => receiptTime;
            set
            {
                receiptTime = value;
                OnPropertyChanged();
            }
        }

        public ReceiptDateViewModel(DateTime receiptDateTime)
        {
            receiptDate = receiptDateTime.Date;
            receiptTime = receiptDateTime.TimeOfDay;
        }
    }
}
