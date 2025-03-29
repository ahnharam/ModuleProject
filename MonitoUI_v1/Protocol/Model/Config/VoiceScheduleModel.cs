using System;
using System.Data;

namespace Protocol.Model.Config
{
    public class VoiceScheduleModel : BaseM
    {
        private int no;

        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private int section;

        public int Section
        {
            get { return section; }
            set { SetProperty(ref section, value); }
        }

        private TimeSpan time;

        public TimeSpan Time
        {
            get { return time; }
            set { SetProperty(ref time, value); }
        }

        private int voiceNo;

        public int VoiceNo
        {
            get { return voiceNo; }
            set { SetProperty(ref voiceNo, value); }
        }
        
        public VoiceScheduleModel()
        { }

        public VoiceScheduleModel(DataRow dataRow):base(dataRow)
        { }

        public override void ConvertData(DataRow dataRow)
        {
            this.No = ConvertInt(dataRow, "no");
            this.Section=ConvertInt(dataRow, "section");
            this.Time=ConvertTime(dataRow, "time");
            this.VoiceNo = ConvertInt(dataRow, "voiceno");
        }
    }

    public class VoiceScheduleList:BaseList<VoiceScheduleModel>
    { }
}