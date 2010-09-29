//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace WebTV.Model
{
    public partial class Customer
    {
        #region Primitive Properties
    
        public virtual int CustomerId
        {
            get;
            set;
        }
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual string Password
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<Animation> Animations
        {
            get
            {
                if (_animations == null)
                {
                    var newCollection = new FixupCollection<Animation>();
                    newCollection.CollectionChanged += FixupAnimations;
                    _animations = newCollection;
                }
                return _animations;
            }
            set
            {
                if (!ReferenceEquals(_animations, value))
                {
                    var previousValue = _animations as FixupCollection<Animation>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupAnimations;
                    }
                    _animations = value;
                    var newValue = value as FixupCollection<Animation>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupAnimations;
                    }
                }
            }
        }
        private ICollection<Animation> _animations;

        #endregion
        #region Association Fixup
    
        private void FixupAnimations(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Animation item in e.NewItems)
                {
                    item.Customer = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Animation item in e.OldItems)
                {
                    if (ReferenceEquals(item.Customer, this))
                    {
                        item.Customer = null;
                    }
                }
            }
        }

        #endregion
    }
}
