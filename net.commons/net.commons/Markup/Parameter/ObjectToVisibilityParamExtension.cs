using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace net.commons.Markup.Parameter
{
    [MarkupExtensionReturnType(typeof(IObjectToVisibilityParam))]
    public class ObjectToVisibilityParamExtension : MarkupExtension, IObjectToVisibilityParam
    {
        public object ReferenceValue { get; set; } = null;
        public bool Invert { get; set; } = false;
        public bool ManageLayout { get; set; } = false;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Build();
        }

        internal ObjectToVisibilityParam Build()
        {
            return new ObjectToVisibilityParam(ReferenceValue, Invert, ManageLayout);
        }
    }

    public interface IObjectToVisibilityParam
    {
        object ReferenceValue { get; set; }
        bool Invert { get; set; }
        bool ManageLayout { get; set; }
    }

    public sealed class ObjectToVisibilityParam : IObjectToVisibilityParam
    {
        public object ReferenceValue { get; set; }
        public bool Invert { get; set; }
        public bool ManageLayout { get; set; }

        public ObjectToVisibilityParam()
        {
        }

        public ObjectToVisibilityParam(object referenceValue, bool inverse, bool manageLayout)
        {
            ReferenceValue = referenceValue;
            Invert = inverse;
            ManageLayout = manageLayout;
        }

        public override string ToString()
        {
            return $"{nameof(ReferenceValue)}: {ReferenceValue}, {nameof(Invert)}: {Invert}, {nameof(ManageLayout)}: {ManageLayout}";
        }
    }
}
