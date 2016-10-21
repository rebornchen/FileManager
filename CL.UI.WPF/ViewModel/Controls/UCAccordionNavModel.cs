using CL.Model;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;

namespace CL.UI.WPF.ViewModel.Controls
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class UCAccordionNavModel : ViewModelBase
    {
        #region 私有变量
        /// <summary>
        /// Categroy 数据 bll
        /// </summary>
        private CL.BLL.CategoryBiz categoryBiz = new CL.BLL.CategoryBiz();
        #endregion

        #region 构造方法
        /// <summary>
        /// Initializes a new instance of the UCAccordionNavModel class.
        /// </summary>
        public UCAccordionNavModel()
        {
            NavItemList = InitialNavData();
        }
        #endregion

        #region 初始化导航数据
        public static List<KeyValuePair<string, List<KeyValuePair<string, object>>>> InitialNavData_Test()
        {
            List<KeyValuePair<string, List<KeyValuePair<string, object>>>> itemList = new List<KeyValuePair<string, List<KeyValuePair<string, object>>>>();
            for (int i = 0; i < 5; i++)
            {
                List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();
                for (int j = 0; j < 7; j++)
                {
                    string tempTxt = string.Format("TextB{0}", j);
                    KeyValuePair<string, object> a = new KeyValuePair<string, object>(tempTxt, tempTxt);
                    list.Add(a);

                }
                string mainTxt = string.Format("MainItem{0}", i);
                KeyValuePair<string, List<KeyValuePair<string, object>>> item =
                    new KeyValuePair<string, List<KeyValuePair<string, object>>>(mainTxt, list);
                itemList.Add(item);
            }
            return itemList;
        }

        /// <summary>
        /// 初始化导航数据
        /// </summary>
        /// <returns></returns>
        public List<KeyValuePair<string, List<KeyValuePair<string, object>>>> InitialNavData()
        {
            List<KeyValuePair<string, List<KeyValuePair<string, object>>>> itemList = new List<KeyValuePair<string, List<KeyValuePair<string, object>>>>();

            string mainTxt = "文件类型";

            List<Category> tempList = categoryBiz.GetAll();

            List<KeyValuePair<string, object>> list = (from v in tempList
                                                      select new KeyValuePair<string, object>(v.CCategoryName, (object)v.ICId)).ToList();

            KeyValuePair<string, List<KeyValuePair<string, object>>> categoryItem =
                    new KeyValuePair<string, List<KeyValuePair<string, object>>>(mainTxt, list);

            itemList.Add(categoryItem);
            return itemList;
        }
        #endregion

        #region 属性 NavItemList， 界面上导航的数据源
        /// <summary>
        /// The <see cref="NavItemList" /> property's name.
        /// </summary>
        public const string NavItemListPropertyName = "NavItemList";

        private List<KeyValuePair<string, List<KeyValuePair<string, object>>>> _navItemList = null;

        /// <summary>
        /// Sets and gets the NavItemList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<KeyValuePair<string, List<KeyValuePair<string, object>>>> NavItemList
        {
            get
            {
                return _navItemList;
            }

            set
            {
                if (_navItemList == value)
                {
                    return;
                }

                _navItemList = value;
                RaisePropertyChanged(() => NavItemList);
            }
        }
        #endregion

        #region 属性 选择的结果 object
        /// <summary>
            /// The <see cref="SelectedValue" /> property's name.
            /// </summary>
        public const string SelectedValuePropertyName = "SelectedValue";

        private object _selectedValue = null;

        /// <summary>
        /// Sets and gets the SelectedValue property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public object SelectedValue
        {
            get
            {
                return _selectedValue;
            }

            set
            {
                if (_selectedValue == value)
                {
                    return;
                }

                _selectedValue = value;
                RaisePropertyChanged(() => SelectedValue);
            }
        }
        #endregion
    }
}