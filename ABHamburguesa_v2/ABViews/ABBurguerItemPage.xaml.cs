using ABHamburguesa_v2.ABModels;

namespace ABHamburguesa_v2.ABViews;

[QueryProperty(nameof(ABItemId),nameof(ABItemId))]
public partial class BurguerItemPage : ContentPage
{
    ABBurguer ABItem = new ABBurguer();
    bool _ABflag;
	public BurguerItemPage()
	{
		InitializeComponent();
        LoadBurguer();
	}

    public int ABItemId
    {
        set { LoadBurguer(value); }
    }

    public void LoadBurguer(int value = -1)
    {
        if (value > -1)
        {
            ABItem = App.BurguerRepo.GetBurguer(value);
            SaveButton.Text = "Editar";
        }
        
        BindingContext = ABItem;

    }

    private void ABCheck_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _ABflag = e.Value;
    }

    private void OnSavedClicked(object sender, EventArgs e)
    {
        ABItem.ABName = ABNameB.Text;
        ABItem.ABDescription = ABDescB.Text;
        ABItem.ABWithExtraCheese = _ABflag;
        if (SaveButton.Text == "Editar")
        {
            App.BurguerRepo.UpadateBurguer(ABItem);
        }
        else
        {
            App.BurguerRepo.AddNewBurguer(ABItem);
        }
        Shell.Current.GoToAsync("..");
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}