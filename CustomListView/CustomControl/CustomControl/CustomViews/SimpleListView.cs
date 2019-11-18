using System;
using System.Collections;
using Xamarin.Forms;

namespace CustomControl
{
    public class SimpleListView : ScrollView, IDisposable 
    {
        private ScrollController controller;
        public int ItemHeight { get; set; }

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(SimpleListView), null, BindingMode.TwoWay);

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { this.SetValue(ItemTemplateProperty, value); }
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create("ItemsSource", typeof(IList), typeof(SimpleListView), null, BindingMode.OneWay);

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { this.SetValue(ItemsSourceProperty, value); }
        }

        public SimpleListView()
        {
            this.Orientation = ScrollOrientation.Vertical;
            this.ItemHeight = 60;
            this.controller = new ScrollController() { ListView = this };
            this.Scrolled += this.controller.ListView_Scrolled;
            this.Content = this.controller;
        }

        public void Dispose()
        {
            this.Scrolled -= this.controller.ListView_Scrolled;
        }
    }
}
