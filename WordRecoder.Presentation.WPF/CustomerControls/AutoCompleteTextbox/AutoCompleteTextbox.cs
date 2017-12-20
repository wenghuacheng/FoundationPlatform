using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using WordRecoder.Presentation.WPF.General.Interfaces;

namespace WordRecoder.Presentation.WPF.CustomerControls.AutoCompleteTextbox
{
    [TemplatePart(Name = "textBox", Type = typeof(TextBox))]
    [TemplatePart(Name = "popup", Type = typeof(Popup))]
    [TemplatePart(Name = "listbox", Type = typeof(ListBox))]
    public class AutoCompleteTextbox : ContentControl
    {
        private TextBox mTextBox;
        private Popup mPopup;
        private ListBox mListbox;

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(AutoCompleteTextbox), new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public IEnumerable<ISelectedable> DataSource
        {
            get { return (IEnumerable<ISelectedable>)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }
        public static readonly DependencyProperty DataSourceProperty =
            DependencyProperty.Register("DataSource", typeof(IEnumerable<ISelectedable>), typeof(AutoCompleteTextbox), new PropertyMetadata((d, e) =>
            {
                var control = d as AutoCompleteTextbox;
                if (control.mPopup == null) return;
                bool isExistData = control.DataSource.Count() > 0;
                control.mPopup.StaysOpen = isExistData;
                control.mPopup.IsOpen = isExistData;
            }));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(AutoCompleteTextbox));


        public ControlTemplate HeaderTemplate
        {
            get { return (ControlTemplate)GetValue(HeaderTemplateProperty); }
            set { SetValue(HeaderTemplateProperty, value); }
        }
        public static readonly DependencyProperty HeaderTemplateProperty =
            DependencyProperty.Register("HeaderTemplate", typeof(ControlTemplate), typeof(AutoCompleteTextbox));


        public static readonly RoutedEvent OnTextChangedEvent = EventManager.RegisterRoutedEvent
          ("OnTextChanged", RoutingStrategy.Bubble, typeof(EventHandler<string>), typeof(AutoCompleteTextbox));
        public event RoutedEventHandler OnTextChanged
        {
            add { this.AddHandler(OnTextChangedEvent, value); }
            remove { this.RemoveHandler(OnTextChangedEvent, value); }
        }

        public static readonly RoutedEvent OnItemSelectedEvent = EventManager.RegisterRoutedEvent
       ("OnItemSelected", RoutingStrategy.Bubble, typeof(EventHandler<ISelectedable>), typeof(AutoCompleteTextbox));
        public event RoutedEventHandler OnItemSelected
        {
            add { this.AddHandler(OnItemSelectedEvent, value); }
            remove { this.RemoveHandler(OnItemSelectedEvent, value); }
        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            mTextBox = GetTemplateChild("textBox") as TextBox;
            mPopup = GetTemplateChild("popup") as Popup;
            mListbox = GetTemplateChild("listBox") as ListBox;

            mTextBox.TextChanged -= MTextBox_TextChanged;
            mTextBox.TextChanged += MTextBox_TextChanged;
            mTextBox.KeyUp -= MTextBox_KeyUp;
            mTextBox.KeyUp += MTextBox_KeyUp;
        }

        private void MTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (this.DataSource == null || this.DataSource.Count() <= 0) return;

            if (e.Key == System.Windows.Input.Key.Up || e.Key == System.Windows.Input.Key.Down)
            {
                int selectedIndex = 0;

                var item = this.DataSource.FirstOrDefault(p => p.IsSelected);

                if (item == null)
                    selectedIndex = 0;
                else
                {
                    selectedIndex = this.DataSource.ToList().IndexOf(item);

                    if (e.Key == System.Windows.Input.Key.Up)
                        selectedIndex = (selectedIndex - 1) % this.DataSource.Count();
                    else if (e.Key == System.Windows.Input.Key.Down)
                        selectedIndex = (selectedIndex + 1) % this.DataSource.Count();
                }

                selectedIndex = selectedIndex < 0 ? 0 : selectedIndex;

                var selectedItem = this.DataSource.ElementAt(selectedIndex);
                selectedItem.IsSelected = true;

                mTextBox.TextChanged -= MTextBox_TextChanged;
                mTextBox.Text = selectedItem.Name;
                mTextBox.TextChanged += MTextBox_TextChanged;


            }
            else if (e.Key == System.Windows.Input.Key.Enter)
            {
                var item = this.DataSource.FirstOrDefault(p => p.IsSelected);
                if (item != null)
                {
                    mPopup.IsOpen = false;
                    mPopup.StaysOpen = false;
                    RaiseEvent(new RoutedEventArgs(OnItemSelectedEvent, item));
                }
            }
        }

        private void MTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.RaiseEvent(new RoutedEventArgs(OnTextChangedEvent, mTextBox.Text));

            if (this.DataSource.Count() > 0)
            {
                mPopup.IsOpen = true;
                mPopup.StaysOpen = true;
            }
            else
            {
                mPopup.IsOpen = false;
                mPopup.StaysOpen = false;
            }
        }
    }
}
