using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CL.Common;
using CL.BLL;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace CL.AffSSNManage.Win.HttpDataRequest
{
    public class SSNRequest : BaseSSNRequest
    {
        /// <summary>
        /// 连接的网址
        /// </summary>
        public override string URLString
        {
            get
            {
                //return "http://www.haoweichi.com";
                return "http://www.haoweichi.com/Others/ying_guo_shen_fen_sheng_cheng";
                //OnAfterSaveSSNEvent(
            }
        } 


        /// <summary>
        /// 根据html 获得SSN model对象
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        protected override CL.Model.SSN GetSSNByHTML(string html)
        {
            if(html.Length == 0)
            {
                return null;
            }
            Model.SSN model = new Model.SSN();

            //截取有用的字符串
            int startIndex = html.IndexOf("<span id='");
            int endIndex = html.IndexOf("</div></div><div class=\"row no-margin no-padding\">");
            int subLength = endIndex - startIndex;

            html = html.Substring(startIndex, subLength);
            //替换所有的空格
            html = html.Replace("&nbsp;", " ");

            //html = HTMLStringHandler.StripHTML(html);

            //ReflectHelper.InvokeMethodOrGetProperty(model.GetType(), 
            //System.Reflection.Assembly.

            //获取所有的属性 集合
            var properties = TypeDescriptor.GetProperties(model);

            //每一个属性的处理
            foreach (PropertyDescriptor des in properties)
            {
                //找到属性对应的名称，将前面的字符串去掉
                int tempStartIndex = html.IndexOf(des.Name);
                if (tempStartIndex < 0)
                {
                    continue;
                }
                string tempStr = html.Substring(tempStartIndex);
                //匹配最近的内容，如果有，则进行数据处理，放到属性值中
                var m = Regex.Match(tempStr, "<input type=\"text\" value=(('.*' )|(\".*\" ))");
                if (m.Success)
                {
                    int s = m.Value.IndexOf("value=");
                    string val = m.Value.Substring(s + 7, m.Value.Length - 9 - s).Replace("&quot;", "''");
                    des.SetValue(model, val);
                }
            }

            return model;
        }

        /// <summary>
        /// 当前网站的地理信息
        /// </summary>
        public override List<KeyValuePair<string, string>> GeoCategoryList
        {
            get 
            { 
                List<KeyValuePair<string, string>> geoCategoryList = new List<KeyValuePair<string, string>>();
                geoCategoryList.Add(
                    new KeyValuePair<string, string>(EnumGEO.US.ToString(), "http://www.haoweichi.com")
                    );
                geoCategoryList.Add(
                    new KeyValuePair<string, string>(EnumGEO.UK.ToString(), "http://www.haoweichi.com/Others/ying_guo_shen_fen_sheng_cheng")
                    );

                return geoCategoryList;
            }
        }
    }
}
