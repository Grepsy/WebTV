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
    public partial class Animation
    {
        #region Primitive Properties
    
        public virtual int AnimationId
        {
            get;
            set;
        }
    
        public virtual int CustomerId
        {
            get { return _customerId; }
            set
            {
                if (_customerId != value)
                {
                    if (Customer != null && Customer.CustomerId != value)
                    {
                        Customer = null;
                    }
                    _customerId = value;
                }
            }
        }
        private int _customerId;
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual int MediaGroupedBy
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual Customer Customer
        {
            get { return _customer; }
            set
            {
                if (!ReferenceEquals(_customer, value))
                {
                    var previousValue = _customer;
                    _customer = value;
                    FixupCustomer(previousValue);
                }
            }
        }
        private Customer _customer;
    
        public virtual ICollection<Log> Logs
        {
            get
            {
                if (_logs == null)
                {
                    var newCollection = new FixupCollection<Log>();
                    newCollection.CollectionChanged += FixupLogs;
                    _logs = newCollection;
                }
                return _logs;
            }
            set
            {
                if (!ReferenceEquals(_logs, value))
                {
                    var previousValue = _logs as FixupCollection<Log>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupLogs;
                    }
                    _logs = value;
                    var newValue = value as FixupCollection<Log>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupLogs;
                    }
                }
            }
        }
        private ICollection<Log> _logs;
    
        public virtual ICollection<PropertyDescriptor> PropertyDescriptors
        {
            get
            {
                if (_propertyDescriptors == null)
                {
                    var newCollection = new FixupCollection<PropertyDescriptor>();
                    newCollection.CollectionChanged += FixupPropertyDescriptors;
                    _propertyDescriptors = newCollection;
                }
                return _propertyDescriptors;
            }
            set
            {
                if (!ReferenceEquals(_propertyDescriptors, value))
                {
                    var previousValue = _propertyDescriptors as FixupCollection<PropertyDescriptor>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupPropertyDescriptors;
                    }
                    _propertyDescriptors = value;
                    var newValue = value as FixupCollection<PropertyDescriptor>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupPropertyDescriptors;
                    }
                }
            }
        }
        private ICollection<PropertyDescriptor> _propertyDescriptors;
    
        public virtual ICollection<MediaSet> MediaSets
        {
            get
            {
                if (_mediaSets == null)
                {
                    var newCollection = new FixupCollection<MediaSet>();
                    newCollection.CollectionChanged += FixupMediaSets;
                    _mediaSets = newCollection;
                }
                return _mediaSets;
            }
            set
            {
                if (!ReferenceEquals(_mediaSets, value))
                {
                    var previousValue = _mediaSets as FixupCollection<MediaSet>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupMediaSets;
                    }
                    _mediaSets = value;
                    var newValue = value as FixupCollection<MediaSet>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupMediaSets;
                    }
                }
            }
        }
        private ICollection<MediaSet> _mediaSets;

        #endregion
        #region Association Fixup
    
        private void FixupCustomer(Customer previousValue)
        {
            if (previousValue != null && previousValue.Animations.Contains(this))
            {
                previousValue.Animations.Remove(this);
            }
    
            if (Customer != null)
            {
                if (!Customer.Animations.Contains(this))
                {
                    Customer.Animations.Add(this);
                }
                if (CustomerId != Customer.CustomerId)
                {
                    CustomerId = Customer.CustomerId;
                }
            }
        }
    
        private void FixupLogs(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Log item in e.NewItems)
                {
                    item.Animation = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Log item in e.OldItems)
                {
                    if (ReferenceEquals(item.Animation, this))
                    {
                        item.Animation = null;
                    }
                }
            }
        }
    
        private void FixupPropertyDescriptors(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (PropertyDescriptor item in e.NewItems)
                {
                    if (!item.Animations.Contains(this))
                    {
                        item.Animations.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (PropertyDescriptor item in e.OldItems)
                {
                    if (item.Animations.Contains(this))
                    {
                        item.Animations.Remove(this);
                    }
                }
            }
        }
    
        private void FixupMediaSets(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (MediaSet item in e.NewItems)
                {
                    item.Animation = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (MediaSet item in e.OldItems)
                {
                    if (ReferenceEquals(item.Animation, this))
                    {
                        item.Animation = null;
                    }
                }
            }
        }

        #endregion
    }
}
