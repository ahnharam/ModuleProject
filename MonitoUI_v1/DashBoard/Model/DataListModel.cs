using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard.Model
{
    public class DataListModel: BindableBase
    {
        private int no;
        public int No
        {
            get { return no; }
            set { SetProperty(ref no, value); }
        }

        private string section;
        public string Section
        {
            get { return section; }
            set { SetProperty(ref section, value); }
        }

        private int temp;
        public int Temp
        {
            get { return temp; }
            set { SetProperty(ref temp, value); }
        }

        private int humi;
        public int Humi
        {
            get { return humi; }
            set { SetProperty(ref humi, value); }
        }

        private bool air;
        public bool Air
        {
            get { return air; }
            set { SetProperty(ref air, value); }
        }

        private bool airState;
        public bool AirState
        {
            get { return airState; }
            set { SetProperty(ref airState, value); }
        }

        private bool light;
        public bool Light
        {
            get { return light; }
            set { SetProperty(ref light, value); }
        }

        private bool doorIn;
        public bool DoorIn
        {
            get { return doorIn; }
            set { SetProperty(ref doorIn, value); }
        }

        private bool doorOut;
        public bool DoorOut
        {
            get { return doorOut; }
            set { SetProperty(ref doorOut, value); }
        }

        private bool call;
        public bool Call
        {
            get { return call; }
            set { SetProperty(ref call, value); }
        }

        private int fair;
        public int Fair
        {
            get { return fair; }
            set { SetProperty(ref fair, value); }
        }

        private bool aICam;
        public bool AICam
        {
            get { return aICam; }
            set { SetProperty(ref aICam, value); }
        }

        private int user;
        public int User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        private bool derect;
        public bool Derect
        {
            get { return derect; }
            set { SetProperty(ref derect, value); }
        }

        private bool num;
        public bool Num
        {
            get { return num; }
            set { SetProperty(ref num, value); }
        }
    }
}
