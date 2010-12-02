using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace WebTV.Model {
    public partial class MediaGroup {
        public MediaGroup() {
            this.Properties.Add(new Property() { PropertyDescriptorId = 1 });
            this.Properties.Add(new Property() { PropertyDescriptorId = 2 });
            this.Properties.Add(new Property() { PropertyDescriptorId = 3 });
        }

        public Property PropertyWithName(string name) {
            return Properties.SingleOrDefault(p => p.PropertyDescriptor.Name.Equals(name));
        }

        public MediaGroup Copy() {
            var copy = new MediaGroup() {
                MediaSetId = this.MediaSetId,
            };
            
            foreach (var prop in this.Properties) {
                copy.Properties.Single(p => p.PropertyDescriptorId.Equals(prop.PropertyDescriptorId)).Value = prop.Value;
            }
            return copy;
        }
    }
}
