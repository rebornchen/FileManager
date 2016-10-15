using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL.Common;
using CL.BLL;
namespace CL.AffSSNManage.Win.HttpDataRequest
{
    #region 基类
    /// <summary>
    /// SSN 请求数据的基类
    /// </summary>
    public abstract class BaseSSNRequest
    {

        /// <summary>
        /// 保存SSN 之后的事件
        /// </summary>
        public event System.EventHandler OnAfterSaveSSNEvent;

        #region public 公共属性和方法
        public abstract string URLString { get; }
        public abstract List<KeyValuePair<string, string>> GeoCategoryList { get; }

        /// <summary>
        /// 请求url
        /// </summary>
        public virtual void RequestURLAndSaveSSN()
        {
            string html = GetRequest();
            
            var model = GetSSNByHTML(html);
            if (model != null)
            {

                SSNBiz biz = new SSNBiz();

                model._Locked = false;
                model._Identify = biz.GetAll().Max(m => m._Identify) + 1;
                model._SortKey = model._Identify;

                biz.Add(model);

                //保存后触发 OnAfterSaveSSNEvent
                if (OnAfterSaveSSNEvent != null)
                {
                    OnAfterSaveSSNEvent(model, null);
                }
            }
        }
        #endregion

        #region protected method
        /// <summary>
        /// 请求数据
        /// </summary>
        /// <returns></returns>
        protected virtual string GetRequest()
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = URLString //URL     必需项
            };
            //得到HTML代码
            HttpResult result = http.GetHtml(item);
            //取出返回的Cookie
            //string cookie = result.Cookie;
            //返回的Html内容
            string html = String.Empty;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                html = result.Html;
                //表示访问成功，具体的大家就参考HttpStatusCode类
            }

            return html;
        }

        /// <summary>
        /// 根据html 获得SSN model对象
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        protected abstract Model.SSN GetSSNByHTML(string html);
      #endregion


    }
    #endregion

    /// <summary>
    /// 国家枚举
    /// </summary>
    public enum EnumGEO
    {
        US,
        UK
    }
}
