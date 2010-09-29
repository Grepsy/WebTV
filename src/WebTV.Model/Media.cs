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
    public partial class Media
    {
        #region Primitive Properties
    
        public virtual int MediaId
        {
            get;
            set;
        }
    
        public virtual int AnimationId
        {
            get { return _animationId; }
            set
            {
                if (_animationId != value)
                {
                    if (Animation != null && Animation.AnimationId != value)
                    {
                        Animation = null;
                    }
                    _animationId = value;
                }
            }
        }
        private int _animationId;
    
        public virtual string Url
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> Active
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual Animation Animation
        {
            get { return _animation; }
            set
            {
                if (!ReferenceEquals(_animation, value))
                {
                    var previousValue = _animation;
                    _animation = value;
                    FixupAnimation(previousValue);
                }
            }
        }
        private Animation _animation;
    
        public virtual ICollection<Property> Properties
        {
            get
            {
                if (_properties == null)
                {
                    var newCollection = new FixupCollection<Property>();
                    newCollection.CollectionChanged += FixupProperties;
                    _properties = newCollection;
                }
                return _properties;
            }
            set
            {
                if (!ReferenceEquals(_properties, value))
                {
                    var previousValue = _properties as FixupCollection<Property>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupProperties;
                    }
                    _properties = value;
                    var newValue = value as FixupCollection<Property>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupProperties;
                    }
                }
            }
        }
        private ICollection<Property> _properties;

        #endregion
        #region Association Fixup
    
        private void FixupAnimation(Animation previousValue)
        {
            if (previousValue != null && previousValue.Media.Contains(this))
            {
                previousValue.Media.Remove(this);
            }
    
            if (Animation != null)
            {
                if (!Animation.Media.Contains(this))
                {
                    Animation.Media.Add(this);
                }
                if (AnimationId != Animation.AnimationId)
                {
                    AnimationId = Animation.AnimationId;
                }
            }
        }
    
        private void FixupProperties(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Property item in e.NewItems)
                {
                    item.Medium = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Property item in e.OldItems)
                {
                    if (ReferenceEquals(item.Medium, this))
                    {
                        item.Medium = null;
                    }
                }
            }
        }

        #endregion
    }
}
