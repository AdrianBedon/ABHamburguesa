using ABHamburguesa_v2.ABModels;

namespace ABHamburguesa_v2.ABViews;

[QueryProperty(nameof(ItemId),nameof(ItemId))]
public partial class BurguerItemPage : ContentPage
{
    ABBurguer Item = new ABBurguer();
    bool _flag;
	public BurguerItemPage()
	{
		InitializeComponent();
        LoadBurguer();
	}

    public int ItemId
    {
        set { LoadBurguer(value); }
    }

    public void LoadBurguer(int value = -1)
    {
        if (value > -1)
        {
            Item = App.BurguerRepo.GetBurguer(value);
            SaveButton.Text = "Editar";
        }
        
        BindingContext = Item;

    }

    private void ABCheck_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _flag = e.Value;
    }

    private void OnSavedClicked(object sender, EventArgs e)
    {
        Item.Name = ABNameB.Text;
        Item.Description = ABDescB.Text;
        Item.WithExtraCheese = _flag;
        if (SaveButton.Text == "Editar")
        {
            App.BurguerRepo.UpadateBurguer(Item);
        }
        else
        {
            App.BurguerRepo.AddNewBurguer(Item);
        }
        Shell.Current.GoToAsync("..");
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}