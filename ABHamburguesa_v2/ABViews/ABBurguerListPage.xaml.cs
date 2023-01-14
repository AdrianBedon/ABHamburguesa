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

    private async void burguersCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var burguer = (ABModels.ABBurguer)e.CurrentSelection[0];

            string action = await DisplayActionSheet("Seleccione la acción que desea realizar:", "Cancel", null, "Editar", "Borrar");

            if (action == "Editar")
            {
                await Shell.Current.GoToAsync($"{nameof(BurguerItemPage)}?{nameof(BurguerItemPage.ItemId)}={burguer.ID}");
            }
            else if (action == "Borrar")
            {
                App.BurguerRepo.DeleteBurguer(burguer);
                LoadData();
            }
            else
            {
                LoadData();
            }

            ABburguerList.SelectedItem = null;
        }
    }
}