using System;
using System.Windows.Markup;
using net.commons.Converter;

namespace net.commons.Markup.Parameter
{
    /// \ingroup wpf_converter_param
    /// \ingroup wpf_markup
    /// <summary>
    /// Markup extension for <see cref="DateTimeConverter"/> parameter to use in XAML
    /// </summary>
    [MarkupExtensionReturnType(typeof(IDateTimeParam))]
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

    /// \ingroup wpf_converter_param
    /// <summary>
    /// Interface for DateTimeConverter parameter
    /// </summary>
    public interface IDateTimeParam
    {
        /// <summary>
        /// Presentation of date value
        /// </summary>
        DatePresentation DatePresentation { get; set; }
        /// <summary>
        /// Presentation of time value
        /// </summary>
        TimePresentation TimePresentation { get; set; }
        string Separator { get; set; }
    }

    public sealed class DateTimeParam : IDateTimeParam
    {
        public DatePresentation DatePresentation { get; set; }
        public TimePresentation TimePresentation { get; set; }
        public string Separator { get; set; }

        public DateTimeParam()
        {
        }

        public DateTimeParam(DatePresentation datePresentation, TimePresentation timePresentation, string separator)
        {
            DatePresentation = datePresentation;
            TimePresentation = timePresentation;
            Separator = separator;
        }

        public override string ToString()
        {
            return $"{nameof(DatePresentation)}: {DatePresentation}, {nameof(TimePresentation)}: {TimePresentation}, {nameof(Separator)}: {Separator}";
        }
    }

    /// \ingroup wpf_converter_param
    /// <summary>
    /// Presentation of date value
    /// </summary>
    public enum DatePresentation
    {
        /// <summary>
        /// Not included in string
        /// </summary>
        None,
        /// <summary>
        /// Short variant
        /// </summary>
        Short,
        /// <summary>
        /// Long variant
        /// </summary>
        Long
    }

    /// \ingroup wpf_converter_param
    /// <summary>
    /// Presentation of time value
    /// </summary>
    public enum TimePresentation
    {
        /// <summary>
        /// Not included in string
        /// </summary>
        None,
        /// <summary>
        /// Short variant
        /// </summary>
        Short,
        /// <summary>
        /// Long variant
        /// </summary>
        Long
    }
}
