using System;
using Windows.UI.Xaml.Markup;
using Net.Commons.Converter;

namespace Net.Commons.Markup.Parameter
{
    #region Parameters Markup Extensions

    /// \ingroup wpf_single_converter_param
    /// \ingroup wpf_markup
    /// <summary>
    /// Basic markup extension for <see cref="TextManipulationConverter"/> parameter to use in XAML
    /// </summary>
    public abstract class TextManipulationParamExtension : MarkupExtension, ITextManipulationParam
    {
    }

    /// \ingroup wpf_single_converter_param
    /// \ingroup wpf_markup
    /// <summary>
    /// Markup extension for <see cref="TextManipulationConverter"/> parameter to use in XAML. See <see cref="ITextManipulationChangeCaseParam"/>
    /// </summary>
    [MarkupExtensionReturnType(ReturnType = typeof(ITextManipulationChangeCaseParam))]
    public class TextManipulationChangeCaseParamExtension : TextManipulationParamExtension, ITextManipulationChangeCaseParam
    {
        public ChangeCaseType Type { get; set; } = ChangeCaseType.Upper;
        public ChangeCaseVariant Variant { get; set; } = ChangeCaseVariant.AllCharacters;

        protected override object ProvideValue()
        {
            return Build();
        }

        internal ITextManipulationChangeCaseParam Build()
        {
            return new TextManipulationChangeCaseParam(Type, Variant);
        }
    }

    /// \ingroup wpf_single_converter_param
    /// \ingroup wpf_markup
    /// <summary>
    /// Markup extension for <see cref="TextManipulationConverter"/> parameter to use in XAML. See <see cref="ITextManipulationReplaceParam"/>
    /// </summary>
    [MarkupExtensionReturnType(ReturnType = typeof(ITextManipulationReplaceParam))]
    public class TextManipulationReplaceParamExtension : TextManipulationParamExtension, ITextManipulationReplaceParam
    {
        public string SourceString { get; set; }
        public string TargetString { get; set; }
        public int Repeat { get; set; } = -1;
        public bool IgnoreCase { get; set; } = false;

        public TextManipulationReplaceParamExtension(string sourceString, string targetString)
        {
            SourceString = sourceString;
            TargetString = targetString;
        }

        protected override object ProvideValue()
        {
            return Build();
        }

        internal ITextManipulationReplaceParam Build()
        {
            return new TextManipulationReplaceParam(SourceString, TargetString, Repeat, IgnoreCase);
        }
    }

    #endregion

    #region Parameters Interfaces

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Basic Interface for the converter parameter of <see cref="TextManipulationConverter"/>, see <see cref="ITextManipulationChangeCaseParam"/>, <see cref="ITextManipulationReplaceParam"/>
    /// </summary>
    public interface ITextManipulationParam
    {
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Interface for the converter parameter of <see cref="TextManipulationConverter"/>, see <see cref="TextManipulationChangeCaseParam"/>
    /// </summary>
    public interface ITextManipulationChangeCaseParam : ITextManipulationParam
    {
        /// <summary>
        /// Type of case change
        /// </summary>
        ChangeCaseType Type { get; set; }
        /// <summary>
        /// Variant of case change
        /// </summary>
        ChangeCaseVariant Variant { get; set; }
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Interface for the converter parameter of <see cref="TextManipulationConverter"/>, see <see cref="TextManipulationReplaceParam"/>
    /// </summary>
    public interface ITextManipulationReplaceParam : ITextManipulationParam
    {
        /// <summary>
        /// String to search for
        /// </summary>
        string SourceString { get; set; }
        /// <summary>
        /// String to replace with
        /// </summary>
        string TargetString { get; set; }
        /// <summary>
        /// Count of repeation, default is -1 (means all)
        /// </summary>
        int Repeat { get; set; }
        /// <summary>
        /// TRUE to ignore case, otherwise FALSE (default)
        /// </summary>
        bool IgnoreCase { get; set; }
    }

    #endregion

    #region Parameters

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Converter parameter of <see cref="TextManipulationConverter"/>
    /// </summary>
    public sealed class TextManipulationChangeCaseParam : ITextManipulationChangeCaseParam
    {
        /// <inheritdoc />
        public ChangeCaseType Type { get; set; }
        /// <inheritdoc />
        public ChangeCaseVariant Variant { get; set; }

        public TextManipulationChangeCaseParam()
        {
        }

        public TextManipulationChangeCaseParam(ChangeCaseType type, ChangeCaseVariant variant)
        {
            Type = type;
            Variant = variant;
        }

        public override string ToString()
        {
            return $"{nameof(Type)}: {Type}, {nameof(Variant)}: {Variant}";
        }
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Converter parameter of <see cref="TextManipulationConverter"/>
    /// </summary>
    public sealed class TextManipulationReplaceParam : ITextManipulationReplaceParam
    {
        /// <inheritdoc />
        public string SourceString { get; set; }
        /// <inheritdoc />
        public string TargetString { get; set; }
        /// <inheritdoc />
        public int Repeat { get; set; }
        /// <inheritdoc />
        public bool IgnoreCase { get; set; }

        public TextManipulationReplaceParam()
        {
        }

        public TextManipulationReplaceParam(string sourceString, string targetString, int repeat, bool ignoreCase)
        {
            SourceString = sourceString;
            TargetString = targetString;
            Repeat = repeat;
            IgnoreCase = ignoreCase;
        }

        public override string ToString()
        {
            return $"{nameof(SourceString)}: {SourceString}, {nameof(TargetString)}: {TargetString}, {nameof(Repeat)}: {Repeat}, {nameof(IgnoreCase)}: {IgnoreCase}";
        }
    }

    #endregion

    #region Types

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Represent the variants to change case
    /// </summary>
    public enum ChangeCaseVariant
    {
        /// <summary>
        /// All characters are changed
        /// </summary>
        AllCharacters,
        /// <summary>
        /// Only first character of each word is changed
        /// </summary>
        WordsOnly
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Represent the types to change case
    /// </summary>
    public enum ChangeCaseType
    {
        /// <summary>
        /// Change to upper case
        /// </summary>
        Upper,
        /// <summary>
        /// Chnage to lower case
        /// </summary>
        Lower
    }

    #endregion
}
