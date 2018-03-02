using Arthas.Utility.Element;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Arthas.Controls.Metro
{
    public class MetroTabItem : TabItem
    {
        public static readonly DependencyProperty IconProperty = ElementBase.Property<MetroTabItem, ImageSource>(nameof(IconProperty), null);
        public static readonly DependencyProperty ClosedProperty = ElementBase.Property<MetroTabItem, bool>(nameof(ClosedProperty), false);

        public static RoutedUICommand CloseBtnClickCommand = ElementBase.Command<MetroTextBox>(nameof(CloseBtnClickCommand));

        public ImageSource Icon { get { return (ImageSource)GetValue(IconProperty); } set { SetValue(IconProperty, value); } }
        public bool Closed { get { return (bool)GetValue(ClosedProperty); } set { SetValue(ClosedProperty, value); } }

        public event EventHandler CloseBtnClick;
        public MetroTabItem()
        {
            ///为关闭按钮添加点击事件
            CommandBindings.Add(new CommandBinding(CloseBtnClickCommand, delegate { if (CloseBtnClick != null) { CloseBtnClick(this, null); } }));
            Utility.Refresh(this);
        }

        static MetroTabItem()
        {
            ElementBase.DefaultStyle<MetroTabItem>(DefaultStyleKeyProperty);
        }
    }
}