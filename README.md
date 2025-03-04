# create-photo-gallery-using-Maui-tabview-listview
This repository holds the demo to create a stunning photo gallery using Syncfusion TabView and ListView controls in .NET Maui.

Steps to create your stunning photo gallery:
Follow these steps to create your stunning photo gallery:
## 1.	Create a simple .NET MAUI Tab View
Start by creating a MAUI application. Refer to the Syncfusion .NET Maui TabView documentation for detailed instructions on setup. Include the following basic TabView:

```
 <tabView:SfTabView />

```
## 2.	Add Multiple Tabs with Headers 
Add tabs with different headers to categorize your images:

```
        <tabView:SfTabView x:Name="tabView">
            <tabView:SfTabView.Items>
                <tabView:SfTabItem Header="Photos"/>
                <tabView:SfTabItem Header="Albums"/>
                <tabView:SfTabItem Header="Favorites"/>
            </tabView:SfTabView.Items>
        </tabView:SfTabView>

```

## 3.	Add ListView as Content for Each Tab 
You can refer to the Syncfusion .NET Maui ListView documentation to  create the Maui ListView. Include a List View for displaying photos within each tab. Here's how you can set it up:

```
<tabView:SfTabItem Header="Photos">
    <tabView:SfTabItem.Content>
        <listView:SfListView>
            <listView:SfListView.ItemTemplate>
                <DataTemplate>  
                    <!-- Bind your ImageData here -->
                </DataTemplate>
            </listView:SfListView.ItemTemplate>
        </listView:SfListView>
    </tabView:SfTabItem.Content>
</tabView:SfTabItem>
```

## 4.	Populate Items in the ListView 

### 1.	Define Model Classes
Create model classes to hold image data, such as ImageInfo and AlbumInfo. Define properties related to each photo:

**ImageInfo.cs**

```
public class ImageInfo : INotifyPropertyChanged
{
    private string imageName;
    private string image;
    private string size;
    private DateTime dateTime;
    private bool isFavorite;
    
    // Properties with Change Notification
    public string ImageName
    {
        get => imageName;
        set
        {
            imageName = value;
            OnPropertyChanged();
        }
    }

    // Similar properties for other fields...
    
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```

**AlbumInfo.cs**

```
    public class AlbumInfo
    {
        public string AlbumName { get; set; }
        public string CoverImage { get; set; }
        public double Count { get; set; }
        public ObservableCollection<ImageInfo> Photos { get; set; }
    }
```

### 2. Create a ViewModel to Manage Your Data
Use a GalleryViewModel class to generate and manage collections of images and albums.

**GalleryViewModel.cs**
```
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

    public GalleryViewModel()
    {
        GeneratePhotos();
        GenerateAlbums();
    }

    // Method to generate a collection of images
    private void GeneratePhotos()
    {
        DateTime dateTime = DateTime.Now.Date;
        Photos = new ObservableCollection<ImageInfo>
        {
            new ImageInfo { ImageName = "place_1", Image = "place_1.jpg", Size = "2MB", DateTime = dateTime.AddHours(15) },
            new ImageInfo { ImageName = "bird01", Image = "bird01.png", Size = "2MB", DateTime = dateTime.AddDays(-1).AddHours(8) },
            new ImageInfo { ImageName = "India", Image = "india.jpg", Size = "2MB", DateTime = dateTime.AddDays(-27).AddHours(10), IsFavorite = true },
            // Additional images...
        };

        // Consolidate images into a single 'Recents' collection
        Recents = new ObservableCollection<ImageInfo>();
        foreach (var category in new[] { Photos, Countries, Birds, Foods, Electronics })
        {
            Recents = new ObservableCollection<ImageInfo>(Recents.Concat(category));
        }

        // Sort recent images by date
        var sortedRecentList = Recents.OrderByDescending(item => item.DateTime).ToList();
        Recents.Clear();
        foreach (var item in sortedRecentList)
        {
            Recents.Add(item);
        }

        // Initialize favorites
        Favorites = new ObservableCollection<ImageInfo>();
        foreach (var photo in Recents)
        {
            if (photo.IsFavorite)
            {
                Favorites.Add(photo);
            }
        }
    }

    // Method to generate albums
    private void GenerateAlbums()
    {
        Albums = new ObservableCollection<AlbumInfo>
        {
            new AlbumInfo { AlbumName = "Recents", CoverImage = "place_1.jpg", Count = 58, Photos = Recents },
            new AlbumInfo { AlbumName = "Countries", CoverImage = "argentina.jpg", Count = 13, Photos = Countries },
            new AlbumInfo { AlbumName = "Electronics", CoverImage = "blindinglights.png", Count = 8, Photos = Electronics },
            new AlbumInfo { AlbumName = "Birds", CoverImage = "bird01.png", Count = 10, Photos = Birds },
            new AlbumInfo { AlbumName = "Foods", CoverImage = "bread.png", Count = 15, Photos = Foods },
        };
    }
}
```

## 5.	Bind the Image Collection to the ListView
In your MainPage.xaml, define the layout and bind your image data to display within the ListView:

**MainPage.Xaml**
```
<tabView:SfTabView>
    <!-- Photos Tab -->
    <tabView:SfTabItem Header="Photos">
        <listView:SfListView x:Name="listViewPhotos" ItemsSource="{Binding Photos}" ItemSize="200" ItemSpacing="10">
            <listView:SfListView.ItemsLayout>
                <listView:GridLayout SpanCount="3" />
            </listView:SfListView.ItemsLayout>
            <listView:SfListView.ItemTemplate>
                <DataTemplate>
                    <Image Source="{Binding Image}" Aspect="AspectFill"/>
                </DataTemplate>
            </listView:SfListView.ItemTemplate>
        </listView:SfListView>
    </tabView:SfTabItem>

    <!-- Albums Tab -->
    <tabView:SfTabItem Header="Albums">
        <listView:SfListView ItemsSource="{Binding Albums}" ItemSize="200" ItemSpacing="10">
            <listView:SfListView.ItemsLayout>
                <listView:GridLayout SpanCount="3" />
            </listView:SfListView.ItemsLayout>
            <listView:SfListView.ItemTemplate>
                <DataTemplate>
                    <Grid RowDefinitions="*,20,20">
                        <Image Source="{Binding CoverImage}" Aspect="AspectFill" />
                        <Label Text="{Binding AlbumName}" FontSize="15" Grid.Row="1"/>
                        <Label Text="{Binding Count}" FontSize="12" Grid.Row="2" />
                    </Grid>
                </DataTemplate>
            </listView:SfListView.ItemTemplate>
        </listView:SfListView>
    </tabView:SfTabItem>

    <!-- Favorites Tab -->
    <tabView:SfTabItem Header="Favorites">
        <listView:SfListView ItemsSource="{Binding Favorites, Mode=TwoWay}" ItemSize="300" ItemSpacing="10">
            <listView:SfListView.ItemsLayout>
                <listView:GridLayout SpanCount="2" />
            </listView:SfListView.ItemsLayout>
            <listView:SfListView.ItemTemplate>
                <DataTemplate>
                    <Grid RowDefinitions="20,*">
                        <Label Text="{Binding DateTime, StringFormat='{0:ddd, dd MMM, yyyy}'}" />
                        <Image Source="{Binding Image}" Aspect="AspectFill" Grid.Row="1"/>
                    </Grid>
                </DataTemplate>
            </listView:SfListView.ItemTemplate>
        </listView:SfListView>
    </tabView:SfTabItem>
</tabView:SfTabView>
```

## 6.	Create Pages to Display Images
### Step 1: Create a Page to Display an Individual Image
You need a simple content page to show a single image when a user selects it from your photo gallery.

**ImagePage.Xaml**
```
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="PhotoGallery.ImagePage"
             Title="Image Details">
    <Grid RowDefinitions="*,60">
        <Image Source="{Binding Image}" Aspect="AspectFit"/>
    </Grid>
</ContentPage>
```

### Step 2: Create a Page to Display Images from an Album
To show a collection of images within an album, create another content page. This will use a ListView to display all images associated with a selected album.

**AlbumCollectionPage.Xaml**
```
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:listView="clr-namespace:Syncfusion.Maui.ListView;assembly=Syncfusion.Maui.ListView"
             x:Class="PhotoGallery.AlbumCollectionPage"
             Title="{Binding AlbumName}">
    <Grid>
        <listView:SfListView x:Name="listView" ItemsSource="{Binding Photos}" ItemSize="200" ItemSpacing="10">
            <listView:SfListView.ItemsLayout>
                <listView:GridLayout SpanCount="3" />
            </listView:SfListView.ItemsLayout>
            <listView:SfListView.ItemTemplate>
                <DataTemplate>
                    <Image Source="{Binding Image}" Aspect="AspectFill"/>
                </DataTemplate>
            </listView:SfListView.ItemTemplate>
        </listView:SfListView>
    </Grid>
</ContentPage>
```

## 7.	Implementing Navigation with Tapped Events

### Step 1: Define the ItemTapped Event in XAML
In your XAML file, define the ItemTapped event in ListView for navigation. This allows users to navigate to a detailed view of the photo when they tap on an image in the list.

**MainPage.Xaml**
```
<tabView:SfTabView>
    <tabView:SfTabItem Header="Photos" x:Name="photosTab" ImageTextSpacing="5">
        <!-- ListView for displaying photos -->
        <listView:SfListView x:Name="listViewPhotos" 
                             ItemsSource="{Binding Photos}" 
                             ItemSize="200" 
                             ItemSpacing="10"
                             ItemTapped="OnPhotosItemTapped">
            <!-- ItemTemplate and other configurations -->
        </listView:SfListView>
    </tabView:SfTabItem>
...
</tabView:SfTabView>
```

### Step 2: Implement Navigation in the Code-Behind
In your code-behind file, implement the logic to navigate to the image details page when an item is tapped.

**MainPage.Xaml.cs**
```
        private void OnPhotosItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
        {
                // Create an instance of ImagePage
            ImagePage imagePage = new ImagePage(this.BindingContext as GalleryViewModel, e.DataItem as ImageInfo); 
            imagePage.BindingContext = e.DataItem as ImageInfo; // Pass the selected image to the new page

            // Navigate to the ImagePage
            Navigation.PushAsync(imagePage);
        }
```
