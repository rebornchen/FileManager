using GalaSoft.MvvmLight;
using System.Collections.Generic;

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
        /// <summary>
        /// Initializes a new instance of the UCAccordionNavModel class.
        /// </summary>
        public UCAccordionNavModel()
        {
            //NavItemList = InitialNavData_Test();
        }

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

        #region 属性 NavItemList， 界面上导航的数据源
        /// <summary>
        /// The <see cref="NavItemList" /> property's name.
        /// </summary>
        public const string NavItemListPropertyName = "NavItemList";

        private List<KeyValuePair<string, List<KeyValuePair<string, object>>>> _navItemList = InitialNavData_Test();

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
    }
}