using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class IndexReceiptTimesViewModel : ViewModel
    {
        IEnumerable<TimeSpan> receiptTimes;

        public IEnumerable<TimeSpan> ReceiptTimes
        {
            get => receiptTimes;
            set
            {
                receiptTimes = value;
                OnPropertyChanged();
            }
        }


    }
}
