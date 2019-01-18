using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ClassLibraryFluentAPI
{
    [ExcludeFromCodeCoverage]
    public abstract class DomainEntity<TKey> : IComparable, IComparable<DomainEntity<TKey>>, IEquatable<DomainEntity<TKey>> where TKey : IComparable, IComparable<TKey>, IEquatable<TKey>
    {
        public TKey Id
        {
            get;
            set;
        }

        public int CompareTo(object obj)
        {
            return ((IComparable<DomainEntity<TKey>>)this).CompareTo(obj as DomainEntity<TKey>);
        }

        public int CompareTo(DomainEntity<TKey> other)
        {
            bool flag = other == null;
            int result;
            if (flag)
            {
                result = 1;
            }
            else
            {
                string displayName = this.GetDisplayName() ?? string.Empty;
                string otherName = other.GetDisplayName() ?? string.Empty;
                result = string.Compare(displayName, otherName, StringComparison.CurrentCultureIgnoreCase);
            }
            return result;

        }

        public bool Equals(DomainEntity<TKey> other)
        {
            bool flag = other == null;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                string domainKey = this.GetDomainId() ?? string.Empty;
                string otherKey = other.GetDomainId() ?? string.Empty;
                result = (base.GetType().Equals(other.GetType()) && domainKey.Equals(otherKey));
            }
            return result;

        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as DomainEntity<TKey>);
        }

        public virtual string GetDisplayName()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0} ({1})", base.GetType().FullName, this.Id);
        }

        public virtual string GetDomainId()
        {
            return Convert.ToString(this.Id, CultureInfo.InvariantCulture);
        }

        public override int GetHashCode()
        {
            string domainKey = this.GetDomainId() ?? string.Empty;
            return domainKey.GetHashCode();
        }

        public static bool operator ==(DomainEntity<TKey> referenceObject, DomainEntity<TKey> differenceObject)
        {
            return object.Equals(referenceObject, null) ? object.Equals(differenceObject, null) : referenceObject.Equals(differenceObject);
        }

        public static bool operator >(DomainEntity<TKey> referenceObject, DomainEntity<TKey> differenceObject)
        {
            bool flag = referenceObject == null && differenceObject == null;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                bool flag2 = referenceObject != null && differenceObject == null;
                if (flag2)
                {
                    result = true;
                }
                else
                {
                    bool flag3 = referenceObject == null;
                    result = (!flag3 && referenceObject.CompareTo(differenceObject) > 0);
                }
            }
            return result;
        }

        public static bool operator !=(DomainEntity<TKey> referenceObject, DomainEntity<TKey> differenceObject)
        {
            return !(referenceObject == differenceObject);
        }

        public static bool operator <(DomainEntity<TKey> referenceObject, DomainEntity<TKey> differenceObject)
        {
            bool flag = referenceObject == null && differenceObject == null;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                bool flag2 = referenceObject != null && differenceObject == null;
                if (flag2)
                {
                    result = false;
                }
                else
                {
                    bool flag3 = referenceObject == null;
                    result = (flag3 || referenceObject.CompareTo(differenceObject) < 0);
                }
            }
            return result;
        }

        public override string ToString()
        {
            return this.GetDisplayName();
        }

    }
}
