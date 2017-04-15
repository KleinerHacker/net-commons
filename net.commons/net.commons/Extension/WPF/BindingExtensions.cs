using System.Windows;
using System.Windows.Data;

namespace net.commons.Extension.WPF
{
    public static class BindingExtensions
    {
        public static object ResolveValue(this Binding binding)
        {
            var dummy = new DummyDependencyObject();
            BindingOperations.SetBinding(dummy, DummyDependencyObject.ValueProperty, binding);

            return dummy.Value;
        }

        public static void BindOn(this Binding binding, DependencyObject o, DependencyProperty dp)
        {
            BindingOperations.SetBinding(o, dp, binding);
        }

        public static void BindOn(this Binding binding, DependencyObject o, DependencyProperty dp, IValueConverter converter, object converterParameter = null)
        {
            var dummy = new DummyDependencyObject();
            BindingOperations.SetBinding(dummy, DummyDependencyObject.ValueProperty, binding);
            BindingOperations.SetBinding(o, dp, new Binding
            {
                Source = dummy,
                Path = new PropertyPath(DummyDependencyObject.ValueProperty),
                Converter = converter,
                ConverterParameter = converterParameter
            });
        }
    }

    internal sealed class DummyDependencyObject : DependencyObject
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(object), typeof(DummyDependencyObject), new PropertyMetadata(default(object)));

        public object Value
        {
            get { return (object) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
    }
}