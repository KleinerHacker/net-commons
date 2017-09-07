using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace net.commons.Markup.Parameter
{
    [MarkupExtensionReturnType(typeof(IMultiBooleanParam))]
    public class MultiBooleanParamExtension : MarkupExtension, IMultiBooleanParam
    {
        public MultiBooleanLogic Logic { get; set; } = MultiBooleanLogic.Any;
        public bool Invert { get; set; } = false;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Build();
        }

        internal MultiBooleanParam Build()
        {
            return new MultiBooleanParam(Logic, Invert);
        }
    }

    public interface IMultiBooleanParam
    {
        MultiBooleanLogic Logic { get; set; }
        bool Invert { get; set; }
    }

    public sealed class MultiBooleanParam : IMultiBooleanParam
    {
        public MultiBooleanLogic Logic { get; set; }
        public bool Invert { get; set; }

        public MultiBooleanParam()
        {
        }

        public MultiBooleanParam(MultiBooleanLogic logic, bool invert)
        {
            Logic = logic;
            Invert = invert;
        }

        public override string ToString()
        {
            return $"{nameof(Logic)}: {Logic}, {nameof(Invert)}: {Invert}";
        }
    }

    public enum MultiBooleanLogic
    {
        Any,
        All
    }
}