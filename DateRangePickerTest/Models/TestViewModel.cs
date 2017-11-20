using System.ComponentModel;

namespace DateRangePickerTest.Models
{
    public class TestViewModel
    {
        [DisplayName("Some String")]
        public string SomeString { get; set; }

        [DisplayName("Some Integer")]
        public int SomeInt { get; set; }

        [DisplayName("Some Date Range")]
        public DateRange SomeDateRange { get; set; }

        [DisplayName("Some Other Date Range")]
        public DateRange SomeOtherDateRange { get; set; }
    }
}