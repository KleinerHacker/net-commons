using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Net.Commons.Markup.Parameter
{
    [MarkupExtensionReturnType(typeof(IObjectToBooleanParam))]
    public class ObjectToBooleanParamExtension : MarkupExtension, IObjectToBooleanParam
    {
        public object ReferenceValue { get; set; } = null;
        public bool Invert { get; set; } = false;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Build();
        }

        internal ObjectToBooleanParam Build()
        {
            return new ObjectToBooleanParam(ReferenceValue, Invert);
        }
    }

    public interface IObjectToBooleanParam
    {
        object ReferenceValue { get; set; }
        bool Invert { get; set; }
    }

    public sealed class ObjectToBooleanParam : IObjectToBooleanParam
    {
        public object ReferenceValue { get; set; }
        public bool Invert { get; set; }

        public ObjectToBooleanParam()
        {
        }

        public ObjectToBooleanParam(object referenceValue, bool invert)
        {
            ReferenceValue = referenceValue;
            Invert = invert;
        }

        public override string ToString()
        {
            return $"{nameof(ReferenceValue)}: {ReferenceValue}, {nameof(Invert)}: {Invert}";
        }
    }
}
