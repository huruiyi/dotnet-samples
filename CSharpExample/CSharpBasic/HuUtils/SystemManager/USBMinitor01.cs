using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Security.Permissions;
using System.Windows.Forms;

namespace HuUtils.SystemManager
{
    public partial class USBMinitor01 : Form
    {
        public USBMinitor01()
        {
            InitializeComponent();
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            DeviceEvent lEvent;

            lEvent = (DeviceEvent)m.WParam.ToInt32();
            switch (lEvent)
            {
                case DeviceEvent.DBT_DEVICEARRIVAL://[Insert]
                    this.CheckDeviceStatus_Lable.BackColor = Color.Green;
                    this.CheckDeviceStatus_Lable.Text = "----Connection Device!----";
                    MessageBox.Show("Just Insert At Moment !", "Insert");
                    break;

                case DeviceEvent.DBT_DEVICEREMOVECOMPLETE://[REmove]
                    this.CheckDeviceStatus_Lable.BackColor = Color.Red;
                    this.CheckDeviceStatus_Lable.Text = "------No Connection------";
                    MessageBox.Show("Remove Complete At Moment!", "Remove");
                    break;

                case DeviceEvent.DBT_DEVNODES_CHANGED://[Device List Have Changed]
                    MessageBox.Show("Device List have been Changed!");
                    break;

                default:
                    break;
            }
        }

        public void ControlUSBConnectionStatu()
        {
            ManagementEventWatcher getEventWatcher = null;
            WqlEventQuery getEventQuery = null;

            ManagementOperationObserver getObserver = new ManagementOperationObserver();

            //Bind to Loacl Machine and Watch the PortConnection
            ManagementScope getScope = new ManagementScope("root\\CIMV2");
            getScope.Options.EnablePrivileges = true;//set requeired

            getEventQuery = new WqlEventQuery();
            getEventQuery.EventClassName = "__InstanceOperationEvent";
            getEventQuery.WithinInterval = new TimeSpan(0, 0, 0, 1);
            getEventQuery.Condition = @"TargetInstance ISA 'Win32_DiskDrive' ";
            //[Disk must have DiskDrive fuck ]

            //Event Watcher [Test Event and semd informatio to this message and create new informtion .]
            getEventWatcher = new ManagementEventWatcher(getEventQuery);
            getEventWatcher.EventArrived += new EventArrivedEventHandler(getEventWatcher_EventArrived);
            getEventWatcher.Start();
            getEventWatcher.Stop();
        }

        private void getEventWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject getBaseObject = (ManagementBaseObject)e.NewEvent;
            if ((getBaseObject.ClassPath.ClassName == "__InstanceCreationEvent"))
            {
                //Usb Inserted
                MessageBox.Show("USB Disk Inserted!");
            }
            else
            {
                //Usb Removed
                MessageBox.Show("USB Device Removed!");
            }
        }

        /// <summary>
        /// 监听USB Device设备插拔事件 完整操作.
        /// WMI Handle Event Change Device List chenkai
        /// </summary>
        public void RegisterDeviceWMIEventStatu()
        {
            //Device List HAve Changed  And Send Message
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent");
            ManagementEventWatcher watcher = new ManagementEventWatcher(query);
            watcher.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
            watcher.Start();  // Start listening for events
        }

        private void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string geteventtype = e.NewEvent.GetPropertyValue("EventType").ToString();
            ManagementBaseObject getEventObject = (ManagementBaseObject)e.NewEvent;

            if (getEventObject != null)
            {
                //close Operator
                //  this.CloseDeviceEqument();
            }
        }

        public void ControlUSBDeviceSTatu()
        {
            WqlEventQuery query = new WqlEventQuery("select * from Win32_VolumeChangeEvent");
            ManagementEventWatcher getwatcher = new ManagementEventWatcher(query);
            getwatcher.EventArrived += new EventArrivedEventHandler(getwatcher_EventArrived);
            getwatcher.Start();
        }

        private void getwatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            MessageBox.Show(e.NewEvent.GetText(TextFormat.Mof).ToString());
        }

        //Get ALL USB DRiver And Driver Property Fuck this shit。chenkai
        public static string[] AllInformation()
        {
            StringCollection propNames = new StringCollection();
            ManagementClass driveClass = new ManagementClass("Win32_USBController");
            PropertyDataCollection props = driveClass.Properties;
            foreach (PropertyData driveProperty in props)
                propNames.Add(driveProperty.Name);
            int idx = 0;
            ManagementObjectCollection drives = driveClass.GetInstances();
            string _s = string.Empty;
            List<string> harddisk = new List<string>();

            foreach (ManagementObject drv in drives)
            {
                idx++;
                _s = string.Format(" USB Driver({0}) Properties ", idx);
                harddisk.Add(_s);
                foreach (string strProp in propNames)
                {
                    _s = string.Format("Property: {0}, Value: {1}", strProp, drv[strProp]);
                    harddisk.Add(_s);
                }
            }
            string[] _ss = harddisk.ToArray();
            return _ss;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process pro = new Process();
            pro.StartInfo.FileName = "cmd.exe";

            pro.StartInfo.UseShellExecute = false;
            pro.StartInfo.RedirectStandardInput = true;
            pro.StartInfo.RedirectStandardOutput = true;
            pro.StartInfo.RedirectStandardError = true;
            pro.StartInfo.CreateNoWindow = true;

            pro.Start();

            pro.StandardInput.WriteLine("control userpasswords2");
            pro.StandardInput.WriteLine("exit");
            string strResult = pro.StandardOutput.ReadToEnd();
            MessageBox.Show(strResult);
        }
    }

    public enum DeviceEvent : int
    {
        DBT_CONFIGCHANGECANCELED = 0x0019,
        DBT_CONFIGCHANGED = 0x0018,
        DBT_CUSTOMEVENT = 0x8006,
        DBT_DEVICEARRIVAL = 0x8000,//USB Insert DEvice Statu
        DBT_DEVICEQUERYREMOVE = 0x8001,
        DBT_DEVICEQUERYREMOVEFAILED = 0x8002,
        DBT_DEVICEREMOVEPENDING = 0x8003,//USB Revoing.
        DBT_DEVICEREMOVECOMPLETE = 0x8004,//USB Remove Completed
        DBT_DEVICETYPESPECIFIC = 0x8005,
        DBT_DEVNODES_CHANGED = 0x0007,//Device List _Changed
        DBT_QUERYCHANGECONFIG = 0x0017,
        DBT_USERDEFINED = 0xFFFF
    }
}