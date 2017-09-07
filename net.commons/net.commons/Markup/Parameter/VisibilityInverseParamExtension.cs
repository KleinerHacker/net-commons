using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace net.commons.Markup.Parameter
{
    [MarkupExtensionReturnType(typeof(IVisibilityInverseParam))]
    public class VisibilityInverseParamExtension : MarkupExtension, IVisibilityInverseParam
    {
        public bool ManageLayout { get; set; } = false;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Build();
        }

        internal VisibilityInverseParam Build()
        {
            return new VisibilityInverseParam(ManageLayout);
        }
    }

    public interface IVisibilityInverseParam
    {
        bool ManageLayout { get; set; }
    }

    public sealed class VisibilityInverseParam : IVisibilityInverseParam
    {
        public bool ManageLayout { get; set; }

        public VisibilityInverseParam()
        {
        }

        public VisibilityInverseParam(bool manageLayout)
        {
            ManageLayout = manageLayout;
        }

        public override string ToString()
        {
            return $"{nameof(ManageLayout)}: {ManageLayout}";
        }
    }
}
