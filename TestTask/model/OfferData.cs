using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTestTask
{
    public class OfferData : IEquatable<OfferData> , IComparable<OfferData>
    {
       

        public OfferData(string name)
        {
            Name = name;
        }
        public OfferData(string name, string key)
        {
            Name = name;
            Key = key;
        }
        public OfferData(string id , string name, string key)
        {
            Id = id;
            Name = name;
            Key = key;
        }

        public bool Equals(OfferData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == (other.Name) && (Key==other.Key);
        }

        public override int GetHashCode()
        {
            return (Name + Key).GetHashCode();
        }

        public override string ToString()
        {
            return Name + " " + Key;
        }
        public int CompareTo(OfferData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Name.CompareTo(other.Name) == 0)
            {
                return Key.CompareTo(other.Key);
            }
            else
            {
                return Key.CompareTo(other.Key);
            }
            
        }
                
        public string Name { get; set; }
        public string Key { get; set; }
        public string Id { get; set; }

    }
}
