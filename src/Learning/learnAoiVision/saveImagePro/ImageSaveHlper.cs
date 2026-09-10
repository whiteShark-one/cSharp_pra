using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learnAoiVision.saveImagePro
{
    /// <summary>
    /// 存图任务实体
    /// </summary>
    public class ImageSaveHlper
    {
        /// <summary>
        /// 名称，约定："工位名，图片文件名"
        /// </summary>
        public string Name{get;set;} = string.Empty;
        /// <summary>
        /// true:OK,false:NG
        /// </summary>
        public bool Result{get;set;}
        /// <summary>
        /// 模拟图像对象，真实项目为 ICogImage
        /// </summary>
        public string SimImageData{get;set;}=string.Empty;

    }
}