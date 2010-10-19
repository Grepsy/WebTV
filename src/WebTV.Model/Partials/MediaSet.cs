using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebTV.Model {
    public partial class MediaSet {
        public MediaSet() {
            Name = "Default name";
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(7);
        }

        public MediaSet Copy() {
            var copy = new MediaSet();
            copy.Name = "Kopie van " + this.Name;

            if (EndDate.HasValue && StartDate.HasValue) {
                copy.StartDate = EndDate.Value.AddDays(1);
                copy.EndDate = EndDate.Value.AddDays((EndDate.Value - StartDate.Value).Days);
            }
            foreach (var media in this.Media) {
                var mediaCopy = new Media() {
                    Active = media.Active,
                    Filename = media.Filename,
                    MediaSet = copy,
                    MimeType = media.MimeType
                };
                foreach (var prop in media.Properties) {
                    mediaCopy.Properties.Add(new Property() {
                        PropertyDescriptorId = prop.PropertyDescriptorId,
                        Value = prop.Value
                    });
                }
                copy.Media.Add(mediaCopy);
            }
            return copy;
        }
    }
}
