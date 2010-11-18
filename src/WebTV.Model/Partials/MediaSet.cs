using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebTV.Model {
    public partial class MediaSet {
        public MediaSet() {
            Name = "Nieuwe fotoset";
            StartDate = DateTime.Now;
            EndDate = StartDate.Value.AddDays(7);
        }

        public MediaSet Copy() {
            var copy = new MediaSet();
            copy.Name = "Kopie van " + this.Name;

            if (EndDate.HasValue && StartDate.HasValue) {
                copy.StartDate = EndDate.Value.AddDays(1);
                copy.EndDate = EndDate.Value.AddDays((EndDate.Value - StartDate.Value).Days);
            }

            foreach (var media in this.Media) {
                copy.Media.Add(media.Copy());
            }

            return copy;
        }
    }
}
