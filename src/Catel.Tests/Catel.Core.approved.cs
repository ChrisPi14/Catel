﻿[assembly: System.Resources.NeutralResourcesLanguageAttribute("en-US")]
[assembly: System.Runtime.CompilerServices.InternalsVisibleToAttribute("Catel.MVVM")]
[assembly: System.Runtime.CompilerServices.InternalsVisibleToAttribute("Catel.Serialization.Json")]
[assembly: System.Runtime.CompilerServices.InternalsVisibleToAttribute("Catel.Tests")]
[assembly: System.Runtime.Versioning.TargetFrameworkAttribute(".NETFramework,Version=v4.7", FrameworkDisplayName=".NET Framework 4.7")]
namespace Catel.ApiCop
{
    public class ApiCop : Catel.ApiCop.IApiCop
    {
        public ApiCop(System.Type targetType) { }
        public System.Type TargetType { get; }
        public System.Collections.Generic.IEnumerable<Catel.ApiCop.IApiCopResult> GetResults() { }
        public Catel.ApiCop.IApiCop RegisterRule<TRule>(TRule rule)
            where TRule : Catel.ApiCop.IApiCopRule { }
        public void UpdateRule<TRule>(string name, System.Action<TRule> action)
            where TRule : Catel.ApiCop.IApiCopRule { }
    }
    public abstract class ApiCopListenerBase : Catel.ApiCop.IApiCopListener
    {
        protected ApiCopListenerBase() { }
        public Catel.ApiCop.ApiCopListenerGrouping Grouping { get; set; }
        protected virtual void BeginWriting() { }
        protected virtual void BeginWritingOfGroup(string groupName) { }
        protected virtual void EndWriting() { }
        protected virtual void EndWritingOfGroup(string groupName) { }
        protected abstract void WriteResult(Catel.ApiCop.IApiCopResult result);
        public void WriteResults(System.Collections.Generic.IEnumerable<Catel.ApiCop.IApiCopResult> results) { }
        protected virtual void WriteSummary(System.Collections.Generic.IEnumerable<Catel.ApiCop.IApiCopResult> results) { }
    }
    public enum ApiCopListenerGrouping
    {
        Cop = 0,
        Rule = 1,
        Tag = 2,
    }
    public class static ApiCopManager
    {
        public static System.Collections.Generic.HashSet<string> IgnoredRules { get; }
        public static bool IsEnabled { get; }
        public static void AddListener(Catel.ApiCop.IApiCopListener listener) { }
        public static void ClearListeners() { }
        public static Catel.ApiCop.IApiCop GetApiCop(System.Type type) { }
        public static Catel.ApiCop.IApiCop GetCurrentClassApiCop() { }
        public static System.Collections.Generic.IEnumerable<Catel.ApiCop.IApiCopListener> GetListeners() { }
        public static bool IsListenerRegistered(Catel.ApiCop.IApiCopListener listener) { }
        public static void RemoveListener(Catel.ApiCop.IApiCopListener listener) { }
        public static void WriteResults() { }
    }
    public class ApiCopResult : Catel.ApiCop.IApiCopResult
    {
        public ApiCopResult(Catel.ApiCop.IApiCop cop, Catel.ApiCop.IApiCopRule rule, string tag) { }
        public Catel.ApiCop.IApiCop Cop { get; }
        public Catel.ApiCop.IApiCopRule Rule { get; }
        public string Tag { get; }
    }
    public abstract class ApiCopRule : Catel.ApiCop.IApiCopRule
    {
        protected ApiCopRule(string name, string description, Catel.ApiCop.ApiCopRuleLevel level, string url = null) { }
        public string Description { get; }
        public Catel.ApiCop.ApiCopRuleLevel Level { get; }
        public string Name { get; }
        public string Url { get; }
        protected void AddTag(string tag) { }
        protected Catel.Data.PropertyBag GetPropertyBagForTag(string tag) { }
        public abstract string GetResultAsText(string tag);
        public System.Collections.Generic.IEnumerable<string> GetTags() { }
        public abstract bool IsValid(Catel.ApiCop.IApiCop apiCop, string tag);
    }
    public enum ApiCopRuleLevel
    {
        Hint = 0,
        Warning = 1,
        Error = 2,
    }
    public interface IApiCop
    {
        System.Type TargetType { get; }
        System.Collections.Generic.IEnumerable<Catel.ApiCop.IApiCopResult> GetResults();
        Catel.ApiCop.IApiCop RegisterRule<TRule>(TRule rule)
            where TRule : Catel.ApiCop.IApiCopRule;
        void UpdateRule<TRule>(string name, System.Action<TRule> action)
            where TRule : Catel.ApiCop.IApiCopRule;
    }
    public interface IApiCopListener
    {
        Catel.ApiCop.ApiCopListenerGrouping Grouping { get; set; }
        void WriteResults(System.Collections.Generic.IEnumerable<Catel.ApiCop.IApiCopResult> results);
    }
    public interface IApiCopResult
    {
        Catel.ApiCop.IApiCop Cop { get; }
        Catel.ApiCop.IApiCopRule Rule { get; }
        string Tag { get; }
    }
    public interface IApiCopRule
    {
        string Description { get; }
        Catel.ApiCop.ApiCopRuleLevel Level { get; }
        string Name { get; }
        string Url { get; }
        string GetResultAsText(string tag);
        System.Collections.Generic.IEnumerable<string> GetTags();
        bool IsValid(Catel.ApiCop.IApiCop apiCop, string tag);
    }
    public abstract class TextApiCopListenerBase : Catel.ApiCop.ApiCopListenerBase
    {
        protected TextApiCopListenerBase() { }
        protected override void BeginWriting() { }
        protected override void BeginWritingOfGroup(string groupName) { }
        protected override void EndWriting() { }
        protected override void EndWritingOfGroup(string groupName) { }
        protected void WriteLine(string format, params object[] args) { }
        protected abstract void WriteLine(string line);
        protected override void WriteResult(Catel.ApiCop.IApiCopResult result) { }
        protected override void WriteSummary(System.Collections.Generic.IEnumerable<Catel.ApiCop.IApiCopResult> results) { }
    }
}
namespace Catel.ApiCop.Listeners
{
    public class ConsoleApiCopListener : Catel.ApiCop.TextApiCopListenerBase
    {
        public ConsoleApiCopListener() { }
        protected override void WriteLine(string line) { }
    }
    public class TextFileApiCopListener : Catel.ApiCop.TextApiCopListenerBase
    {
        public TextFileApiCopListener(string fileName) { }
        protected override void BeginWriting() { }
        protected override void EndWriting() { }
        protected override void WriteLine(string line) { }
    }
}
namespace Catel.ApiCop.Rules
{
    public class InitializationApiCopRule : Catel.ApiCop.ApiCopRule
    {
        public InitializationApiCopRule(string name, string description, Catel.ApiCop.ApiCopRuleLevel level, Catel.ApiCop.Rules.InitializationMode recommendedInitializationMode, string url = null) { }
        public Catel.ApiCop.Rules.InitializationMode RecommendedInitializationMode { get; }
        public override string GetResultAsText(string tag) { }
        public override bool IsValid(Catel.ApiCop.IApiCop apiCop, string tag) { }
        public void SetInitializationMode(Catel.ApiCop.Rules.InitializationMode initializationMode, string tag) { }
    }
    public enum InitializationMode
    {
        Lazy = 0,
        Eager = 1,
    }
    public class TooManyDependenciesApiCopRule : Catel.ApiCop.ApiCopRule
    {
        public TooManyDependenciesApiCopRule(string name, string description, Catel.ApiCop.ApiCopRuleLevel level, string url = null) { }
        public override string GetResultAsText(string tag) { }
        public override bool IsValid(Catel.ApiCop.IApiCop apiCop, string tag) { }
        public void SetNumberOfDependenciesInjected(System.Type type, int numberOfDependencies) { }
    }
    public class UnusedFeatureApiCopRule : Catel.ApiCop.ApiCopRule
    {
        public UnusedFeatureApiCopRule(string name, string description, Catel.ApiCop.ApiCopRuleLevel level, string url = null) { }
        public override string GetResultAsText(string tag) { }
        public void IncreaseCount(bool isUsed, string tag) { }
        public override bool IsValid(Catel.ApiCop.IApiCop apiCop, string tag) { }
    }
}
namespace Catel
{
    public class static Argument
    {
        public static void ImplementsInterface(string paramName, object instance, System.Type interfaceType) { }
        public static void ImplementsInterface<TInterface>(string paramName, object instance)
            where TInterface :  class { }
        public static void ImplementsInterface(string paramName, System.Type type, System.Type interfaceType) { }
        public static void ImplementsInterface<T>(System.Linq.Expressions.Expression<System.Func<T>> expression, System.Type interfaceType)
            where T :  class { }
        public static void ImplementsOneOfTheInterfaces(string paramName, object instance, System.Type[] interfaceTypes) { }
        public static void ImplementsOneOfTheInterfaces(string paramName, System.Type type, System.Type[] interfaceTypes) { }
        public static void ImplementsOneOfTheInterfaces<T>(System.Linq.Expressions.Expression<System.Func<T>> expression, System.Type[] interfaceTypes)
            where T :  class { }
        public static void InheritsFrom(string paramName, System.Type type, System.Type baseType) { }
        public static void InheritsFrom(string paramName, object instance, System.Type baseType) { }
        public static void InheritsFrom<TBase>(string paramName, object instance)
            where TBase :  class { }
        public static void IsMatch(string paramName, string paramValue, string pattern, System.Text.RegularExpressions.RegexOptions regexOptions = 0) { }
        public static void IsMatch(System.Linq.Expressions.Expression<System.Func<string>> expression, string pattern, System.Text.RegularExpressions.RegexOptions regexOptions = 0) { }
        public static void IsMaximum<T>(string paramName, T paramValue, T maximumValue, System.Func<T, T, bool> validation) { }
        public static void IsMaximum<T>(string paramName, T paramValue, T maximumValue)
            where T : System.IComparable { }
        public static void IsMaximum<T>(System.Linq.Expressions.Expression<System.Func<T>> expression, T maximumValue, System.Func<T, T, bool> validation) { }
        public static void IsMaximum<T>(System.Linq.Expressions.Expression<System.Func<T>> expression, T maximumValue)
            where T : System.IComparable { }
        public static void IsMinimal<T>(string paramName, T paramValue, T minimumValue, System.Func<T, T, bool> validation) { }
        public static void IsMinimal<T>(string paramName, T paramValue, T minimumValue)
            where T : System.IComparable { }
        public static void IsMinimal<T>(System.Linq.Expressions.Expression<System.Func<T>> expression, T minimumValue, System.Func<T, T, bool> validation) { }
        public static void IsMinimal<T>(System.Linq.Expressions.Expression<System.Func<T>> expression, T minimumValue)
            where T : System.IComparable { }
        public static void IsNotEmpty(string paramName, System.Guid paramValue) { }
        public static void IsNotEmpty(System.Linq.Expressions.Expression<System.Func<System.Guid>> expression) { }
        public static void IsNotMatch(string paramName, string paramValue, string pattern, System.Text.RegularExpressions.RegexOptions regexOptions = 0) { }
        public static void IsNotMatch(System.Linq.Expressions.Expression<System.Func<string>> expression, string pattern, System.Text.RegularExpressions.RegexOptions regexOptions = 0) { }
        public static void IsNotNull(string paramName, object paramValue) { }
        public static void IsNotNull<T>(System.Linq.Expressions.Expression<System.Func<T>> expression)
            where T :  class { }
        public static void IsNotNullOrEmpty(string paramName, string paramValue) { }
        public static void IsNotNullOrEmpty(string paramName, System.Nullable<System.Guid> paramValue) { }
        public static void IsNotNullOrEmpty(System.Linq.Expressions.Expression<System.Func<string>> expression) { }
        public static void IsNotNullOrEmpty(System.Linq.Expressions.Expression<System.Func<System.Nullable<System.Guid>>> expression) { }
        public static void IsNotNullOrEmptyArray(string paramName, System.Array paramValue) { }
        public static void IsNotNullOrEmptyArray(System.Linq.Expressions.Expression<System.Func<System.Array>> expression) { }
        public static void IsNotNullOrWhitespace(string paramName, string paramValue) { }
        public static void IsNotNullOrWhitespace(System.Linq.Expressions.Expression<System.Func<string>> expression) { }
        public static void IsNotOfOneOfTheTypes(string paramName, object instance, System.Type[] notRequiredTypes) { }
        public static void IsNotOfOneOfTheTypes(string paramName, System.Type type, System.Type[] notRequiredTypes) { }
        public static void IsNotOfOneOfTheTypes<T>(System.Linq.Expressions.Expression<System.Func<T>> expression, System.Type[] notRequiredTypes)
            where T :  class { }
        public static void IsNotOfType(string paramName, object instance, System.Type notRequiredType) { }
        public static void IsNotOfType(string paramName, System.Type type, System.Type notRequiredType) { }
        public static void IsNotOfType<T>(System.Linq.Expressions.Expression<System.Func<T>> expression, System.Type notRequiredType)
            where T :  class { }
        public static void IsNotOutOfRange<T>(string paramName, T paramValue, T minimumValue, T maximumValue, System.Func<T, T, T, bool> validation) { }
        public static void IsNotOutOfRange<T>(string paramName, T paramValue, T minimumValue, T maximumValue)
            where T : System.IComparable { }
        public static void IsNotOutOfRange<T>(System.Linq.Expressions.Expression<System.Func<T>> expression, T minimumValue, T maximumValue, System.Func<T, T, T, bool> validation) { }
        public static void IsNotOutOfRange<T>(System.Linq.Expressions.Expression<System.Func<T>> expression, T minimumValue, T maximumValue)
            where T : System.IComparable { }
        public static void IsOfOneOfTheTypes(string paramName, object instance, System.Type[] requiredTypes) { }
        public static void IsOfOneOfTheTypes(string paramName, System.Type type, System.Type[] requiredTypes) { }
        public static void IsOfOneOfTheTypes<T>(System.Linq.Expressions.Expression<System.Func<T>> expression, System.Type[] requiredTypes)
            where T :  class { }
        public static void IsOfType(string paramName, object instance, System.Type requiredType) { }
        public static void IsOfType(string paramName, System.Type type, System.Type requiredType) { }
        public static void IsOfType<T>(System.Linq.Expressions.Expression<System.Func<T>> expression, System.Type requiredType)
            where T :  class { }
        public static void IsSupported(bool isSupported, string errorFormat, params object[] args) { }
        public static void IsValid<T>(string paramName, T paramValue, System.Func<bool> validation) { }
        public static void IsValid<T>(string paramName, T paramValue, System.Func<T, bool> validation) { }
        public static void IsValid<T>(string paramName, T paramValue, Catel.Data.IValueValidator<T> validator) { }
        public static void IsValid<T>(string paramName, T paramValue, bool validation) { }
        public static void IsValid<T>(System.Linq.Expressions.Expression<System.Func<T>> expression, System.Func<T, bool> validation) { }
        public static void IsValid<T>(System.Linq.Expressions.Expression<System.Func<T>> expression, System.Func<bool> validation) { }
        public static void IsValid<T>(System.Linq.Expressions.Expression<System.Func<T>> expression, bool validation) { }
        public static void IsValid<T>(System.Linq.Expressions.Expression<System.Func<T>> expression, Catel.Data.IValueValidator<T> validator) { }
    }
    public class static AsyncEventHandlerExtensions
    {
        public static System.Threading.Tasks.Task<bool> SafeInvokeAsync(this Catel.AsyncEventHandler<System.EventArgs> handler, object sender, bool allowParallelExecution = True) { }
        public static System.Threading.Tasks.Task<bool> SafeInvokeAsync<TEventArgs>(this Catel.AsyncEventHandler<TEventArgs> handler, object sender, TEventArgs e, bool allowParallelExecution = True)
            where TEventArgs : System.EventArgs { }
    }
    public delegate System.Threading.Tasks.Task AsyncEventHandler<TEventArgs>(object sender, TEventArgs e);
    public class static ByteArrayExtensions
    {
        public static string GetString(this byte[] data, System.Text.Encoding encoding) { }
        public static string GetUtf8String(this byte[] data) { }
    }
    public class CompositeFilter<T> : Catel.ICompositeFilter<T>
        where T :  class
    {
        public CompositeFilter() { }
        public Catel.CompositePredicate<T> Excludes { get; set; }
        public Catel.CompositePredicate<T> Includes { get; set; }
        public bool Matches(T target) { }
        public bool MatchesObject(object target) { }
    }
    public class CompositePredicate<T>
        where T :  class
    {
        public CompositePredicate() { }
        public bool DoesNotMatchAny(T target) { }
        public bool MatchesAll(T target) { }
        public bool MatchesAny(T target) { }
        public bool MatchesNone(T target) { }
        public static Catel.CompositePredicate<T> +(Catel.CompositePredicate<T> invokes, System.Predicate<T> filter) { }
    }
    public class CoreModule : Catel.IoC.IServiceLocatorInitializer
    {
        public CoreModule() { }
        public void Initialize(Catel.IoC.IServiceLocator serviceLocator) { }
    }
    public abstract class Disposable : System.IDisposable
    {
        protected Disposable() { }
        protected void CheckDisposed() { }
        public void Dispose() { }
        protected virtual void DisposeManaged() { }
        protected virtual void DisposeUnmanaged() { }
        protected override void Finalize() { }
    }
    public class DisposableToken : Catel.DisposableToken<object>
    {
        public DisposableToken(object instance, System.Action<Catel.IDisposableToken<object>> initialize, System.Action<Catel.IDisposableToken<object>> dispose, object tag = null) { }
    }
    public class DisposableToken<T> : Catel.Disposable, Catel.IDisposableToken<T>, System.IDisposable
    {
        public DisposableToken(T instance, System.Action<Catel.IDisposableToken<T>> initialize, System.Action<Catel.IDisposableToken<T>> dispose, object tag = null) { }
        public T Instance { get; }
        public object Tag { get; }
        protected override void DisposeManaged() { }
    }
    public class static Enum<TEnum>
        where TEnum :  struct, System.IComparable, System.IFormattable
    {
        public static TEnum ConvertFromOtherEnumValue(object inputEnumValue) { }
        public static string GetName(int value) { }
        public static string GetName(long value) { }
        public static string[] GetNames() { }
        public static System.Collections.Generic.List<TEnum> GetValues() { }
        public static TEnum Parse(string input, bool ignoreCase = False) { }
        public static System.Collections.Generic.List<TEnum> ToList() { }
        public static bool TryParse(string input, out System.Nullable<> result) { }
        public static bool TryParse(string input, out TEnum result) { }
        public static bool TryParse(string input, bool ignoreCase, out System.Nullable<> result) { }
        public static bool TryParse(string input, bool ignoreCase, out TEnum result) { }
        public class static DataBinding<TEnum>
            where TEnum :  struct, System.IComparable, System.IFormattable
        {
            public static System.Collections.Generic.IList<Catel.IBindableEnum<TEnum>> CreateList(Catel.Enum<TEnum>.DataBinding.FormatEnumName formatName = null) { }
            public delegate string FormatEnumName<TEnum>(TEnum value);
        }
        public class static Flags<TEnum>
            where TEnum :  struct, System.IComparable, System.IFormattable
        {
            public static TEnum ClearFlag(TEnum flags, TEnum flagToClear) { }
            public static TEnum ClearFlag(int flags, TEnum flagToClear) { }
            public static TEnum ClearFlag(long flags, TEnum flagToClear) { }
            public static TEnum ClearFlag(int flags, int flagToClear) { }
            public static TEnum ClearFlag(long flags, long flagToClear) { }
            public static TEnum[] GetValues(TEnum flags) { }
            public static bool IsFlagSet(TEnum flags, TEnum flagToFind) { }
            public static bool IsFlagSet(int flags, TEnum flagToFind) { }
            public static bool IsFlagSet(long flags, TEnum flagToFind) { }
            public static bool IsFlagSet(int flags, int flagToFind) { }
            public static bool IsFlagSet(long flags, long flagToFind) { }
            public static TEnum SetFlag(TEnum flags, TEnum flagToSet) { }
            public static TEnum SetFlag(int flags, TEnum flagToSet) { }
            public static TEnum SetFlag(long flags, TEnum flagToSet) { }
            public static TEnum SetFlag(int flags, int flagToSet) { }
            public static TEnum SetFlag(long flags, long flagToSet) { }
            public static TEnum SwapFlag(TEnum flags, TEnum flagToSwap) { }
            public static TEnum SwapFlag(int flags, TEnum flagToSwap) { }
            public static TEnum SwapFlag(long flags, TEnum flagToSwap) { }
            public static TEnum SwapFlag(int flags, int flagToSwap) { }
            public static TEnum SwapFlag(long flags, long flagToSwap) { }
        }
    }
    public class static EnvironmentHelper
    {
        public static bool IsProcessHostedByExpressionBlend { get; }
        public static bool IsProcessHostedBySharpDevelop { get; }
        public static bool IsProcessHostedByTool { get; }
        public static bool IsProcessHostedByVisualStudio { get; }
        public static bool IsProcessCurrentlyHostedByExpressionBlend(bool checkParentProcesses = False) { }
        public static bool IsProcessCurrentlyHostedBySharpDevelop(bool checkParentProcesses = False) { }
        public static bool IsProcessCurrentlyHostedByTool(bool checkParentProcesses = False) { }
        public static bool IsProcessCurrentlyHostedByVisualStudio(bool checkParentProcesses = False) { }
    }
    public class static EventHandlerExtensions
    {
        [System.ObsoleteAttribute("Use handler?.Invoke(this) instead, see https://github.com/Catel/Catel/issues/1258" +
            ". Will be removed in version 6.0.0.", true)]
        public static bool SafeInvoke(this System.EventHandler handler, object sender) { }
        [System.ObsoleteAttribute("Use handler?.Invoke(this) instead, see https://github.com/Catel/Catel/issues/1258" +
            ". Will be removed in version 6.0.0.", true)]
        public static bool SafeInvoke(this System.EventHandler<System.EventArgs> handler, object sender) { }
        [System.ObsoleteAttribute("Use handler?.Invoke(this) instead, see https://github.com/Catel/Catel/issues/1258" +
            ". Will be removed in version 6.0.0.", true)]
        public static bool SafeInvoke(this System.EventHandler handler, object sender, System.EventArgs e) { }
        [System.ObsoleteAttribute("Use handler?.Invoke(this) instead, see https://github.com/Catel/Catel/issues/1258" +
            ". Will be removed in version 6.0.0.", true)]
        public static bool SafeInvoke<TEventArgs>(this System.EventHandler<TEventArgs> handler, object sender, TEventArgs e)
            where TEventArgs : System.EventArgs { }
        [System.ObsoleteAttribute("Use handler?.Invoke(this) instead, see https://github.com/Catel/Catel/issues/1258" +
            ". Will be removed in version 6.0.0.", true)]
        public static bool SafeInvoke<TEventArgs>(this System.EventHandler<TEventArgs> handler, object sender, System.Func<TEventArgs> fE)
            where TEventArgs : System.EventArgs { }
        [System.ObsoleteAttribute("Use handler?.Invoke(this) instead, see https://github.com/Catel/Catel/issues/1258" +
            ". Will be removed in version 6.0.0.", true)]
        public static bool SafeInvoke(this System.ComponentModel.PropertyChangedEventHandler handler, object sender, System.ComponentModel.PropertyChangedEventArgs e) { }
        [System.ObsoleteAttribute("Use handler?.Invoke(this) instead, see https://github.com/Catel/Catel/issues/1258" +
            ". Will be removed in version 6.0.0.", true)]
        public static bool SafeInvoke(this System.ComponentModel.PropertyChangedEventHandler handler, object sender, System.Func<System.ComponentModel.PropertyChangedEventArgs> fE) { }
        [System.ObsoleteAttribute("Use handler?.Invoke(this) instead, see https://github.com/Catel/Catel/issues/1258" +
            ". Will be removed in version 6.0.0.", true)]
        public static bool SafeInvoke(this System.Collections.Specialized.NotifyCollectionChangedEventHandler handler, object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) { }
        [System.ObsoleteAttribute("Use handler?.Invoke(this) instead, see https://github.com/Catel/Catel/issues/1258" +
            ". Will be removed in version 6.0.0.", true)]
        public static bool SafeInvoke(this System.Collections.Specialized.NotifyCollectionChangedEventHandler handler, object sender, System.Func<System.Collections.Specialized.NotifyCollectionChangedEventArgs> fE) { }
        public static void UnsubscribeAllHandlers<TEventArgs>(this System.EventHandler<TEventArgs> handler)
            where TEventArgs : System.EventArgs { }
    }
    public class static ExceptionExtensions
    {
        public static TException Find<TException>(this System.Exception exception)
            where TException : System.Exception { }
        public static string Flatten(this System.Exception exception, string message = "", bool includeStackTrace = False) { }
        public static System.Collections.Generic.IEnumerable<System.Exception> GetAllInnerExceptions(this System.Exception exception) { }
        public static System.Exception GetLowestInnerException(this System.Exception exception) { }
        public static bool IsCritical(this System.Exception ex) { }
        public static System.Xml.Linq.XDocument ToXml(this System.Exception exception) { }
    }
    public class static ExceptionFactory
    {
        public static TException CreateException<TException>(string message, System.Exception innerException = null)
            where TException : System.Exception { }
        public static System.Exception CreateException(System.Type exceptionType, string message, System.Exception innerException = null) { }
        public static TException CreateException<TException>(object[] args)
            where TException : System.Exception { }
        public static System.Exception CreateException(System.Type exceptionType, object[] args) { }
    }
    public class static ExpressionHelper
    {
        public static object GetOwner<TProperty>(System.Linq.Expressions.Expression<System.Func<TProperty>> propertyExpression) { }
        public static string GetPropertyName<TSource, TProperty>(System.Linq.Expressions.Expression<System.Func<TSource, TProperty>> propertyExpression) { }
        public static string GetPropertyName<TProperty>(System.Linq.Expressions.Expression<System.Func<TProperty>> propertyExpression) { }
    }
    public class static FastDateTime
    {
        public static System.DateTime Now { get; }
        public static System.DateTime UtcNow { get; }
    }
    public class static HashHelper
    {
        public static int CombineHash(params int[] hashCodes) { }
    }
    public interface IBindableEnum<TEnum> : System.IComparable<Catel.IBindableEnum<TEnum>>, System.IEquatable<Catel.IBindableEnum<TEnum>>
        where TEnum :  struct, System.IComparable, System.IFormattable
    {
        string Name { get; }
        TEnum Value { get; }
    }
    public interface ICompositeFilter<T>
        where T :  class
    {
        Catel.CompositePredicate<T> Excludes { get; set; }
        Catel.CompositePredicate<T> Includes { get; set; }
        bool Matches(T target);
        bool MatchesObject(object target);
    }
    public interface IDisposableToken<T> : System.IDisposable
    {
        T Instance { get; }
        object Tag { get; }
    }
    public interface IExecute
    {
        bool Execute();
    }
    public interface IExecuteWithObject
    {
        bool ExecuteWithObject(object parameter);
    }
    public interface IExecuteWithObject<TResult>
    {
        bool ExecuteWithObject(object parameter, out TResult result);
    }
    public interface IExecute<TResult>
    {
        bool Execute(out TResult result);
    }
    public interface IFluent
    {
        bool Equals(object obj);
        int GetHashCode();
        System.Type GetType();
        string ToString();
    }
    public interface IUniqueIdentifyable
    {
        int UniqueIdentifier { get; }
    }
    public interface IWeakAction : Catel.IExecute, Catel.IWeakReference
    {
        System.Delegate Action { get; }
        string MethodName { get; }
    }
    public interface IWeakAction<TParameter> : Catel.IExecuteWithObject, Catel.IWeakReference
    {
        System.Delegate Action { get; }
        string MethodName { get; }
        bool Execute(TParameter parameter);
    }
    public interface IWeakEventListener
    {
        System.Type EventArgsType { get; }
        bool IsSourceAlive { get; }
        bool IsStaticEvent { get; }
        bool IsStaticEventHandler { get; }
        bool IsTargetAlive { get; }
        object Source { get; }
        System.Type SourceType { get; }
        System.WeakReference SourceWeakReference { get; }
        object Target { get; }
        System.Type TargetType { get; }
        System.WeakReference TargetWeakReference { get; }
        void Detach();
    }
    public interface IWeakFunc<TResult> : Catel.IExecute<TResult>, Catel.IWeakReference
    {
        System.Delegate Action { get; }
        string MethodName { get; }
    }
    public interface IWeakFunc<TParameter, TResult> : Catel.IExecuteWithObject<TResult>, Catel.IWeakReference
    {
        System.Delegate Action { get; }
        string MethodName { get; }
    }
    public interface IWeakReference
    {
        bool IsTargetAlive { get; }
        object Target { get; }
    }
    public enum KnownPlatforms
    {
        Unknown = 0,
        NET = 1,
        NET45 = 2,
        NET46 = 3,
        NET47 = 4,
        NET50 = 5,
        NetStandard = 6,
        NetStandard20 = 7,
        WindowsUniversal = 8,
        Xamarin = 9,
        XamarinAndroid = 10,
        XamariniOS = 11,
        XamarinForms = 12,
    }
    public class static LanguageHelper
    {
        public static string GetString(string resourceName, System.Globalization.CultureInfo culture = null) { }
    }
    public class MustBeImplementedException : System.Exception
    {
        public MustBeImplementedException() { }
    }
    public class NotSupportedInPlatformException : System.Exception
    {
        public NotSupportedInPlatformException() { }
        public NotSupportedInPlatformException(string message) { }
        public NotSupportedInPlatformException(string featureFormat = "", params object[] args) { }
        public Catel.SupportedPlatforms Platform { get; }
        public string Reason { get; }
    }
    public class static ObjectHelper
    {
        public static bool AreEqual(object object1, object object2) { }
        public static bool AreEqualReferences(object object1, object object2) { }
        public static bool IsNull(object obj) { }
    }
    public class static ObjectToStringHelper
    {
        public static System.Globalization.CultureInfo DefaultCulture { get; set; }
        public static string ToFullTypeString(object instance) { }
        public static string ToString(object instance) { }
        public static string ToString(object instance, System.Globalization.CultureInfo cultureInfo) { }
        public static string ToTypeString(object instance) { }
    }
    public delegate void OpenInstanceActionHandler<TTarget>(TTarget @this);
    public delegate void OpenInstanceEventHandler<TTarget, TEventArgs>(TTarget @this, object sender, TEventArgs e);
    public class static ParallelHelper
    {
        public static void ExecuteInParallel<T>(System.Collections.Generic.List<T> items, System.Action<T> actionToInvoke, int itemsPerBatch = 1000, string taskName = null) { }
        public static System.Threading.Tasks.Task ExecuteInParallelAsync(System.Collections.Generic.List<System.Func<System.Threading.Tasks.Task>> tasks, int batchSize = 1000, string taskName = null) { }
    }
    public class static Platforms
    {
        public static Catel.SupportedPlatforms CurrentPlatform { get; }
        public static bool IsPlatformSupported(Catel.KnownPlatforms platformToCheck) { }
        public static bool IsPlatformSupported(Catel.KnownPlatforms platformToCheck, Catel.SupportedPlatforms currentPlatform) { }
    }
    public class static ProcessExtensions
    {
        public static System.Diagnostics.Process GetParent(this System.Diagnostics.Process process) { }
    }
    public class ProgressContext : Catel.Disposable
    {
        public ProgressContext(long totalCount, int numberOfRefreshes) { }
        public long CurrentCount { get; set; }
        public int CurrentRefreshNumber { get; }
        public bool IsRefreshRequired { get; }
        public int NumberOfRefreshes { get; }
        public double Percentage { get; }
        public long TotalCount { get; }
    }
    public class static ResourceHelper
    {
        public static string ExtractEmbeddedResource(this System.Reflection.Assembly assembly, string relativeResourceName) { }
        public static void ExtractEmbeddedResource(this System.Reflection.Assembly assembly, string relativeResourceName, System.IO.Stream targetStream) { }
        public static void ExtractEmbeddedResource(this System.Reflection.Assembly assembly, string assemblyName, string relativeResourceName, System.IO.Stream targetStream) { }
        public static string GetString(System.Type callingType, string resourceFile, string resourceName) { }
        public static string GetString(string resourceName) { }
    }
    public class static StringExtensions
    {
        public static readonly System.Text.RegularExpressions.Regex SlugRegex;
        public static readonly System.Text.RegularExpressions.Regex WhiteSpaceRegex;
        public static bool ContainsIgnoreCase(this string str, string valueToCheck) { }
        public static bool EndsWithAny(this string str, params string[] values) { }
        public static bool EndsWithAnyIgnoreCase(this string str, params string[] values) { }
        public static bool EndsWithIgnoreCase(this string str, string valueToCheck) { }
        public static bool EqualsAny(this string str, params string[] values) { }
        public static bool EqualsAnyIgnoreCase(this string str, params string[] values) { }
        public static bool EqualsIgnoreCase(this string str, string valueToCheck) { }
        public static string GetSlug(this string input, string spaceReplacement = "", string dotReplacement = "", bool makeLowercase = True) { }
        public static int IndexOfIgnoreCase(this string str, string valueToCheck) { }
        public static string PrepareAsSearchFilter(this string filter) { }
        public static string RemoveDiacritics(this string value) { }
        public static string SplitCamelCase(this string value) { }
        public static bool StartsWithAny(this string str, params string[] values) { }
        public static bool StartsWithAnyIgnoreCase(this string str, params string[] values) { }
        public static bool StartsWithIgnoreCase(this string str, string valueToCheck) { }
    }
    public class static StringToObjectHelper
    {
        public static System.Globalization.CultureInfo DefaultCulture { get; set; }
        public static bool ToBool(string value) { }
        public static byte[] ToByteArray(string value) { }
        public static System.DateTime ToDateTime(string value) { }
        public static System.DateTime ToDateTime(string value, System.Globalization.CultureInfo cultureInfo) { }
        public static decimal ToDecimal(string value) { }
        public static decimal ToDecimal(string value, System.Globalization.CultureInfo cultureInfo) { }
        public static double ToDouble(string value) { }
        public static double ToDouble(string value, System.Globalization.CultureInfo cultureInfo) { }
        public static TEnumValue ToEnum<TEnumValue>(string value, TEnumValue defaultValue)
            where TEnumValue :  struct, System.IComparable, System.IFormattable { }
        public static float ToFloat(string value) { }
        public static float ToFloat(string value, System.Globalization.CultureInfo cultureInfo) { }
        public static System.Guid ToGuid(string value) { }
        public static int ToInt(string value) { }
        public static int ToInt(string value, System.Globalization.CultureInfo cultureInfo) { }
        public static long ToLong(string value) { }
        public static long ToLong(string value, System.Globalization.CultureInfo cultureInfo) { }
        public static object ToRightType(System.Type targetType, string value) { }
        public static object ToRightType(System.Type targetType, string value, System.Globalization.CultureInfo cultureInfo) { }
        public static short ToShort(string value) { }
        public static short ToShort(string value, System.Globalization.CultureInfo cultureInfo) { }
        public static string ToString(string value) { }
        public static System.TimeSpan ToTimeSpan(string value) { }
        public static System.TimeSpan ToTimeSpan(string value, System.Globalization.CultureInfo cultureInfo) { }
        public static System.Type ToType(string value) { }
        public static uint ToUInt(string value) { }
        public static uint ToUInt(string value, System.Globalization.CultureInfo cultureInfo) { }
        public static ulong ToULong(string value) { }
        public static ulong ToULong(string value, System.Globalization.CultureInfo cultureInfo) { }
        public static ushort ToUShort(string value) { }
        public static ushort ToUShort(string value, System.Globalization.CultureInfo cultureInfo) { }
        public static System.Uri ToUri(string value) { }
    }
    public enum SupportedPlatforms
    {
        NET45 = 0,
        NET46 = 1,
        NET47 = 2,
        NET50 = 3,
        NetStandard20 = 4,
        WindowsUniversal = 5,
        Android = 6,
        iOS = 7,
        XamarinForms = 8,
    }
    public class static TagHelper
    {
        public static bool AreTagsEqual(object firstTag, object secondTag) { }
        public static string ToString(object tag) { }
    }
    public class static ThreadHelper
    {
        public static int GetCurrentThreadId() { }
        public static void Sleep(int millisecondsTimeout) { }
        public static void SpinWait(int iterations) { }
    }
    public class static UniqueIdentifierHelper
    {
        public static int GetUniqueIdentifier<T>() { }
        public static int GetUniqueIdentifier(System.Type type) { }
    }
    public class static UriExtensions
    {
        public static string GetSafeUriString(this System.Uri uri) { }
        public static bool IsAbsoluteUrl(this string url) { }
    }
    public class WeakAction : Catel.WeakActionBase, Catel.IExecute, Catel.IWeakAction, Catel.IWeakReference
    {
        public WeakAction(object target, System.Action action) { }
        public System.Delegate Action { get; }
        public string MethodName { get; }
        public bool Execute() { }
        public delegate void OpenInstanceAction<TTarget>(TTarget @this);
    }
    public abstract class WeakActionBase : Catel.IWeakReference
    {
        protected WeakActionBase(object target) { }
        public bool IsTargetAlive { get; }
        public object Target { get; }
    }
    public class WeakAction<TParameter> : Catel.WeakActionBase, Catel.IExecuteWithObject, Catel.IWeakAction<TParameter>, Catel.IWeakReference
    {
        public WeakAction(object target, System.Action<TParameter> action) { }
        public System.Delegate Action { get; }
        public string MethodName { get; }
        public bool Execute(TParameter parameter) { }
        public delegate void OpenInstanceGenericAction<TParameter, TTarget>(TTarget @this, TParameter parameter);
    }
    public class static WeakEventListener
    {
        public static Catel.IWeakEventListener SubscribeToWeakCollectionChangedEvent(this object target, object source, System.Collections.Specialized.NotifyCollectionChangedEventHandler handler, bool throwWhenSubscriptionFails = True, string eventName = "CollectionChanged") { }
        public static Catel.IWeakEventListener SubscribeToWeakEvent(this object target, object source, string eventName, System.Action handler, bool throwWhenSubscriptionFails = True) { }
        public static Catel.IWeakEventListener SubscribeToWeakEvent(this object target, object source, string eventName, System.Delegate handler, bool throwWhenSubscriptionFails = True) { }
        public static Catel.IWeakEventListener SubscribeToWeakGenericEvent<TEventArgs>(this object target, object source, string eventName, System.EventHandler<TEventArgs> handler, bool throwWhenSubscriptionFails = True)
            where TEventArgs : System.EventArgs { }
        public static Catel.IWeakEventListener SubscribeToWeakPropertyChangedEvent(this object target, object source, System.ComponentModel.PropertyChangedEventHandler handler, bool throwWhenSubscriptionFails = True, string eventName = "PropertyChanged") { }
    }
    public class static WeakEventListener<TTarget, TSource>
        where TTarget :  class
        where TSource :  class
    {
        public static Catel.IWeakEventListener SubscribeToWeakCollectionChangedEvent(TTarget target, TSource source, System.Collections.Specialized.NotifyCollectionChangedEventHandler handler, bool throwWhenSubscriptionFails = True, string eventName = "CollectionChanged") { }
        public static Catel.IWeakEventListener SubscribeToWeakEvent(TTarget target, TSource source, string eventName, System.Delegate handler, bool throwWhenSubscriptionFails = True) { }
        public static Catel.IWeakEventListener SubscribeToWeakEventWithExplicitSourceType<TExplicitSourceType>(TTarget target, TSource source, string eventName, System.Delegate handler, bool throwWhenSubscriptionFails = True) { }
        public static Catel.IWeakEventListener SubscribeToWeakGenericEvent<TEventArgs>(TTarget target, TSource source, string eventName, System.EventHandler<TEventArgs> handler, bool throwWhenSubscriptionFails = True)
            where TEventArgs : System.EventArgs { }
        public static Catel.IWeakEventListener SubscribeToWeakPropertyChangedEvent(TTarget target, TSource source, System.ComponentModel.PropertyChangedEventHandler handler, bool throwWhenSubscriptionFails = True, string eventName = "PropertyChanged") { }
    }
    public class WeakEventListener<TTarget, TSource, TEventArgs> : Catel.IWeakEventListener
        where TTarget :  class
        where TSource :  class
    {
        public System.Type EventArgsType { get; }
        public bool IsSourceAlive { get; }
        public bool IsStaticEvent { get; }
        public bool IsStaticEventHandler { get; }
        public bool IsTargetAlive { get; }
        public object Source { get; }
        public System.Type SourceType { get; }
        public System.WeakReference SourceWeakReference { get; }
        public object Target { get; }
        public System.Type TargetType { get; }
        public System.WeakReference TargetWeakReference { get; }
        public void Detach() { }
        public void OnEvent(object source, TEventArgs eventArgs) { }
        public static Catel.IWeakEventListener SubscribeToWeakCollectionChangedEvent(TTarget target, TSource source, System.Collections.Specialized.NotifyCollectionChangedEventHandler handler, bool throwWhenSubscriptionFails = True, string eventName = "CollectionChanged") { }
        public static Catel.IWeakEventListener SubscribeToWeakEvent(TTarget target, TSource source, string eventName, System.Delegate handler, bool throwWhenSubscriptionFails = True) { }
        public static Catel.IWeakEventListener SubscribeToWeakEventWithExplicitSourceType<TExplicitSourceType>(TTarget target, TSource source, string eventName, System.Delegate handler, bool throwWhenSubscriptionFails = True)
            where TExplicitSourceType :  class { }
        public static Catel.IWeakEventListener SubscribeToWeakGenericEvent(TTarget target, TSource source, string eventName, System.EventHandler<TEventArgs> handler, bool throwWhenSubscriptionFails = True) { }
        public static Catel.IWeakEventListener SubscribeToWeakPropertyChangedEvent(TTarget target, TSource source, System.ComponentModel.PropertyChangedEventHandler handler, bool throwWhenSubscriptionFails = True, string eventName = "PropertyChanged") { }
    }
    public class WeakFunc<TResult> : Catel.WeakActionBase, Catel.IExecute<TResult>, Catel.IWeakFunc<TResult>, Catel.IWeakReference
    {
        public WeakFunc(object target, System.Func<TResult> func) { }
        public System.Delegate Action { get; }
        public string MethodName { get; }
        public bool Execute(out TResult result) { }
        public delegate TResult OpenInstanceAction<TResult, TTarget>(TTarget @this);
    }
    public class WeakFunc<TParameter, TResult> : Catel.WeakActionBase, Catel.IExecuteWithObject<TResult>, Catel.IWeakFunc<TParameter, TResult>, Catel.IWeakReference
    {
        public WeakFunc(object target, System.Func<TParameter, TResult> func) { }
        public System.Delegate Action { get; }
        public string MethodName { get; }
        public bool Execute(TParameter parameter, out TResult result) { }
        public delegate TResult OpenInstanceGenericAction<TParameter, TResult, TTarget>(TTarget @this, TParameter parameter);
    }
}
namespace Catel.Caching
{
    public class CacheStorage<TKey, TValue> : Catel.Caching.ICacheStorage<TKey, TValue>
    {
        public CacheStorage(System.Func<Catel.Caching.Policies.ExpirationPolicy> defaultExpirationPolicyInitCode = null, bool storeNullValues = False, System.Collections.Generic.IEqualityComparer<TKey> equalityComparer = null) { }
        public bool DisposeValuesOnRemoval { get; set; }
        public System.TimeSpan ExpirationTimerInterval { get; set; }
        public TValue this[TKey key] { get; }
        public System.Collections.Generic.IEnumerable<TKey> Keys { get; }
        public event System.EventHandler<Catel.Caching.ExpiredEventArgs<TKey, TValue>> Expired;
        public event System.EventHandler<Catel.Caching.ExpiringEventArgs<TKey, TValue>> Expiring;
        public void Add(TKey key, TValue value, bool override = False, System.TimeSpan expiration = null) { }
        public void Add(TKey key, TValue value, Catel.Caching.Policies.ExpirationPolicy expirationPolicy, bool override = False) { }
        public void Clear() { }
        public bool Contains(TKey key) { }
        public TValue Get(TKey key) { }
        public TValue GetFromCacheOrFetch(TKey key, System.Func<TValue> code, Catel.Caching.Policies.ExpirationPolicy expirationPolicy, bool override = False) { }
        public TValue GetFromCacheOrFetch(TKey key, System.Func<TValue> code, bool override = False, System.TimeSpan expiration = null) { }
        public System.Threading.Tasks.Task<TValue> GetFromCacheOrFetchAsync(TKey key, System.Func<System.Threading.Tasks.Task<TValue>> code, Catel.Caching.Policies.ExpirationPolicy expirationPolicy, bool override = False) { }
        public System.Threading.Tasks.Task<TValue> GetFromCacheOrFetchAsync(TKey key, System.Func<System.Threading.Tasks.Task<TValue>> code, bool override = False, System.TimeSpan expiration = null) { }
        public void Remove(TKey key, System.Action action = null) { }
    }
    public class ExpiredEventArgs<TKey, TValue> : System.EventArgs
    {
        public ExpiredEventArgs(TKey key, TValue value, bool dispose) { }
        public bool Dispose { get; set; }
        public TKey Key { get; }
        public TValue Value { get; }
    }
    public class ExpiringEventArgs<TKey, TValue> : System.EventArgs
    {
        public ExpiringEventArgs(TKey key, TValue value, Catel.Caching.Policies.ExpirationPolicy expirationPolicy) { }
        public bool Cancel { get; set; }
        public Catel.Caching.Policies.ExpirationPolicy ExpirationPolicy { get; set; }
        public TKey Key { get; }
        public TValue Value { get; }
    }
    public interface ICacheStorage<TKey, TValue>
    {
        bool DisposeValuesOnRemoval { get; set; }
        System.TimeSpan ExpirationTimerInterval { get; set; }
        TValue this[TKey key] { get; }
        System.Collections.Generic.IEnumerable<TKey> Keys { get; }
        public event System.EventHandler<Catel.Caching.ExpiredEventArgs<TKey, TValue>> Expired;
        public event System.EventHandler<Catel.Caching.ExpiringEventArgs<TKey, TValue>> Expiring;
        void Add(TKey key, TValue value, bool override = False, System.TimeSpan expiration = null);
        void Add(TKey key, TValue value, Catel.Caching.Policies.ExpirationPolicy expirationPolicy, bool override = False);
        void Clear();
        bool Contains(TKey key);
        TValue Get(TKey key);
        TValue GetFromCacheOrFetch(TKey key, System.Func<TValue> code, bool override = False, System.TimeSpan expiration = null);
        TValue GetFromCacheOrFetch(TKey key, System.Func<TValue> code, Catel.Caching.Policies.ExpirationPolicy expirationPolicy, bool override = False);
        System.Threading.Tasks.Task<TValue> GetFromCacheOrFetchAsync(TKey key, System.Func<System.Threading.Tasks.Task<TValue>> code, Catel.Caching.Policies.ExpirationPolicy expirationPolicy, bool override = False);
        System.Threading.Tasks.Task<TValue> GetFromCacheOrFetchAsync(TKey key, System.Func<System.Threading.Tasks.Task<TValue>> code, bool override = False, System.TimeSpan expiration = null);
        void Remove(TKey key, System.Action action = null);
    }
}
namespace Catel.Caching.Policies
{
    public class AbsoluteExpirationPolicy : Catel.Caching.Policies.ExpirationPolicy
    {
        protected AbsoluteExpirationPolicy(System.DateTime absoluteExpirationDateTime, bool canReset) { }
        protected System.DateTime AbsoluteExpirationDateTime { get; set; }
        public override bool IsExpired { get; }
    }
    public sealed class CompositeExpirationPolicy : Catel.Caching.Policies.ExpirationPolicy
    {
        public CompositeExpirationPolicy(bool expiresOnlyIfAllPoliciesExpires = False) { }
        public override bool CanReset { get; }
        public override bool IsExpired { get; }
        public Catel.Caching.Policies.CompositeExpirationPolicy Add(Catel.Caching.Policies.ExpirationPolicy expirationPolicy) { }
        protected override void OnReset() { }
    }
    public sealed class CustomExpirationPolicy : Catel.Caching.Policies.ExpirationPolicy
    {
        public CustomExpirationPolicy(System.Func<bool> isExpiredFunc = null, System.Action resetAction = null) { }
        public override bool IsExpired { get; }
        protected override void OnReset() { }
    }
    public class DurationExpirationPolicy : Catel.Caching.Policies.AbsoluteExpirationPolicy
    {
        protected DurationExpirationPolicy(System.TimeSpan durationTimeSpan, bool canReset) { }
        protected System.TimeSpan DurationTimeSpan { get; set; }
    }
    public abstract class ExpirationPolicy
    {
        protected ExpirationPolicy(bool canReset = False) { }
        public bool CanReset { get; }
        public abstract bool IsExpired { get; }
        protected bool IsResting { get; }
        public static Catel.Caching.Policies.ExpirationPolicy Absolute(System.DateTime absoluteExpirationDateTime, bool force = False) { }
        public static Catel.Caching.Policies.ExpirationPolicy Custom(System.Func<bool> isExpiredFunc, System.Action resetAction = null, bool force = False) { }
        public static Catel.Caching.Policies.ExpirationPolicy Duration(System.TimeSpan durationTimeSpan, bool force = False) { }
        protected virtual void OnReset() { }
        public void Reset() { }
        public static Catel.Caching.Policies.ExpirationPolicy Sliding(System.TimeSpan durationTimeSpan, bool force = False) { }
    }
    public sealed class SlidingExpirationPolicy : Catel.Caching.Policies.DurationExpirationPolicy
    {
        protected override void OnReset() { }
    }
}
namespace Catel.Collections
{
    public class static ArrayShim
    {
        public static T[] Empty<T>() { }
    }
    public class static CollectionExtensions
    {
        public static void AddRange<T>(this System.Collections.Generic.ICollection<T> collection, System.Collections.Generic.IEnumerable<T> range) { }
        public static bool CanMoveItemDown(this System.Collections.IList list, object item) { }
        public static bool CanMoveItemUp(this System.Collections.IList list, object item) { }
        public static void ForEach<TItem>(this System.Collections.Generic.IEnumerable<TItem> collection, System.Action<TItem> action) { }
        public static int IndexOf<T>(this System.Collections.Generic.IList<T> list, T item, int index) { }
        public static bool MoveItemDown(this System.Collections.IList list, object item) { }
        public static bool MoveItemDownByIndex(this System.Collections.IList list, int index) { }
        public static bool MoveItemUp(this System.Collections.IList list, object item) { }
        public static bool MoveItemUpByIndex(this System.Collections.IList list, int index) { }
        public static void RemoveFirst(this System.Collections.IList list) { }
        public static void RemoveLast(this System.Collections.IList list) { }
        public static void ReplaceRange<T>(this System.Collections.Generic.ICollection<T> collection, System.Collections.Generic.IEnumerable<T> range) { }
        public static void Sort<T>(this System.Collections.Generic.IList<T> existingSet, System.Func<T, T, int> comparer = null) { }
        public static System.Collections.Generic.IEnumerable<T> SynchronizeCollection<T>(this System.Collections.Generic.IList<T> existingSet, System.Collections.Generic.IEnumerable<T> newSet, bool updateExistingSet = True) { }
        public static System.Collections.Generic.IEnumerable<T> SynchronizeCollection<T>(this System.Collections.Generic.ICollection<T> existingSet, System.Collections.Generic.IEnumerable<T> newSet, bool updateExistingSet = True) { }
        public static System.Array ToArray(this System.Collections.IEnumerable collection, System.Type elementType) { }
    }
    public class static CollectionHelper
    {
        public static bool IsEqualTo(System.Collections.IEnumerable listA, System.Collections.IEnumerable listB) { }
    }
    public class static DictionaryExtensions
    {
        public static void AddItemIfNotEmpty<TKey>(this System.Collections.Generic.Dictionary<TKey, string> dictionary, TKey key, string value) { }
        public static void AddRange<TKey, TValue>(this System.Collections.Generic.Dictionary<TKey, TValue> target, System.Collections.Generic.Dictionary<TKey, TValue> source, bool overwriteExisting = True) { }
    }
    public class static HashSetExtensions
    {
        public static void AddRange<T>(this System.Collections.Generic.HashSet<T> hashSet, System.Collections.Generic.IEnumerable<T> items) { }
    }
    public interface ISuspendChangeNotificationsCollection : System.Collections.ICollection, System.Collections.IEnumerable
    {
        bool IsDirty { get; }
        bool NotificationsSuspended { get; }
        void Reset();
        System.IDisposable SuspendChangeNotifications();
        System.IDisposable SuspendChangeNotifications(Catel.Collections.SuspensionMode mode);
    }
    public class ListDictionary<TKey, TValue> : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.Generic.IDictionary<TKey, TValue>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.IEnumerable
    {
        public ListDictionary() { }
        public ListDictionary(System.Collections.Generic.IEqualityComparer<TKey> comparer) { }
        public int Count { get; }
        public bool IsReadOnly { get; }
        public TValue this[TKey key] { get; set; }
        public System.Collections.Generic.ICollection<TKey> Keys { get; }
        public System.Collections.Generic.ICollection<TValue> Values { get; }
        public void Add(System.Collections.Generic.KeyValuePair<TKey, TValue> item) { }
        public void Add(TKey key, TValue value) { }
        public void Clear() { }
        public bool Contains(System.Collections.Generic.KeyValuePair<TKey, TValue> item) { }
        public bool ContainsKey(TKey key) { }
        public void CopyTo(System.Collections.Generic.KeyValuePair<, >[] array, int arrayIndex) { }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>> GetEnumerator() { }
        public bool Remove(System.Collections.Generic.KeyValuePair<TKey, TValue> item) { }
        public bool Remove(TKey key) { }
        public bool TryGetValue(TKey key, out TValue value) { }
    }
    public enum SuspensionMode
    {
        None = 0,
        Adding = 1,
        Removing = 2,
        Mixed = 3,
        MixedBash = 4,
        MixedConsolidate = 5,
        Silent = 6,
    }
}
namespace Catel.ComponentModel
{
    [System.AttributeUsageAttribute(System.AttributeTargets.Class | System.AttributeTargets.Enum | System.AttributeTargets.Method | System.AttributeTargets.Property | System.AttributeTargets.Field | System.AttributeTargets.Event | System.AttributeTargets.All)]
    public class DisplayNameAttribute : System.ComponentModel.DisplayNameAttribute
    {
        public DisplayNameAttribute(string resourceName) { }
        public override string DisplayName { get; }
        public Catel.Services.ILanguageService LanguageService { get; set; }
        public string ResourceName { get; }
    }
}
namespace Catel.Configuration
{
    public class ConfigurationChangedEventArgs : System.EventArgs
    {
        public ConfigurationChangedEventArgs(Catel.Configuration.ConfigurationContainer container, string key, object newValue) { }
        public Catel.Configuration.ConfigurationContainer Container { get; }
        public string Key { get; }
        public object NewValue { get; }
    }
    public enum ConfigurationContainer
    {
        Local = 0,
        Roaming = 1,
    }
    public class static ConfigurationExtensions
    {
        public static TSection GetSection<TSection>(this System.Configuration.Configuration @this, string sectionName, string sectionGroupName = null)
            where TSection : System.Configuration.ConfigurationSection { }
        public static bool IsConfigurationKey(this Catel.Configuration.ConfigurationChangedEventArgs eventArgs, string expectedKey) { }
        public static bool IsConfigurationKey(this string key, string expectedKey) { }
    }
    public class ConfigurationService : Catel.Configuration.IConfigurationService
    {
        public ConfigurationService(Catel.Runtime.Serialization.ISerializationManager serializationManager, Catel.Services.IObjectConverterService objectConverterService, Catel.Runtime.Serialization.Xml.IXmlSerializer serializer) { }
        public ConfigurationService(Catel.Runtime.Serialization.ISerializationManager serializationManager, Catel.Services.IObjectConverterService objectConverterService, Catel.Runtime.Serialization.ISerializer serializer) { }
        public event System.EventHandler<Catel.Configuration.ConfigurationChangedEventArgs> ConfigurationChanged;
        protected virtual string GetFinalKey(string key) { }
        protected virtual Catel.Configuration.DynamicConfiguration GetSettingsContainer(Catel.Configuration.ConfigurationContainer container) { }
        public T GetValue<T>(Catel.Configuration.ConfigurationContainer container, string key, T defaultValue = null) { }
        protected virtual string GetValueFromStore(Catel.Configuration.ConfigurationContainer container, string key) { }
        public void InitializeValue(Catel.Configuration.ConfigurationContainer container, string key, object defaultValue) { }
        public bool IsValueAvailable(Catel.Configuration.ConfigurationContainer container, string key) { }
        public void SetLocalConfigFilePath(string filePath) { }
        public void SetRoamingConfigFilePath(string filePath) { }
        public void SetValue(Catel.Configuration.ConfigurationContainer container, string key, object value) { }
        protected virtual void SetValueToStore(Catel.Configuration.ConfigurationContainer container, string key, string value) { }
        public System.IDisposable SuspendNotifications() { }
        protected virtual bool ValueExists(Catel.Configuration.ConfigurationContainer container, string key) { }
    }
    [Catel.Runtime.Serialization.SerializerModifierAttribute(typeof(Catel.Configuration.DynamicConfigurationSerializerModifier))]
    public class DynamicConfiguration : Catel.Data.ModelBase
    {
        public DynamicConfiguration() { }
        public object GetConfigurationValue(string name) { }
        public bool IsConfigurationValueSet(string name) { }
        public void MarkConfigurationValueAsSet(string name) { }
        public void RegisterConfigurationKey(string name) { }
        public void SetConfigurationValue(string name, object value) { }
    }
    public class static DynamicConfigurationExtensions
    {
        public static TValue GetConfigurationValue<TValue>(this Catel.Configuration.DynamicConfiguration dynamicConfiguration, string name, TValue defaultValue) { }
    }
    public class DynamicConfigurationSerializerModifier : Catel.Runtime.Serialization.SerializerModifierBase
    {
        public DynamicConfigurationSerializerModifier(Catel.Runtime.Serialization.ISerializationManager serializationManager) { }
        public override void OnDeserializing(Catel.Runtime.Serialization.ISerializationContext context, object model) { }
        public override void OnSerializing(Catel.Runtime.Serialization.ISerializationContext context, object model) { }
    }
    public interface IConfigurationService
    {
        public event System.EventHandler<Catel.Configuration.ConfigurationChangedEventArgs> ConfigurationChanged;
        T GetValue<T>(Catel.Configuration.ConfigurationContainer container, string key, T defaultValue = null);
        void InitializeValue(Catel.Configuration.ConfigurationContainer container, string key, object defaultValue);
        bool IsValueAvailable(Catel.Configuration.ConfigurationContainer container, string key);
        void SetLocalConfigFilePath(string filePath);
        void SetRoamingConfigFilePath(string filePath);
        void SetValue(Catel.Configuration.ConfigurationContainer container, string key, object value);
        System.IDisposable SuspendNotifications();
    }
    public class static IConfigurationServiceExtensions
    {
        public static T GetLocalValue<T>(this Catel.Configuration.IConfigurationService configurationService, string key, T defaultValue = null) { }
        public static T GetRoamingValue<T>(this Catel.Configuration.IConfigurationService configurationService, string key, T defaultValue = null) { }
        public static void InitializeLocalValue(this Catel.Configuration.IConfigurationService configurationService, string key, object defaultValue) { }
        public static void InitializeRoamingValue(this Catel.Configuration.IConfigurationService configurationService, string key, object defaultValue) { }
        public static bool IsLocalValueAvailable(this Catel.Configuration.IConfigurationService configurationService, string key) { }
        public static bool IsRoamingValueAvailable(this Catel.Configuration.IConfigurationService configurationService, string key) { }
        public static void SetLocalValue(this Catel.Configuration.IConfigurationService configurationService, string key, object value) { }
        public static void SetRoamingValue(this Catel.Configuration.IConfigurationService configurationService, string key, object value) { }
    }
}
namespace Catel.Core
{
    public class static ModuleInitializer
    {
        public static void Initialize() { }
    }
}
namespace Catel.Data
{
    public class AdvancedPropertyChangedEventArgs : System.ComponentModel.PropertyChangedEventArgs
    {
        public AdvancedPropertyChangedEventArgs(object sender, Catel.Data.AdvancedPropertyChangedEventArgs e) { }
        public AdvancedPropertyChangedEventArgs(object sender, string propertyName) { }
        public AdvancedPropertyChangedEventArgs(object sender, string propertyName, object newValue) { }
        public AdvancedPropertyChangedEventArgs(object sender, string propertyName, object oldValue, object newValue) { }
        public AdvancedPropertyChangedEventArgs(object originalSender, object latestSender, string propertyName) { }
        public AdvancedPropertyChangedEventArgs(object originalSender, object latestSender, string propertyName, object newValue) { }
        public AdvancedPropertyChangedEventArgs(object originalSender, object latestSender, string propertyName, object oldValue, object newValue) { }
        public bool IsNewValueMeaningful { get; }
        public bool IsOldValueMeaningful { get; }
        public object LatestSender { get; }
        public object NewValue { get; }
        public object OldValue { get; }
        public object OriginalSender { get; }
    }
    public class AttributeValidatorProvider : Catel.Data.ValidatorProviderBase
    {
        public AttributeValidatorProvider() { }
        protected override Catel.Data.IValidator GetValidator(System.Type targetType) { }
    }
    public class BoxingCache<T>
        where T :  struct
    {
        public BoxingCache() { }
        protected T AddBoxedValue(object boxedValue) { }
        protected object AddUnboxedValue(T value) { }
        public object GetBoxedValue(T value) { }
        public T GetUnboxedValue(object boxedValue) { }
    }
    public class BusinessRuleValidationResult : Catel.Data.ValidationResult, Catel.Data.IBusinessRuleValidationResult, Catel.Data.IValidationResult
    {
        public BusinessRuleValidationResult(Catel.Data.ValidationResultType validationResultType, string messageFormat, params object[] args) { }
        public static Catel.Data.BusinessRuleValidationResult CreateError(string messageFormat, params object[] args) { }
        public static Catel.Data.BusinessRuleValidationResult CreateErrorWithTag(string message, object tag) { }
        public static Catel.Data.BusinessRuleValidationResult CreateWarning(string messageFormat, params object[] args) { }
        public static Catel.Data.BusinessRuleValidationResult CreateWarningWithTag(string message, object tag) { }
        public override string ToString() { }
    }
    public class CatelTypeInfo
    {
        public CatelTypeInfo(System.Type type) { }
        public bool IsRegisterPropertiesCalled { get; }
        public System.Type Type { get; }
        public System.Collections.Generic.IDictionary<string, Catel.Data.PropertyData> GetCatelProperties() { }
        public System.Collections.Generic.IDictionary<string, Catel.Reflection.CachedPropertyInfo> GetNonCatelProperties() { }
        public Catel.Data.PropertyData GetPropertyData(string name) { }
        public bool IsPropertyRegistered(string name) { }
        public void RegisterProperties() { }
        public void RegisterProperty(string name, Catel.Data.PropertyData propertyData) { }
        public void UnregisterProperty(string name) { }
    }
    public class ChangeNotificationWrapper
    {
        public ChangeNotificationWrapper(object value) { }
        public bool IsObjectAlive { get; }
        public bool SupportsNotifyCollectionChanged { get; }
        public bool SupportsNotifyPropertyChanged { get; }
        public event System.Collections.Specialized.NotifyCollectionChangedEventHandler CollectionChanged;
        public event System.ComponentModel.PropertyChangedEventHandler CollectionItemPropertyChanged;
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        public static bool IsUsefulForObject(object obj) { }
        public void OnObjectCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) { }
        public void OnObjectCollectionItemPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) { }
        public void OnObjectPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) { }
        public void SubscribeNotifyChangedEvents(object value, System.Collections.ICollection parentCollection) { }
        public void UnsubscribeFromAllEvents() { }
        public void UnsubscribeNotifyChangedEvents(object value, System.Collections.ICollection parentCollection) { }
        public void UpdateCollectionSubscriptions(System.Collections.ICollection collection) { }
    }
    public abstract class ChildAwareModelBase : Catel.Data.ValidatableModelBase
    {
        protected ChildAwareModelBase() { }
        protected ChildAwareModelBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public static bool DefaultDisableEventSubscriptionsOfChildValuesValue { get; set; }
        protected bool DisableEventSubscriptionsOfChildValues { get; set; }
        [System.ComponentModel.BrowsableAttribute(false)]
        protected bool HandlePropertyAndCollectionChanges { get; set; }
        protected virtual void OnPropertyObjectCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) { }
        protected virtual void OnPropertyObjectCollectionItemPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) { }
        protected virtual void OnPropertyObjectPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) { }
        protected override void SetValueToPropertyBag(string propertyName, object value) { }
    }
    public abstract class ComparableModelBase : Catel.Data.ModelBase
    {
        protected ComparableModelBase() { }
        protected ComparableModelBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        protected Catel.Data.IModelEqualityComparer EqualityComparer { get; set; }
        public override bool Equals(object obj) { }
        public override int GetHashCode() { }
        public static bool ==(Catel.Data.ComparableModelBase firstObject, Catel.Data.ComparableModelBase secondObject) { }
        public static bool !=(Catel.Data.ComparableModelBase firstObject, Catel.Data.ComparableModelBase secondObject) { }
    }
    public sealed class CompositeValidator : Catel.Data.IValidator
    {
        public CompositeValidator() { }
        public void Add(Catel.Data.IValidator validator) { }
        public void AfterValidateBusinessRules(object instance, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> validationResults) { }
        public void AfterValidateFields(object instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> validationResults) { }
        public void AfterValidation(object instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> fieldValidationResults, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> businessRuleValidationResults) { }
        public void BeforeValidateBusinessRules(object instance, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> previousValidationResults) { }
        public void BeforeValidateFields(object instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> previousValidationResults) { }
        public void BeforeValidation(object instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> previousFieldValidationResults, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> previousBusinessRuleValidationResults) { }
        public bool Contains(Catel.Data.IValidator validator) { }
        public void Remove(Catel.Data.IValidator validator) { }
        public void Validate(object instance, Catel.Data.ValidationContext validationContext) { }
        public void ValidateBusinessRules(object instance, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> validationResults) { }
        public void ValidateFields(object instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> validationResults) { }
    }
    public class CompositeValidatorProvider : Catel.Data.ValidatorProviderBase
    {
        public CompositeValidatorProvider() { }
        public void Add(Catel.Data.IValidatorProvider validatorProvider) { }
        public bool Contains(Catel.Data.IValidatorProvider validatorProvider) { }
        protected override Catel.Data.IValidator GetValidator(System.Type targetType) { }
        public void Remove(Catel.Data.IValidatorProvider validatorProvider) { }
    }
    public class static EditableObjectHelper
    {
        public static void BeginEditObject(object obj) { }
        public static void CancelEditObject(object obj) { }
        public static void EndEditObject(object obj) { }
    }
    public enum EventChangeType
    {
        Property = 0,
        Collection = 1,
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Property | System.AttributeTargets.All, AllowMultiple=false, Inherited=true)]
    public class ExcludeFromValidationAttribute : System.Attribute
    {
        public ExcludeFromValidationAttribute() { }
    }
    public class FieldValidationResult : Catel.Data.ValidationResult, Catel.Data.IFieldValidationResult, Catel.Data.IValidationResult
    {
        public FieldValidationResult(Catel.Data.PropertyData property, Catel.Data.ValidationResultType validationResultType, string messageFormat, params object[] args) { }
        public FieldValidationResult(string propertyName, Catel.Data.ValidationResultType validationResultType, string messageFormat, params object[] args) { }
        public string PropertyName { get; }
        public static Catel.Data.FieldValidationResult CreateError(Catel.Data.PropertyData propertyData, string messageFormat, params object[] args) { }
        public static Catel.Data.FieldValidationResult CreateError(string propertyName, string messageFormat, params object[] args) { }
        public static Catel.Data.FieldValidationResult CreateError<TProperty>(System.Linq.Expressions.Expression<System.Func<TProperty>> propertyExpression, string messageFormat, params object[] args) { }
        public static Catel.Data.FieldValidationResult CreateErrorWithTag(Catel.Data.PropertyData propertyData, string message, object tag) { }
        public static Catel.Data.FieldValidationResult CreateErrorWithTag(string propertyName, string message, object tag) { }
        public static Catel.Data.FieldValidationResult CreateErrorWithTag<TProperty>(System.Linq.Expressions.Expression<System.Func<TProperty>> propertyExpression, string message, object tag) { }
        public static Catel.Data.FieldValidationResult CreateWarning(Catel.Data.PropertyData propertyData, string messageFormat, params object[] args) { }
        public static Catel.Data.FieldValidationResult CreateWarning(string propertyName, string messageFormat, params object[] args) { }
        public static Catel.Data.FieldValidationResult CreateWarning<TProperty>(System.Linq.Expressions.Expression<System.Func<TProperty>> propertyExpression, string messageFormat, params object[] args) { }
        public static Catel.Data.FieldValidationResult CreateWarningWithTag(Catel.Data.PropertyData propertyData, string message, object tag) { }
        public static Catel.Data.FieldValidationResult CreateWarningWithTag(string propertyName, string message, object tag) { }
        public static Catel.Data.FieldValidationResult CreateWarningWithTag<TProperty>(System.Linq.Expressions.Expression<System.Func<TProperty>> propertyExpression, string message, object tag) { }
        public override string ToString() { }
    }
    public interface IAdvancedNotifyPropertyChanged : System.ComponentModel.INotifyPropertyChanged { }
    public interface IBusinessRuleValidationResult : Catel.Data.IValidationResult { }
    public interface IFieldValidationResult : Catel.Data.IValidationResult
    {
        string PropertyName { get; }
    }
    public interface IFreezable
    {
        bool IsFrozen { get; }
        void Freeze();
        void Unfreeze();
    }
    public interface IModel : Catel.Data.IFreezable, Catel.Data.IModelEditor, Catel.Data.IModelSerialization, Catel.Runtime.Serialization.ISerializable, System.ComponentModel.IAdvancedEditableObject, System.ComponentModel.IEditableObject, System.ComponentModel.INotifyPropertyChanged, System.Runtime.Serialization.ISerializable, System.Xml.Serialization.IXmlSerializable
    {
        bool IsDirty { get; }
        bool IsInEditSession { get; }
        string KeyName { get; }
        object GetDefaultValue(string name);
        TValue GetDefaultValue<TValue>(string name);
        System.Type GetPropertyType(string name);
    }
    public interface IModelEditor
    {
        object GetValue(string propertyName);
        TValue GetValue<TValue>(string propertyName);
        object GetValueFastButUnsecure(string propertyName);
        void SetValue(string propertyName, object value);
        void SetValueFastButUnsecure(string propertyName, object value);
    }
    public interface IModelEqualityComparer : System.Collections.IEqualityComparer
    {
        bool CompareCollections { get; set; }
        bool CompareProperties { get; set; }
        bool CompareValues { get; set; }
    }
    public class static IModelExtensions
    {
        public static void ClearIsDirtyOnAllChildren(this Catel.Data.IModel model, bool suspendNotifications = False) { }
        [System.ObsoleteAttribute("Use `ClearIsDirtyOnAllChildren(IModel, bool)` instead. Will be removed in version" +
            " 6.0.0.", true)]
        public static void ClearIsDirtyOnAllChilds(this Catel.Data.IModel model) { }
        public static byte[] ToByteArray(this Catel.Data.IModel model, Catel.Runtime.Serialization.ISerializer serializer, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        public static System.Xml.Linq.XDocument ToXml(this Catel.Data.IModel model, Catel.Runtime.Serialization.ISerializer serializer, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
    }
    public interface IModelSerialization : Catel.Runtime.Serialization.ISerializable, System.Runtime.Serialization.ISerializable, System.Xml.Serialization.IXmlSerializable { }
    public interface ISavableModel : Catel.Data.IFreezable, Catel.Data.IModel, Catel.Data.IModelEditor, Catel.Data.IModelSerialization, Catel.Runtime.Serialization.ISerializable, System.ComponentModel.IAdvancedEditableObject, System.ComponentModel.IEditableObject, System.ComponentModel.INotifyPropertyChanged, System.Runtime.Serialization.ISerializable, System.Xml.Serialization.IXmlSerializable
    {
        void Save(System.IO.Stream stream, Catel.Runtime.Serialization.ISerializer serializer, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null);
    }
    public class static ISavableModelExtensions
    {
        public static void Save(this Catel.Data.ISavableModel model, string fileName, Catel.Runtime.Serialization.ISerializer serializer, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
    }
    public interface IValidatable : System.ComponentModel.IDataErrorInfo, System.ComponentModel.IDataWarningInfo, System.ComponentModel.INotifyDataErrorInfo, System.ComponentModel.INotifyDataWarningInfo
    {
        bool IsHidingValidationResults { get; }
        bool IsValidated { get; }
        Catel.Data.IValidationContext ValidationContext { get; }
        Catel.Data.IValidator Validator { get; set; }
        public event System.EventHandler<Catel.Data.ValidationEventArgs> Validated;
        public event System.EventHandler<Catel.Data.ValidationEventArgs> Validating;
        void Validate(bool force = False);
    }
    public class static IValidatableExtensions
    {
        public static void AddBusinessRuleValidationResult(this Catel.Data.IValidatable validatable, Catel.Data.IBusinessRuleValidationResult businessRuleValidationResult, bool validate = False) { }
        public static void AddFieldValidationResult(this Catel.Data.IValidatable validatable, Catel.Data.IFieldValidationResult fieldValidationResult, bool validate = False) { }
        public static string GetBusinessRuleErrors(this Catel.Data.IValidatable validatable) { }
        public static string GetBusinessRuleWarnings(this Catel.Data.IValidatable validatable) { }
        public static string GetErrorMessage(this Catel.Data.IValidatable validatable, string userFriendlyObjectName = null) { }
        public static string GetFieldErrors(this Catel.Data.IValidatable validatable, string columnName) { }
        public static string GetFieldWarnings(this Catel.Data.IValidatable validatable, string columnName) { }
        public static Catel.Data.IValidationContext GetValidationContext(this Catel.Data.IValidatable validatable) { }
        public static string GetWarningMessage(this Catel.Data.IValidatable validatable, string userFriendlyObjectName = null) { }
    }
    public interface IValidatableModel : Catel.Data.IFreezable, Catel.Data.IModel, Catel.Data.IModelEditor, Catel.Data.IModelSerialization, Catel.Data.IValidatable, Catel.Runtime.Serialization.ISerializable, System.ComponentModel.IAdvancedEditableObject, System.ComponentModel.IDataErrorInfo, System.ComponentModel.IDataWarningInfo, System.ComponentModel.IEditableObject, System.ComponentModel.INotifyDataErrorInfo, System.ComponentModel.INotifyDataWarningInfo, System.ComponentModel.INotifyPropertyChanged, System.Runtime.Serialization.ISerializable, System.Xml.Serialization.IXmlSerializable { }
    public class static IValidatableModelExtensions
    {
        public static Catel.Data.IValidationContext GetValidationContextForObjectGraph(this Catel.Data.IValidatableModel model) { }
    }
    public interface IValidationContext
    {
        bool HasErrors { get; }
        bool HasWarnings { get; }
        System.DateTime LastModified { get; }
        long LastModifiedTicks { get; }
        void Add(Catel.Data.IFieldValidationResult fieldValidationResult);
        void Add(Catel.Data.IBusinessRuleValidationResult businessRuleValidationResult);
        [System.ObsoleteAttribute("Use `Add(IBusinessRuleValidationResult)` instead. Will be removed in version 6.0." +
            "0.", true)]
        void AddBusinessRuleValidationResult(Catel.Data.IBusinessRuleValidationResult businessRuleValidationResult);
        [System.ObsoleteAttribute("Use `Add(IFieldValidationResult)` instead. Will be removed in version 6.0.0.", true)]
        void AddFieldValidationResult(Catel.Data.IFieldValidationResult fieldValidationResult);
        int GetBusinessRuleErrorCount();
        int GetBusinessRuleErrorCount(object tag);
        System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> GetBusinessRuleErrors();
        System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> GetBusinessRuleErrors(object tag);
        int GetBusinessRuleValidationCount();
        int GetBusinessRuleValidationCount(object tag);
        System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> GetBusinessRuleValidations();
        System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> GetBusinessRuleValidations(object tag);
        int GetBusinessRuleWarningCount();
        int GetBusinessRuleWarningCount(object tag);
        System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> GetBusinessRuleWarnings();
        System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> GetBusinessRuleWarnings(object tag);
        int GetErrorCount();
        int GetErrorCount(object tag);
        System.Collections.Generic.List<Catel.Data.IValidationResult> GetErrors();
        System.Collections.Generic.List<Catel.Data.IValidationResult> GetErrors(object tag);
        int GetFieldErrorCount();
        int GetFieldErrorCount(object tag);
        System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldErrors();
        System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldErrors(object tag);
        System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldErrors(string propertyName);
        System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldErrors(string propertyName, object tag);
        int GetFieldValidationCount();
        int GetFieldValidationCount(object tag);
        System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldValidations();
        System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldValidations(object tag);
        System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldValidations(string propertyName);
        System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldValidations(string propertyName, object tag);
        int GetFieldWarningCount();
        int GetFieldWarningCount(object tag);
        System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldWarnings();
        System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldWarnings(object tag);
        System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldWarnings(string propertyName);
        System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldWarnings(string propertyName, object tag);
        int GetValidationCount();
        int GetValidationCount(object tag);
        System.Collections.Generic.List<Catel.Data.IValidationResult> GetValidations();
        System.Collections.Generic.List<Catel.Data.IValidationResult> GetValidations(object tag);
        int GetWarningCount();
        int GetWarningCount(object tag);
        System.Collections.Generic.List<Catel.Data.IValidationResult> GetWarnings();
        System.Collections.Generic.List<Catel.Data.IValidationResult> GetWarnings(object tag);
        void Remove(Catel.Data.IFieldValidationResult fieldValidationResult);
        void Remove(Catel.Data.IBusinessRuleValidationResult businessRuleValidationResult);
        [System.ObsoleteAttribute("Use `Remove(IBusinessRuleValidationResult)` instead. Will be removed in version 6" +
            ".0.0.", true)]
        void RemoveBusinessRuleValidationResult(Catel.Data.IBusinessRuleValidationResult businessRuleValidationResult);
        [System.ObsoleteAttribute("Use `Remove(IFieldValidationResult)` instead. Will be removed in version 6.0.0.", true)]
        void RemoveFieldValidationResult(Catel.Data.IFieldValidationResult fieldValidationResult);
    }
    public class static IValidationContextExtensions
    {
        public static string GetValidationsAsStringList(this Catel.Data.IValidationContext validationContext, Catel.Data.ValidationResultType validationResult) { }
        public static bool HasWarningsOrErrors(this Catel.Data.IValidationContext validationContext) { }
    }
    public interface IValidationResult
    {
        string Message { get; set; }
        object Tag { get; set; }
        Catel.Data.ValidationResultType ValidationResultType { get; }
    }
    public interface IValidationSummary
    {
        System.Collections.ObjectModel.ReadOnlyCollection<Catel.Data.IBusinessRuleValidationResult> BusinessRuleErrors { get; }
        System.Collections.ObjectModel.ReadOnlyCollection<Catel.Data.IBusinessRuleValidationResult> BusinessRuleWarnings { get; }
        System.Collections.ObjectModel.ReadOnlyCollection<Catel.Data.IFieldValidationResult> FieldErrors { get; }
        System.Collections.ObjectModel.ReadOnlyCollection<Catel.Data.IFieldValidationResult> FieldWarnings { get; }
        bool HasBusinessRuleErrors { get; }
        bool HasBusinessRuleWarnings { get; }
        bool HasErrors { get; }
        bool HasFieldErrors { get; }
        bool HasFieldWarnings { get; }
        bool HasWarnings { get; }
        System.DateTime LastModified { get; }
        long LastModifiedTicks { get; }
    }
    public interface IValidator
    {
        void AfterValidateBusinessRules(object instance, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> validationResults);
        void AfterValidateFields(object instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> validationResults);
        void AfterValidation(object instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> fieldValidationResults, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> businessRuleValidationResults);
        void BeforeValidateBusinessRules(object instance, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> previousValidationResults);
        void BeforeValidateFields(object instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> previousValidationResults);
        void BeforeValidation(object instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> previousFieldValidationResults, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> previousBusinessRuleValidationResults);
        void Validate(object instance, Catel.Data.ValidationContext validationContext);
        void ValidateBusinessRules(object instance, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> validationResults);
        void ValidateFields(object instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> validationResults);
    }
    public interface IValidatorProvider
    {
        Catel.Data.IValidator GetValidator<TTargetType>();
        Catel.Data.IValidator GetValidator(System.Type targetType);
    }
    public interface IValueValidator<in TValue>
    {
        bool IsValid(TValue value);
    }
    public class InvalidPropertyException : System.Exception
    {
        public InvalidPropertyException(string propertyName) { }
        public string PropertyName { get; }
    }
    public class InvalidPropertyValueException : System.Exception
    {
        public InvalidPropertyValueException(string propertyName, System.Type expectedType, System.Type actualType) { }
        public System.Type ActualType { get; }
        public System.Type ExpectedType { get; }
        public string PropertyName { get; }
    }
    public abstract class ModelBase : Catel.Data.ObservableObject, Catel.Data.IFreezable, Catel.Data.IModel, Catel.Data.IModelEditor, Catel.Data.IModelSerialization, Catel.Runtime.Serialization.ISerializable, System.ComponentModel.IAdvancedEditableObject, System.ComponentModel.IEditableObject, System.ComponentModel.INotifyPropertyChanged, System.Runtime.Serialization.ISerializable, System.Xml.Serialization.IXmlSerializable
    {
        public static readonly Catel.Data.PropertyData IsDirtyProperty;
        public static readonly Catel.Data.PropertyData IsReadOnlyProperty;
        protected ModelBase() { }
        protected ModelBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        [System.ComponentModel.BrowsableAttribute(false)]
        protected bool AlwaysInvokeNotifyChanged { get; set; }
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public static bool DisablePropertyChangeNotifications { get; set; }
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsDirty { get; set; }
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsReadOnly { get; set; }
        public event System.EventHandler<System.ComponentModel.BeginEditEventArgs> System.ComponentModel.IAdvancedEditableObject.BeginEditing;
        public event System.EventHandler<System.ComponentModel.CancelEditEventArgs> System.ComponentModel.IAdvancedEditableObject.CancelEditing;
        public event System.EventHandler<System.EventArgs> System.ComponentModel.IAdvancedEditableObject.CancelEditingCompleted;
        public event System.EventHandler<System.ComponentModel.EndEditEventArgs> System.ComponentModel.IAdvancedEditableObject.EndEditing;
        public event System.EventHandler<System.ComponentModel.BeginEditEventArgs> _beginEditingEvent;
        public event System.EventHandler<System.EventArgs> _cancelEditingCompletedEvent;
        public event System.EventHandler<System.ComponentModel.CancelEditEventArgs> _cancelEditingEvent;
        public event System.EventHandler<System.ComponentModel.EndEditEventArgs> _endEditingEvent;
        [System.Security.SecurityCriticalAttribute()]
        public virtual void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        protected Catel.Data.PropertyData GetPropertyData(string name) { }
        protected Catel.Runtime.Serialization.ISerializer GetSerializerForIEditableObject() { }
        protected internal object GetValue(string name) { }
        protected TValue GetValue<TValue>(string name) { }
        protected object GetValue(Catel.Data.PropertyData property) { }
        protected TValue GetValue<TValue>(Catel.Data.PropertyData property) { }
        protected virtual T GetValueFromPropertyBag<T>(string propertyName) { }
        protected virtual void InitializeCustomProperties() { }
        protected internal void InitializePropertyAfterConstruction(Catel.Data.PropertyData property) { }
        protected bool IsModelBaseProperty(string name) { }
        public bool IsPropertyRegistered(string name) { }
        protected static bool IsPropertyRegistered(System.Type type, string name) { }
        protected virtual void OnBeginEdit(System.ComponentModel.BeginEditEventArgs e) { }
        protected virtual void OnCancelEdit(System.ComponentModel.EditEventArgs e) { }
        protected virtual void OnCancelEditCompleted(System.ComponentModel.CancelEditCompletedEventArgs e) { }
        protected virtual void OnDeserialized() { }
        protected virtual void OnDeserializing() { }
        protected virtual void OnEndEdit(System.ComponentModel.EditEventArgs e) { }
        protected virtual void OnSerialized() { }
        protected virtual void OnSerializing() { }
        protected override void RaisePropertyChanged(object sender, Catel.Data.AdvancedPropertyChangedEventArgs e) { }
        protected void RaisePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e, bool updateIsDirty, bool isRefreshCallOnly) { }
        public static Catel.Data.PropertyData RegisterProperty<TModel, TValue>(System.Linq.Expressions.Expression<System.Func<TModel, TValue>> propertyExpression, TValue defaultValue, System.Action<TModel, Catel.Data.AdvancedPropertyChangedEventArgs> propertyChangedEventHandler = null, bool includeInSerialization = True, bool includeInBackup = True) { }
        public static Catel.Data.PropertyData RegisterProperty<TModel, TValue>(System.Linq.Expressions.Expression<System.Func<TModel, TValue>> propertyExpression, System.Func<TValue> createDefaultValue = null, System.Action<TModel, Catel.Data.AdvancedPropertyChangedEventArgs> propertyChangedEventHandler = null, bool includeInSerialization = True, bool includeInBackup = True) { }
        public static Catel.Data.PropertyData RegisterProperty<TValue>(string name, System.Type type, TValue defaultValue, System.EventHandler<Catel.Data.AdvancedPropertyChangedEventArgs> propertyChangedEventHandler = null, bool includeInSerialization = True, bool includeInBackup = True) { }
        public static Catel.Data.PropertyData RegisterProperty(string name, System.Type type, System.Func<object> createDefaultValue = null, System.EventHandler<Catel.Data.AdvancedPropertyChangedEventArgs> propertyChangedEventHandler = null, bool includeInSerialization = True, bool includeInBackup = True) { }
        protected virtual void SetDirty(string propertyName) { }
        protected internal void SetValue(string name, object value, bool notifyOnChange = True) { }
        protected internal void SetValue(Catel.Data.PropertyData property, object value, bool notifyOnChange = True) { }
        protected virtual void SetValueToPropertyBag(string propertyName, object value) { }
        protected virtual bool ShouldPropertyChangeUpdateIsDirty(string propertyName) { }
        public System.IDisposable SuspendChangeCallbacks() { }
        public System.IDisposable SuspendChangeNotifications(bool raiseOnResume = True) { }
        public override string ToString() { }
        protected internal static void UnregisterProperty(System.Type modelType, string name) { }
    }
    public class static ModelBaseExtensions
    {
        public static void Save(this Catel.Data.ModelBase model, System.IO.Stream stream, Catel.Runtime.Serialization.ISerializer serializer) { }
        public static void Save(this Catel.Data.ModelBase model, string filePath, Catel.Runtime.Serialization.ISerializer serializer) { }
        public static void SaveAsXml(this Catel.Data.ModelBase model, System.IO.Stream stream) { }
        public static void SaveAsXml(this Catel.Data.ModelBase model, string filePath) { }
    }
    public class ModelEqualityComparer : System.Collections.Generic.EqualityComparer<Catel.Data.ModelBase>, Catel.Data.IModelEqualityComparer, System.Collections.IEqualityComparer
    {
        public ModelEqualityComparer() { }
        public bool CompareCollections { get; set; }
        public bool CompareProperties { get; set; }
        public bool CompareValues { get; set; }
        public override bool Equals(Catel.Data.ModelBase x, Catel.Data.ModelBase y) { }
        public override int GetHashCode(Catel.Data.ModelBase obj) { }
    }
    public class ObservableObject : Catel.Data.IAdvancedNotifyPropertyChanged, System.ComponentModel.INotifyPropertyChanged
    {
        public ObservableObject() { }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(Catel.Data.AdvancedPropertyChangedEventArgs e) { }
        protected internal void RaisePropertyChanged<TProperty>(System.Linq.Expressions.Expression<System.Func<TProperty>> propertyExpression) { }
        protected internal void RaisePropertyChanged<TProperty>(System.Linq.Expressions.Expression<System.Func<TProperty>> propertyExpression, object newValue) { }
        protected internal void RaisePropertyChanged<TProperty>(System.Linq.Expressions.Expression<System.Func<TProperty>> propertyExpression, object oldValue, object newValue) { }
        protected internal void RaisePropertyChanged(string propertyName) { }
        protected internal void RaisePropertyChanged(string propertyName, object newValue) { }
        protected internal void RaisePropertyChanged(string propertyName, object oldValue, object newValue) { }
        protected internal void RaisePropertyChanged(object sender, string propertyName) { }
        protected internal void RaisePropertyChanged(object sender, string propertyName, object newValue) { }
        protected internal void RaisePropertyChanged(object sender, string propertyName, object oldValue, object newValue) { }
        protected virtual void RaisePropertyChanged(object sender, Catel.Data.AdvancedPropertyChangedEventArgs e) { }
    }
    public class static ObservableObjectExtensions
    {
        public static void RaiseAllPropertiesChanged(this Catel.Data.ObservableObject sender) { }
    }
    public class PropertyAlreadyRegisteredException : System.Exception
    {
        public PropertyAlreadyRegisteredException(string propertyName, System.Type propertyType) { }
        public string PropertyName { get; }
        public System.Type PropertyType { get; }
    }
    public class PropertyBag : System.ComponentModel.INotifyPropertyChanged
    {
        public PropertyBag() { }
        public object this[string name] { get; set; }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        public System.Collections.Generic.Dictionary<string, object> GetAllProperties() { }
        public TValue GetPropertyValue<TValue>(string propertyName) { }
        public TValue GetPropertyValue<TValue>(string propertyName, TValue defaultValue) { }
        public void Import(System.Collections.Generic.Dictionary<string, object> propertiesToImport) { }
        public bool IsPropertyAvailable(string propertyName) { }
        public void SetPropertyValue(string propertyName, bool value) { }
        public void SetPropertyValue(string propertyName, short value) { }
        public void SetPropertyValue(string propertyName, ushort value) { }
        public void SetPropertyValue(string propertyName, int value) { }
        public void SetPropertyValue(string propertyName, uint value) { }
        public void SetPropertyValue(string propertyName, long value) { }
        public void SetPropertyValue(string propertyName, ulong value) { }
        public void SetPropertyValue(string propertyName, object value) { }
        public void UpdatePropertyValue<TValue>(string propertyName, System.Func<TValue, TValue> update) { }
    }
    public class PropertyData
    {
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IncludeInBackup { get; }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IncludeInSerialization { get; }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsCalculatedProperty { get; }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsModelBaseProperty { get; }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsSerializable { get; }
        public string Name { get; }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Type Type { get; }
        public object GetDefaultValue() { }
        public TValue GetDefaultValue<TValue>() { }
        public Catel.Reflection.CachedPropertyInfo GetPropertyInfo(System.Type containingType) { }
    }
    public class PropertyDataManager
    {
        public PropertyDataManager() { }
        public static Catel.Data.PropertyDataManager Default { get; }
        public Catel.Data.CatelTypeInfo GetCatelTypeInfo(System.Type type) { }
        public Catel.Data.PropertyData GetPropertyData(System.Type type, string name) { }
        public bool IsPropertyNameMappedToXmlAttribute(System.Type type, string propertyName) { }
        public bool IsPropertyNameMappedToXmlElement(System.Type type, string propertyName) { }
        public bool IsPropertyRegistered(System.Type type, string name) { }
        public bool IsXmlAttributeNameMappedToProperty(System.Type type, string xmlName) { }
        public bool IsXmlElementNameMappedToProperty(System.Type type, string xmlName) { }
        public string MapPropertyNameToXmlAttributeName(System.Type type, string propertyName) { }
        public string MapPropertyNameToXmlElementName(System.Type type, string propertyName) { }
        public string MapXmlAttributeNameToPropertyName(System.Type type, string xmlName) { }
        public string MapXmlElementNameToPropertyName(System.Type type, string xmlName) { }
        public Catel.Data.CatelTypeInfo RegisterProperties(System.Type type) { }
        public void RegisterProperty(System.Type type, string name, Catel.Data.PropertyData propertyData) { }
        public void UnregisterProperty(System.Type type, string name) { }
    }
    public class PropertyNotNullableException : System.Exception
    {
        public PropertyNotNullableException(string propertyName, System.Type propertyType) { }
        public string PropertyName { get; }
        public System.Type PropertyType { get; }
    }
    public class PropertyNotRegisteredException : System.Exception
    {
        public PropertyNotRegisteredException(string propertyName, System.Type objectType) { }
        public System.Type ObjectType { get; }
        public string PropertyName { get; }
    }
    public class PropertyValue : System.Runtime.Serialization.ISerializable
    {
        public PropertyValue() { }
        public PropertyValue(Catel.Data.PropertyData propertyData, System.Collections.Generic.KeyValuePair<string, object> keyValuePair) { }
        public PropertyValue(Catel.Data.PropertyData propertyData, string name, object value) { }
        public PropertyValue(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public int GraphId { get; set; }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public int GraphRefId { get; set; }
        public string Name { get; set; }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public Catel.Data.PropertyData PropertyData { get; }
        public object Value { get; set; }
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
    }
    public abstract class SavableModelBase<T> : Catel.Data.ModelBase, Catel.Data.IFreezable, Catel.Data.IModel, Catel.Data.IModelEditor, Catel.Data.IModelSerialization, Catel.Data.ISavableModel, Catel.Runtime.Serialization.ISerializable, System.ComponentModel.IAdvancedEditableObject, System.ComponentModel.IEditableObject, System.ComponentModel.INotifyPropertyChanged, System.Runtime.Serialization.ISerializable, System.Xml.Serialization.IXmlSerializable
        where T :  class
    {
        protected SavableModelBase() { }
        protected SavableModelBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        public static T Load(System.IO.Stream stream, Catel.Runtime.Serialization.ISerializer serializer, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        public static Catel.Data.IModel Load(System.Type type, System.IO.Stream stream, Catel.Runtime.Serialization.ISerializer serializer, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        public void Save(System.IO.Stream stream, Catel.Runtime.Serialization.ISerializer serializer, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
    }
    public class SuspensionContext
    {
        public SuspensionContext() { }
        public int Counter { get; }
        public System.Collections.Generic.IEnumerable<string> Properties { get; }
        public void Add(string propertyName) { }
        public void Decrement() { }
        public void Increment() { }
    }
    public abstract class ValidatableModelBase : Catel.Data.ModelBase, Catel.Data.IFreezable, Catel.Data.IModel, Catel.Data.IModelEditor, Catel.Data.IModelSerialization, Catel.Data.IValidatable, Catel.Data.IValidatableModel, Catel.Runtime.Serialization.ISerializable, System.ComponentModel.IAdvancedEditableObject, System.ComponentModel.IDataErrorInfo, System.ComponentModel.IDataWarningInfo, System.ComponentModel.IEditableObject, System.ComponentModel.INotifyDataErrorInfo, System.ComponentModel.INotifyDataWarningInfo, System.ComponentModel.INotifyPropertyChanged, System.Runtime.Serialization.ISerializable, System.Xml.Serialization.IXmlSerializable
    {
        protected static readonly System.Collections.Generic.Dictionary<System.Type, System.Collections.Generic.HashSet<string>> PropertiesNotCausingValidation;
        protected ValidatableModelBase() { }
        protected ValidatableModelBase(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
        [System.ComponentModel.BrowsableAttribute(false)]
        protected bool AutomaticallyValidateOnPropertyChanged { get; set; }
        public static bool DefaultValidateUsingDataAnnotationsValue { get; set; }
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual bool HasErrors { get; }
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual bool HasWarnings { get; }
        [System.ComponentModel.BrowsableAttribute(false)]
        protected bool HideValidationResults { get; set; }
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        protected bool IsValidating { get; }
        protected virtual bool IsValidationSuspended { get; }
        protected bool ValidateUsingDataAnnotations { get; set; }
        public event System.EventHandler<Catel.Data.ValidationEventArgs> Catel.Data.IValidatable.Validated;
        public event System.EventHandler<Catel.Data.ValidationEventArgs> Catel.Data.IValidatable.Validating;
        public event System.EventHandler<System.ComponentModel.DataErrorsChangedEventArgs> System.ComponentModel.INotifyDataErrorInfo.ErrorsChanged;
        public event System.EventHandler<System.ComponentModel.DataErrorsChangedEventArgs> System.ComponentModel.INotifyDataWarningInfo.WarningsChanged;
        public event System.EventHandler ValidatedBusinessRules;
        public event System.EventHandler ValidatedFields;
        public event System.EventHandler ValidatingBusinessRules;
        public event System.EventHandler ValidatingFields;
        public event System.EventHandler<System.ComponentModel.DataErrorsChangedEventArgs> _errorsChanged;
        public event System.EventHandler<Catel.Data.ValidationEventArgs> _validated;
        public event System.EventHandler<Catel.Data.ValidationEventArgs> _validating;
        public event System.EventHandler<System.ComponentModel.DataErrorsChangedEventArgs> _warningsChanged;
        protected virtual string GetBusinessRuleErrors() { }
        protected virtual string GetBusinessRuleWarnings() { }
        protected virtual string GetFieldErrors(string columnName) { }
        protected virtual string GetFieldWarnings(string columnName) { }
        protected virtual bool IsValidationProperty(string propertyName) { }
        protected void NotifyValidationResult(Catel.Data.IValidationResult validationResult, bool notifyGlobal) { }
        protected override void OnPropertyChanged(Catel.Data.AdvancedPropertyChangedEventArgs e) { }
        protected virtual void OnValidated(Catel.Data.IValidationContext validationContext) { }
        protected virtual void OnValidatedBusinessRules(Catel.Data.IValidationContext validationContext) { }
        protected virtual void OnValidatedFields(Catel.Data.IValidationContext validationContext) { }
        protected virtual void OnValidating(Catel.Data.IValidationContext validationContext) { }
        protected virtual void OnValidatingBusinessRules(Catel.Data.IValidationContext validationContext) { }
        protected virtual void OnValidatingFields(Catel.Data.IValidationContext validationContext) { }
        protected override bool ShouldPropertyChangeUpdateIsDirty(string propertyName) { }
        public System.IDisposable SuspendValidations(bool validateOnResume = True) { }
        public virtual void Validate(bool force = False) { }
        protected virtual void ValidateBusinessRules(System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> validationResults) { }
        protected virtual void ValidateFields(System.Collections.Generic.List<Catel.Data.IFieldValidationResult> validationResults) { }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Class | System.AttributeTargets.All, AllowMultiple=true)]
    public class ValidateModelAttribute : System.Attribute
    {
        public ValidateModelAttribute(System.Type validatorType) { }
        public System.Type ValidatorType { get; }
    }
    public class ValidationContext : Catel.Data.IValidationContext
    {
        public ValidationContext() { }
        public ValidationContext(System.Collections.Generic.IEnumerable<Catel.Data.IFieldValidationResult> fieldValidationResults, System.Collections.Generic.IEnumerable<Catel.Data.IBusinessRuleValidationResult> businessRuleValidationResults) { }
        public ValidationContext(System.Collections.Generic.IEnumerable<Catel.Data.IFieldValidationResult> fieldValidationResults, System.Collections.Generic.IEnumerable<Catel.Data.IBusinessRuleValidationResult> businessRuleValidationResults, System.DateTime lastModified) { }
        public bool HasErrors { get; }
        public bool HasWarnings { get; }
        public System.DateTime LastModified { get; }
        public long LastModifiedTicks { get; }
        public void Add(Catel.Data.IFieldValidationResult fieldValidationResult) { }
        public void Add(Catel.Data.IBusinessRuleValidationResult businessRuleValidationResult) { }
        [System.ObsoleteAttribute("Use `Add(IBusinessRuleValidationResult)` instead. Will be removed in version 6.0." +
            "0.", true)]
        public void AddBusinessRuleValidationResult(Catel.Data.IBusinessRuleValidationResult businessRuleValidationResult) { }
        [System.ObsoleteAttribute("Use `Add(IFieldValidationResult)` instead. Will be removed in version 6.0.0.", true)]
        public void AddFieldValidationResult(Catel.Data.IFieldValidationResult fieldValidationResult) { }
        public int GetBusinessRuleErrorCount() { }
        public int GetBusinessRuleErrorCount(object tag) { }
        public System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> GetBusinessRuleErrors() { }
        public System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> GetBusinessRuleErrors(object tag) { }
        public int GetBusinessRuleValidationCount() { }
        public int GetBusinessRuleValidationCount(object tag) { }
        public System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> GetBusinessRuleValidations() { }
        public System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> GetBusinessRuleValidations(object tag) { }
        public int GetBusinessRuleWarningCount() { }
        public int GetBusinessRuleWarningCount(object tag) { }
        public System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> GetBusinessRuleWarnings() { }
        public System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> GetBusinessRuleWarnings(object tag) { }
        public int GetErrorCount() { }
        public int GetErrorCount(object tag) { }
        public System.Collections.Generic.List<Catel.Data.IValidationResult> GetErrors() { }
        public System.Collections.Generic.List<Catel.Data.IValidationResult> GetErrors(object tag) { }
        public int GetFieldErrorCount() { }
        public int GetFieldErrorCount(object tag) { }
        public System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldErrors() { }
        public System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldErrors(object tag) { }
        public System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldErrors(string propertyName) { }
        public System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldErrors(string propertyName, object tag) { }
        public int GetFieldValidationCount() { }
        public int GetFieldValidationCount(object tag) { }
        public System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldValidations() { }
        public System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldValidations(object tag) { }
        public System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldValidations(string propertyName) { }
        public System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldValidations(string propertyName, object tag) { }
        public int GetFieldWarningCount() { }
        public int GetFieldWarningCount(object tag) { }
        public System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldWarnings() { }
        public System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldWarnings(object tag) { }
        public System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldWarnings(string propertyName) { }
        public System.Collections.Generic.List<Catel.Data.IFieldValidationResult> GetFieldWarnings(string propertyName, object tag) { }
        public int GetValidationCount() { }
        public int GetValidationCount(object tag) { }
        public System.Collections.Generic.List<Catel.Data.IValidationResult> GetValidations() { }
        public System.Collections.Generic.List<Catel.Data.IValidationResult> GetValidations(object tag) { }
        public int GetWarningCount() { }
        public int GetWarningCount(object tag) { }
        public System.Collections.Generic.List<Catel.Data.IValidationResult> GetWarnings() { }
        public System.Collections.Generic.List<Catel.Data.IValidationResult> GetWarnings(object tag) { }
        public void Remove(Catel.Data.IFieldValidationResult fieldValidationResult) { }
        public void Remove(Catel.Data.IBusinessRuleValidationResult businessRuleValidationResult) { }
        [System.ObsoleteAttribute("Use `Remove(IBusinessRuleValidationResult)` instead. Will be removed in version 6" +
            ".0.0.", true)]
        public void RemoveBusinessRuleValidationResult(Catel.Data.IBusinessRuleValidationResult businessRuleValidationResult) { }
        [System.ObsoleteAttribute("Use `Remove(IFieldValidationResult)` instead. Will be removed in version 6.0.0.", true)]
        public void RemoveFieldValidationResult(Catel.Data.IFieldValidationResult fieldValidationResult) { }
        public override string ToString() { }
    }
    public class ValidationContextChange
    {
        public ValidationContextChange(Catel.Data.IValidationResult validationResult, Catel.Data.ValidationContextChangeType changeType) { }
        public Catel.Data.ValidationContextChangeType ChangeType { get; }
        public Catel.Data.IValidationResult ValidationResult { get; }
    }
    public enum ValidationContextChangeType
    {
        Added = 0,
        Removed = 1,
    }
    public class static ValidationContextHelper
    {
        public static System.Collections.Generic.List<Catel.Data.ValidationContextChange> GetChanges(Catel.Data.IValidationContext firstContext, Catel.Data.IValidationContext secondContext) { }
    }
    public class ValidationEventArgs : System.EventArgs
    {
        public ValidationEventArgs(Catel.Data.IValidationContext validationContext) { }
        public Catel.Data.IValidationContext ValidationContext { get; }
    }
    public class static ValidationExtensions
    {
        public static Catel.Data.IValidationSummary GetValidationSummary(this Catel.Data.IValidationContext validationContext, object tag = null) { }
        public static System.Collections.Generic.List<Catel.Data.ValidationContextChange> SynchronizeWithContext(this Catel.Data.ValidationContext validationContext, Catel.Data.IValidationContext additionalValidationContext, bool onlyAddValidation = False) { }
    }
    public abstract class ValidationResult : Catel.Data.IValidationResult
    {
        protected ValidationResult(Catel.Data.ValidationResultType validationResultType, string message) { }
        public string Message { get; set; }
        public object Tag { get; set; }
        public Catel.Data.ValidationResultType ValidationResultType { get; }
    }
    public enum ValidationResultType
    {
        Warning = 0,
        Error = 1,
    }
    public class ValidationSummary : Catel.Data.IValidationSummary
    {
        public ValidationSummary(Catel.Data.IValidationContext validationContext) { }
        public ValidationSummary(Catel.Data.IValidationContext validationContext, object tag) { }
        public System.Collections.ObjectModel.ReadOnlyCollection<Catel.Data.IBusinessRuleValidationResult> BusinessRuleErrors { get; }
        public System.Collections.ObjectModel.ReadOnlyCollection<Catel.Data.IBusinessRuleValidationResult> BusinessRuleWarnings { get; }
        public System.Collections.ObjectModel.ReadOnlyCollection<Catel.Data.IFieldValidationResult> FieldErrors { get; }
        public System.Collections.ObjectModel.ReadOnlyCollection<Catel.Data.IFieldValidationResult> FieldWarnings { get; }
        public bool HasBusinessRuleErrors { get; }
        public bool HasBusinessRuleWarnings { get; }
        public bool HasErrors { get; }
        public bool HasFieldErrors { get; }
        public bool HasFieldWarnings { get; }
        public bool HasWarnings { get; }
        public System.DateTime LastModified { get; }
        public long LastModifiedTicks { get; }
        public override string ToString() { }
    }
    public abstract class ValidatorBase<TTargetType> : Catel.Data.IValidator
        where TTargetType :  class
    {
        protected ValidatorBase() { }
        public void AfterValidateBusinessRules(object instance, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> validationResults) { }
        protected virtual void AfterValidateBusinessRules(TTargetType instance, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> validationResults) { }
        public void AfterValidateFields(object instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> validationResults) { }
        protected virtual void AfterValidateFields(TTargetType instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> validationResults) { }
        public void AfterValidation(object instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> fieldValidationResults, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> businessRuleValidationResults) { }
        protected virtual void AfterValidation(TTargetType instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> fieldValidationResults, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> businessRuleValidationResults) { }
        public void BeforeValidateBusinessRules(object instance, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> previousValidationResults) { }
        protected virtual void BeforeValidateBusinessRules(TTargetType instance, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> previousValidationResults) { }
        public void BeforeValidateFields(object instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> previousValidationResults) { }
        protected virtual void BeforeValidateFields(TTargetType instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> previousValidationResults) { }
        public void BeforeValidation(object instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> previousFieldValidationResults, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> previousBusinessRuleValidationResults) { }
        protected virtual void BeforeValidation(TTargetType instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> previousFieldValidationResults, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> previousBusinessRuleValidationResults) { }
        public void Validate(object instance, Catel.Data.ValidationContext validationContext) { }
        protected virtual void Validate(TTargetType instance, Catel.Data.ValidationContext validationContext) { }
        public void ValidateBusinessRules(object instance, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> validationResults) { }
        protected virtual void ValidateBusinessRules(TTargetType instance, System.Collections.Generic.List<Catel.Data.IBusinessRuleValidationResult> validationResults) { }
        public void ValidateFields(object instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> validationResults) { }
        protected virtual void ValidateFields(TTargetType instance, System.Collections.Generic.List<Catel.Data.IFieldValidationResult> validationResults) { }
    }
    public abstract class ValidatorProviderBase : Catel.Data.IValidatorProvider
    {
        protected ValidatorProviderBase() { }
        public bool UseCache { get; set; }
        protected abstract Catel.Data.IValidator GetValidator(System.Type targetType);
    }
    public class XmlNameMapper<T>
    {
        public bool IsPropertyNameMappedToXmlName(System.Type type, string propertyName) { }
        public bool IsXmlNameMappedToProperty(System.Type type, string xmlName) { }
        public string MapPropertyNameToXmlName(System.Type type, string propertyName) { }
        public string MapXmlNameToPropertyName(System.Type type, string xmlName) { }
    }
}
namespace Catel.ExceptionHandling
{
    public class BufferPolicy : Catel.ExceptionHandling.PolicyBase, Catel.ExceptionHandling.IBufferPolicy, Catel.ExceptionHandling.IPolicy
    {
        public BufferPolicy(int numberOfTimes, System.TimeSpan interval) { }
        public override string ToString() { }
    }
    public class BufferedEventArgs : System.EventArgs
    {
        public BufferedEventArgs(System.Exception bufferedException, System.DateTime dateTime) { }
        public System.Exception BufferedException { get; }
        public System.DateTime DateTime { get; }
    }
    public class ExceptionHandler : Catel.ExceptionHandling.IExceptionHandler
    {
        public ExceptionHandler(System.Type exceptionType, System.Action<System.Exception> action, Catel.ExceptionHandling.ExceptionPredicate filter = null) { }
        public Catel.ExceptionHandling.IBufferPolicy BufferPolicy { get; set; }
        public System.Type ExceptionType { get; }
        public Catel.ExceptionHandling.ExceptionPredicate Filter { get; }
        public Catel.ExceptionHandling.IRetryPolicy RetryPolicy { get; set; }
        public void Handle(System.Exception exception) { }
    }
    public class static ExceptionHandlerExtensions
    {
        public static void OnErrorRetry(this Catel.ExceptionHandling.IExceptionHandler exceptionHandler, int numberOfTimes, System.TimeSpan interval) { }
        public static void OnErrorRetryImmediately(this Catel.ExceptionHandling.IExceptionHandler exceptionHandler, int numberOfTimes = 2147483647) { }
        public static void UsingTolerance(this Catel.ExceptionHandling.IExceptionHandler exceptionHandler, int numberOfTimes, System.TimeSpan interval) { }
    }
    public abstract class ExceptionHandler<TException> : Catel.ExceptionHandling.IExceptionHandler, Catel.ExceptionHandling.IExceptionHandler<TException>
        where TException : System.Exception
    {
        protected ExceptionHandler() { }
        public Catel.ExceptionHandling.IBufferPolicy BufferPolicy { get; set; }
        public System.Type ExceptionType { get; }
        public Catel.ExceptionHandling.ExceptionPredicate Filter { get; }
        public Catel.ExceptionHandling.IRetryPolicy RetryPolicy { get; set; }
        public virtual System.Func<TException, bool> GetFilter() { }
        public void Handle(System.Exception exception) { }
        public abstract void OnException(TException exception);
    }
    public delegate bool ExceptionPredicate(System.Exception exception);
    public class ExceptionService : Catel.ExceptionHandling.IExceptionService
    {
        public ExceptionService() { }
        public static Catel.ExceptionHandling.IExceptionService Default { get; }
        public System.Collections.Generic.IEnumerable<Catel.ExceptionHandling.IExceptionHandler> ExceptionHandlers { get; }
        public event System.EventHandler<Catel.ExceptionHandling.BufferedEventArgs> ExceptionBuffered;
        public event System.EventHandler<Catel.ExceptionHandling.RetryingEventArgs> RetryingAction;
        public Catel.ExceptionHandling.IExceptionHandler GetHandler(System.Type exceptionType) { }
        public Catel.ExceptionHandling.IExceptionHandler GetHandler<TException>()
            where TException : System.Exception { }
        public bool HandleException(System.Exception exception) { }
        public bool IsExceptionRegistered<TException>()
            where TException : System.Exception { }
        public bool IsExceptionRegistered(System.Type exceptionType) { }
        protected virtual void OnExceptionBuffered(System.Exception bufferedException, System.DateTime dateTime) { }
        protected virtual void OnRetryingAction(int retryCount, System.Exception lastError, System.TimeSpan delay) { }
        public void Process(System.Action action) { }
        public TResult Process<TResult>(System.Func<TResult> action) { }
        public System.Threading.Tasks.Task ProcessAsync(System.Threading.Tasks.Task action) { }
        public System.Threading.Tasks.Task ProcessAsync(System.Func<System.Threading.Tasks.Task> action) { }
        public System.Threading.Tasks.Task<TResult> ProcessAsync<TResult>(System.Func<TResult> action, System.Threading.CancellationToken cancellationToken = null) { }
        public System.Threading.Tasks.Task<TResult> ProcessAsync<TResult>(System.Func<System.Threading.Tasks.Task<TResult>> action) { }
        public TResult ProcessWithRetry<TResult>(System.Func<TResult> action) { }
        public System.Threading.Tasks.Task<TResult> ProcessWithRetryAsync<TResult>(System.Func<System.Threading.Tasks.Task<TResult>> action) { }
        public Catel.ExceptionHandling.IExceptionHandler Register<TException>(System.Action<TException> handler, System.Func<TException, bool> exceptionPredicate = null)
            where TException : System.Exception { }
        public Catel.ExceptionHandling.IExceptionHandler Register(Catel.ExceptionHandling.IExceptionHandler handler) { }
        public bool Unregister<TException>()
            where TException : System.Exception { }
    }
    public class static ExceptionServiceExtensions
    {
        public static System.Threading.Tasks.Task<bool> HandleExceptionAsync(this Catel.ExceptionHandling.IExceptionService exceptionService, System.Exception exception, System.Threading.CancellationToken cancellationToken = null) { }
        public static void ProcessWithRetry(this Catel.ExceptionHandling.IExceptionService exceptionService, System.Action action) { }
        public static System.Threading.Tasks.Task ProcessWithRetryAsync(this Catel.ExceptionHandling.IExceptionService exceptionService, System.Threading.Tasks.Task action) { }
        public static System.Threading.Tasks.Task ProcessWithRetryAsync(this Catel.ExceptionHandling.IExceptionService exceptionService, System.Action action, System.Threading.CancellationToken cancellationToken = null) { }
        public static System.Threading.Tasks.Task<TResult> ProcessWithRetryAsync<TResult>(this Catel.ExceptionHandling.IExceptionService exceptionService, System.Func<TResult> action, System.Threading.CancellationToken cancellationToken = null) { }
        public static System.Threading.Tasks.Task ProcessWithRetryAsync(this Catel.ExceptionHandling.IExceptionService exceptionService, System.Func<System.Threading.Tasks.Task> action) { }
        public static Catel.ExceptionHandling.IExceptionHandler Register<TExceptionHandler>(this Catel.ExceptionHandling.IExceptionService exceptionService)
            where TExceptionHandler : Catel.ExceptionHandling.IExceptionHandler, new () { }
    }
    public interface IBufferPolicy : Catel.ExceptionHandling.IPolicy { }
    public interface IExceptionHandler
    {
        Catel.ExceptionHandling.IBufferPolicy BufferPolicy { get; set; }
        System.Type ExceptionType { get; }
        Catel.ExceptionHandling.ExceptionPredicate Filter { get; }
        Catel.ExceptionHandling.IRetryPolicy RetryPolicy { get; set; }
        void Handle(System.Exception exception);
    }
    public interface IExceptionHandler<in TException> : Catel.ExceptionHandling.IExceptionHandler
        where in TException : System.Exception
    {
        System.Func<TException, bool> GetFilter();
        void OnException(TException exception);
    }
    public interface IExceptionService
    {
        System.Collections.Generic.IEnumerable<Catel.ExceptionHandling.IExceptionHandler> ExceptionHandlers { get; }
        public event System.EventHandler<Catel.ExceptionHandling.BufferedEventArgs> ExceptionBuffered;
        public event System.EventHandler<Catel.ExceptionHandling.RetryingEventArgs> RetryingAction;
        Catel.ExceptionHandling.IExceptionHandler GetHandler(System.Type exceptionType);
        Catel.ExceptionHandling.IExceptionHandler GetHandler<TException>()
            where TException : System.Exception;
        bool HandleException(System.Exception exception);
        bool IsExceptionRegistered<TException>()
            where TException : System.Exception;
        bool IsExceptionRegistered(System.Type exceptionType);
        void Process(System.Action action);
        TResult Process<TResult>(System.Func<TResult> action);
        System.Threading.Tasks.Task ProcessAsync(System.Threading.Tasks.Task action);
        System.Threading.Tasks.Task<TResult> ProcessAsync<TResult>(System.Func<System.Threading.Tasks.Task<TResult>> action);
        System.Threading.Tasks.Task ProcessAsync(System.Func<System.Threading.Tasks.Task> action);
        System.Threading.Tasks.Task<TResult> ProcessAsync<TResult>(System.Func<TResult> action, System.Threading.CancellationToken cancellationToken = null);
        TResult ProcessWithRetry<TResult>(System.Func<TResult> action);
        System.Threading.Tasks.Task<TResult> ProcessWithRetryAsync<TResult>(System.Func<System.Threading.Tasks.Task<TResult>> action);
        Catel.ExceptionHandling.IExceptionHandler Register<TException>(System.Action<TException> handler, System.Func<TException, bool> exceptionPredicate = null)
            where TException : System.Exception;
        Catel.ExceptionHandling.IExceptionHandler Register(Catel.ExceptionHandling.IExceptionHandler handler);
        bool Unregister<TException>()
            where TException : System.Exception;
    }
    public interface IPolicy
    {
        System.TimeSpan Interval { get; }
        int NumberOfTimes { get; }
    }
    public interface IRetryPolicy : Catel.ExceptionHandling.IPolicy { }
    public class PolicyBase : Catel.ExceptionHandling.IPolicy
    {
        public PolicyBase() { }
        public System.TimeSpan Interval { get; set; }
        public int NumberOfTimes { get; set; }
    }
    public class RetryPolicy : Catel.ExceptionHandling.PolicyBase, Catel.ExceptionHandling.IPolicy, Catel.ExceptionHandling.IRetryPolicy
    {
        public RetryPolicy(int numberOfTimes, System.TimeSpan interval) { }
    }
    public class RetryingEventArgs : System.EventArgs
    {
        public RetryingEventArgs(int currentRetryCount, System.TimeSpan delay, System.Exception lastException) { }
        public int CurrentRetryCount { get; }
        public System.TimeSpan Delay { get; }
        public System.Exception LastException { get; }
    }
}
namespace Catel.IO
{
    public enum ApplicationDataTarget
    {
        UserLocal = 0,
        UserRoaming = 1,
        Machine = 2,
    }
    public class static Path
    {
        public static string AppendTrailingSlash(string path) { }
        public static string AppendTrailingSlash(string path, char slash) { }
        public static string Combine(params string[] paths) { }
        public static string CombineUrls(params string[] urls) { }
        public static string GetApplicationDataDirectory() { }
        public static string GetApplicationDataDirectory(string productName) { }
        public static string GetApplicationDataDirectory(string companyName, string productName) { }
        public static string GetApplicationDataDirectory(Catel.IO.ApplicationDataTarget applicationDataTarget) { }
        public static string GetApplicationDataDirectory(Catel.IO.ApplicationDataTarget applicationDataTarget, string productName) { }
        public static string GetApplicationDataDirectory(Catel.IO.ApplicationDataTarget applicationDataTarget, string companyName, string productName) { }
        public static string GetApplicationDataDirectoryForAllUsers() { }
        public static string GetApplicationDataDirectoryForAllUsers(string productName) { }
        public static string GetApplicationDataDirectoryForAllUsers(string companyName, string productName) { }
        public static string GetDirectoryName(string path) { }
        public static string GetFileName(string path) { }
        public static string GetFullPath(string relativePath, string basePath) { }
        public static string GetParentDirectory(string path) { }
        public static string GetRelativePath(string fullPath, string basePath = null) { }
    }
    public class static StreamExtensions
    {
        public static string GetString(this System.IO.Stream stream, System.Text.Encoding encoding) { }
        public static string GetUtf8String(this System.IO.Stream stream) { }
        public static byte[] ToByteArray(this System.IO.Stream stream) { }
    }
}
namespace Catel.IoC
{
    public class CatelDependencyResolver : Catel.IoC.IDependencyResolver
    {
        public CatelDependencyResolver(Catel.IoC.IServiceLocator serviceLocator) { }
        public bool CanResolve(System.Type type, object tag = null) { }
        [System.ObsoleteAttribute("Use `CanResolveMultiple` instead. Will be removed in version 6.0.0.", true)]
        public bool CanResolveAll(System.Type[] types) { }
        public bool CanResolveMultiple(System.Type[] types) { }
        public object Resolve(System.Type type, object tag = null) { }
        [System.ObsoleteAttribute("Use `ResolveMultiple` instead. Will be removed in version 6.0.0.", true)]
        public object[] ResolveAll(System.Type[] types, object tag = null) { }
        public object[] ResolveMultiple(System.Type[] types, object tag = null) { }
    }
    public class CircularDependencyException : System.Exception
    {
        public Catel.IoC.TypeRequestInfo DuplicateRequestInfo { get; }
        public Catel.IoC.ITypeRequestPath TypePath { get; }
    }
    public class static DependencyResolverExtensions
    {
        public static bool CanResolve<T>(this Catel.IoC.IDependencyResolver dependencyResolver, object tag = null) { }
        public static T Resolve<T>(this Catel.IoC.IDependencyResolver dependencyResolver, object tag = null) { }
        public static object TryResolve(this Catel.IoC.IDependencyResolver dependencyResolver, System.Type serviceType, object tag = null) { }
        public static T TryResolve<T>(this Catel.IoC.IDependencyResolver dependencyResolver, object tag = null) { }
    }
    public class DependencyResolverManager : Catel.IoC.IDependencyResolverManager
    {
        public DependencyResolverManager() { }
        public static Catel.IoC.IDependencyResolverManager Default { get; set; }
        public Catel.IoC.IDependencyResolver DefaultDependencyResolver { get; set; }
        public virtual Catel.IoC.IDependencyResolver GetDependencyResolverForInstance(object instance) { }
        public virtual Catel.IoC.IDependencyResolver GetDependencyResolverForType(System.Type type) { }
        public virtual void RegisterDependencyResolverForInstance(object instance, Catel.IoC.IDependencyResolver dependencyResolver) { }
        public virtual void RegisterDependencyResolverForType(System.Type type, Catel.IoC.IDependencyResolver dependencyResolver) { }
    }
    public class ExternalContainerNotSupportedException : System.Exception
    {
        public ExternalContainerNotSupportedException(string[] supportedContainers) { }
        public string[] SupportedContainers { get; }
    }
    public class FirstInterfaceRegistrationConvention : Catel.IoC.RegistrationConventionBase
    {
        public FirstInterfaceRegistrationConvention(Catel.IoC.IServiceLocator serviceLocator, Catel.IoC.RegistrationType registrationType = 0) { }
        public override void Process(System.Collections.Generic.IEnumerable<System.Type> typesToRegister) { }
    }
    public interface IDependencyResolver
    {
        bool CanResolve(System.Type type, object tag = null);
        [System.ObsoleteAttribute("Use `CanResolveMultiple` instead. Will be removed in version 6.0.0.", true)]
        bool CanResolveAll(System.Type[] types);
        bool CanResolveMultiple(System.Type[] types);
        object Resolve(System.Type type, object tag = null);
        [System.ObsoleteAttribute("Use `ResolveMultiple` instead. Will be removed in version 6.0.0.", true)]
        object[] ResolveAll(System.Type[] types, object tag = null);
        object[] ResolveMultiple(System.Type[] types, object tag = null);
    }
    public interface IDependencyResolverManager
    {
        Catel.IoC.IDependencyResolver DefaultDependencyResolver { get; set; }
        Catel.IoC.IDependencyResolver GetDependencyResolverForInstance(object instance);
        Catel.IoC.IDependencyResolver GetDependencyResolverForType(System.Type type);
        void RegisterDependencyResolverForInstance(object instance, Catel.IoC.IDependencyResolver dependencyResolver);
        void RegisterDependencyResolverForType(System.Type type, Catel.IoC.IDependencyResolver dependencyResolver);
    }
    public interface INeedCustomInitialization
    {
        void Initialize();
    }
    public interface IRegistrationConvention
    {
        Catel.IoC.RegistrationType RegistrationType { get; }
        void Process(System.Collections.Generic.IEnumerable<System.Type> typesToRegister);
    }
    public interface IRegistrationConventionHandler
    {
        Catel.ICompositeFilter<System.Reflection.Assembly> AssemblyFilter { get; }
        System.Collections.Generic.IEnumerable<Catel.IoC.IRegistrationConvention> RegistrationConventions { get; }
        Catel.ICompositeFilter<System.Type> TypeFilter { get; }
        void AddAssemblyToScan(System.Reflection.Assembly assembly);
        void ApplyConventions();
        void RegisterConvention<TRegistrationConvention>(Catel.IoC.RegistrationType registrationType = 0)
            where TRegistrationConvention : Catel.IoC.IRegistrationConvention;
    }
    public interface IServiceLocator : System.IDisposable, System.IServiceProvider
    {
        bool AutoRegisterTypesViaAttributes { get; set; }
        bool CanResolveNonAbstractTypesWithoutRegistration { get; set; }
        bool IgnoreRuntimeIncorrectUsageOfRegisterAttribute { get; set; }
        public event System.EventHandler<Catel.IoC.MissingTypeEventArgs> MissingType;
        public event System.EventHandler<Catel.IoC.TypeInstantiatedEventArgs> TypeInstantiated;
        public event System.EventHandler<Catel.IoC.TypeRegisteredEventArgs> TypeRegistered;
        public event System.EventHandler<Catel.IoC.TypeUnregisteredEventArgs> TypeUnregistered;
        [System.ObsoleteAttribute("Use `AreMultipleTypesRegistered` instead. Will be removed in version 6.0.0.", true)]
        bool AreAllTypesRegistered(params System.Type[] types);
        bool AreMultipleTypesRegistered(params System.Type[] types);
        Catel.IoC.RegistrationInfo GetRegistrationInfo(System.Type serviceType, object tag = null);
        bool IsTypeRegistered(System.Type serviceType, object tag = null);
        bool IsTypeRegisteredAsSingleton(System.Type serviceType, object tag = null);
        bool IsTypeRegisteredWithOrWithoutTag(System.Type serviceType);
        void RegisterInstance(System.Type serviceType, object instance, object tag = null);
        void RegisterType(System.Type serviceType, System.Type serviceImplementationType, object tag = null, Catel.IoC.RegistrationType registrationType = 0, bool registerIfAlreadyRegistered = True);
        void RegisterType(System.Type serviceType, System.Func<Catel.IoC.ServiceLocatorRegistration, object> createServiceFunc, object tag = null, Catel.IoC.RegistrationType registrationType = 0, bool registerIfAlreadyRegistered = True);
        void RemoveAllTypes(System.Type serviceType);
        void RemoveType(System.Type serviceType, object tag = null);
        [System.ObsoleteAttribute("Use `ResolveMultipleTypes` instead. Will be removed in version 6.0.0.", true)]
        object[] ResolveAllTypes(params System.Type[] types);
        object[] ResolveMultipleTypes(params System.Type[] types);
        object ResolveType(System.Type serviceType, object tag = null);
        System.Collections.Generic.IEnumerable<object> ResolveTypes(System.Type serviceType);
    }
    public interface IServiceLocatorInitializer
    {
        void Initialize(Catel.IoC.IServiceLocator serviceLocator);
    }
    public interface ITypeFactory
    {
        void ClearCache();
        object CreateInstance(System.Type typeToConstruct);
        object CreateInstanceWithParameters(System.Type typeToConstruct, params object[] parameters);
        object CreateInstanceWithParametersAndAutoCompletion(System.Type typeToConstruct, params object[] parameters);
        object CreateInstanceWithParametersAndAutoCompletionWithTag(System.Type typeToConstruct, object tag, params object[] parameters);
        object CreateInstanceWithParametersWithTag(System.Type typeToConstruct, object tag, params object[] parameters);
        object CreateInstanceWithTag(System.Type typeToConstruct, object tag);
    }
    public interface ITypeRequestPath
    {
        System.Collections.Generic.IEnumerable<Catel.IoC.TypeRequestInfo> AllTypes { get; }
        Catel.IoC.TypeRequestInfo FirstType { get; }
        Catel.IoC.TypeRequestInfo LastType { get; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Property | System.AttributeTargets.All, AllowMultiple=false, Inherited=false)]
    public class InjectAttribute : System.Attribute
    {
        public InjectAttribute(System.Type type = null, object tag = null) { }
        public object Tag { get; }
        public System.Type Type { get; set; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Constructor | System.AttributeTargets.All, AllowMultiple=false, Inherited=false)]
    public class InjectionConstructorAttribute : System.Attribute
    {
        public InjectionConstructorAttribute() { }
    }
    public class static IoCConfiguration
    {
        public static Catel.IoC.IDependencyResolver DefaultDependencyResolver { get; }
        public static Catel.IoC.IServiceLocator DefaultServiceLocator { get; }
        public static Catel.IoC.ITypeFactory DefaultTypeFactory { get; }
        public static void UpdateDefaultComponents() { }
    }
    public sealed class IoCConfigurationSection : System.Configuration.ConfigurationSection
    {
        public IoCConfigurationSection() { }
        public Catel.IoC.ServiceLocatorConfiguration DefaultServiceLocatorConfiguration { get; }
        [System.Configuration.ConfigurationPropertyAttribute("serviceLocatorConfigurations", IsDefaultCollection=false)]
        public Catel.IoC.ServiceLocatorConfigurationCollection ServiceLocatorConfigurationCollection { get; }
        public Catel.IoC.ServiceLocatorConfiguration GetServiceLocatorConfiguration(string name = "default") { }
    }
    public class static IoCFactory
    {
        public static System.Func<Catel.IoC.IServiceLocator, Catel.IoC.IDependencyResolver> CreateDependencyResolverFunc { get; set; }
        public static System.Func<Catel.IoC.IServiceLocator> CreateServiceLocatorFunc { get; set; }
        public static System.Func<Catel.IoC.IServiceLocator, Catel.IoC.ITypeFactory> CreateTypeFactoryFunc { get; set; }
        public static Catel.IoC.IServiceLocator CreateServiceLocator(bool initializeServiceLocator = True) { }
    }
    public sealed class LateBoundImplementation { }
    public class MissingTypeEventArgs : System.EventArgs
    {
        public MissingTypeEventArgs(System.Type interfaceType) { }
        public MissingTypeEventArgs(System.Type interfaceType, object tag) { }
        public object ImplementingInstance { get; set; }
        public System.Type ImplementingType { get; set; }
        public System.Type InterfaceType { get; }
        public Catel.IoC.RegistrationType RegistrationType { get; set; }
        public object Tag { get; set; }
    }
    public class NamingRegistrationConvention : Catel.IoC.RegistrationConventionBase
    {
        public NamingRegistrationConvention(Catel.IoC.IServiceLocator serviceLocator, Catel.IoC.RegistrationType registrationType = 0) { }
        public override void Process(System.Collections.Generic.IEnumerable<System.Type> typesToRegister) { }
    }
    public class static ObjectExtensions
    {
        public static Catel.IoC.IDependencyResolver GetDependencyResolver(this object obj) { }
        public static Catel.IoC.IServiceLocator GetServiceLocator(this object obj) { }
        public static Catel.IoC.ITypeFactory GetTypeFactory(this object obj) { }
    }
    public class Registration : System.Configuration.ConfigurationElement
    {
        public Registration() { }
        public System.Type ImplementationType { get; }
        [System.Configuration.ConfigurationPropertyAttribute("implementationType", IsRequired=true)]
        public string ImplementationTypeName { get; set; }
        public System.Type InterfaceType { get; }
        [System.Configuration.ConfigurationPropertyAttribute("interfaceType", IsRequired=true)]
        public string InterfaceTypeName { get; set; }
        [System.Configuration.ConfigurationPropertyAttribute("registrationType", DefaultValue=Catel.IoC.RegistrationType.Singleton)]
        public Catel.IoC.RegistrationType RegistrationType { get; set; }
        [System.Configuration.ConfigurationPropertyAttribute("tag")]
        public string Tag { get; set; }
    }
    public abstract class RegistrationConventionBase : Catel.IoC.IRegistrationConvention
    {
        protected RegistrationConventionBase(Catel.IoC.IServiceLocator serviceLocator, Catel.IoC.RegistrationType registrationType = 0) { }
        public Catel.IoC.IServiceLocator Container { get; set; }
        public Catel.IoC.RegistrationType RegistrationType { get; set; }
        public abstract void Process(System.Collections.Generic.IEnumerable<System.Type> typesToRegister);
    }
    public class RegistrationConventionHandler : Catel.IoC.IRegistrationConventionHandler
    {
        public RegistrationConventionHandler(Catel.IoC.IServiceLocator serviceLocator = null, Catel.IoC.ITypeFactory typeFactory = null) { }
        public Catel.ICompositeFilter<System.Reflection.Assembly> AssemblyFilter { get; }
        public static Catel.IoC.IRegistrationConventionHandler Default { get; }
        public System.Collections.Generic.IEnumerable<Catel.IoC.IRegistrationConvention> RegistrationConventions { get; }
        public Catel.ICompositeFilter<System.Type> TypeFilter { get; }
        public void AddAssemblyToScan(System.Reflection.Assembly assembly) { }
        public void ApplyConventions() { }
        public void RegisterConvention<TRegistrationConvention>(Catel.IoC.RegistrationType registrationType = 0)
            where TRegistrationConvention : Catel.IoC.IRegistrationConvention { }
        protected void RemoveIfAlreadyRegistered(System.Type type) { }
    }
    public class static RegistrationConventionHandlerExtensions
    {
        public static Catel.IoC.IRegistrationConventionHandler AddAssemblyToScan<TAssembly>(this Catel.IoC.IRegistrationConventionHandler registrationConventionHandler)
            where TAssembly : System.Reflection.Assembly { }
        public static Catel.IoC.IRegistrationConventionHandler ExcludeAllTypesOfNamespace(this Catel.IoC.IRegistrationConventionHandler registrationConventionHandler, string @namespace) { }
        public static Catel.IoC.IRegistrationConventionHandler ExcludeAllTypesOfNamespaceContaining<T>(this Catel.IoC.IRegistrationConventionHandler registrationConventionHandler)
            where T :  class { }
        public static Catel.IoC.IRegistrationConventionHandler ExcludeAssembliesWhere(this Catel.IoC.IRegistrationConventionHandler registrationConventionHandler, System.Predicate<System.Reflection.Assembly> exclude) { }
        public static Catel.IoC.IRegistrationConventionHandler ExcludeAssembly<TAssembly>(this Catel.IoC.IRegistrationConventionHandler registrationConventionHandler)
            where TAssembly : System.Reflection.Assembly { }
        public static Catel.IoC.IRegistrationConventionHandler ExcludeType<T>(this Catel.IoC.IRegistrationConventionHandler registrationConventionHandler)
            where T :  class { }
        public static Catel.IoC.IRegistrationConventionHandler ExcludeTypesWhere(this Catel.IoC.IRegistrationConventionHandler registrationConventionHandler, System.Predicate<System.Type> exclude) { }
        public static Catel.IoC.IRegistrationConventionHandler IncludeAllTypesOfNamespace(this Catel.IoC.IRegistrationConventionHandler registrationConventionHandler, string @namespace) { }
        public static Catel.IoC.IRegistrationConventionHandler IncludeAllTypesOfNamespaceContaining<T>(this Catel.IoC.IRegistrationConventionHandler registrationConventionHandler) { }
        public static Catel.IoC.IRegistrationConventionHandler IncludeType<T>(this Catel.IoC.IRegistrationConventionHandler registrationConventionHandler)
            where T :  class { }
        public static Catel.IoC.IRegistrationConventionHandler IncludeTypesWhere(this Catel.IoC.IRegistrationConventionHandler registrationConventionHandler, System.Predicate<System.Type> include) { }
        public static Catel.IoC.IRegistrationConventionHandler ShouldAlsoUseConvention<TRegistrationConvention>(this Catel.IoC.IRegistrationConventionHandler registrationConventionHandler, Catel.IoC.RegistrationType registrationType = 0)
            where TRegistrationConvention : Catel.IoC.IRegistrationConvention { }
    }
    public class RegistrationInfo
    {
        public System.Type DeclaringType { get; }
        public System.Type ImplementingType { get; }
        public bool IsLateBoundRegistration { get; }
        public bool IsTypeInstantiatedForSingleton { get; }
        public Catel.IoC.RegistrationType RegistrationType { get; }
    }
    public enum RegistrationType
    {
        Singleton = 0,
        Transient = 1,
    }
    public class ServiceLocator : Catel.IoC.IServiceLocator, System.IDisposable, System.IServiceProvider
    {
        public ServiceLocator() { }
        public bool AutoRegisterTypesViaAttributes { get; set; }
        public bool CanResolveNonAbstractTypesWithoutRegistration { get; set; }
        public static Catel.IoC.IServiceLocator Default { get; }
        public bool IgnoreRuntimeIncorrectUsageOfRegisterAttribute { get; set; }
        public event System.EventHandler<Catel.IoC.MissingTypeEventArgs> MissingType;
        public event System.EventHandler<Catel.IoC.TypeInstantiatedEventArgs> TypeInstantiated;
        public event System.EventHandler<Catel.IoC.TypeRegisteredEventArgs> TypeRegistered;
        public event System.EventHandler<Catel.IoC.TypeUnregisteredEventArgs> TypeUnregistered;
        [System.ObsoleteAttribute("Use `AreMultipleTypesRegistered` instead. Will be removed in version 6.0.0.", true)]
        public bool AreAllTypesRegistered(params System.Type[] types) { }
        public bool AreMultipleTypesRegistered(params System.Type[] types) { }
        public void Dispose() { }
        public Catel.IoC.RegistrationInfo GetRegistrationInfo(System.Type serviceType, object tag = null) { }
        public bool IsTypeRegistered(System.Type serviceType, object tag = null) { }
        public bool IsTypeRegisteredAsSingleton(System.Type serviceType, object tag = null) { }
        public bool IsTypeRegisteredWithOrWithoutTag(System.Type serviceType) { }
        public void RegisterInstance(System.Type serviceType, object instance, object tag = null) { }
        public void RegisterType(System.Type serviceType, System.Type serviceImplementationType, object tag = null, Catel.IoC.RegistrationType registrationType = 0, bool registerIfAlreadyRegistered = True) { }
        public void RegisterType(System.Type serviceType, System.Func<Catel.IoC.ServiceLocatorRegistration, object> createServiceFunc, object tag = null, Catel.IoC.RegistrationType registrationType = 0, bool registerIfAlreadyRegistered = True) { }
        public void RemoveAllTypes(System.Type serviceType) { }
        public void RemoveType(System.Type serviceType, object tag = null) { }
        [System.ObsoleteAttribute("Use `ResolveMultipleTypes` instead. Will be removed in version 6.0.0.", true)]
        public object[] ResolveAllTypes(params System.Type[] types) { }
        public object[] ResolveMultipleTypes(params System.Type[] types) { }
        public object ResolveType(System.Type serviceType, object tag = null) { }
        public System.Collections.Generic.IEnumerable<object> ResolveTypes(System.Type serviceType) { }
    }
    public class ServiceLocatorAutoRegistrationManager
    {
        public ServiceLocatorAutoRegistrationManager(Catel.IoC.IServiceLocator serviceLocator) { }
        public bool AutoRegisterTypesViaAttributes { get; set; }
        public bool IgnoreRuntimeIncorrectUsageOfRegisterAttribute { get; set; }
    }
    public sealed class ServiceLocatorConfiguration : System.Configuration.ConfigurationElementCollection
    {
        public ServiceLocatorConfiguration(string name = "default") { }
        public override System.Configuration.ConfigurationElementCollectionType CollectionType { get; }
        [System.Configuration.ConfigurationPropertyAttribute("name", DefaultValue="default", IsKey=true, IsRequired=true)]
        public string Name { get; set; }
        public void Configure(Catel.IoC.IServiceLocator serviceLocator) { }
        protected override System.Configuration.ConfigurationElement CreateNewElement() { }
        protected override object GetElementKey(System.Configuration.ConfigurationElement element) { }
        protected override bool IsElementName(string elementName) { }
    }
    public sealed class ServiceLocatorConfigurationCollection : System.Configuration.ConfigurationElementCollection
    {
        public ServiceLocatorConfigurationCollection() { }
        public override System.Configuration.ConfigurationElementCollectionType CollectionType { get; }
        protected override System.Configuration.ConfigurationElement CreateNewElement() { }
        protected override object GetElementKey(System.Configuration.ConfigurationElement element) { }
        protected override bool IsElementName(string elementName) { }
    }
    public class static ServiceLocatorExtensions
    {
        public static bool IsTypeRegistered<TService>(this Catel.IoC.IServiceLocator serviceLocator, object tag = null) { }
        public static bool IsTypeRegisteredAsSingleton<TService>(this Catel.IoC.IServiceLocator serviceLocator, object tag = null) { }
        public static void RegisterInstance<TService>(this Catel.IoC.IServiceLocator serviceLocator, TService instance, object tag = null) { }
        public static void RegisterType<TServiceImplementation>(this Catel.IoC.IServiceLocator serviceLocator, Catel.IoC.RegistrationType registrationType = 0) { }
        public static void RegisterType<TService, TServiceImplementation>(this Catel.IoC.IServiceLocator serviceLocator, Catel.IoC.RegistrationType registrationType = 0, bool registerIfAlreadyRegistered = True)
            where TServiceImplementation : TService { }
        public static void RegisterType<TService>(this Catel.IoC.IServiceLocator serviceLocator, System.Func<Catel.IoC.ServiceLocatorRegistration, TService> createServiceFunc, Catel.IoC.RegistrationType registrationType = 0, bool registerIfAlreadyRegistered = True) { }
        public static TServiceImplementation RegisterTypeAndInstantiate<TServiceImplementation>(this Catel.IoC.IServiceLocator serviceLocator) { }
        public static TService RegisterTypeAndInstantiate<TService, TServiceImplementation>(this Catel.IoC.IServiceLocator serviceLocator)
            where TServiceImplementation : TService { }
        public static void RegisterTypeIfNotYetRegistered<TService, TServiceImplementation>(this Catel.IoC.IServiceLocator serviceLocator, Catel.IoC.RegistrationType registrationType = 0)
            where TServiceImplementation : TService { }
        public static void RegisterTypeIfNotYetRegistered(this Catel.IoC.IServiceLocator serviceLocator, System.Type serviceType, System.Type serviceImplementationType, Catel.IoC.RegistrationType registrationType = 0) { }
        public static void RegisterTypeIfNotYetRegisteredWithTag<TService, TServiceImplementation>(this Catel.IoC.IServiceLocator serviceLocator, object tag = null, Catel.IoC.RegistrationType registrationType = 0)
            where TServiceImplementation : TService { }
        public static void RegisterTypeIfNotYetRegisteredWithTag(this Catel.IoC.IServiceLocator serviceLocator, System.Type serviceType, System.Type serviceImplementationType, object tag = null, Catel.IoC.RegistrationType registrationType = 0) { }
        public static void RegisterTypeWithTag<TServiceImplementation>(this Catel.IoC.IServiceLocator serviceLocator, object tag = null, Catel.IoC.RegistrationType registrationType = 0) { }
        public static void RegisterTypeWithTag<TService, TServiceImplementation>(this Catel.IoC.IServiceLocator serviceLocator, object tag = null, Catel.IoC.RegistrationType registrationType = 0, bool registerIfAlreadyRegistered = True)
            where TServiceImplementation : TService { }
        public static void RegisterTypeWithTag<TService>(this Catel.IoC.IServiceLocator serviceLocator, System.Func<Catel.IoC.ServiceLocatorRegistration, TService> createServiceFunc, object tag = null, Catel.IoC.RegistrationType registrationType = 0, bool registerIfAlreadyRegistered = True) { }
        public static Catel.IoC.IRegistrationConventionHandler RegisterTypesUsingAllConventions(this Catel.IoC.IServiceLocator serviceLocator, Catel.IoC.RegistrationType registrationType = 0) { }
        public static Catel.IoC.IRegistrationConventionHandler RegisterTypesUsingConvention<TRegistrationConvention>(this Catel.IoC.IServiceLocator serviceLocator, Catel.IoC.RegistrationType registrationType = 0)
            where TRegistrationConvention : Catel.IoC.IRegistrationConvention { }
        public static Catel.IoC.IRegistrationConventionHandler RegisterTypesUsingDefaultFirstInterfaceConvention(this Catel.IoC.IServiceLocator serviceLocator, Catel.IoC.RegistrationType registrationType = 0) { }
        public static Catel.IoC.IRegistrationConventionHandler RegisterTypesUsingDefaultNamingConvention(this Catel.IoC.IServiceLocator serviceLocator, Catel.IoC.RegistrationType registrationType = 0) { }
        public static void RemoveType<TService>(this Catel.IoC.IServiceLocator serviceLocator, object tag = null) { }
        public static TService ResolveType<TService>(this Catel.IoC.IServiceLocator serviceLocator, object tag = null) { }
        public static T ResolveTypeAndReturnNullIfNotRegistered<T>(this Catel.IoC.IServiceLocator serviceLocator, object tag = null) { }
        public static object ResolveTypeAndReturnNullIfNotRegistered(this Catel.IoC.IServiceLocator serviceLocator, System.Type serviceType, object tag = null) { }
        public static T ResolveTypeUsingParameters<T>(this Catel.IoC.IServiceLocator serviceLocator, object[] parameters, object tag = null) { }
        public static object ResolveTypeUsingParameters(this Catel.IoC.IServiceLocator serviceLocator, System.Type serviceType, object[] parameters, object tag = null) { }
        public static System.Collections.Generic.IEnumerable<TService> ResolveTypes<TService>(this Catel.IoC.IServiceLocator serviceLocator) { }
        public static TService TryResolveType<TService>(this Catel.IoC.IServiceLocator serviceLocator, object tag = null) { }
    }
    [System.Diagnostics.DebuggerDisplayAttribute("{DeclaringType} => {ImplementingType} ({RegistrationType})")]
    public class ServiceLocatorRegistration
    {
        public ServiceLocatorRegistration(System.Type declaringType, System.Type implementingType, object tag, Catel.IoC.RegistrationType registrationType, System.Func<Catel.IoC.ServiceLocatorRegistration, object> createServiceFunc) { }
        public System.Func<Catel.IoC.ServiceLocatorRegistration, object> CreateServiceFunc { get; }
        public System.Type DeclaringType { get; }
        public string DeclaringTypeName { get; }
        public System.Type ImplementingType { get; }
        public string ImplementingTypeName { get; }
        public Catel.IoC.RegistrationType RegistrationType { get; }
        public object Tag { get; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Class | System.AttributeTargets.All, AllowMultiple=false, Inherited=false)]
    public class ServiceLocatorRegistrationAttribute : System.Attribute
    {
        public ServiceLocatorRegistrationAttribute(System.Type interfaceType, Catel.IoC.ServiceLocatorRegistrationMode registrationMode = 2, object tag = null) { }
        public System.Type InterfaceType { get; }
        public Catel.IoC.ServiceLocatorRegistrationMode RegistrationMode { get; }
        public Catel.IoC.RegistrationType RegistrationType { get; }
        public object Tag { get; }
    }
    public class ServiceLocatorRegistrationGroup
    {
        public ServiceLocatorRegistrationGroup(Catel.IoC.ServiceLocatorRegistration entryRegistration) { }
        public Catel.IoC.ServiceLocatorRegistration EntryRegistration { get; }
    }
    public enum ServiceLocatorRegistrationMode
    {
        Transient = 0,
        SingletonInstantiateImmediately = 1,
        SingletonInstantiateWhenRequired = 2,
    }
    public class TypeFactory : Catel.IoC.ITypeFactory
    {
        public TypeFactory(Catel.IoC.IServiceLocator serviceLocator) { }
        public static Catel.IoC.ITypeFactory Default { get; }
        public void ClearCache() { }
        public object CreateInstance(System.Type typeToConstruct) { }
        public object CreateInstanceWithParameters(System.Type typeToConstruct, params object[] parameters) { }
        public object CreateInstanceWithParametersAndAutoCompletion(System.Type typeToConstruct, params object[] parameters) { }
        public object CreateInstanceWithParametersAndAutoCompletionWithTag(System.Type typeToConstruct, object tag, params object[] parameters) { }
        public object CreateInstanceWithParametersWithTag(System.Type typeToConstruct, object tag, params object[] parameters) { }
        public object CreateInstanceWithTag(System.Type typeToConstruct, object tag) { }
    }
    public class static TypeFactoryExtensions
    {
        public static T CreateInstance<T>(this Catel.IoC.ITypeFactory typeFactory) { }
        public static T CreateInstanceWithParameters<T>(this Catel.IoC.ITypeFactory typeFactory, params object[] parameters) { }
        public static T CreateInstanceWithParametersAndAutoCompletion<T>(this Catel.IoC.ITypeFactory typeFactory, params object[] parameters) { }
        public static T CreateInstanceWithParametersAndAutoCompletionWithTag<T>(this Catel.IoC.ITypeFactory typeFactory, object tag, params object[] parameters) { }
        public static T CreateInstanceWithParametersWithTag<T>(this Catel.IoC.ITypeFactory typeFactory, object tag, params object[] parameters) { }
        public static T CreateInstanceWithTag<T>(this Catel.IoC.ITypeFactory typeFactory, object tag) { }
    }
    public class TypeInstantiatedEventArgs : System.EventArgs
    {
        public TypeInstantiatedEventArgs(System.Type serviceType, System.Type serviceImplementationType, object tag, Catel.IoC.RegistrationType registrationType) { }
        public TypeInstantiatedEventArgs(System.Type serviceType, System.Type serviceImplementationType, object tag, Catel.IoC.RegistrationType registrationType, object instance) { }
        public object Instance { get; }
        public Catel.IoC.RegistrationType RegistrationType { get; }
        public System.Type ServiceImplementationType { get; }
        public System.Type ServiceType { get; }
        public object Tag { get; }
    }
    public class TypeNotRegisteredException : System.Exception
    {
        public TypeNotRegisteredException(System.Type requestedType, string message) { }
        public System.Type RequestedType { get; }
    }
    public class TypeRegisteredEventArgs : System.EventArgs
    {
        public TypeRegisteredEventArgs(System.Type serviceType, System.Type serviceImplementationType, object tag, Catel.IoC.RegistrationType registrationType) { }
        public Catel.IoC.RegistrationType RegistrationType { get; }
        public System.Type ServiceImplementationType { get; }
        public System.Type ServiceType { get; }
        public object Tag { get; }
    }
    public class TypeRequestInfo
    {
        public TypeRequestInfo(System.Type type, object tag = null) { }
        public object Tag { get; }
        public System.Type Type { get; }
        public override bool Equals(object obj) { }
        public override int GetHashCode() { }
        public override string ToString() { }
        public static bool ==(Catel.IoC.TypeRequestInfo firstObject, Catel.IoC.TypeRequestInfo secondObject) { }
        public static bool !=(Catel.IoC.TypeRequestInfo firstObject, Catel.IoC.TypeRequestInfo secondObject) { }
    }
    public class TypeRequestPath : Catel.IoC.ITypeRequestPath
    {
        public System.Collections.Generic.IEnumerable<Catel.IoC.TypeRequestInfo> AllTypes { get; }
        public Catel.IoC.TypeRequestInfo FirstType { get; }
        public Catel.IoC.TypeRequestInfo LastType { get; }
        public string Name { get; }
        public int TypeCount { get; }
        public static Catel.IoC.TypeRequestPath Branch(Catel.IoC.TypeRequestPath parent, Catel.IoC.TypeRequestInfo typeRequestInfo) { }
        public static Catel.IoC.TypeRequestPath Root(string name = null) { }
        public override string ToString() { }
    }
    public class TypeUnregisteredEventArgs : System.EventArgs
    {
        public TypeUnregisteredEventArgs(System.Type serviceType, System.Type serviceImplementationType, object tag, Catel.IoC.RegistrationType registrationType) { }
        public TypeUnregisteredEventArgs(System.Type serviceType, System.Type serviceImplementationType, object tag, Catel.IoC.RegistrationType registrationType, object instance) { }
        public object Instance { get; }
        public Catel.IoC.RegistrationType RegistrationType { get; }
        public System.Type ServiceImplementationType { get; }
        public System.Type ServiceType { get; }
        public object Tag { get; }
    }
}
namespace Catel.Linq
{
    public class static EnumerableExtensions
    {
        public static System.Collections.IEnumerable AsReadOnly(this System.Collections.IEnumerable instance, System.Type type) { }
        public static System.Collections.IEnumerable Cast(this System.Collections.IEnumerable instance, System.Type type) { }
        public static System.Collections.IEnumerable ToList(this System.Collections.IEnumerable instance, System.Type type) { }
        public static System.Collections.IEnumerable ToSystemArray(this System.Collections.IEnumerable instance, System.Type type) { }
    }
}
namespace Catel.Logging
{
    public abstract class BatchLogListenerBase : Catel.Logging.LogListenerBase, Catel.Logging.IBatchLogListener
    {
        public BatchLogListenerBase(int maxBatchCount = 100) { }
        public BatchLogListenerBase(System.TimeSpan interval, int maxBatchCount = 100) { }
        protected System.TimeSpan Interval { get; set; }
        public int MaximumBatchCount { get; }
        public System.Threading.Tasks.Task FlushAsync() { }
        protected override void Write(Catel.Logging.ILog log, string message, Catel.Logging.LogEvent logEvent, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
        protected virtual System.Threading.Tasks.Task WriteBatchAsync(System.Collections.Generic.List<Catel.Logging.LogBatchEntry> batchEntries) { }
    }
    public class ConsoleLogListener : Catel.Logging.LogListenerBase
    {
        public ConsoleLogListener() { }
        protected override void Write(Catel.Logging.ILog log, string message, Catel.Logging.LogEvent logEvent, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
    }
    public class DebugLogListener : Catel.Logging.LogListenerBase
    {
        public DebugLogListener() { }
        protected override void Write(Catel.Logging.ILog log, string message, Catel.Logging.LogEvent logEvent, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
    }
    public class EtwLogListener : Catel.Logging.LogListenerBase
    {
        public EtwLogListener() { }
        protected override void Write(Catel.Logging.ILog log, string message, Catel.Logging.LogEvent logEvent, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
    }
    public class EventLogListener : Catel.Logging.BatchLogListenerBase
    {
        public EventLogListener() { }
        public string LogName { get; }
        public string MachineName { get; }
        public string Source { get; set; }
        protected override string FormatLogEvent(Catel.Logging.ILog log, string message, Catel.Logging.LogEvent logEvent, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
        protected override System.Threading.Tasks.Task WriteBatchAsync(System.Collections.Generic.List<Catel.Logging.LogBatchEntry> batchEntries) { }
    }
    public class FileLogListener : Catel.Logging.BatchLogListenerBase
    {
        public FileLogListener(System.Reflection.Assembly assembly = null) { }
        public FileLogListener(string filePath, int maxSizeInKiloBytes, System.Reflection.Assembly assembly = null) { }
        public string FilePath { get; set; }
        public int MaxSizeInKiloBytes { get; set; }
        protected virtual string DetermineFilePath(string filePath) { }
        protected override System.Threading.Tasks.Task WriteBatchAsync(System.Collections.Generic.List<Catel.Logging.LogBatchEntry> batchEntries) { }
        public class static FilePathKeyword
        {
            public const string AppData = "{AppData}";
            public const string AppDataLocal = "{AppDataLocal}";
            public const string AppDataMachine = "{AppDataMachine}";
            public const string AppDataRoaming = "{AppDataRoaming}";
            public const string AppDir = "{AppDir}";
            public const string AssemblyCompany = "{AssemblyCompany}";
            public const string AssemblyName = "{AssemblyName}";
            public const string AssemblyProduct = "{AssemblyProduct}";
            public const string AutoLogFileName = "{AutoLogFileName}";
            public const string Date = "{Date}";
            public const string ProcessId = "{ProcessId}";
            public const string Time = "{Time}";
            public const string WorkDir = "{WorkDir}";
        }
    }
    public interface IBatchLogListener
    {
        System.Threading.Tasks.Task FlushAsync();
    }
    public class static IBatchLogListenerExtensions { }
    public interface IJsonLogFormatter
    {
        string FormatLogEvent(Catel.Logging.ILog log, string message, Catel.Logging.LogEvent logEvent, System.DateTime time);
    }
    public interface ILog
    {
        int IndentLevel { get; set; }
        int IndentSize { get; set; }
        bool IsCatelLogging { get; }
        string Name { get; }
        object Tag { get; set; }
        System.Type TargetType { get; }
        public event System.EventHandler<Catel.Logging.LogMessageEventArgs> LogMessage;
        void Indent();
        void Unindent();
        void WriteWithData(string message, object extraData, Catel.Logging.LogEvent logEvent);
        void WriteWithData(string message, Catel.Logging.LogData logData, Catel.Logging.LogEvent logEvent);
    }
    public interface ILogListener
    {
        bool IgnoreCatelLogging { get; set; }
        bool IsDebugEnabled { get; set; }
        bool IsErrorEnabled { get; set; }
        bool IsInfoEnabled { get; set; }
        bool IsStatusEnabled { get; set; }
        bool IsWarningEnabled { get; set; }
        Catel.Logging.TimeDisplay TimeDisplay { get; set; }
        public event System.EventHandler<Catel.Logging.LogMessageEventArgs> LogMessage;
        void Debug(Catel.Logging.ILog log, string message, object extraData, Catel.Logging.LogData logData, System.DateTime time);
        void Error(Catel.Logging.ILog log, string message, object extraData, Catel.Logging.LogData logData, System.DateTime time);
        void Info(Catel.Logging.ILog log, string message, object extraData, Catel.Logging.LogData logData, System.DateTime time);
        void Status(Catel.Logging.ILog log, string message, object extraData, Catel.Logging.LogData logData, System.DateTime time);
        void Warning(Catel.Logging.ILog log, string message, object extraData, Catel.Logging.LogData logData, System.DateTime time);
        void Write(Catel.Logging.ILog log, string message, Catel.Logging.LogEvent logEvent, object extraData, Catel.Logging.LogData logData, System.DateTime time);
    }
    public class JsonLogFormatter : Catel.Logging.IJsonLogFormatter
    {
        protected static readonly System.Collections.Generic.IDictionary<System.Type, System.Action<object, bool, System.IO.TextWriter>> LiteralWriters;
        protected static readonly System.Collections.Generic.Dictionary<Catel.Logging.LogEvent, string> LogEventStrings;
        public JsonLogFormatter() { }
        public string FormatLogEvent(Catel.Logging.ILog log, string message, Catel.Logging.LogEvent logEvent, System.DateTime time) { }
    }
    public class Log : Catel.Logging.ILog
    {
        public Log(System.Type targetType) { }
        public Log(string name) { }
        public Log(string name, System.Type targetType) { }
        public int IndentLevel { get; set; }
        public int IndentSize { get; set; }
        public virtual bool IsCatelLogging { get; }
        public string Name { get; }
        public object Tag { get; set; }
        public System.Type TargetType { get; }
        public event System.EventHandler<Catel.Logging.LogMessageEventArgs> LogMessage;
        public void Indent() { }
        protected virtual bool ShouldIgnoreIfCatelLoggingIsDisabled() { }
        public void Unindent() { }
        public void WriteWithData(string message, object extraData, Catel.Logging.LogEvent logEvent) { }
        public void WriteWithData(string message, Catel.Logging.LogData logData, Catel.Logging.LogEvent logEvent) { }
    }
    public class LogBatchEntry : Catel.Logging.LogEntry
    {
        public LogBatchEntry(Catel.Logging.ILog log, string message, Catel.Logging.LogEvent logEvent, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
    }
    public class LogData : System.Collections.Generic.Dictionary<string, object>
    {
        public LogData() { }
        public LogData(System.Collections.Generic.IDictionary<string, object> values) { }
    }
    public class LogEntry
    {
        public LogEntry(Catel.Logging.LogMessageEventArgs eventArgs) { }
        public LogEntry(Catel.Logging.ILog log, string message, Catel.Logging.LogEvent logEvent, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
        public Catel.Logging.LogData Data { get; }
        public object ExtraData { get; }
        public Catel.Logging.ILog Log { get; }
        public Catel.Logging.LogEvent LogEvent { get; }
        public string Message { get; }
        public System.DateTime Time { get; }
        public override string ToString() { }
    }
    [System.FlagsAttribute()]
    public enum LogEvent
    {
        Debug = 1,
        Info = 2,
        Warning = 4,
        Error = 8,
        Status = 16,
    }
    public class static LogExtensions
    {
        public static void Debug(this Catel.Logging.ILog log) { }
        public static void Debug(this Catel.Logging.ILog log, Catel.Logging.LogEvent logEvent, string messageFormat, object s1) { }
        public static void Debug(this Catel.Logging.ILog log, string messageFormat, object s1, object s2) { }
        public static void Debug(this Catel.Logging.ILog log, string messageFormat, object s1, object s2, object s3) { }
        public static void Debug(this Catel.Logging.ILog log, string messageFormat, object s1, object s2, object s3, object s4) { }
        public static void Debug(this Catel.Logging.ILog log, string messageFormat, object s1, object s2, object s3, object s4, object s5, params object[] others) { }
        public static void Debug(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void Debug(this Catel.Logging.ILog log, System.Exception exception) { }
        public static void Debug(this Catel.Logging.ILog log, System.Exception exception, string messageFormat, params object[] args) { }
        public static void DebugAndStatus(this Catel.Logging.ILog log) { }
        public static void DebugAndStatus(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void DebugWithData(this Catel.Logging.ILog log, string message, object extraData = null) { }
        public static void DebugWithData(this Catel.Logging.ILog log, string message, Catel.Logging.LogData logData) { }
        public static void DebugWithData(this Catel.Logging.ILog log, System.Exception exception, string message, object extraData = null) { }
        public static void Error(this Catel.Logging.ILog log) { }
        public static void Error(this Catel.Logging.ILog log, string messageFormat, object s1) { }
        public static void Error(this Catel.Logging.ILog log, string messageFormat, object s1, object s2) { }
        public static void Error(this Catel.Logging.ILog log, string messageFormat, object s1, object s2, object s3) { }
        public static void Error(this Catel.Logging.ILog log, string messageFormat, object s1, object s2, object s3, object s4) { }
        public static void Error(this Catel.Logging.ILog log, string messageFormat, object s1, object s2, object s3, object s4, object s5, params object[] others) { }
        public static void Error(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void Error(this Catel.Logging.ILog log, System.Exception exception) { }
        public static void Error(this Catel.Logging.ILog log, System.Exception exception, string messageFormat, params object[] args) { }
        public static System.Exception ErrorAndCreateException<TException>(this Catel.Logging.ILog log, string messageFormat, params object[] args)
            where TException : System.Exception { }
        public static System.Exception ErrorAndCreateException<TException>(this Catel.Logging.ILog log, System.Func<string, TException> createExceptionCallback, string messageFormat, params object[] args)
            where TException : System.Exception { }
        public static System.Exception ErrorAndCreateException<TException>(this Catel.Logging.ILog log, System.Exception innerException, string messageFormat, params object[] args)
            where TException : System.Exception { }
        public static System.Exception ErrorAndCreateException<TException>(this Catel.Logging.ILog log, System.Exception innerException, System.Func<string, TException> createExceptionCallback, string messageFormat, params object[] args)
            where TException : System.Exception { }
        public static void ErrorAndStatus(this Catel.Logging.ILog log) { }
        public static void ErrorAndStatus(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void ErrorWithData(this Catel.Logging.ILog log, string message, object extraData = null) { }
        public static void ErrorWithData(this Catel.Logging.ILog log, string message, Catel.Logging.LogData logData) { }
        public static void ErrorWithData(this Catel.Logging.ILog log, System.Exception exception, string message, object extraData = null) { }
        public static void Info(this Catel.Logging.ILog log) { }
        public static void Info(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void Info(this Catel.Logging.ILog log, System.Exception exception) { }
        public static void Info(this Catel.Logging.ILog log, System.Exception exception, string messageFormat, params object[] args) { }
        public static void InfoAndStatus(this Catel.Logging.ILog log) { }
        public static void InfoAndStatus(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void InfoWithData(this Catel.Logging.ILog log, string message, object extraData = null) { }
        public static void InfoWithData(this Catel.Logging.ILog log, string message, Catel.Logging.LogData logData) { }
        public static void InfoWithData(this Catel.Logging.ILog log, System.Exception exception, string message, object extraData = null) { }
        public static bool IsCatelLoggingAndCanBeIgnored(this Catel.Logging.ILog log) { }
        public static void LogDebugHeading(this Catel.Logging.ILog log, string headingContent, string messageFormat, params object[] args) { }
        public static void LogDebugHeading1(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void LogDebugHeading2(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void LogDebugHeading3(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void LogDeviceInfo(this Catel.Logging.ILog log) { }
        public static void LogErrorHeading(this Catel.Logging.ILog log, string headingContent, string messageFormat, params object[] args) { }
        public static void LogErrorHeading1(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void LogErrorHeading2(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void LogErrorHeading3(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void LogHeading(this Catel.Logging.ILog log, Catel.Logging.LogEvent logEvent, string headingContent, string messageFormat, params object[] args) { }
        public static void LogInfoHeading(this Catel.Logging.ILog log, string headingContent, string messageFormat, params object[] args) { }
        public static void LogInfoHeading1(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void LogInfoHeading2(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void LogInfoHeading3(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void LogProductInfo(this Catel.Logging.ILog log) { }
        public static void LogWarningHeading(this Catel.Logging.ILog log, string headingContent, string messageFormat, params object[] args) { }
        public static void LogWarningHeading1(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void LogWarningHeading2(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void LogWarningHeading3(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void Status(this Catel.Logging.ILog log) { }
        public static void Status(this Catel.Logging.ILog log, string messageFormat, object s1) { }
        public static void Status(this Catel.Logging.ILog log, string messageFormat, object s1, object s2) { }
        public static void Status(this Catel.Logging.ILog log, string messageFormat, object s1, object s2, object s3) { }
        public static void Status(this Catel.Logging.ILog log, string messageFormat, object s1, object s2, object s3, object s4) { }
        public static void Status(this Catel.Logging.ILog log, string messageFormat, object s1, object s2, object s3, object s4, object s5, params object[] others) { }
        public static void Status(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void Warning(this Catel.Logging.ILog log) { }
        public static void Warning(this Catel.Logging.ILog log, string messageFormat, object s1) { }
        public static void Warning(this Catel.Logging.ILog log, string messageFormat, object s1, object s2) { }
        public static void Warning(this Catel.Logging.ILog log, string messageFormat, object s1, object s2, object s3) { }
        public static void Warning(this Catel.Logging.ILog log, string messageFormat, object s1, object s2, object s3, object s4) { }
        public static void Warning(this Catel.Logging.ILog log, string messageFormat, object s1, object s2, object s3, object s4, object s5, params object[] others) { }
        public static void Warning(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void Warning(this Catel.Logging.ILog log, System.Exception exception) { }
        public static void Warning(this Catel.Logging.ILog log, System.Exception exception, string messageFormat, params object[] args) { }
        public static void WarningAndStatus(this Catel.Logging.ILog log) { }
        public static void WarningAndStatus(this Catel.Logging.ILog log, string messageFormat, params object[] args) { }
        public static void WarningWithData(this Catel.Logging.ILog log, string message, object extraData = null) { }
        public static void WarningWithData(this Catel.Logging.ILog log, string message, Catel.Logging.LogData logData) { }
        public static void WarningWithData(this Catel.Logging.ILog log, System.Exception exception, string message, object extraData = null) { }
        public static void Write(this Catel.Logging.ILog log, Catel.Logging.LogEvent logEvent, string messageFormat, object s1) { }
        public static void Write(this Catel.Logging.ILog log, Catel.Logging.LogEvent logEvent, string messageFormat, object s1, object s2) { }
        public static void Write(this Catel.Logging.ILog log, Catel.Logging.LogEvent logEvent, string messageFormat, object s1, object s2, object s3) { }
        public static void Write(this Catel.Logging.ILog log, Catel.Logging.LogEvent logEvent, string messageFormat, object s1, object s2, object s3, object s4) { }
        public static void Write(this Catel.Logging.ILog log, Catel.Logging.LogEvent logEvent, string messageFormat, object s1, object s2, object s3, object s4, object s5, params object[] others) { }
        public static void Write(this Catel.Logging.ILog log, Catel.Logging.LogEvent logEvent, string messageFormat, params object[] args) { }
        public static void Write(this Catel.Logging.ILog log, Catel.Logging.LogEvent logEvent, System.Exception exception, string messageFormat, params object[] args) { }
        public static void WriteWithData(this Catel.Logging.ILog log, System.Exception exception, string message, object extraData, Catel.Logging.LogEvent logEvent) { }
    }
    public abstract class LogListenerBase : Catel.Logging.ILogListener
    {
        protected static readonly System.Collections.Generic.Dictionary<Catel.Logging.LogEvent, string> LogEventStrings;
        protected LogListenerBase(bool ignoreCatelLogging = False) { }
        public bool IgnoreCatelLogging { get; set; }
        public bool IsDebugEnabled { get; set; }
        public bool IsErrorEnabled { get; set; }
        public bool IsInfoEnabled { get; set; }
        public bool IsStatusEnabled { get; set; }
        public bool IsWarningEnabled { get; set; }
        public Catel.Logging.TimeDisplay TimeDisplay { get; set; }
        public event System.EventHandler<Catel.Logging.LogMessageEventArgs> LogMessage;
        protected virtual void Debug(Catel.Logging.ILog log, string message, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
        protected virtual void Error(Catel.Logging.ILog log, string message, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
        protected virtual string FormatLogEvent(Catel.Logging.ILog log, string message, Catel.Logging.LogEvent logEvent, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
        protected virtual void Info(Catel.Logging.ILog log, string message, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
        protected void RaiseLogMessage(Catel.Logging.ILog log, string message, Catel.Logging.LogEvent logEvent, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
        protected virtual bool ShouldIgnoreLogMessage(Catel.Logging.ILog log, string message, Catel.Logging.LogEvent logEvent, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
        protected virtual void Status(Catel.Logging.ILog log, string message, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
        protected virtual void Warning(Catel.Logging.ILog log, string message, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
        protected virtual void Write(Catel.Logging.ILog log, string message, Catel.Logging.LogEvent logEvent, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
    }
    public sealed class LogListenerConfiguration : System.Configuration.ConfigurationElement
    {
        public LogListenerConfiguration() { }
        [System.Configuration.ConfigurationPropertyAttribute("type", IsRequired=true)]
        public string Type { get; set; }
        public Catel.Logging.ILogListener GetLogListener(System.Reflection.Assembly assembly = null) { }
        protected override bool OnDeserializeUnrecognizedAttribute(string name, string value) { }
    }
    public sealed class LogListenerConfigurationCollection : System.Configuration.ConfigurationElementCollection
    {
        public LogListenerConfigurationCollection() { }
        public override System.Configuration.ConfigurationElementCollectionType CollectionType { get; }
        protected override System.Configuration.ConfigurationElement CreateNewElement() { }
        protected override object GetElementKey(System.Configuration.ConfigurationElement element) { }
        protected override bool IsElementName(string elementName) { }
    }
    public class static LogManager
    {
        public static System.Nullable<bool> IgnoreCatelLogging { get; set; }
        public static System.Nullable<bool> IgnoreDuplicateExceptionLogging { get; set; }
        public static System.Nullable<bool> IsDebugEnabled { get; set; }
        public static System.Nullable<bool> IsErrorEnabled { get; set; }
        public static System.Nullable<bool> IsInfoEnabled { get; set; }
        public static System.Nullable<bool> IsStatusEnabled { get; set; }
        public static System.Nullable<bool> IsWarningEnabled { get; set; }
        public event System.EventHandler<Catel.Logging.LogMessageEventArgs> LogMessage;
        public static Catel.Logging.ILogListener AddDebugListener(bool ignoreCatelLogging = False) { }
        public static void AddListener(Catel.Logging.ILogListener listener) { }
        public static void ClearListeners() { }
        [System.ObsoleteAttribute("Since listeners only have FlushAsync, a non-async flush doesn\'t make sense. Use `" +
            "FlushAllAsync` instead. Will be removed in version 6.0.0.", true)]
        public static void FlushAll() { }
        public static System.Threading.Tasks.Task FlushAllAsync() { }
        public static Catel.Logging.ILog GetCurrentClassLogger() { }
        public static System.Collections.Generic.IEnumerable<Catel.Logging.ILogListener> GetListeners() { }
        public static Catel.Logging.ILog GetLogger<T>() { }
        public static Catel.Logging.ILog GetLogger(System.Type type) { }
        public static Catel.Logging.ILog GetLogger(string name) { }
        public static Catel.Logging.ILog GetLogger(string name, System.Type type) { }
        public static bool IsListenerRegistered(Catel.Logging.ILogListener listener) { }
        public static void LoadListenersFromConfiguration(System.Configuration.Configuration configuration, System.Reflection.Assembly assembly = null) { }
        public static void LoadListenersFromConfigurationFile(string configurationFilePath, System.Reflection.Assembly assembly = null) { }
        public static void RemoveListener(Catel.Logging.ILogListener listener) { }
        public class static LogInfo
        {
            public static bool IgnoreCatelLogging { get; }
            public static bool IgnoreDuplicateExceptionLogging { get; }
            public static bool IsDebugEnabled { get; }
            public static bool IsEnabled { get; }
            public static bool IsErrorEnabled { get; }
            public static bool IsInfoEnabled { get; }
            public static bool IsStatusEnabled { get; }
            public static bool IsWarningEnabled { get; }
            public static bool IsLogEventEnabled(Catel.Logging.LogEvent logEvent) { }
        }
    }
    public class LogMessageEventArgs : System.EventArgs
    {
        public LogMessageEventArgs(Catel.Logging.ILog log, string message, object extraData, Catel.Logging.LogData logData, Catel.Logging.LogEvent logEvent) { }
        public LogMessageEventArgs(Catel.Logging.ILog log, string message, object extraData, Catel.Logging.LogData logData, Catel.Logging.LogEvent logEvent, System.DateTime time) { }
        public object ExtraData { get; }
        public Catel.Logging.ILog Log { get; }
        public Catel.Logging.LogData LogData { get; }
        public Catel.Logging.LogEvent LogEvent { get; }
        public string Message { get; }
        public object Tag { get; }
        public System.DateTime Time { get; }
    }
    public sealed class LoggingConfigurationSection : System.Configuration.ConfigurationSection
    {
        public LoggingConfigurationSection() { }
        [System.Configuration.ConfigurationPropertyAttribute("listeners", IsDefaultCollection=false)]
        public Catel.Logging.LogListenerConfigurationCollection LogListenerConfigurationCollection { get; }
        public System.Collections.Generic.IEnumerable<Catel.Logging.ILogListener> GetLogListeners(System.Reflection.Assembly assembly = null) { }
    }
    public class RollingInMemoryLogListener : Catel.Logging.LogListenerBase
    {
        public RollingInMemoryLogListener() { }
        public int MaximumNumberOfErrorLogEntries { get; set; }
        public int MaximumNumberOfLogEntries { get; set; }
        public int MaximumNumberOfWarningLogEntries { get; set; }
        public System.Collections.Generic.IEnumerable<Catel.Logging.LogEntry> GetErrorLogEntries() { }
        public System.Collections.Generic.IEnumerable<Catel.Logging.LogEntry> GetLogEntries() { }
        public System.Collections.Generic.IEnumerable<Catel.Logging.LogEntry> GetWarningLogEntries() { }
        protected override void Write(Catel.Logging.ILog log, string message, Catel.Logging.LogEvent logEvent, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
    }
    public class SeqLogListener : Catel.Logging.BatchLogListenerBase, System.IDisposable
    {
        public SeqLogListener() { }
        public string ApiKey { get; set; }
        public string ServerUrl { get; set; }
        public void Dispose() { }
        protected override string FormatLogEvent(Catel.Logging.ILog log, string message, Catel.Logging.LogEvent logEvent, object extraData, Catel.Logging.LogData logData, System.DateTime time) { }
        protected override System.Threading.Tasks.Task WriteBatchAsync(System.Collections.Generic.List<Catel.Logging.LogBatchEntry> batchEntries) { }
    }
    public class StatusLogListener : Catel.Logging.LogListenerBase
    {
        public StatusLogListener() { }
    }
    public enum TimeDisplay
    {
        Time = 0,
        DateTime = 1,
    }
}
namespace Catel.Messaging
{
    public class CombinedMessage : Catel.Messaging.MessageBase<Catel.Messaging.CombinedMessage, bool>
    {
        public CombinedMessage() { }
        public System.Exception Exception { get; }
        public static void SendWith(bool data, System.Exception exception, object tag = null) { }
    }
    public interface IMessageMediator
    {
        void CleanUp();
        bool IsMessageRegistered<TMessage>(object tag = null);
        bool IsMessageRegistered(System.Type messageType, object tag = null);
        bool Register<TMessage>(object recipient, System.Action<TMessage> handler, object tag = null);
        bool SendMessage<TMessage>(TMessage message, object tag = null);
        bool Unregister<TMessage>(object recipient, System.Action<TMessage> handler, object tag = null);
        bool UnregisterRecipient(object recipient, object tag = null);
        bool UnregisterRecipientAndIgnoreTags(object recipient);
    }
    public abstract class MessageBase<TMessage, TData>
        where TMessage : Catel.Messaging.MessageBase<, >, new ()
    {
        protected MessageBase() { }
        protected MessageBase(TData data) { }
        public TData Data { get; set; }
        public static void Register(object recipient, System.Action<TMessage> handler, object tag = null) { }
        protected static void Send(TMessage message, object tag = null) { }
        public static void SendWith(TData data, object tag = null) { }
        public static void Unregister(object recipient, System.Action<TMessage> handler, object tag = null) { }
        public static TMessage With(TData data) { }
    }
    public class MessageMediator : Catel.Messaging.IMessageMediator
    {
        public MessageMediator() { }
        public static Catel.Messaging.IMessageMediator Default { get; }
        public void CleanUp() { }
        public bool IsMessageRegistered<TMessage>(object tag = null) { }
        public bool IsMessageRegistered(System.Type messageType, object tag = null) { }
        public bool IsRegistered<TMessage>(object recipient, System.Action<TMessage> handler, object tag = null) { }
        public bool Register<TMessage>(object recipient, System.Action<TMessage> handler, object tag = null) { }
        public bool SendMessage<TMessage>(TMessage message, object tag = null) { }
        public bool Unregister<TMessage>(object recipient, System.Action<TMessage> handler, object tag = null) { }
        public bool UnregisterRecipient(object recipient, object tag = null) { }
        public bool UnregisterRecipient(object recipient, object tag, bool ignoreTag) { }
        public bool UnregisterRecipientAndIgnoreTags(object recipient) { }
    }
    public class static MessageMediatorHelper
    {
        public static void SubscribeRecipient(object instance, Catel.Messaging.IMessageMediator messageMediator = null) { }
        public static void UnsubscribeRecipient(object instance, Catel.Messaging.IMessageMediator messageMediator = null) { }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Method | System.AttributeTargets.All, AllowMultiple=false, Inherited=true)]
    public sealed class MessageRecipientAttribute : System.Attribute
    {
        public MessageRecipientAttribute() { }
        public object Tag { get; set; }
    }
    public class SimpleMessage : Catel.Messaging.MessageBase<Catel.Messaging.SimpleMessage, string>
    {
        public SimpleMessage() { }
    }
}
namespace Catel.Pooling
{
    public class Buffer4096Poolable : Catel.Pooling.BufferPoolableBase
    {
        public Buffer4096Poolable() { }
    }
    public abstract class BufferPoolableBase : Catel.Pooling.PoolableBase
    {
        protected BufferPoolableBase(int size) { }
        public byte[] Data { get; }
        public override int Size { get; }
        public override void Reset() { }
    }
    public interface IPoolManager
    {
        int Count { get; }
        void ReturnObject(object value);
    }
    public interface IPoolManager<TPoolable> : Catel.Pooling.IPoolManager
        where TPoolable :  class, Catel.Pooling.IPoolable, new ()
    {
        int CurrentSize { get; }
        TPoolable GetObject();
    }
    public interface IPoolable : System.IDisposable
    {
        int Size { get; }
        void Reset();
        void SetPoolManager(Catel.Pooling.IPoolManager poolManager);
    }
    public class PoolManager<TPoolable> : Catel.Pooling.IPoolManager, Catel.Pooling.IPoolManager<TPoolable>
        where TPoolable :  class, Catel.Pooling.IPoolable, new ()
    {
        public PoolManager() { }
        public int Count { get; }
        public int CurrentSize { get; }
        public int MaxSize { get; set; }
        public TPoolable GetObject() { }
        public void ReturnObject(TPoolable value) { }
    }
    public abstract class PoolableBase : Catel.IUniqueIdentifyable, Catel.Pooling.IPoolable, System.IDisposable
    {
        protected Catel.Pooling.IPoolManager _poolManager;
        protected PoolableBase() { }
        public abstract int Size { get; }
        public int UniqueIdentifier { get; }
        public void Dispose() { }
        public abstract void Reset();
    }
}
namespace Catel.Reflection
{
    public class static AppDomainExtensions
    {
        public static T CreateInstanceAndUnwrap<T>(this System.AppDomain appDomain)
            where T : new() { }
        public static void LoadAssemblyIntoAppDomain(this System.AppDomain appDomain, string assemblyFilename, bool includeReferencedAssemblies = True) { }
        public static void LoadAssemblyIntoAppDomain(this System.AppDomain appDomain, System.Reflection.Assembly assembly, bool includeReferencedAssemblies = True) { }
        public static void LoadAssemblyIntoAppDomain(this System.AppDomain appDomain, System.Reflection.Assembly assembly, bool includeReferencedAssemblies, System.Collections.Generic.HashSet<string> alreadyLoadedAssemblies) { }
        public static void LoadAssemblyIntoAppDomain(this System.AppDomain appDomain, System.Reflection.AssemblyName assemblyName, bool includeReferencedAssemblies = True) { }
        public static void PreloadAssemblies(this System.AppDomain appDomain, string directory = null) { }
    }
    public class static AssemblyExtensions
    {
        public static string Company(this System.Reflection.Assembly assembly) { }
        public static string Copyright(this System.Reflection.Assembly assembly) { }
        public static string Description(this System.Reflection.Assembly assembly) { }
        public static System.DateTime GetBuildDateTime(this System.Reflection.Assembly assembly) { }
        public static string GetDirectory(this System.Reflection.Assembly assembly) { }
        public static string InformationalVersion(this System.Reflection.Assembly assembly) { }
        public static string Product(this System.Reflection.Assembly assembly) { }
        public static string Title(this System.Reflection.Assembly assembly) { }
        public static string Version(this System.Reflection.Assembly assembly, int separatorCount = 3) { }
    }
    public class static AssemblyHelper
    {
        public static System.Type[] GetAllTypesSafely(this System.Reflection.Assembly assembly, bool logLoaderExceptions = True) { }
        public static string GetAssemblyNameWithVersion(string assemblyNameWithoutVersion) { }
        public static System.Reflection.Assembly GetEntryAssembly() { }
        public static System.DateTime GetLinkerTimestamp(string fileName) { }
        public static System.Collections.Generic.List<System.Reflection.Assembly> GetLoadedAssemblies() { }
        public static System.Collections.Generic.List<System.Reflection.Assembly> GetLoadedAssemblies(this System.AppDomain appDomain) { }
        public static System.Collections.Generic.List<System.Reflection.Assembly> GetLoadedAssemblies(this System.AppDomain appDomain, bool ignoreDynamicAssemblies) { }
        public static bool IsDynamicAssembly(this System.Reflection.Assembly assembly) { }
    }
    public class AssemblyLoadedEventArgs : System.EventArgs
    {
        public AssemblyLoadedEventArgs(System.Reflection.Assembly assembly, System.Collections.Generic.IEnumerable<System.Type> loadedTypes) { }
        public System.Reflection.Assembly Assembly { get; }
        public System.Collections.Generic.IEnumerable<System.Type> LoadedTypes { get; }
    }
    public class static BindingFlagsHelper
    {
        public const System.Reflection.BindingFlags DefaultBindingFlags = 52;
        public static System.Reflection.BindingFlags GetFinalBindingFlags(bool flattenHierarchy, bool allowStaticMembers, System.Nullable<bool> allowNonPublicMembers = null) { }
    }
    public class CachedPropertyInfo
    {
        public CachedPropertyInfo(System.Reflection.PropertyInfo propertyInfo) { }
        public bool HasPublicGetter { get; }
        public bool HasPublicSetter { get; }
        public System.Reflection.PropertyInfo PropertyInfo { get; }
        public bool IsDecoratedWithAttribute<TAttribute>() { }
        public bool IsDecoratedWithAttribute(System.Type attributeType) { }
    }
    public class CannotGetPropertyValueException : System.Exception
    {
        public CannotGetPropertyValueException(string propertyName) { }
        public string PropertyName { get; }
    }
    public class CannotSetPropertyValueException : System.Exception
    {
        public CannotSetPropertyValueException(string propertyName) { }
        public string PropertyName { get; }
    }
    public class static DelegateExtensions
    {
        public static System.Reflection.MethodInfo GetMethodInfoEx(this System.Delegate del) { }
    }
    public class static DelegateHelper
    {
        public static System.Delegate CreateDelegate(System.Type delegateType, System.Reflection.MethodInfo methodInfo) { }
        public static System.Delegate CreateDelegate(System.Type delegateType, System.Type targetType, string methodName) { }
        public static System.Delegate CreateDelegate(System.Type delegateType, object target, string methodName) { }
        public static System.Delegate CreateDelegate(System.Type delegateType, object target, System.Reflection.MethodInfo methodInfo) { }
    }
    public interface IEntryAssemblyResolver
    {
        System.Reflection.Assembly Resolve();
    }
    public class static MemberInfoExtensions
    {
        public static string GetSignature(this System.Reflection.ConstructorInfo constructorInfo) { }
        public static string GetSignature(this System.Reflection.MethodInfo methodInfo) { }
        public static bool IsStatic(this System.Reflection.PropertyInfo propertyInfo) { }
        public static System.Collections.Generic.IEnumerable<System.Reflection.ConstructorInfo> SortByParametersMatchDistance(this System.Collections.Generic.List<System.Reflection.ConstructorInfo> constructors, object[] parameters) { }
        public static bool TryGetConstructorDistanceByParametersMatch(this System.Reflection.ConstructorInfo constructor, object[] parameters, out int distance) { }
    }
    public class static ObjectExtensions
    {
        public static System.Attribute[] ToAttributeArray(this object[] objects) { }
    }
    public class static PropertyHelper
    {
        public static TValue GetHiddenPropertyValue<TValue>(object obj, string property, System.Type baseType) { }
        public static System.Reflection.PropertyInfo GetPropertyInfo(object obj, string property, bool ignoreCase = False) { }
        public static string GetPropertyName(System.Linq.Expressions.Expression propertyExpression, bool allowNested = False) { }
        public static string GetPropertyName<TValue>(System.Linq.Expressions.Expression<System.Func<TValue>> propertyExpression, bool allowNested = False) { }
        public static string GetPropertyName<TModel, TValue>(System.Linq.Expressions.Expression<System.Func<TModel, TValue>> propertyExpression, bool allowNested = False) { }
        public static object GetPropertyValue(object obj, string property, bool ignoreCase = False) { }
        public static TValue GetPropertyValue<TValue>(object obj, string property, bool ignoreCase = False) { }
        public static bool IsPropertyAvailable(object obj, string property, bool ignoreCase = False) { }
        public static bool IsPublicProperty(object obj, string property, bool ignoreCase = False) { }
        public static void SetPropertyValue(object obj, string property, object value, bool ignoreCase = False) { }
        public static bool TryGetPropertyValue(object obj, string property, out object value) { }
        public static bool TryGetPropertyValue(object obj, string property, bool ignoreCase, out object value) { }
        public static bool TryGetPropertyValue<TValue>(object obj, string property, out TValue value) { }
        public static bool TryGetPropertyValue<TValue>(object obj, string property, bool ignoreCase, out TValue value) { }
        public static bool TrySetPropertyValue(object obj, string property, object value, bool ignoreCase = False) { }
    }
    public class PropertyNotFoundException : System.Exception
    {
        public PropertyNotFoundException(string propertyName) { }
        public string PropertyName { get; }
    }
    public class static ReflectionExtensions
    {
        public static bool ContainsGenericParametersEx(this System.Type type) { }
        public static System.Reflection.Assembly GetAssemblyEx(this System.Type type) { }
        public static string GetAssemblyFullNameEx(this System.Type type) { }
        public static TAttribute GetAttribute<TAttribute>(this System.Reflection.MemberInfo memberInfo)
            where TAttribute : System.Attribute { }
        public static System.Attribute GetAttribute(this System.Reflection.MemberInfo memberInfo, System.Type attributeType) { }
        public static TAttribute GetAttribute<TAttribute>(this System.Type type)
            where TAttribute : System.Attribute { }
        public static System.Attribute GetAttribute(this System.Type type, System.Type attributeType) { }
        public static System.Type GetBaseTypeEx(this System.Type type) { }
        public static System.Reflection.ConstructorInfo GetConstructorEx(this System.Type type, System.Type[] types) { }
        public static System.Reflection.ConstructorInfo[] GetConstructorsEx(this System.Type type) { }
        public static System.Attribute GetCustomAttributeEx(this System.Reflection.Assembly assembly, System.Type attributeType) { }
        public static System.Attribute GetCustomAttributeEx(this System.Reflection.MethodInfo methodInfo, System.Type attributeType, bool inherit) { }
        public static System.Attribute GetCustomAttributeEx(this System.Reflection.PropertyInfo propertyInfo, System.Type attributeType, bool inherit) { }
        public static System.Attribute GetCustomAttributeEx(this System.Type type, System.Type attributeType, bool inherit) { }
        public static System.Attribute[] GetCustomAttributesEx(this System.Reflection.Assembly assembly, System.Type attributeType) { }
        public static System.Attribute[] GetCustomAttributesEx(this System.Reflection.MethodInfo methodInfo, bool inherit) { }
        public static System.Attribute[] GetCustomAttributesEx(this System.Reflection.MethodInfo methodInfo, System.Type attributeType, bool inherit) { }
        public static System.Attribute[] GetCustomAttributesEx(this System.Reflection.PropertyInfo propertyInfo, bool inherit) { }
        public static System.Attribute[] GetCustomAttributesEx(this System.Reflection.PropertyInfo propertyInfo, System.Type attributeType, bool inherit) { }
        public static System.Attribute[] GetCustomAttributesEx(this System.Type type, bool inherit) { }
        public static System.Attribute[] GetCustomAttributesEx(this System.Type type, System.Type attributeType, bool inherit) { }
        public static System.Type GetElementTypeEx(this System.Type type) { }
        public static System.Reflection.EventInfo GetEventEx(this System.Type type, string name, bool flattenHierarchy = True, bool allowStaticMembers = False) { }
        public static System.Reflection.EventInfo GetEventEx(this System.Type type, string name, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.EventInfo[] GetEventsEx(this System.Type type, bool flattenHierarchy = True, bool allowStaticMembers = False) { }
        public static System.Type[] GetExportedTypesEx(this System.Reflection.Assembly assembly) { }
        public static System.Reflection.FieldInfo GetFieldEx(this System.Type type, string name, bool flattenHierarchy = True, bool allowStaticMembers = False) { }
        public static System.Reflection.FieldInfo GetFieldEx(this System.Type type, string name, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.FieldInfo[] GetFieldsEx(this System.Type type, bool flattenHierarchy = True, bool allowStaticMembers = False) { }
        public static System.Reflection.FieldInfo[] GetFieldsEx(this System.Type type, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Type[] GetGenericArgumentsEx(this System.Type type) { }
        public static System.Type GetGenericTypeDefinitionEx(this System.Type type) { }
        public static System.Type GetInterfaceEx(this System.Type type, string name, bool ignoreCase) { }
        public static System.Type[] GetInterfacesEx(this System.Type type) { }
        public static System.Reflection.MemberInfo[] GetMemberEx(this System.Type type, string name, bool flattenHierarchy = True, bool allowStaticMembers = False) { }
        public static System.Reflection.MemberInfo[] GetMemberEx(this System.Type type, string name, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.MethodInfo GetMethodEx(this System.Type type, string name, bool flattenHierarchy = True, bool allowStaticMembers = False) { }
        public static System.Reflection.MethodInfo GetMethodEx(this System.Type type, string name, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.MethodInfo GetMethodEx(this System.Type type, string name, System.Type[] types, bool flattenHierarchy = True, bool allowStaticMembers = False) { }
        public static System.Reflection.MethodInfo GetMethodEx(this System.Type type, string name, System.Type[] types, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.MethodInfo[] GetMethodsEx(this System.Type type, bool flattenHierarchy = True, bool allowStaticMembers = False) { }
        public static System.Reflection.MethodInfo[] GetMethodsEx(this System.Type type, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Collections.Generic.IEnumerable<System.Type> GetParentTypes(this System.Type type) { }
        public static System.Reflection.PropertyInfo[] GetPropertiesEx(this System.Type type, bool flattenHierarchy = True, bool allowStaticMembers = False) { }
        public static System.Reflection.PropertyInfo[] GetPropertiesEx(this System.Type type, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.PropertyInfo GetPropertyEx(this System.Type type, string name, bool flattenHierarchy = True, bool allowStaticMembers = False, bool allowExplicitInterfaceProperties = True) { }
        public static System.Reflection.PropertyInfo GetPropertyEx(this System.Type type, string name, System.Reflection.BindingFlags bindingFlags, bool allowExplicitInterfaceProperties = True) { }
        public static string GetSafeFullName(this System.Type type, bool fullyQualifiedAssemblyName) { }
        public static int GetTypeDistance(this System.Type fromType, System.Type toType) { }
        public static System.Type[] GetTypesEx(this System.Reflection.Assembly assembly) { }
        public static bool HasBaseTypeEx(this System.Type type, System.Type typeToCheck) { }
        public static bool ImplementsInterfaceEx<TInterface>(this System.Type type) { }
        public static bool ImplementsInterfaceEx(this System.Type type, System.Type interfaceType) { }
        public static bool IsAbstractEx(this System.Type type) { }
        public static bool IsArrayEx(this System.Type type) { }
        public static bool IsAssignableFromEx(this System.Type type, System.Type typeToCheck) { }
        public static bool IsCOMObjectEx(this System.Type type) { }
        public static bool IsCatelType(this System.Type type) { }
        public static bool IsClassEx(this System.Type type) { }
        public static bool IsDecoratedWithAttribute<TAttribute>(this System.Reflection.MemberInfo memberInfo) { }
        public static bool IsDecoratedWithAttribute(this System.Reflection.MemberInfo memberInfo, System.Type attributeType) { }
        public static bool IsDecoratedWithAttribute<TAttribute>(this System.Type type) { }
        public static bool IsDecoratedWithAttribute(this System.Type type, System.Type attributeType) { }
        public static bool IsEnumEx(this System.Type type) { }
        public static bool IsGenericTypeDefinitionEx(this System.Type type) { }
        public static bool IsGenericTypeEx(this System.Type type) { }
        public static bool IsInstanceOfTypeEx(this System.Type type, object objectToCheck) { }
        public static bool IsInterfaceEx(this System.Type type) { }
        public static bool IsNestedPublicEx(this System.Type type) { }
        public static bool IsPrimitiveEx(this System.Type type) { }
        public static bool IsPublicEx(this System.Type type) { }
        public static bool IsSerializableEx(this System.Type type) { }
        public static bool IsValueTypeEx(this System.Type type) { }
        public static System.Type MakeGenericTypeEx(this System.Type type, params System.Type[] typeArguments) { }
        public static bool TryGetAttribute<TAttribute>(this System.Reflection.MemberInfo memberInfo, out TAttribute attribute)
            where TAttribute : System.Attribute { }
        public static bool TryGetAttribute(this System.Reflection.MemberInfo memberInfo, System.Type attributeType, out System.Attribute attribute) { }
        public static bool TryGetAttribute<TAttribute>(this System.Type type, out TAttribute attribute)
            where TAttribute : System.Attribute { }
        public static bool TryGetAttribute(this System.Type type, System.Type attributeType, out System.Attribute attribute) { }
    }
    public class static StaticHelper
    {
        public static System.Type GetCallingType() { }
    }
    public class static TypeArray
    {
        public static System.Type[] From<T1, T2, T3, T4, T5>() { }
        public static System.Type[] From<T1, T2, T3, T4>() { }
        public static System.Type[] From<T1, T2, T3>() { }
        public static System.Type[] From<T1, T2>() { }
        public static System.Type[] From<T>() { }
    }
    public class static TypeCache
    {
        public static System.Collections.Generic.List<string> InitializedAssemblies { get; }
        public static System.Collections.Generic.List<System.Func<System.Reflection.Assembly, bool>> ShouldIgnoreAssemblyEvaluators { get; }
        public static System.Collections.Generic.List<System.Func<System.Reflection.Assembly, System.Type, bool>> ShouldIgnoreTypeEvaluators { get; }
        public event System.EventHandler<Catel.Reflection.AssemblyLoadedEventArgs> AssemblyLoaded;
        public static System.Type GetType(string typeNameWithAssembly, bool ignoreCase = False, bool allowInitialization = True) { }
        public static System.Type GetTypeWithAssembly(string typeName, string assemblyName, bool ignoreCase = False, bool allowInitialization = True) { }
        public static System.Type GetTypeWithoutAssembly(string typeNameWithoutAssembly, bool ignoreCase = False, bool allowInitialization = True) { }
        public static System.Type[] GetTypes(System.Func<System.Type, bool> predicate = null, bool allowInitialization = True) { }
        public static System.Type[] GetTypesImplementingInterface(System.Type interfaceType) { }
        public static System.Type[] GetTypesOfAssembly(System.Reflection.Assembly assembly, System.Func<System.Type, bool> predicate = null) { }
        public static void InitializeTypes(string assemblyName, bool forceFullInitialization, bool allowMultithreadedInitialization = False) { }
        public static void InitializeTypes(System.Reflection.Assembly assembly = null, bool forceFullInitialization = False, bool allowMultithreadedInitialization = False) { }
    }
    public class static TypeCacheEvaluator
    {
        public static System.Collections.Generic.List<System.Func<System.Reflection.Assembly, bool>> AssemblyEvaluators { get; }
        public static System.Collections.Generic.List<System.Func<System.Reflection.Assembly, System.Type, bool>> TypeEvaluators { get; }
    }
    public class static TypeExtensions
    {
        public static System.Type GetCollectionElementType(this System.Type type) { }
        public static bool IsBasicType(this System.Type type) { }
        public static bool IsClassType(this System.Type type) { }
        public static bool IsCollection(this System.Type type) { }
        public static bool IsDictionary(this System.Type type) { }
        public static bool IsModelBase(this System.Type type) { }
        public static bool IsNullableType(this System.Type type) { }
    }
    public class static TypeHelper
    {
        public static System.Collections.Generic.IEnumerable<string> MicrosoftPublicKeyTokens { get; }
        public static TOutput Cast<TOutput, TInput>(TInput value) { }
        public static TOutput Cast<TOutput>(object value) { }
        public static TOutput Cast<TOutput, TInput>(TInput value, TOutput whenNullValue) { }
        public static string ConvertTypeToVersionIndependentType(string type, bool stripAssemblies = False) { }
        [System.ObsoleteAttribute("Use `FormatInnerTypes(IEnumerable<string>, bool)` instead. Will be removed in ver" +
            "sion 6.0.0.", true)]
        public static string FormatInnerTypes(string[] innerTypes, bool stripAssemblies = False) { }
        public static string FormatInnerTypes(System.Collections.Generic.IEnumerable<string> innerTypes, bool stripAssemblies = False) { }
        public static string FormatType(string assembly, string type) { }
        public static string GetAssemblyName(string fullTypeName) { }
        public static string GetAssemblyNameWithoutOverhead(string fullyQualifiedAssemblyName) { }
        public static string[] GetInnerTypes(string type) { }
        public static string GetTypeName(string fullTypeName) { }
        public static string GetTypeNameWithAssembly(string fullTypeName) { }
        public static string GetTypeNameWithoutNamespace(string fullTypeName) { }
        public static string GetTypeNamespace(string fullTypeName) { }
        public static TTargetType GetTypedInstance<TTargetType>(object instance)
            where TTargetType :  class { }
        public static bool IsSubclassOfRawGeneric(System.Type generic, System.Type toCheck) { }
        public static bool TryCast<TOutput, TInput>(TInput value, out TOutput output) { }
    }
    public class static TypeInfoExtensions
    {
        public static System.Reflection.ConstructorInfo GetConstructor(this System.Reflection.TypeInfo typeInfo, System.Type[] types, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.ConstructorInfo[] GetConstructors(this System.Reflection.TypeInfo typeInfo, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.EventInfo GetEvent(this System.Reflection.TypeInfo typeInfo, string name, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.EventInfo[] GetEvents(this System.Reflection.TypeInfo typeInfo, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.FieldInfo GetField(this System.Reflection.TypeInfo typeInfo, string name, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.FieldInfo[] GetFields(this System.Reflection.TypeInfo typeInfo, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.MemberInfo[] GetMember(this System.Reflection.TypeInfo typeInfo, string name, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.MemberInfo[] GetMembers(this System.Reflection.TypeInfo typeInfo, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.MethodInfo GetMethod(this System.Reflection.TypeInfo typeInfo, string name, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.MethodInfo GetMethod(this System.Reflection.TypeInfo typeInfo, string name, System.Type[] types, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.MethodInfo[] GetMethods(this System.Reflection.TypeInfo typeInfo, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.PropertyInfo[] GetProperties(this System.Reflection.TypeInfo typeInfo, System.Reflection.BindingFlags bindingFlags) { }
        public static System.Reflection.PropertyInfo GetProperty(this System.Reflection.TypeInfo typeInfo, string name, System.Reflection.BindingFlags bindingFlags) { }
    }
}
namespace Catel.Runtime
{
    public class ReferenceEqualityComparer<TObject> : System.Collections.Generic.IEqualityComparer<TObject>
        where TObject :  class
    {
        public ReferenceEqualityComparer() { }
        public bool Equals(TObject x, TObject y) { }
        public int GetHashCode(TObject obj) { }
    }
    public class ReferenceInfo
    {
        public ReferenceInfo(object instance, int id, bool isFirstUsage) { }
        public int Id { get; }
        public object Instance { get; }
        public bool IsFirstUsage { get; }
    }
    public class ReferenceManager
    {
        public ReferenceManager() { }
        public int Count { get; }
        public Catel.Runtime.ReferenceInfo GetInfo(object instance) { }
        public Catel.Runtime.ReferenceInfo GetInfoAt(int index) { }
        public Catel.Runtime.ReferenceInfo GetInfoById(int id) { }
        public void RegisterManually(int id, object instance) { }
    }
    public class RuntimeBindingRedirect
    {
        public RuntimeBindingRedirect() { }
        public RuntimeBindingRedirect(System.AppDomain appDomain) { }
    }
}
namespace Catel.Runtime.Serialization.Binary
{
    [System.ObsoleteAttribute("Binary serialization should no longer be used for security reasons, see https://g" +
        "ithub.com/Catel/Catel/issues/1216. Will be treated as an error from version 6.0." +
        "0. Will be removed in version 6.0.0.", false)]
    public class BinarySerializationContextInfo : Catel.Runtime.Serialization.SerializationContextInfoBase<Catel.Runtime.Serialization.Binary.BinarySerializationContextInfo>
    {
        public BinarySerializationContextInfo(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> memberValues = null, System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = null) { }
        public System.Runtime.Serialization.Formatters.Binary.BinaryFormatter BinaryFormatter { get; }
        public System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> MemberValues { get; }
        public System.Collections.Generic.List<Catel.Data.PropertyValue> PropertyValues { get; }
        public System.Runtime.Serialization.SerializationInfo SerializationInfo { get; }
    }
    [System.ObsoleteAttribute("Binary serialization should no longer be used for security reasons, see https://g" +
        "ithub.com/Catel/Catel/issues/1216. Will be treated as an error from version 6.0." +
        "0. Will be removed in version 6.0.0.", false)]
    public class BinarySerializationContextInfoFactory : Catel.Runtime.Serialization.ISerializationContextInfoFactory
    {
        public BinarySerializationContextInfoFactory() { }
        public Catel.Runtime.Serialization.ISerializationContextInfo GetSerializationContextInfo(Catel.Runtime.Serialization.ISerializer serializer, object model, object data, Catel.Runtime.Serialization.ISerializationConfiguration configuration) { }
    }
    [System.ObsoleteAttribute("Binary serialization should no longer be used for security reasons, see https://g" +
        "ithub.com/Catel/Catel/issues/1216. Will be treated as an error from version 6.0." +
        "0. Will be removed in version 6.0.0.", false)]
    public class BinarySerializer : Catel.Runtime.Serialization.SerializerBase<Catel.Runtime.Serialization.Binary.BinarySerializationContextInfo>, Catel.Runtime.Serialization.Binary.IBinarySerializer, Catel.Runtime.Serialization.ISerializer
    {
        protected static Catel.Runtime.Serialization.Binary.RedirectDeserializationBinder DeserializationBinder;
        public BinarySerializer(Catel.Runtime.Serialization.ISerializationManager serializationManager, Catel.IoC.ITypeFactory typeFactory, Catel.Runtime.Serialization.IObjectAdapter objectAdapter) { }
        protected override void AfterSerialization(Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Binary.BinarySerializationContextInfo> context) { }
        protected override void AppendContextToStream(Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Binary.BinarySerializationContextInfo> context, System.IO.Stream stream) { }
        protected override void BeforeDeserialization(Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Binary.BinarySerializationContextInfo> context) { }
        protected override void BeforeSerialization(Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Binary.BinarySerializationContextInfo> context) { }
        public override object Deserialize(System.Type modelType, System.IO.Stream stream, Catel.Runtime.Serialization.ISerializationConfiguration configuration) { }
        public override object Deserialize(object model, System.IO.Stream stream, Catel.Runtime.Serialization.ISerializationConfiguration configuration) { }
        protected override Catel.Runtime.Serialization.SerializationObject DeserializeMember(Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Binary.BinarySerializationContextInfo> context, Catel.Runtime.Serialization.MemberValue memberValue) { }
        [System.ObsoleteAttribute("Use `GetSerializationContextInfo` instead. Will be removed in version 6.0.0.", true)]
        protected override Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Binary.BinarySerializationContextInfo> GetContext(object model, System.Type modelType, System.IO.Stream stream, Catel.Runtime.Serialization.SerializationContextMode contextMode, Catel.Runtime.Serialization.ISerializationConfiguration configuration) { }
        protected override Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Binary.BinarySerializationContextInfo> GetSerializationContextInfo(object model, System.Type modelType, System.IO.Stream stream, Catel.Runtime.Serialization.SerializationContextMode contextMode, Catel.Runtime.Serialization.ISerializationConfiguration configuration) { }
        protected override void SerializeMember(Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Binary.BinarySerializationContextInfo> context, Catel.Runtime.Serialization.MemberValue memberValue) { }
        protected override bool ShouldSerializeModelAsCollection(System.Type memberType) { }
        protected override void Warmup(System.Type type) { }
    }
    [System.ObsoleteAttribute("Binary serialization should no longer be used for security reasons, see https://g" +
        "ithub.com/Catel/Catel/issues/1216. Will be treated as an error from version 6.0." +
        "0. Will be removed in version 6.0.0.", false)]
    public interface IBinarySerializer : Catel.Runtime.Serialization.ISerializer { }
    public sealed class RedirectDeserializationBinder : System.Runtime.Serialization.SerializationBinder
    {
        public RedirectDeserializationBinder(int typesPerThread = 2500) { }
        public override System.Type BindToType(string assemblyName, string typeName) { }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Assembly | System.AttributeTargets.Module | System.AttributeTargets.Class | System.AttributeTargets.Struct | System.AttributeTargets.Enum | System.AttributeTargets.Constructor | System.AttributeTargets.Method | System.AttributeTargets.Property | System.AttributeTargets.Field | System.AttributeTargets.Event | System.AttributeTargets.Interface | System.AttributeTargets.Parameter | System.AttributeTargets.Delegate | System.AttributeTargets.ReturnValue | System.AttributeTargets.GenericParameter | System.AttributeTargets.All, AllowMultiple=true, Inherited=false)]
    public class RedirectTypeAttribute : System.Attribute
    {
        public RedirectTypeAttribute(string originalAssemblyName, string originalTypeName) { }
        public string NewAssemblyName { get; set; }
        public string NewTypeName { get; set; }
        public string OriginalAssemblyName { get; }
        public string OriginalType { get; }
        public string OriginalTypeName { get; }
        public string TypeToLoad { get; }
    }
}
namespace Catel.Runtime.Serialization
{
    public class CacheInvalidatedEventArgs : System.EventArgs
    {
        public CacheInvalidatedEventArgs(System.Type type) { }
        public System.Type Type { get; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Property | System.AttributeTargets.Field | System.AttributeTargets.All, AllowMultiple=false)]
    public class ExcludeFromSerializationAttribute : System.Attribute
    {
        public ExcludeFromSerializationAttribute() { }
    }
    public interface IFieldSerializable
    {
        bool GetFieldValue(string fieldName, ref object value);
        bool SetFieldValue(string fieldName, object value);
    }
    public interface IObjectAdapter
    {
        Catel.Runtime.Serialization.MemberValue GetMemberValue(object model, string memberName, Catel.Runtime.Serialization.SerializationModelInfo modelInfo);
        void SetMemberValue(object model, Catel.Runtime.Serialization.MemberValue member, Catel.Runtime.Serialization.SerializationModelInfo modelInfo);
    }
    public interface IPropertySerializable
    {
        bool GetPropertyValue(string propertyName, ref object value);
        bool SetPropertyValue(string propertyName, object value);
    }
    public interface ISerializable
    {
        void FinishDeserialization();
        void FinishSerialization();
        void StartDeserialization();
        void StartSerialization();
    }
    public interface ISerializationConfiguration
    {
        System.Globalization.CultureInfo Culture { get; set; }
    }
    public interface ISerializationContext : System.IDisposable
    {
        Catel.Runtime.Serialization.ISerializationConfiguration Configuration { get; }
        Catel.Runtime.Serialization.SerializationContextMode ContextMode { get; }
        int Depth { get; }
        object Model { get; set; }
        System.Type ModelType { get; }
        string ModelTypeName { get; }
        Catel.Runtime.ReferenceManager ReferenceManager { get; }
        System.Collections.Generic.Stack<System.Type> TypeStack { get; }
    }
    public interface ISerializationContextContainer
    {
        void SetSerializationContext<T>(Catel.Runtime.Serialization.ISerializationContext<T> serializationContext)
            where T :  class, Catel.Runtime.Serialization.ISerializationContextInfo;
    }
    public class static ISerializationContextExtensions
    {
        public static System.Type FindParentType(this Catel.Runtime.Serialization.ISerializationContext serializationContext, System.Func<System.Type, bool> predicate, int maxLevels = -1) { }
    }
    public interface ISerializationContextInfo { }
    public interface ISerializationContextInfoFactory
    {
        Catel.Runtime.Serialization.ISerializationContextInfo GetSerializationContextInfo(Catel.Runtime.Serialization.ISerializer serializer, object model, object data, Catel.Runtime.Serialization.ISerializationConfiguration configuration);
    }
    public interface ISerializationContext<TSerializationContext> : Catel.Runtime.Serialization.ISerializationContext, System.IDisposable
        where TSerializationContext :  class, Catel.Runtime.Serialization.ISerializationContextInfo
    {
        TSerializationContext Context { get; }
        Catel.Runtime.Serialization.ISerializationContext<TSerializationContext> Parent { get; }
    }
    public interface ISerializationManager
    {
        public event System.EventHandler<Catel.Runtime.Serialization.CacheInvalidatedEventArgs> CacheInvalidated;
        void AddSerializerModifier(System.Type type, System.Type serializerModifierType);
        void Clear(System.Type type);
        System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> GetCatelProperties(System.Type type, bool includeModelBaseProperties = False);
        System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> GetCatelPropertiesToSerialize(System.Type type);
        System.Collections.Generic.HashSet<string> GetCatelPropertyNames(System.Type type, bool includeModelBaseProperties = False);
        System.Collections.Generic.HashSet<string> GetFieldNames(System.Type type);
        System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> GetFields(System.Type type);
        System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> GetFieldsToSerialize(System.Type type);
        System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> GetRegularProperties(System.Type type);
        System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> GetRegularPropertiesToSerialize(System.Type type);
        System.Collections.Generic.HashSet<string> GetRegularPropertyNames(System.Type type);
        Catel.Runtime.Serialization.ISerializerModifier[] GetSerializerModifiers(System.Type type);
        void RemoveSerializerModifier(System.Type type, System.Type serializerModifierType);
        void Warmup(System.Type type);
    }
    public class static ISerializationManagerExtensions
    {
        public static void AddSerializerModifier<TType, TSerializerModifier>(this Catel.Runtime.Serialization.ISerializationManager serializationManager)
            where TSerializerModifier : Catel.Runtime.Serialization.ISerializerModifier { }
        public static Catel.Runtime.Serialization.ISerializerModifier[] GetSerializerModifiers<TType>(this Catel.Runtime.Serialization.ISerializationManager serializationManager) { }
        public static void RemoveSerializerModifier<TType, TSerializerModifier>(this Catel.Runtime.Serialization.ISerializationManager serializationManager)
            where TSerializerModifier : Catel.Runtime.Serialization.ISerializerModifier { }
    }
    public interface ISerializer
    {
        public event System.EventHandler<Catel.Runtime.Serialization.SerializationEventArgs> Deserialized;
        public event System.EventHandler<Catel.Runtime.Serialization.MemberSerializationEventArgs> DeserializedMember;
        public event System.EventHandler<Catel.Runtime.Serialization.SerializationEventArgs> Deserializing;
        public event System.EventHandler<Catel.Runtime.Serialization.MemberSerializationEventArgs> DeserializingMember;
        public event System.EventHandler<Catel.Runtime.Serialization.SerializationEventArgs> Serialized;
        public event System.EventHandler<Catel.Runtime.Serialization.MemberSerializationEventArgs> SerializedMember;
        public event System.EventHandler<Catel.Runtime.Serialization.SerializationEventArgs> Serializing;
        public event System.EventHandler<Catel.Runtime.Serialization.MemberSerializationEventArgs> SerializingMember;
        object Deserialize(object model, System.IO.Stream stream, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null);
        object Deserialize(object model, Catel.Runtime.Serialization.ISerializationContextInfo serializationContext, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null);
        object Deserialize(System.Type modelType, System.IO.Stream stream, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null);
        object Deserialize(System.Type modelType, Catel.Runtime.Serialization.ISerializationContextInfo serializationContext, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null);
        System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> DeserializeMembers(System.Type modelType, System.IO.Stream stream, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null);
        System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> DeserializeMembers(object model, System.IO.Stream stream, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null);
        System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> DeserializeMembers(System.Type modelType, Catel.Runtime.Serialization.ISerializationContextInfo serializationContext, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null);
        System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> DeserializeMembers(object model, Catel.Runtime.Serialization.ISerializationContextInfo serializationContext, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null);
        void Serialize(object model, System.IO.Stream stream, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null);
        void Serialize(object model, Catel.Runtime.Serialization.ISerializationContextInfo serializationContext, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null);
        void SerializeMembers(object model, System.IO.Stream stream, Catel.Runtime.Serialization.ISerializationConfiguration configuration, params string[] membersToIgnore);
        void Warmup(System.Collections.Generic.IEnumerable<System.Type> types = null, int typesPerThread = 1000);
    }
    public class static ISerializerExtensions
    {
        public static TModel Deserialize<TModel>(this Catel.Runtime.Serialization.ISerializer serializer, System.IO.Stream stream, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
    }
    public interface ISerializerModifier
    {
        void DeserializeMember(Catel.Runtime.Serialization.ISerializationContext context, Catel.Runtime.Serialization.MemberValue memberValue);
        void OnDeserialized(Catel.Runtime.Serialization.ISerializationContext context, object model);
        void OnDeserializing(Catel.Runtime.Serialization.ISerializationContext context, object model);
        void OnSerialized(Catel.Runtime.Serialization.ISerializationContext context, object model);
        void OnSerializing(Catel.Runtime.Serialization.ISerializationContext context, object model);
        void SerializeMember(Catel.Runtime.Serialization.ISerializationContext context, Catel.Runtime.Serialization.MemberValue memberValue);
        bool ShouldIgnoreMember(Catel.Runtime.Serialization.ISerializationContext context, object model, Catel.Runtime.Serialization.MemberValue memberValue);
        System.Nullable<bool> ShouldSerializeAsCollection();
        System.Nullable<bool> ShouldSerializeAsDictionary();
        System.Nullable<bool> ShouldSerializeEnumMemberUsingToString(Catel.Runtime.Serialization.MemberValue memberValue);
        System.Nullable<bool> ShouldSerializeMemberUsingParse(Catel.Runtime.Serialization.MemberValue memberValue);
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Property | System.AttributeTargets.Field | System.AttributeTargets.All, AllowMultiple=false)]
    public class IncludeInSerializationAttribute : System.Attribute
    {
        public IncludeInSerializationAttribute() { }
        public IncludeInSerializationAttribute(string name) { }
        public string Name { get; set; }
    }
    public class KeyValuePairSerializerModifier : Catel.Runtime.Serialization.SerializerModifierBase
    {
        public KeyValuePairSerializerModifier() { }
        public override void DeserializeMember(Catel.Runtime.Serialization.ISerializationContext context, Catel.Runtime.Serialization.MemberValue memberValue) { }
        public override void SerializeMember(Catel.Runtime.Serialization.ISerializationContext context, Catel.Runtime.Serialization.MemberValue memberValue) { }
    }
    public class MemberMetadata
    {
        public MemberMetadata(System.Type containingType, System.Type memberType, Catel.Runtime.Serialization.SerializationMemberGroup memberGroup, string memberName) { }
        public System.Type ContainingType { get; }
        public Catel.Runtime.Serialization.SerializationMemberGroup MemberGroup { get; }
        public string MemberName { get; }
        public string MemberNameForSerialization { get; set; }
        public System.Type MemberType { get; }
        public object Tag { get; set; }
    }
    public class MemberSerializationEventArgs : Catel.Runtime.Serialization.SerializationEventArgs
    {
        public MemberSerializationEventArgs(Catel.Runtime.Serialization.ISerializationContext serializationContext, Catel.Runtime.Serialization.MemberValue memberValue) { }
        public Catel.Runtime.Serialization.MemberValue MemberValue { get; }
    }
    [System.Diagnostics.DebuggerDisplayAttribute("{Name} => {Value} ({ActualMemberType})")]
    public class MemberValue
    {
        public MemberValue(Catel.Runtime.Serialization.SerializationMemberGroup memberGroup, System.Type modelType, System.Type memberType, string name, string nameForSerialization, object value) { }
        public System.Type ActualMemberType { get; }
        public Catel.Runtime.Serialization.SerializationMemberGroup MemberGroup { get; }
        public System.Type MemberType { get; }
        public string MemberTypeName { get; }
        public System.Type ModelType { get; }
        public string ModelTypeName { get; }
        public string Name { get; }
        public string NameForSerialization { get; }
        public object Value { get; set; }
        public System.Type GetBestMemberType() { }
    }
    public class ObjectAdapter : Catel.Runtime.Serialization.IObjectAdapter
    {
        public ObjectAdapter() { }
        public virtual Catel.Runtime.Serialization.MemberValue GetMemberValue(object model, string memberName, Catel.Runtime.Serialization.SerializationModelInfo modelInfo) { }
        public virtual void SetMemberValue(object model, Catel.Runtime.Serialization.MemberValue member, Catel.Runtime.Serialization.SerializationModelInfo modelInfo) { }
    }
    [System.Runtime.Serialization.DataContractAttribute()]
    public class SerializableKeyValuePair
    {
        public SerializableKeyValuePair() { }
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Key { get; set; }
        [Catel.Runtime.Serialization.ExcludeFromSerializationAttribute()]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Type KeyType { get; set; }
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Value { get; set; }
        [Catel.Runtime.Serialization.ExcludeFromSerializationAttribute()]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public System.Type ValueType { get; set; }
    }
    public class SerializationConfiguration : Catel.Runtime.Serialization.ISerializationConfiguration
    {
        public SerializationConfiguration() { }
        public System.Globalization.CultureInfo Culture { get; set; }
    }
    public class static SerializationContextHelper
    {
        [System.ObsoleteAttribute("Use `GetSerializationScopeName` instead. Will be removed in version 6.0.0.", true)]
        public static string GetSerializationReferenceManagerScopeName() { }
        public static string GetSerializationScopeName() { }
    }
    public abstract class SerializationContextInfoBase<TSerializationContextInfo> : Catel.Runtime.Serialization.ISerializationContextContainer, Catel.Runtime.Serialization.ISerializationContextInfo
        where TSerializationContextInfo :  class, Catel.Runtime.Serialization.ISerializationContextInfo
    {
        public SerializationContextInfoBase() { }
        public Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> Context { get; }
        protected virtual void OnContextUpdated(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context) { }
    }
    public enum SerializationContextMode
    {
        Serialization = 0,
        Deserialization = 1,
    }
    public class SerializationContextScope<TSerializationContextInfo>
        where TSerializationContextInfo :  class, Catel.Runtime.Serialization.ISerializationContextInfo
    {
        public SerializationContextScope() { }
        public System.Collections.Generic.Stack<Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo>> Contexts { get; }
        public Catel.Runtime.ReferenceManager ReferenceManager { get; }
        public System.Collections.Generic.Stack<System.Type> TypeStack { get; }
    }
    public class SerializationContext<TSerializationContextInfo> : Catel.Disposable, Catel.Runtime.Serialization.ISerializationContext, Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo>, System.IDisposable
        where TSerializationContextInfo :  class, Catel.Runtime.Serialization.ISerializationContextInfo
    {
        public SerializationContext(object model, System.Type modelType, TSerializationContextInfo context, Catel.Runtime.Serialization.SerializationContextMode contextMode, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        public Catel.Runtime.Serialization.ISerializationConfiguration Configuration { get; }
        public TSerializationContextInfo Context { get; }
        public Catel.Runtime.Serialization.SerializationContextMode ContextMode { get; }
        public System.Collections.Generic.Stack<Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo>> Contexts { get; }
        public int Depth { get; }
        public object Model { get; set; }
        public System.Type ModelType { get; }
        public string ModelTypeName { get; }
        public Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> Parent { get; }
        public Catel.Runtime.ReferenceManager ReferenceManager { get; }
        public System.Runtime.Serialization.SerializationInfo SerializationInfo { get; set; }
        public System.Collections.Generic.Stack<System.Type> TypeStack { get; }
        protected override void DisposeManaged() { }
    }
    public class SerializationEventArgs : System.EventArgs
    {
        public SerializationEventArgs(Catel.Runtime.Serialization.ISerializationContext serializationContext) { }
        public Catel.Runtime.Serialization.ISerializationContext SerializationContext { get; }
    }
    public class static SerializationFactory
    {
        public static Catel.Runtime.Serialization.Binary.IBinarySerializer GetBinarySerializer() { }
        public static Catel.Runtime.Serialization.Xml.IXmlSerializer GetXmlSerializer() { }
    }
    [System.ObsoleteAttribute("No longer needed, confusing name. Will be removed in version 6.0.0.", true)]
    public class SerializationInfoSerializationContextInfo : Catel.Runtime.Serialization.ISerializationContextInfo
    {
        public SerializationInfoSerializationContextInfo() { }
        public SerializationInfoSerializationContextInfo(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> memberValues = null) { }
        public System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> MemberValues { get; }
        public Catel.Runtime.Serialization.ISerializationContextInfo Parent { get; }
        public System.Collections.Generic.List<Catel.Data.PropertyValue> PropertyValues { get; }
        public System.Runtime.Serialization.SerializationInfo SerializationInfo { get; }
    }
    public class SerializationManager : Catel.Runtime.Serialization.ISerializationManager
    {
        public SerializationManager() { }
        public event System.EventHandler<Catel.Runtime.Serialization.CacheInvalidatedEventArgs> CacheInvalidated;
        public void AddSerializerModifier(System.Type type, System.Type serializerModifierType) { }
        public void Clear(System.Type type) { }
        protected virtual System.Collections.Generic.List<System.Type> FindSerializerModifiers(System.Type type) { }
        public System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> GetCatelProperties(System.Type type, bool includeModelBaseProperties = False) { }
        public virtual System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> GetCatelPropertiesToSerialize(System.Type type) { }
        public System.Collections.Generic.HashSet<string> GetCatelPropertyNames(System.Type type, bool includeModelBaseProperties = False) { }
        public System.Collections.Generic.HashSet<string> GetFieldNames(System.Type type) { }
        public System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> GetFields(System.Type type) { }
        public virtual System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> GetFieldsToSerialize(System.Type type) { }
        public System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> GetRegularProperties(System.Type type) { }
        public virtual System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> GetRegularPropertiesToSerialize(System.Type type) { }
        public System.Collections.Generic.HashSet<string> GetRegularPropertyNames(System.Type type) { }
        public virtual Catel.Runtime.Serialization.ISerializerModifier[] GetSerializerModifiers(System.Type type) { }
        public void RemoveSerializerModifier(System.Type type, System.Type serializerModifierType) { }
        public void Warmup(System.Type type) { }
    }
    public enum SerializationMemberGroup
    {
        CatelProperty = 0,
        RegularProperty = 1,
        Field = 2,
        SimpleRootObject = 3,
        Collection = 4,
        Dictionary = 5,
    }
    public class SerializationModelInfo
    {
        public SerializationModelInfo(System.Type modelType, System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> catelProperties, System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> fields, System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> regularProperties) { }
        public System.Collections.Generic.List<Catel.Data.PropertyData> CatelProperties { get; }
        public System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> CatelPropertiesByName { get; }
        public System.Collections.Generic.HashSet<string> CatelPropertyNames { get; }
        public System.Collections.Generic.HashSet<string> FieldNames { get; }
        public System.Collections.Generic.List<System.Reflection.FieldInfo> Fields { get; }
        public System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> FieldsByName { get; }
        public System.Type ModelType { get; }
        public System.Collections.Generic.List<System.Reflection.PropertyInfo> Properties { get; }
        public System.Collections.Generic.Dictionary<string, Catel.Runtime.Serialization.MemberMetadata> PropertiesByName { get; }
        public System.Collections.Generic.HashSet<string> PropertyNames { get; }
    }
    public class SerializationObject
    {
        public bool IsSuccessful { get; }
        public Catel.Runtime.Serialization.SerializationMemberGroup MemberGroup { get; }
        public string MemberName { get; }
        public object MemberValue { get; }
        public System.Type ModelType { get; }
        public static Catel.Runtime.Serialization.SerializationObject FailedToDeserialize(System.Type modelType, Catel.Runtime.Serialization.SerializationMemberGroup memberGroup, string memberName) { }
        public static Catel.Runtime.Serialization.SerializationObject SucceededToDeserialize(System.Type modelType, Catel.Runtime.Serialization.SerializationMemberGroup memberGroup, string memberName, object memberValue) { }
    }
    public class SerializationScope
    {
        public SerializationScope(Catel.Runtime.Serialization.ISerializer serializer, Catel.Runtime.Serialization.ISerializationConfiguration configuration) { }
        public Catel.Runtime.Serialization.ISerializationConfiguration Configuration { get; set; }
        public Catel.Runtime.Serialization.ISerializer Serializer { get; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Class | System.AttributeTargets.All)]
    public class SerializeAsCollectionAttribute : System.Attribute
    {
        public SerializeAsCollectionAttribute() { }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Property | System.AttributeTargets.Field | System.AttributeTargets.All, AllowMultiple=false)]
    public class SerializeEnumAsStringAttribute : System.Attribute
    {
        public SerializeEnumAsStringAttribute() { }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Class | System.AttributeTargets.Property | System.AttributeTargets.Field | System.AttributeTargets.All)]
    public class SerializeUsingParseAndToStringAttribute : System.Attribute
    {
        public SerializeUsingParseAndToStringAttribute() { }
    }
    public abstract class SerializerBase<TSerializationContextInfo> : Catel.Runtime.Serialization.ISerializer
        where TSerializationContextInfo :  class, Catel.Runtime.Serialization.ISerializationContextInfo
    {
        protected const string CollectionName = "Items";
        protected const string DictionaryName = "Pairs";
        protected const string RootObjectName = "Value";
        protected SerializerBase(Catel.Runtime.Serialization.ISerializationManager serializationManager, Catel.IoC.ITypeFactory typeFactory, Catel.Runtime.Serialization.IObjectAdapter objectAdapter) { }
        protected Catel.Runtime.Serialization.IObjectAdapter ObjectAdapter { get; }
        protected Catel.Runtime.Serialization.ISerializationManager SerializationManager { get; }
        protected Catel.IoC.ITypeFactory TypeFactory { get; }
        public event System.EventHandler<Catel.Runtime.Serialization.SerializationEventArgs> Deserialized;
        public event System.EventHandler<Catel.Runtime.Serialization.MemberSerializationEventArgs> DeserializedMember;
        public event System.EventHandler<Catel.Runtime.Serialization.SerializationEventArgs> Deserializing;
        public event System.EventHandler<Catel.Runtime.Serialization.MemberSerializationEventArgs> DeserializingMember;
        public event System.EventHandler<Catel.Runtime.Serialization.SerializationEventArgs> Serialized;
        public event System.EventHandler<Catel.Runtime.Serialization.MemberSerializationEventArgs> SerializedMember;
        public event System.EventHandler<Catel.Runtime.Serialization.SerializationEventArgs> Serializing;
        public event System.EventHandler<Catel.Runtime.Serialization.MemberSerializationEventArgs> SerializingMember;
        protected virtual void AfterDeserialization(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context) { }
        protected virtual void AfterDeserializeMember(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context, Catel.Runtime.Serialization.MemberValue memberValue) { }
        protected virtual void AfterSerialization(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context) { }
        protected virtual void AfterSerializeMember(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context, Catel.Runtime.Serialization.MemberValue memberValue) { }
        protected abstract void AppendContextToStream(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context, System.IO.Stream stream);
        protected virtual void BeforeDeserialization(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context) { }
        protected virtual void BeforeDeserializeMember(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context, Catel.Runtime.Serialization.MemberValue memberValue) { }
        protected virtual void BeforeSerialization(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context) { }
        protected virtual void BeforeSerializeMember(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context, Catel.Runtime.Serialization.MemberValue memberValue) { }
        protected System.Collections.Generic.List<Catel.Runtime.Serialization.SerializableKeyValuePair> ConvertDictionaryToCollection(object memberValue) { }
        protected virtual object CreateModelInstance(System.Type type) { }
        public virtual object Deserialize(object model, System.IO.Stream stream, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        public object Deserialize(object model, Catel.Runtime.Serialization.ISerializationContextInfo serializationContext, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        public virtual object Deserialize(object model, TSerializationContextInfo serializationContext, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        protected virtual object Deserialize(object model, Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context) { }
        public virtual object Deserialize(System.Type modelType, System.IO.Stream stream, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        public object Deserialize(System.Type modelType, Catel.Runtime.Serialization.ISerializationContextInfo serializationContext, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        public virtual object Deserialize(System.Type modelType, TSerializationContextInfo serializationContext, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        protected abstract Catel.Runtime.Serialization.SerializationObject DeserializeMember(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context, Catel.Runtime.Serialization.MemberValue memberValue);
        public virtual System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> DeserializeMembers(System.Type modelType, System.IO.Stream stream, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        public virtual System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> DeserializeMembers(object model, System.IO.Stream stream, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        public System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> DeserializeMembers(System.Type modelType, Catel.Runtime.Serialization.ISerializationContextInfo serializationContextInfo, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        public virtual System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> DeserializeMembers(System.Type modelType, TSerializationContextInfo serializationContext, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        public System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> DeserializeMembers(object model, Catel.Runtime.Serialization.ISerializationContextInfo serializationContextInfo, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        public virtual System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> DeserializeMembers(object model, TSerializationContextInfo serializationContext, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        protected virtual System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> DeserializeMembers(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context) { }
        protected virtual object DeserializeUsingObjectParse(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context, Catel.Runtime.Serialization.MemberValue memberValue) { }
        protected Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> GetContext(System.Type modelType, TSerializationContextInfo context, Catel.Runtime.Serialization.SerializationContextMode contextMode, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        protected Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> GetContext(System.Type modelType, System.IO.Stream stream, Catel.Runtime.Serialization.SerializationContextMode contextMode, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        protected virtual Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> GetContext(object model, System.Type modelType, TSerializationContextInfo context, Catel.Runtime.Serialization.SerializationContextMode contextMode, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        [System.ObsoleteAttribute("Use `GetSerializationContextInfo` instead. Will be treated as an error from versi" +
            "on 6.0.0. Will be removed in version 6.0.0.", false)]
        protected abstract Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> GetContext(object model, System.Type modelType, System.IO.Stream stream, Catel.Runtime.Serialization.SerializationContextMode contextMode, Catel.Runtime.Serialization.ISerializationConfiguration configuration);
        protected virtual Catel.Runtime.Serialization.ISerializationConfiguration GetCurrentSerializationConfiguration(Catel.Runtime.Serialization.ISerializationConfiguration configuration) { }
        protected virtual Catel.Scoping.ScopeManager<Catel.Runtime.Serialization.SerializationScope> GetCurrentSerializationScopeManager(Catel.Runtime.Serialization.ISerializationConfiguration configuration) { }
        protected Catel.Runtime.Serialization.SerializationMemberGroup GetMemberGroup(System.Type modelType, string memberName) { }
        protected System.Type GetMemberType(System.Type modelType, string memberName) { }
        protected virtual System.Reflection.MethodInfo GetObjectParseMethod(System.Type memberType) { }
        protected virtual System.Reflection.MethodInfo GetObjectToStringMethod(System.Type memberType) { }
        public virtual System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> GetSerializableMembers(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context, object model, params string[] membersToIgnore) { }
        protected abstract Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> GetSerializationContextInfo(object model, System.Type modelType, System.IO.Stream stream, Catel.Runtime.Serialization.SerializationContextMode contextMode, Catel.Runtime.Serialization.ISerializationConfiguration configuration);
        protected virtual bool IsRootCollection(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context, Catel.Runtime.Serialization.MemberValue memberValue) { }
        protected virtual bool IsRootDictionary(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context, Catel.Runtime.Serialization.MemberValue memberValue) { }
        protected virtual bool IsRootObject(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context, Catel.Runtime.Serialization.MemberValue memberValue, System.Func<Catel.Runtime.Serialization.MemberValue, bool> predicate) { }
        [System.ObsoleteAttribute("Use `PopulateModel(ISerializationContext<TSerializationContextInfo>, MemberValue[" +
            "])` instead. Will be removed in version 6.0.0.", true)]
        protected virtual void PopulateModel(object model, params Catel.Runtime.Serialization.MemberValue[] members) { }
        protected virtual void PopulateModel(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context, System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> members) { }
        public virtual void Serialize(object model, System.IO.Stream stream, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        public void Serialize(object model, Catel.Runtime.Serialization.ISerializationContextInfo context, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        public virtual void Serialize(object model, TSerializationContextInfo context, Catel.Runtime.Serialization.ISerializationConfiguration configuration = null) { }
        protected virtual void Serialize(object model, Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context) { }
        protected abstract void SerializeMember(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context, Catel.Runtime.Serialization.MemberValue memberValue);
        public virtual void SerializeMembers(object model, System.IO.Stream stream, Catel.Runtime.Serialization.ISerializationConfiguration configuration, params string[] membersToIgnore) { }
        protected virtual void SerializeMembers(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context, System.Collections.Generic.List<Catel.Runtime.Serialization.MemberValue> membersToSerialize) { }
        protected virtual string SerializeUsingObjectToString(Catel.Runtime.Serialization.ISerializationContext<TSerializationContextInfo> context, Catel.Runtime.Serialization.MemberValue memberValue) { }
        protected virtual bool ShouldExternalSerializerHandleMember(Catel.Runtime.Serialization.MemberValue memberValue) { }
        protected virtual bool ShouldExternalSerializerHandleMember(System.Type memberType) { }
        protected virtual bool ShouldIgnoreMember(object model, string propertyName) { }
        protected bool ShouldSerializeAsCollection(Catel.Runtime.Serialization.MemberValue memberValue) { }
        protected virtual bool ShouldSerializeAsCollection(System.Type memberType) { }
        protected bool ShouldSerializeAsDictionary(Catel.Runtime.Serialization.MemberValue memberValue) { }
        protected virtual bool ShouldSerializeAsDictionary(System.Type memberType) { }
        protected virtual bool ShouldSerializeEnumAsString(Catel.Runtime.Serialization.MemberValue memberValue, bool checkActualMemberType) { }
        protected virtual bool ShouldSerializeModelAsCollection(System.Type memberType) { }
        protected virtual bool ShouldSerializeUsingParseAndToString(Catel.Runtime.Serialization.MemberValue memberValue, bool checkActualMemberType) { }
        public void Warmup(System.Collections.Generic.IEnumerable<System.Type> types, int typesPerThread = 1000) { }
        protected abstract void Warmup(System.Type type);
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Class | System.AttributeTargets.All, AllowMultiple=true, Inherited=true)]
    public class SerializerModifierAttribute : System.Attribute
    {
        public SerializerModifierAttribute(System.Type serializerModifierType) { }
        public System.Type SerializerModifierType { get; }
    }
    public abstract class SerializerModifierBase : Catel.Runtime.Serialization.ISerializerModifier
    {
        protected SerializerModifierBase() { }
        public virtual void DeserializeMember(Catel.Runtime.Serialization.ISerializationContext context, Catel.Runtime.Serialization.MemberValue memberValue) { }
        public virtual void OnDeserialized(Catel.Runtime.Serialization.ISerializationContext context, object model) { }
        public virtual void OnDeserializing(Catel.Runtime.Serialization.ISerializationContext context, object model) { }
        public virtual void OnSerialized(Catel.Runtime.Serialization.ISerializationContext context, object model) { }
        public virtual void OnSerializing(Catel.Runtime.Serialization.ISerializationContext context, object model) { }
        public virtual void SerializeMember(Catel.Runtime.Serialization.ISerializationContext context, Catel.Runtime.Serialization.MemberValue memberValue) { }
        public virtual bool ShouldIgnoreMember(Catel.Runtime.Serialization.ISerializationContext context, object model, Catel.Runtime.Serialization.MemberValue memberValue) { }
        public virtual System.Nullable<bool> ShouldSerializeAsCollection() { }
        public virtual System.Nullable<bool> ShouldSerializeAsDictionary() { }
        public virtual System.Nullable<bool> ShouldSerializeEnumMemberUsingToString(Catel.Runtime.Serialization.MemberValue memberValue) { }
        public virtual System.Nullable<bool> ShouldSerializeMemberUsingParse(Catel.Runtime.Serialization.MemberValue memberValue) { }
    }
    public abstract class SerializerModifierBase<TModel> : Catel.Runtime.Serialization.SerializerModifierBase
    {
        protected SerializerModifierBase() { }
        public virtual void OnDeserialized(Catel.Runtime.Serialization.ISerializationContext context, TModel model) { }
        public virtual void OnDeserializing(Catel.Runtime.Serialization.ISerializationContext context, TModel model) { }
        public virtual void OnSerialized(Catel.Runtime.Serialization.ISerializationContext context, TModel model) { }
        public virtual void OnSerializing(Catel.Runtime.Serialization.ISerializationContext context, TModel model) { }
    }
}
namespace Catel.Runtime.Serialization.Xml
{
    public class DataContractSerializerFactory : Catel.Runtime.Serialization.Xml.IDataContractSerializerFactory
    {
        public DataContractSerializerFactory() { }
        public System.Runtime.Serialization.DataContractResolver DataContractResolver { get; set; }
        public System.Runtime.Serialization.IDataContractSurrogate DataContractSurrogate { get; set; }
        protected virtual bool AddTypeToKnownTypesIfSerializable(System.Type typeToAdd, Catel.Runtime.Serialization.Xml.DataContractSerializerFactory.XmlSerializerTypeInfo serializerTypeInfo) { }
        protected virtual bool AllowNonPublicReflection(System.Type type) { }
        public virtual System.Runtime.Serialization.DataContractSerializer GetDataContractSerializer(System.Type serializingType, System.Type typeToSerialize, string xmlName, string rootNamespace = null, System.Collections.Generic.List<System.Type> additionalKnownTypes = null) { }
        public virtual System.Collections.Generic.List<System.Type> GetKnownTypes(System.Type serializingType, System.Type typeToSerialize, System.Collections.Generic.List<System.Type> additionalKnownTypes = null) { }
        protected virtual void GetKnownTypes(System.Type type, Catel.Runtime.Serialization.Xml.DataContractSerializerFactory.XmlSerializerTypeInfo serializerTypeInfo, bool resolveAbstractClassesAndInterfaces = True) { }
        protected virtual System.Type[] GetKnownTypesViaAttributes(System.Type type) { }
        protected virtual bool IsTypeSerializable(System.Type type, Catel.Runtime.Serialization.Xml.DataContractSerializerFactory.XmlSerializerTypeInfo serializerTypeInfo) { }
        protected virtual bool ShouldTypeBeIgnored(System.Type type, Catel.Runtime.Serialization.Xml.DataContractSerializerFactory.XmlSerializerTypeInfo serializerTypeInfo) { }
        protected class XmlSerializerTypeInfo
        {
            public XmlSerializerTypeInfo(System.Type serializingType, System.Type typeToSerialize, System.Collections.Generic.IEnumerable<System.Type> additionalKnownTypes = null) { }
            public System.Collections.Generic.IEnumerable<System.Type> KnownTypes { get; }
            public System.Type SerializingType { get; }
            public System.Collections.Generic.IEnumerable<System.Type> SpecialCollectionTypes { get; }
            public System.Collections.Generic.IEnumerable<System.Type> SpecialGenericCollectionTypes { get; }
            public System.Type TypeToSerialize { get; }
            public System.Collections.Generic.IEnumerable<System.Type> TypesAlreadyHandled { get; }
            public void AddCollectionAsHandled(System.Type type) { }
            public bool AddKnownType(System.Type type) { }
            public void AddTypeAsHandled(System.Type type) { }
            public bool ContainsKnownType(System.Type type) { }
            public bool IsCollectionAlreadyHandled(System.Type type) { }
            public bool IsSpecialCollectionType(System.Type type) { }
            public bool IsTypeAlreadyHandled(System.Type type) { }
            public bool IsTypeSerializable(System.Type type) { }
        }
    }
    public interface ICustomXmlSerializable
    {
        void Deserialize(System.Xml.Linq.XElement xmlElement);
        void Serialize(System.Xml.Linq.XElement xmlElement);
    }
    public interface IDataContractSerializerFactory
    {
        System.Runtime.Serialization.DataContractResolver DataContractResolver { get; set; }
        System.Runtime.Serialization.IDataContractSurrogate DataContractSurrogate { get; set; }
        System.Runtime.Serialization.DataContractSerializer GetDataContractSerializer(System.Type serializingType, System.Type typeToSerialize, string xmlName, string rootNamespace = null, System.Collections.Generic.List<System.Type> additionalKnownTypes = null);
        System.Collections.Generic.List<System.Type> GetKnownTypes(System.Type serializingType, System.Type typeToSerialize, System.Collections.Generic.List<System.Type> additionalKnownTypes = null);
    }
    public interface IXmlNamespaceManager
    {
        Catel.Runtime.Serialization.Xml.XmlNamespace GetNamespace(System.Type type, string preferredPrefix);
    }
    public interface IXmlSerializer : Catel.Runtime.Serialization.ISerializer { }
    public class static XmlHelper
    {
        public static object ConvertToObject(System.Xml.Linq.XElement element, System.Type objectType, System.Func<object> createDefaultValue) { }
        public static System.Xml.Linq.XElement ConvertToXml(string elementName, System.Type objectType, object objectValue) { }
    }
    public class XmlNamespace
    {
        public XmlNamespace(string prefix, string uri) { }
        public string Prefix { get; }
        public string Uri { get; }
        public override string ToString() { }
    }
    public class XmlNamespaceManager : Catel.Runtime.Serialization.Xml.IXmlNamespaceManager
    {
        public XmlNamespaceManager() { }
        public Catel.Runtime.Serialization.Xml.XmlNamespace GetNamespace(System.Type type, string preferredPrefix) { }
    }
    public class static XmlSchemaHelper
    {
        public const string Xmlns = "http://www.w3.org/2001/XMLSchema";
        public static System.Xml.XmlQualifiedName GetXmlSchema(System.Type type, System.Xml.Schema.XmlSchemaSet schemaSet, bool generateFlatSchema) { }
    }
    public class XmlSchemaManager
    {
        public XmlSchemaManager() { }
        public static bool GenerateFlatSchemas { get; set; }
        public static System.Xml.XmlQualifiedName GetXmlSchema(System.Type type, System.Xml.Schema.XmlSchemaSet schemaSet) { }
    }
    public class XmlSerializationConfiguration : Catel.Runtime.Serialization.SerializationConfiguration
    {
        public XmlSerializationConfiguration() { }
        public Catel.Runtime.Serialization.Xml.XmlSerializerOptimalizationMode OptimalizationMode { get; set; }
    }
    public class XmlSerializationContextInfo : Catel.Runtime.Serialization.SerializationContextInfoBase<Catel.Runtime.Serialization.Xml.XmlSerializationContextInfo>
    {
        public XmlSerializationContextInfo(System.Xml.Linq.XElement element, object model) { }
        public XmlSerializationContextInfo(System.Xml.XmlReader xmlReader, Catel.Data.ModelBase model) { }
        public XmlSerializationContextInfo(string xmlContent, Catel.Data.ModelBase model) { }
        public System.Xml.Linq.XElement Element { get; }
        public System.Collections.Generic.HashSet<System.Type> KnownTypes { get; }
        public object Model { get; }
        protected override void OnContextUpdated(Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Xml.XmlSerializationContextInfo> context) { }
    }
    public class XmlSerializationContextInfoFactory : Catel.Runtime.Serialization.ISerializationContextInfoFactory
    {
        public XmlSerializationContextInfoFactory() { }
        public Catel.Runtime.Serialization.ISerializationContextInfo GetSerializationContextInfo(Catel.Runtime.Serialization.ISerializer serializer, object model, object data, Catel.Runtime.Serialization.ISerializationConfiguration configuration) { }
    }
    public class XmlSerializer : Catel.Runtime.Serialization.SerializerBase<Catel.Runtime.Serialization.Xml.XmlSerializationContextInfo>, Catel.Runtime.Serialization.ISerializer, Catel.Runtime.Serialization.Xml.IXmlSerializer
    {
        public XmlSerializer(Catel.Runtime.Serialization.ISerializationManager serializationManager, Catel.Runtime.Serialization.Xml.IDataContractSerializerFactory dataContractSerializerFactory, Catel.Runtime.Serialization.Xml.IXmlNamespaceManager xmlNamespaceManager, Catel.IoC.ITypeFactory typeFactory, Catel.Runtime.Serialization.IObjectAdapter objectAdapter) { }
        protected override void AppendContextToStream(Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Xml.XmlSerializationContextInfo> context, System.IO.Stream stream) { }
        protected override void BeforeDeserialization(Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Xml.XmlSerializationContextInfo> context) { }
        protected override void BeforeSerialization(Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Xml.XmlSerializationContextInfo> context) { }
        protected override object Deserialize(object model, Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Xml.XmlSerializationContextInfo> context) { }
        protected override Catel.Runtime.Serialization.SerializationObject DeserializeMember(Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Xml.XmlSerializationContextInfo> context, Catel.Runtime.Serialization.MemberValue memberValue) { }
        [System.ObsoleteAttribute("Use `GetSerializationContextInfo` instead. Will be removed in version 6.0.0.", true)]
        protected override Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Xml.XmlSerializationContextInfo> GetContext(object model, System.Type modelType, System.IO.Stream stream, Catel.Runtime.Serialization.SerializationContextMode contextMode, Catel.Runtime.Serialization.ISerializationConfiguration configuration) { }
        protected virtual string GetNamespacePrefix() { }
        protected virtual string GetNamespaceUrl() { }
        protected override Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Xml.XmlSerializationContextInfo> GetSerializationContextInfo(object model, System.Type modelType, System.IO.Stream stream, Catel.Runtime.Serialization.SerializationContextMode contextMode, Catel.Runtime.Serialization.ISerializationConfiguration configuration) { }
        protected string GetXmlElementName(System.Type modelType, object model, string memberName) { }
        protected virtual Catel.Runtime.Serialization.Xml.XmlSerializerOptimalizationMode GetXmlOptimalizationMode(Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Xml.XmlSerializationContextInfo> context) { }
        protected virtual void OptimizeXDocument(System.Xml.Linq.XDocument document, Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Xml.XmlSerializationContextInfo> context) { }
        protected virtual void OptimizeXElement(System.Xml.Linq.XElement element, Catel.Runtime.Serialization.Xml.XmlSerializerOptimalizationMode optimalizationMode) { }
        protected override void Serialize(object model, Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Xml.XmlSerializationContextInfo> context) { }
        protected override void SerializeMember(Catel.Runtime.Serialization.ISerializationContext<Catel.Runtime.Serialization.Xml.XmlSerializationContextInfo> context, Catel.Runtime.Serialization.MemberValue memberValue) { }
        protected override bool ShouldIgnoreMember(object model, string propertyName) { }
        protected override void Warmup(System.Type type) { }
    }
    public enum XmlSerializerOptimalizationMode
    {
        PrettyXml = 0,
        PrettyXmlAgressive = 1,
        Performance = 2,
    }
}
namespace Catel.Scoping
{
    public class ScopeClosedEventArgs : System.EventArgs
    {
        public ScopeClosedEventArgs(object scopeObject, string scopeName) { }
        public string ScopeName { get; }
        public object ScopeObject { get; }
    }
    public class ScopeManager<T> : System.IDisposable
        where T :  class
    {
        protected ScopeManager(string scopeName, System.Func<T> createScopeFunction) { }
        public int RefCount { get; }
        public T ScopeObject { get; }
        public event System.EventHandler<Catel.Scoping.ScopeClosedEventArgs> ScopeClosed;
        public void Dispose() { }
        public static Catel.Scoping.ScopeManager<T> GetScopeManager(string scopeName = "", System.Func<T> createScopeFunction = null) { }
        public static bool ScopeExists(string scopeName = "") { }
    }
}
namespace Catel.Services
{
    public class GuidObjectIdGenerator<TObjectType> : Catel.Services.ObjectIdGenerator<TObjectType, System.Guid>
        where TObjectType :  class
    {
        public GuidObjectIdGenerator() { }
        protected override System.Guid GenerateUniqueIdentifier() { }
    }
    public interface ILanguageService
    {
        bool CacheResults { get; set; }
        System.Globalization.CultureInfo FallbackCulture { get; set; }
        System.Globalization.CultureInfo PreferredCulture { get; set; }
        public event System.EventHandler<System.EventArgs> LanguageUpdated;
        void ClearLanguageResources();
        string GetString(string resourceName);
        string GetString(string resourceName, System.Globalization.CultureInfo cultureInfo);
        string GetString(Catel.Services.ILanguageSource languageSource, string resourceName, System.Globalization.CultureInfo cultureInfo);
        void PreloadLanguageSources();
        void RegisterLanguageSource(Catel.Services.ILanguageSource languageSource);
    }
    public interface ILanguageSource
    {
        string GetSource();
    }
    public interface IObjectConverterService
    {
        System.Globalization.CultureInfo DefaultCulture { get; set; }
        object ConvertFromObjectToObject(object value, System.Type targetType);
        string ConvertFromObjectToString(object value);
        string ConvertFromObjectToString(object value, System.Globalization.CultureInfo culture);
        object ConvertFromStringToObject(string value, System.Type targetType);
        object ConvertFromStringToObject(string value, System.Type targetType, System.Globalization.CultureInfo culture);
    }
    public class static IObjectConverterServiceExtensions
    {
        public static T ConvertFromObjectToObject<T>(this Catel.Services.IObjectConverterService service, object value) { }
        public static T ConvertFromStringToObject<T>(this Catel.Services.IObjectConverterService service, string value) { }
    }
    public interface IObjectIdGenerator<TUniqueIdentifier>
    {
        TUniqueIdentifier GetUniqueIdentifier(bool reuse = False);
        void ReleaseIdentifier(TUniqueIdentifier identifier);
    }
    public interface IObjectIdGenerator<in TObjectType, TUniqueIdentifier> : Catel.Services.IObjectIdGenerator<TUniqueIdentifier>
        where in TObjectType :  class
    {
        TUniqueIdentifier GetUniqueIdentifierForInstance(TObjectType instance, bool reuse = False);
    }
    public interface IRollingInMemoryLogService
    {
        Catel.Logging.RollingInMemoryLogListener LogListener { get; }
        int MaximumNumberOfErrorLogEntries { get; set; }
        int MaximumNumberOfLogEntries { get; set; }
        int MaximumNumberOfWarningLogEntries { get; set; }
        public event System.EventHandler<Catel.Logging.LogMessageEventArgs> LogMessage;
        System.Collections.Generic.IEnumerable<Catel.Logging.LogEntry> GetErrorLogEntries();
        System.Collections.Generic.IEnumerable<Catel.Logging.LogEntry> GetLogEntries();
        System.Collections.Generic.IEnumerable<Catel.Logging.LogEntry> GetWarningLogEntries();
    }
    public interface IService
    {
        string Name { get; }
    }
    public sealed class IntegerObjectIdGenerator<TObjectType> : Catel.Services.NumericBasedObjectIdGenerator<TObjectType, int>
        where TObjectType :  class
    {
        public IntegerObjectIdGenerator() { }
        protected override int GenerateUniqueIdentifier() { }
    }
    public class LanguageResourceKey : System.IEquatable<Catel.Services.LanguageResourceKey>
    {
        public LanguageResourceKey(string resourceName, System.Globalization.CultureInfo cultureInfo) { }
        public System.Globalization.CultureInfo CultureInfo { get; }
        public string ResourceName { get; }
        public override bool Equals(object obj) { }
        public bool Equals(Catel.Services.LanguageResourceKey other) { }
        public override int GetHashCode() { }
    }
    [System.Diagnostics.DebuggerDisplayAttribute("{GetSource()}")]
    public class LanguageResourceSource : Catel.Services.ILanguageSource
    {
        public LanguageResourceSource(string assemblyName, string namespaceName, string resourceFileName) { }
        public string AssemblyName { get; }
        public string NamespaceName { get; }
        public string ResourceFileName { get; }
        public string GetSource() { }
    }
    public class LanguageService : Catel.Services.LanguageServiceBase, Catel.Services.ILanguageService
    {
        public LanguageService() { }
        public bool CacheResults { get; set; }
        public System.Globalization.CultureInfo FallbackCulture { get; set; }
        public System.Globalization.CultureInfo PreferredCulture { get; set; }
        public event System.EventHandler<System.EventArgs> LanguageUpdated;
        public void ClearLanguageResources() { }
        public string GetString(string resourceName) { }
        public string GetString(string resourceName, System.Globalization.CultureInfo cultureInfo) { }
        public override string GetString(Catel.Services.ILanguageSource languageSource, string resourceName, System.Globalization.CultureInfo cultureInfo) { }
        protected override void PreloadLanguageSource(Catel.Services.ILanguageSource languageSource) { }
        public virtual void PreloadLanguageSources() { }
        public void RegisterLanguageSource(Catel.Services.ILanguageSource languageSource) { }
    }
    public abstract class LanguageServiceBase
    {
        protected LanguageServiceBase() { }
        public abstract string GetString(Catel.Services.ILanguageSource languageSource, string resourceName, System.Globalization.CultureInfo cultureInfo);
        protected abstract void PreloadLanguageSource(Catel.Services.ILanguageSource languageSource);
    }
    public sealed class LongObjectIdGenerator<TObjectType> : Catel.Services.NumericBasedObjectIdGenerator<TObjectType, long>
        where TObjectType :  class
    {
        public LongObjectIdGenerator() { }
        protected override long GenerateUniqueIdentifier() { }
    }
    public abstract class NumericBasedObjectIdGenerator<TObjectType, TUniqueIdentifier> : Catel.Services.ObjectIdGenerator<TObjectType, TUniqueIdentifier>
        where TObjectType :  class
    {
        protected NumericBasedObjectIdGenerator() { }
        protected static TUniqueIdentifier Value { get; set; }
    }
    public class ObjectConverterService : Catel.Services.IObjectConverterService
    {
        public ObjectConverterService() { }
        public System.Globalization.CultureInfo DefaultCulture { get; set; }
        public virtual object ConvertFromObjectToObject(object value, System.Type targetType) { }
        public virtual string ConvertFromObjectToString(object value) { }
        public string ConvertFromObjectToString(object value, System.Globalization.CultureInfo culture) { }
        public virtual object ConvertFromStringToObject(string value, System.Type targetType) { }
        public object ConvertFromStringToObject(string value, System.Type targetType, System.Globalization.CultureInfo culture) { }
    }
    public abstract class ObjectIdGenerator<TObjectType, TUniqueIdentifier> : Catel.Services.IObjectIdGenerator<TUniqueIdentifier>, Catel.Services.IObjectIdGenerator<TObjectType, TUniqueIdentifier>
        where TObjectType :  class
    {
        protected readonly object _lock;
        protected ObjectIdGenerator() { }
        protected abstract TUniqueIdentifier GenerateUniqueIdentifier();
        public TUniqueIdentifier GetUniqueIdentifier(bool reuse = False) { }
        public TUniqueIdentifier GetUniqueIdentifierForInstance(TObjectType instance, bool reuse = False) { }
        public void ReleaseIdentifier(TUniqueIdentifier identifier) { }
    }
    public class RollingInMemoryLogService : Catel.Services.ServiceBase, Catel.Services.IRollingInMemoryLogService
    {
        public RollingInMemoryLogService() { }
        public RollingInMemoryLogService(Catel.Logging.RollingInMemoryLogListener logListener) { }
        public Catel.Logging.RollingInMemoryLogListener LogListener { get; }
        public int MaximumNumberOfErrorLogEntries { get; set; }
        public int MaximumNumberOfLogEntries { get; set; }
        public int MaximumNumberOfWarningLogEntries { get; set; }
        public event System.EventHandler<Catel.Logging.LogMessageEventArgs> LogMessage;
        public System.Collections.Generic.IEnumerable<Catel.Logging.LogEntry> GetErrorLogEntries() { }
        public System.Collections.Generic.IEnumerable<Catel.Logging.LogEntry> GetLogEntries() { }
        public System.Collections.Generic.IEnumerable<Catel.Logging.LogEntry> GetWarningLogEntries() { }
    }
    public abstract class ServiceBase : Catel.Services.IService
    {
        protected ServiceBase() { }
        public virtual string Name { get; }
    }
    public sealed class ULongObjectIdGenerator<TObjectType> : Catel.Services.NumericBasedObjectIdGenerator<TObjectType, ulong>
        where TObjectType :  class
    {
        public ULongObjectIdGenerator() { }
        protected override ulong GenerateUniqueIdentifier() { }
    }
}
namespace Catel.Tests
{
    public class static ExceptionTester
    {
        public static TException CallMethodAndExpectException<TException>(System.Action action, System.Func<TException, bool> exceptionValidator = null)
            where TException : System.Exception { }
    }
}
namespace Catel.Text
{
    public class static StringBuilderExtensions
    {
        public static void AppendLine(this System.Text.StringBuilder sb, string format, params object[] args) { }
    }
}
namespace Catel.Threading
{
    [System.Diagnostics.DebuggerDisplayAttribute("Id = {Id}, Taken = {_taken}")]
    [System.Diagnostics.DebuggerTypeProxyAttribute(typeof(Catel.Threading.AsyncLock.DebugView))]
    public sealed class AsyncLock
    {
        public AsyncLock() { }
        public AsyncLock(Catel.Threading.IAsyncWaitQueue<System.IDisposable> queue) { }
        public int Id { get; }
        public bool IsTaken { get; }
        public System.IDisposable Lock(System.Threading.CancellationToken cancellationToken) { }
        public System.IDisposable Lock() { }
        public Catel.Threading.AwaitableDisposable<System.IDisposable> LockAsync(System.Threading.CancellationToken cancellationToken) { }
        public Catel.Threading.AwaitableDisposable<System.IDisposable> LockAsync() { }
    }
    public class static AsyncWaitQueueExtensions
    {
        public static System.Threading.Tasks.Task<T> EnqueueAsync<T>(this Catel.Threading.IAsyncWaitQueue<T> @this, object syncObject, System.Threading.CancellationToken token) { }
    }
    public struct AwaitableDisposable<T>
        where T : System.IDisposable
    {
        public AwaitableDisposable(System.Threading.Tasks.Task<T> task) { }
        public System.Threading.Tasks.Task<T> AsTask() { }
        public System.Runtime.CompilerServices.ConfiguredTaskAwaitable<T> ConfigureAwait(bool continueOnCapturedContext) { }
        public System.Runtime.CompilerServices.TaskAwaiter<T> GetAwaiter() { }
        public static System.Threading.Tasks.Task<T> op_Implicit(Catel.Threading.AwaitableDisposable<T> source) { }
    }
    [System.Diagnostics.DebuggerDisplayAttribute("Count = {Count}")]
    [System.Diagnostics.DebuggerTypeProxyAttribute(typeof(Catel.Threading.DefaultAsyncWaitQueue<>.DebugView))]
    public sealed class DefaultAsyncWaitQueue<T> : Catel.Threading.IAsyncWaitQueue<T>
    {
        public DefaultAsyncWaitQueue() { }
    }
    public interface IAsyncWaitQueue<T>
    {
        bool IsEmpty { get; }
        System.IDisposable CancelAll();
        System.IDisposable Dequeue(T result = null);
        System.IDisposable DequeueAll(T result = null);
        System.Threading.Tasks.Task<T> EnqueueAsync();
        System.IDisposable TryCancel(System.Threading.Tasks.Task task);
    }
    public class static ReaderWriterLockSlimExtensions
    {
        public static void PerformRead(this System.Threading.ReaderWriterLockSlim lockSlim, System.Action criticalOperation) { }
        public static T PerformRead<T>(this System.Threading.ReaderWriterLockSlim lockSlim, System.Func<T> criticalOperation) { }
        public static void PerformUpgradableRead(this System.Threading.ReaderWriterLockSlim lockSlim, System.Action criticalOperation) { }
        public static T PerformUpgradableRead<T>(this System.Threading.ReaderWriterLockSlim lockSlim, System.Func<T> criticalOperation) { }
        public static void PerformWrite(this System.Threading.ReaderWriterLockSlim lockSlim, System.Action criticalOperation) { }
    }
    public class SynchronizationContext
    {
        public SynchronizationContext() { }
        public bool IsLockAcquired { get; }
        public void Acquire() { }
        public void Execute(System.Action code) { }
        public T Execute<T>(System.Func<T> code) { }
        public void Release() { }
    }
    public class static SynchronizationContextExtensions
    {
        public static Catel.IDisposableToken<Catel.Threading.SynchronizationContext> AcquireScope(this Catel.Threading.SynchronizationContext synchronizationContext) { }
    }
    public class static TaskExtensions
    {
        public static System.Threading.Tasks.Task AwaitWithTimeoutAsync(this System.Threading.Tasks.Task task, int timeout) { }
        public static void WaitAndUnwrapException(this System.Threading.Tasks.Task task) { }
        public static void WaitAndUnwrapException(this System.Threading.Tasks.Task task, System.Threading.CancellationToken cancellationToken) { }
        public static TResult WaitAndUnwrapException<TResult>(this System.Threading.Tasks.Task<TResult> task) { }
        public static TResult WaitAndUnwrapException<TResult>(this System.Threading.Tasks.Task<TResult> task, System.Threading.CancellationToken cancellationToken) { }
    }
    public class static TaskHelper
    {
        public const bool DefaultConfigureAwaitValue = false;
        public static System.Threading.Tasks.Task Canceled { get; }
        public static System.Threading.Tasks.Task Completed { get; }
        public static System.Threading.Tasks.Task Run(System.Action action, bool configureAwait = False, System.Threading.CancellationToken cancellationToken = null) { }
        public static System.Threading.Tasks.Task<TResult> Run<TResult>(System.Func<TResult> func, bool configureAwait = False, System.Threading.CancellationToken cancellationToken = null) { }
        public static System.Threading.Tasks.Task Run(System.Func<System.Threading.Tasks.Task> func, bool configureAwait = False, System.Threading.CancellationToken cancellationToken = null) { }
        public static System.Threading.Tasks.Task<TResult> Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>> func, bool configureAwait = False, System.Threading.CancellationToken cancellationToken = null) { }
        public static void RunAndWait(params System.Action[] actions) { }
        public static System.Threading.Tasks.Task RunAndWaitAsync(params System.Action[] actions) { }
        public static System.Threading.Tasks.Task RunAndWaitAsync(params System.Func<>[] actions) { }
    }
    public class static TaskHelper<T>
    {
        public static System.Threading.Tasks.Task<T> Canceled { get; }
        public static System.Threading.Tasks.Task<T> DefaultValue { get; }
        public static System.Threading.Tasks.Task<T> FromResult(T value) { }
    }
    public class static TaskShim
    {
        public static System.Threading.Tasks.Task Delay(int millisecondsDelay) { }
        public static System.Threading.Tasks.Task Delay(int millisecondsDelay, System.Threading.CancellationToken cancellationToken) { }
        public static System.Threading.Tasks.Task Delay(System.TimeSpan dueTime) { }
        public static System.Threading.Tasks.Task Delay(System.TimeSpan dueTime, System.Threading.CancellationToken cancellationToken) { }
        public static System.Threading.Tasks.Task<TResult> FromResult<TResult>(TResult result) { }
        public static System.Threading.Tasks.Task Run(System.Action action) { }
        public static System.Threading.Tasks.Task Run(System.Action action, System.Threading.CancellationToken cancellationToken) { }
        public static System.Threading.Tasks.Task Run(System.Func<System.Threading.Tasks.Task> function) { }
        public static System.Threading.Tasks.Task Run(System.Func<System.Threading.Tasks.Task> function, System.Threading.CancellationToken cancellationToken) { }
        public static System.Threading.Tasks.Task<TResult> Run<TResult>(System.Func<TResult> function) { }
        public static System.Threading.Tasks.Task<TResult> Run<TResult>(System.Func<TResult> function, System.Threading.CancellationToken cancellationToken) { }
        public static System.Threading.Tasks.Task<TResult> Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>> function) { }
        public static System.Threading.Tasks.Task<TResult> Run<TResult>(System.Func<System.Threading.Tasks.Task<TResult>> function, System.Threading.CancellationToken cancellationToken) { }
        public static System.Threading.Tasks.Task<TResult[]> WhenAll<TResult>(System.Collections.Generic.IEnumerable<System.Threading.Tasks.Task<TResult>> tasks) { }
        public static System.Threading.Tasks.Task<TResult[]> WhenAll<TResult>(params System.Threading.Tasks.Task<>[] tasks) { }
        public static System.Threading.Tasks.Task WhenAll(System.Collections.Generic.IEnumerable<System.Threading.Tasks.Task> tasks) { }
        public static System.Threading.Tasks.Task WhenAll(params System.Threading.Tasks.Task[] tasks) { }
        public static System.Threading.Tasks.Task<System.Threading.Tasks.Task> WhenAny(params System.Threading.Tasks.Task[] tasks) { }
        public static System.Threading.Tasks.Task<System.Threading.Tasks.Task> WhenAny(System.Collections.Generic.IEnumerable<System.Threading.Tasks.Task> tasks) { }
        public static System.Threading.Tasks.Task<System.Threading.Tasks.Task<TResult>> WhenAny<TResult>(params System.Threading.Tasks.Task<>[] tasks) { }
        public static System.Threading.Tasks.Task<System.Threading.Tasks.Task<TResult>> WhenAny<TResult>(System.Collections.Generic.IEnumerable<System.Threading.Tasks.Task<TResult>> tasks) { }
        public static System.Runtime.CompilerServices.YieldAwaitable Yield() { }
    }
    public class static Timeout
    {
        public const int Infinite = -1;
        public static readonly System.TimeSpan InfiniteTimeSpan;
    }
    public class Timer : System.IDisposable
    {
        public Timer() { }
        public Timer(int interval) { }
        public Timer(Catel.Threading.TimerCallback callback) { }
        public Timer(Catel.Threading.TimerCallback callback, object state, int dueTime, int interval) { }
        public Timer(Catel.Threading.TimerCallback callback, object state, System.TimeSpan dueTime, System.TimeSpan interval) { }
        public int Interval { get; set; }
        public event System.EventHandler<System.EventArgs> Changed;
        public event System.EventHandler<System.EventArgs> Elapsed;
        public void Change(int dueTime, int interval) { }
        public void Change(System.TimeSpan dueTime, System.TimeSpan interval) { }
        public void Dispose() { }
    }
    public delegate void TimerCallback(object state);
}
namespace System.ComponentModel
{
    public class BeginEditEventArgs : System.ComponentModel.EditEventArgs { }
    public class CancelEditCompletedEventArgs : System.EventArgs { }
    public class CancelEditEventArgs : System.ComponentModel.EditEventArgs { }
    public class EditEventArgs : System.EventArgs { }
    public class EndEditEventArgs : System.ComponentModel.EditEventArgs { }
    public interface IAdvancedEditableObject : System.ComponentModel.IEditableObject { }
    public interface IDataWarningInfo { }
    public interface INotifyDataWarningInfo { }
    public class static PropertyChangedEventArgsExtensions { }
}