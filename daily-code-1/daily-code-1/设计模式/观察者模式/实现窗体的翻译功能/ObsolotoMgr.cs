using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace 实现窗体的翻译功能
{
    public delegate void DTransformor(string lang);

    /// <summary>
    /// 多语言切换观察者类
    /// </summary>
    public class ObsolotoMgr
    {
        /// <summary>
        /// 负责接收每个窗体打开以后注册一个方法到其上面
        /// </summary>
        public static event DTransformor trnsHandler;

        public static void CalltrnsHandler(string lang)
        {
            if (trnsHandler != null)
            {
                trnsHandler(lang);
            }
        }

    }
}
