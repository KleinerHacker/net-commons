using System;
using System.Windows.Markup;

namespace Net.Commons.Markup.Parameter
{
    [MarkupExtensionReturnType(typeof(IBooleanToVisibilityParam))]
    public class BooleanToVisibilityParamExtension : MarkupExtension, IBooleanToVisibilityParam
    {
        public bool Invert { get; set; } = false;
        public bool ManageLayout { get; set; } = false;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Build();
        }

        internal BooleanToVisibilityParam Build()
        {
            return new BooleanToVisibilityParam(Invert, ManageLayout);
        }
    }

    public interface IBooleanToVisibilityParam
    {
        bool Invert { get; set; }
        bool ManageLayout { get; set; }
    }

    public sealed class BooleanToVisibilityParam : IBooleanToVisibilityParam
    {
        public bool Invert { get; set; }
        public bool ManageLayout { get; set; }

        public BooleanToVisibilityParam(bool inverse, bool manageLayout)
        {
            Invert = inverse;
            ManageLayout = manageLayout;
        }

        public override string ToString()
        {
            return $"{nameof(Invert)}: {Invert}, {nameof(ManageLayout)}: {ManageLayout}";
        }
    }
}
