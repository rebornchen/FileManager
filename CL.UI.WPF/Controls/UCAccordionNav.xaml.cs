using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CL.UI.WPF.Controls
{
    /// <summary>
    /// UCAccordionNav.xaml 的交互逻辑
    /// </summary>
    public partial class UCAccordionNav : UserControl
    {
        public UCAccordionNav()
        {
            InitializeComponent();
        }

        #region ItemList 属性
        /// <summary>
        /// The <see cref="ItemList" /> dependency property's name.
        /// </summary>
        public const string ItemListPropertyName = "ItemList";

        /// <summary>
        /// Gets or sets the value of the <see cref="ItemList" />
        /// Accordion 里面项的数据源
        /// </summary>
        public List<KeyValuePair<string, List<KeyValuePair<string ,object>>>> ItemList
        {
            get
            {
                return (List<KeyValuePair<string, List<KeyValuePair<string ,object>>>>)GetValue(ItemListProperty);
            }
            set
            {
                SetValue(ItemListProperty, value);
            }
        }
        
        /// <summary>
        /// Identifies the <see cref="ItemList" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemListProperty = DependencyProperty.Register(
            ItemListPropertyName,
            typeof(List<KeyValuePair<string, List<KeyValuePair<string ,object>>>>),
            typeof(UCAccordionNav),
            new UIPropertyMetadata(null, 
                (sender, args)=> {
                    UCAccordionNav obj = sender as UCAccordionNav;
                    obj.LoadAccordionNavData();
                }));
        #endregion

        #region SelectedValue 属性
        /// <summary>
        /// The <see cref="SelectedValue" /> dependency property's name.
        /// </summary>
        public const string SelectedValuePropertyName = "SelectedValue";

        /// <summary>
        /// Gets or sets the value of the <see cref="SelectedValue" />
        /// property. This is a dependency property.
        /// </summary>
        public object SelectedValue
        {
            get
            {
                return (object)GetValue(SelectedValueProperty);
            }
            set
            {
                SetValue(SelectedValueProperty, value);
            }
        }

        /// <summary>
        /// Identifies the <see cref="SelectedValue" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register(
            SelectedValuePropertyName,
            typeof(object),
            typeof(UCAccordionNav),
            new UIPropertyMetadata(null));
        #endregion


        /// <summary>
        /// 加载导航控件中的数据
        /// </summary>
        protected void LoadAccordionNavData()
        {
            this.accordionNav.Items.Clear();
            SelectedValue = null;
            
            if(ItemList == null)
            {
                return;
            }
            foreach (KeyValuePair<string, List<KeyValuePair<string ,object>>> item in ItemList)
            {
                AccordionItem aitem = new AccordionItem();
                aitem.Header = item.Key;
                this.accordionNav.Items.Add(aitem);
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Vertical;
                foreach (var child in item.Value)
                {
                    TextBlock txt = new TextBlock() { Text = child.Key, Tag = child.Value };
                    txt.MouseDown += Txt_MouseDown;
                    stackPanel.Children.Add(txt);
                }
                aitem.Content = stackPanel;
            }
            
        }

        private void Txt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                SelectedValue = ((TextBlock)sender).Tag;
                MessageBox.Show(SelectedValue.ToString());
            }
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoadAccordionNavData();
            

        }

    }
}
