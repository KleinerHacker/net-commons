using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace net.commons.Markup
{
    [MarkupExtensionReturnType(typeof(DateTimeParam))]
    public class DateTimeParamExtension : MarkupExtension, IDateTimeParam
    {
        public DatePresentation DatePresentation { get; set; } = DatePresentation.Short;
        public TimePresentation TimePresentation { get; set; } = TimePresentation.Short;
        public string Separator { get; set; } = " ";

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Build();
        }

        internal DateTimeParam Build()
        {
            return new DateTimeParam(DatePresentation, TimePresentation, Separator);
        }
    }

    public interface IDateTimeParam
    {
        DatePresentation DatePresentation { get; set; }
        TimePresentation TimePresentation { get; set; }
        string Separator { get; set; }
    }

    internal class DateTimeParam : IDateTimeParam
    {
        public DatePresentation DatePresentation { get; set; }
        public TimePresentation TimePresentation { get; set; }
        public string Separator { get; set; }

        public DateTimeParam(DatePresentation datePresentation, TimePresentation timePresentation, string separator)
        {
            DatePresentation = datePresentation;
            TimePresentation = timePresentation;
            Separator = separator;
        }
    }

    public enum DatePresentation
    {
        None,
        Short,
        Long
    }

    public enum TimePresentation
    {
        None,
        Short,
        Long
    }
}
