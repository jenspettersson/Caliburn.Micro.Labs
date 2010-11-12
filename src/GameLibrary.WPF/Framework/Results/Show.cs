namespace GameLibrary.WPF.Framework.Results
{
    public class Show
    {
        public static OpenChildResult<TChild> Child<TChild>()
        {
            return new OpenChildResult<TChild>();
        }

        public static OpenChildResult<TChild> Child<TChild>(TChild child)
        {
            return new OpenChildResult<TChild>(child);
        }

        public static BusyResult Busy()
        {
            return new BusyResult(true, null);
        }

        public static BusyResult Busy(object busyViewModel)
        {
            return new BusyResult(true, busyViewModel);
        }

        public static BusyResult NotBusy()
        {
            return new BusyResult(false, null);
        }
    }
}