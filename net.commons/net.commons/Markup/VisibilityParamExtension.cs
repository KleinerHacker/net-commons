using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace net.commons.Markup
{
    [MarkupExtensionReturnType(typeof(VisibilityParam))]
    public class VisibilityParamExtension : MarkupExtension, IVisibilityParam
    {
        public bool Inverse { get; set; } = false;
        public bool ManageLayout { get; set; } = false;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Build();
        }

        internal VisibilityParam Build()
        {
            return new VisibilityParam(Inverse, ManageLayout);
        }
    }

    internal class VisibilityParam : IVisibilityParam
    {
        public bool Inverse { get; set; }
        public bool ManageLayout { get; set; }

        public VisibilityParam(bool inverse, bool manageLayout)
        {
            Inverse = inverse;
            ManageLayout = manageLayout;
        }
    }

    public interface IVisibilityParam
    {
        bool Inverse { get; set; }
        bool ManageLayout { get; set; }
    }
}
