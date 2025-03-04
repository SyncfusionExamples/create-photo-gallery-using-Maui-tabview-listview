using System.Collections.ObjectModel;

namespace PhotoGallery
{
    public class AlbumInfo
    {
        public string AlbumName { get; set; }
        public string CoverImage { get; set; }
        public double Count { get; set; }
        public ObservableCollection<ImageInfo> Photos { get; set; }
    }
}
