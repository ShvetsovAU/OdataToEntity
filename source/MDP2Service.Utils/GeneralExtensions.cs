using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASE.MD.MDP2.Product.MDP2Service.Utils.Enums;

namespace ASE.MD.MDP2.Product.MDP2Service.Utils
{
    public static class GeneralExtensions
    {
        /// <summary>
        /// Возвращает значение указанного свойства объекта
        /// </summary>
        public static object GetPropertyValue(this object obj, string propertyName)
        {
            foreach (var prop in propertyName.Split('.'))
            {
                if (obj == null) return null;
                var property = obj.GetType().GetProperty(prop);
                obj = property == null ? null : property.GetValue(obj, null);
            }
            return obj;
        }

        public static void SetPropertyValue(this object obj, string propertyName, object value)
        {
            var names = propertyName.Split('.');
            for (int i = 0; i < names.Length - 1; i++)
            {
                if (obj == null) return;
                obj = obj.GetType().GetProperty(names[i]);
            }
            var prop = obj.GetType().GetProperty(names.Last());
            if (prop != null)
                prop.SetValue(obj, value);
        }

        public static DateTime TruncateTo(this DateTime source, DateTimeTruncate to = DateTimeTruncate.Minute)
        {
            switch (to)
            {
                case DateTimeTruncate.Year:
                    return new DateTime(source.Year, 0, 0);
                case DateTimeTruncate.Month:
                    return new DateTime(source.Year, source.Month, 0);
                case DateTimeTruncate.Day:
                    return new DateTime(source.Year, source.Month, source.Day);
                case DateTimeTruncate.Hour:
                    return new DateTime(source.Year, source.Month, source.Day, source.Hour, 0, 0);
                case DateTimeTruncate.Minute:
                    return new DateTime(source.Year, source.Month, source.Day, source.Hour, source.Minute, 0);
                default:
                    return new DateTime(source.Year, source.Month, source.Day, source.Hour, source.Minute, source.Second);
            }
        }

        public static DateTime? TruncateTo(this DateTime? source, DateTimeTruncate to = DateTimeTruncate.Minute)
        {
            return source != null ? TruncateTo(source.Value, to) : (DateTime?)null;
        }

        /// <summary>
        /// Коллекция пустая или не имеет ссылки.
        /// </summary>
        public static bool Empty(this IEnumerable source)
        {
            if (source == null)
                return true;

            using (var disposableEnumerator = GetDisposableEnumerator(source))
            {
                if (disposableEnumerator.MoveNext())
                    return false;
            }

            return true;
        }

        public static bool Empty(this StringBuilder source)
        {
            return source.Length == 0;
        }

        /// <summary>
        /// Коллекция состоит только из одного элемента или пуста
        /// </summary>
        public static bool HasOneItemOrEmpty(this IEnumerable source)
        {
            if (source == null) return true;
            using (var disposableEnumerator = GetDisposableEnumerator(source))
            {
                return !(disposableEnumerator.MoveNext() && disposableEnumerator.MoveNext());
            }
        }

        public static string NullIfWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source) ? null : source;
        }

        public static string NullIfEmpty(this string source)
        {
            return string.IsNullOrEmpty(source) ? null : source;
        }

        private static DisposableEnumerator GetDisposableEnumerator(this IEnumerable source)
        {
            return new DisposableEnumerator(source);
        }

        public static void RemoveItems(this IList collection, IEnumerable items)
        {
            foreach (var obj in items)
                collection.Remove(obj);
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable.Empty())
                return;

            foreach (var item in enumerable)
                action(item);
        }

        /// <summary>
        ///   This method extends the LINQ methods to flatten a collection of 
        ///   items that have a property of children of the same type.
        /// </summary>
        /// <typeparam name = "T">Item type.</typeparam>
        /// <param name = "source">Source collection.</param>
        /// <param name = "childPropertySelector">
        ///   Child property selector delegate of each item. 
        ///   IEnumerable'T' childPropertySelector(T itemBeingFlattened)
        /// </param>
        /// <returns>Returns a one level list of elements of type T.</returns>
        public static IEnumerable<T> Flatten<T>(
            this IEnumerable<T> source,
            Func<T, IEnumerable<T>> childPropertySelector)
        {
            if (source == null) throw new ArgumentNullException("source");
            return source.Flatten((itemBeingFlattened, objectsBeingFlattened) =>
                         childPropertySelector(itemBeingFlattened));
        }

        /// <summary>
        ///   This method extends the LINQ methods to flatten a collection of 
        ///   items that have a property of children of the same type.
        /// </summary>
        /// <typeparam name = "T">Item type.</typeparam>
        /// <param name = "source">Source collection.</param>
        /// <param name = "childPropertySelector">
        ///   Child property selector delegate of each item. 
        ///   IEnumerable'T' childPropertySelector
        ///   (T itemBeingFlattened, IEnumerable'T' objectsBeingFlattened)
        /// </param>
        /// <returns>Returns a one level list of elements of type T.</returns>
        public static IEnumerable<T> Flatten<T>(
            this IEnumerable<T> source,
            Func<T, IEnumerable<T>, IEnumerable<T>> childPropertySelector)
        {
            return source.Concat(source.Where(item => childPropertySelector(item, source) != null)
                         .SelectMany(itemBeingFlattened => childPropertySelector(itemBeingFlattened, source)
                         .Flatten(childPropertySelector)));
        }

        /// <summary>
        /// Создание сущности TWrapper по сущности TEntity передаваемой в конструкторе
        /// </summary>
        /// <typeparam name="TEntity">оригинал</typeparam>
        /// <typeparam name="TWrapper">то что на выходе</typeparam>
        /// <param name="entity">исходная сущность</param>
        /// <returns></returns>
        public static TWrapper CreateFrom<TEntity, TWrapper>(this TEntity entity) where TWrapper : class
        {
            return Activator.CreateInstance(typeof(TWrapper), entity) as TWrapper;
        }

        public static IEnumerable<T> FlattenTree<T>(IEnumerable<T> roots, Func<T, IEnumerable<T>> childrenProvider)
        {
            if (roots == null) throw new ArgumentNullException("roots");
            if (childrenProvider == null) throw new ArgumentNullException("childrenProvider");

            var stack = new Stack<T>();

            foreach (var root in roots)
            {
                stack.Push(root);
            }

            while (stack.Any())
            {
                var current = stack.Pop();
                yield return current;

                var children = childrenProvider(current);

                if (children == null)
                    continue;

                foreach (var child in children)
                {
                    stack.Push(child);
                }
            }
        }

        public static HashSet<TSource> ToHashSet<TSource, TComparison>(this IEnumerable<TSource> source, Func<TSource, TComparison> comparisonValueProvider)
        {
            if (source == null) throw new ArgumentException("source");
            if (comparisonValueProvider == null) throw new ArgumentException("comarisonValueProvider");

            return new HashSet<TSource>(new DelegateComparer<TSource, TComparison>(comparisonValueProvider));
        }

        /// <summary>
        /// Выборка уникальных значений по заданному ключу.<br/>
        /// <i>Если необходим составной ключ, то воспользуйтесь анонимным типом (new { key1, key2 })</i><br/>
        /// <b>!Важно: используется отложенный итератор!</b>
        /// </summary>
        public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Удаление дубликатов значений из коллекции по заданному ключу.<br/>
        /// <i>Если необходим составной ключ, то воспользуйтесь анонимным типом (new { key1, key2 })</i>
        /// </summary>
        public static void Distinct<TSource, TKey>(this ICollection<TSource> source, Func<TSource, TKey> keySelector)
        {
            var deletingElements = new List<TSource>(source.Count / 2);
            var seenKeys = new HashSet<TKey>();
            foreach (var element in source)
                if (!seenKeys.Add(keySelector(element)))
                    deletingElements.Add(element);
               
            foreach (var element in deletingElements)
                source.Remove(element);
        }

        /// <summary>
        /// Объединение двух наборов уникальными значениями по заданному ключу.<br/>
        /// <i>Если необходим составной ключ, то воспользуйтесь анонимным типом (new { key1, key2 })</i><br/>
        /// <b>!Важно: используется отложенный итератор!</b>
        /// </summary>
        public static IEnumerable<TSource> Union<TSource, TKey>(this IEnumerable<TSource> source,
            IEnumerable<TSource> second, Func<TSource, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
                if (seenKeys.Add(keySelector(element)))
                    yield return element;

            foreach (TSource element in second)
                if (seenKeys.Add(keySelector(element)))
                    yield return element;
        }

        /// <summary>
        /// Объединение уникальных значений в текущую коллекцию по заданному ключу.<br/>
        /// <i>Если необходим составной ключ, то воспользуйтесь анонимным типом (new { key1, key2 })</i>
        /// </summary>
        public static void Union<TSource, TKey>(this ICollection<TSource> source,
            IEnumerable<TSource> second, Func<TSource, TKey> keySelector)
        {
            var deletingElements = new List<TSource>(source.Count / 2);
            var seenKeys = new HashSet<TKey>();
            foreach (var element in source)
                if (!seenKeys.Add(keySelector(element)))
                    deletingElements.Add(element);

            foreach (var element in deletingElements)
                source.Remove(element);
            
            foreach (var element in second)
                if (seenKeys.Add(keySelector(element)))
                    source.Add(element);
        }

        #region DelegateComparer

        private class DelegateComparer<TSource, TComparison> : IEqualityComparer<TSource>
        {
            private readonly Func<TSource, TComparison> _valueProvider;

            public DelegateComparer(Func<TSource, TComparison> valueProvider)
            {
                _valueProvider = valueProvider;
            }

            public bool Equals(TSource first, TSource second)
            {
                return EqualityComparer<TComparison>.Default.Equals(_valueProvider(first), _valueProvider(second));
            }

            public int GetHashCode(TSource source)
            {
                return _valueProvider(source).GetHashCode();
            }
        }

        #endregion
    }

    public class DisposableEnumerator : IDisposable, IEnumerator
    {
        #region Properties & Fields

        private readonly IEnumerator _wrapped;

        public object Current
        {
            get { return _wrapped.Current; }
        }

        #endregion

        #region Constructors

        public DisposableEnumerator(IEnumerable source)
        {
            _wrapped = source.GetEnumerator();
        }

        #endregion

        #region Methods & Handlers

        public void Dispose()
        {
            if (!(_wrapped is IDisposable wrapped))
                return;

            wrapped.Dispose();
        }

        public bool MoveNext()
        {
            return _wrapped.MoveNext();
        }

        public void Reset()
        {
            _wrapped.Reset();
        }

        #endregion
    }
}