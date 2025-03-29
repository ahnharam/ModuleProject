using System.Data;

namespace Protocol.Model.Config
{
    public class VoiceModel : BaseM
    {
        private int no;

        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private int voiceNo;

        public int VoiceNo
        {
            get { return voiceNo; }
            set { SetProperty(ref voiceNo, value); }
        }

        private string memo;

        public string Memo
        {
            get { return memo; }
            set { SetProperty(ref memo, value); }
        }

        private string remark;

        public string Remark
        {
            get { return remark; }
            set { SetProperty(ref remark, value); }
        }

        public VoiceModel()
        { }

        public VoiceModel(DataRow dataRow):base(dataRow)
        { }

        public override void ConvertData(DataRow dataRow)
        {
            this.No = ConvertInt(dataRow, "no");
            this.Title = ConvertString(dataRow, "title");
            this.VoiceNo = ConvertInt(dataRow, "voiceno");
            this.Memo = ConvertString(dataRow, "memo");
            this.Remark = ConvertString(dataRow, "remark");
        }
    }
    public class VoiceList:BaseList<VoiceModel>
    { }
}