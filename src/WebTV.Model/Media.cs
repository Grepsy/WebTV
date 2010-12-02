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
    
        public virtual bool Active
        {
            get;
            set;
        }
    
        public virtual string Filename
        {
            get;
            set;
        }
    
        public virtual string MimeType
        {
            get;
            set;
        }
    
        public virtual int MediaSetId
        {
            get { return _mediaSetId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_mediaSetId != value)
                    {
                        if (MediaSet != null && MediaSet.MediaSetId != value)
                        {
                            MediaSet = null;
                        }
                        _mediaSetId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private int _mediaSetId;
    
        public virtual Nullable<int> MediaGroupId
        {
            get { return _mediaGroupId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_mediaGroupId != value)
                    {
                        if (MediaGroup != null && MediaGroup.MediaGroupId != value)
                        {
                            MediaGroup = null;
                        }
                        _mediaGroupId = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _mediaGroupId;

        #endregion
        #region Navigation Properties
    
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
    
        public virtual MediaSet MediaSet
        {
            get { return _mediaSet; }
            set
            {
                if (!ReferenceEquals(_mediaSet, value))
                {
                    var previousValue = _mediaSet;
                    _mediaSet = value;
                    FixupMediaSet(previousValue);
                }
            }
        }
        private MediaSet _mediaSet;
    
        public virtual MediaGroup MediaGroup
        {
            get { return _mediaGroup; }
            set
            {
                if (!ReferenceEquals(_mediaGroup, value))
                {
                    var previousValue = _mediaGroup;
                    _mediaGroup = value;
                    FixupMediaGroup(previousValue);
                }
            }
        }
        private MediaGroup _mediaGroup;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupMediaSet(MediaSet previousValue)
        {
            if (previousValue != null && previousValue.Media.Contains(this))
            {
                previousValue.Media.Remove(this);
            }
    
            if (MediaSet != null)
            {
                if (!MediaSet.Media.Contains(this))
                {
                    MediaSet.Media.Add(this);
                }
                if (MediaSetId != MediaSet.MediaSetId)
                {
                    MediaSetId = MediaSet.MediaSetId;
                }
            }
        }
    
        private void FixupMediaGroup(MediaGroup previousValue)
        {
            if (previousValue != null && previousValue.Media.Contains(this))
            {
                previousValue.Media.Remove(this);
            }
    
            if (MediaGroup != null)
            {
                if (!MediaGroup.Media.Contains(this))
                {
                    MediaGroup.Media.Add(this);
                }
                if (MediaGroupId != MediaGroup.MediaGroupId)
                {
                    MediaGroupId = MediaGroup.MediaGroupId;
                }
            }
            else if (!_settingFK)
            {
                MediaGroupId = null;
            }
        }
    
        private void FixupProperties(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Property item in e.NewItems)
                {
                    item.MediaId = MediaId;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Property item in e.OldItems)
                {
                    item.MediaId = null;
                }
            }
        }

        #endregion
    }
}
