using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PhotoGallery
{
    public class GalleryViewModel
    {
        public ObservableCollection<ImageInfo> Photos { get; set; }
        public ObservableCollection<ImageInfo> Countries { get; set; }
        public ObservableCollection<ImageInfo> Birds { get; set; }
        public ObservableCollection<ImageInfo> Electronics { get; set; }
        public ObservableCollection<ImageInfo> Foods { get; set; }
        public ObservableCollection<ImageInfo> Recents { get; set; }
        public ObservableCollection<ImageInfo> Favorites { get; set; }

        public ObservableCollection<AlbumInfo> Albums { get; set; }
        public string SelectedCollectionName { get; set; }
        public string SelectedImageName { get; set; }

        public GalleryViewModel()
        {
            GeneratePhotos();
            GenerateAlbums();
        }

        private void GeneratePhotos()
        {
            DateTime dateTime = DateTime.Now.Date;
            Photos = new ObservableCollection<ImageInfo>()
            {
               new ImageInfo() { ImageName = "place_1", Image= "place_1.jpg",Size= "2MB",DateTime=  dateTime.AddHours(15)},
               new ImageInfo() { ImageName = "bird01", Image= "bird01.png",Size= "2MB",DateTime= dateTime.AddDays(-1).AddHours(8)},
               new ImageInfo() { ImageName = "place_2", Image= "place_2.jpg",Size= "2MB",DateTime= dateTime.AddDays(-1).AddHours(15)},
               new ImageInfo() { ImageName = "place_5", Image= "place_5.jpg",Size= "2MB",DateTime= dateTime.AddDays(-20).AddHours(11)},
               new ImageInfo() { ImageName = "place_6", Image= "place_6.jpg",Size= "2MB",DateTime= dateTime.AddDays(-25).AddHours(9)},
               new ImageInfo() { ImageName = "cake", Image= "cake.png",Size= "2MB",DateTime= dateTime.AddDays(-25).AddHours(20)},
               new ImageInfo() { ImageName = "India", Image= "india.jpg",Size= "2MB",DateTime= dateTime.AddDays(-27).AddHours(10), IsFavorite = true},
               new ImageInfo() { ImageName = "place_3", Image= "place_3.jpg",Size= "2MB",DateTime= dateTime.AddDays(-27).AddHours(10)},
               new ImageInfo() { ImageName = "place_4", Image= "place_4.jpg",Size= "2MB",DateTime= dateTime.AddDays(-27).AddHours(8)},
               new ImageInfo() { ImageName = "sandwiches", Image= "sandwiches.png",Size= "2MB",DateTime= dateTime.AddDays(-52).AddHours(16)},
               new ImageInfo() { ImageName = "place_7", Image= "place_7.jpg",Size= "2MB",DateTime= dateTime.AddDays(-30).AddHours(15),IsFavorite = true},
               new ImageInfo() { ImageName = "place_8", Image= "place_8.jpg",Size= "2MB",DateTime= dateTime.AddDays(-40).AddHours(14)},
               new ImageInfo() { ImageName = "monitors", Image= "monitors.png",Size= "2MB",DateTime= dateTime.AddDays(-45).AddHours(14)},
               new ImageInfo() { ImageName = "place_9", Image= "place_9.jpg",Size= "2MB",DateTime= dateTime.AddDays(-50).AddHours(13)},
               new ImageInfo() { ImageName = "bird10", Image= "bird10.jpg",Size= "2MB",DateTime= dateTime.AddMonths(-2).AddHours(16)},
               new ImageInfo() { ImageName = "place_10", Image= "place_10.jpg",Size= "2MB",DateTime= dateTime.AddYears(-1).AddHours(16)},
           };

            Countries = new ObservableCollection<ImageInfo>()
            {
                new ImageInfo() { ImageName = "Argentina", Image= "argentina.jpg",Size= "2MB",DateTime= dateTime.AddHours(10)},
                new ImageInfo() { ImageName = "Austria", Image= "austria.jpg",Size= "2MB",DateTime= dateTime.AddDays(-2).AddHours(11)},
                new ImageInfo() { ImageName = "Barcelona", Image= "barcelona.jpg",Size= "2MB",DateTime= dateTime.AddDays(-2).AddHours(14)},
                new ImageInfo() { ImageName = "Brazil", Image= "brazil.jpg",Size= "2MB",DateTime= dateTime.AddDays(-14).AddHours(18)},
                new ImageInfo() { ImageName = "Colombia", Image= "colombia.jpg",Size= "2MB",DateTime= dateTime.AddDays(-18).AddHours(11)},
                new ImageInfo() { ImageName = "Germany", Image= "germany.jpg",Size= "2MB",DateTime= dateTime.AddDays(-13).AddHours(13)},
                new ImageInfo() { ImageName = "India", Image= "india.jpg",Size= "2MB",DateTime= dateTime.AddDays(-27).AddHours(10)},
                new ImageInfo() { ImageName = "callingmyphone", Image= "callingmyphone.png",Size= "2MB",DateTime= dateTime.AddDays(-36).AddHours(9)},
                new ImageInfo() { ImageName = "Italy", Image= "italy.jpg",Size= "2MB",DateTime= dateTime.AddDays(-41).AddHours(14)},
                new ImageInfo() { ImageName = "Switzerland", Image= "switzerland.jpg",Size= "2MB",DateTime= dateTime.AddDays(-48).AddHours(15)},
                new ImageInfo() { ImageName = "Sydney", Image= "sydney.jpg",Size= "2MB",DateTime= dateTime.AddDays(-54).AddHours(17)},
                new ImageInfo() { ImageName = "Thailand", Image= "thailand.jpg",Size= "2MB",DateTime= dateTime.AddDays(-58).AddHours(13)},
                new ImageInfo() { ImageName = "Turkey", Image= "turkey.jpg",Size= "2MB",DateTime= dateTime.AddDays(-65).AddHours(8)},
                new ImageInfo() { ImageName = "USA", Image= "usa.jpg",Size= "2MB",DateTime= dateTime.AddDays(-70).AddHours(9)},
            };

            Birds = new ObservableCollection<ImageInfo>()
            {
                new ImageInfo() { ImageName = "bird02", Image= "bird02.png",Size= "2MB",DateTime= dateTime.AddDays(-1).AddHours(12)},
                new ImageInfo() { ImageName = "bird03", Image= "bird03.png",Size= "2MB",DateTime= dateTime.AddDays(-3).AddHours(11)},
                new ImageInfo() { ImageName = "bird04", Image= "bird04.png",Size= "2MB",DateTime= dateTime.AddDays(-3).AddHours(10)},
               new ImageInfo() { ImageName = "bird05", Image= "bird05.png",Size= "2MB",DateTime= dateTime.AddDays(-13).AddHours(12)},
                new ImageInfo() { ImageName = "bird06", Image= "bird06.png",Size= "2MB",DateTime= dateTime.AddDays(-9).AddHours(15)},
                new ImageInfo() { ImageName = "bird07", Image= "bird07.png",Size= "2MB",DateTime= dateTime.AddDays(-13).AddHours(12), IsFavorite = true},
                new ImageInfo() { ImageName = "bird08", Image= "bird08.png",Size= "2MB",DateTime= dateTime.AddDays(-15).AddHours(11)},
                new ImageInfo() { ImageName = "bird09", Image= "bird09.png",Size= "2MB",DateTime= dateTime.AddDays(-23).AddHours(13)},
                new ImageInfo() { ImageName = "bird10", Image= "bird10.jpg",Size= "2MB",DateTime= dateTime.AddMonths(-2).AddHours(16)},
            };

            Foods = new ObservableCollection<ImageInfo>()
            {
                new ImageInfo() { ImageName = "bread", Image= "bread.png",Size= "2MB",DateTime= dateTime.AddDays(-1).AddHours(16)},
                new ImageInfo() { ImageName = "brownie", Image= "brownie.png",Size= "2MB",DateTime= dateTime.AddDays(-6).AddHours(14)},
                new ImageInfo() { ImageName = "bucolicpie", Image= "bucolicpie.png",Size= "2MB",DateTime= dateTime.AddDays(-6).AddHours(12)},
                new ImageInfo() { ImageName = "caffe", Image= "caffe.png",Size= "2MB",DateTime= dateTime.AddDays(-6).AddHours(18)},
                new ImageInfo() { ImageName = "bumpercrop", Image= "bumpercrop.png",Size= "2MB",DateTime= dateTime.AddDays(-25).AddHours(14)},
                new ImageInfo() { ImageName = "cookie", Image= "cookie.png",Size= "2MB",DateTime= dateTime.AddDays(-28).AddHours(19)},
                new ImageInfo() { ImageName = "cupcake", Image= "cupcake.png",Size= "2MB",DateTime= dateTime.AddDays(-32).AddHours(16)},
                new ImageInfo() { ImageName = "egg", Image= "egg.png",Size= "2MB",DateTime= dateTime.AddDays(-36).AddHours(15)},
                new ImageInfo() { ImageName = "food", Image= "food.png",Size= "2MB",DateTime= dateTime.AddDays(-41).AddHours(14)},
                new ImageInfo() { ImageName = "pasta", Image= "pasta.png",Size= "2MB",DateTime= dateTime.AddDays(-44).AddHours(19), IsFavorite = true},
                new ImageInfo() { ImageName = "pancakes", Image= "pancakes.png",Size= "2MB",DateTime= dateTime.AddDays(-48).AddHours(17)},
                new ImageInfo() { ImageName = "soup", Image= "soup.png",Size= "2MB",DateTime= dateTime.AddDays(-56).AddHours(20)},
                new ImageInfo() { ImageName = "thairecipe", Image= "thairecipe.png",Size= "2MB",DateTime= dateTime.AddDays(-59).AddHours(14)},
            };

            Electronics = new ObservableCollection<ImageInfo>()
            {
                new ImageInfo() { ImageName = "blindinglights", Image= "blindinglights.png",Size= "2MB",DateTime= dateTime.AddHours(20)},
                new ImageInfo() { ImageName = "body", Image= "body.png",Size= "2MB",DateTime= dateTime.AddDays(-1).AddHours(11)},
                new ImageInfo() { ImageName = "callingmyphone", Image= "callingmyphone.png",Size= "2MB",DateTime= dateTime.AddDays(-1).AddHours(12)},
                new ImageInfo() { ImageName = "camera", Image= "camera.png",Size= "2MB",DateTime= dateTime.AddDays(-1).AddHours(19), IsFavorite = true},
                new ImageInfo() { ImageName = "computeraccessories", Image= "computeraccessories.png",Size= "2MB",DateTime= dateTime.AddDays(-1).AddHours(13)},
                new ImageInfo() { ImageName = "mobile", Image= "mobile.png",Size= "2MB",DateTime= dateTime.AddDays(-3).AddHours(15)},
                new ImageInfo() { ImageName = "printers", Image= "printers.png",Size= "2MB",DateTime= dateTime.AddDays(-5).AddHours(12)},
                new ImageInfo() { ImageName = "router", Image= "router.png",Size= "2MB",DateTime= dateTime.AddDays(-5).AddHours(11)},
            };

            Recents = new ObservableCollection<ImageInfo>();

            foreach (var category in new[] { Photos, Countries, Birds, Foods, Electronics })
            {
                foreach (var photo in category)
                {
                    photo.PropertyChanged += ImageInfo_PropertyChanged;
                }

                // Add to Recents
                Recents = new ObservableCollection<ImageInfo>(Recents.Concat(category));
            }

            var sortedRecentList = Recents.OrderByDescending(item => item.DateTime).ToList();
            Recents.Clear();
            foreach (var item in sortedRecentList)
            {
                Recents.Add(item);
            }

            // Initialize Favorites and add favorite images
            Favorites = new ObservableCollection<ImageInfo>();
            foreach (var photo in Recents)
            {
                if (photo.IsFavorite)
                {
                    Favorites.Add(photo);
                }
            }

        }

        private void GenerateAlbums()
        {
            Albums = new ObservableCollection<AlbumInfo>()
            {
                new AlbumInfo() { AlbumName = "Recents", CoverImage = "place_1.jpg", Count=58, Photos = Recents },
                new AlbumInfo() { AlbumName = "Countries", CoverImage = "argentina.jpg", Count=13, Photos = Countries },
                new AlbumInfo() { AlbumName = "Electronics", CoverImage = "blindinglights.png", Count=8, Photos = Electronics },
                new AlbumInfo() { AlbumName = "Birds", CoverImage = "bird01.png",Count=10, Photos = Birds },
                new AlbumInfo() { AlbumName = "Foods", CoverImage = "bread.png", Count=15, Photos = Foods },
            };
        }

        private void ImageInfo_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is ImageInfo imageInfo && e.PropertyName == nameof(ImageInfo.IsFavorite))
            {
                if (imageInfo.IsFavorite && !Favorites.Contains(imageInfo))
                {
                    Favorites.Add(imageInfo);
                }
                else if (!imageInfo.IsFavorite && Favorites.Contains(imageInfo))
                {
                    Favorites.Remove(imageInfo);
                }
            }
        }
    }
}
