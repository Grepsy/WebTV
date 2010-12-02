using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace WebTV.Model {
    public partial class Media {
        private string baseDir = ConfigurationManager.AppSettings["MediaPath"];

        public Media() {
            this.Properties.Add(new Property() { PropertyDescriptorId = 1 });
            this.Properties.Add(new Property() { PropertyDescriptorId = 2 });
            this.Properties.Add(new Property() { PropertyDescriptorId = 3 });
            
            string fileguid = Guid.NewGuid().ToString();
            this.Filename = Path.Combine(baseDir, fileguid);
        }

        public Property PropertyWithName(string name) {
            return Properties.SingleOrDefault(p => p.PropertyDescriptor.Name.Equals(name));
        }

        public Media Copy() {
            var copy = new Media() {
                Active = this.Active,
                MediaSetId = this.MediaSetId,
                MediaGroupId = this.MediaGroupId,
                MimeType = this.MimeType
            };
            
            File.Copy(Path.Combine(baseDir, this.Filename), Path.Combine(baseDir, copy.Filename));
            foreach (var prop in this.Properties) {
                copy.Properties.Single(p => p.PropertyDescriptorId.Equals(prop.PropertyDescriptorId)).Value = prop.Value;
            }
            return copy;
        }
    }
}
