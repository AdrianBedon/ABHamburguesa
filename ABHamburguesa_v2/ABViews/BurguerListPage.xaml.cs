using ABHamburguesa_v2.ABModels;

namespace ABHamburguesa_v2.ABViews;

public partial class BurguerListPage : ContentPage
{
	public BurguerListPage()
	{
		InitializeComponent();
		LoadData();
	}

    protected override void OnAppearing()
    {
        LoadData();
    }

    public void LoadData()
	{
        List<ABBurguer> burguer = App.BurguerRepo.GetAllBurguers();
        ABburguerList.ItemsSource = burguer;
    }
	async void OnItemAdded(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(BurguerItemPage));
    }

    
}