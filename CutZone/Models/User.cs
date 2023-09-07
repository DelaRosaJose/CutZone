using CommunityToolkit.Mvvm.ComponentModel;
using CutZone.Models.Base;

namespace CutZone.Models
{
    public partial class User : BaseModel<User>
    {

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string password;

    }
}

