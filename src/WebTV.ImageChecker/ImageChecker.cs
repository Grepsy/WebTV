using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace WebTV.Imaging {
    /// <summary>
    /// Checks images to conform to specifications
    /// </summary>
    public class ImageChecker {
        public class Result {
            public bool IsToSmall { get; internal set; }
            public bool IsToLarge { get; internal set; }
            public bool InvalidRatio { get; internal set; }
            public bool UnsupportedFormat { get; internal set; }
            public bool IsOK {
                get {
                    return !(IsToSmall && IsToSmall && InvalidRatio && UnsupportedFormat);
                }
            }
            
            internal Result() {
                IsToSmall = false;
                IsToLarge = false;
                InvalidRatio = false;
                UnsupportedFormat = false;
            }
        }

        public Size MinimalSize { get; set; }
        public Size MaximalSize { get; set; }
        public float Ratio { get; set; }

        public ImageChecker() {
            MinimalSize = new Size(640, 480);
            MaximalSize = new Size(1600, 1200);
            Ratio = 4 / 3;
        }

        public Result Check(Image image) {
            var result = new Result();
            result.UnsupportedFormat = false;

            if (image.Size.Width < MinimalSize.Width ||
                image.Size.Height < MinimalSize.Height) {
                result.IsToSmall = true;
            }

            if (image.Size.Width > MaximalSize.Width ||
                image.Size.Height > MaximalSize.Height) {
                result.IsToLarge = true;
            }

            if ((Ratio != 0) && (image.Width / image.Height != Ratio)) {
                result.InvalidRatio = true;
            }

            return result;
        }

        public Result Check(Stream stream) {
            Image image;
            try {
                image = Image.FromStream(stream);
            }
            catch {
                return new Result { UnsupportedFormat = true };
            }
            return Check(image);
        }
    }
}