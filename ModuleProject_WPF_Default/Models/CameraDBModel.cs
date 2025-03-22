using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ModuleProject_WPF_Default.Models
{
    public class CameraDBModel : IsEditUpdater
    {
        // 원본 데이터 필드
        private int _camno;
        private string _camname;
        private string _userid;
        private string _pwd;
        private string _ipaddr;
        private int? _portno;
        private string _url;
        private int? _isptz;
        private int? _resx;
        private int? _resy;
        private int? _codecid;
        private string _model;
        private int? _modelindex;
        private string _destsvrip;
        private int? _destport;
        private int? _destch;
        private int? _audioon;
        private int? _fps;
        private int? _bps;
        private int? _protocol;
        private int? _subch;
        private int? _transportmode;
        private string _description;
        private int? _areano;
        private int? _areacamno;
        private string _datacollection;
        private string _collectionkind;

        // UI 데이터 필드
        private int _camnoui;
        private string _camnameui;
        private string _useridui;
        private string _pwdui;
        private string _ipaddrui;
        private int? _portnoui;
        private string _urlui;
        private int? _isptzui;
        private int? _resxui;
        private int? _resyui;
        private int? _codecidui;
        private string _modelui;
        private int? _modelindexui;
        private string _destsvripui;
        private int? _destportui;
        private int? _destchui;
        private int? _audioonui;
        private int? _fpsui;
        private int? _bpsui;
        private int? _protocolui;
        private int? _subchui;
        private int? _transportmodeui;
        private string _descriptionui;
        private int? _areanoui;
        private int? _areacamnoui;
        private string _datacollectionui;
        private string _collectionkindui;

        // 원본 데이터 프로퍼티
        public int camno
        {
            get { return _camno; }
            set { if (SetProperty(ref _camno, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string camname
        {
            get { return _camname; }
            set { if (SetProperty(ref _camname, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string userid
        {
            get { return _userid; }
            set { if (SetProperty(ref _userid, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string pwd
        {
            get { return _pwd; }
            set { if (SetProperty(ref _pwd, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string ipaddr
        {
            get { return _ipaddr; }
            set { if (SetProperty(ref _ipaddr, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? portno
        {
            get { return _portno; }
            set { if (SetProperty(ref _portno, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string url
        {
            get { return _url; }
            set { if (SetProperty(ref _url, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? isptz
        {
            get { return _isptz; }
            set { if (SetProperty(ref _isptz, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? resx
        {
            get { return _resx; }
            set { if (SetProperty(ref _resx, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? resy
        {
            get { return _resy; }
            set { if (SetProperty(ref _resy, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? codecid
        {
            get { return _codecid; }
            set { if (SetProperty(ref _codecid, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string model
        {
            get { return _model; }
            set { if (SetProperty(ref _model, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? modelindex
        {
            get { return _modelindex; }
            set { if (SetProperty(ref _modelindex, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string destsvrip
        {
            get { return _destsvrip; }
            set { if (SetProperty(ref _destsvrip, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? destport
        {
            get { return _destport; }
            set { if (SetProperty(ref _destport, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? destch
        {
            get { return _destch; }
            set { if (SetProperty(ref _destch, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? audioon
        {
            get { return _audioon; }
            set { if (SetProperty(ref _audioon, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? fps
        {
            get { return _fps; }
            set { if (SetProperty(ref _fps, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? bps
        {
            get { return _bps; }
            set { if (SetProperty(ref _bps, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? protocol
        {
            get { return _protocol; }
            set { if (SetProperty(ref _protocol, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? subch
        {
            get { return _subch; }
            set { if (SetProperty(ref _subch, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? transportmode
        {
            get { return _transportmode; }
            set { if (SetProperty(ref _transportmode, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string description
        {
            get { return _description; }
            set { if (SetProperty(ref _description, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? areano
        {
            get { return _areano; }
            set { if (SetProperty(ref _areano, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? areacamno
        {
            get { return _areacamno; }
            set { if (SetProperty(ref _areacamno, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string datacollection
        {
            get { return _datacollection; }
            set { if (SetProperty(ref _datacollection, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string collectionkind
        {
            get { return _collectionkind; }
            set { if (SetProperty(ref _collectionkind, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        // UI 데이터 프로퍼티
        public int camnoui
        {
            get { return _camnoui; }
            set { if (SetProperty(ref _camnoui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string camnameui
        {
            get { return _camnameui; }
            set { if (SetProperty(ref _camnameui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string useridui
        {
            get { return _useridui; }
            set { if (SetProperty(ref _useridui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string pwdui
        {
            get { return _pwdui; }
            set { if (SetProperty(ref _pwdui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string ipaddrui
        {
            get { return _ipaddrui; }
            set { if (SetProperty(ref _ipaddrui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? portnoui
        {
            get { return _portnoui; }
            set { if (SetProperty(ref _portnoui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string urlui
        {
            get { return _urlui; }
            set { if (SetProperty(ref _urlui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? isptzui
        {
            get { return _isptzui; }
            set { if (SetProperty(ref _isptzui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? resxui
        {
            get { return _resxui; }
            set { if (SetProperty(ref _resxui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? resyui
        {
            get { return _resyui; }
            set { if (SetProperty(ref _resyui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? codecidui
        {
            get { return _codecidui; }
            set { if (SetProperty(ref _codecidui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string modelui
        {
            get { return _modelui; }
            set { if (SetProperty(ref _modelui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? modelindexui
        {
            get { return _modelindexui; }
            set { if (SetProperty(ref _modelindexui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string destsvripui
        {
            get { return _destsvripui; }
            set { if (SetProperty(ref _destsvripui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? destportui
        {
            get { return _destportui; }
            set { if (SetProperty(ref _destportui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? destchui
        {
            get { return _destchui; }
            set { if (SetProperty(ref _destchui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? audioonui
        {
            get { return _audioonui; }
            set { if (SetProperty(ref _audioonui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? fpsui
        {
            get { return _fpsui; }
            set { if (SetProperty(ref _fpsui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? bpsui
        {
            get { return _bpsui; }
            set { if (SetProperty(ref _bpsui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? protocolui
        {
            get { return _protocolui; }
            set { if (SetProperty(ref _protocolui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? subchui
        {
            get { return _subchui; }
            set { if (SetProperty(ref _subchui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? transportmodeui
        {
            get { return _transportmodeui; }
            set { if (SetProperty(ref _transportmodeui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string descriptionui
        {
            get { return _descriptionui; }
            set { if (SetProperty(ref _descriptionui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? areanoui
        {
            get { return _areanoui; }
            set { if (SetProperty(ref _areanoui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public int? areacamnoui
        {
            get { return _areacamnoui; }
            set { if (SetProperty(ref _areacamnoui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string datacollectionui
        {
            get { return _datacollectionui; }
            set { if (SetProperty(ref _datacollectionui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        public string collectionkindui
        {
            get { return _collectionkindui; }
            set { if (SetProperty(ref _collectionkindui, value)) OnPropertyChanged(nameof(IsEdit)); }
        }

        // 기본 생성자
        public CameraDBModel() : base() { }

        // 원본 데이터를 UI 데이터로 복사
        public override void CopyOriginToUI()
        {
            camnoui = camno;
            camnameui = camname;
            useridui = userid;
            pwdui = pwd;
            ipaddrui = ipaddr;
            portnoui = portno;
            urlui = url;
            isptzui = isptz;
            resxui = resx;
            resyui = resy;
            codecidui = codecid;
            modelui = model;
            modelindexui = modelindex;
            destsvripui = destsvrip;
            destportui = destport;
            destchui = destch;
            audioonui = audioon;
            fpsui = fps;
            bpsui = bps;
            protocolui = protocol;
            subchui = subch;
            transportmodeui = transportmode;
            descriptionui = description;
            areanoui = areano;
            areacamnoui = areacamno;
            datacollectionui = datacollection;
            collectionkindui = collectionkind;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            camno = camnoui;
            camname = camnameui;
            userid = useridui;
            pwd = pwdui;
            ipaddr = ipaddrui;
            portno = portnoui;
            url = urlui;
            isptz = isptzui;
            resx = resxui;
            resy = resyui;
            codecid = codecidui;
            model = modelui;
            modelindex = modelindexui;
            destsvrip = destsvripui;
            destport = destportui;
            destch = destchui;
            audioon = audioonui;
            fps = fpsui;
            bps = bpsui;
            protocol = protocolui;
            subch = subchui;
            transportmode = transportmodeui;
            description = descriptionui;
            areano = areanoui;
            areacamno = areacamnoui;
            datacollection = datacollectionui;
            collectionkind = collectionkindui;
        }

        // 사용자가 데이터를 편집했는지 확인
        public override bool IsUserEdit()
        {
            return camno != camnoui ||
                   camname != camnameui ||
                   userid != useridui ||
                   pwd != pwdui ||
                   ipaddr != ipaddrui ||
                   portno != portnoui ||
                   url != urlui ||
                   isptz != isptzui ||
                   resx != resxui ||
                   resy != resyui ||
                   codecid != codecidui ||
                   model != modelui ||
                   modelindex != modelindexui ||
                   destsvrip != destsvripui ||
                   destport != destportui ||
                   destch != destchui ||
                   audioon != audioonui ||
                   fps != fpsui ||
                   bps != bpsui ||
                   protocol != protocolui ||
                   subch != subchui ||
                   transportmode != transportmodeui ||
                   description != descriptionui ||
                   areano != areanoui ||
                   areacamno != areacamnoui ||
                   datacollection != datacollectionui ||
                   collectionkind != collectionkindui;
        }
    }

    public class CameraDBList : BaseDBList<CameraDBModel>
    {
        public CameraDBList() : base() { }

        // Method to generate the SQL query for selecting all entries from the camera table
        public string SelectAllQuery()
        {
            return "SELECT * FROM camera";
        }

        // Method to parse the dataset and populate the collection
        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                CameraDBModel model = new CameraDBModel();
                Assign(dr, model);

                this.Add(model);
            }

            dataset.Clear();
        }

        // Method to map a DataRow to a CameraModel instance
        private void Assign(DataRow dr, CameraDBModel model)
        {
            model.camno = Convert.ToInt32(dr["camno"].ToString());
            model.camname = dr["camname"]?.ToString();
            model.userid = dr["userid"]?.ToString();
            model.pwd = dr["pwd"]?.ToString();
            model.ipaddr = dr["ipaddr"]?.ToString();
            model.portno = dr["portno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["portno"].ToString());
            model.url = dr["url"]?.ToString();
            model.isptz = dr["isptz"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["isptz"].ToString());
            model.resx = dr["resx"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["resx"].ToString());
            model.resy = dr["resy"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["resy"].ToString());
            model.codecid = dr["codecid"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["codecid"].ToString());
            model.model = dr["model"]?.ToString();
            model.modelindex = dr["modelindex"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["modelindex"].ToString());
            model.destsvrip = dr["destsvrip"]?.ToString();
            model.destport = dr["destport"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["destport"].ToString());
            model.destch = dr["destch"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["destch"].ToString());
            model.audioon = dr["audioon"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["audioon"].ToString());
            model.fps = dr["fps"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["fps"].ToString());
            model.bps = dr["bps"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["bps"].ToString());
            model.protocol = dr["protocol"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["protocol"].ToString());
            model.subch = dr["subch"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["subch"].ToString());
            model.transportmode = dr["transportmode"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["transportmode"].ToString());
            model.description = dr["description"]?.ToString();
            model.areano = dr["areano"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["areano"].ToString());
            model.areacamno = dr["areacamno"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["areacamno"].ToString());
            model.datacollection = dr["datacollection"]?.ToString();
            model.collectionkind = dr["collectionkind"]?.ToString();
        }

        // Method to get a model by its Camno property
        public CameraDBModel GetByCamno(int camno)
        {
            return this.FirstOrDefault(a => a.camno == camno);
        }
    }
}
