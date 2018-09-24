using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Commons.Type
{
    /// <summary>
    /// Delegation class for a <see cref="IEqualityComparer{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class DelegateEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _equalsFunc;
        private readonly Func<T, int> _hashCodeFunc;

        public DelegateEqualityComparer(Func<T, T, bool> equalsFunc, Func<T, int> hashCodeFunc)
        {
            _equalsFunc = equalsFunc;
            _hashCodeFunc = hashCodeFunc;
        }

        /// <inheritdoc />
        public bool Equals(T x, T y)
        {
            return _equalsFunc(x, y);
        }

        /// <inheritdoc />
        public int GetHashCode(T obj)
        {
            return _hashCodeFunc(obj);
        }
    }
}
