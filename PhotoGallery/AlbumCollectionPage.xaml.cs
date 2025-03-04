using Syncfusion.Maui.DataSource;
using System.Globalization;

namespace PhotoGallery;

public partial class AlbumCollectionPage : ContentPage
{

    private readonly GalleryViewModel _viewModel;

    public AlbumCollectionPage(GalleryViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        listView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
        {
            PropertyName = "DateTime",
            KeySelector = (object obj1) =>
            {
                var item = obj1 as ImageInfo;
                if (item != null)
                {
                    if (item.DateTime.Date == DateTime.Now.Date)
                    {
                        return "Today";
                    }
                    else if (item.DateTime.Year == DateTime.Now.Year)
                    {
                        return item.DateTime.ToString("MMM dd", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        return item.DateTime.ToString("MMM dd yyyy", CultureInfo.InvariantCulture);
                    }
                }
                else
                {
                    return "";
                }
            }
        });
    }

    private void OnPhotosItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
    {

        ImagePage imagePage = new ImagePage(_viewModel, e.DataItem as ImageInfo);
        imagePage.BindingContext = e.DataItem as ImageInfo;
        Navigation.PushAsync(imagePage);
    }
}