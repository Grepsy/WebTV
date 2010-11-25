using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebTV.Model {
    public partial class Media {
        public Media() {
            this.Properties.Add(new Property() { PropertyDescriptorId = 1 });
            this.Properties.Add(new Property() { PropertyDescriptorId = 2 });
            this.Properties.Add(new Property() { PropertyDescriptorId = 3 });
        }

        public Property PropertyWithName(string name) {
            return Properties.SingleOrDefault(p => p.PropertyDescriptor.Name.Equals(name));
        }

        public Media Copy() {
            var copy = new Media() {
                Active = this.Active,
                Filename = this.Filename,
                MediaSet = this.MediaSet,
                MimeType = this.MimeType
            };
            foreach (var prop in this.Properties) {
                copy.Properties.Add(new Property() {
                    PropertyDescriptorId = prop.PropertyDescriptorId,
                    Value = prop.Value
                });
            }
            return copy;
        }
    }
}
