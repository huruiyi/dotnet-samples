using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Sample.Models
{
    public class UploadFileModel
    {
        public string Content { get; set; }

        public string FileName { get; set; }

        public int ContentLenght { get; set; }

        public float ImgWidth { get; set; }

        public float ImgHeight { get; set; }

        public float CropX { get; set; }

        public float CropY { get; set; }

        public int CropWidth { get; set; }

        public int CropHeight { get; set; }
    }
}