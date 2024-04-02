using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;


namespace bmwssq
{
    public partial class frmMain : Form
    {
        Search sh = new Search();
        private bool _isSearch = false;//是否搜索
        private string _condition = "多个条件用＂|＂隔开"; //默认的文本
        private string _urlSrting;//网页url
        private string _myCookie;//cookie
        private string _urlEncode;//转码后的url

        /// <summary>
        /// 转码后的url
        /// </summary>
        public string UrlEncode
        {
            get { return _urlEncode; }
            set { _urlEncode = value; }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        #region 各模块设置

        /// <summary>
        /// load调用
        /// </summary>
        private void setLoad()
        {
            MyRegistry reg = new MyRegistry();
            txtRegistryASCII.Text = reg.GetMachineCode();
            setSnik();
            setMain();
            setLink();
            setEmail();
            setTel();
            setMuSearch();
            gbEmail.Enabled = false;
            gbTel.Enabled = false;
            lswEmailResult.Visible = false;
            lswTelResult.Visible = false;
            ckbInNext.Enabled = false;
            ckbIsNotSoft.Visible = false;
            if (MyRegCode.IsReg)
            {
                lblsspRegText.Text = "注册用户："+MyRegCode.RegName+"  注册邮箱："+MyRegCode.Email+"  注册时间："+MyRegCode.RegDate;
            }
        }

        /// <summary>
        /// 设置皮肤
        /// </summary>
        private void setSnik()
        {
            switch (MyRegCode.SnikID)//判断当前的id，设置皮肤
            {
                case "0":
                    btnChangeSnik.PerformClick();
                    break;
                case "1":
                    mnuSnik1.PerformClick();
                    break;
                case "2":
                    mnuSnik2.PerformClick();
                    break;
                case "3":
                    mnuSnik3.PerformClick();
                    break;
                case "4":
                    mnuSnik4.PerformClick();
                    break;
                case "5":
                    mnuSnik5.PerformClick();
                    break;
            }
        }

        /// <summary>
        /// 设置主窗体
        /// </summary>
        private void setMain()
        {
            btnGoBack.Enabled = false;
            btnGoFront.Enabled = false;
            txtAddress.Text = MyRegCode.WebIndex;
            string url = txtAddress.Text;
            this.wbIndex.Navigate(url);
        }

        /// <summary>
        /// 设置连接部分
        /// </summary>
        private void setLink()
        {
            txtSearchLinkHead.Text = "http://";
            txtSearchLinkPage1.Text = "1";
            txtSearchLinkPage2.Text = "100";
            txtSearchLinkEnd.Text = "";
            if (!ckbInNext.Checked)
            {
                txtWebPageNext.Enabled = false;
            }
        }

        /// <summary>
        /// 设置Email部分
        /// </summary>
        private void setEmail()
        {
            txtEmailKey.Text = _condition;
            txtEmailKey.Enabled = false;
            txtEmailNotIn.Text = _condition;
            txtEmailNotIn.Enabled = false;
            txtEmailSign1.Text = "@";
            txtEmailSign2.Text = ".";
            rbtnEmailKey.Checked = false;
            rbtnFiltrate.Checked = false;
        }

        /// <summary>
        /// 设置电话部分
        /// </summary>
        private void setTel()
        {
            ckbSearchHomeTel.Checked = false;
            ckbSearchMtel.Checked = true;
            ckbSearchInBaidu.Checked = false;
            if (ckbEmailOk.Checked)
            {
                ckbSearchInBaidu.Enabled = false;
            }
            txtSearchBaiduPage.Enabled = false;
            txtTelQuHao.Text = _condition;
            txtSearchBaiduPage.Text = "1";
            txtTelQuHao.Enabled = false;
            txtTelHaoDuan.Text = _condition;
            txtTelHaoDuan.Enabled = true;
            txtTelBaidu.Text = "";
            txtTelBaidu.Enabled = false;

        }

        /// <summary>
        /// 设置多层搜索
        /// </summary>
        private void setMuSearch()
        {
            ckb3ceng.Checked = false;
            ckb4ceng.Checked = false;
            txt3ceng.Text = "";
            txt4ceng.Text = "";
            ckbMultilayerSearch.Checked = false;
            ckbMultilayerSearch.Visible = false;
            palVisible.Visible = false;
        }

        /// <summary>
        /// 开始搜索
        /// </summary>
        private void beginSearch()
        {
            _isSearch = true;
            ckbEmailOk.Enabled = false;
            ckbSearchTelOk.Enabled = false;
            ckbInNext.Enabled = false;
            btnSearchBegin.Enabled = false;
        }
   
        /// <summary>
        /// 搜索结束
        /// </summary>
        private void endSearch()
        {
            _isSearch = false;
            ckbEmailOk.Enabled = true;
            ckbSearchTelOk.Enabled = true;
            if (!ckbSearchInBaidu.Checked&&ckbSearchTelOk.Checked||ckbEmailOk.Checked)
            {
                ckbInNext.Enabled = true;
            }
            btnSearchBegin.Enabled = true;
            resultOut();
        }

        #endregion

        #region 窗体的事件代码：窗体网页相关

        private void frmMain_Load(object sender, EventArgs e) //程序加载
        {
            this.setLoad();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)//窗体关闭程序
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)//关闭窗体时保存xml
        {
            XMLOperate xo = new XMLOperate();
            xo.xmlSaveConfig();
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e) //地址栏回车打开
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOpen.PerformClick();
            }
        }

        private void txtSearchLinkHead_Enter(object sender, EventArgs e) //文本框获得焦点
        {
            txtSearchLinkHead.SelectionStart = txtSearchLinkHead.Text.Length;
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e) //退出程序设置
        {
            if (tabMain.SelectedIndex == 3)
            {

                DialogResult dr = MessageBox.Show("您确定退出吗?", "提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    Application.Exit();
                  }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e) //打开网站
        {
            string url = this.txtAddress.Text;
            this.wbIndex.Navigate(url);
        }

        private void wbIndex_Navigating(object sender, WebBrowserNavigatingEventArgs e)//页面加载前
        {
            this.btnGoBack.Enabled = false;
            this.btnGoFront.Enabled = false;
        }

        private void wbIndex_Navigated(object sender, WebBrowserNavigatedEventArgs e) //更新地址栏url
        {
            this.txtAddress.Text = this.wbIndex.Url.ToString();
        }

        private void btnSetIndex_Click(object sender, EventArgs e)//设置主页
        {
            if (!MyRegCode.IsReg)
            {
                MessageBox.Show("非注册版本，此功能不可用！\r\n注册后功能无限！",
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            MyRegCode.WebIndex = txtAddress.Text;
            MessageBox.Show("您已将\r\n"+MyRegCode.WebIndex+"\r\n设为主页，下次使用将生效！",
                "设置成功",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }

        private void btnGoBack_Click(object sender, EventArgs e)//后退
        {
            if (!MyRegCode.IsReg)
            {
                MessageBox.Show("非注册版本，此功能不可用！\r\n注册后功能无限！",
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            wbIndex.GoBack();
        }

        private void btnGoFront_Click(object sender, EventArgs e)//前进
        {
            if (!MyRegCode.IsReg)
            {
                MessageBox.Show("非注册版本，此功能不可用！\r\n注册后功能无限！",
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            wbIndex.GoForward();

        }

        private void wbIndex_NewWindow(object sender, CancelEventArgs e)//打开新窗口
        {
            string NewURL = ((WebBrowser)sender).StatusText;
            wbIndex.Navigate(NewURL);
            //e.Cancel = true;
        }
        private void wbIndex_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) //网页加载结束后运行
        {
            btnGoBack.Enabled = wbIndex.CanGoBack;
            btnGoFront.Enabled = wbIndex.CanGoForward;
        }

        private void frmMain_Resize(object sender, EventArgs e) //调整窗体大小时的设置
        {
            if (ckbEmailOk.Checked && !ckbSearchTelOk.Checked)
            {
                lswEmailResult.Width = palResultpanel.Width;
            }
            else if (!ckbEmailOk.Checked && ckbSearchTelOk.Checked)
            {
                lswTelResult.Width = palResultpanel.Width;
            }
            else if (ckbSearchTelOk.Checked && ckbEmailOk.Checked)
            {
                lswEmailResult.Width = palResultpanel.Width / 2;
                lswTelResult.Width = palResultpanel.Width / 2;
            }
        }

        private void btnZhuce_Click(object sender, EventArgs e)//软件注册
        {
            if (txtZhuce.Text == "" || txtZhuce.Text.Length != 24)
            {
                MessageBox.Show("请填写正确的注册码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("注册完毕，软件重启后生效！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }


        }
 
        #endregion

        #region 窗体的事件代码：搜索相关

        private void ckbInNext_CheckedChanged(object sender, EventArgs e) //是否底层搜索
        {
            if (ckbInNext.Checked)
            {
                txtWebPageNext.Enabled = true;
                ckbMultilayerSearch.Visible = true;
                ckbIsNotSoft.Visible = true;
            }
            else
            {
                txtWebPageNext.Enabled = false;
                ckbIsNotSoft.Visible = false;
                setMuSearch();
            }
        }

        private void ckbMultilayerSearch_CheckedChanged(object sender, EventArgs e) //使用多层搜索
        {
            
            if (ckbMultilayerSearch.Checked)
            {
                if (!MyRegCode.IsReg)
                {
                    MessageBox.Show("非注册版本，此功能不可用！\r\n注册后功能无限！",
                        "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ckbMultilayerSearch.Checked = false;
                    return;
                }
                palVisible.Visible = true;
                ckbIsNotSoft.Visible = false;
            }
            else
            {
                palVisible.Visible = false;
                ckbIsNotSoft.Visible = true;
            }
        }

        private void txtEmailKey_MouseDown(object sender, MouseEventArgs e)//Email关键字设置
        {
            txtEmailKey.SelectAll();
        }

        private void txtEmailNotIn_MouseDown(object sender, MouseEventArgs e)//Email筛选设置
        {
            txtEmailNotIn.SelectAll();
        }

        private void txtSearchBaiduPage_MouseDown(object sender, MouseEventArgs e)//百度搜索页设置
        {
            txtSearchBaiduPage.Text = "";
        }

        private void txtTelBaidu_MouseDown(object sender, MouseEventArgs e)//百度搜索关键字设置
        {
            txtTelBaidu.SelectAll();
        }

        private void txtTelHaoDuan_MouseDown(object sender, MouseEventArgs e)//手机号段设置
        {
            txtTelHaoDuan.SelectAll();
        }

        private void txtTelQuHao_MouseDown(object sender, MouseEventArgs e)//固话区号设置
        {
            txtTelQuHao.SelectAll();
        }

        private void txtSearchLinkPage1_MouseDown(object sender, MouseEventArgs e)//设置链接开始页码
        {
            txtSearchLinkPage1.Text = "";
        }

        private void txtSearchLinkPage2_MouseDown(object sender, MouseEventArgs e)//设置链接结束页码
        {
            txtSearchLinkPage2.Text = "";
        }

        private void ckbSearchInBaidu_CheckedChanged(object sender, EventArgs e) //是否在百度搜索
        {
            if (ckbSearchInBaidu.Checked)
            {
                ckbInNext.Checked = false;
                ckbInNext.Enabled = false;
                txtTelBaidu.Enabled = true;
                txtSearchBaiduPage.Enabled = true;
            }
            else
            {
                ckbInNext.Enabled = true;
                txtTelBaidu.Enabled = false;
                txtSearchBaiduPage.Enabled = false;
            }
        }

        private void ckbEmailOk_CheckedChanged(object sender, EventArgs e) //是否搜索Email
        {

            if (ckbEmailOk.Checked)
            {
                gbEmail.Enabled = true;
                ckbSearchInBaidu.Checked = false;
                ckbSearchInBaidu.Enabled = false;
                if (ckbSearchTelOk.Checked)
                {
                    lswEmailResult.Visible = true;
                    lswEmailResult.Width = palResultpanel.Width / 2;
                    lswTelResult.Width = palResultpanel.Width / 2;

                }
                else
                {
                    ckbInNext.Enabled = true;
                    lswEmailResult.Visible = true;
                    lswEmailResult.Width = palResultpanel.Width;
                }
            }
            else
            {
                if (!ckbSearchTelOk.Checked)
                {
                    ckbInNext.Enabled = false;
                    ckbInNext.Checked = false;
                }
                else
                {
                    ckbSearchInBaidu.Enabled = true;
                }
                setEmail();
                gbEmail.Enabled = false;
                lswEmailResult.Visible = false;
                lswTelResult.Width = palResultpanel.Width;
            }
        }

        private void ckbSearchTelOk_CheckedChanged(object sender, EventArgs e) //是否搜索电话
        {

            if (ckbSearchTelOk.Checked)
            {
                gbTel.Enabled = true;
                ckbSearchMtel.Checked = true;
                if (ckbEmailOk.Checked)
                {
                    lswTelResult.Visible = true;
                    lswEmailResult.Width = palResultpanel.Width / 2;
                    lswTelResult.Width = palResultpanel.Width / 2;
                }
                else
                {
                    ckbSearchInBaidu.Enabled = true;
                    ckbInNext.Enabled = true;
                    lswTelResult.Visible = true;
                    lswTelResult.Width = palResultpanel.Width;
                }
            }
            else
            {
                if (!ckbEmailOk.Checked)
                {
                    ckbInNext.Enabled = false;
                    ckbInNext.Checked = false;
                }
                setTel();
                gbTel.Enabled = false;
                lswTelResult.Visible = false;
                lswEmailResult.Width = palResultpanel.Width;
            }
        }

        private void rbtnEmailKey_CheckedChanged(object sender, EventArgs e) //是否使用Email关键字
        {
            if (rbtnEmailKey.Checked)
            {
                txtEmailKey.Enabled = true;
            }
            else
            {
                txtEmailKey.Text = _condition;
                txtEmailKey.Enabled = false;
            }
        }

        private void rbtnFiltrate_CheckedChanged(object sender, EventArgs e) //是否过滤Email关键字
        {
            if (rbtnFiltrate.Checked)
            {
                txtEmailNotIn.Enabled = true;
            }
            else
            {
                txtEmailNotIn.Text = _condition;
                txtEmailNotIn.Enabled = false;
            }
        }

        private void ckbSearchMtel_CheckedChanged(object sender, EventArgs e) //是否搜索手机
        {
            if (ckbSearchMtel.Checked)
            {
                txtTelHaoDuan.Enabled = true;
            }
            else
            {
                txtTelHaoDuan.Text = _condition;
                txtTelHaoDuan.Enabled = false;
            }
        }

        private void ckbSearchHomeTel_CheckedChanged(object sender, EventArgs e) //是否搜索固话
        {
            if (ckbSearchHomeTel.Checked)
            {
                txtTelQuHao.Enabled = true;
            }
            else
            {
                txtTelQuHao.Text = _condition;
                txtTelQuHao.Enabled = false;
            }
        }
        
        private void btnEmailClean_Click(object sender, EventArgs e) //重置Email选项
        {
            setEmail();
        }

        private void btnTelClean_Click(object sender, EventArgs e) //重置tel选项
        {
            setTel();
        }

        private void btnSearchLinkOk_Click(object sender, EventArgs e) //添加搜索的url
        {
            ListViewItem item = new ListViewItem();
            item.SubItems[0].Text = txtSearchLinkHead.Text;
            item.SubItems.Add(txtSearchLinkPage1.Text);
            item.SubItems.Add(txtSearchLinkPage2.Text);
            item.SubItems.Add(txtSearchLinkEnd.Text);
            lswSearchLinkView.Items.Add(item);
            setLink();
        }

        private void btnDelectLink_Click(object sender, EventArgs e) //删除所选的链接
        {
            if (lswSearchLinkView.Items.Count > 0)
            {
                for (int i = this.lswSearchLinkView.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem item = this.lswSearchLinkView.SelectedItems[i];
                    this.lswSearchLinkView.Items.Remove(item);
                }
            }
        }

        private void btnSetDcssOK_Click(object sender, EventArgs e) //多层搜索设置完成
        {
            palVisible.Visible = false;
            ckbMultilayerSearch.Enabled = true;
        }

        private void btnSearchStop_Click(object sender, EventArgs e) //停止搜索进程
        {
            _isSearch = false;
        }

        private void btnSearchBegin_Click(object sender, EventArgs e) //开始搜索
        {
            beginSearch();
            _myCookie = sh.GetCookie(wbIndex);
            setAndSearch();
            endSearch();
        }

        private void btnGuolv_Click(object sender, EventArgs e) //进行筛选
        {
            ArrayList al;

            if (lswEmailResult.Items.Count < 1 && lswTelResult.Items.Count < 1)
            {
                MessageBox.Show("请先进行搜索再进行筛选！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (lswEmailResult.Items.Count > 0)
                {
                    
                    al = new ArrayList();
                    foreach (ListViewItem item in lswEmailResult.Items)
                    {
                        al.Add(item.SubItems[0].Text);
                    }
                    lswEmailResult.Clear();
                    lswEmailResult.Columns.Insert(0, "Email地址", 150, HorizontalAlignment.Center);

                    for (int i = 0; i < al.Count; i++)
                    {
                        bool flag = true;
                        if (lswEmailResult.Items.Count < 1)
                        {
                            ListViewItem item = new ListViewItem();
                            item.SubItems[0].Text = al[i].ToString();
                            lswEmailResult.Items.Add(item);
                        }
                        else
                        {
                            foreach (ListViewItem item in lswEmailResult.Items)
                            {
                                if (item.SubItems[0].Text.Equals(al[i].ToString()))
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                ListViewItem item = new ListViewItem();
                                item.SubItems[0].Text = al[i].ToString();
                                lswEmailResult.Items.Add(item);
                            }
 
                        }
                    }
                }
                if (lswTelResult.Items.Count > 0)
                {
                    
                    al = new ArrayList();
                    foreach (ListViewItem item in lswTelResult.Items)
                    {
                        al.Add(item.SubItems[0].Text);
                    }
                    lswTelResult.Clear();
                    lswTelResult.Columns.Insert(0, "电话号码", 150, HorizontalAlignment.Center);

                    for (int i = 0; i < al.Count; i++)
                    {
                        bool flag = true;
                        if (lswTelResult.Items.Count < 1)
                        {
                            ListViewItem item = new ListViewItem();
                            item.SubItems[0].Text = al[i].ToString();
                            lswTelResult.Items.Add(item);
                        }
                        else
                        {
                            foreach (ListViewItem item in lswTelResult.Items)
                            {
                                if (item.SubItems[0].Text.Equals(al[i].ToString()))
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                ListViewItem item = new ListViewItem();
                                item.SubItems[0].Text = al[i].ToString();
                                lswTelResult.Items.Add(item);
                            }

                        }
                    }
                }
                MessageBox.Show("筛选完毕！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnResuleOut_Click(object sender, EventArgs e) //导出Email
        {
            if (!MyRegCode.IsReg)
            {
                MessageBox.Show("非注册版本，此功能不可用！\r\n注册后功能无限！",
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            resultOut(lswEmailResult);
        }

        private void btnTelResultOut_Click(object sender, EventArgs e) //导出tel文本
        {
            if (!MyRegCode.IsReg)
            {
                MessageBox.Show("非注册版本，此功能不可用！\r\n注册后功能无限！",
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            resultOut(lswTelResult);
        }

        private void btnSearchLinkIn_Click(object sender, EventArgs e) //导入网页url文件
        {
            if (!MyRegCode.IsReg)
            {
                MessageBox.Show("非注册版本，此功能不可用！\r\n注册后功能无限！",
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            btnSearchLinkClean.PerformClick();
            for (int i = 0; i < lswSearchLinkView.Items.Count; i++)
            {
                lswSearchLinkView.Items.RemoveAt(0);
            }
            openFileDialog1.Filter = "(文本文档)*.txt|";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = this.openFileDialog1.FileName;
                if (path != "")
                {
                    sh.ReadResultFromTxt(lswSearchLinkView, path);
                }
            }
        }

        private void btnSearchLinkClean_Click(object sender, EventArgs e) //清空搜索url项
        {
            while (lswSearchLinkView.Items.Count > 0)
            {
                lswSearchLinkView.Items.RemoveAt(0);
            }
        }

        private void btnResultClean_Click(object sender, EventArgs e) //清空结果集显示
        {
            lswEmailResult.Clear();
            lswEmailResult.Columns.Insert(0, "Email地址", 150, HorizontalAlignment.Center);
            lswEmailResult.Columns.Insert(1, "搜索网址", 450, HorizontalAlignment.Center);
            lswTelResult.Clear();
            lswTelResult.Columns.Insert(0, "电话号码", 150, HorizontalAlignment.Center);
            lswTelResult.Columns.Insert(1, "搜索网址", 450, HorizontalAlignment.Center);
        }


        #endregion

        #region 自定义函数

        /// <summary>
        /// 结果导出TXT
        /// </summary>
        private void resultOut()
        {
            if (lswEmailResult.Items.Count > 0)
            {
                sh.WriteResultToTxt(lswEmailResult, "Email");
            }
            if (lswTelResult.Items.Count > 0)
            {
                sh.WriteResultToTxt(lswTelResult, "Tel");
            }
        }

        /// <summary>
        /// 设置搜索
        /// </summary>
        private void setAndSearch()
        {
            try
            {
                if (ckbSearchInBaidu.Checked)
                {
                    searchInBaidu();
                }              
                else
                {
                    if (_myCookie == null)
                    {
                        MessageBox.Show("网络问题，请检查登陆设置！",
                                           "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (lswSearchLinkView.Items.Count > 0)
                    {
                        if (ckbInNext.Checked)
                        {
                            if (ckb3ceng.Checked)
                            {
                                searchNext2();
                            }
                            else
                            { 
                                searchNext();
                            }
                        }
                        else
                        {
                            setUrlStringAndSearch();
                        }
                    }
                    else
                    {
                        MessageBox.Show("请先设置网页链接项！","提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }

        /// <summary>
        /// 在百度搜索
        /// </summary>
        private void searchInBaidu()
        {
            ckbInNext.Checked = false;
            int page = Convert.ToInt32(txtSearchBaiduPage.Text) * 10;
            for (int i = 0; i < page; i = i + 10)
            {
                if (!_isSearch)
                {
                    break;
                }
                _urlSrting = @"http://www.baidu.com/s?lm=0&si=&rn=10&ie=gb2312&ct=0&wd="
                    + txtTelBaidu.Text + @"&pn=" + i.ToString() + @"&ver=0&cl=3";
                UrlEncode = sh.GetUrlEncode(_urlSrting);

                string regexTel = getRegexTel();
                string urlText = sh.GetUrlText(UrlEncode);
                if (!MyRegCode.IsReg && lswTelResult.Items.Count >= 50)
                {

                    MessageBox.Show("非注册版本，只能搜索50条！\r\n注册后功能无限！",
                            "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }
                else
                {
                    ArrayList srs = sh.FindString(urlText, regexTel);
                    sh.WriteResult(srs, lswTelResult, UrlEncode);
                    sh.WriteResultToTxt(lswTelResult, "Tel");
                }
            }
        }

        /// <summary>
        /// 深层搜索
        /// </summary>
        private void searchNext()
        {
            ArrayList al = null;

            #region 关键页为空
            if (txtWebPageNext.Text == "")
            {
                _isSearch = false;
                MessageBox.Show("请输入关键页参数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            #endregion
            else
            {
                string urlHead = "";
                string urlGuanjian = "";
                urlHead = sh.SubUrlHead(txtWebPageNext.Text);
                urlGuanjian = sh.SubUrlRegexStr(txtWebPageNext.Text);


                for (int i = 0; i < lswSearchLinkView.Items.Count; i++)
                {
                    if (!_isSearch)
                    {
                        break;
                    }
                    string urlStrHead = lswSearchLinkView.Items[i].SubItems[0].Text;
                    #region 开始页不为空
                    if (lswSearchLinkView.Items[i].SubItems[1].Text != "")//如果开始页不为空
                    {
                        int sign1 = Convert.ToInt32(lswSearchLinkView.Items[i].SubItems[1].Text);
                        if (lswSearchLinkView.Items[i].SubItems[2].Text != "")
                        {
                            int sign2 = Convert.ToInt32(lswSearchLinkView.Items[i].SubItems[2].Text);
                            string urlStrEnd = lswSearchLinkView.Items[i].SubItems[3].Text;
                            for (int j = sign1; j <= sign2; j++)
                            {
                                if (!_isSearch)
                                {
                                    break;
                                }
                                _urlSrting = urlStrHead + j.ToString() + urlStrEnd;//设置搜索url

                                UrlEncode = sh.GetUrlEncode(_urlSrting);

                                string urlText = sh.GetUrlText(UrlEncode, _myCookie);//得到网页源码
                                al = sh.IsInNextSearch(urlText, urlGuanjian);//得到下级url

                                for (int k = 0; k < al.Count; k++)//循环搜索
                                {
                                    try
                                    {
                                        if (!_isSearch)
                                        {
                                            break;
                                        }
                                        if (this.ckbIsNotSoft.Checked)
                                        {
                                            _urlSrting = al[k].ToString();
                                        }
                                        else
                                        {
                                            _urlSrting = urlHead + al[k].ToString();
                                        }
                                        UrlEncode = sh.GetUrlEncode(_urlSrting);
                                        string urlText1 = sh.GetUrlText(UrlEncode, _myCookie);
                                        searchMain(urlText1);
                                        Thread.Sleep(20);
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("请设置结束页码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    #endregion
                    #region 开始页为空
                    else
                    {
                        UrlEncode = sh.GetUrlEncode(urlStrHead);
                        string urlText = sh.GetUrlText(UrlEncode, _myCookie);//得到网页源码
                        al = sh.IsInNextSearch(urlText, urlGuanjian);//得到下级url

                        for (int k = 0; k < al.Count; k++)//循环搜索
                        {
                            try
                            {
                                if (!_isSearch)
                                {
                                    break;
                                }
                                if (this.ckbIsNotSoft.Checked)
                                {
                                    _urlSrting = al[k].ToString();
                                }
                                else
                                {
                                    _urlSrting = urlHead + al[k].ToString();
                                }
                                UrlEncode = sh.GetUrlEncode(_urlSrting);
                                string urlText1 = sh.GetUrlText(UrlEncode, _myCookie);
                                searchMain(urlText1);
                                Thread.Sleep(20);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                    }
                    #endregion
                }
            }
        }

        /// <summary>
        /// 三层搜索
        /// </summary>
        private void searchNext2()
        {
            ArrayList al = null;//存查到的下级
            ArrayList al1 = null;//下级的下级

            if (txtWebPageNext.Text == "")
            {
                _isSearch = false;
                MessageBox.Show("请输入关键页参数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string urlHead = "";//二层的地址
                string urlGuanjian = "";
                urlHead = sh.SubUrlHead(txtWebPageNext.Text);
                urlGuanjian = sh.SubUrlRegexStr(txtWebPageNext.Text);
                string urlHead1 = "";//三层的地址
                string urlGuanjian1 = "";
                urlHead1 = sh.SubUrlHead(this.txt3ceng.Text);
                urlGuanjian1 = sh.SubUrlRegexStr(txt3ceng.Text);


                for (int i = 0; i < lswSearchLinkView.Items.Count; i++)
                {
                    if (!_isSearch)
                    {
                        break;
                    }
                    string urlStrHead = lswSearchLinkView.Items[i].SubItems[0].Text;
                    if (lswSearchLinkView.Items[i].SubItems[1].Text != "")//如果开始页不为空
                    {
                        int sign1 = Convert.ToInt32(lswSearchLinkView.Items[i].SubItems[1].Text);
                        if (lswSearchLinkView.Items[i].SubItems[2].Text != "")
                        {
                            int sign2 = Convert.ToInt32(lswSearchLinkView.Items[i].SubItems[2].Text);
                            string urlStrEnd = lswSearchLinkView.Items[i].SubItems[3].Text;
                            for (int j = sign1; j <= sign2; j++)
                            {
                                if (!_isSearch)
                                {
                                    break;
                                }
                                _urlSrting = urlStrHead + j.ToString() + urlStrEnd;//设置搜索url

                                UrlEncode = sh.GetUrlEncode(_urlSrting);

                                string urlText = sh.GetUrlText(UrlEncode, _myCookie);//得到网页源码
                                al = sh.IsInNextSearch(urlText, urlGuanjian);//得到下级url

                                for (int k = 0; k < al.Count; k++)//循环搜索
                                {
                                    try
                                    {
                                        if (!_isSearch)
                                        {
                                            break;
                                        }
                                        _urlSrting = urlHead + al[k].ToString();
                                        UrlEncode = sh.GetUrlEncode(_urlSrting);
                                        string urlText1 = sh.GetUrlText(UrlEncode, _myCookie);

                                        al1 = sh.IsInNextSearch(urlText1, urlGuanjian1);//得到下级url

                                        for (int l = 0; l < al.Count; l++)//循环搜索
                                        {
                                            try
                                            {
                                                if (!_isSearch)
                                                {
                                                    break;
                                                }
                                                _urlSrting = urlHead1 + al1[l].ToString();
                                                UrlEncode = sh.GetUrlEncode(_urlSrting);
                                                string urlText2 = sh.GetUrlText(UrlEncode, _myCookie);
                                                searchMain(urlText2);
                                                Thread.Sleep(20);
                                            }
                                            catch (Exception)
                                            {
                                                continue;
                                            }
                                        }
                                        Thread.Sleep(20);
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("请设置结束页码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        UrlEncode = sh.GetUrlEncode(urlStrHead);
                        string urlText = sh.GetUrlText(UrlEncode, _myCookie);//得到网页源码
                        al = sh.IsInNextSearch(urlText, urlGuanjian);//得到下级url

                        for (int k = 0; k < al.Count; k++)//循环搜索
                        {
                            try
                            {
                                if (!_isSearch)
                                {
                                    break;
                                }
                                _urlSrting = urlHead + al[k].ToString();
                                UrlEncode = sh.GetUrlEncode(_urlSrting);
                                string urlText1 = sh.GetUrlText(UrlEncode, _myCookie);
                                searchMain(urlText1);
                                Thread.Sleep(20);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 设置网页url并搜索
        /// </summary>
        private void setUrlStringAndSearch()
        {
            for (int i = 0; i < lswSearchLinkView.Items.Count; i++)
            {
                if (!_isSearch)
                {
                    break;
                }

                string urlStrHead = lswSearchLinkView.Items[i].SubItems[0].Text;
                if (lswSearchLinkView.Items[i].SubItems[1].Text != "")
                {
                    int sign1 = Convert.ToInt32(lswSearchLinkView.Items[i].SubItems[1].Text);
                    if (lswSearchLinkView.Items[i].SubItems[2].Text != "")
                    {
                        int sign2 = Convert.ToInt32(lswSearchLinkView.Items[i].SubItems[2].Text);
                        string urlStrEnd = lswSearchLinkView.Items[i].SubItems[3].Text;

                        for (int j = sign1; j <= sign2; j++)
                        {
                            try
                            {
                                if (!_isSearch)
                                {
                                    break;
                                }
                                _urlSrting = urlStrHead + j.ToString() + urlStrEnd;
                                UrlEncode = sh.GetUrlEncode(_urlSrting);
                                string urlText = sh.GetUrlText(UrlEncode, _myCookie);

                                searchMain(urlText);
                            }
                            catch (Exception)
                            {
                                continue;
                            }    
                        }
                    }
                    else
                    {
                        MessageBox.Show("请设置结束页码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                else
                {
                    _urlSrting = urlStrHead;
                    UrlEncode = sh.GetUrlEncode(_urlSrting);
                    string urlText = sh.GetUrlText(UrlEncode, _myCookie);
                    searchMain(urlText);
                }
            }
        }

        /// <summary>
        /// 搜索的主代码
        /// </summary>
        private void searchMain(string urlText)
        {
            if (!MyRegCode.IsReg && (lswTelResult.Items.Count >= 50||lswEmailResult.Items.Count>=50))
            {

                MessageBox.Show("非注册版本，只能搜索50条！\r\n注册后功能无限！",
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _isSearch = false;
            }
            else
            {

                 
                
                //string urlText = sh.getUrlText(UrlEncode, _myCookie);
                string regexEmail = getRegexEmail();
                string regexTel = getRegexTel();
                if (ckbEmailOk.Checked && !ckbSearchTelOk.Checked)
                {
                    ArrayList srs = sh.FindString(urlText, regexEmail);
                    sh.WriteResult(srs, lswEmailResult, UrlEncode);
                    //sh.writeResultToTxt(lswEmailResult, "Email");
                }
                else if (!ckbEmailOk.Checked && ckbSearchTelOk.Checked)
                {
                    ArrayList srs = sh.FindString(urlText, regexTel);
                    sh.WriteResult(srs, lswTelResult, UrlEncode);
                    //sh.writeResultToTxt(lswTelResult, "Tel");
                }
                else if (ckbSearchTelOk.Checked && ckbEmailOk.Checked)
                {
                    ArrayList srs = sh.FindString(urlText, regexEmail);
                    sh.WriteResult(srs, lswEmailResult, UrlEncode);
                    //sh.writeResultToTxt(lswEmailResult, "Email");
                    ArrayList srs2 = sh.FindString(urlText, regexTel);
                    sh.WriteResult(srs2, lswTelResult, UrlEncode);
                    //sh.writeResultToTxt(lswTelResult, "Tel");
                }
                else if (!ckbSearchTelOk.Checked && !ckbEmailOk.Checked)
                {
                    MessageBox.Show("请选择要搜索的内容!");
                }
            }
        }

        /// <summary>
        /// Email的正则表达式
        /// </summary>
        /// <returns>Email的正则表达式</returns>
        private string getRegexEmail()
        {
            string reg = @"([_a-z0-9-]+)";
            string sign1 = txtEmailSign1.Text;
            string sign2 = txtEmailSign2.Text;
            string regexEmail = @"([_a-z0-9-]+)" + sign1 + reg + sign2 + @"([^\s<>'"":;&#\*\\/]+[\w])";
            if (rbtnEmailKey.Checked)
            {
                regexEmail = @"([_a-z0-9-]+)" + sign1 + @"((" + txtEmailKey.Text + @"))" + sign2 + @"([^\s<>'"":;&#\*\\/]+[\w])";

            }
            if (rbtnFiltrate.Checked)
            {
                regexEmail = @"([_a-z0-9-]+)" + sign1 + @"([^(" + this.txtEmailNotIn.Text + @")])" + sign2 + @"([^\s<>'"":;&#\*\\/]+[\w])";
            }
            return regexEmail;
        }

        /// <summary>
        /// 电话的正则表达式
        /// </summary>
        /// <returns>电话的正则表达式</returns>
        private string getRegexTel()
        {
            string regexTel = @"(1[3,5]\d{9})";
            if (!ckbSearchHomeTel.Checked && ckbSearchMtel.Checked)
            {
                if (!txtTelHaoDuan.Text.Equals(_condition))
                {
                    regexTel = @"((" + txtTelHaoDuan.Text + @")\d{8})";
                }
            }
            if (ckbSearchHomeTel.Checked && !ckbSearchMtel.Checked)
            {
                if (txtTelQuHao.Text.Equals(_condition))
                {
                    regexTel = @"(0\d{2,3}[\*,\-]?\d{7,8})";
                }
                else
                {
                    regexTel = @"((" + txtTelQuHao.Text + @"))[\*,\-]?\d{7,8})";
                }
            }

            if (ckbSearchHomeTel.Checked && ckbSearchMtel.Checked)
            {
                if (txtTelHaoDuan.Text.Equals(_condition) && txtTelQuHao.Text.Equals(_condition))
                {
                    regexTel = @"(1[3,5]\d{9})|(0\d{2,3}[\*,\-]?\d{7,8})";
                }
                else if (txtTelHaoDuan.Text.Equals(_condition) && !txtTelQuHao.Text.Equals(_condition))
                {
                    regexTel = @"((" + txtTelHaoDuan.Text + @")\d{8})|(0\d{2,3}[*,\-]?\d{7,8})";
                }
                else if (!txtTelHaoDuan.Text.Equals(_condition) && txtTelQuHao.Text.Equals(_condition))
                {
                    regexTel = @"(1[3,5]\d{9})|((" + txtTelQuHao.Text + @")[\*,\-]?\d{7,8})";
                }
                else
                {
                    regexTel = @"((" + txtTelHaoDuan.Text + @")\d{8})|((" + txtTelQuHao.Text + @")[\*,\-]?\d{7,8})";
                }
            }
            return regexTel;
        }

        /// <summary>
        /// 手动导出结果集
        /// </summary>
        /// <param name="lv">结果集</param>
        private void resultOut(ListView lv)
        {
            if (lv.Items.Count <= 0)
            {
                MessageBox.Show("请先进行搜索再导出文件！","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            string filepath = "";
            saveFileDialog1.Filter = "(文本文件)*.txt|";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.InitialDirectory = "d:\\";
            saveFileDialog1.OverwritePrompt = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                filepath = saveFileDialog1.FileName;
                StreamWriter sw = new StreamWriter(filepath);
                for (int i = 0; i < lv.Items.Count; i++)
                {
                    sw.WriteLine(lv.Items[i].SubItems[0].Text);//你想要写入的文本   
                }
                sw.Flush();
                sw.Close();
            }
        }

        #endregion

    }
}