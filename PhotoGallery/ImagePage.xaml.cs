namespace PhotoGallery;

public partial class ImagePage : ContentPage
{
    private readonly GalleryViewModel _viewModel;

    public ImagePage(GalleryViewModel viewModel, ImageInfo imageInfo)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = imageInfo;
    }

    private void OnFavoriteTapped(object sender, TappedEventArgs e)
    {
        if (BindingContext is ImageInfo imageInfo)
        {
            imageInfo.IsFavorite = !imageInfo.IsFavorite;
        }
    }

    private async void OnDeleteTapped(object sender, TappedEventArgs e)
    {
        if (BindingContext is ImageInfo imageInfo)
        {
            // Confirm the deletion action
            bool isConfirmed = await DisplayAlert("Delete Image", "Are you sure you want to delete this image?", "Yes", "No");
            if (isConfirmed)
            {
                if (_viewModel.Recents.Contains(imageInfo))
                    _viewModel.Recents.Remove(imageInfo);

                // Remove from Photos collection
                if (_viewModel.Photos.Contains(imageInfo))
                    _viewModel.Photos.Remove(imageInfo);
                else if (_viewModel.Countries.Contains(imageInfo))
                    _viewModel.Countries.Remove(imageInfo);
                else if (_viewModel.Foods.Contains(imageInfo))
                    _viewModel.Foods.Remove(imageInfo);
                else if (_viewModel.Electronics.Contains(imageInfo))
                    _viewModel.Electronics.Remove(imageInfo);
                else if (_viewModel.Birds.Contains(imageInfo))
                    _viewModel.Birds.Remove(imageInfo);


                // Remove from Favorites if it's there
                if (imageInfo.IsFavorite)
                {
                    _viewModel.Favorites.Remove(imageInfo);
                }

                // Navigate back to the main page or previous navigation stack
                await Navigation.PopAsync();
            }
        }
    }

    private void OnShareTapped(object sender, TappedEventArgs e)
    {
        // Add your changes to share the image
    }

    private void OnEditTapped(object sender, TappedEventArgs e)
    {
        // Add your changes to edit the image
    }
}

