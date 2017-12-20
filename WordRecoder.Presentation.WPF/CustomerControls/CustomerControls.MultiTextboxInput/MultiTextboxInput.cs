using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WordRecoder.Presentation.WPF.CustomerControls.CustomerControls.MultiTextboxInput
{
    [TemplatePart(Name = ButtonName, Type = typeof(Button))]
    public class MultiTextboxInput : ItemsControl
    {        
        private const string ButtonName = "Btn_SetNum";        
        private Button mButton;

        #region Properties  

        public int DefaultCount
        {
            get { return (int)GetValue(DefaultCountProperty); }
            set { SetValue(DefaultCountProperty, value); }
        }
        public static readonly DependencyProperty DefaultCountProperty =
            DependencyProperty.Register("DefaultCount", typeof(int), typeof(MultiTextboxInput), new PropertyMetadata(3, (d, e) =>
            {
                MultiTextboxInput control = d as MultiTextboxInput;
                if (control.ItemsSource == null)
                    control.ItemsSource = new BindableCollection<InputModel>();

                var source = control.ItemsSource as BindableCollection<InputModel>;
                if (source == null) return;
                for (int i = 0; i < control.DefaultCount; i++)
                    source.Add(new InputModel());
            }));


        #endregion

        #region override
        public override void OnApplyTemplate()
        {
            mButton = GetTemplateChild(ButtonName) as Button;

            if (mButton == null) return;

            mButton.Click -= MButton_Click;
            mButton.Click += MButton_Click;

            base.OnApplyTemplate();
        }
        #endregion

        private void MButton_Click(object sender, RoutedEventArgs e)
        {
            var source = ItemsSource as BindableCollection<InputModel>;
            if (source == null) return;

            source.Add(new InputModel());
        }
    }

    public class InputModel
    {
        public string Name { get; set; }
    }
}
