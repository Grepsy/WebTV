using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebTV.Model {
    public partial class Media {
        public Media() {
            this.Properties.Add(new Property() { PropertyDescriptorId = 1 });
            this.Properties.Add(new Property() { PropertyDescriptorId = 2 });
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

        //public Media Copy() {
        //    var copy = new MediaSet();
        //    copy.Name = "Kopie van " + this.Name;

        //    if (EndDate.HasValue && StartDate.HasValue) {
        //        copy.StartDate = EndDate.Value.AddDays(1);
        //        copy.EndDate = EndDate.Value.AddDays((EndDate.Value - StartDate.Value).Days);
        //    }

        //    foreach (var media in this.Media) {
        //        var mediaCopy = new Media() {
        //            Active = media.Active,
        //            Filename = media.Filename,
        //            MediaSet = copy,
        //            MimeType = media.MimeType
        //        };
        //        foreach (var prop in media.Properties) {
        //            mediaCopy.Properties.Add(new Property() {
        //                PropertyDescriptorId = prop.PropertyDescriptorId,
        //                Value = prop.Value
        //            });
        //        }
        //        copy.Media.Add(mediaCopy);
        //    }

        //    return copy;
        //}
    }
}
