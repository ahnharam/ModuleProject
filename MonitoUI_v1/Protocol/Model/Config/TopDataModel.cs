namespace Protocol.Model.Config
{
    public class TopDataModel : BaseM
    {
        private string headerName;

        public string HeaderName
        {
            get { return headerName; }
            set { SetProperty(ref headerName, value); }
        }

        private int headerWidth;

        public int HeaderWidth
        {
            get { return headerWidth; }
            set { SetProperty(ref headerWidth, value); }
        }

        private string contentName;

        public string ContentName
        {
            get { return contentName; }
            set { SetProperty(ref contentName, value); }
        }

        private int contentWidth;

        public int ContentWidth
        {
            get { return contentWidth; }
            set { SetProperty(ref contentWidth, value); }
        }
    }
}