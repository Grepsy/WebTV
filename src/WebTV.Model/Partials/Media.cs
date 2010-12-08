using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace WebTV.Model {
    public partial class Media {
        public static string BaseDir = ConfigurationManager.AppSettings["MediaPath"];

        public Media() {
            this.Properties.Add(new Property() { PropertyDescriptorId = 1 });
            this.Properties.Add(new Property() { PropertyDescriptorId = 2 });
            this.Properties.Add(new Property() { PropertyDescriptorId = 3 });
            
            string fileguid = Guid.NewGuid().ToString();
            this.Filename = fileguid;
        }

        public Property PropertyWithName(string name) {
            return Properties.SingleOrDefault(p => p.PropertyDescriptor.Name.Equals(name));
        }

        public object ToJsonObject(string imageUrl) {
            return new {
                Url = imageUrl + "/" + this.Filename,
                Properties = this.Properties.Select(p => new {
                    Name = p.PropertyDescriptor.Name,
                    Value = p.Value
                })
            };
        }

        public Media Copy() {
            var copy = new Media() {
                Active = this.Active,
                MediaSetId = this.MediaSetId,
                MediaGroupId = this.MediaGroupId,
                MimeType = this.MimeType
            };
            
            File.Copy(Path.Combine(BaseDir, this.Filename), Path.Combine(BaseDir, copy.Filename));
            foreach (var prop in this.Properties) {
                copy.Properties.Single(p => p.PropertyDescriptorId.Equals(prop.PropertyDescriptorId)).Value = prop.Value;
            }
            return copy;
        }
    }
}
