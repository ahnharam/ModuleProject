using DevExpress.Pdf.Native;
using DevExpress.Xpo.DB.Helpers;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Media.Media3D;

namespace SystemEditor.DBModel.DBData
{
    public class CameraDBModel : IsEditUpdater, IDBQuery
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
            set { if (SetProperty(ref _camno, value)) UserEditEvent?.Invoke(); }
        }

        public string camname
        {
            get { return _camname; }
            set { if (SetProperty(ref _camname, value)) UserEditEvent?.Invoke(); }
        }

        public string userid
        {
            get { return _userid; }
            set { if (SetProperty(ref _userid, value)) UserEditEvent?.Invoke(); }
        }

        public string pwd
        {
            get { return _pwd; }
            set { if (SetProperty(ref _pwd, value)) UserEditEvent?.Invoke(); }
        }

        public string ipaddr
        {
            get { return _ipaddr; }
            set { if (SetProperty(ref _ipaddr, value)) UserEditEvent?.Invoke(); }
        }

        public int? portno
        {
            get { return _portno; }
            set { if (SetProperty(ref _portno, value)) UserEditEvent?.Invoke(); }
        }

        public string url
        {
            get { return _url; }
            set { if (SetProperty(ref _url, value)) UserEditEvent?.Invoke(); }
        }

        public int? isptz
        {
            get { return _isptz; }
            set { if (SetProperty(ref _isptz, value)) UserEditEvent?.Invoke(); }
        }

        public int? resx
        {
            get { return _resx; }
            set { if (SetProperty(ref _resx, value)) UserEditEvent?.Invoke(); }
        }

        public int? resy
        {
            get { return _resy; }
            set { if (SetProperty(ref _resy, value)) UserEditEvent?.Invoke(); }
        }

        public int? codecid
        {
            get { return _codecid; }
            set { if (SetProperty(ref _codecid, value)) UserEditEvent?.Invoke(); }
        }

        public string model
        {
            get { return _model; }
            set { if (SetProperty(ref _model, value)) UserEditEvent?.Invoke(); }
        }

        public int? modelindex
        {
            get { return _modelindex; }
            set { if (SetProperty(ref _modelindex, value)) UserEditEvent?.Invoke(); }
        }

        public string destsvrip
        {
            get { return _destsvrip; }
            set { if (SetProperty(ref _destsvrip, value)) UserEditEvent?.Invoke(); }
        }

        public int? destport
        {
            get { return _destport; }
            set { if (SetProperty(ref _destport, value)) UserEditEvent?.Invoke(); }
        }

        public int? destch
        {
            get { return _destch; }
            set { if (SetProperty(ref _destch, value)) UserEditEvent?.Invoke(); }
        }

        public int? audioon
        {
            get { return _audioon; }
            set { if (SetProperty(ref _audioon, value)) UserEditEvent?.Invoke(); }
        }

        public int? fps
        {
            get { return _fps; }
            set { if (SetProperty(ref _fps, value)) UserEditEvent?.Invoke(); }
        }

        public int? bps
        {
            get { return _bps; }
            set { if (SetProperty(ref _bps, value)) UserEditEvent?.Invoke(); }
        }

        public int? protocol
        {
            get { return _protocol; }
            set { if (SetProperty(ref _protocol, value)) UserEditEvent?.Invoke(); }
        }

        public int? subch
        {
            get { return _subch; }
            set { if (SetProperty(ref _subch, value)) UserEditEvent?.Invoke(); }
        }

        public int? transportmode
        {
            get { return _transportmode; }
            set { if (SetProperty(ref _transportmode, value)) UserEditEvent?.Invoke(); }
        }

        public string description
        {
            get { return _description; }
            set { if (SetProperty(ref _description, value)) UserEditEvent?.Invoke(); }
        }

        public int? areano
        {
            get { return _areano; }
            set { if (SetProperty(ref _areano, value)) UserEditEvent?.Invoke(); }
        }

        public int? areacamno
        {
            get { return _areacamno; }
            set { if (SetProperty(ref _areacamno, value)) UserEditEvent?.Invoke(); }
        }

        public string datacollection
        {
            get { return _datacollection; }
            set { if (SetProperty(ref _datacollection, value)) UserEditEvent?.Invoke(); }
        }

        public string collectionkind
        {
            get { return _collectionkind; }
            set { if (SetProperty(ref _collectionkind, value)) UserEditEvent?.Invoke(); }
        }

        // UI 데이터 프로퍼티
        public int camnoui
        {
            get { return _camnoui; }
            set { if (SetProperty(ref _camnoui, value)) UserEditEvent?.Invoke(); }
        }

        public string camnameui
        {
            get { return _camnameui; }
            set { if (SetProperty(ref _camnameui, value)) UserEditEvent?.Invoke(); }
        }

        public string useridui
        {
            get { return _useridui; }
            set { if (SetProperty(ref _useridui, value)) UserEditEvent?.Invoke(); }
        }

        public string pwdui
        {
            get { return _pwdui; }
            set { if (SetProperty(ref _pwdui, value)) UserEditEvent?.Invoke(); }
        }

        public string ipaddrui
        {
            get { return _ipaddrui; }
            set { if (SetProperty(ref _ipaddrui, value)) UserEditEvent?.Invoke(); }
        }

        public int? portnoui
        {
            get { return _portnoui; }
            set { if (SetProperty(ref _portnoui, value)) UserEditEvent?.Invoke(); }
        }

        public string urlui
        {
            get { return _urlui; }
            set { if (SetProperty(ref _urlui, value)) UserEditEvent?.Invoke(); }
        }

        public int? isptzui
        {
            get { return _isptzui; }
            set { if (SetProperty(ref _isptzui, value)) UserEditEvent?.Invoke(); }
        }

        public int? resxui
        {
            get { return _resxui; }
            set { if (SetProperty(ref _resxui, value)) UserEditEvent?.Invoke(); }
        }

        public int? resyui
        {
            get { return _resyui; }
            set { if (SetProperty(ref _resyui, value)) UserEditEvent?.Invoke(); }
        }

        public int? codecidui
        {
            get { return _codecidui; }
            set { if (SetProperty(ref _codecidui, value)) UserEditEvent?.Invoke(); }
        }

        public string modelui
        {
            get { return _modelui; }
            set { if (SetProperty(ref _modelui, value)) UserEditEvent?.Invoke(); }
        }

        public int? modelindexui
        {
            get { return _modelindexui; }
            set { if (SetProperty(ref _modelindexui, value)) UserEditEvent?.Invoke(); }
        }

        public string destsvripui
        {
            get { return _destsvripui; }
            set { if (SetProperty(ref _destsvripui, value)) UserEditEvent?.Invoke(); }
        }

        public int? destportui
        {
            get { return _destportui; }
            set { if (SetProperty(ref _destportui, value)) UserEditEvent?.Invoke(); }
        }

        public int? destchui
        {
            get { return _destchui; }
            set { if (SetProperty(ref _destchui, value)) UserEditEvent?.Invoke(); }
        }

        public int? audioonui
        {
            get { return _audioonui; }
            set { if (SetProperty(ref _audioonui, value)) UserEditEvent?.Invoke(); }
        }

        public int? fpsui
        {
            get { return _fpsui; }
            set { if (SetProperty(ref _fpsui, value)) UserEditEvent?.Invoke(); }
        }

        public int? bpsui
        {
            get { return _bpsui; }
            set { if (SetProperty(ref _bpsui, value)) UserEditEvent?.Invoke(); }
        }

        public int? protocolui
        {
            get { return _protocolui; }
            set { if (SetProperty(ref _protocolui, value)) UserEditEvent?.Invoke(); }
        }

        public int? subchui
        {
            get { return _subchui; }
            set { if (SetProperty(ref _subchui, value)) UserEditEvent?.Invoke(); }
        }

        public int? transportmodeui
        {
            get { return _transportmodeui; }
            set { if (SetProperty(ref _transportmodeui, value)) UserEditEvent?.Invoke(); }
        }

        public string descriptionui
        {
            get { return _descriptionui; }
            set { if (SetProperty(ref _descriptionui, value)) UserEditEvent?.Invoke(); }
        }

        public int? areanoui
        {
            get { return _areanoui; }
            set { if (SetProperty(ref _areanoui, value)) UserEditEvent?.Invoke(); }
        }

        public int? areacamnoui
        {
            get { return _areacamnoui; }
            set { if (SetProperty(ref _areacamnoui, value)) UserEditEvent?.Invoke(); }
        }

        public string datacollectionui
        {
            get { return _datacollectionui; }
            set { if (SetProperty(ref _datacollectionui, value)) UserEditEvent?.Invoke(); }
        }

        public string collectionkindui
        {
            get { return _collectionkindui; }
            set { if (SetProperty(ref _collectionkindui, value)) UserEditEvent?.Invoke(); }
        }

        #region RTSP
        private string _mainrtsp;
        private string _subrtsp;
        private string _mainrtspui;
        private string _subrtspui;

        public string mainrtsp
        {
            get { return _mainrtsp; }
            set { if (SetProperty(ref _mainrtsp, value)) UserEditEvent?.Invoke(); }
        }
        public string subrtsp
        {
            get { return _subrtsp; }
            set { if (SetProperty(ref _subrtsp, value)) UserEditEvent?.Invoke(); }
        }
        public string mainrtspui
        {
            get { return _mainrtspui; }
            set { if (SetProperty(ref _mainrtspui, value)) UserEditEvent?.Invoke(); }
        }
        public string subrtspui
        {
            get { return _subrtspui; }
            set { if (SetProperty(ref _subrtspui, value)) UserEditEvent?.Invoke(); }
        }
        #endregion

        #region AI
        private bool _isaicamerapeoplecount;
        private bool _isaicameraalarm;
        private bool _isaicamerapeoplecountui;
        private bool _isaicameraalarmui;

        public bool IsAiCameraPeopleCount
        {
            get { return _isaicamerapeoplecount; }
            set { if (SetProperty(ref _isaicamerapeoplecount, value)) UserEditEvent?.Invoke(); }
        }
        public bool IsAiCameraAlarm
        {
            get { return _isaicameraalarm; }
            set { if (SetProperty(ref _isaicameraalarm, value)) UserEditEvent?.Invoke(); }
        }
        public bool IsAiCameraPeopleCountUI
        {
            get { return _isaicamerapeoplecountui; }
            set { if (SetProperty(ref _isaicamerapeoplecountui, value)) UserEditEvent?.Invoke(); }
        }
        public bool IsAiCameraAlarmUI
        {
            get { return _isaicameraalarmui; }
            set { if (SetProperty(ref _isaicameraalarmui, value)) UserEditEvent?.Invoke(); }
        }
        #endregion

        #region UIP
        private bool _isptzcheck;
        private bool _isptzcheckui;

        public bool IsPTZCheck
        {
            get { return _isptzcheck; }
            set { if (SetProperty(ref _isptzcheck, value)) UserEditEvent?.Invoke(); }
        }
        public bool IsPTZCheckUI
        {
            get { return _isptzcheckui; }
            set { if (SetProperty(ref _isptzcheckui, value)) UserEditEvent?.Invoke(); }
        }
        #endregion

        // 기본 생성자
        public CameraDBModel() : base()
        {
            camno = 0;
            portno = 554;
            isptz = 0;
            resx = 0;
            resy = 0;
            codecid = 104;
            modelindex = 1;
            destport = 30008;
            destch = 1;
            audioon = 0;
            fps = 1;
            bps = 1;
            protocol = 1;
            subch = 0;
            transportmode = 1;
        }

        // 기본 생성자
        public CameraDBModel(StationInfoDBModel selectedStationInfoDBModel, int maxcamno, int index) : base()
        {
            camno = maxcamno + 1;
            portno = 554;
            isptz = 0;
            resx = 0;
            resy = 0;
            codecid = 104;
            modelindex = 1;
            destport = 30008;
            destch = 1;
            audioon = 0;
            fps = 1;
            bps = 1;
            protocol = 1;
            subch = camno + 1000;
            transportmode = 1;

            areano = selectedStationInfoDBModel.no;
            areacamno = index + 1;
        }

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
            
            mainrtspui = mainrtsp;
            subrtspui = subrtsp;

            ConvertOriginToUi();

            IsAiCameraPeopleCountUI = IsAiCameraPeopleCount;
            IsAiCameraAlarmUI = IsAiCameraAlarm;

            IsPTZCheckUI = IsPTZCheck;
        }

        // UI 데이터를 원본 데이터로 복사
        public override void CopyUIToOrigin()
        {
            ConvertUiToOrigin();

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

            mainrtsp = mainrtspui;
            subrtsp = subrtspui;

            IsAiCameraPeopleCount = IsAiCameraPeopleCountUI;
            IsAiCameraAlarm = IsAiCameraAlarmUI;

            IsPTZCheck = IsPTZCheckUI;
        }

        private void ConvertOriginToUi()
        {
            if (collectionkind.Contains("Event"))
            {
                IsAiCameraAlarm = true;
            }

            if (collectionkind.Contains("PeopleCount"))
            {
                IsAiCameraPeopleCount = true;
            }

            IsPTZCheck = isptz == 1 ? true : false;
        }

        private void ConvertUiToOrigin()
        {
            if (IsAiCameraPeopleCountUI == true &&
                IsAiCameraAlarmUI == true)
            {
                datacollectionui = "Y";
                collectionkindui = "PeopleCount,Event";
            }
            else if (IsAiCameraPeopleCountUI == false &&
                     IsAiCameraAlarmUI == true)
            {
                datacollectionui = "Y";
                collectionkindui = "Event";
            }
            else if (IsAiCameraPeopleCountUI == true &&
                     IsAiCameraAlarmUI == false)
            {
                datacollectionui = "Y";
                collectionkindui = "PeopleCount";
            }
            else if (IsAiCameraPeopleCountUI == false &&
                     IsAiCameraAlarmUI == false)
            {
                datacollectionui = "N";
                collectionkindui = "";
            }

            isptzui = IsPTZCheckUI == true ? 1 : 0;
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
                   collectionkind != collectionkindui ||
                   mainrtsp != mainrtspui ||
                   subrtsp != subrtspui ||
                   IsAiCameraPeopleCount != IsAiCameraPeopleCountUI||
                   IsAiCameraAlarm != IsAiCameraAlarmUI ||
                   IsPTZCheck != IsPTZCheckUI;
        }

        public void SetAutoIncrementIndex(long autoincrementindex)
        {

        }

        public string InsertQuery()
        {
            return "";
        }

        public string[] InsertSubQuery()
        {
            string[] querylist = new string[]
            {
                string.Format("Insert into camera values (" +
                    "{0}, '{1}', '{2}', '{3}', '{4}', {5}, '{6}', {7}, '{8}', '{9}', {10}, '{11}', {12}, '{13}', " +
                    "{14}, '{15}', {16}, {17}, {18}, {19}, '{20}', {21}, '{22}', {23}, {24}, '{25}', '{26}')",
                    camno,
                    camname,
                    userid,
                    pwd,
                    ipaddr,
                    portno,
                    url,
                    isptz,
                    resx,
                    resy,
                    codecid,
                    model,
                    modelindex,
                    destsvrip,
                    destport,
                    destch,
                    audioon,
                    fps,
                    bps,
                    protocol,
                    subch,
                    transportmode,
                    description,
                    areano,
                    areacamno,
                    datacollection,
                    collectionkind),

                string.Format("Insert into camera values (" +
                    "{0}, '{1}', '{2}', '{3}', '{4}', {5}, '{6}', {7}, '{8}', '{9}', {10}, '{11}', {12}, '{13}', " +
                    "{14}, '{15}', {16}, {17}, {18}, {19}, '{20}', {21}, '{22}', {23}, {24}, '{25}', '{26}')",
                    subch,
                    camname,
                    userid,
                    pwd,
                    ipaddr,
                    portno,
                    url,
                    isptz,
                    resx,
                    resy,
                    codecid,
                    model,
                    modelindex,
                    destsvrip,
                    destport,
                    destch,
                    audioon,
                    fps,
                    bps,
                    protocol,
                    0,
                    transportmode,
                    description,
                    areano,
                    areacamno,
                    datacollection,
                    collectionkind),

                string.Format("SELECT cg.* FROM cameragroup cg, (SELECT * FROM stationinfo WHERE NO = {0}) st WHERE cg.cameragroupname = st.city", areano),
            };

            return querylist;
        }

        public string[] UpdateQuery()
        {
            string[] querylist = new string[]
            {
                string.Format("Update camera set " +
                "camname='{0}', userid='{1}', pwd='{2}', ipaddr='{3}', portno='{4}', url='{5}', isptz='{6}', resx='{7}', " +
                "resy='{8}', codecid='{9}', model='{10}', modelindex='{11}', destsvrip='{12}', destport='{13}', destch='{14}', " +
                "audioon='{15}', fps='{16}', bps='{17}', protocol='{18}', subch='{19}', transportmode='{20}', description='{21}', " +
                "areano='{22}', areacamno='{23}', datacollection='{24}', collectionkind='{25}' where camno='{26}'",
                    camname,
                    userid,
                    pwd,
                    ipaddr,
                    portno,
                    mainrtsp,
                    isptz,
                    resx,
                    resy,
                    codecid,
                    model,
                    modelindex,
                    destsvrip,
                    destport,
                    destch,
                    audioon,
                    fps,
                    bps,
                    protocol,
                    subch,
                    transportmode,
                    description,
                    areano ,
                    areacamno,
                    datacollection,
                    collectionkind,
                    camno),

                string.Format("Update camera set " +
                "camname='{0}', userid='{1}', pwd='{2}', ipaddr='{3}', portno='{4}', url='{5}', isptz='{6}', resx='{7}', " +
                "resy='{8}', codecid='{9}', model='{10}', modelindex='{11}', destsvrip='{12}', destport='{13}', destch='{14}', " +
                "audioon='{15}', fps='{16}', bps='{17}', protocol='{18}', subch='{19}', transportmode='{20}', description='{21}', " +
                "areano='{22}', areacamno='{23}', datacollection='{24}', collectionkind='{25}' where camno='{26}'",
                    camname,
                    userid,
                    pwd,
                    ipaddr,
                    portno,
                    subrtsp,
                    isptz,
                    resx,
                    resy,
                    codecid,
                    model,
                    modelindex,
                    destsvrip,
                    destport,
                    destch,
                    audioon,
                    fps,
                    bps,
                    protocol,
                    0,
                    transportmode,
                    description,
                    areano ,
                    areacamno,
                    "N",
                    "",
                    subch),

                string.Format("Update tb_aicamera_info set " +
                "ai_user_id='{0}', ai_user_pw='{1}' where cam_no='{2}'",
                    userid,
                    pwd,
                    camno),
            };

            return querylist;
        }

        public string[] DeleteQueryList()
        {
            string[] querylist = new string[]
            {
                string.Format("Delete from tb_aicamera_info where Cam_No = {0}", camno),
                string.Format("Delete from camera where camno = {0} OR subch = {0}", camno),
                string.Format("Delete from cameragroupcamera where camerano = {0}", camno),
                string.Format("Delete from dashboarddata where sensorsot = 0 AND sensorno = {0}", camno),
                string.Format("UPDATE screencamera SET camerano = 0 WHERE camerano = {0}", camno),
                string.Format("UPDATE cameraalarmoperation SET maincamerano = 0 WHERE  maincamerano = {0};", camno),
                string.Format("UPDATE cameraalarmoperation SET subcamerano = 0 WHERE  subcamerano = {0};", camno),
            };

            return querylist;
        }
    }

    public class CameraDBList : BaseDBListByOC<CameraDBModel>
    {
        public CameraDBList() : base()
        {

        }

        public CameraDBList(CameraDBList cameradblist) : base()
        {
            foreach (var model in cameradblist)
            {
                this.Add(model);
            }
        }

        public CameraDBList(List<CameraDBModel> cameradblist) : base()
        {
            foreach (var model in cameradblist)
            {
                this.Add(model);
            }
        }

        public string SelectAllQuery()
        {
            return "SELECT * FROM camera";
        }

        public void SelectAllDSParsing()
        {
            this.Clear();

            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                CameraDBModel model = new CameraDBModel();
                Assign(dr, model);
                model.CopyOriginToUI();

                this.Add(model);
            }

            dataset.Clear();
        }

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

        public CameraDBModel GetByCamno(int camno)
        {
            return this.FirstOrDefault(a => a.camno == camno);
        }
    }
}
