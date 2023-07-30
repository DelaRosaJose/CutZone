using CommunityToolkit.Maui.Views;

namespace CutZone;

public partial class MainPage : Pages.BasePage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    public override void Build()
    {
        
    }

    private void OnCounterClicked(object sender, EventArgs e)
	{
        //count++;

        //if (count == 1)
        //    CounterBtn.Text = $"Clicked {count} time";
        //else
        //    CounterBtn.Text = $"Clicked {count} timesww";

        this.ShowPopup(new Pages.LoginPopup());

        //SemanticScreenReader.Announce(CounterBtn.Text);
    }
}

